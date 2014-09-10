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
    public class TipoSecaoDA
    {
        public List<TipoSecaoVO> SelecionarSecaoLista(TipoSecaoVO param)
        {
            List<TipoSecaoVO> listaRetorno = new List<TipoSecaoVO>();
            TipoSecaoVO retorno;
            InfoTech2uSQLUtil objSql = new InfoTech2uSQLUtil();
            List<SqlParameter> lstSqlParameter = new List<SqlParameter>();
            DataTable dtRetorno = new DataTable();

            try
            {
                objSql.Sigla = objSql.GetDataBase();
                objSql.ConnectionString = objSql.GetConnectionString(objSql.Sigla);
                objSql.Open();

                if (param.CodigoTipoSecao == null)
                    lstSqlParameter.Add(new SqlParameter("@CODIGO_TIPO_SECAO", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@CODIGO_TIPO_SECAO", param.CodigoTipoSecao));

                objSql.Execute("dbo.[SPVRT081_TIPO_SECAO_PR_SELECIONAR]", lstSqlParameter.ToArray(), null, ref dtRetorno);

                DataTable dt = dtRetorno;

                int i = 0;
                while (i < dtRetorno.Rows.Count)
                {
                    retorno = new TipoSecaoVO();

                    retorno.CodigoTipoSecao = Convert.ToInt32(dtRetorno.Rows[i]["@CODIGO_TIPO_SECAO"].ToString());
                    retorno.Descricao = string.IsNullOrWhiteSpace(dtRetorno.Rows[i]["DESCRICAO"].ToString()) ? null : dtRetorno.Rows[i]["DESCRICAO"].ToString();

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

        public bool IncluirTipoSecao(TipoSecaoVO param)
        {
            InfoTech2uSQLUtil objSql = null;
            StringBuilder query = null;
            List<SqlParameter> lstSqlParameter = null;
            DataTable dt = null;

            try
            {

                objSql = new InfoTech2uSQLUtil();
                lstSqlParameter = new List<SqlParameter>();
                query = new StringBuilder();

                objSql.Sigla = objSql.GetDataBase();
                objSql.ConnectionString = objSql.GetConnectionString(objSql.Sigla);
                objSql.Open();

                lstSqlParameter.Add(new SqlParameter("@DESCRICAO", param.Descricao));
                lstSqlParameter.Add(new SqlParameter("@CODIGO_USUARIO_CADASTRO", param.CodigoUsuarioCadastro));
                lstSqlParameter.Add(new SqlParameter("@DATA_CADASTRO", param.DataCadastro));
                lstSqlParameter.Add(new SqlParameter("@CODIGO_USUARIO_ALTERACAO", param.CodigoUsuarioAlteracao));
                lstSqlParameter.Add(new SqlParameter("@DATA_ALTERACAO", param.DataAlteracao));
                lstSqlParameter.Add(new SqlParameter("@CODIGO_STATUS", param.CodigoStatus));

                lstSqlParameter.Add(new SqlParameter("@C_ERR", DBNull.Value));
                lstSqlParameter.Add(new SqlParameter("@T_ERR", DBNull.Value));

                dt = new DataTable();

                int rowsAffected = 0;
                objSql.ExecuteNonQuery("SPVRT082_TIPO_SECAO_PR_INCLUIR", lstSqlParameter.ToArray(), null, out rowsAffected);

                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }

        public bool ExcluirTipoSecao(TipoSecaoVO param)
        {
            InfoTech2uSQLUtil objSql = null;
            StringBuilder query = null;
            List<SqlParameter> lstSqlParameter = null;
            bool foiExcluido = false;

            try
            {

                objSql = new InfoTech2uSQLUtil();
                lstSqlParameter = new List<SqlParameter>();
                query = new StringBuilder();

                objSql.Sigla = objSql.GetDataBase();
                objSql.ConnectionString = objSql.GetConnectionString(objSql.Sigla);
                objSql.Open();

                lstSqlParameter.Add(new SqlParameter("@CODIGO_TIPO_SECAO", param.CodigoTipoSecao));

                int rowsAffected = 0;

                objSql.ExecuteNonQuery("SPVRT084_TIPO_SECAO_PR_EXCLUIR", lstSqlParameter.ToArray(), null, out rowsAffected);

                foiExcluido = rowsAffected > 0;
            }
            catch (Exception ex)
            {
                foiExcluido = false;
            }
            finally
            {
                objSql = null;
                lstSqlParameter = null;
                query = null;
            }

            return foiExcluido;
        }
    }
}
