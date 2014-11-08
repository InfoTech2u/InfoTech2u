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

namespace InfoTech2u.Verithus.WEB.Handler
{
    /// <summary>
    /// Summary description for BuscarCep
    /// </summary>
    public class BuscarCep : IHttpHandler
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

                ConsultaCEPServicoFreeVO objCEP = new ConsultaCEPServicoFreeVO();
                List<ConsultaCEPServicoFreeVO> listObjCEP = new List<ConsultaCEPServicoFreeVO>();
                XmlDocument objXml = new XmlDocument();
                DataTable dtRetorno = new DataTable();
                string _StrX = "<?xml version='1.0' encoding='utf-8'?><root>";
                string jsonText = null;
                string CEP;
                List<EstadoVO> listaEstado = new List<EstadoVO>();
                EstadoBS objEstado = new EstadoBS();
                EstadoVO paramEstado = new EstadoVO();


                if (!String.IsNullOrEmpty(context.Request.QueryString["txtCEP"].ToString()))
                    CEP = context.Request.QueryString["txtCEP"].ToString();
                else
                    CEP = "";

                objCEP.Uf = "";
                objCEP.Cidade = "";
                objCEP.Bairro = "";
                objCEP.Tipo_logradouro = "";
                objCEP.Logradouro = "";
                objCEP.Resultado = "0";
                objCEP.Resultato_txt = "CEP não encontrado";

                DataSet ds = new DataSet();
                ds.ReadXml("http://cep.republicavirtual.com.br/web_cep.php?cep=" + CEP.Replace("-", "").Trim() + "&formato=xml");

                if (ds != null)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        objCEP.Resultado = ds.Tables[0].Rows[0]["resultado"].ToString();
                        switch (objCEP.Resultado)
                        {
                            case "1":

                                paramEstado.Sigla = ds.Tables[0].Rows[0]["uf"].ToString().Trim();

                                listaEstado = objEstado.SelecionarEstado(paramEstado);

                                //objCEP.Uf = ds.Tables[0].Rows[0]["uf"].ToString().Trim();

                                objCEP.Uf = listaEstado[0].Descricao.ToString();
                                objCEP.Cidade = ds.Tables[0].Rows[0]["cidade"].ToString().Trim();
                                objCEP.Bairro = ds.Tables[0].Rows[0]["bairro"].ToString().Trim();
                                objCEP.Tipo_logradouro = ds.Tables[0].Rows[0]["tipo_logradouro"].ToString().Trim();
                                objCEP.Logradouro = ds.Tables[0].Rows[0]["logradouro"].ToString().Trim();
                                objCEP.Resultato_txt = "CEP completo";
                                listObjCEP.Add(objCEP);
                                break;
                            case "2":
                                objCEP.Uf = ds.Tables[0].Rows[0]["uf"].ToString().Trim();
                                objCEP.Cidade = ds.Tables[0].Rows[0]["cidade"].ToString().Trim();
                                objCEP.Bairro = "";
                                objCEP.Tipo_logradouro = "";
                                objCEP.Logradouro = "";
                                objCEP.Resultato_txt = "CEP  único";
                                listObjCEP.Add(objCEP);
                                break;
                            default:
                                objCEP.Uf = "";
                                objCEP.Cidade = "";
                                objCEP.Bairro = "";
                                objCEP.Tipo_logradouro = "";
                                objCEP.Logradouro = "";
                                objCEP.Resultato_txt = "CEP não  encontrado";
                                listObjCEP.Add(objCEP);
                                break;
                        }
                    }
                }

                JavaScriptSerializer  objSerial = new JavaScriptSerializer();

                context.Response.Write(objSerial.Serialize(listObjCEP));
                /*if (ds != null)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        string xmlRetorno = ds.GetXml();

                        xmlRetorno = xmlRetorno.Replace("NewDataSet", "estados");
                        xmlRetorno = xmlRetorno.Replace("Table", "row");

                        _StrX += xmlRetorno;
                        _StrX += "</root>";

                    }
                }


                objXml.LoadXml(_StrX);

                jsonText = JsonConvert.SerializeXmlNode(objXml);

                context.Response.Write(jsonText);*/
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