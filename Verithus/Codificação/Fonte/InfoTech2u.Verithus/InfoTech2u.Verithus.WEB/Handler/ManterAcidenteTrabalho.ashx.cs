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
            if (context.Request.QueryString["Metodo"] == "Selecionar")
            {
                var retorno = SelecionarAcidenteTrabalho(context);

                context.Response.Write(retorno.Serializer());
            }
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

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}