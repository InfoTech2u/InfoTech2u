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

            UsuariosBS retorno = new UsuariosBS();
            UsuariosVO param = new UsuariosVO();
            List<UsuariosVO> listParam = new List<UsuariosVO>();

            param.CodigoUsuario = 1;

            listParam = retorno.SelecionarUsuarioLista(param);

            this.lblCodigoUsuario.Text = listParam[0].CodigoUsuario.ToString();
            this.lblNome.Text = listParam[0].Nome.ToString();
            this.lblMail.Text = listParam[0].Mail.ToString();
            this.lblLogin.Text = listParam[0].LoginUsuario.ToString();
            this.lblSenha.Text = listParam[0].Senha.ToString();
            this.lblDataCadastro.Text = listParam[0].DataCadastro.ToString();

            this.grdListaUsuario.DataSource = listParam;
            this.grdListaUsuario.DataBind();


        }

    }
}