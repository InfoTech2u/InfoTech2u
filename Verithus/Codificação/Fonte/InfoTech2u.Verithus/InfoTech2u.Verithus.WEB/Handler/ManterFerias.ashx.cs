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



        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}