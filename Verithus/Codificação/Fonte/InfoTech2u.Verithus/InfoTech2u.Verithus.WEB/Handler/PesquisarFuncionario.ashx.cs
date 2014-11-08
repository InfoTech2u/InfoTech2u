using System;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.UI;
using InfoTech2u.Verithus.VO;
using InfoTech2u.Verithus.BS;
using System.Web.Script.Serialization;
using System.Collections.Generic;
using System.Data;
using InfoTech2u.Verithus.Util;

namespace InfoTech2u.Verithus.WEB.Handler
{
    /// <summary>
    /// Summary description for PesquisarFuncionario
    /// </summary>
    public class PesquisarFuncionario : IHttpHandler, System.Web.SessionState.IRequiresSessionState
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

            DataTable dtRetorno = new DataTable();
            FuncionariosBS objRetorno = new FuncionariosBS();
            //Objetos Dados de Funcionario
            FuncionariosVO objFuncionario = new FuncionariosVO();

            string CodigoFuncionario = context.Request.QueryString["CodigoFuncionario"].ToString();
            string NumeroOrdemMatricula = context.Request.QueryString["NumeroOrdemMatricula"].ToString();
            string NumeroMatricula = context.Request.QueryString["NumeroMatricula"].ToString();
            string NomeFuncionario = context.Request.QueryString["NomeFuncionario"].ToString();

            //Passo 1 - Dados Pessoais
            if (!String.IsNullOrWhiteSpace(CodigoFuncionario))
                objFuncionario.CodigoFuncionario = Convert.ToInt32(CodigoFuncionario);

            if (!String.IsNullOrWhiteSpace(NumeroOrdemMatricula))
                objFuncionario.NumeroOrdemMatricula = Convert.ToInt32(NumeroOrdemMatricula);

            if (!String.IsNullOrWhiteSpace(NumeroMatricula))
                objFuncionario.NumeroMatricula = Convert.ToInt32(NumeroMatricula);

            objFuncionario.NomeFuncionario = NomeFuncionario;

            dtRetorno = objRetorno.SelecionarFuncionario(objFuncionario);

            context.Response.Write(dtRetorno.DataTableSerializer());
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