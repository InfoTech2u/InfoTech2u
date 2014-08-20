using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfoTech2u.Verithus.Util;
using InfoTech2u.Verithus.VO;
using System.Data.SqlClient;
using System.Data;

namespace InfoTech2u.Verithus.DA
{
    public class TipoOlhoDA
    {
        
        public string SelecionarTipoOlho(TipoOlhoVO param)
        {
            InfoTech2uSQLUtil objSql = new InfoTech2uSQLUtil();
            List<SqlParameter> lstSqlParameter = new List<SqlParameter>();
            DataSet dtRetorno = new DataSet();

            try
            {
                objSql.Sigla = objSql.GetDataBase();
                objSql.ConnectionString = objSql.GetConnectionString(objSql.Sigla);
                objSql.Open();

                if (param.CodigoTipoOlho != null)
                    lstSqlParameter.Add(new SqlParameter("@CODIGO_TIPO_OLHO", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@CODIGO_TIPO_OLHO", param.CodigoTipoOlho));


                objSql.Execute("dbo.[SPVRT069_TIPO_OLHO_PR_SELECIONAR]", lstSqlParameter.ToArray(), null, ref dtRetorno);

                DataSet ds = dtRetorno;

                string xmlRetorno = ds.GetXml();

                xmlRetorno = xmlRetorno.Replace("NewDataSet", "tipo_Olho");
                xmlRetorno = xmlRetorno.Replace("Table", "row");

                return xmlRetorno;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

          public List<TipoOlhoVO> SelecionarTipoOlhoLista(TipoOlhoVO param)
        {

            List<TipoOlhoVO> listaRetorno = new List<TipoOlhoVO>();
            TipoOlhoVO retorno;
            InfoTech2uSQLUtil objSql = new InfoTech2uSQLUtil();
            List<SqlParameter> lstSqlParameter = new List<SqlParameter>();
            //DataSet dtRetorno = new DataSet();
            DataTable dtRetorno = new DataTable();

            try
            {
                objSql.Sigla = objSql.GetDataBase();
                objSql.ConnectionString = objSql.GetConnectionString(objSql.Sigla);
                objSql.Open();

                if (param.CodigoTipoOlho != null)
                    lstSqlParameter.Add(new SqlParameter("@CODIGO_TIPO_OLHO", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@CODIGO_TIPO_OLHO", param.CodigoTipoOlho));


                objSql.Execute("dbo.[SPVRT069_TIPO_OLHO_PR_SELECIONAR]", lstSqlParameter.ToArray(), null, ref dtRetorno);


                DataTable dt = dtRetorno;

                int i = 0;
                while (i < dtRetorno.Rows.Count)
                {
                    

                    retorno = new TipoOlhoVO();

                    retorno.CodigoTipoOlho = Convert.ToInt32(dtRetorno.Rows[i]["CODIGO_TIPO_OLHO"].ToString());

                    retorno.Descricao = string.IsNullOrWhiteSpace(dtRetorno.Rows[i]["DESCRICAO"].ToString()) ? null : dtRetorno.Rows[i]["DESCRICAO"].ToString();
                    
                    if (!String.IsNullOrWhiteSpace(dtRetorno.Rows[i]["CODIGO_USUARIO_CADASTRO"].ToString()))
                        retorno.CodigoUsuarioCadastro = Convert.ToInt32(dtRetorno.Rows[i]["CODIGO_USUARIO_CADASTRO"].ToString());

                    if (!String.IsNullOrWhiteSpace(dtRetorno.Rows[i]["DATA_CADASTRO"].ToString()))
                        retorno.DataCadastro = Convert.ToDateTime(dtRetorno.Rows[i]["DATA_CADASTRO"].ToString());

                    if (!String.IsNullOrWhiteSpace(dtRetorno.Rows[i]["CODIGO_USUARIO_ALTERACAO"].ToString()))
                        retorno.CodigoUsuarioAlteracao = Convert.ToInt32(dtRetorno.Rows[i]["CODIGO_USUARIO_ALTERACAO"].ToString());

                    if (!String.IsNullOrWhiteSpace(dtRetorno.Rows[i]["DATA_ALTERACAO"].ToString()))
                        retorno.DataAlteracao = Convert.ToDateTime(dtRetorno.Rows[i]["DATA_ALTERACAO"].ToString());

                    if (!String.IsNullOrWhiteSpace(dtRetorno.Rows[i]["CODIGO_STATUS"].ToString()))
                        retorno.CodigoStatus = Convert.ToInt32(dtRetorno.Rows[i]["CODIGO_STATUS"].ToString());



                    listaRetorno.Add(retorno);
                    i++;
                }
                
                
                
                return listaRetorno;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objSql = null;
                lstSqlParameter = null;
                dtRetorno = null;
                param = null;
            }
        }
    }    
}
