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
    public class FeriasDA
    {
        public DataTable IncluirFerias(FeriasVO usuario)
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

                lstSqlParameter.Add(new SqlParameter("@CODIGO_FERIAS", usuario.CodigoFerias));
                lstSqlParameter.Add(new SqlParameter("@CODIGO_FUNCIONARIO", usuario.CodigoFuncionario));
                lstSqlParameter.Add(new SqlParameter("@DATA_PERIODO_INICIO", usuario.DataPeriodoInicio));
                lstSqlParameter.Add(new SqlParameter("@DATA_PERIODO_FIM", usuario.DataPeriodoFim));
                lstSqlParameter.Add(new SqlParameter("@DATA_GOZADA_INICIO", usuario.DataGozadaInicio));
                lstSqlParameter.Add(new SqlParameter("@DATA_GOZADA_FIM", usuario.DataGozadaFim));
                
                //TODO: Pegar Usuario da SESSION
                lstSqlParameter.Add(new SqlParameter("@CODIGO_USUARIO_CADASTRO", usuario.CodigoUsuarioCadastro));
                lstSqlParameter.Add(new SqlParameter("@DATA_CADASTRO", usuario.DataCadastro));
                lstSqlParameter.Add(new SqlParameter("@CODIGO_USUARIO_ALTERACAO", usuario.CodigoUsuarioAlteracao));
                lstSqlParameter.Add(new SqlParameter("@DATA_ALTERACAO", usuario.DataAlteracao));
                //lstSqlParameter.Add(new SqlParameter("@CODIGO_STATUS", usuario.CodigoStatus));

                dtRetorno = new DataTable();

                objSql.Execute("SPVRT067_FERIAS_PR_INCLUIR", lstSqlParameter.ToArray(), null, ref dtRetorno);

            }
            catch (Exception ex)
            {
                return null;
            }

            return dtRetorno;
        }

        public DataTable AlterarFerias(FeriasVO usuario)
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

                lstSqlParameter.Add(new SqlParameter("@CODIGO_FERIAS", usuario.CodigoFerias));
                lstSqlParameter.Add(new SqlParameter("@CODIGO_FUNCIONARIO", usuario.CodigoFuncionario));
                lstSqlParameter.Add(new SqlParameter("@DATA_PERIODO_INICIO", usuario.DataPeriodoInicio));
                lstSqlParameter.Add(new SqlParameter("@DATA_PERIODO_FIM", usuario.DataPeriodoFim));
                lstSqlParameter.Add(new SqlParameter("@DATA_GOZADA_INICIO", usuario.DataGozadaInicio));
                lstSqlParameter.Add(new SqlParameter("@DATA_GOZADA_FIM", usuario.DataGozadaFim));

                //TODO: Pegar Usuario da SESSION
                lstSqlParameter.Add(new SqlParameter("@CODIGO_USUARIO_CADASTRO", usuario.CodigoUsuarioCadastro));
                lstSqlParameter.Add(new SqlParameter("@DATA_CADASTRO", usuario.DataCadastro));
                lstSqlParameter.Add(new SqlParameter("@CODIGO_USUARIO_ALTERACAO", usuario.CodigoUsuarioAlteracao));
                lstSqlParameter.Add(new SqlParameter("@DATA_ALTERACAO", usuario.DataAlteracao));
                //lstSqlParameter.Add(new SqlParameter("@CODIGO_STATUS", usuario.CodigoStatus));

                dtRetorno = new DataTable();

                objSql.Execute("SPVRT066_FERIAS_PR_ALTERAR", lstSqlParameter.ToArray(), null, ref dtRetorno);

            }
            catch (Exception ex)
            {
                return null;
            }

            return dtRetorno;
        }

        public DataTable SelecionarFerias(FeriasVO usuario)
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

                lstSqlParameter.Add(new SqlParameter("@CODIGO_FUNCIONARIO", usuario.CodigoFuncionario));

                lstSqlParameter.Add(new SqlParameter("@CODIGO_FERIAS", usuario.CodigoFerias));

                dtRetorno = new DataTable();

                objSql.Execute("SPVRT068_FERIAS_PR_SELECIONAR", lstSqlParameter.ToArray(), null, ref dtRetorno);

            }
            catch (Exception ex)
            {
                return null;
            }

            return dtRetorno;
        }

        public DataTable ExcluirFerias(FeriasVO usuario)
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

                lstSqlParameter.Add(new SqlParameter("@CODIGO_FUNCIONARIO", usuario.CodigoFuncionario));

                lstSqlParameter.Add(new SqlParameter("@CODIGO_FERIAS", usuario.CodigoFerias));

                lstSqlParameter.Add(new SqlParameter("@CODIGO_USUARIO_ALTERACAO", usuario.CodigoUsuarioAlteracao));

                dtRetorno = new DataTable();

                objSql.Execute("SPVRT078_FERIAS_PR_EXCLUIR", lstSqlParameter.ToArray(), null, ref dtRetorno);

            }
            catch (Exception ex)
            {
                return null;
            }

            return dtRetorno;
        }
    }
}
