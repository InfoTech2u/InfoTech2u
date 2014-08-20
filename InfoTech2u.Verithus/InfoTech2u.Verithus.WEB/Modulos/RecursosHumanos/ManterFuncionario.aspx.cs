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
            }

        }
        protected void CarregarPais()
        {
            PaisBS retorno = new PaisBS();
            PaisVO entrada = new PaisVO();
            List<PaisVO> retornoLista = new List<PaisVO>();

            retornoLista = retorno.SelecionarUsuarioLista(entrada);

            
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
            InfoTech2uControlHtmlUtil.IncludeHtmlGenericControl(this.Page, "js", pachJs, "custom.js");
            InfoTech2uControlHtmlUtil.IncludeHtmlGenericControl(this.Page, "js", pachJs, "CadastroFuncionario.js");


            /*
             bootstrap-fileupload.min.css
             bootstrap-timepicker.min.css
             
             bootstrap-fileupload.min.js
             bootstrap-timepicker.min.js
             jquery.validate.min.js
             jquery.tagsinput.min.js
             jquery.autogrow-textarea.js
             charCount.js
             colorpicker.js
             ui.spinner.min.js
             chosen.jquery.min.js
             forms.js
             */






        }
    }
}