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
    public partial class ManterAcidenteTrabalho : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CarregarIncludes();

            string idFuncionario = Request.QueryString["idUser"].ToString();
                CarregarCampo(idFuncionario);
        }

        private void CarregarCampo(string idFuncionario)
        {

            DataTable dtRetorno = new DataTable();

            dtRetorno = SelecionarAcidenteTrabalho();

            int i = 0;
            while (i < dtRetorno.Rows.Count)
            {

                this.txtCodigoAcidenteTrabalho.Text = dtRetorno.Rows[i]["CODIGO_ACIDENTE_TRABALHO"].ToString();
                this.txtData.Text = dtRetorno.Rows[i]["DATA"].ToString();
                this.txtLocalAcidente.Text = dtRetorno.Rows[i]["ACIDENTE_TRABALHO_LOCAL"].ToString();
                this.txtCausaAcidente.Text = dtRetorno.Rows[i]["CAUSA"].ToString();
                this.txtDataAlta.Text = dtRetorno.Rows[i]["DATA_ALTA"].ToString();
                this.txtResultado.Text = dtRetorno.Rows[i]["RESULTADO"].ToString();
                this.txtObservacoes.Text = dtRetorno.Rows[i]["OBSERVACOES"].ToString();

                i++;

            }

        }

        private DataTable SelecionarAcidenteTrabalho()
        {
            AcidenteTrabalhoBS objBS = new AcidenteTrabalhoBS();
            AcidenteTrabalhoVO dadosAcidenteTrabalho = new AcidenteTrabalhoVO();

            int codigoFuncionario = 0;
            if (Int32.TryParse(Request.QueryString["idUser"], out codigoFuncionario))
            {
                dadosAcidenteTrabalho.CodigoFuncionario = codigoFuncionario;
            }

            return objBS.SelecionarAcidenteTrabalho(dadosAcidenteTrabalho);
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
            InfoTech2uControlHtmlUtil.IncludeHtmlGenericControl(this.Page, "js", pachJs, "charCount.js");
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
            InfoTech2uControlHtmlUtil.IncludeHtmlGenericControl(this.Page, "js", pachJs, "ManterAcidenteTrabalho.js");
        }
    }
}