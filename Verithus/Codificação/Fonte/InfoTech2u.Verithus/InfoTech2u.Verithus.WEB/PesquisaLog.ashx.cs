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

namespace InfoTech2u.Verithus.WEB
{
    /// <summary>
    /// Summary description for PesquisaLog
    /// </summary>
    public class PesquisaLog : IHttpHandler, System.Web.SessionState.IRequiresSessionState
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

                LogVO param = new LogVO();

                if (String.IsNullOrWhiteSpace(context.Request.QueryString["CodigoLog"].ToString()))
                    param.CodigoLog = null;
                else
                    param.CodigoLog = Convert.ToInt32(context.Request.QueryString["CodigoLog"].ToString());

                if (String.IsNullOrWhiteSpace(context.Request.QueryString["TipoLog"].ToString()))
                    param.TipoLog = null;
                else
                    param.TipoLog = context.Request.QueryString["TipoLog"].ToString();

                if (String.IsNullOrWhiteSpace(context.Request.QueryString["CodigoUsuarioExecucao"].ToString()))
                    param.CodigoUsuarioExecucao = null;
                else
                    param.CodigoUsuarioExecucao = Convert.ToInt32(context.Request.QueryString["CodigoUsuarioExecucao"].ToString());

                if (String.IsNullOrWhiteSpace(context.Request.QueryString["DataGeracaoInicio"].ToString()))
                    param.DataGeracaoInicio = null;
                else
                    param.DataGeracaoInicio = Convert.ToDateTime(context.Request.QueryString["DataGeracaoInicio"].ToString());

                if (String.IsNullOrWhiteSpace(context.Request.QueryString["DataGeracaoFim"].ToString()))
                    param.DataGeracaoFim = null;
                else
                    param.DataGeracaoFim = Convert.ToDateTime(context.Request.QueryString["DataGeracaoFim"].ToString());

                if (String.IsNullOrWhiteSpace(context.Request.QueryString["Metodo"].ToString()))
                    param.Metodo = null;
                else
                    param.Metodo = context.Request.QueryString["Metodo"].ToString();

                if (String.IsNullOrWhiteSpace(context.Request.QueryString["Descricao"].ToString()))
                    param.Descricao = null;
                else
                    param.Descricao = context.Request.QueryString["Descricao"].ToString();

                var retorno = SelecionarLog(new LogVO());

                JavaScriptSerializer serializer = new JavaScriptSerializer();

                context.Response.Write(serializer.Serialize(retorno));
            }
        }

        private List<LogVO> SelecionarLog(LogVO param)
        {
            LogBS objBS = new LogBS();
            return objBS.SelecionarLog(param);
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