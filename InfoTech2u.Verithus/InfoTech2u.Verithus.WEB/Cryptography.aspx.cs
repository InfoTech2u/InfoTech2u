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
    public partial class Cryptography : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEncrypt_Click(object sender, EventArgs e)
        {
            InfoTech2uCryptographyUtil oCrypt = new InfoTech2uCryptographyUtil(EncryptionAlgorithm.TripleDes);

            string xmlDatabase = "";

            

            if (!String.IsNullOrWhiteSpace(this.txtdatabase.Text) || !String.IsNullOrEmpty(this.txtdatabase.Text))
                this.lbldatabaseResultado.Text = oCrypt.Encrypt(this.txtdatabase.Text);

            if (!String.IsNullOrWhiteSpace(this.txtserver.Text) || !String.IsNullOrEmpty(this.txtserver.Text))
                this.lblserverResultado.Text = oCrypt.Encrypt(this.txtserver.Text);

            if (!String.IsNullOrWhiteSpace(this.txtuser.Text) || !String.IsNullOrEmpty(this.txtuser.Text))
                this.lbluserResultado.Text = oCrypt.Encrypt(this.txtuser.Text);

            if (!String.IsNullOrWhiteSpace(this.txtpassword.Text) || !String.IsNullOrEmpty(this.txtpassword.Text))
                this.lblpasswordResultado.Text = oCrypt.Encrypt(this.txtpassword.Text);

            xmlDatabase = xmlDatabase + "<dataset>";
            xmlDatabase = xmlDatabase + "<ConnectionString>";
            xmlDatabase = xmlDatabase + "<database>" + oCrypt.Encrypt(this.txtdatabase.Text) + "</database>";
            xmlDatabase = xmlDatabase + "<server>" + oCrypt.Encrypt(this.txtserver.Text) + "</server>";
            xmlDatabase = xmlDatabase + "<port></port>";
            xmlDatabase = xmlDatabase + "<user>" + oCrypt.Encrypt(this.txtuser.Text) + "</user>";
            xmlDatabase = xmlDatabase + "<password>" + oCrypt.Encrypt(this.txtpassword.Text) + "</password>";
            xmlDatabase = xmlDatabase + "<winapli></winapli>";
            xmlDatabase = xmlDatabase + "</ConnectionString>";
            xmlDatabase = xmlDatabase + "</dataset>";

            this.txtXmlDatabase.Text = xmlDatabase;


        }

        protected void btnDecrypt_Click(object sender, EventArgs e)
        {
            InfoTech2uCryptographyUtil oCrypt = new InfoTech2uCryptographyUtil(EncryptionAlgorithm.TripleDes);

            if (!String.IsNullOrWhiteSpace(this.txtdatabase.Text) || !String.IsNullOrEmpty(this.txtdatabase.Text))
                this.lbldatabaseResultado.Text = oCrypt.Decrypt(this.txtdatabase.Text);

            if (!String.IsNullOrWhiteSpace(this.txtserver.Text) || !String.IsNullOrEmpty(this.txtserver.Text))
                this.lblserverResultado.Text = oCrypt.Decrypt(this.txtserver.Text);

            if (!String.IsNullOrWhiteSpace(this.txtuser.Text) || !String.IsNullOrEmpty(this.txtuser.Text))
                this.lbluserResultado.Text = oCrypt.Decrypt(this.txtuser.Text);

            if (!String.IsNullOrWhiteSpace(this.txtpassword.Text) || !String.IsNullOrEmpty(this.txtpassword.Text))
                this.lblpasswordResultado.Text = oCrypt.Decrypt(this.txtpassword.Text);

        }

        protected void btnLimpar_Click(object sender, EventArgs e)
        {
            this.lbldatabaseResultado.Text = "";
            this.lblserverResultado.Text = "";
            this.lbluserResultado.Text = "";
            this.lblpasswordResultado.Text = "";

            this.txtdatabase.Text = "";
            this.txtserver.Text = "";
            this.txtuser.Text = "";
            this.txtpassword.Text = "";
        }
    }
}