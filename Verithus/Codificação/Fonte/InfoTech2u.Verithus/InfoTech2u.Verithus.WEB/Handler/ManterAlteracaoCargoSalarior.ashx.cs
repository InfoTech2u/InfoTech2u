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

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}