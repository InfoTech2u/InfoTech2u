using InfoTech2u.Verithus.BS;
using InfoTech2u.Verithus.VO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using InfoTech2u.Verithus.Util;

namespace InfoTech2u.Verithus.WEB.Handler
{
    /// <summary>
    /// Summary description for ManterStatus
    /// </summary>
    public class ManterStatus : IHttpHandler, System.Web.SessionState.IRequiresSessionState
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

            if (context.Request.QueryString["Metodo"] == "Listar")
            {
                var retorno = SelecionarListaStatus();

                context.Response.Write(retorno.Serializer());
            }
        }

        private List<StatusVO> SelecionarListaStatus()
        {
            StatusBS objBS = new StatusBS();
            
            return objBS.SelecionarStatus(new StatusVO());
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