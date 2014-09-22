using InfoTech2u.Verithus.BS;
using InfoTech2u.Verithus.VO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using InfoTech2u.Verithus.Util;

namespace InfoTech2u.Verithus.WEB.Handler
{
    /// <summary>
    /// Summary description for ManterTipoAcesso
    /// </summary>
    public class ManterTipoAcesso : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            if (context.Request.QueryString["Metodo"] == "Lista")
            {
                var retorno = SelecionarTipoAcesso(new SindicatoVO());

                context.Response.Write(retorno.Serializer());
            }
            else if (context.Request.QueryString["Metodo"] == "Incluir")
            {
               
            }
            else if (context.Request.QueryString["Metodo"] == "Excluir")
            {
               
            }
        }

        private DataTable SelecionarTipoAcesso(SindicatoVO param)
        {
            TipoAcessoBS objBS = new TipoAcessoBS();
            return objBS.SelecionarTipoAcessoLista();
        }

        //private DataTable IncluirTipoAcesso(SindicatoVO param)
        //{
        //    TipoAcessoBS objBS = new TipoAcessoBS();
        //    return objBS.IncluirTipoAcesso(param);
        //}

        //private bool ExcluirTipoAcesso(SindicatoVO param)
        //{
        //    TipoAcessoBS objBS = new TipoAcessoBS();
        //    return objBS.ExcluirTipoAcesso(param);
        //}

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}