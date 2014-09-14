using System;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.UI;
using InfoTech2u.Verithus.VO;
using InfoTech2u.Verithus.BS;
using System.Web.Script.Serialization;
using System.Collections.Generic;
using System.Data;
using InfoTech2u.Verithus.Util;

namespace InfoTech2u.Verithus.WEB.Handler
{
    /// <summary>
    /// Summary description for ManutencaoFuncionario
    /// </summary>
    public class ManutencaoFuncionario : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            DataTable dtRetorno = new DataTable();
            FuncionariosBS objRetorno = new FuncionariosBS();
            //Objetos Dados de Funcionario
            FuncionariosVO objFuncionario = new FuncionariosVO();
            EstadoCivilVO objEstadoCivilFuncionario = new EstadoCivilVO();
            EnderecoVO objEnderecoFuncionario = new EnderecoVO();
            TipoEnderecoVO objTipoEnderecoFuncionario = new TipoEnderecoVO();
            TipoLogradouroVO objTipoLogradouroFuncionario = new TipoLogradouroVO();
            DetalheEnderecoVO objDetalheEnderecoFuncionario = new DetalheEnderecoVO();
            //List<DetalheEnderecoVO> objListaDetalheEnderecoFuncionario = new List<DetalheEnderecoVO>();
            PaisVO objPaisFuncionario = new PaisVO();
            PaisVO objPaisPai = new PaisVO();
            PaisVO objPaisMae = new PaisVO();

            //Objetos de Documentos
            DocumentoVO objDocumentos = new DocumentoVO();
            //List<DocumentoVO> objListaDocumentos = new List<DocumentoVO>();
            DocumentoEstrangeiroVO objDocumentoEstrangeiro = new DocumentoEstrangeiroVO();
            List<DocumentoEstrangeiroVO> objListDocumentoEstrangeiro = new List<DocumentoEstrangeiroVO>();
            DocumentoPISVO objDocumentosPIS = new DocumentoPISVO();
            //List<DocumentoPISVO> objListaDocumentosPIS = new List<DocumentoPISVO>();
            BancoVO objBancoPIS = new BancoVO();
            EnderecoVO objEnderecoPIS = new EnderecoVO();
            TipoEnderecoVO objTipoEnderecoPIS = new TipoEnderecoVO();
            TipoLogradouroVO objTipoLogradouroPIS = new TipoLogradouroVO();
            DetalheEnderecoVO objDetalheEnderecoPIS = new DetalheEnderecoVO();
            //List<DetalheEnderecoVO> objListDetalheEnderecoPIS = new List<DetalheEnderecoVO>();
            DocumentoFundoGarantiaVO objDocumentoFundoGarantia = new DocumentoFundoGarantiaVO();
            //List<DocumentoFundoGarantiaVO> objListaDocumentoFundoGarantia = new List<DocumentoFundoGarantiaVO>();
            BancoVO objBancoFGTS = new BancoVO();

            //Objetos de Caracteristicas Fisicas
            CaractesristicaFisicaVO objCaractesristicaFisica = new CaractesristicaFisicaVO();
            // List<CaractesristicaFisicaVO> objListaCaractesristicaFisica = new List<CaractesristicaFisicaVO>();
            TipoCorVO objTipoCor = new TipoCorVO();
            TipoCabeloVO objTipoCabelo = new TipoCabeloVO();
            TipoOlhoVO objTipoOlho = new TipoOlhoVO();

            string retorno = "";

            string Metodo = context.Request.QueryString["Metodo"].ToString();
            string Acao = context.Request.QueryString["Acao"].ToString();
            //string UsuarioAcao = context.Request.QueryString["UsuarioAcao"].ToString();

            //Dados Pessoais
            string NumeroOrdemMatricula = context.Request.QueryString["NumeroOrdemMatricula"].ToString();
            string NumeroMatricula = context.Request.QueryString["NumeroMatricula"].ToString();
            string NomeFuncionario = context.Request.QueryString["NomeFuncionario"].ToString();
            string DataNascimento = context.Request.QueryString["DataNascimento"].ToString();
            string NacionalidadeFuncionario = context.Request.QueryString["NacionalidadeFuncionario"].ToString();
            string EstadoCivil = context.Request.QueryString["EstadoCivil"].ToString();
            string NomeConjuge = context.Request.QueryString["NomeConjuge"].ToString();
            string QtdFilhos = context.Request.QueryString["QtdFilhos"].ToString();
            //Endereço
            string TipoEndereco = context.Request.QueryString["TipoEndereco"].ToString();
            string TipoLogradouro = context.Request.QueryString["TipoLogradouro"].ToString();
            string CidadeFuncionario = context.Request.QueryString["CidadeFuncionario"].ToString();
            string EstadoFuncionario = context.Request.QueryString["EstadoFuncionario"].ToString();

            string Logradouro = context.Request.QueryString["Logradouro"].ToString();
            string NumeroEndereco = context.Request.QueryString["NumeroEndereco"].ToString();
            string Bairro = context.Request.QueryString["Bairro"].ToString();
            string Complemento = context.Request.QueryString["Complemento"].ToString();
            string CEP = context.Request.QueryString["CEP"].ToString();
            //Filiação
            string NomePai = context.Request.QueryString["NomePai"].ToString();
            string NacionalidadePai = context.Request.QueryString["NacionalidadePai"].ToString();
            string NomeMae = context.Request.QueryString["NomeMae"].ToString();
            string NacionalidadeMae = context.Request.QueryString["NacionalidadeMae"].ToString();
            //Documentos
            string RG = context.Request.QueryString["RG"].ToString();
            string CarteiraTrabalho = context.Request.QueryString["CarteiraTrabalho"].ToString();
            string NumeroSerie = context.Request.QueryString["NumeroSerie"].ToString();
            string NumeroCertificadoReservista = context.Request.QueryString["NumeroCertificadoReservista"].ToString();
            string Categoria = context.Request.QueryString["Categoria"].ToString();
            string CPF = context.Request.QueryString["CPF"].ToString();
            string TituloEleitor = context.Request.QueryString["TituloEleitor"].ToString();
            string CateiraSaude = context.Request.QueryString["CateiraSaude"].ToString();
            //Documentos Estrangeiro
            string CBO = context.Request.QueryString["CBO"].ToString();
            string Carteira19 = context.Request.QueryString["Carteira19"].ToString();
            string RegistroGeral = context.Request.QueryString["RegistroGeral"].ToString();
            string CasadoBrasileiro = context.Request.QueryString["CasadoBrasileiro"].ToString();
            string Naturalizado = context.Request.QueryString["Naturalizado"].ToString();
            string FilhoBrasileiro = context.Request.QueryString["FilhoBrasileiro"].ToString();
            string DataChegadaBrasil = context.Request.QueryString["DataChegadaBrasil"].ToString();
            //Documentos PIS
            string CadastroPIS = context.Request.QueryString["CadastroPIS"].ToString();
            string SobNumero = context.Request.QueryString["SobNumero"].ToString();
            string BancoPIS = context.Request.QueryString["BancoPIS"].ToString();
            string Agencia = context.Request.QueryString["Agencia"].ToString();
            string Digito = context.Request.QueryString["Digito"].ToString();
            string TipoEnderecoPIS = context.Request.QueryString["TipoEnderecoPIS"].ToString();
            string TipoLogradouroPIS = context.Request.QueryString["TipoLogradouroPIS"].ToString();
            string CidadePIS = context.Request.QueryString["CidadePIS"].ToString();
            string EstadoPIS = context.Request.QueryString["EstadoPIS"].ToString();
            string LogradouroPIS = context.Request.QueryString["LogradouroPIS"].ToString();
            string NumeroEnderecoPIS = context.Request.QueryString["NumeroEnderecoPIS"].ToString();
            string BairroPIS = context.Request.QueryString["BairroPIS"].ToString();
            string ComplementoPIS = context.Request.QueryString["ComplementoPIS"].ToString();
            string CEPPIS = context.Request.QueryString["CEPPIS"].ToString();
            //Documentos Fundo de Garantia
            string OptanteFGTS = context.Request.QueryString["OptanteFGTS"].ToString();
            string DataOpcao = context.Request.QueryString["DataOpcao"].ToString();
            string DataRetratacao = context.Request.QueryString["DataRetratacao"].ToString();
            string BancoFGTS = context.Request.QueryString["BancoFGTS"].ToString();
            string AgenciaFGTS = context.Request.QueryString["AgenciaFGTS"].ToString();
            string DigitoFGTS = context.Request.QueryString["DigitoFGTS"].ToString();
            //Caracteristicas Fisicas
            string Cor = context.Request.QueryString["Cor"].ToString();
            string Altura = context.Request.QueryString["Altura"].ToString();
            string Peso = context.Request.QueryString["Peso"].ToString();
            string Cabelo = context.Request.QueryString["Cabelo"].ToString();
            string Olho = context.Request.QueryString["Olho"].ToString();
            string Sinais = context.Request.QueryString["Sinais"].ToString();


            //Passo 1 - Dados Pessoais
            if (!String.IsNullOrWhiteSpace(NumeroOrdemMatricula))
                objFuncionario.NumeroOrdemMatricula = Convert.ToInt32(NumeroOrdemMatricula);

            if (!String.IsNullOrWhiteSpace(NumeroMatricula))
                objFuncionario.NumeroMatricula = Convert.ToInt32(NumeroMatricula);
            objFuncionario.NomeFuncionario = NomeFuncionario;

            if (!String.IsNullOrWhiteSpace(DataNascimento))
                objFuncionario.DataNascimento = Convert.ToDateTime(DataNascimento);
            
            objFuncionario.LocalNascimento = objPaisFuncionario.CodigoPais.ToString();

            if (!String.IsNullOrWhiteSpace(EstadoCivil))
                objFuncionario.CodigoEstadoCivil = Convert.ToInt32(EstadoCivil);
            objFuncionario.NomeConjuge = NomeConjuge;

            if (!String.IsNullOrWhiteSpace(QtdFilhos))
                objFuncionario.QuantosFilhos = Convert.ToInt16(QtdFilhos);

            //Passo2 - Endereço
            if (!String.IsNullOrWhiteSpace(TipoEndereco))
                objTipoEnderecoFuncionario.CodigoTipoEndereco = Convert.ToInt32(TipoEndereco);

            if (!String.IsNullOrWhiteSpace(TipoLogradouro))
                objTipoLogradouroFuncionario.CodigoTipoLogradouro = Convert.ToInt32(TipoLogradouro);

            objDetalheEnderecoFuncionario.TipoEnderecoVO = objTipoEnderecoFuncionario;
            objDetalheEnderecoFuncionario.TipoLogradouroVO = objTipoLogradouroFuncionario;

            if (!String.IsNullOrWhiteSpace(CidadeFuncionario))
                objDetalheEnderecoFuncionario.CodigoCidade = Convert.ToInt32(CidadeFuncionario);

            if (!String.IsNullOrWhiteSpace(EstadoFuncionario))
                objDetalheEnderecoFuncionario.CodigoEstado = Convert.ToInt32(EstadoFuncionario);

            objDetalheEnderecoFuncionario.Logradouro = Logradouro;
            objDetalheEnderecoFuncionario.Numero = NumeroEndereco;
            objDetalheEnderecoFuncionario.Bairro = Bairro;
            objDetalheEnderecoFuncionario.Complemento = Complemento;
            objDetalheEnderecoFuncionario.CEP = CEP;
            //objListaDetalheEnderecoFuncionario.Add(objDetalheEnderecoFuncionario);
            objEnderecoFuncionario.DetalheEndereco = objDetalheEnderecoFuncionario;
            objFuncionario.Endereco = objEnderecoFuncionario;
            //Passo 3 - Filiação
            objFuncionario.NomePai = NomePai;
            objFuncionario.NacionalidadePai = NacionalidadePai;
            objFuncionario.NomeMae = NomeMae;
            objFuncionario.NacionalidadeMae = NacionalidadeMae;
            //Passo 4 - Documentos
            objDocumentos.NumeroIdentidade = RG;
            objDocumentos.NumeroCarteiraTrabalho = CarteiraTrabalho;
            objDocumentos.NumeroSerie = NumeroSerie;
            objDocumentos.NumeroCertificadoReservista = NumeroCertificadoReservista;
            objDocumentos.Categoria = Categoria;
            objDocumentos.NumeroCPF = CPF;
            objDocumentos.TituloEleitor = TituloEleitor;
            objDocumentos.NumeroCarteiraSaude = CateiraSaude;
            //objListaDocumentos.Add(objDocumentos);
            objFuncionario.Documento = objDocumentos;
            //Passo 4 - Documentos Estrangeiro
            objDocumentoEstrangeiro.NumeroCBO = CBO;
            objDocumentoEstrangeiro.NumeroCarteira19 = Carteira19;
            objDocumentoEstrangeiro.NumeroRegistroGeral = RegistroGeral;
            objDocumentoEstrangeiro.CasadoBrasileiro = CasadoBrasileiro;
            objDocumentoEstrangeiro.Naturalizado = Naturalizado;
            objDocumentoEstrangeiro.FilhoBrasileiro = FilhoBrasileiro;

            if (!String.IsNullOrWhiteSpace(DataChegadaBrasil))
                objDocumentoEstrangeiro.DataChegadaBrasil = Convert.ToDateTime(DataChegadaBrasil);
            //objListDocumentoEstrangeiro.Add(objDocumentoEstrangeiro);
            objFuncionario.DocumentoEstrangeiro = objDocumentoEstrangeiro;
            //Passo 5 Documentos PIS
            if (!String.IsNullOrWhiteSpace(CadastroPIS))
                objDocumentosPIS.DataCadastroPIS = Convert.ToDateTime(CadastroPIS);
            objDocumentosPIS.SOBNumero = SobNumero;
            objBancoPIS.NumeroBanco = BancoPIS;
            objBancoPIS.Agencia = Agencia;
            objBancoPIS.Digito = Digito;
            objDocumentosPIS.BancoVO = objBancoPIS;

            if (!String.IsNullOrWhiteSpace(TipoEnderecoPIS))
                objTipoEnderecoPIS.CodigoTipoEndereco = Convert.ToInt32(TipoEnderecoPIS);

            if (!String.IsNullOrWhiteSpace(TipoLogradouroPIS))
                objTipoLogradouroPIS.CodigoTipoLogradouro = Convert.ToInt32(TipoLogradouroPIS);


            if (!String.IsNullOrWhiteSpace(CidadePIS))
                objDetalheEnderecoPIS.CodigoCidade = Convert.ToInt32(CidadePIS);

            if (!String.IsNullOrWhiteSpace(EstadoPIS))
                objDetalheEnderecoPIS.CodigoEstado = Convert.ToInt32(EstadoPIS);

            objDetalheEnderecoPIS.TipoEnderecoVO = objTipoEnderecoPIS;
            objDetalheEnderecoPIS.TipoLogradouroVO = objTipoLogradouroPIS;
            objDetalheEnderecoPIS.Logradouro = LogradouroPIS;
            objDetalheEnderecoPIS.Numero = NumeroEnderecoPIS;
            objDetalheEnderecoPIS.Bairro = BairroPIS;
            objDetalheEnderecoPIS.Complemento = ComplementoPIS;
            objDetalheEnderecoPIS.CEP = CEPPIS;
            //objListDetalheEnderecoPIS.Add(objDetalheEnderecoPIS);
            objEnderecoPIS.DetalheEndereco = objDetalheEnderecoPIS;
            objDocumentosPIS.EnderecoVO = objEnderecoPIS;
            //objListaDocumentosPIS.Add(objDocumentosPIS);
            objFuncionario.DocumentoPIS = objDocumentosPIS;
            //Passo 6 Documentos Fundo de Garantia
            objDocumentoFundoGarantia.Optante = OptanteFGTS;
            if (!String.IsNullOrWhiteSpace(DataOpcao))
                objDocumentoFundoGarantia.DataOpcao = Convert.ToDateTime(DataOpcao);

            if (!String.IsNullOrWhiteSpace(DataRetratacao))
                objDocumentoFundoGarantia.DataRetratacao = Convert.ToDateTime(DataRetratacao);

            objBancoFGTS.NumeroBanco = BancoFGTS;
            objBancoFGTS.Agencia = AgenciaFGTS;
            objBancoFGTS.Digito = DigitoFGTS;
            objDocumentoFundoGarantia.BancoVO = objBancoFGTS;
            //objListaDocumentoFundoGarantia.Add(objDocumentoFundoGarantia);
            objFuncionario.DocumentoFundoGarantia = objDocumentoFundoGarantia;
            //Passo 7 - Caracteristicas Fisicas
            if (!String.IsNullOrWhiteSpace(Altura))
                objCaractesristicaFisica.Altura = Altura;

            if (!String.IsNullOrWhiteSpace(Peso))
                objCaractesristicaFisica.Peso = Peso;

            objCaractesristicaFisica.Sinais = Sinais;

            if (!String.IsNullOrWhiteSpace(Cor))
                objTipoCor.CodigoTipoCor = Convert.ToInt32(Cor);

            objCaractesristicaFisica.TipoCorVO = objTipoCor;

            if (!String.IsNullOrWhiteSpace(Cabelo))
                objTipoCabelo.CodigoTipoCabelo = Convert.ToInt32(Cabelo);

            objCaractesristicaFisica.TipoCabeloVO = objTipoCabelo;

            if (!String.IsNullOrWhiteSpace(Olho))
                objTipoOlho.CodigoTipoOlho = Convert.ToInt32(Olho);

            objCaractesristicaFisica.TipoOlhoVO = objTipoOlho;
            //objListaCaractesristicaFisica.Add(objCaractesristicaFisica);
            objFuncionario.CaractesristicaFisica = objCaractesristicaFisica;

            objFuncionario.CodigoUsuarioCadastro = null;
            objFuncionario.DataCadastro = null;
            objFuncionario.CodigoUsuarioAlteracao = null;
            objFuncionario.DataAlteracao = null;

            dtRetorno = objRetorno.IncluirFuncionario(objFuncionario);


            context.Response.Write(dtRetorno.DataTableSerializer());
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