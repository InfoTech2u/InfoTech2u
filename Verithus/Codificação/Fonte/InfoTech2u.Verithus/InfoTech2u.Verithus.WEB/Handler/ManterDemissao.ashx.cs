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
    /// Summary description for ManterDemissao
    /// </summary>
    public class ManterDemissao : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            if (context.Request.QueryString["Metodo"] == "Selecionar")
            {
                var retorno = SelecionarAdmissao(context);

                context.Response.Write(retorno.Serializer());
            }
            else if (context.Request.QueryString["Metodo"] == "Gravar")
            {
                context.Response.Write(GravarAdmissao(context).Serializer());
            }
        }
        
        private DataTable SelecionarAdmissao(HttpContext context)
        {
            DadosDemissaoBS objBS = new DadosDemissaoBS();
            DadosDemissaoVO dadosDemissao = new DadosDemissaoVO();

            int codigoFuncionario = 0;
            if (Int32.TryParse(context.Request.QueryString["CodigoFuncionario"], out codigoFuncionario))
            {
                dadosDemissao.CodigoFuncionario = codigoFuncionario;
            }

            return objBS.Selecionar(dadosDemissao);
        }

        private DataTable GravarAdmissao(HttpContext context)
        {
            DadosDemissaoBS objBS = new DadosDemissaoBS();
            DadosDemissaoVO dadosDemissao = new DadosDemissaoVO();

            int codigoDemissao = 0;
            if (Int32.TryParse(context.Request.QueryString["CodigoDEMISSAO"], out codigoDemissao))
            {
                dadosDemissao.CodigoDEMISSAO = codigoDemissao;
            }

            int codigoFuncionario = 0;
            if (Int32.TryParse(context.Request.QueryString["CodigoFuncionario"], out codigoFuncionario))
            {
                dadosDemissao.CodigoFuncionario = codigoFuncionario;
            }

            DateTime dataDemissao;
            if (DateTime.TryParse(context.Request.QueryString["DataDemissao"], out dataDemissao))
            {
                dadosDemissao.DataDemissao = dataDemissao;
            }

            DateTime dataRegistro;
            if (DateTime.TryParse(context.Request.QueryString["DataRegistro"], out dataRegistro))
            {
                dadosDemissao.DataRegistro = dataRegistro;
            }

            int codigoTipoCargo = 0;
            if (Int32.TryParse(context.Request.QueryString["CodigoTipoCargo"], out codigoTipoCargo))
            {
                dadosDemissao.CodigoTipoCargo = codigoTipoCargo;
            }

            int codigoTipoSecao = 0;
            if (Int32.TryParse(context.Request.QueryString["CodigoTipoSecao"], out codigoTipoSecao))
            {
                dadosDemissao.CodigoTipoSecao = codigoTipoSecao;
            }

            dadosDemissao.SalarioInicial = context.Request.QueryString["SalarioInicial"].ToString();

            dadosDemissao.Comissao = context.Request.QueryString["Comissao"].ToString();

            int codigoTipoTarefa = 0;
            if (Int32.TryParse(context.Request.QueryString["CodigoTipoTarefa"], out codigoTipoTarefa))
            {
                dadosDemissao.CodigoTipoTarefa = codigoTipoTarefa;
            }

            int codigoTipoFormaPagamento = 0;
            if (Int32.TryParse(context.Request.QueryString["CodigoTipoFormaPagamento"], out codigoTipoFormaPagamento))
            {
                dadosDemissao.CodigoTipoFormaPagamento = codigoTipoFormaPagamento;
            }

            

            int codigoStatus = 0;
            if (Int32.TryParse(context.Request.QueryString["CodigoStatus"], out codigoStatus))
            {
                dadosDemissao.CodigoStatus = codigoStatus;
            }

            if (dadosDemissao.CodigoDEMISSAO == 0)
            {
                int codigoUsuarioCadastro = 0;
                if (Int32.TryParse(context.Request.QueryString["CodigoUsuarioCadastro"], out codigoUsuarioCadastro))
                {
                    dadosDemissao.CodigoUsuarioCadastro = Convert.ToInt32(context.Session["CodigoUsuario"].ToString());
                }

                return objBS.IncluirDemissao(dadosDemissao);
            }
            else
            {

                int codigoUsuarioAlteracao = 0;
                if (Int32.TryParse(context.Request.QueryString["CodigoUsuarioAlteracao"], out codigoUsuarioAlteracao))
                {
                    dadosDemissao.CodigoUsuarioAlteracao = Convert.ToInt32(context.Session["CodigoUsuario"].ToString());
                }

                return objBS.AlterarDemissao(dadosDemissao);
            }

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