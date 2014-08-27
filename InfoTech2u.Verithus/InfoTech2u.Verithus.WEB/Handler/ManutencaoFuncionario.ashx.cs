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
            string NumeroOrdemMatricula = context.Request.QueryString["NumeroOrdemMatricula"].ToString();
            string NumeroMatricula = context.Request.QueryString["NumeroMatricula"].ToString();
            string NomeFuncionario = context.Request.QueryString["NomeFuncionario"].ToString();
            string DataNascimento = context.Request.QueryString["DataNascimento"].ToString();
            string NacionalidadeFuncionario = context.Request.QueryString["NacionalidadeFuncionario"].ToString();
            string EstadoCivil = context.Request.QueryString["EstadoCivil"].ToString();
            string NomeConjuge = context.Request.QueryString["NomeConjuge"].ToString();
            string QtdFilhos = context.Request.QueryString["QtdFilhos"].ToString();
            string TipoEndereco = context.Request.QueryString["TipoEndereco"].ToString();
            string TipoLogradouro = context.Request.QueryString["TipoLogradouro"].ToString();
            string Logradouro = context.Request.QueryString["Logradouro"].ToString();
            string NumeroEndereco = context.Request.QueryString["NumeroEndereco"].ToString();
            string Bairro = context.Request.QueryString["Bairro"].ToString();
            string Complemento = context.Request.QueryString["Complemento"].ToString();
            string CEP = context.Request.QueryString["CEP"].ToString();
            string NomePai = context.Request.QueryString["NomePai"].ToString();
            string NacionalidadePai = context.Request.QueryString["NacionalidadePai"].ToString();
            string NomeMae = context.Request.QueryString["NomeMae"].ToString();
            string NacionalidadeMae = context.Request.QueryString["NacionalidadeMa"].ToString();
            string RG = context.Request.QueryString["RG"].ToString();
            string CarteiraTrabalho = context.Request.QueryString["CarteiraTrabalho"].ToString();
            string NumeroSerie = context.Request.QueryString["NumeroSerie"].ToString();
            string NumeroCertificadoReservista = context.Request.QueryString["NumeroCertificadoReservista"].ToString();
            string Categoria = context.Request.QueryString["Categoria"].ToString();
            string CPF = context.Request.QueryString["CPF"].ToString();
            string TituloEleitor = context.Request.QueryString["TituloEleitor"].ToString();
            string CateiraSaude = context.Request.QueryString["CateiraSaude"].ToString();
            string CBO = context.Request.QueryString["CBO"].ToString();
            string Carteira19 = context.Request.QueryString["Carteira19"].ToString();
            string RegistroGeral = context.Request.QueryString["RegistroGeral"].ToString();
            string CasadoBrasileiro = context.Request.QueryString["rdbCasadoBrasileiro"].ToString();
            string Naturalizado = context.Request.QueryString["Naturalizado"].ToString();
            string FilhoBrasileiro = context.Request.QueryString["FilhoBrasileirod"].ToString();
            string DataChegadaBrasil = context.Request.QueryString["DataChegadaBrasil"].ToString();
            string CadastroPIS = context.Request.QueryString["CadastroPIS"].ToString();
            string SobNumero = context.Request.QueryString["SobNumero"].ToString();
            string BancoPIS = context.Request.QueryString["BancoPIS"].ToString();
            string Agencia = context.Request.QueryString["Agencia"].ToString();
            string Digito = context.Request.QueryString["Digito"].ToString();
            string TipoEnderecoPIS = context.Request.QueryString["TipoEnderecoPIS"].ToString();
            string TipoLogradouroPIS = context.Request.QueryString["TipoLogradouroPIS"].ToString();
            string LogradouroPIS = context.Request.QueryString["LogradouroPIS"].ToString();
            string NumeroEnderecoPIS = context.Request.QueryString["NumeroEnderecoPIS"].ToString();
            string BairroPIS = context.Request.QueryString["BairroPIS"].ToString();
            string ComplementoPIS = context.Request.QueryString["ComplementoPIS"].ToString();
            string CEPPIS = context.Request.QueryString["CEPPIS"].ToString();
            string OptanteFGTS = context.Request.QueryString["rdpOptanteFGTS"].ToString();
            string DataOpcao = context.Request.QueryString["DataOpcao"].ToString();
            string DataRetratacao = context.Request.QueryString["DataRetratacao"].ToString();
            string BancoFGTS = context.Request.QueryString["BancoFGTS"].ToString();
            string AgenciaFGTS = context.Request.QueryString["AgenciaFGTS"].ToString();
            string DigitoFGTS = context.Request.QueryString["DigitoFGTS"].ToString();
            string Cor = context.Request.QueryString["Cor"].ToString();
            string Altura = context.Request.QueryString["Altura"].ToString();
            string Peso = context.Request.QueryString["Peso"].ToString();
            string Cabelo = context.Request.QueryString["Cabelo"].ToString();
            string Olho = context.Request.QueryString["Olho"].ToString();
            string Sinais = context.Request.QueryString["Sinais"].ToString();


            //Objetos Dados de Funcionario
            FuncionariosVO Funcionario = new FuncionariosVO();
            EstadoCivilVO objEstadoCivilFuncionario = new EstadoCivilVO();
            EnderecoVO EnderecoFuncionario = new EnderecoVO();
            TipoEnderecoVO TipoEnderecoFuncionario = new TipoEnderecoVO();
            TipoLogradouroVO objTipoLogradouroFuncionario = new TipoLogradouroVO();
            DetalheEnderecoVO DetalheEnderecoFuncionario = new DetalheEnderecoVO();
            PaisVO objPaisFuncionario = new PaisVO();
            PaisVO objPaisPai = new PaisVO();
            PaisVO objPaisMae = new PaisVO();
            
            //Objetos de Documentos
            DocumentoVO objDocumentos = new DocumentoVO();
            DocumentoEstrangeiroVO objDocumentoEstrangeiro = new DocumentoEstrangeiroVO();
            DocumentoPISVO objDocumentosPIS = new DocumentoPISVO();
            EnderecoVO objEnderecoPIS = new EnderecoVO();
            TipoEnderecoVO objTipoEnderecoPIS = new TipoEnderecoVO();
            TipoLogradouroVO objTipoLogradouroPIS = new TipoLogradouroVO();
            DetalheEnderecoVO objDetalheEnderecoPIS = new DetalheEnderecoVO();
            DocumentoFundoGarantiaVO objDocumentoFundoGarantia = new DocumentoFundoGarantiaVO();

            //Objetos de Caracteristicas Fisicas
            CaractesristicaFisicaVO objCaractesristicaFisica = new CaractesristicaFisicaVO();
            TipoCorVO objTipoCor = new TipoCorVO();
            TipoCabeloVO objTipoCabelo = new TipoCabeloVO();
            TipoOlhoVO objTipoOlho = new TipoOlhoVO();

            //valorizar Objetos
            Funcionario.

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