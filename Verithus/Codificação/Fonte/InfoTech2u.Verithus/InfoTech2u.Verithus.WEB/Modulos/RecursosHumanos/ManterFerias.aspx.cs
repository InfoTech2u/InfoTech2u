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

namespace InfoTech2u.Verithus.WEB.Modulos.RecursosHumanos
{
    public partial class ManterFerias : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CarregarIncludes();

            string idFuncionario = Request.QueryString["idUser"].ToString();
                CarregarCampo(idFuncionario);
        }

        private void CarregarCampo(string idFuncionario) {

            DataTable dtRetorno = new DataTable();

            dtRetorno = SelecionarFerias();

            int i = 0;
            while (i < dtRetorno.Rows.Count)
            {

                this.txtCodigoFerias.Text = dtRetorno.Rows[i]["CODIGO_FERIAS"].ToString();
                this.txtDataPeriodoInicio.Text = dtRetorno.Rows[i]["DATA_PERIODO_INICIO"].ToString();
                this.txtDataPeriodoFim.Text = dtRetorno.Rows[i]["DATA_PERIODO_FIM"].ToString();
                this.txtDataGozadaInicio.Text = dtRetorno.Rows[i]["DATA_GOZADA_INICIO"].ToString();
                this.txtDataGozadaFim.Text = dtRetorno.Rows[i]["DATA_GOZADA_FIM"].ToString();

                i++;

            }

        }

        private DataTable SelecionarFerias()
        {
            FeriasBS objBS = new FeriasBS();
            FeriasVO dadosFerias = new FeriasVO();

            int codigoFuncionario = 0;
            if (Int32.TryParse(Request.QueryString["idUser"], out codigoFuncionario))
            {
                dadosFerias.CodigoFuncionario = codigoFuncionario;
            }

            return objBS.SelecionarFerias(dadosFerias);
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
            InfoTech2uControlHtmlUtil.IncludeHtmlGenericControl(this.Page, "js", pachJs, "jquery.alerts.js");
            InfoTech2uControlHtmlUtil.IncludeHtmlGenericControl(this.Page, "js", pachJs, "jquery.cookie.js");
            InfoTech2uControlHtmlUtil.IncludeHtmlGenericControl(this.Page, "js", pachJs, "modernizr.min.js");
            InfoTech2uControlHtmlUtil.IncludeHtmlGenericControl(this.Page, "js", pachJs, "jquery.smartWizard.min.js");
            InfoTech2uControlHtmlUtil.IncludeHtmlGenericControl(this.Page, "js", pachJs, "jquery.maskedinput-1.3.js");
            InfoTech2uControlHtmlUtil.IncludeHtmlGenericControl(this.Page, "js", pachJs, "jquery.maskMoney.js");
            InfoTech2uControlHtmlUtil.IncludeHtmlGenericControl(this.Page, "js", pachJs, "custom.js");
            InfoTech2uControlHtmlUtil.IncludeHtmlGenericControl(this.Page, "js", pachJs, "ManterFerias.js");
        }
    }
}