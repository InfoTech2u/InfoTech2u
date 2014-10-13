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
    public partial class ManterAlteracaoCargoSalario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CarregarIncludes();
            CarregarCargo();

            string idFuncionario = Request.QueryString["idUser"].ToString();

            if (!String.IsNullOrWhiteSpace(idFuncionario))
                CarregarCampo(idFuncionario);
        }

        private void CarregarCampo(string idFuncionario)
        {
            DataTable dtRetorno = new DataTable();

            dtRetorno = SelecionarAdmissao();

            int i = 0;
            while (i < dtRetorno.Rows.Count)
            {

                this.txtCodigoAlteracaoCargoSalario.Text = dtRetorno.Rows[i]["CODIGO_ALTERACAO_CARGO_SALARIO"].ToString();
                this.txtData.Text = dtRetorno.Rows[i]["DATA"].ToString();
                this.txtHorarioEntrada.Text = dtRetorno.Rows[i]["HORARIO_INICIO"].ToString();
                this.txtHorarioSaida.Text = dtRetorno.Rows[i]["HORARIO_FIM"].ToString();
                this.txtSalario.Text = dtRetorno.Rows[i]["SALARIO"].ToString();

                InfoTech2uControlHtmlUtil.SetSelectedValue(this.ddlCargo, dtRetorno.Rows[i]["CODIGO_TIPO_CARGO"].ToString());
                

                i++;
            }
        }

        private DataTable SelecionarAdmissao()
        {
            AlteracaoCargoSalariorBS objBS = new AlteracaoCargoSalariorBS();
            AlteracaoCargoSalariorVO dadosAlteracaoCargoSalarior = new AlteracaoCargoSalariorVO();

            int codigoFuncionario = 0;
            if (Int32.TryParse(Request.QueryString["idUser"], out codigoFuncionario))
            {
                dadosAlteracaoCargoSalarior.CodigoFuncionario = codigoFuncionario;
            }

            return objBS.SelecionarAlteracaoCargoSalarior(dadosAlteracaoCargoSalarior);
        }

        private void CarregarCargo()
        {
            TipoCargoBS retornoCargoBS = new TipoCargoBS();
            TipoCargoVO objEntrada = new TipoCargoVO();
            List<TipoCargoVO> listaCargoVO = new List<TipoCargoVO>();

            listaCargoVO = retornoCargoBS.SelecionarCargoLista(objEntrada);

            this.ddlCargo.DataSource = listaCargoVO;
            this.ddlCargo.DataValueField = "CodigoTipoCargo";
            this.ddlCargo.DataTextField = "Descricao";
            this.ddlCargo.DataBind();
            this.ddlCargo.Items.Insert(0, new ListItem("Selecionar", "0"));
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
            InfoTech2uControlHtmlUtil.IncludeHtmlGenericControl(this.Page, "js", pachJs, "ManterAlteracaoCargoSalarior.js");
        }
    }
}