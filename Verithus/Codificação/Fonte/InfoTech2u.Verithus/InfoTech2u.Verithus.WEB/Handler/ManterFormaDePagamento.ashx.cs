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
    /// Summary description for ManterFormaDePagamento
    /// </summary>
    public class ManterFormaDePagamento : IHttpHandler, System.Web.SessionState.IRequiresSessionState
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
                var retorno = SelecionarFormaPagamentoLista(new TipoFormaPagamentoVO());

                JavaScriptSerializer serializer = new JavaScriptSerializer();

                context.Response.Write(serializer.Serialize(retorno));
            }
            else if (context.Request.QueryString["Metodo"] == "Incluir")
            {
                TipoFormaPagamentoVO param = new TipoFormaPagamentoVO();
                param.Descricao = context.Request.QueryString["Descricao"].ToString();

                param.CodigoUsuarioCadastro = Convert.ToInt32(context.Session["CodigoUsuario"].ToString());

                context.Response.Write(IncluirTipoFormaPagamento(param).DataTableSerializer());

            }
            else if (context.Request.QueryString["Metodo"] == "Excluir")
            {
                TipoFormaPagamentoVO param = new TipoFormaPagamentoVO();
                int numconvertido = 0;

                if (Int32.TryParse(context.Request.QueryString["Id"].ToString(), out numconvertido))
                {
                    param.CodigoTipoFormaPagamento = numconvertido;

                    param.CodigoUsuarioAlteracao = Convert.ToInt32(context.Session["CodigoUsuario"].ToString());
                }

                context.Response.Write(ExcluirTipoFormaPagamento(param).Serializer());
            }
        }

        private List<TipoFormaPagamentoVO> SelecionarFormaPagamentoLista(TipoFormaPagamentoVO param)
        {
            TipoFormaPagamentoBS objBS = new TipoFormaPagamentoBS();
            return objBS.SelecionarFormaPagamentoLista(param);
        }

        private DataTable IncluirTipoFormaPagamento(TipoFormaPagamentoVO param)
        {
            TipoFormaPagamentoBS objBS = new TipoFormaPagamentoBS();
            return objBS.IncluirTipoFormaPagamento(param);
        }

        private DataTable ExcluirTipoFormaPagamento(TipoFormaPagamentoVO param)
        {
            TipoFormaPagamentoBS objBS = new TipoFormaPagamentoBS();

            return objBS.ExcluirTipoFormaPagamento(param);
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