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
    /// Summary description for ManterAlteracaoCargoSalarior
    /// </summary>
    public class ManterAlteracaoCargoSalarior : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            if (context.Request.QueryString["Metodo"] == "Selecionar")
            {
                var retorno = SelecionarAlteracaoCargoSalarior(context);

                context.Response.Write(retorno.Serializer());
            }
            else if (context.Request.QueryString["Metodo"] == "Gravar")
            {
                context.Response.Write(GravarAlteracaoCargoSalarior(context).Serializer());
            }
        }

        private DataTable SelecionarAlteracaoCargoSalarior(HttpContext context)
        {
            AlteracaoCargoSalariorBS objBS = new AlteracaoCargoSalariorBS();
            AlteracaoCargoSalariorVO dadosAlteracaoCargoSalarior = new AlteracaoCargoSalariorVO();

            int codigoFuncionario = 0;
            if (Int32.TryParse(context.Request.QueryString["CodigoFuncionario"], out codigoFuncionario))
            {
                dadosAlteracaoCargoSalarior.CodigoFuncionario = codigoFuncionario;
            }

            return objBS.SelecionarAlteracaoCargoSalarior(dadosAlteracaoCargoSalarior);
        }

        private DataTable GravarAlteracaoCargoSalarior(HttpContext context)
        {
            AlteracaoCargoSalariorBS objBS = new AlteracaoCargoSalariorBS();
            AlteracaoCargoSalariorVO dadosAlteracaoCargoSalarior = new AlteracaoCargoSalariorVO();

            int codigoAlteracaoCargoSalario = 0;
            if (Int32.TryParse(context.Request.QueryString["CodigoAlteracaoCargoSalario"], out codigoAlteracaoCargoSalario))
            {
                dadosAlteracaoCargoSalarior.CodigoAlteracaoCargoSalario = codigoAlteracaoCargoSalario;
            }

            int codigoFuncionario = 0;
            if (Int32.TryParse(context.Request.QueryString["CodigoFuncionario"], out codigoFuncionario))
            {
                dadosAlteracaoCargoSalarior.CodigoFuncionario = codigoFuncionario;
            }

            DateTime data;
            if (DateTime.TryParse(context.Request.QueryString["Data"], out data))
            {
                dadosAlteracaoCargoSalarior.Data = data;
            }

            int codigoTipoCargo = 0;
            if (Int32.TryParse(context.Request.QueryString["CodigoTipoCargo"], out codigoTipoCargo))
            {
                dadosAlteracaoCargoSalarior.CodigoTipoCargo = codigoTipoCargo;
            }

            dadosAlteracaoCargoSalarior.Salario = context.Request.QueryString["Salario"].ToString();
            dadosAlteracaoCargoSalarior.HorarioInicio = context.Request.QueryString["HorarioInicio"].ToString();
            dadosAlteracaoCargoSalarior.HorarioFim = context.Request.QueryString["HorarioFim"].ToString();

            int codigoStatus = 0;
            if (Int32.TryParse(context.Request.QueryString["CodigoStatus"], out codigoStatus))
            {
                dadosAlteracaoCargoSalarior.CodigoStatus = codigoStatus;
            }

            if (dadosAlteracaoCargoSalarior.CodigoAlteracaoCargoSalario == 0)
            {
                int codigoUsuarioCadastro = 0;
                if (Int32.TryParse(context.Request.QueryString["CodigoUsuarioCadastro"], out codigoUsuarioCadastro))
                {
                    dadosAlteracaoCargoSalarior.CodigoUsuarioCadastro = Convert.ToInt32(context.Session["CodigoUsuario"].ToString());
                }

                return objBS.IncluirAlteracaoCargoSalarior(dadosAlteracaoCargoSalarior);
            }
            else
            {

                int codigoUsuarioAlteracao = 0;
                if (Int32.TryParse(context.Request.QueryString["CodigoUsuarioAlteracao"], out codigoUsuarioAlteracao))
                {
                    dadosAlteracaoCargoSalarior.CodigoUsuarioAlteracao = Convert.ToInt32(context.Session["CodigoUsuario"].ToString());
                }

                return objBS.AlterarAlteracaoCargoSalarior(dadosAlteracaoCargoSalarior);
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