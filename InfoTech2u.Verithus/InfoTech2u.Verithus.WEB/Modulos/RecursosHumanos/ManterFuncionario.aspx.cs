using InfoTech2u.Verithus.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InfoTech2u.Verithus.VO;
using InfoTech2u.Verithus.BS;
using System.Data;

namespace InfoTech2u.Verithus.WEB.Modulos.RecursosHumanos.Funcionario
{
    public partial class ManterFuncionario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            CarregarIncludes();
            CarregarPais();
            CarregarEstadoCivil();
            CarregarTipoEndereco();
            CarregarTipoLogradouro();
            CarregarTipoCor();
            CarregarTipoCabelo();
            CarregarTipoOlho();
            CarregarTipoBancoPIS();
            CarregarTipoBancoFGTS();
            CarregarEstado();
            CarregarStatus();
            ConfiguracaoInicialPagina();


        }

        protected void ConfiguracaoInicialPagina()
        {
            string tpAcao = Request.QueryString["tpAcao"].ToString();
            string idUser;

            if (tpAcao != "1")
                idUser = Request.QueryString["idUser"].ToString();
            else
                idUser = null;

            switch (tpAcao)
            {
                case "1":
                    this.hdnCodigoUsuarioCadastro.Value = HttpContext.Current.Session["CodigoUsuario"].ToString();
                    break;

                case "2":
                    CarregarCampos(idUser);
                    this.hdnCodigoUsuarioAlteracao.Value = HttpContext.Current.Session["CodigoUsuario"].ToString();
                    break;

                case "3":
                    CarregarCampos(idUser);
                    BloquearCampos();
                    break;
                case "4":
                    CarregarCampos(idUser);
                    BloquearCampos();
                    HabilitarExcluir();
                    break;
            }

        }

        protected void HabilitarExcluir()
        { }

        protected void CarregarCampos(string idUser)
        {

            if (!string.IsNullOrWhiteSpace(idUser))
            {
                FuncionariosVO param = new FuncionariosVO();
                FuncionariosBS retorno = new FuncionariosBS();
                DataTable dtRetorno = new DataTable();

                param.CodigoFuncionario = Convert.ToInt32(idUser);

                dtRetorno = retorno.SelecionarFuncionario(param);

                //dtRetorno.Rows[i]["NOME"].ToString()

                //DataTable dt = dtRetorno;

                int i = 0;
                while (i < dtRetorno.Rows.Count)
                {

                    this.txtAgencia.Text = dtRetorno.Rows[i]["BANCO_PIS_AGENCIA"].ToString();
                    this.txtAgenciaFGTS.Text = dtRetorno.Rows[i]["BANCO_FGTS_AGENCIA"].ToString();
                    this.txtAltura.Text = dtRetorno.Rows[i]["CARACTERISTICA_FUNC_ALTURA"].ToString();
                    this.txtBairro.Text = dtRetorno.Rows[i]["DETL_END_BAIRRO"].ToString();
                    this.txtBairroPIS.Text = dtRetorno.Rows[i]["DETL_PIS_BAIRRO"].ToString();
                    this.txtCadastroPIS.Text = dtRetorno.Rows[i]["DOC_PIS_FUNC_DATA_CADASTRO_PIS"].ToString();
                    this.txtCarteira19.Text = dtRetorno.Rows[i]["DOC_EST_FUNC_NUMERO_CARTEIRA_19"].ToString();
                    this.txtCarteiraTrabalho.Text = dtRetorno.Rows[i]["DOC_FUNC_NUMERO_CARTEIRA_TRABALHO"].ToString();
                    this.txtCategoria.Text = dtRetorno.Rows[i]["DOC_FUNC_CATEGORIA"].ToString();
                    this.txtCateiraSaude.Text = dtRetorno.Rows[i]["DOC_FUNC_NUMERO_CARTEIRA_SAUDE"].ToString();
                    this.txtCBO.Text = dtRetorno.Rows[i]["DOC_EST_FUNC_NUMERO_CBO"].ToString();
                    this.txtCEP.Text = dtRetorno.Rows[i]["DETL_END_CEP"].ToString();
                    this.txtCEPPIS.Text = dtRetorno.Rows[i]["DETL_PIS_CEP"].ToString();
                    this.txtComplemento.Text = dtRetorno.Rows[i]["DETL_END_COMPLEMENTO"].ToString();
                    this.txtComplementoPIS.Text = dtRetorno.Rows[i]["DETL_PIS_COMPLEMENTO"].ToString();
                    this.txtConta.Text = dtRetorno.Rows[i]["BANCO_PIS_CONTA"].ToString();
                    this.txtContaFGTS.Text = dtRetorno.Rows[i]["BANCO_FGTS_CONTA"].ToString();
                    this.txtCPF.Text = dtRetorno.Rows[i]["DOC_FUNC_NUMERO_CPF"].ToString();
                    this.txtDataNascimento.Text = dtRetorno.Rows[i]["FUNC_DATA_NASCIMENTO"].ToString();
                    this.txtDataOpcao.Text = dtRetorno.Rows[i]["DOC_FGTS_FUNC_DATA_OPCAO"].ToString();
                    this.txtDataRetratacao.Text = dtRetorno.Rows[i]["DOC_FGTS_FUNC_DATA_RETRATACAO"].ToString();
                    this.txtDigito.Text = dtRetorno.Rows[i]["BANCO_PIS_DIGITO"].ToString();
                    this.txtDigitoFGTS.Text = dtRetorno.Rows[i]["BANCO_FGTS_DIGITO"].ToString();
                    this.txtLogradouro.Text = dtRetorno.Rows[i]["DETL_END_LOGRADOURO"].ToString();
                    this.txtLogradouroPIS.Text = dtRetorno.Rows[i]["DETL_PIS_LOGRADOURO"].ToString();
                    this.txtNomeConjuge.Text = dtRetorno.Rows[i]["FUNC_NOME_CONJUGE"].ToString();
                    this.txtNomeFuncionario.Text = dtRetorno.Rows[i]["FUNC_NOME_FUNCIONARIO"].ToString();
                    this.txtNomeMae.Text = dtRetorno.Rows[i]["FUNC_NOME_MAE"].ToString();
                    this.txtNomePai.Text = dtRetorno.Rows[i]["FUNC_NOME_PAI"].ToString();
                    this.txtNumeroCertificadoReservista.Text = dtRetorno.Rows[i]["DOC_FUNC_NUMERO_CERTIFICADO_RESERVISTA"].ToString();
                    this.txtNumeroEndereco.Text = dtRetorno.Rows[i]["DETL_END_NUMERO"].ToString();
                    this.txtNumeroEnderecoPIS.Text = dtRetorno.Rows[i]["DETL_PIS_NUMERO"].ToString();
                    this.txtNumeroMatricula.Text = dtRetorno.Rows[i]["FUNC_NUMERO_MATRICULA"].ToString();
                    this.txtNumeroOrdemMatricula.Text = dtRetorno.Rows[i]["FUNC_NUMERO_ORDEM_MATRICULA"].ToString();
                    this.txtNumeroSerie.Text = dtRetorno.Rows[i]["DOC_FUNC_NUMERO_SERIE"].ToString();
                    this.txtPeso.Text = dtRetorno.Rows[i]["CARACTERISTICA_FUNC_PESO"].ToString();
                    this.txtQtdFilhos.Text = dtRetorno.Rows[i]["FUNC_QUANTOS_FILHOS"].ToString();
                    this.txtRegistroGeral.Text = dtRetorno.Rows[i]["DOC_EST_FUNC_NUMERO_RESISTRO_GERAL"].ToString();
                    this.txtRG.Text = dtRetorno.Rows[i]["DOC_FUNC_NUMERO_IDENTIDADE"].ToString();
                    this.txtSinais.Text = dtRetorno.Rows[i]["CARACTERISTICA_FUNC_SINAIS"].ToString();
                    this.txtSobNumero.Text = dtRetorno.Rows[i]["DOC_PIS_FUNC_SOB_NUMERO"].ToString();
                    this.txtTituloEleitor.Text = dtRetorno.Rows[i]["DOC_FUNC_TITULO_ELEITOR"].ToString();

                    CidadeBS retornoCidade = new CidadeBS();
                    CidadeVO entradaFuncionario = new CidadeVO();
                    CidadeVO entradaPIS = new CidadeVO();
                    DataTable retornoListaFuncionario = new DataTable();
                    DataTable retornoListaPIS = new DataTable();

                    entradaFuncionario.CodigoEstado = Convert.ToInt32(dtRetorno.Rows[i]["DETL_END_CODIGO_ESTADO"].ToString());
                    entradaPIS.CodigoEstado = Convert.ToInt32(dtRetorno.Rows[i]["DETL_END_CODIGO_ESTADO"].ToString());

                    retornoListaFuncionario = retornoCidade.SelecionarCidade(entradaFuncionario);
                    retornoListaPIS = retornoCidade.SelecionarCidade(entradaPIS);

                    this.ddlCidadeFuncionario.DataSource = retornoListaFuncionario;
                    this.ddlCidadeFuncionario.DataValueField = "CODIGO_CIDADE";
                    this.ddlCidadeFuncionario.DataTextField = "DESCRICAO";
                    this.ddlCidadeFuncionario.DataBind();
                    this.ddlCidadeFuncionario.Items.Insert(0, new ListItem("Selecionar", "0"));

                    this.ddlCidadePIS.DataSource = retornoListaPIS;
                    this.ddlCidadePIS.DataValueField = "CODIGO_CIDADE";
                    this.ddlCidadePIS.DataTextField = "DESCRICAO";
                    this.ddlCidadePIS.DataBind();
                    this.ddlCidadePIS.Items.Insert(0, new ListItem("Selecionar", "0"));

                    InfoTech2uControlHtmlUtil.SetSelectedValue(this.ddlBancoFGTS, dtRetorno.Rows[i]["BANCO_FGTS_NUMERO_BANCO"].ToString());
                    InfoTech2uControlHtmlUtil.SetSelectedValue(this.ddlBancoPIS, dtRetorno.Rows[i]["BANCO_PIS_NUMERO_BANCO"].ToString());
                    InfoTech2uControlHtmlUtil.SetSelectedValue(this.ddlCabelo, dtRetorno.Rows[i]["CARACTERISTICA_FUNC_CODIGO_TIPO_CABELO"].ToString());
                    InfoTech2uControlHtmlUtil.SetSelectedValue(this.ddlCor, dtRetorno.Rows[i]["CARACTERISTICA_FUNC_CODIGO_TIPO_COR"].ToString());
                    InfoTech2uControlHtmlUtil.SetSelectedValue(this.ddlEstadoCivil, dtRetorno.Rows[i]["FUNC_CODIGO_ESTADO_CIVIL"].ToString());
                    InfoTech2uControlHtmlUtil.SetSelectedValue(this.ddlEstadoFuncionario, dtRetorno.Rows[i]["DETL_END_CODIGO_ESTADO"].ToString());
                    InfoTech2uControlHtmlUtil.SetSelectedValue(this.ddlEstadoPIS, dtRetorno.Rows[i]["DETL_PIS_CODIGO_ESTADO"].ToString());
                    InfoTech2uControlHtmlUtil.SetSelectedValue(this.ddlNacionalidadeFuncionario, dtRetorno.Rows[i]["FUNC_LOCAL_NASCIMENTO"].ToString());
                    InfoTech2uControlHtmlUtil.SetSelectedValue(this.ddlNacionalidadeMae, dtRetorno.Rows[i]["FUNC_NACIONALIDADE_MAE"].ToString());
                    InfoTech2uControlHtmlUtil.SetSelectedValue(this.ddlNacionalidadePai, dtRetorno.Rows[i]["FUNC_NACIONALIDADE_PAI"].ToString());
                    InfoTech2uControlHtmlUtil.SetSelectedValue(this.ddlOlho, dtRetorno.Rows[i]["CARACTERISTICA_FUNC_CODIGO_TIPO_OLHO"].ToString());
                    InfoTech2uControlHtmlUtil.SetSelectedValue(this.ddlTipoEndereco, dtRetorno.Rows[i]["DETL_END_CODIGO_TIPO_ENDERECO"].ToString());
                    InfoTech2uControlHtmlUtil.SetSelectedValue(this.ddlTipoEnderecoPIS, dtRetorno.Rows[i]["DETL_PIS_CODIGO_TIPO_ENDERECO"].ToString());
                    InfoTech2uControlHtmlUtil.SetSelectedValue(this.ddlTipoLogradouro, dtRetorno.Rows[i]["DETL_END_CODIGO_TIPO_LOGRADOURO"].ToString());
                    InfoTech2uControlHtmlUtil.SetSelectedValue(this.ddlTipoLogradouroPIS, dtRetorno.Rows[i]["DETL_PIS_CODIGO_TIPO_LOGRADOURO"].ToString());
                    InfoTech2uControlHtmlUtil.SetSelectedValue(this.ddlCidadePIS, dtRetorno.Rows[i]["DETL_PIS_CODIGO_CIDADE"].ToString());
                    InfoTech2uControlHtmlUtil.SetSelectedValue(this.ddlCidadeFuncionario, dtRetorno.Rows[i]["DETL_END_CODIGO_CIDADE"].ToString());
                    InfoTech2uControlHtmlUtil.SetSelectedValue(this.ddlStatus, dtRetorno.Rows[i]["FUNC_CODIGO_STATUS"].ToString());

                    //InfoTech2uControlHtmlUtil.SetSelectedValue(this.ddlBancoPIS, dtRetorno.Rows[i]["BANCO_FGTS_NUMERO_BANCO"].ToString());
                    //InfoTech2uControlHtmlUtil.SetSelectedValue(this.ddlBancoFGTS, dtRetorno.Rows[i]["BANCO_PIS_NUMERO_BANCO"].ToString());

                    this.txtCodigoFuncionario.Text = dtRetorno.Rows[i]["FUNC_CODIGO_FUNCIONARIO"].ToString();
                    this.hdnCodigoDocumento.Value = dtRetorno.Rows[i]["DOC_FUNC_CODIGO_DOCUMENTO"].ToString();
                    this.hdnCodigoDocumentoEstrangeiro.Value = dtRetorno.Rows[i]["DOC_EST_FUNC_CODIGO_DOCUMENTO_ESTRAGEIRO"].ToString();
                    this.hdnCodigoPIS.Value = dtRetorno.Rows[i]["DOC_PIS_FUNC_CODIGO_PIS"].ToString();
                    this.hdnCodigoDocumentoFundoGarantia.Value = dtRetorno.Rows[i]["DOC_FGTS_FUNC_CODIGO_DOCUMENTO_FUNDO_GARANTIA"].ToString();
                    this.hdnCodigoCaracteristicaFisica.Value = dtRetorno.Rows[i]["CARACTERISTICA_FUNC_CODIGO_CARACTERISTICA_FISICA"].ToString();
                    this.hdnDetalheEndereco.Value = dtRetorno.Rows[i]["DETL_END_CODIGO_ENDERECO"].ToString();

                    this.hdnDetalheEnderecoPIS.Value = dtRetorno.Rows[i]["DETL_PIS_CODIGO_ENDERECO"].ToString();
                    this.hdnCodigoBancoPIS.Value = dtRetorno.Rows[i]["BANCO_PIS_CODIGO_BANCO"].ToString();
                    this.hdnCodigoBancoFGTS.Value = dtRetorno.Rows[i]["BANCO_FGTS_CODIGO_BANCO"].ToString();
                    
                    
                    i++;
                }

            }
        }

        

        protected void BloquearCampos()
        {
            this.txtAgencia.ReadOnly = true;
            this.txtAgenciaFGTS.ReadOnly = true;
            this.txtAltura.ReadOnly = true;
            this.txtBairro.ReadOnly = true;
            this.txtBairroPIS.ReadOnly = true;
            //this.txtBancoFGTS.ReadOnly = true;
            //this.txtBancoPIS.ReadOnly = true;
            this.txtCadastroPIS.ReadOnly = true;
            this.txtCarteira19.ReadOnly = true;
            this.txtCarteiraTrabalho.ReadOnly = true;
            this.txtCategoria.ReadOnly = true;
            this.txtCateiraSaude.ReadOnly = true;
            this.txtCBO.ReadOnly = true;
            this.txtCEP.ReadOnly = true;
            this.txtCEPPIS.ReadOnly = true;
            this.txtComplemento.ReadOnly = true;
            this.txtComplementoPIS.ReadOnly = true;
            this.txtConta.ReadOnly = true;
            this.txtContaFGTS.ReadOnly = true;
            this.txtCPF.ReadOnly = true;
            this.txtDataNascimento.ReadOnly = true;
            this.txtDataOpcao.ReadOnly = true;
            this.txtDataRetratacao.ReadOnly = true;
            this.txtDigito.ReadOnly = true;
            this.txtDigitoFGTS.ReadOnly = true;
            this.txtLogradouro.ReadOnly = true;
            this.txtLogradouroPIS.ReadOnly = true;
            this.txtNomeConjuge.ReadOnly = true;
            this.txtNomeFuncionario.ReadOnly = true;
            this.txtNomeMae.ReadOnly = true;
            this.txtNomePai.ReadOnly = true;
            this.txtNumeroCertificadoReservista.ReadOnly = true;
            this.txtNumeroEndereco.ReadOnly = true;
            this.txtNumeroEnderecoPIS.ReadOnly = true;
            this.txtNumeroMatricula.ReadOnly = true;
            this.txtNumeroOrdemMatricula.ReadOnly = true;
            this.txtNumeroSerie.ReadOnly = true;
            this.txtPeso.ReadOnly = true;
            this.txtQtdFilhos.ReadOnly = true;
            this.txtRegistroGeral.ReadOnly = true;
            this.txtRG.ReadOnly = true;
            this.txtSinais.ReadOnly = true;
            this.txtSobNumero.ReadOnly = true;
            this.txtTituloEleitor.ReadOnly = true;
            this.ddlBancoFGTS.Enabled = false;
            this.ddlBancoPIS.Enabled = false;
            this.ddlCabelo.Enabled = false;
            this.ddlCor.Enabled = false;
            this.ddlEstadoCivil.Enabled = false;
            this.ddlEstadoFuncionario.Enabled = false;
            this.ddlCidadeFuncionario.Enabled = false;
            this.ddlCidadePIS.Enabled = false;
            this.ddlEstadoPIS.Enabled = false;
            this.ddlNacionalidadeFuncionario.Enabled = false;
            this.ddlNacionalidadeMae.Enabled = false;
            this.ddlNacionalidadePai.Enabled = false;
            this.ddlOlho.Enabled = false;
            this.ddlTipoEndereco.Enabled = false;
            this.ddlTipoEnderecoPIS.Enabled = false;
            this.ddlTipoLogradouro.Enabled = false;
            this.ddlTipoLogradouroPIS.Enabled = false;
            this.rblFilhoBrasileiro.Enabled = false;
            this.rblNaturalizado.Enabled = false;
            this.rdbCasadoBrasileiro.Enabled = false;
            this.rdpOptanteFGTS.Enabled = false;



        }

        protected void CarregarTipoBancoPIS()
        {
            TipoBancoBS retorno = new TipoBancoBS();
            TipoBancoVO entrada = new TipoBancoVO();
            List<TipoBancoVO> retornoLista = new List<TipoBancoVO>();

            retornoLista = retorno.SelecionarTipoBanco(entrada);

            this.ddlBancoPIS.DataSource = retornoLista;
            this.ddlBancoPIS.DataValueField = "CodigoBanco";
            this.ddlBancoPIS.DataTextField = "NomeBanco";
            this.ddlBancoPIS.DataBind();
            this.ddlBancoPIS.Items.Insert(0, new ListItem("Selecionar", "0"));
        }

        protected void CarregarTipoBancoFGTS()
        {
            TipoBancoBS retorno = new TipoBancoBS();
            TipoBancoVO entrada = new TipoBancoVO();
            List<TipoBancoVO> retornoLista = new List<TipoBancoVO>();

            retornoLista = retorno.SelecionarTipoBanco(entrada);

            this.ddlBancoFGTS.DataSource = retornoLista;
            this.ddlBancoFGTS.DataValueField = "CodigoBanco";
            this.ddlBancoFGTS.DataTextField = "NomeBanco";
            this.ddlBancoFGTS.DataBind();
            this.ddlBancoFGTS.Items.Insert(0, new ListItem("Selecionar", "0"));
        }

        protected void CarregarTipoCor()
        {
            TipoCorBS retorno = new TipoCorBS();
            TipoCorVO entrada = new TipoCorVO();
            List<TipoCorVO> retornoLista = new List<TipoCorVO>();

            retornoLista = retorno.SelecionarTipoCor(entrada);

            this.ddlCor.DataSource = retornoLista;
            this.ddlCor.DataValueField = "CodigoTipoCor";
            this.ddlCor.DataTextField = "Descricao";
            this.ddlCor.DataBind();
            this.ddlCor.Items.Insert(0, new ListItem("Selecionar", "0"));
        }

        protected void CarregarTipoOlho()
        {
            TipoOlhoBS retorno = new TipoOlhoBS();
            TipoOlhoVO entrada = new TipoOlhoVO();
            List<TipoOlhoVO> retornoLista = new List<TipoOlhoVO>();

            retornoLista = retorno.SelecionarTipoOlhoLista(entrada);

            this.ddlOlho.DataSource = retornoLista;
            this.ddlOlho.DataValueField = "CodigoTipoOlho";
            this.ddlOlho.DataTextField = "Descricao";
            this.ddlOlho.DataBind();
            this.ddlOlho.Items.Insert(0, new ListItem("Selecionar", "0"));
        }

        protected void CarregarStatus()
        {
            StatusBS retorno = new StatusBS();
            StatusVO entrada = new StatusVO();
            List<StatusVO> retornoLista = new List<StatusVO>();

            retornoLista = retorno.SelecionarStatus(entrada);

            this.ddlStatus.DataSource = retornoLista;
            this.ddlStatus.DataValueField = "CodigoStatus";
            this.ddlStatus.DataTextField = "Descricao";
            this.ddlStatus.DataBind();
            this.ddlStatus.Items.Insert(0, new ListItem("Selecionar", "0"));
        }

        protected void CarregarTipoCabelo()
        {
            TipoCabeloBS retorno = new TipoCabeloBS();
            TipoCabeloVO entrada = new TipoCabeloVO();
            List<TipoCabeloVO> retornoLista = new List<TipoCabeloVO>();

            retornoLista = retorno.SelecionarTipoCabeloLista(entrada);

            this.ddlCabelo.DataSource = retornoLista;
            this.ddlCabelo.DataValueField = "CodigoTipoCabelo";
            this.ddlCabelo.DataTextField = "Descricao";
            this.ddlCabelo.DataBind();
            this.ddlCabelo.Items.Insert(0, new ListItem("Selecionar", "0"));
        }

        protected void CarregarTipoLogradouro()
        {

            TipoLogradouroBS retorno = new TipoLogradouroBS();
            TipoLogradouroVO entrada = new TipoLogradouroVO();
            List<TipoLogradouroVO> retornoLista = new List<TipoLogradouroVO>();

            retornoLista = retorno.SelecionarTipoLogradouroLista(entrada);

            this.ddlTipoLogradouro.DataSource = retornoLista;
            this.ddlTipoLogradouro.DataValueField = "CodigoTipoLogradouro";
            this.ddlTipoLogradouro.DataTextField = "Descricao";
            this.ddlTipoLogradouro.DataBind();
            this.ddlTipoLogradouro.Items.Insert(0, new ListItem("Selecionar", "0"));

            this.ddlTipoLogradouroPIS.DataSource = retornoLista;
            this.ddlTipoLogradouroPIS.DataValueField = "CodigoTipoLogradouro";
            this.ddlTipoLogradouroPIS.DataTextField = "Descricao";
            this.ddlTipoLogradouroPIS.DataBind();
            this.ddlTipoLogradouroPIS.Items.Insert(0, new ListItem("Selecionar", "0"));
        }

        protected void CarregarTipoEndereco()
        {
            TipoEnderecoBS retorno = new TipoEnderecoBS();
            TipoEnderecoVO entrada = new TipoEnderecoVO();
            List<TipoEnderecoVO> retornoLista = new List<TipoEnderecoVO>();

            retornoLista = retorno.SelecionarTipoEndereco(entrada);

            this.ddlTipoEndereco.DataSource = retornoLista;
            this.ddlTipoEndereco.DataValueField = "CodigoTipoEndereco";
            this.ddlTipoEndereco.DataTextField = "Descricao";
            this.ddlTipoEndereco.DataBind();
            this.ddlTipoEndereco.Items.Insert(0, new ListItem("Selecionar", "0"));

            this.ddlTipoEnderecoPIS.DataSource = retornoLista;
            this.ddlTipoEnderecoPIS.DataValueField = "CodigoTipoEndereco";
            this.ddlTipoEnderecoPIS.DataTextField = "Descricao";
            this.ddlTipoEnderecoPIS.DataBind();
            this.ddlTipoEnderecoPIS.Items.Insert(0, new ListItem("Selecionar", "0"));


        }

        protected void CarregarEstadoCivil()
        {
            EstadoCivilBS retorno = new EstadoCivilBS();
            EstadoCivilVO entrada = new EstadoCivilVO();
            List<EstadoCivilVO> retornoLista = new List<EstadoCivilVO>();

            retornoLista = retorno.SelecionarEstadoCivilLista(entrada);

            this.ddlEstadoCivil.DataSource = retornoLista;
            this.ddlEstadoCivil.DataValueField = "CodigoEstadoCivil";
            this.ddlEstadoCivil.DataTextField = "Descricao";
            this.ddlEstadoCivil.DataBind();
            this.ddlEstadoCivil.Items.Insert(0, new ListItem("Selecionar", "0"));



        }

        protected void CarregarEstado()
        {
            EstadoBS retorno = new EstadoBS();
            EstadoVO entrada = new EstadoVO();
            List<EstadoVO> retornoLista = new List<EstadoVO>();

            retornoLista = retorno.SelecionarEstado(entrada);

            this.ddlEstadoFuncionario.DataSource = retornoLista;
            this.ddlEstadoFuncionario.DataValueField = "CodigoEstado";
            this.ddlEstadoFuncionario.DataTextField = "Descricao";
            this.ddlEstadoFuncionario.DataBind();
            this.ddlEstadoFuncionario.Items.Insert(0, new ListItem("Selecionar", "0"));

            this.ddlEstadoPIS.DataSource = retornoLista;
            this.ddlEstadoPIS.DataValueField = "CodigoEstado";
            this.ddlEstadoPIS.DataTextField = "Descricao";
            this.ddlEstadoPIS.DataBind();
            this.ddlEstadoPIS.Items.Insert(0, new ListItem("Selecionar", "0"));
        }

        protected void CarregarPais()
        {
            PaisBS retorno = new PaisBS();
            PaisVO entrada = new PaisVO();
            List<PaisVO> retornoLista = new List<PaisVO>();

            retornoLista = retorno.SelecionarPaisLista(entrada);


            this.ddlNacionalidadePai.DataSource = retornoLista;
            this.ddlNacionalidadePai.DataValueField = "CodigoPais";
            this.ddlNacionalidadePai.DataTextField = "Descricao";
            this.ddlNacionalidadePai.DataBind();
            this.ddlNacionalidadePai.Items.Insert(0, new ListItem("Selecionar", "0"));

            this.ddlNacionalidadeMae.DataSource = retornoLista;
            this.ddlNacionalidadeMae.DataValueField = "CodigoPais";
            this.ddlNacionalidadeMae.DataTextField = "Descricao";
            this.ddlNacionalidadeMae.DataBind();
            this.ddlNacionalidadeMae.Items.Insert(0, new ListItem("Selecionar", "0"));

            this.ddlNacionalidadeFuncionario.DataSource = retornoLista;
            this.ddlNacionalidadeFuncionario.DataValueField = "CodigoPais";
            this.ddlNacionalidadeFuncionario.DataTextField = "Descricao";
            this.ddlNacionalidadeFuncionario.DataBind();
            this.ddlNacionalidadeFuncionario.Items.Insert(0, new ListItem("Selecionar", "0"));



        }
        protected void CarregarIncludes()
        {
            string pachCss = "../../css/";
            string pachJs = "../../js/";

            InfoTech2uControlHtmlUtil.IncludeHtmlGenericControl(this.Page, "css", pachCss, "style.default.css");

            InfoTech2uControlHtmlUtil.IncludeHtmlGenericControl(this.Page, "css", pachCss, "bootstrap-fileupload.min.css");
            InfoTech2uControlHtmlUtil.IncludeHtmlGenericControl(this.Page, "css", pachCss, "bootstrap-timepicker.min.css");

            InfoTech2uControlHtmlUtil.IncludeHtmlGenericControl(this.Page, "js", pachJs, "jquery-1.9.1.min.js");
            InfoTech2uControlHtmlUtil.IncludeHtmlGenericControl(this.Page, "js", pachJs, "jquery-migrate-1.1.1.min.js");
            InfoTech2uControlHtmlUtil.IncludeHtmlGenericControl(this.Page, "js", pachJs, "jquery-ui-1.9.2.min.js");
            InfoTech2uControlHtmlUtil.IncludeHtmlGenericControl(this.Page, "js", pachJs, "bootstrap.min.js");
            InfoTech2uControlHtmlUtil.IncludeHtmlGenericControl(this.Page, "js", pachJs, "bootstrap-fileupload.min.js");
            InfoTech2uControlHtmlUtil.IncludeHtmlGenericControl(this.Page, "js", pachJs, "bootstrap-timepicker.min.js");
            InfoTech2uControlHtmlUtil.IncludeHtmlGenericControl(this.Page, "js", pachJs, "jquery.uniform.min.js");
            InfoTech2uControlHtmlUtil.IncludeHtmlGenericControl(this.Page, "js", pachJs, "jquery.validate.min.js");
            InfoTech2uControlHtmlUtil.IncludeHtmlGenericControl(this.Page, "js", pachJs, "jquery.tagsinput.min.js");
            InfoTech2uControlHtmlUtil.IncludeHtmlGenericControl(this.Page, "js", pachJs, "jquery.autogrow-textarea.js");
            //InfoTech2uControlHtmlUtil.IncludeHtmlGenericControl(this.Page, "js", pachJs, "charCount.js");
            InfoTech2uControlHtmlUtil.IncludeHtmlGenericControl(this.Page, "js", pachJs, "colorpicker.js");
            InfoTech2uControlHtmlUtil.IncludeHtmlGenericControl(this.Page, "js", pachJs, "ui.spinner.min.js");
            InfoTech2uControlHtmlUtil.IncludeHtmlGenericControl(this.Page, "js", pachJs, "chosen.jquery.min.js");
            InfoTech2uControlHtmlUtil.IncludeHtmlGenericControl(this.Page, "js", pachJs, "jquery.cookie.js");
            InfoTech2uControlHtmlUtil.IncludeHtmlGenericControl(this.Page, "js", pachJs, "modernizr.min.js");
            InfoTech2uControlHtmlUtil.IncludeHtmlGenericControl(this.Page, "js", pachJs, "jquery.smartWizard.min.js");
            InfoTech2uControlHtmlUtil.IncludeHtmlGenericControl(this.Page, "js", pachJs, "jquery.maskedinput-1.3.js");
            InfoTech2uControlHtmlUtil.IncludeHtmlGenericControl(this.Page, "js", pachJs, "jquery.maskMoney.js");
            InfoTech2uControlHtmlUtil.IncludeHtmlGenericControl(this.Page, "js", pachJs, "custom.js");
            InfoTech2uControlHtmlUtil.IncludeHtmlGenericControl(this.Page, "js", pachJs, "CadastroFuncionario.js");

        }
    }
}