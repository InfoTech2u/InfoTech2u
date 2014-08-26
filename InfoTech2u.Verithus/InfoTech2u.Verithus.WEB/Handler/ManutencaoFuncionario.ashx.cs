using System;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.UI;
using InfoTech2u.Verithus.VO;
using InfoTech2u.Verithus.BS;
using System.Web.Script.Serialization;
using System.Collections.Generic;

namespace InfoTech2u.Verithus.WEB.Handler
{
    /// <summary>
    /// Summary description for ManutencaoFuncionario
    /// </summary>
    public class ManutencaoFuncionario : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string retorno = "";

            string Metodo = context.Request.QueryString["Metodo"].ToString();
            string Acao = context.Request.QueryString["Acao"].ToString();
            string UsuarioAcao = context.Request.QueryString["UsuarioAcao"].ToString();

            //Dados Pessoais
            string NumeroOrdemMatricula = context.Request.QueryString["txtNumeroOrdemMatricula"].ToString();
            string NumeroMatricula = context.Request.QueryString["txtNumeroMatricula"].ToString();
            string NomePai = context.Request.QueryString["txtNomePai"].ToString();
            string NacionalidadePai = context.Request.QueryString["ddlNacionalidadePai"].ToString();
            string NomeMae = context.Request.QueryString["txtNomMae"].ToString();
            string NacionalidadeMae = context.Request.QueryString["ddlNacionalidadeMae"].ToString();
            string DataNascimento = context.Request.QueryString["txtDataNascimento"].ToString();
            string NacionalidadeFuncionario = context.Request.QueryString["ddlNacionalidadeFuncionario"].ToString();
            string EstadoCivil = context.Request.QueryString["ddlEstadoCivil"].ToString();
            string NomeConjuge = context.Request.QueryString["txtNomeConjuge"].ToString();
            string QtdFilhos = context.Request.QueryString["txtQtdFilhos"].ToString();
            string TipoEndereco = context.Request.QueryString["ddlTipoEndereco"].ToString();
            string TipoLogradouro = context.Request.QueryString["ddlTipoLogradouro"].ToString();
            string Logradouro = context.Request.QueryString["txtLogradouro"].ToString();
            string NumeroEndereco = context.Request.QueryString["txtNumeroEndereco"].ToString();
            string Bairro = context.Request.QueryString["txtBairro"].ToString();
            string Complemento = context.Request.QueryString["txtComplemento"].ToString();
            string CEP = context.Request.QueryString["txtCEP"].ToString();

            //Monta Objeto Dados Pessoais de Funcionario
            FuncionariosVO EntradaDadosPessoais = new FuncionariosVO();
            if (!String.IsNullOrWhiteSpace(context.Request.QueryString["txtNumeroOrdemMatricula"].ToString()))
                EntradaDadosPessoais.NumeroOrdemMatricula = Convert.ToInt32(context.Request.QueryString["txtNumeroOrdemMatricula"].ToString());

            if (!String.IsNullOrWhiteSpace(context.Request.QueryString["txtNumeroMatricula"].ToString()))
                EntradaDadosPessoais.NumeroMatricula = Convert.ToInt32(context.Request.QueryString["txtNumeroMatricula"].ToString());

            EntradaDadosPessoais.NomePai = context.Request.QueryString["txtNomePai"].ToString();
            EntradaDadosPessoais.NacionalidadePai = context.Request.QueryString["ddlNacionalidadePai"].ToString();
            EntradaDadosPessoais.NomeMae = context.Request.QueryString["txtNomMae"].ToString();
            EntradaDadosPessoais.NacionalidadeMae = context.Request.QueryString["ddlNacionalidadeMae"].ToString();
            EntradaDadosPessoais.DataNascimento = context.Request.QueryString["txtDataNascimento"].ToString();
            EntradaDadosPessoais.LocalNascimento = context.Request.QueryString["ddlNacionalidadeFuncionario"].ToString();
            //EntradaDadosPessoais.EstadoCivil = context.Request.QueryString["ddlEstadoCivil"].ToString();
            EntradaDadosPessoais.NomeConjuge = context.Request.QueryString["txtNomeConjuge"].ToString();

            if (!String.IsNullOrWhiteSpace(context.Request.QueryString["txtNumeroMatricula"].ToString()))
                EntradaDadosPessoais.QuantosFilhos = Convert.ToInt16(context.Request.QueryString["txtQtdFilhos"].ToString());
            
            //EntradaDadosPessoais.TipoEndereco = context.Request.QueryString["ddlTipoEndereco"].ToString();
            //EntradaDadosPessoais.TipoLogradouro = context.Request.QueryString["ddlTipoLogradouro"].ToString();
            //EntradaDadosPessoais.Logradouro = context.Request.QueryString["txtLogradouro"].ToString();
            //EntradaDadosPessoais.NumeroEndereco = context.Request.QueryString["txtNumeroEndereco"].ToString();
            //EntradaDadosPessoais.Bairro = context.Request.QueryString["txtBairro"].ToString();
            //EntradaDadosPessoais.Complemento = context.Request.QueryString["txtComplemento"].ToString();
            //EntradaDadosPessoais.CEP = context.Request.QueryString["txtCEP"].ToString();

            context.Response.Write(retorno);
        }

        
        protected List<FuncionariosVO> IncluirFuncionario(FuncionariosVO param)
        {
            List<FuncionariosVO> retorno = new List<FuncionariosVO>();

            return retorno;
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