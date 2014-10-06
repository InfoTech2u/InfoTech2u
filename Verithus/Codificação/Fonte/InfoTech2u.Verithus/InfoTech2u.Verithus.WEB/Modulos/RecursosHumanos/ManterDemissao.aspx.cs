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
    public partial class ManterDemissao : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CarregarIncludes();
            CarregarTarefa();
            CarregarCargo();
            CarregarSecao();
            CarregarFormaPagamento();

            string idFuncionario = Request.QueryString["idUser"].ToString();

            if (!String.IsNullOrWhiteSpace(idFuncionario))
                CarregarCampo(idFuncionario);

        }

        private void CarregarCampo(string idFuncionario){

            DataTable dtRetorno = new DataTable();

            dtRetorno = SelecionarDemissão();

            int i = 0;
            while (i < dtRetorno.Rows.Count)
            {

                //this.txtAgencia.Text = dtRetorno.Rows[i]["BANCO_PIS_AGENCIA"].ToString();
                this.txtCodigoDemissao.Text = dtRetorno.Rows[i]["CODIGO_DEMISSAO"].ToString();
                this.txtComissao.Text = dtRetorno.Rows[i]["COMISSAO"].ToString();
                this.txtDataDemissao.Text = dtRetorno.Rows[i]["DATA_DEMISSAO"].ToString();
                this.txtDataRegistro.Text = dtRetorno.Rows[i]["DATA_REGISTRO"].ToString();
                this.txtSalarioInicial.Text = dtRetorno.Rows[i]["SALARIO_INICIAL"].ToString();

                InfoTech2uControlHtmlUtil.SetSelectedValue(this.ddlCargo, dtRetorno.Rows[i]["CODIGO_TIPO_CARGO"].ToString());
                InfoTech2uControlHtmlUtil.SetSelectedValue(this.ddlSecao, dtRetorno.Rows[i]["CODIGO_TIPO_SECAO"].ToString());
                InfoTech2uControlHtmlUtil.SetSelectedValue(this.ddlTarefa, dtRetorno.Rows[i]["CODIGO_TIPO_TAREFA"].ToString());
                InfoTech2uControlHtmlUtil.SetSelectedValue(this.ddlFormaPagamento, dtRetorno.Rows[i]["CODIGO_TIPO_FORMA_PAGAMENTO"].ToString());

                i++;
            }

        }

        private DataTable SelecionarDemissão()
        {
            DadosDemissaoBS objBS = new DadosDemissaoBS();
            DadosDemissaoVO dadosDemissao = new DadosDemissaoVO();

            int codigoFuncionario = 0;
            if (Int32.TryParse(Request.QueryString["idUser"], out codigoFuncionario))
            {
                dadosDemissao.CodigoFuncionario = codigoFuncionario;
            }

            return objBS.Selecionar(dadosDemissao);
        }

        private void CarregarFormaPagamento()
        {
            TipoFormaPagamentoBS retornoFormaPagamentoBS = new TipoFormaPagamentoBS();
            TipoFormaPagamentoVO objEntrada = new TipoFormaPagamentoVO();
            List<TipoFormaPagamentoVO> listaFormaPagamentoVO = new List<TipoFormaPagamentoVO>();

            listaFormaPagamentoVO = retornoFormaPagamentoBS.SelecionarFormaPagamentoLista(objEntrada);

            this.ddlFormaPagamento.DataSource = listaFormaPagamentoVO;
            this.ddlFormaPagamento.DataValueField = "CodigoTipoFormaPagamento";
            this.ddlFormaPagamento.DataTextField = "Descricao";
            this.ddlFormaPagamento.DataBind();
            this.ddlFormaPagamento.Items.Insert(0, new ListItem("Selecionar", "0"));
        }

        private void CarregarTarefa()
        {
            TipoTarefaBS retornoTarefaBS = new TipoTarefaBS();
            TipoTarefaVO objEntrada = new TipoTarefaVO();
            List<TipoTarefaVO> listaTarefaVO = new List<TipoTarefaVO>();

            listaTarefaVO = retornoTarefaBS.SelecionarTarefaLista(objEntrada);

            this.ddlTarefa.DataSource = listaTarefaVO;
            this.ddlTarefa.DataValueField = "CodigoTipoTarefa";
            this.ddlTarefa.DataTextField = "Descricao";
            this.ddlTarefa.DataBind();
            this.ddlTarefa.Items.Insert(0, new ListItem("Selecionar", "0"));
        }

        private void CarregarSecao()
        {
            TipoSecaoBS retornoSecaoBS = new TipoSecaoBS();
            TipoSecaoVO objEntrada = new TipoSecaoVO();
            List<TipoSecaoVO> listaSecaoVO = new List<TipoSecaoVO>();

            listaSecaoVO = retornoSecaoBS.SelecionarSecaoLista(objEntrada);

            this.ddlSecao.DataSource = listaSecaoVO;
            this.ddlSecao.DataValueField = "CodigoTipoSecao";
            this.ddlSecao.DataTextField = "Descricao";
            this.ddlSecao.DataBind();
            this.ddlSecao.Items.Insert(0, new ListItem("Selecionar", "0"));
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
            InfoTech2uControlHtmlUtil.IncludeHtmlGenericControl(this.Page, "js", pachJs, "jquery.cookie.js");
            InfoTech2uControlHtmlUtil.IncludeHtmlGenericControl(this.Page, "js", pachJs, "modernizr.min.js");
            InfoTech2uControlHtmlUtil.IncludeHtmlGenericControl(this.Page, "js", pachJs, "jquery.smartWizard.min.js");
            InfoTech2uControlHtmlUtil.IncludeHtmlGenericControl(this.Page, "js", pachJs, "jquery.maskedinput-1.3.js");
            InfoTech2uControlHtmlUtil.IncludeHtmlGenericControl(this.Page, "js", pachJs, "jquery.maskMoney.js");
            InfoTech2uControlHtmlUtil.IncludeHtmlGenericControl(this.Page, "js", pachJs, "custom.js");
            InfoTech2uControlHtmlUtil.IncludeHtmlGenericControl(this.Page, "js", pachJs, "CadastroDemissao.js");

        }
    }
}