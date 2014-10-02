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
    public class ContribuicaoSindicalDA
    {
        //SPVRT021_FUNCIONARIO_PR_SELECIONAR
        public DataTable SelecionarContribuicaoFuncionario(ContribuicaoSindicalVO param)
        {
            InfoTech2uSQLUtil objSql = null;
            List<SqlParameter> lstSqlParameter = null;
            DataTable dtRetorno = null;

            try
            {
                objSql = new InfoTech2uSQLUtil();
                lstSqlParameter = new List<SqlParameter>();
                dtRetorno = new DataTable();

                objSql.Sigla = objSql.GetDataBase();
                objSql.ConnectionString = objSql.GetConnectionString(objSql.Sigla);
                objSql.Open();

                lstSqlParameter.Add(new SqlParameter("@CODIGO_FUNCIONARIO", param.CodigoFuncionario));
                lstSqlParameter.Add(new SqlParameter("@CODIGO_CONTRIBUICAO_SINDICAL", DBNull.Value));

                objSql.Execute("dbo.[SPVRT109_CONTRIBUICAO_SINDICAL_PR_SELECIONAR]", lstSqlParameter.ToArray(), null, ref dtRetorno);

                return dtRetorno;
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

        }

        public DataTable IncluirContribuicaoSindical(ContribuicaoSindicalVO param)
        {
            InfoTech2uSQLUtil objSql = null;
            List<SqlParameter> lstSqlParameter = null;
            DataTable dtRetorno = null;

            try
            {
                objSql = new InfoTech2uSQLUtil();
                lstSqlParameter = new List<SqlParameter>();
                dtRetorno = new DataTable();

                objSql.Sigla = objSql.GetDataBase();
                objSql.ConnectionString = objSql.GetConnectionString(objSql.Sigla);
                objSql.Open();

                lstSqlParameter.Add(new SqlParameter("@CODIGO_FUNCIONARIO", param.CodigoFuncionario));
                lstSqlParameter.Add(new SqlParameter("@CODIGO_SINDICATO", param.CodigoSindicato));
                lstSqlParameter.Add(new SqlParameter("@CODIGO_STATUS", param.CodigoStatus));
                lstSqlParameter.Add(new SqlParameter("@CODIGO_USUARIO_ALTERACAO", param.CodigoUsuarioAlteracao));
                lstSqlParameter.Add(new SqlParameter("@CODIGO_USUARIO_CADASTRO", param.CodigoUsuarioCadastro));
                lstSqlParameter.Add(new SqlParameter("@DATA_CADASTRO", param.DataCadastro));
                lstSqlParameter.Add(new SqlParameter("@DATA_ALTERACAO", param.DataAlteracao));
                lstSqlParameter.Add(new SqlParameter("@PERIODO_ANO", param.PeriodoAno));
                lstSqlParameter.Add(new SqlParameter("@VALOR_RECOLHIDO", param.ValorRecolhido));

                objSql.Execute("dbo.[SPVRT110_CONTRIBUICAO_SINDICAL_PR_INCLUIR]", lstSqlParameter.ToArray(), null, ref dtRetorno);

                return dtRetorno;
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
        }

        public DataTable AlterarContribuicaoSindical(ContribuicaoSindicalVO param)
        {
            InfoTech2uSQLUtil objSql = null;
            List<SqlParameter> lstSqlParameter = null;
            DataTable dtRetorno = null;

            try
            {
                objSql = new InfoTech2uSQLUtil();
                lstSqlParameter = new List<SqlParameter>();
                dtRetorno = new DataTable();

                objSql.Sigla = objSql.GetDataBase();
                objSql.ConnectionString = objSql.GetConnectionString(objSql.Sigla);
                objSql.Open();

                lstSqlParameter.Add(new SqlParameter("@CODIGO_CONTRIBUICAO_SINDICAL", param.CodigoContribuicaoSindical));
                lstSqlParameter.Add(new SqlParameter("@CODIGO_SINDICATO", param.CodigoSindicato));
                lstSqlParameter.Add(new SqlParameter("@CODIGO_STATUS", param.CodigoStatus));
                lstSqlParameter.Add(new SqlParameter("@CODIGO_USUARIO_ALTERACAO", param.CodigoUsuarioAlteracao));
                lstSqlParameter.Add(new SqlParameter("@DATA_ALTERACAO", param.DataAlteracao));
                lstSqlParameter.Add(new SqlParameter("@PERIODO_ANO", param.PeriodoAno));
                lstSqlParameter.Add(new SqlParameter("@VALOR_RECOLHIDO", param.ValorRecolhido));

                objSql.Execute("dbo.[SPVRT111_CONTRIBUICAO_SINDICAL_PR_ALTERAR]", lstSqlParameter.ToArray(), null, ref dtRetorno);

                return dtRetorno;
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
        }

        public bool ExcluirContribuicaoSindical(ContribuicaoSindicalVO param)
        {
            InfoTech2uSQLUtil objSql = null;
            List<SqlParameter> lstSqlParameter = null;
            DataTable dtRetorno = null;
            int rowsAffected = 0;

            try
            {
                objSql = new InfoTech2uSQLUtil();
                lstSqlParameter = new List<SqlParameter>();
                dtRetorno = new DataTable();

                objSql.Sigla = objSql.GetDataBase();
                objSql.ConnectionString = objSql.GetConnectionString(objSql.Sigla);
                objSql.Open();

                lstSqlParameter.Add(new SqlParameter("@CODIGO_CONTRIBUICAO_SINDICAL", param.CodigoContribuicaoSindical));
                lstSqlParameter.Add(new SqlParameter("@CODIGO_USUARIO_ALTERACAO", param.CodigoUsuarioAlteracao));

                
                objSql.ExecuteNonQuery("dbo.[SPVRT112_CONTRIBUICAO_SINDICAL_PR_EXCLUIR]", lstSqlParameter.ToArray(), null, out rowsAffected);

                
            }
            catch (Exception ex)
            {
                rowsAffected = 0;
            }
            finally
            {
                objSql = null;
                lstSqlParameter = null;
                dtRetorno = null;
            }

            return rowsAffected > 0;
        }
    }
}
