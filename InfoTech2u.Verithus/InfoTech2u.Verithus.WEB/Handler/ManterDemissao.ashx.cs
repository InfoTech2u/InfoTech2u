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
    /// Summary description for ManterDemissao
    /// </summary>
    public class ManterDemissao : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            if (context.Request.QueryString["Metodo"] == "Lista")
            {
                /*
                var retorno = SelecionarCargoLista(new TipoCargoVO());

                JavaScriptSerializer serializer = new JavaScriptSerializer();

                context.Response.Write(serializer.Serialize(retorno));
                */
            }
            else if (context.Request.QueryString["Metodo"] == "Incluir")
            {
                DadosDemissaoVO param = new DadosDemissaoVO();

                param.DataDemissao = Convert.ToDateTime(context.Request.QueryString["DataDemissao"].ToString());
                param.DataRegistro = Convert.ToDateTime(context.Request.QueryString["DataRegistro"].ToString());
                param.CodigoTipoCargo = Convert.ToInt32(context.Request.QueryString["Cargo"].ToString());
                param.CodigoTipoSecao = Convert.ToInt32(context.Request.QueryString["Secao"].ToString());
                param.SalarioInicial = Convert.ToDecimal(context.Request.QueryString["SalarioInicial"].ToString());
                param.Comissao = context.Request.QueryString["Comissao"].ToString();
                param.CodigoTipoTarefa = Convert.ToInt32(context.Request.QueryString["Tarefa"].ToString());
                param.CodigoTipoFormaPagamento = Convert.ToInt32(context.Request.QueryString["FormaPagamento"].ToString());

                JavaScriptSerializer serializer = new JavaScriptSerializer();

                context.Response.Write(serializer.Serialize(IncluirDemissao(param)));

            }
            else if (context.Request.QueryString["Metodo"] == "Excluir")
            {
                /*
                TipoCargoVO param = new TipoCargoVO();
                int numconvertido = 0;

                JavaScriptSerializer serializer = new JavaScriptSerializer();

                if (Int32.TryParse(context.Request.QueryString["Id"].ToString(), out numconvertido))
                {
                    param.CodigoTipoCargo = numconvertido;

                    context.Response.Write(serializer.Serialize(ExcluirTipoCargo(param)));
                }
                else
                {
                    context.Response.Write(serializer.Serialize(false));
                }
                 */
            }
        }
        /*
        private List<TipoCargoVO> SelecionarCargoLista(TipoCargoVO param)
        {
            TipoCargoBS objBS = new TipoCargoBS();
            return objBS.SelecionarCargoLista(param);
        }
        */
        private bool IncluirDemissao(DadosDemissaoVO param)
        {
            DadosDemissaoBS objBS = new DadosDemissaoBS();
            return objBS.IncluirDemissao(param);
        }
        /*
        private bool ExcluirTipoCargo(TipoCargoVO param)
        {
            TipoCargoBS objBS = new TipoCargoBS();
            return objBS.ExcluirTipoCargo(param);
        }
        */
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}