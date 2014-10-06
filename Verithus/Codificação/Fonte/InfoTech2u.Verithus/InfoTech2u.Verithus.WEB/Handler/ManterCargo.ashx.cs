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
    /// Summary description for ManterCargo
    /// </summary>
    public class ManterCargo : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            if (context.Request.QueryString["Metodo"] == "Lista")
            {
                var retorno = SelecionarCargoLista(new TipoCargoVO());

                JavaScriptSerializer serializer = new JavaScriptSerializer();

                context.Response.Write(serializer.Serialize(retorno));
            }
            else if (context.Request.QueryString["Metodo"] == "Incluir")
            {
                TipoCargoVO param = new TipoCargoVO();
                param.Descricao = context.Request.QueryString["Descricao"].ToString();

                param.CodigoUsuarioCadastro = Convert.ToInt32(context.Session["CodigoUsuario"].ToString());

                context.Response.Write(IncluirTipoCargo(param).DataTableSerializer());

            }
            else if (context.Request.QueryString["Metodo"] == "Excluir")
            {
                TipoCargoVO param = new TipoCargoVO();
                int numconvertido = 0;

                JavaScriptSerializer serializer = new JavaScriptSerializer();

                if (Int32.TryParse(context.Request.QueryString["Id"].ToString(), out numconvertido))
                {
                    param.CodigoTipoCargo = numconvertido;

                    param.CodigoUsuarioAlteracao = Convert.ToInt32(context.Session["CodigoUsuario"].ToString());

                    context.Response.Write(ExcluirTipoCargo(param).DataTableSerializer());
                }
                else
                {
                    context.Response.Write(serializer.Serialize(false));
                }
            }
        }

        private List<TipoCargoVO> SelecionarCargoLista(TipoCargoVO param)
        {
            TipoCargoBS objBS = new TipoCargoBS();
            return objBS.SelecionarCargoLista(param);
        }

        private DataTable IncluirTipoCargo(TipoCargoVO param)
        {
            TipoCargoBS objBS = new TipoCargoBS();
            return objBS.IncluirTipoCargo(param);
        }

        private DataTable ExcluirTipoCargo(TipoCargoVO param)
        {
            TipoCargoBS objBS = new TipoCargoBS();
            return objBS.ExcluirTipoCargo(param);
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