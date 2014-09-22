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
    public class ManterSindicato : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            if (context.Request.QueryString["Metodo"] == "Lista")
            {
                var retorno = SelecionarSindicato(new SindicatoVO());

                context.Response.Write(retorno.Serializer());
            }
            else if (context.Request.QueryString["Metodo"] == "Incluir")
            {
                SindicatoVO param = new SindicatoVO();
                param.Nome = context.Request.QueryString["Nome"].ToString();

                context.Response.Write(IncluirSindicato(param).Serializer());
            }
            else if (context.Request.QueryString["Metodo"] == "Excluir")
            {
                SindicatoVO param = new SindicatoVO();
                int numconvertido = 0;

                JavaScriptSerializer serializer = new JavaScriptSerializer();

                if (Int32.TryParse(context.Request.QueryString["Id"].ToString(), out numconvertido))
                {
                    param.CodigoSindicato = numconvertido;

                    context.Response.Write(serializer.Serialize(ExcluirSindicato(param)));
                }
                else
                {
                    context.Response.Write(serializer.Serialize(false));
                }
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

        private bool ExcluirSindicato(SindicatoVO param)
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