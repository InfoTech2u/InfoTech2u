using InfoTech2u.Verithus.BS;
using InfoTech2u.Verithus.VO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace InfoTech2u.Verithus.WEB.Handler
{
    /// <summary>
    /// Summary description for ManterSecao
    /// </summary>
    public class ManterSecao : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            if (context.Request.QueryString["Metodo"] == "Lista")
            {
                var retorno = SelecionarSecaoLista(new TipoSecaoVO());

                JavaScriptSerializer serializer = new JavaScriptSerializer();

                context.Response.Write(serializer.Serialize(retorno));
            }
            else if (context.Request.QueryString["Metodo"] == "Incluir")
            {
                TipoSecaoVO param = new TipoSecaoVO();
                param.Descricao = context.Request.QueryString["Descricao"].ToString();

                JavaScriptSerializer serializer = new JavaScriptSerializer();

                context.Response.Write(serializer.Serialize(IncluirTipoSecao(param)));

            }
            else if (context.Request.QueryString["Metodo"] == "Excluir")
            {
                TipoSecaoVO param = new TipoSecaoVO();
                int numconvertido = 0;

                JavaScriptSerializer serializer = new JavaScriptSerializer();

                if (Int32.TryParse(context.Request.QueryString["Id"].ToString(), out numconvertido))
                {
                    param.CodigoTipoSecao = numconvertido;

                    context.Response.Write(serializer.Serialize(ExcluirTipoSecao(param)));
                }
                else
                {
                    context.Response.Write(serializer.Serialize(false));
                }
            }
        }

        private List<TipoSecaoVO> SelecionarSecaoLista(TipoSecaoVO param)
        {
            TipoSecaoBS objBS = new TipoSecaoBS();
            return objBS.SelecionarSecaoLista(param);
        }

        private bool IncluirTipoSecao(TipoSecaoVO param)
        {
            TipoSecaoBS objBS = new TipoSecaoBS();
            return objBS.IncluirTipoSecao(param);
        }

        private bool ExcluirTipoSecao(TipoSecaoVO param)
        {
            TipoSecaoBS objBS = new TipoSecaoBS();
            return objBS.ExcluirTipoSecao(param);
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