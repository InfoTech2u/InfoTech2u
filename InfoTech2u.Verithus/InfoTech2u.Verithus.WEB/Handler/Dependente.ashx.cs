using InfoTech2u.Verithus.BS;
using InfoTech2u.Verithus.VO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace InfoTech2u.Verithus.WEB.Handler
{
    /// <summary>
    /// Summary description for Dependente
    /// </summary>
    public class Dependente : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
           
            var a = serializer.Deserialize<String[]>(context.Request.QueryString["Beneficio"]);

            if (context.Request.QueryString["Metodo"] == "Lista")
            {
                if (!String.IsNullOrEmpty(context.Request.QueryString["CodigoFuncionario"]))
                {
                    int codigoFuncionario = Convert.ToInt32(context.Request.QueryString["CodigoFuncionario"].ToString());

                    context.Response.Write(serializer.Serialize(ListarDependentes(codigoFuncionario)));
                }
            }
        }

        private List<DependenteVO> ListarDependentes(int codigoFuncionario)
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