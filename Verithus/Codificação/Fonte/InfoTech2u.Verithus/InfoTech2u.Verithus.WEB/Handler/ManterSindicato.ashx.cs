using InfoTech2u.Verithus.BS;
using InfoTech2u.Verithus.VO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using System.Web.Script.Serialization;
using InfoTech2u.Verithus.Util;

namespace InfoTech2u.Verithus.WEB.Handler
{
    /// <summary>
    /// Summary description for ManterTipoBeneficio
    /// </summary>
    public class ManterSindicato : IHttpHandler, System.Web.SessionState.IRequiresSessionState
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

            if (context.Request.QueryString["Metodo"] == "Lista")
            {
                var retorno = SelecionarSindicato(new SindicatoVO());

                context.Response.Write(retorno.Serializer());
            }
            else if (context.Request.QueryString["Metodo"] == "Incluir")
            {
                SindicatoVO param = new SindicatoVO();
                param.Nome = context.Request.QueryString["Nome"].ToString();

                param.CodigoUsuarioCadastro = Convert.ToInt32(context.Session["CodigoUsuario"].ToString());

                context.Response.Write(IncluirSindicato(param).Serializer());
            }
            else if (context.Request.QueryString["Metodo"] == "Excluir")
            {
                SindicatoVO param = new SindicatoVO();
                int numconvertido = 0;

                if (Int32.TryParse(context.Request.QueryString["Id"].ToString(), out numconvertido))
                {
                    param.CodigoSindicato = numconvertido;

                    param.CodigoUsuarioAlteracao = Convert.ToInt32(context.Session["CodigoUsuario"].ToString());
                }

                context.Response.Write(ExcluirSindicato(param).Serializer());
            }
        }

        private List<SindicatoVO> SelecionarSindicato(SindicatoVO param)
        {
            SindicatoBS objBS = new SindicatoBS();
            return objBS.SelecionarSindicato(param);
        }

        private DataTable IncluirSindicato(SindicatoVO param)
        {
            SindicatoBS objBS = new SindicatoBS();
            return objBS.IncluirSindicato(param);
        }

        private DataTable ExcluirSindicato(SindicatoVO param)
        {
            SindicatoBS objBS = new SindicatoBS();
            return objBS.ExcluirSindicato(param);
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