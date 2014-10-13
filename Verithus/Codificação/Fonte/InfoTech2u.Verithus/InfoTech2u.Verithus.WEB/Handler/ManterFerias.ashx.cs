using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InfoTech2u.Verithus.Util;
using System.Data;
using InfoTech2u.Verithus.BS;
using InfoTech2u.Verithus.VO;

namespace InfoTech2u.Verithus.WEB.Handler
{
    /// <summary>
    /// Summary description for ManterFerias
    /// </summary>
    public class ManterFerias : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            if (context.Request.QueryString["Metodo"] == "Selecionar")
            {
                var retorno = SelecionarFerias(context);

                context.Response.Write(retorno.Serializer());
            }
            else if (context.Request.QueryString["Metodo"] == "Gravar")
            {
                context.Response.Write(GravarFerias(context).Serializer());
            }
        }

        private DataTable SelecionarFerias(HttpContext context)
        {
            FeriasBS objBS = new FeriasBS();
            FeriasVO dadosFerias = new FeriasVO();

            int codigoFuncionario = 0;
            if (Int32.TryParse(context.Request.QueryString["CodigoFuncionario"], out codigoFuncionario))
            {
                dadosFerias.CodigoFuncionario = codigoFuncionario;
            }

            return objBS.SelecionarFerias(dadosFerias);
        }

        private DataTable GravarFerias(HttpContext context)
        {
            FeriasBS objBS = new FeriasBS();
            FeriasVO dadosFerias = new FeriasVO();

            int codigoFerias = 0;
            if (Int32.TryParse(context.Request.QueryString["CodigoFerias"], out codigoFerias))
            {
                dadosFerias.CodigoFerias = codigoFerias;
            }

            int codigoFuncionario = 0;
            if (Int32.TryParse(context.Request.QueryString["CodigoFuncionario"], out codigoFuncionario))
            {
                dadosFerias.CodigoFuncionario = codigoFuncionario;
            }

            DateTime dataPeriodoInicio;
            if (DateTime.TryParse(context.Request.QueryString["DataPeriodoInicio"], out dataPeriodoInicio))
            {
                dadosFerias.DataPeriodoInicio = dataPeriodoInicio;
            }

            DateTime dataPeriodoFim;
            if (DateTime.TryParse(context.Request.QueryString["DataPeriodoFim"], out dataPeriodoFim))
            {
                dadosFerias.DataPeriodoFim = dataPeriodoFim;
            }

            DateTime dataGozadaInicio;
            if (DateTime.TryParse(context.Request.QueryString["DataGozadaInicio"], out dataGozadaInicio))
            {
                dadosFerias.DataGozadaInicio = dataGozadaInicio;
            }

            DateTime dataGozadaFim;
            if (DateTime.TryParse(context.Request.QueryString["DataGozadaFim"], out dataGozadaFim))
            {
                dadosFerias.DataGozadaFim= dataGozadaFim;
            }

            int codigoStatus = 0;
            if (Int32.TryParse(context.Request.QueryString["CodigoStatus"], out codigoStatus))
            {
                dadosFerias.CodigoStatus = codigoStatus;
            }

            if (dadosFerias.CodigoFerias == 0)
            {
                int codigoUsuarioCadastro = 0;
                if (Int32.TryParse(context.Request.QueryString["CodigoUsuarioCadastro"], out codigoUsuarioCadastro))
                {
                    dadosFerias.CodigoUsuarioCadastro = Convert.ToInt32(context.Session["CodigoUsuario"].ToString());
                }

                return objBS.IncluirFerias(dadosFerias);
            }
            else
            {

                int codigoUsuarioAlteracao = 0;
                if (Int32.TryParse(context.Request.QueryString["CodigoUsuarioAlteracao"], out codigoUsuarioAlteracao))
                {
                    dadosFerias.CodigoUsuarioAlteracao = Convert.ToInt32(context.Session["CodigoUsuario"].ToString());
                }

                return objBS.AlterarFerias(dadosFerias);
            }

        }



        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}