using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using InfoTech2u.Verithus.Util;


namespace InfoTech2u.Verithus.WEB
{
    public partial class InfoTech2u : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoginUsuario"] == null)
                Response.Redirect("~/Login.aspx", true);

           // CarregarUrlAmigavel();
            

            this.lblNomeUsuario.Text = HttpContext.Current.Session["Nome"].ToString();
            this.lblMailUsuario.Text = HttpContext.Current.Session["Mail"].ToString();
        }

        protected void CarregarUrlAmigavel()
        {
            //Paginas de Dashboard
            //InfoTech2uControlHtmlUtil.AdicionarUrlAmigavel("Modulos/Dashboard/Dashboard-Gerente", "DashboardGerente.aspx", this.hlkDashboard);
            

            InfoTech2uControlHtmlUtil.AdicionarUrlAmigavel("Modulos/RecursosHumanos/Pesquisa-Funcionário", "PesquisaFuncionario.aspx", this.hlkPesquisaFuncionario);
            InfoTech2uControlHtmlUtil.AdicionarUrlAmigavel("Modulos/RecursosHumanos/Cadastro-Funcionario", "ManterFuncionario.aspx", this.hlkManterUsuario);
            InfoTech2uControlHtmlUtil.AdicionarUrlAmigavel("Modulos/RecursosHumanos/Pesquisa-Empresa", "PesquisaEmpresa.aspx", this.hlkPesquisaEmpresa);
            InfoTech2uControlHtmlUtil.AdicionarUrlAmigavel("Modulos/RecursosHumanos/Cadastro-Empresa", "ManterEmpresa.aspx", this.hlkManterEmpresa);
            //InfoTech2uControlHtmlUtil.AdicionarUrlAmigavel("Modulos/RecursosHumanos/Pesquisa-Benefícios", "PesquisaBeneficios.aspx", this.hlkPesquisaBeneficios);
            

            //Paginas Filhas de Funcionario
            
            InfoTech2uControlHtmlUtil.AdicionarUrlAmigavel("Modulos/RecursosHumanos/Manutenção-Demissão", "ManterDemissao.aspx", this.hlkManterUsuario);
            InfoTech2uControlHtmlUtil.AdicionarUrlAmigavel("Modulos/RecursosHumanos/Manutenção-Admissão", "ManterAdmissao.aspx", this.hlkManterUsuario);
            InfoTech2uControlHtmlUtil.AdicionarUrlAmigavel("Modulos/RecursosHumanos/Manutenção-Beneficios", "ManterBeneficios.aspx", this.hlkManterUsuario);
            InfoTech2uControlHtmlUtil.AdicionarUrlAmigavel("Modulos/RecursosHumanos/Manutenção-Contribuição-Sindical", "ManterContribuicaoSindicaol.aspx", this.hlkManterUsuario);

            //Link de Paginas de Dominio de RH
            InfoTech2uControlHtmlUtil.AdicionarUrlAmigavel("Modulos/RecursosHumanos/Manutenção-Tipo-Beneficio", "ManterTipoBeneficio.aspx", this.hlkTipoBeneficio);
            InfoTech2uControlHtmlUtil.AdicionarUrlAmigavel("Modulos/RecursosHumanos/Manutenção-Tarefa", "ManterTarefa.aspx", this.hlkTipoTarefa);
            InfoTech2uControlHtmlUtil.AdicionarUrlAmigavel("Modulos/RecursosHumanos/Manutenção-Sindicato", "ManterSindicato.aspx", this.hlkSindicato);
            InfoTech2uControlHtmlUtil.AdicionarUrlAmigavel("Modulos/RecursosHumanos/Manutenção-Seção", "ManterSecao.aspx", this.hlkSecao);
            InfoTech2uControlHtmlUtil.AdicionarUrlAmigavel("Modulos/RecursosHumanos/Manutenção-Cargo", "ManterCargo.aspx", this.hlkCargo);
            InfoTech2uControlHtmlUtil.AdicionarUrlAmigavel("Modulos/RecursosHumanos/Manutenção-Forma-Pagamento", "ManterFormaDePagamento.aspx", this.hlkFormaPagamento);

            //Link de paginas Dominio do Sistema



        }

    }
}