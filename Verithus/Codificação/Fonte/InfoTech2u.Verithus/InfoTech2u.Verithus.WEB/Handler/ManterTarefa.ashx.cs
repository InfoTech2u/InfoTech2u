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
    /// Summary description for ManterTarefa
    /// </summary>
    public class ManterTarefa : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            if (context.Request.QueryString["Metodo"] == "Lista")
            {
                var retorno = SelecionarTarefaLista(new TipoTarefaVO());

                JavaScriptSerializer serializer = new JavaScriptSerializer();

                context.Response.Write(serializer.Serialize(retorno));
            }
            else if (context.Request.QueryString["Metodo"] == "Incluir")
            {
                TipoTarefaVO param = new TipoTarefaVO();
                param.Descricao = context.Request.QueryString["Descricao"].ToString();

                param.CodigoUsuarioCadastro = Convert.ToInt32(context.Session["CodigoUsuario"].ToString());

                context.Response.Write(IncluirTipoTarefa(param).DataTableSerializer());

            }
            else if (context.Request.QueryString["Metodo"] == "Excluir")
            {
                TipoTarefaVO param = new TipoTarefaVO();
                int numconvertido = 0;

                JavaScriptSerializer serializer = new JavaScriptSerializer();

                if (Int32.TryParse(context.Request.QueryString["Id"].ToString(), out numconvertido))
                {
                    param.CodigoTipoTarefa = numconvertido;

                    param.CodigoUsuarioAlteracao = Convert.ToInt32(context.Session["CodigoUsuario"].ToString());

                    context.Response.Write(ExcluirTipoTarefa(param).DataTableSerializer());
                }
                else
                {
                    context.Response.Write(serializer.Serialize(false));
                }
            }
        }

        private List<TipoTarefaVO> SelecionarTarefaLista(TipoTarefaVO param)
        {
            TipoTarefaBS objBS = new TipoTarefaBS();
            return objBS.SelecionarTarefaLista(param);
        }

        private DataTable IncluirTipoTarefa(TipoTarefaVO param)
        {
            TipoTarefaBS objBS = new TipoTarefaBS();
            return objBS.IncluirTipoTarefa(param);
        }

        private DataTable ExcluirTipoTarefa(TipoTarefaVO param)
        {
            TipoTarefaBS objBS = new TipoTarefaBS();
            return objBS.ExcluirTipoTarefa(param);
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