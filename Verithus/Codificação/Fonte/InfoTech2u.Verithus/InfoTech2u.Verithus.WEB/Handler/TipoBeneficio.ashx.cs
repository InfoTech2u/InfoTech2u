using InfoTech2u.Verithus.BS;
using InfoTech2u.Verithus.VO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using System.Web.Script.Serialization;
using InfoTech2u.Verithus.Util;

namespace InfoTech2u.Verithus.WEB.Handler
{
    /// <summary>
    /// Summary description for ManterTipoBeneficio
    /// </summary>
    public class ManterTipoBeneficio : IHttpHandler, System.Web.SessionState.IRequiresSessionState
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
                var retorno = SelecionarTipoBeneficio(new TipoBeneficioVO());
                 
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                                
                context.Response.Write(serializer.Serialize(retorno));
            }
            else if (context.Request.QueryString["Metodo"] == "Incluir")
            {
                TipoBeneficioVO param = new TipoBeneficioVO();
                param.Descricao = context.Request.QueryString["Descricao"].ToString();

                param.CodigoUsuarioCadastro = Convert.ToInt32(context.Session["CodigoUsuario"].ToString());
               
                context.Response.Write(IncluirTipoBeneficio(param).DataTableSerializer());
            }
            else if (context.Request.QueryString["Metodo"] == "Excluir")
            {
                TipoBeneficioVO param = new TipoBeneficioVO();
                int numconvertido = 0;

                JavaScriptSerializer serializer = new JavaScriptSerializer();

                if (Int32.TryParse(context.Request.QueryString["Id"].ToString(), out numconvertido))
                {
                    param.CodigoTipoBeneficio = numconvertido;

                    param.CodigoUsuarioAlteracao = Convert.ToInt32(context.Session["CodigoUsuario"].ToString());

                    context.Response.Write(ExcluirTipoBeneficio(param).Serializer());
                }
                else
                {
                    context.Response.Write(serializer.Serialize(false));
                }
            }
        }

        private List<TipoBeneficioVO> SelecionarTipoBeneficio(TipoBeneficioVO param)
        {
            TipoBeneficioBS objBS = new TipoBeneficioBS();
            return objBS.SelecionarTipoBeneficio(param);
        }

        private DataTable IncluirTipoBeneficio(TipoBeneficioVO param)
        { 
            TipoBeneficioBS objBS = new TipoBeneficioBS();
            return objBS.IncluirTipoBeneficio(param);
        }

        private DataTable ExcluirTipoBeneficio(TipoBeneficioVO param)
        {
            TipoBeneficioBS objBS = new TipoBeneficioBS();
            return objBS.ExcluirTipoBeneficio(param);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
   
    public class Teste
    {
        
        public Teste()
        { }
       
        public String dados1 { get; set; }
       
        public int dados2 { get; set; }
        
        public DateTime dados3 { get; set; }
    }
}