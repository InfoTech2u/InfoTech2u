using InfoTech2u.Verithus.Util;
using InfoTech2u.Verithus.VO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoTech2u.Verithus.DA
{
    public class SistemaDA
    {
        public DataTable IncluirSistema(SistemaVO param)
        {
            InfoTech2uSQLUtil objSql = null;
            StringBuilder query = null;
            List<SqlParameter> lstSqlParameter = null;
            DataTable dtRetorno = null;

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

                dtRetorno = new DataTable();

                objSql.Execute("SPVRT033_SISTEMA_PR_INCLUIR", lstSqlParameter.ToArray(), null, ref dtRetorno);

            }
            catch (Exception ex)
            {
                return null;
            }

            return dtRetorno;
        }

        public List<SistemaVO> SelecionarSistema(SistemaVO param)
        {
            InfoTech2uSQLUtil objSql = null;
            List<SqlParameter> lstSqlParameter = null;
            DataTable dtRetorno = null;
            List<SistemaVO> listaRetorno = null;
            SistemaVO retorno = null;

            try
            {
                objSql = new InfoTech2uSQLUtil();
                lstSqlParameter = new List<SqlParameter>();
                dtRetorno = new DataTable();

                objSql.Sigla = objSql.GetDataBase();
                objSql.ConnectionString = objSql.GetConnectionString(objSql.Sigla);
                objSql.Open();

                if (param.CodigoSistema == null)
                    lstSqlParameter.Add(new SqlParameter("@CODIGO_SISTEMA", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@CODIGO_SISTEMA", param.CodigoSistema));


                objSql.Execute("dbo.[SPVRT076_SISTEMA_PR_SELECIONAR]", lstSqlParameter.ToArray(), null, ref dtRetorno);

                listaRetorno = new List<SistemaVO>();
                int i = 0;
                while (i < dtRetorno.Rows.Count)
                {
                    retorno = new SistemaVO();

                    retorno.CodigoSistema = Convert.ToInt32(dtRetorno.Rows[i]["CODIGO_SISTEMA"].ToString());

                    retorno.Descricao = string.IsNullOrWhiteSpace(dtRetorno.Rows[i]["DESCRICAO"].ToString()) ? null : dtRetorno.Rows[i]["DESCRICAO"].ToString();

                    if (!String.IsNullOrWhiteSpace(dtRetorno.Rows[i]["CODIGO_USUARIO_CADASTRO"].ToString()))
                        retorno.CodigoUsuarioAlteracao = Convert.ToInt32(dtRetorno.Rows[i]["CODIGO_USUARIO_CADASTRO"].ToString());

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
        }

        public List<SistemaVO> SelecionarSistemaLista()
        {

            List<SistemaVO> listaRetorno = null;
            SistemaVO retorno = null;
            InfoTech2uSQLUtil objSql = null;
            List<SqlParameter> lstSqlParameter = null;
            DataTable dtRetorno = null;

            try
            {
                listaRetorno = new List<SistemaVO>();
                objSql = new InfoTech2uSQLUtil();
                lstSqlParameter = new List<SqlParameter>();
                dtRetorno = new DataTable();

                objSql.Sigla = objSql.GetDataBase();
                objSql.ConnectionString = objSql.GetConnectionString(objSql.Sigla);
                objSql.Open();


                lstSqlParameter.Add(new SqlParameter("@CODIGO_SISTEMA", DBNull.Value));


                objSql.Execute("dbo.[SPVRT076_SISTEMA_PR_SELECIONAR]", lstSqlParameter.ToArray(), null, ref dtRetorno);

                DataTable dt = dtRetorno;

                int i = 0;
                while (i < dtRetorno.Rows.Count)
                {
                    retorno = new SistemaVO();

                    retorno.CodigoSistema = Convert.ToInt32(dtRetorno.Rows[i]["CODIGO_SISTEMA"].ToString());

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
            }

            return listaRetorno;
        }

        public DataTable ExcluirSistema(SistemaVO param)
        {
            InfoTech2uSQLUtil objSql = null;
            StringBuilder query = null;
            List<SqlParameter> lstSqlParameter = null;
            DataTable dtRetorno = null;

            try
            {

                objSql = new InfoTech2uSQLUtil();
                lstSqlParameter = new List<SqlParameter>();
                dtRetorno = new DataTable();
                query = new StringBuilder();

                objSql.Sigla = objSql.GetDataBase();
                objSql.ConnectionString = objSql.GetConnectionString(objSql.Sigla);
                objSql.Open();

                lstSqlParameter.Add(new SqlParameter("@CODIGO_SISTEMA", param.CodigoSistema));
                lstSqlParameter.Add(new SqlParameter("@CODIGO_USUARIO_ALTERACAO", param.CodigoUsuarioAlteracao));

                objSql.Execute("SPVRT077_SISTEMA_PR_EXCLUIR", lstSqlParameter.ToArray(), null, ref dtRetorno);

                return dtRetorno;
            }
            catch (Exception ex)
            {
                return dtRetorno;
            }
            finally
            {
                objSql = null;
                lstSqlParameter = null;
                query = null;
                dtRetorno = null;
            }
        }
    }
}
