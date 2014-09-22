using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InfoTech2u.Verithus.Util;
using System.Data;
using InfoTech2u.Verithus.BS;
using InfoTech2u.Verithus.VO;

namespace InfoTech2u.Verithus.WEB.Handler
{
    /// <summary>
    /// Summary description for ManterUsuario
    /// </summary>
    public class ManterUsuario : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            if (context.Request.QueryString["Metodo"] == "VerificarLogin")
            {
                var retorno = VerificarLogin(context);

                context.Response.Write(retorno.Serializer());
            }
            else if (context.Request.QueryString["Metodo"] == "Incluir")
            {
                context.Response.Write(IncluirUsuario(context).Serializer());
            }
            else if (context.Request.QueryString["Metodo"] == "Lista")
            {
                context.Response.Write(SelecionarUsuario(context).Serializer());
            }
            else if (context.Request.QueryString["Metodo"] == "Excluir")
            {
                context.Response.Write(ExcluirUsuario(context));
            }
            else if (context.Request.QueryString["Metodo"] == "Alterar")
            {
                context.Response.Write(AlterarUsuario(context).Serializer());
            }
        }

        private DataTable SelecionarUsuario(HttpContext context)
        {
            UsuariosBS objBS = new UsuariosBS();
            UsuariosVO usuario = new UsuariosVO();

            int codigoUsuario = 0;
            if (Int32.TryParse(context.Request.QueryString["CodigoUsuario"], out codigoUsuario))
            {
                usuario.CodigoUsuario = codigoUsuario;
            }

            return objBS.SelecionarUsuario(usuario);
        }

        private DataTable VerificarLogin(HttpContext context)
        {
            InfoTech2uCryptographyUtil oCrypt = new InfoTech2uCryptographyUtil(EncryptionAlgorithm.TripleDes);
            UsuariosBS objBS = new UsuariosBS();
            var login = oCrypt.Encrypt(context.Request.QueryString["Login"].ToLower().Trim());
            return objBS.VerificarLogin(login);

        }

        private DataTable IncluirUsuario(HttpContext context)
        {
            InfoTech2uCryptographyUtil oCrypt = new InfoTech2uCryptographyUtil(EncryptionAlgorithm.TripleDes);
            UsuariosBS objBS = new UsuariosBS();
            UsuariosVO usuario = new UsuariosVO();

            usuario.Nome = context.Request.QueryString["Nome"].ToString();
            usuario.Mail = context.Request.QueryString["Email"].ToString();
            usuario.LoginUsuario = oCrypt.Encrypt(context.Request.QueryString["Login"].ToLower().Trim());
            usuario.Senha = oCrypt.Encrypt(context.Request.QueryString["Senha"].ToLower().Trim());
            usuario.CodigoTipoAcesso = Convert.ToInt32(context.Request.QueryString["CodigoTipoAcesso"]);

            usuario.CodigoUsuarioCadastro = null;
            usuario.DataCadastro = DateTime.Now;
            usuario.CodigoUsuarioAlteracao = null;
            usuario.DataAlteracao = DateTime.Now; ;
            usuario.CodigoStatus = 1;
            return objBS.IncluirUsuario(usuario);
        }

        private DataTable AlterarUsuario(HttpContext context)
        {
            UsuariosBS objBS = new UsuariosBS();
            UsuariosVO usuario = new UsuariosVO();

            int codigoUsuario = 0;
            if (Int32.TryParse(context.Request.QueryString["CodigoUsuario"], out codigoUsuario))
            {
                usuario.CodigoUsuario = codigoUsuario;
                usuario.Nome = context.Request.QueryString["Nome"];
                usuario.Mail = context.Request.QueryString["Email"];
                usuario.CodigoTipoAcesso = Convert.ToInt32(context.Request.QueryString["CodigoTipoAcesso"]);
                usuario.CodigoUsuarioAlteracao = null;
                usuario.DataAlteracao = DateTime.Now;
                return objBS.AlterarUsuario(usuario);
            }
            else
                return new DataTable();
        }

        private bool ExcluirUsuario(HttpContext context)
        {
            UsuariosBS objBS = new UsuariosBS();
            UsuariosVO usuario = new UsuariosVO();
            int codigoUsuario = 0;
            if (Int32.TryParse(context.Request.QueryString["CodigoUsuario"], out codigoUsuario))
            {
                usuario.CodigoUsuario = codigoUsuario;
                return objBS.ExcluirUsuario(usuario);
            }
            else
                return false;
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