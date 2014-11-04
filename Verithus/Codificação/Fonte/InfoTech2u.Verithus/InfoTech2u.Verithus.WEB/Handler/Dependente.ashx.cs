using InfoTech2u.Verithus.BS;
using InfoTech2u.Verithus.VO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using InfoTech2u.Verithus.Util;
using System.Data;

namespace InfoTech2u.Verithus.WEB.Handler
{
    /// <summary>
    /// Summary description for Dependente
    /// </summary>
    public class Dependente : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            if (context.Session["CodigoUsuario"] == null)
            {
                context.Response.ContentType = "application/json; charset=utf-8";
                context.Response.Write("{ \"Msg\": \"Sessão expirada. Você será redirecionado para tela de login.\"}");
                context.Response.End();
                return;
            }

            if (context.Request.QueryString["Metodo"] == "Listar")
            {
                if (!String.IsNullOrEmpty(context.Request.QueryString["CodigoFuncionario"]))
                {
                    int codigoFuncionario = Convert.ToInt32(context.Request.QueryString["CodigoFuncionario"].ToString());

                    context.Response.Write(ListarDependentes(codigoFuncionario).Serializer());
                }
            }
            else if (context.Request.QueryString["Metodo"] == "Incluir")
            {
                context.Response.Write(IncluirDependente(context).Serializer());
            }
            else if (context.Request.QueryString["Metodo"] == "Selecionar")
            {
                context.Response.Write(SelecionarDependente(context).Serializer());
            }
            else if (context.Request.QueryString["Metodo"] == "Alterar")
            {
                context.Response.Write(AlterarDependente(context).Serializer());
            }
            else if (context.Request.QueryString["Metodo"] == "Excluir")
            {
                context.Response.Write(ExcluirDependente(context).Serializer());
            }
        }

        private bool ExcluirDependente(HttpContext context)
        {
            DependenteBS objBS = new DependenteBS();
            DependenteVO param = new DependenteVO();


            param.BeneficioVO = new List<BeneficioVO>();
            param.CodigoDependente = Convert.ToInt32(context.Request.QueryString["CodigoDependente"]);

            param.CodigoUsuarioAlteracao = Convert.ToInt32(context.Session["CodigoUsuario"].ToString());

            return objBS.ExcluirDependente(param);
        }

        private DataTable AlterarDependente(HttpContext context)
        {
            DependenteBS objBS = new DependenteBS();
            DependenteVO param = new DependenteVO();
            String strBeneficio;
            param.BeneficioVO = new List<BeneficioVO>();

            param.CodigoDependente = Convert.ToInt32(context.Request.QueryString["CodigoDependente"]);
            param.CodigoTipoParentesco = Convert.ToInt32(context.Request.QueryString["TipoParentesco"]);
            param.DataNascimento = Convert.ToDateTime(context.Request.QueryString["DataNascimento"]);
            param.Nome = context.Request.QueryString["Nome"].ToString();
            strBeneficio = context.Request.QueryString["Beneficios"].ToString();


            if (!String.IsNullOrEmpty(strBeneficio))
            {
                foreach (var item in strBeneficio.Split('|'))
                {
                    if (!String.IsNullOrEmpty(item))
                    {
                        param.BeneficioVO.Add(new BeneficioVO()
                        {
                            TipoBeneficio = new TipoBeneficioVO()
                            {
                                CodigoTipoBeneficio = Convert.ToInt32(item)
                            }
                        });
                    }
                }
            }

            param.CodigoUsuarioAlteracao = Convert.ToInt32(context.Session["CodigoUsuario"].ToString());
            param.DataAlteracao = DateTime.Now;
            param.CodigoStatus = null;

            return objBS.AlterarDependente(param);
        }

        private DataTable SelecionarDependente(HttpContext context)
        {
            DependenteBS objBS = new DependenteBS();
            DependenteVO param = new DependenteVO();
            param.CodigoDependente = Convert.ToInt32(context.Request.QueryString["CodigoDependente"]);

            return objBS.SelecionarDependente(param);
        }

        private DataTable IncluirDependente(HttpContext context)
        {
            DependenteBS objBS = new DependenteBS();
            DependenteVO param = new DependenteVO();
            String strBeneficio;
            param.BeneficioVO = new List<BeneficioVO>();

            param.CodigoFuncionario = Convert.ToInt32(context.Request.QueryString["CodigoFuncionario"]);
            param.CodigoTipoParentesco = Convert.ToInt32(context.Request.QueryString["TipoParentesco"]);
            param.DataNascimento = Convert.ToDateTime(context.Request.QueryString["DataNascimento"]);
            param.Nome = context.Request.QueryString["Nome"].ToString();
            strBeneficio = context.Request.QueryString["Beneficios"].ToString();


            if (!String.IsNullOrEmpty(strBeneficio))
            {
                foreach (var item in strBeneficio.Split('|'))
                {
                    if (!String.IsNullOrEmpty(item))
                    {
                        param.BeneficioVO.Add(new BeneficioVO()
                        {
                            TipoBeneficio = new TipoBeneficioVO()
                            {
                                CodigoTipoBeneficio = Convert.ToInt32(item)
                            }
                        });
                    }
                }
            }

            param.CodigoUsuarioAlteracao = null;
            param.DataAlteracao = DateTime.Now;
            param.CodigoUsuarioCadastro = Convert.ToInt32(context.Session["CodigoUsuario"].ToString());
            param.DataCadastro = DateTime.Now;
            param.CodigoStatus = null;
            
            return objBS.IncluirDependente(param);
        }

        private DataTable ListarDependentes(int codigoFuncionario)
        { 
            DependenteBS objBS = new DependenteBS();
            FuncionariosVO param = new FuncionariosVO();
            param.CodigoFuncionario = codigoFuncionario;

            return objBS.SelecionarDependentesDoFuncionario(param);
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