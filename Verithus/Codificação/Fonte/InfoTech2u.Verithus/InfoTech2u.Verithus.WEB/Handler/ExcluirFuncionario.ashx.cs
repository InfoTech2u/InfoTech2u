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
    /// Summary description for ExcluirFuncionario
    /// </summary>
    public class ExcluirFuncionario : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            DataTable dtRetorno = new DataTable();
            FuncionariosBS objRetorno = new FuncionariosBS();
            //Objetos Dados de Funcionario
            FuncionariosVO objFuncionario = new FuncionariosVO();

            string CodigoFuncionario = context.Request.QueryString["CodigoFuncionario"].ToString();
            

            //Passo 1 - Dados Pessoais
            if (!String.IsNullOrWhiteSpace(CodigoFuncionario))
                objFuncionario.CodigoFuncionario = Convert.ToInt32(CodigoFuncionario);

            objFuncionario.CodigoUsuarioAlteracao = Convert.ToInt32(context.Session["CodigoUsuario"].ToString());

            dtRetorno = objRetorno.ExcluirFuncionario(objFuncionario);

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