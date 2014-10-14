using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InfoTech2u.Verithus.VO;
using InfoTech2u.Verithus.BS;
using InfoTech2u.Verithus.Util;

namespace InfoTech2u.Verithus.WEB
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoginUsuario"] == null)
                Response.Redirect("~/Login.aspx", true);
            
            /*
            UsuariosVO param = new UsuariosVO();

            param.CodigoUsuario = Convert.ToInt32(HttpContext.Current.Session["CodigoUsuario"].ToString());
            param.Nome = HttpContext.Current.Session["Nome"].ToString();
            param.Mail = HttpContext.Current.Session["Mail"].ToString();
            param.LoginUsuario = HttpContext.Current.Session["LoginUsuario"].ToString();
            param.Senha = HttpContext.Current.Session["Senha"].ToString();
            param.CodigoUsuario = Convert.ToInt32(HttpContext.Current.Session["CodigoTipoAcesso"].ToString());
            param.CodigoUsuario = Convert.ToInt32(HttpContext.Current.Session["CodigoStatus"].ToString());

            this.lblCodigoUsuario.Text = param.CodigoUsuario.ToString();
            this.lblNome.Text = param.Nome.ToString();
            this.lblMail.Text = param.Mail.ToString();
            this.lblLogin.Text = param.LoginUsuario.ToString();
            this.lblSenha.Text = param.Senha.ToString();
            */

            




        }

    }
}