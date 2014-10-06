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
    /// Summary description for ManterAdmissao
    /// </summary>
    public class ManterAdmissao : IHttpHandler, System.Web.SessionState.IRequiresSessionState
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
            DadosAdmissaoBS objBS = new DadosAdmissaoBS();
            DadosAdmissaoVO dadosAdmissao = new DadosAdmissaoVO();

            int codigoFuncionario = 0;
            if (Int32.TryParse(context.Request.QueryString["CodigoFuncionario"], out codigoFuncionario))
            {
                dadosAdmissao.CodigoFuncionario = codigoFuncionario;
            }

            return objBS.SelecionarAdmissao(dadosAdmissao);
        }

        private DataTable GravarAdmissao(HttpContext context)
        {
            DadosAdmissaoBS objBS = new DadosAdmissaoBS();
            DadosAdmissaoVO dadosAdmissao = new DadosAdmissaoVO();

            int codigoAdmissao = 0;
            if (Int32.TryParse(context.Request.QueryString["CodigoAdmissao"], out codigoAdmissao))
            {
                dadosAdmissao.CodigoAdmissao = codigoAdmissao;
            }

            int codigoFuncionario = 0;
            if (Int32.TryParse(context.Request.QueryString["CodigoFuncionario"], out codigoFuncionario))
            {
                dadosAdmissao.CodigoFuncionario = codigoFuncionario;
            }

            DateTime dataAdmissao;
            if (DateTime.TryParse(context.Request.QueryString["DataAdmissao"], out dataAdmissao))
            {
                dadosAdmissao.DataAdmissao = dataAdmissao;
            }

            DateTime dataRegistro;
            if (DateTime.TryParse(context.Request.QueryString["DataRegistro"], out dataRegistro))
            {
                dadosAdmissao.DataRegistro = dataRegistro;
            }

            int codigoTipoCargo = 0;
            if (Int32.TryParse(context.Request.QueryString["CodigoTipoCargo"], out codigoTipoCargo))
            {
                dadosAdmissao.CodigoTipoCargo = codigoTipoCargo;
            }

            int codigoTipoSecao = 0;
            if (Int32.TryParse(context.Request.QueryString["CodigoTipoSecao"], out codigoTipoSecao))
            {
                dadosAdmissao.CodigoTipoSecao = codigoTipoSecao;
            }

            dadosAdmissao.SalarioInicial = context.Request.QueryString["SalarioInicial"].ToString();

            dadosAdmissao.Comissao = context.Request.QueryString["Comissao"].ToString();

            int codigoTipoTarefa = 0;
            if (Int32.TryParse(context.Request.QueryString["CodigoTipoTarefa"], out codigoTipoTarefa))
            {
                dadosAdmissao.CodigoTipoTarefa = codigoTipoTarefa;
            }

            int codigoTipoFormaPagamento = 0;
            if (Int32.TryParse(context.Request.QueryString["CodigoTipoFormaPagamento"], out codigoTipoFormaPagamento))
            {
                dadosAdmissao.CodigoTipoFormaPagamento = codigoTipoFormaPagamento;
            }

            dadosAdmissao.HorarioTrabalhoInicio = context.Request.QueryString["HorarioTrabalhoInicio"].ToString();
            dadosAdmissao.HorarioTrabalhoFim = context.Request.QueryString["HorarioTrabalhoFim"].ToString();
            dadosAdmissao.IntervaloAlmocoInicio = context.Request.QueryString["IntervaloAlmocoInicio"].ToString();
            dadosAdmissao.IntervaloAlmocoFim = context.Request.QueryString["IntervaloAlmocoFim"].ToString();
            dadosAdmissao.DescansoSemanalInicio = context.Request.QueryString["DescansoSemanalInicio"].ToString();
            dadosAdmissao.DescansoSemanalFim = context.Request.QueryString["DescansoSemanalFim"].ToString();

            int codigoStatus = 0;
            if (Int32.TryParse(context.Request.QueryString["CodigoStatus"], out codigoStatus))
            {
                dadosAdmissao.CodigoStatus = codigoStatus;
            }

            if (dadosAdmissao.CodigoAdmissao == 0)
            {
                int codigoUsuarioCadastro = 0;
                if (Int32.TryParse(context.Request.QueryString["CodigoUsuarioCadastro"], out codigoUsuarioCadastro))
                {
                    dadosAdmissao.CodigoUsuarioCadastro = Convert.ToInt32(context.Session["CodigoUsuario"].ToString());
                }

                return objBS.IncluirAdmissao(dadosAdmissao);
            }
            else
            {

                int codigoUsuarioAlteracao = 0;
                if (Int32.TryParse(context.Request.QueryString["CodigoUsuarioAlteracao"], out codigoUsuarioAlteracao))
                {
                    dadosAdmissao.CodigoUsuarioAlteracao = Convert.ToInt32(context.Session["CodigoUsuario"].ToString());
                }

                return objBS.AlterarAdmissao(dadosAdmissao);
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