using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InfoTech2u.Verithus.Util;
using InfoTech2u.Verithus.VO;
using System.Data;
using InfoTech2u.Verithus.BS;

namespace InfoTech2u.Verithus.WEB.Handler
{
    /// <summary>
    /// Summary description for ManterContribuicaoSindical
    /// </summary>
    public class ManterContribuicaoSindical : IHttpHandler, System.Web.SessionState.IRequiresSessionState
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

            if (context.Request.QueryString["Metodo"] == "SelecionarContribuicaoFuncionario")
            {
                if (!String.IsNullOrWhiteSpace(context.Request.QueryString["CodigoFuncionario"]))
                { 
                    var retorno = SelecionarContribuicaoFuncionario(Convert.ToInt32(context.Request.QueryString["CodigoFuncionario"]));                

                    context.Response.Write(retorno.Serializer());
                }
            }
            else if (context.Request.QueryString["Metodo"] == "Incluir")
            {
                context.Response.Write(IncluirContribuicaoSindical(context).Serializer());
            }
            else if (context.Request.QueryString["Metodo"] == "Alterar")
            {
                context.Response.Write(AlterarContribuicaoSindical(context).Serializer());
            }
            else if (context.Request.QueryString["Metodo"] == "Excluir")
            {
                context.Response.Write(ExcluirContribuicaoSindical(context));
            }
        }

        private DataTable SelecionarContribuicaoFuncionario(int idFuncionario)
        {
            ContribuicaoSindicalBS objBS = null;
            ContribuicaoSindicalVO contribuicao = null;
            try
            {
                objBS = new ContribuicaoSindicalBS();
                contribuicao = new ContribuicaoSindicalVO();
                contribuicao.CodigoFuncionario = idFuncionario;

                return objBS.SelecionarContribuicaoFuncionario(contribuicao);

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                objBS = null;
                contribuicao = null;
            }
        }

        private DataTable IncluirContribuicaoSindical(HttpContext context)
        {
            ContribuicaoSindicalBS objBS = null;
            ContribuicaoSindicalVO contribuicao = null;

            try
            {
                objBS = new ContribuicaoSindicalBS();
                contribuicao = new ContribuicaoSindicalVO();

                contribuicao.CodigoFuncionario = Convert.ToInt32(context.Request.QueryString["CodigoFuncionario"]);
                contribuicao.PeriodoAno = Convert.ToDateTime(context.Request.QueryString["PeriodoAno"]);
                contribuicao.CodigoSindicato = Convert.ToInt32(context.Request.QueryString["CodigoSindicato"]);
                contribuicao.ValorRecolhido = context.Request.QueryString["ValorRecolhido"];
                contribuicao.CodigoStatus = null;
                contribuicao.CodigoUsuarioAlteracao = null;
                contribuicao.CodigoUsuarioCadastro = Convert.ToInt32(context.Session["CodigoUsuario"].ToString());
                contribuicao.DataAlteracao = null;
                contribuicao.DataCadastro = DateTime.Now;

                return objBS.IncluirContribuicaoSindical(contribuicao);
                
            }
            catch (Exception)
            {
                
                throw;
            }
            finally
            {
                objBS = null;
                contribuicao = null;
            }
        }

        public DataTable AlterarContribuicaoSindical(HttpContext context)
        {
            ContribuicaoSindicalBS objBS = null;
            ContribuicaoSindicalVO contribuicao = null;

            try
            {
                objBS = new ContribuicaoSindicalBS();
                contribuicao = new ContribuicaoSindicalVO();

                contribuicao.CodigoContribuicaoSindical = Convert.ToInt32(context.Request.QueryString["CodigoContribuicaoSindical"]);
                contribuicao.PeriodoAno = Convert.ToDateTime(context.Request.QueryString["PeriodoAno"]);
                contribuicao.CodigoSindicato = Convert.ToInt32(context.Request.QueryString["CodigoSindicato"]);
                contribuicao.ValorRecolhido = context.Request.QueryString["ValorRecolhido"];
                contribuicao.CodigoStatus = null;
                contribuicao.CodigoUsuarioAlteracao = Convert.ToInt32(context.Session["CodigoUsuario"].ToString());
                contribuicao.DataAlteracao = DateTime.Now;

                return objBS.AlterarContribuicaoSindical(contribuicao);

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                objBS = null;
                contribuicao = null;
            }
        }

        private bool ExcluirContribuicaoSindical(HttpContext context)
        {
            ContribuicaoSindicalBS objBS = null;
            ContribuicaoSindicalVO contribuicao = null;

            try
            {
                objBS = new ContribuicaoSindicalBS();
                contribuicao = new ContribuicaoSindicalVO();

                contribuicao.CodigoContribuicaoSindical = Convert.ToInt32(context.Request.QueryString["CodigoContribuicaoSindical"]);
                contribuicao.CodigoUsuarioAlteracao = Convert.ToInt32(context.Session["CodigoUsuario"].ToString());
                contribuicao.DataAlteracao = DateTime.Now;

                return objBS.ExcluirContribuicaoSindical(contribuicao);

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                objBS = null;
                contribuicao = null;
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