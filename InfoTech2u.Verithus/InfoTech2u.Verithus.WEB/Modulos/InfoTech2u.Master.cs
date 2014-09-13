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
                Response.Redirect("../../Login.aspx", true);

            CarregarUrlAmigavel();
            

            this.lblNomeUsuario.Text = HttpContext.Current.Session["Nome"].ToString();
            this.lblMailUsuario.Text = HttpContext.Current.Session["Mail"].ToString();
        }

        protected void CarregarUrlAmigavel()
        {
            InfoTech2uControlHtmlUtil.AdicionarUrlAmigavel("Modulos/Dashboard/Dashboard-Gerente", "DashboardGerente.aspx", this.hlkDashboard);
            InfoTech2uControlHtmlUtil.AdicionarUrlAmigavel("Modulos/RecursosHumanos/Pesquisa-Empresa", "PesquisaEmpresa.aspx", this.hlkPesquisaEmpresa);
            InfoTech2uControlHtmlUtil.AdicionarUrlAmigavel("Modulos/RecursosHumanos/Pesquisa-Funcionário", "PesquisaFuncionario.aspx", this.hlkPesquisaFuncionario);
            InfoTech2uControlHtmlUtil.AdicionarUrlAmigavel("Modulos/RecursosHumanos/Pesquisa-Benefícios", "PesquisaBeneficios.aspx", this.hlkPesquisaBeneficios);
            InfoTech2uControlHtmlUtil.AdicionarUrlAmigavel("Modulos/RecursosHumanos/Cadastro-Funcionario", "ManterFuncionario.aspx", this.hlkManterUsuario);

        }

    }
}