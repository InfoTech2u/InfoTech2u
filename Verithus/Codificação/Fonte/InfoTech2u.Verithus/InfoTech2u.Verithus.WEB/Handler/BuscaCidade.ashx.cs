using System;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.UI;
using InfoTech2u.Verithus.VO;
using InfoTech2u.Verithus.BS;
using System.Web.Script.Serialization;
using System.Collections.Generic;
using System.Xml;
using System.Data;
using Newtonsoft.Json;

namespace InfoTech2u.Verithus.WEB
{
    /// <summary>
    /// Summary description for BuscaCidade
    /// </summary>
    public class BuscaCidade : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            try
            {
                if (context.Session["CodigoUsuario"] == null)
                {
                    context.Response.ContentType = "application/json; charset=utf-8";
                    context.Response.Write("{ \"Msg\": \"Sessão expirada. Você será redirecionado para tela de login.\"}");
                    context.Response.End();
                    return;
                }

                DataTable dtRetorno = new DataTable();
                CidadeVO entrada = new CidadeVO();
                CidadeBS objCidade = new CidadeBS();
                List<CidadeVO> listaCidade = new List<CidadeVO>();
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                int? codigoEstado;
                string retorno = "";

                if (!String.IsNullOrEmpty(context.Request.QueryString["codigoEstado"].ToString()))
                    codigoEstado = Convert.ToInt32(context.Request.QueryString["codigoEstado"].ToString());
                else
                    codigoEstado = null;

                entrada.CodigoEstado = codigoEstado;

                dtRetorno = objCidade.SelecionarCidade(entrada);

                List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
                Dictionary<string, object> row;

                foreach (DataRow dr in dtRetorno.Rows)
                {
                    row = new Dictionary<string, object>();
                    foreach (DataColumn col in dtRetorno.Columns)
                    {
                        row.Add(col.ColumnName, dr[col]);
                    }
                    rows.Add(row);
                }
                retorno = serializer.Serialize(rows);

                context.Response.Write(retorno);
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
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