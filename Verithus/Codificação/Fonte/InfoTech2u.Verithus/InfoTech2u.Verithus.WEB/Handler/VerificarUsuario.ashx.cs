using System;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.UI;
using InfoTech2u.Verithus.VO;
using InfoTech2u.Verithus.BS;
using System.Web.Script.Serialization;
using System.Collections.Generic;
using System.Xml;
using System.Data;
using Newtonsoft.Json;
using InfoTech2u.Verithus.Util;

namespace InfoTech2u.Verithus.WEB.Handler
{
    /// <summary>
    /// Summary description for VerificarUsuario
    /// </summary>
    public class VerificarUsuario : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            try
            {
                InfoTech2uCryptographyUtil oCrypt = new InfoTech2uCryptographyUtil(EncryptionAlgorithm.TripleDes);
                DataTable dtRetorno = new DataTable();
                UsuariosVO param = new UsuariosVO();
                UsuariosVO usuarioretorno = new UsuariosVO();
                UsuariosBS retorno = new UsuariosBS();

                string usuarioGet = oCrypt.Encrypt(context.Request.QueryString["usuario"].ToString());
                string senhaGet = oCrypt.Encrypt(context.Request.QueryString["senha"].ToString());
                string usuarioBanco = "";
                string senhaBanco = "";

                if (!String.IsNullOrEmpty(usuarioGet))
                    param.LoginUsuario = usuarioGet;
                else
                    param.LoginUsuario = null;

                if (!String.IsNullOrEmpty(senhaGet))
                    param.Senha = senhaGet;
                else
                    param.Senha = null;

                dtRetorno = retorno.VerificarUsuario(param);

                int i = 0;
                while (i < dtRetorno.Rows.Count)
                {
                    usuarioBanco = string.IsNullOrWhiteSpace(dtRetorno.Rows[i]["LOGIN_USUARIO"].ToString()) ? null : dtRetorno.Rows[i]["LOGIN_USUARIO"].ToString();
                    senhaBanco = string.IsNullOrWhiteSpace(dtRetorno.Rows[i]["SENHA"].ToString()) ? null : dtRetorno.Rows[i]["SENHA"].ToString();

                    usuarioretorno.CodigoUsuario = Convert.ToInt32(dtRetorno.Rows[i]["CODIGO_USUARIO"].ToString());
                    usuarioretorno.Nome = string.IsNullOrWhiteSpace(dtRetorno.Rows[i]["NOME"].ToString()) ? null : dtRetorno.Rows[i]["NOME"].ToString();
                    usuarioretorno.Mail = string.IsNullOrWhiteSpace(dtRetorno.Rows[i]["MAIL"].ToString()) ? null : dtRetorno.Rows[i]["MAIL"].ToString();
                    usuarioretorno.LoginUsuario = string.IsNullOrWhiteSpace(dtRetorno.Rows[i]["LOGIN_USUARIO"].ToString()) ? null : dtRetorno.Rows[i]["LOGIN_USUARIO"].ToString();
                    usuarioretorno.Senha = string.IsNullOrWhiteSpace(dtRetorno.Rows[i]["SENHA"].ToString()) ? null : dtRetorno.Rows[i]["SENHA"].ToString();
                    usuarioretorno.CodigoTipoAcesso = Convert.ToInt32(dtRetorno.Rows[i]["CODIGO_TIPO_ACESSO"].ToString());
                    usuarioretorno.CodigoStatus = Convert.ToInt32(dtRetorno.Rows[i]["CODIGO_STATUS"].ToString());

                    context.Session["CodigoUsuario"] = usuarioretorno.CodigoUsuario.ToString();
                    context.Session["Nome"] = usuarioretorno.Nome.ToString();
                    context.Session["Mail"] = usuarioretorno.Mail.ToString();
                    context.Session["LoginUsuario"] = usuarioretorno.LoginUsuario.ToString();
                    context.Session["Senha"] = usuarioretorno.Senha.ToString();
                    context.Session["CodigoTipoAcesso"] = usuarioretorno.CodigoTipoAcesso.ToString();
                    context.Session["CodigoStatus"] = usuarioretorno.CodigoStatus.ToString();

                    i++;
                }


                if(usuarioGet == usuarioBanco && senhaGet == senhaBanco)
                    context.Response.Write(dtRetorno.DataTableSerializer());
                else
                     context.Response.Write("Erro");



            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}