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
    /// Summary description for ManterSistema
    /// </summary>
    public class ManterSistema : IHttpHandler, System.Web.SessionState.IRequiresSessionState
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
                var retorno = SelecionarSistema(new SistemaVO());

                context.Response.Write(retorno.Serializer());
            }
            else if (context.Request.QueryString["Metodo"] == "Incluir")
            {
                SistemaVO param = new SistemaVO();
                param.Descricao = context.Request.QueryString["Descricao"].ToString();

                param.CodigoUsuarioCadastro = Convert.ToInt32(context.Session["CodigoUsuario"].ToString());
                param.CodigoUsuarioAlteracao = Convert.ToInt32(context.Session["CodigoUsuario"].ToString());
                param.DataCadastro = DateTime.Now;
                param.DataAlteracao = DateTime.Now;

                context.Response.Write(IncluirSistema(param).Serializer());
            }
            else if (context.Request.QueryString["Metodo"] == "Excluir")
            {
                SistemaVO param = new SistemaVO();
                int numconvertido = 0;

                if (Int32.TryParse(context.Request.QueryString["Id"].ToString(), out numconvertido))
                {
                    param.CodigoSistema = numconvertido;

                    param.CodigoUsuarioAlteracao = Convert.ToInt32(context.Session["CodigoUsuario"].ToString());
                    param.DataAlteracao = DateTime.Now;
                }

                context.Response.Write(ExcluirSistema(param).Serializer());
            }
        }

        private List<SistemaVO> SelecionarSistema(SistemaVO param)
        {
            SistemaBS objBS = new SistemaBS();
            return objBS.SelecionarSistema(param);
        }

        private DataTable IncluirSistema(SistemaVO param)
        {
            SistemaBS objBS = new SistemaBS();
            return objBS.IncluirSistema(param);
        }

        private DataTable ExcluirSistema(SistemaVO param)
        {
            SistemaBS objBS = new SistemaBS();
            return objBS.ExcluirSistema(param);
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