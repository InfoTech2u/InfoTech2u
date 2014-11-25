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
    /// Summary description for ManterAcidenteTrabalho
    /// </summary>
    public class ManterAcidenteTrabalho : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            if (context.Session["CodigoUsuario"] == null)
            {
                context.Response.ContentType = "application/json; charset=utf-8";
                context.Response.Write("{ \"Msg\": \"Sessão expirada. Você será redirecionado para tela de login.\"}");
                context.Response.End();
                return;
            }

            if (context.Request.QueryString["Metodo"] == "Selecionar")
            {
                var retorno = SelecionarAcidenteTrabalho(context);

                context.Response.Write(retorno.Serializer());
            }
            else if (context.Request.QueryString["Metodo"] == "Gravar")
            {
                context.Response.Write(GravarAcidenteTrabalho(context).Serializer());
            }
            else if (context.Request.QueryString["Metodo"] == "Excluir")
            {
                context.Response.Write(ExcluirAcidenteTrabalho(context).Serializer());
            }

        }

        private DataTable ExcluirAcidenteTrabalho(HttpContext context)
        {
            AcidenteTrabalhoBS objBS = new AcidenteTrabalhoBS();
            AcidenteTrabalhoVO dadosAcidenteTrabalho = new AcidenteTrabalhoVO();

            int codigoFuncionario = 0;
            if (Int32.TryParse(context.Request.QueryString["CodigoFuncionario"], out codigoFuncionario))
            {
                dadosAcidenteTrabalho.CodigoFuncionario = codigoFuncionario;
            }

            int codigoUsuarioAlteracao = 0;
            if (Int32.TryParse(context.Request.QueryString["CodigoUsuarioAlteracao"], out codigoUsuarioAlteracao))
            {
                dadosAcidenteTrabalho.CodigoUsuarioAlteracao = Convert.ToInt32(context.Session["CodigoUsuario"].ToString());
            }

            int codigoAcidenteTrabalho = 0;
            if (Int32.TryParse(context.Request.QueryString["CodigoAcidenteTrabalho"], out codigoAcidenteTrabalho))
            {
                dadosAcidenteTrabalho.CodigoAcidenteTrabalho = codigoAcidenteTrabalho;
            }
            else
            {
                dadosAcidenteTrabalho.CodigoAcidenteTrabalho = null;
            }

            return objBS.ExcluirAcidenteTrabalho(dadosAcidenteTrabalho);
        }

        private DataTable SelecionarAcidenteTrabalho(HttpContext context)
        {
            AcidenteTrabalhoBS objBS = new AcidenteTrabalhoBS();
            AcidenteTrabalhoVO dadosAcidenteTrabalho = new AcidenteTrabalhoVO();

            int codigoFuncionario = 0;
            if (Int32.TryParse(context.Request.QueryString["CodigoFuncionario"], out codigoFuncionario))
            {
                dadosAcidenteTrabalho.CodigoFuncionario = codigoFuncionario;
            }

            return objBS.SelecionarAcidenteTrabalho(dadosAcidenteTrabalho);
        }

        private DataTable GravarAcidenteTrabalho(HttpContext context)
        {
            AcidenteTrabalhoBS objBS = new AcidenteTrabalhoBS();
            AcidenteTrabalhoVO dadosAcidenteTrabalho = new AcidenteTrabalhoVO();

            int codigoAcidenteTrabalho = 0;
            if (Int32.TryParse(context.Request.QueryString["CodigoAcidenteTrabalho"], out codigoAcidenteTrabalho))
            {
                dadosAcidenteTrabalho.CodigoAcidenteTrabalho = codigoAcidenteTrabalho;
            }

            int codigoFuncionario = 0;
            if (Int32.TryParse(context.Request.QueryString["CodigoFuncionario"], out codigoFuncionario))
            {
                dadosAcidenteTrabalho.CodigoFuncionario = codigoFuncionario;
            }

            DateTime data;
            if (DateTime.TryParse(context.Request.QueryString["Data"], out data))
            {
                dadosAcidenteTrabalho.Data = data;
            }

            dadosAcidenteTrabalho.Local = context.Request.QueryString["Local"].ToString();
            dadosAcidenteTrabalho.Causa = context.Request.QueryString["Causa"].ToString();

            DateTime dataAlta;
            if (DateTime.TryParse(context.Request.QueryString["DataAlta"], out dataAlta))
            {
                dadosAcidenteTrabalho.DataAlta = dataAlta;
            }

            dadosAcidenteTrabalho.Resultado = context.Request.QueryString["Resultado"].ToString();
            dadosAcidenteTrabalho.Observacoes = context.Request.QueryString["Observacoes"].ToString();

            int codigoStatus = 0;
            if (Int32.TryParse(context.Request.QueryString["CodigoStatus"], out codigoStatus))
            {
                dadosAcidenteTrabalho.CodigoStatus = codigoStatus;
            }

            if (dadosAcidenteTrabalho.CodigoAcidenteTrabalho == 0 || dadosAcidenteTrabalho.CodigoAcidenteTrabalho == null)
            {
                int codigoUsuarioCadastro = 0;
                if (Int32.TryParse(context.Request.QueryString["CodigoUsuarioCadastro"], out codigoUsuarioCadastro))
                {
                    dadosAcidenteTrabalho.CodigoUsuarioCadastro = Convert.ToInt32(context.Session["CodigoUsuario"].ToString());
                }

                return objBS.IncluirAcidenteTrabalho(dadosAcidenteTrabalho);
            }
            else
            {

                int codigoUsuarioAlteracao = 0;
                if (Int32.TryParse(context.Request.QueryString["CodigoUsuarioAlteracao"], out codigoUsuarioAlteracao))
                {
                    dadosAcidenteTrabalho.CodigoUsuarioAlteracao = Convert.ToInt32(context.Session["CodigoUsuario"].ToString());
                }

                return objBS.AlterarAcidenteTrabalho(dadosAcidenteTrabalho);
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