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
    /// Summary description for ManterSecao
    /// </summary>
    public class ManterSecao : IHttpHandler, System.Web.SessionState.IRequiresSessionState
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

                param.CodigoUsuarioCadastro = Convert.ToInt32(context.Session["CodigoUsuario"].ToString());

                context.Response.Write(IncluirTipoSecao(param).DataTableSerializer());

            }
            else if (context.Request.QueryString["Metodo"] == "Excluir")
            {
                TipoSecaoVO param = new TipoSecaoVO();
                int numconvertido = 0;

                JavaScriptSerializer serializer = new JavaScriptSerializer();

                if (Int32.TryParse(context.Request.QueryString["Id"].ToString(), out numconvertido))
                {
                    param.CodigoTipoSecao = numconvertido;

                    param.CodigoUsuarioAlteracao = Convert.ToInt32(context.Session["CodigoUsuario"].ToString());

                    context.Response.Write(ExcluirTipoSecao(param).DataTableSerializer());
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

        private DataTable IncluirTipoSecao(TipoSecaoVO param)
        {
            TipoSecaoBS objBS = new TipoSecaoBS();
            return objBS.IncluirTipoSecao(param);
        }

        private DataTable ExcluirTipoSecao(TipoSecaoVO param)
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