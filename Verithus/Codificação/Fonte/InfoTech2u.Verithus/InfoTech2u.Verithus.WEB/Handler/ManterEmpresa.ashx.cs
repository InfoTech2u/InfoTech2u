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
    /// Summary description for ManterEmpresa
    /// </summary>
    public class ManterEmpresa : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            if (context.Request.QueryString["Metodo"] == "SelecionarEmpresa")
            {
                var retorno = SelecionarEmpresa(context);

                context.Response.Write(retorno.Serializer());
            }
            else if (context.Request.QueryString["Metodo"] == "Gravar")
            {
                context.Response.Write(GravarEmpresa(context).Serializer());
            }
            else if (context.Request.QueryString["Metodo"] == "ListaEmpresa")
            {
                context.Response.Write(SelecionarEmpresa(context).Serializer());
            }
            else if (context.Request.QueryString["Metodo"] == "Excluir")
            {
                context.Response.Write(ExcluirEmpresa(context).Serializer());
            }
        }

        private DataTable ExcluirEmpresa(HttpContext context)
        {
            EmpresaBS objBS = new EmpresaBS();
            EmpresaVO dadosEmpresa = new EmpresaVO();

            int codigoEmpresa = 0;
            if (Int32.TryParse(context.Request.QueryString["CodigoEmpresa"], out codigoEmpresa))
            {
                dadosEmpresa.CodigoEmpresa = codigoEmpresa;
            }

            dadosEmpresa.NomeFantasia = context.Request.QueryString["NomeFantasia"].ToString();
            dadosEmpresa.RazaoSocial = context.Request.QueryString["RazaoSocial"].ToString();
            dadosEmpresa.CNJP = context.Request.QueryString["CNPJ"].ToString();
            dadosEmpresa.InscricaoEstadual = context.Request.QueryString["InscricaoEstadual"].ToString();

            int codigoStatus = 0;
            if (Int32.TryParse(context.Request.QueryString["CodigoStatus"], out codigoStatus))
            {
                dadosEmpresa.CodigoStatus = codigoStatus;
            }

            dadosEmpresa.CodigoUsuarioAlteracao = Convert.ToInt32(context.Session["CodigoUsuario"].ToString());

            return objBS.ExcluirEmpresa(dadosEmpresa);
        }

        private DataTable SelecionarEmpresa(HttpContext context)
        {
            EmpresaBS objBS = new EmpresaBS();
            EmpresaVO dadosEmpresa = new EmpresaVO();

            int codigoEmpresa = 0;
            if (Int32.TryParse(context.Request.QueryString["CodigoEmpresa"], out codigoEmpresa))
            {
                dadosEmpresa.CodigoEmpresa = codigoEmpresa;
            }

            dadosEmpresa.NomeFantasia = context.Request.QueryString["NomeFantasia"].ToString();
            dadosEmpresa.RazaoSocial = context.Request.QueryString["RazaoSocial"].ToString();
            dadosEmpresa.CNJP = context.Request.QueryString["CNPJ"].ToString();
            dadosEmpresa.InscricaoEstadual = context.Request.QueryString["InscricaoEstadual"].ToString();

            int codigoStatus = 0;
            if (Int32.TryParse(context.Request.QueryString["CodigoStatus"], out codigoStatus))
            {
                dadosEmpresa.CodigoStatus = codigoStatus;
            }

            return objBS.SelecionarEmpresa(dadosEmpresa);
        }

        private DataTable GravarEmpresa(HttpContext context)
        {
            EmpresaBS objBS = new EmpresaBS();
            EmpresaVO dadosEmpresa = new EmpresaVO();

            int codigoEmpresa = 0;
            if (Int32.TryParse(context.Request.QueryString["CodigoEmpresa"], out codigoEmpresa))
            {
                dadosEmpresa.CodigoEmpresa = codigoEmpresa;
            }

            dadosEmpresa.NomeFantasia = context.Request.QueryString["NomeFantasia"].ToString();
            dadosEmpresa.RazaoSocial = context.Request.QueryString["RazaoSocial"].ToString();
            dadosEmpresa.CNJP = context.Request.QueryString["CNPJ"].ToString();
            dadosEmpresa.InscricaoEstadual = context.Request.QueryString["InscricaoEstadual"].ToString();

            int codigoStatus = 0;
            if (Int32.TryParse(context.Request.QueryString["CodigoStatus"], out codigoStatus))
            {
                dadosEmpresa.CodigoStatus = codigoStatus;
            }

            if (dadosEmpresa.CodigoEmpresa == 0)
            {
                int codigoUsuarioCadastro = 0;
                if (Int32.TryParse(context.Request.QueryString["CodigoUsuarioCadastro"], out codigoUsuarioCadastro))
                {
                    dadosEmpresa.CodigoUsuarioCadastro = Convert.ToInt32(context.Session["CodigoUsuario"].ToString());
                }

                return objBS.IncluirEmpresa(dadosEmpresa);
            }
            else
            {

                int codigoUsuarioAlteracao = 0;
                if (Int32.TryParse(context.Request.QueryString["CodigoUsuarioAlteracao"], out codigoUsuarioAlteracao))
                {
                    dadosEmpresa.CodigoUsuarioAlteracao = Convert.ToInt32(context.Session["CodigoUsuario"].ToString());
                }

                return objBS.AlterarEmpresa(dadosEmpresa);
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