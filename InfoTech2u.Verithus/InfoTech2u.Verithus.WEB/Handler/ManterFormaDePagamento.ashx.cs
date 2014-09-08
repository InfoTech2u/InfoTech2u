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
    /// Summary description for ManterFormaDePagamento
    /// </summary>
    public class ManterFormaDePagamento : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
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

                JavaScriptSerializer serializer = new JavaScriptSerializer();

                context.Response.Write(serializer.Serialize(IncluirTipoFormaPagamento(param)));

            }
            else if (context.Request.QueryString["Metodo"] == "Excluir")
            {
                TipoFormaPagamentoVO param = new TipoFormaPagamentoVO();
                int numconvertido = 0;

                JavaScriptSerializer serializer = new JavaScriptSerializer();

                if (Int32.TryParse(context.Request.QueryString["Id"].ToString(), out numconvertido))
                {
                    param.CodigoTipoFormaPagamento = numconvertido;

                    context.Response.Write(serializer.Serialize(ExcluirTipoFormaPagamento(param)));
                }
                else
                {
                    context.Response.Write(serializer.Serialize(false));
                }
            }
        }

        private List<TipoFormaPagamentoVO> SelecionarFormaPagamentoLista(TipoFormaPagamentoVO param)
        {
            TipoFormaPagamentoBS objBS = new TipoFormaPagamentoBS();
            return objBS.SelecionarFormaPagamentoLista(param);
        }

        private bool IncluirTipoFormaPagamento(TipoFormaPagamentoVO param)
        {
            TipoFormaPagamentoBS objBS = new TipoFormaPagamentoBS();
            return objBS.IncluirTipoFormaPagamento(param);
        }

        private bool ExcluirTipoFormaPagamento(TipoFormaPagamentoVO param)
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