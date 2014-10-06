using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InfoTech2u.Verithus.WEB
{
    public partial class Logoff : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            limparSessao();
        }

        private void limparSessao()
        {

            HttpContext.Current.Session["CodigoUsuario"] = null;
            HttpContext.Current.Session["Nome"] = null;
            HttpContext.Current.Session["LoginUsuario"] = null;
            HttpContext.Current.Session["Senha"] = null;
            HttpContext.Current.Session["CodigoTipoAcesso"] = null;
            HttpContext.Current.Session["CodigoStatus"] = null;

            Response.Redirect("Login.aspx", true);

        }
    }
}