using InfoTech2u.Verithus.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InfoTech2u.Verithus.VO;
using InfoTech2u.Verithus.BS;

namespace InfoTech2u.Verithus.WEB.Modulos.RecursosHumanos.Funcionario
{
    public partial class ManterFuncionario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CarregarIncludes();
                CarregarPais();
                CarregarEstadoCivil();
                CarregarTipoEndereco();
                CarregarTipoLogradouro();
                CarregarTipoCor();
                CarregarTipoCabelo();
                CarregarTipoOlho();
            }


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