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
    public partial class RelatorioFuncionarioGeral : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string idUser = Request.QueryString["idUser"].ToString();

            CarregarDadosFuncionario(idUser);
            CarregarCampoAdmissao(idUser);
            CarregarDemissao(idUser);
            CarregarSindicato(idUser);
            CarregaDependentes(idUser);
            CarregarIncludes();
            CarregarFerias(idUser);
            CarregarAlteracaoCargoSalario(idUser);
            ListaAcidenteTrabalho(idUser);
        }

        protected void CarregarAlteracaoCargoSalario(string idUser)
        {
            AlteracaoCargoSalariorVO param = new AlteracaoCargoSalariorVO();
            AlteracaoCargoSalariorBS retorno = new AlteracaoCargoSalariorBS();
            DataTable dtRetorno = new DataTable();

            param.CodigoFuncionario = Convert.ToInt32(idUser);

            dtRetorno = retorno.SelecionarAlteracaoCargoSalarior(param);

            this.rptDependentes.ItemDataBound += new RepeaterItemEventHandler(rptAcidenteTrabalho_ItemDataBound);

            this.grdAlteracaoCargoSalario.DataSource = dtRetorno;
            this.grdAlteracaoCargoSalario.DataBind();
        }

        protected void CarregaDependentes(string idUser)
        {
            List<DependenteVO> listaDependentes = ListaDependentes(idUser);

            // this.rptDependentes.ItemDataBound += new RepeaterItemEventHandler(rptDependentes_ItemDataBound);

            this.rptDependentes.DataSource = listaDependentes;
            this.rptDependentes.DataBind();



        }

        protected void ListaAcidenteTrabalho(string idUser)
        {
            AcidenteTrabalhoVO param = new AcidenteTrabalhoVO();
            AcidenteTrabalhoBS retorno = new AcidenteTrabalhoBS();
            DataTable dtRetorno = new DataTable();

            param.CodigoFuncionario = Convert.ToInt32(idUser);

            dtRetorno = retorno.SelecionarAcidenteTrabalho(param);

            //lblAcidenteTrabalho

            if (dtRetorno.Rows.Count > 0)
            {
                this.rptAcidenteTrabalho.DataSource = dtRetorno;
                this.rptAcidenteTrabalho.DataBind();
            }
            else
            {
                this.lblAcidenteTrabalho.Visible = true;
            }


        }

        protected List<DependenteVO> ListaDependentes(string idUser)
        {
            FuncionariosVO param = new FuncionariosVO();
            List<DependenteVO> listParam = new List<DependenteVO>();
            DependenteVO dependente;
            DependenteBS retorno = new DependenteBS();
            DataTable dtRetorno = new DataTable();

            param.CodigoFuncionario = Convert.ToInt32(idUser);

            dtRetorno = retorno.SelecionarDependentesDoFuncionario(param);

            int i = 0;
            while (i < dtRetorno.Rows.Count)
            {

                dependente = new DependenteVO();

                dependente.CodigoDependente = Convert.ToInt32(dtRetorno.Rows[i]["CODIGO_DEPENDENTE"].ToString());
                dependente.CodigoFuncionario = Convert.ToInt32(dtRetorno.Rows[i]["CODIGO_FUNCIONARIO"].ToString());
                dependente.Nome = dtRetorno.Rows[i]["NOME"].ToString();
                dependente.CodigoTipoParentesco = Convert.ToInt32(dtRetorno.Rows[i]["CODIGO_TIPO_PARENTESCO"].ToString());
                dependente.DataNascimento = Convert.ToDateTime(dtRetorno.Rows[i]["DATA_NASCIMENTO_STR"].ToString());
                dependente.DescricaoTipoParentesco = dtRetorno.Rows[i]["TIPO_PARENTESCO_DESC"].ToString();
                dependente.BeneficioVO = ListaBeneficios(Convert.ToInt32(dtRetorno.Rows[i]["CODIGO_DEPENDENTE"].ToString()));

                listParam.Add(dependente);

                i++;
            }

            return listParam;
        }


        protected List<BeneficioVO> ListaBeneficios(int idBeneficio)
        {
            List<BeneficioVO> listParam = new List<BeneficioVO>();
            BeneficioVO beneficio;
            BeneficioVO dependente = new BeneficioVO();
            BeneficioBS retorno = new BeneficioBS();
            DataTable dtRetorno = new DataTable();


            dependente.CodigoDependente = idBeneficio;

            dtRetorno = retorno.SelecionarBeneficios(dependente);

            int i = 0;
            while (i < dtRetorno.Rows.Count)
            {
                beneficio = new BeneficioVO();

                beneficio.DescricaoTipoBeneficio = dtRetorno.Rows[i]["DESCRICAO"].ToString();

                listParam.Add(beneficio);

                i++;
            }


            return listParam;
        }

        protected void CarregarFerias(string idUser)
        {

            FeriasVO param = new FeriasVO();
            FeriasBS retorno = new FeriasBS();
            DataTable dtRetorno = new DataTable();

            param.CodigoFuncionario = Convert.ToInt32(idUser);

            dtRetorno = retorno.SelecionarFerias(param);

            this.grdFerias.DataSource = dtRetorno;
            this.grdFerias.DataBind();
        }

        protected void CarregarDadosFuncionario(string idUser)
        {
            if (!string.IsNullOrWhiteSpace(idUser))
            {
                FuncionariosVO param = new FuncionariosVO();
                FuncionariosBS retorno = new FuncionariosBS();
                DataTable dtRetorno = new DataTable();

                param.CodigoFuncionario = Convert.ToInt32(idUser);

                dtRetorno = retorno.SelecionarFuncionario(param);

                int i = 0;
                while (i < dtRetorno.Rows.Count)
                {
                    this.lblNomeEmpresa.Text = dtRetorno.Rows[i]["EMPR_RAZAO_SOCIAL"].ToString();
                    this.lblAgenciaPIS.Text = dtRetorno.Rows[i]["BANCO_PIS_AGENCIA"].ToString();
                    this.lblAgenciaFGTS.Text = dtRetorno.Rows[i]["BANCO_FGTS_AGENCIA"].ToString();
                    this.lblAltura.Text = dtRetorno.Rows[i]["CARACTERISTICA_FUNC_ALTURA"].ToString();
                    this.lblBairroFuncionario.Text = dtRetorno.Rows[i]["DETL_END_BAIRRO"].ToString();
                    this.lblBairroPIS.Text = dtRetorno.Rows[i]["DETL_PIS_BAIRRO"].ToString();
                    this.lblDataCadastroPIS.Text = dtRetorno.Rows[i]["DOC_PIS_FUNC_DATA_CADASTRO_PIS_STR"].ToString();
                    //this.txtCarteira19.Text = dtRetorno.Rows[i]["DOC_EST_FUNC_NUMERO_CARTEIRA_19"].ToString();
                    this.lblNumeroCarteiraTrabalho.Text = dtRetorno.Rows[i]["DOC_FUNC_NUMERO_CARTEIRA_TRABALHO"].ToString();
                    this.lblCategoria.Text = dtRetorno.Rows[i]["DOC_FUNC_CATEGORIA"].ToString();
                    this.lblCarteiraSaude.Text = dtRetorno.Rows[i]["DOC_FUNC_NUMERO_CARTEIRA_SAUDE"].ToString();
                    //this.txtCBO.Text = dtRetorno.Rows[i]["DOC_EST_FUNC_NUMERO_CBO"].ToString();
                    this.lblCEP.Text = dtRetorno.Rows[i]["DETL_END_CEP"].ToString();
                    this.lblCEPPIS.Text = dtRetorno.Rows[i]["DETL_PIS_CEP"].ToString();
                    this.lblComplemento.Text = dtRetorno.Rows[i]["DETL_END_COMPLEMENTO"].ToString();
                    this.lblComplementoPIS.Text = dtRetorno.Rows[i]["DETL_PIS_COMPLEMENTO"].ToString();
                    this.lblContaPIS.Text = dtRetorno.Rows[i]["BANCO_PIS_CONTA"].ToString();
                    this.lblContaFGTS.Text = dtRetorno.Rows[i]["BANCO_FGTS_CONTA"].ToString();
                    this.lblNumeroCPF.Text = dtRetorno.Rows[i]["DOC_FUNC_NUMERO_CPF"].ToString();
                    this.lblDatadeNascimento.Text = dtRetorno.Rows[i]["FUNC_DATA_NASCIMENTO_STR"].ToString();
                    this.lblDataOpcaoFGTS.Text = dtRetorno.Rows[i]["DOC_FGTS_FUNC_DATA_OPCAO_STR"].ToString();
                    this.lblDataRetratacaoFGTS.Text = dtRetorno.Rows[i]["DOC_FGTS_FUNC_DATA_RETRATACAO_STR"].ToString();
                    this.lblDigitoPIS.Text = dtRetorno.Rows[i]["BANCO_PIS_DIGITO"].ToString();
                    this.lblDigitoFGTS.Text = dtRetorno.Rows[i]["BANCO_FGTS_DIGITO"].ToString();
                    this.lblLogradouroFuncionario.Text = dtRetorno.Rows[i]["DETL_END_LOGRADOURO"].ToString();
                    this.lblTLogradouroPIS.Text = dtRetorno.Rows[i]["DETL_PIS_LOGRADOURO"].ToString();
                    this.lblNomeConjuge.Text = dtRetorno.Rows[i]["FUNC_NOME_CONJUGE"].ToString();
                    this.lblNomeFuncionario.Text = dtRetorno.Rows[i]["FUNC_NOME_FUNCIONARIO"].ToString();
                    this.lblNomeMae.Text = dtRetorno.Rows[i]["FUNC_NOME_MAE"].ToString();
                    this.lblNomePai.Text = dtRetorno.Rows[i]["FUNC_NOME_PAI"].ToString();
                    this.lblNumeroCertificadoReservista.Text = dtRetorno.Rows[i]["DOC_FUNC_NUMERO_CERTIFICADO_RESERVISTA"].ToString();
                    this.lblNumeroFuncionario.Text = dtRetorno.Rows[i]["DETL_END_NUMERO"].ToString();
                    this.lblNumeroEnderecoPIS.Text = dtRetorno.Rows[i]["DETL_PIS_NUMERO"].ToString();
                    //this.lblNumeroMatricula.Text = dtRetorno.Rows[i]["FUNC_NUMERO_MATRICULA"].ToString();
                    //this.txtNumeroOrdemMatricula.Text = dtRetorno.Rows[i]["FUNC_NUMERO_ORDEM_MATRICULA"].ToString();
                    this.lblNumeroSerie.Text = dtRetorno.Rows[i]["DOC_FUNC_NUMERO_SERIE"].ToString();
                    this.lblPeso.Text = dtRetorno.Rows[i]["CARACTERISTICA_FUNC_PESO"].ToString();
                    this.lblQtdFilhos.Text = dtRetorno.Rows[i]["FUNC_QUANTOS_FILHOS"].ToString();
                    //this.txtRegistroGeral.Text = dtRetorno.Rows[i]["DOC_EST_FUNC_NUMERO_RESISTRO_GERAL"].ToString();
                    this.lblRG.Text = dtRetorno.Rows[i]["DOC_FUNC_NUMERO_IDENTIDADE"].ToString();
                    this.lblSinais.Text = dtRetorno.Rows[i]["CARACTERISTICA_FUNC_SINAIS"].ToString();
                    //this.txtSobNumero.Text = dtRetorno.Rows[i]["DOC_PIS_FUNC_SOB_NUMERO"].ToString();
                    this.lblTituloEleitor.Text = dtRetorno.Rows[i]["DOC_FUNC_TITULO_ELEITOR"].ToString();
                    this.lblEstadoCivil.Text = dtRetorno.Rows[i]["CIVIL_DESCRICAO"].ToString();
                    this.lblNacionalidade.Text = dtRetorno.Rows[i]["FUNC_LOCAL_NASCIMENTO_PAIS"].ToString();
                    this.lblTipoLogradouroFuncionario.Text = dtRetorno.Rows[i]["TIPO_LOG_FUNC_DESCRICAO"].ToString();
                    this.lblEstado.Text = dtRetorno.Rows[i]["EST_FUNC_DESCRICAO"].ToString();
                    this.lblCidade.Text = dtRetorno.Rows[i]["CID_FUNC_DESCRICAO"].ToString();

                    this.lblNacionalidadePai.Text = dtRetorno.Rows[i]["FUNC_NACIONALIDADE_PAI_PAIS"].ToString();
                    this.lblNacionalidadeMae.Text = dtRetorno.Rows[i]["FUNC_NACIONALIDADE_MAE_PAIS"].ToString();



                    this.lblEstadoCivil.Text = dtRetorno.Rows[i]["CIVIL_DESCRICAO"].ToString();



                    this.lblEstadoCivil.Text = dtRetorno.Rows[i]["CIVIL_DESCRICAO"].ToString();

                    this.lblCor.Text = dtRetorno.Rows[i]["COR_DESCRICAO"].ToString();
                    this.lblCabelo.Text = dtRetorno.Rows[i]["CABELO_DESCRICAO"].ToString();
                    this.lblOlho.Text = dtRetorno.Rows[i]["OLHO_DESCRICAO"].ToString();

                    this.lblNumeroPIS.Text = dtRetorno.Rows[i]["DETL_PIS_NUMERO"].ToString();

                    this.lblBancoPIS.Text = dtRetorno.Rows[i]["BANCO_PIS_DESCRICAO"].ToString();
                    this.lblCidadePIS.Text = dtRetorno.Rows[i]["CIDADE_PIS_DESCRICAO"].ToString();
                    this.lblEstadoPIS.Text = dtRetorno.Rows[i]["ESTADO_PIS_DESCRICAO"].ToString();

                    if (dtRetorno.Rows[i]["DOC_FGTS_FUNC_OPTANTE"].ToString() == "S")
                        this.lblOptanteFGTS.Text = "Sim";
                    else if (dtRetorno.Rows[i]["DOC_FGTS_FUNC_OPTANTE"].ToString() == "N")
                        this.lblOptanteFGTS.Text = "Não";

                    this.lblBancoFGTS.Text = dtRetorno.Rows[i]["BANCO_FGTS_DESCRICAO"].ToString();

                    /*
                     
                     
                     
                     
                      
                      
                      
                      
                     
                     */

                    i++;
                }

            }
        }

        private void CarregarCampoAdmissao(string idFuncionario)
        {
            DataTable dtRetorno = new DataTable();

            dtRetorno = SelecionarAdmissao();

            int i = 0;
            while (i < dtRetorno.Rows.Count)
            {

                this.lblComissoeAdmissao.Text = dtRetorno.Rows[i]["COMISSAO"].ToString();
                this.lblDataAdmissao.Text = dtRetorno.Rows[i]["DATA_ADMISSAO_STR"].ToString();
                this.lblDataregistroAdmissao.Text = dtRetorno.Rows[i]["DATA_REGISTRO_STR"].ToString();
                this.lblHorarioTrabalhoEntredaAdmissao.Text = dtRetorno.Rows[i]["HORARIO_TRABALHO_INICIO"].ToString();
                this.lblHorarioTrabalhoSaidaAdmissao.Text = dtRetorno.Rows[i]["HORARIO_TRABALHO_FIM"].ToString();
                this.lblIntervaloTravbalhoEntradaAdmissao.Text = dtRetorno.Rows[i]["INTERVALO_ALMOCO_INICIO"].ToString();
                this.lblIntervaloTrabalhoSaidaAdmissao.Text = dtRetorno.Rows[i]["INTERVALO_ALMOCO_FIM"].ToString();
                this.lblSalarioAdmissao.Text = dtRetorno.Rows[i]["SALARIO_INICIAL"].ToString();

                this.lblCargoAdmissao.Text = dtRetorno.Rows[i]["TIPO_CARGO"].ToString();
                this.lblSecaoAdmissao.Text = dtRetorno.Rows[i]["TIPO_SECAO"].ToString();
                this.lblTarefaAdmissao.Text = dtRetorno.Rows[i]["TIPO_TAREFA"].ToString();
                this.lblFormaPagamentoAdmissao.Text = dtRetorno.Rows[i]["TIPO_FORMA_PAGAMENTO"].ToString();

                int DescabsiSemanaEntradaAdmissao = Convert.ToInt32(dtRetorno.Rows[i]["DESCANSO_SEMANAL_INICIO"].ToString());
                switch (DescabsiSemanaEntradaAdmissao)
                {
                    case 1:
                        this.lblDescabsiSemanaEntradaAdmissao.Text = "Domingo";
                        break;
                    case 2:
                        this.lblDescabsiSemanaEntradaAdmissao.Text = "Segunda-Feira";
                        break;
                    case 3:
                        this.lblDescabsiSemanaEntradaAdmissao.Text = "Terça-feira";
                        break;
                    case 4:
                        this.lblDescabsiSemanaEntradaAdmissao.Text = "Quarta-Feira";
                        break;
                    case 5:
                        this.lblDescabsiSemanaEntradaAdmissao.Text = "Quinta-Feira";
                        break;
                    case 6:
                        this.lblDescabsiSemanaEntradaAdmissao.Text = "Sexta-Feira";
                        break;
                    case 7:
                        this.lblDescabsiSemanaEntradaAdmissao.Text = "Sabado";
                        break;
                }

                int DescansoSemanaSaidaAdmissao = Convert.ToInt32(dtRetorno.Rows[i]["DESCANSO_SEMANAL_FIM"].ToString());
                switch (DescansoSemanaSaidaAdmissao)
                {
                    case 1:
                        this.lblDescansoSemanaSaidaAdmissao.Text = "Domingo";
                        break;
                    case 2:
                        this.lblDescansoSemanaSaidaAdmissao.Text = "Segunda-Feira";
                        break;
                    case 3:
                        this.lblDescansoSemanaSaidaAdmissao.Text = "Terça-feira";
                        break;
                    case 4:
                        this.lblDescansoSemanaSaidaAdmissao.Text = "Quarta-Feira";
                        break;
                    case 5:
                        this.lblDescansoSemanaSaidaAdmissao.Text = "Quinta-Feira";
                        break;
                    case 6:
                        this.lblDescansoSemanaSaidaAdmissao.Text = "Sexta-Feira";
                        break;
                    case 7:
                        this.lblDescansoSemanaSaidaAdmissao.Text = "Sabado";
                        break;
                }

                i++;
            }
        }

        private void CarregarDemissao(string idFuncionario)
        {

            DataTable dtRetorno = new DataTable();

            dtRetorno = SelecionarDemissão();

            int i = 0;
            while (i < dtRetorno.Rows.Count)
            {

                //this.txtAgencia.Text = dtRetorno.Rows[i]["BANCO_PIS_AGENCIA"].ToString();
                this.lblComissaoDemissao.Text = dtRetorno.Rows[i]["COMISSAO"].ToString();
                this.lblDataDemissao.Text = dtRetorno.Rows[i]["DATA_DEMISSAO_STR"].ToString();
                this.lblDataRegistroDemissao.Text = dtRetorno.Rows[i]["DATA_REGISTRO_STR"].ToString();
                this.lblSalarioInicialDemissao.Text = dtRetorno.Rows[i]["SALARIO_INICIAL"].ToString();

                this.lblCargoDemissao.Text = dtRetorno.Rows[i]["TIPO_CARGO"].ToString();
                this.lblSecaoDemissao.Text = dtRetorno.Rows[i]["TIPO_SECAO"].ToString();
                this.lblTarefaDemissao.Text = dtRetorno.Rows[i]["TIPO_TAREFA"].ToString();
                this.lblFormaPagamentoDemissao.Text = dtRetorno.Rows[i]["TIPO_FORMA_PAGAMENTO"].ToString();

                i++;
            }

        }

        private void CarregarSindicato(string idFuncionario)
        {
            DataTable dtRetorno = new DataTable();

            dtRetorno = SelecionarSindicato();

            int i = 0;
            while (i < dtRetorno.Rows.Count)
            {

                this.lblPeriodoAnoSindicato.Text = dtRetorno.Rows[i]["PERIODO_ANO_STR"].ToString();
                this.lblSindicato.Text = dtRetorno.Rows[i]["NOME"].ToString();
                this.lblValorContribuicaoSindicato.Text = dtRetorno.Rows[i]["VALOR_RECOLHIDO"].ToString();


                i++;
            }

        }

        private DataTable SelecionarSindicato()
        {

            ContribuicaoSindicalBS objBS = new ContribuicaoSindicalBS();
            ContribuicaoSindicalVO dadosContribuicaoSindical = new ContribuicaoSindicalVO();

            int codigoFuncionario = 0;
            if (Int32.TryParse(Request.QueryString["idUser"], out codigoFuncionario))
            {
                dadosContribuicaoSindical.CodigoFuncionario = codigoFuncionario;
            }

            return objBS.SelecionarContribuicaoFuncionario(dadosContribuicaoSindical);
        }

        private DataTable SelecionarAdmissao()
        {
            DadosAdmissaoBS objBS = new DadosAdmissaoBS();
            DadosAdmissaoVO dadosAdmissao = new DadosAdmissaoVO();

            int codigoFuncionario = 0;
            if (Int32.TryParse(Request.QueryString["idUser"], out codigoFuncionario))
            {
                dadosAdmissao.CodigoFuncionario = codigoFuncionario;
            }

            return objBS.SelecionarAdmissao(dadosAdmissao);
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
            InfoTech2uControlHtmlUtil.IncludeHtmlGenericControl(this.Page, "js", pachJs, "jquery.dataTables.min.js");
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
            InfoTech2uControlHtmlUtil.IncludeHtmlGenericControl(this.Page, "js", pachJs, "responsive-tables.js");
            InfoTech2uControlHtmlUtil.IncludeHtmlGenericControl(this.Page, "js", pachJs, "custom.js");
            InfoTech2uControlHtmlUtil.IncludeHtmlGenericControl(this.Page, "js", pachJs, "CadastroFuncionario.js");

            InfoTech2uControlHtmlUtil.IncludeHtmlGenericControl(this.Page, "css", pachCss, "print.css", "print");

        }

        protected void rptDependentes_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                Repeater r = (Repeater)e.Item.FindControl("rptBeneficio");

                r.DataSource = DataBinder.Eval(e.Item.DataItem, "BeneficioVO");
                r.DataBind();
            }
        }

        protected void rptBeneficio_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                //Recuperando literal e atribuindo na propriedade text dele
                ((Literal)e.Item.FindControl("ltBeneficio")).Text = DataBinder.Eval(e.Item.DataItem, "DescricaoTipoBeneficio").ToString();
            }
        }

        protected void rptAcidenteTrabalho_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

        }
    }
}