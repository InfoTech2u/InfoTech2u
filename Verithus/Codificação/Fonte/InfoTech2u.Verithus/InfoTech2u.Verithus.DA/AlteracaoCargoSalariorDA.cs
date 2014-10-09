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
    public class AlteracaoCargoSalariorDA
    {
        public DataTable IncluirAlteracaoCargoSalarior(AlteracaoCargoSalariorVO usuario)
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

                lstSqlParameter.Add(new SqlParameter("@CODIGO_ALTERACAO_CARGO_SALARIO", usuario.CodigoAlteracaoCargoSalario));
                lstSqlParameter.Add(new SqlParameter("@CODIGO_FUNCIONARIO", usuario.CodigoFuncionario));
                lstSqlParameter.Add(new SqlParameter("@DATA", usuario.Data));
                lstSqlParameter.Add(new SqlParameter("@CODIGO_TIPO_CARGO", usuario.CodigoTipoCargo));
                lstSqlParameter.Add(new SqlParameter("@SALARIO", usuario.Salario));
                lstSqlParameter.Add(new SqlParameter("@HORARIO_INICIO", usuario.HorarioInicio));
                lstSqlParameter.Add(new SqlParameter("@HORARIO_FIM", usuario.HorarioFim));
                
                //TODO: Pegar Usuario da SESSION
                lstSqlParameter.Add(new SqlParameter("@CODIGO_USUARIO_CADASTRO", usuario.CodigoUsuarioCadastro));
                lstSqlParameter.Add(new SqlParameter("@DATA_CADASTRO", usuario.DataCadastro));
                lstSqlParameter.Add(new SqlParameter("@CODIGO_USUARIO_ALTERACAO", usuario.CodigoUsuarioAlteracao));
                lstSqlParameter.Add(new SqlParameter("@DATA_ALTERACAO", usuario.DataAlteracao));
                //lstSqlParameter.Add(new SqlParameter("@CODIGO_STATUS", usuario.CodigoStatus));

                dtRetorno = new DataTable();

                objSql.Execute("SPVRT073_ALTERACAO_CARGO_SALARIO_PR_INCLUIR", lstSqlParameter.ToArray(), null, ref dtRetorno);

            }
            catch (Exception ex)
            {
                return null;
            }

            return dtRetorno;
        }

        public DataTable AlterarAlteracaoCargoSalarior(AlteracaoCargoSalariorVO usuario)
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

                lstSqlParameter.Add(new SqlParameter("@CODIGO_ALTERACAO_CARGO_SALARIO", usuario.CodigoAlteracaoCargoSalario));
                lstSqlParameter.Add(new SqlParameter("@CODIGO_FUNCIONARIO", usuario.CodigoFuncionario));
                lstSqlParameter.Add(new SqlParameter("@DATA", usuario.Data));
                lstSqlParameter.Add(new SqlParameter("@CODIGO_TIPO_CARGO", usuario.CodigoTipoCargo));
                lstSqlParameter.Add(new SqlParameter("@SALARIO", usuario.Salario));
                lstSqlParameter.Add(new SqlParameter("@HORARIO_INICIO", usuario.HorarioInicio));
                lstSqlParameter.Add(new SqlParameter("@HORARIO_FIM", usuario.HorarioFim));

                //TODO: Pegar Usuario da SESSION
                lstSqlParameter.Add(new SqlParameter("@CODIGO_USUARIO_CADASTRO", usuario.CodigoUsuarioCadastro));
                lstSqlParameter.Add(new SqlParameter("@DATA_CADASTRO", usuario.DataCadastro));
                lstSqlParameter.Add(new SqlParameter("@CODIGO_USUARIO_ALTERACAO", usuario.CodigoUsuarioAlteracao));
                lstSqlParameter.Add(new SqlParameter("@DATA_ALTERACAO", usuario.DataAlteracao));
                //lstSqlParameter.Add(new SqlParameter("@CODIGO_STATUS", usuario.CodigoStatus));

                dtRetorno = new DataTable();

                objSql.Execute("SPVRT072_ALTERACAO_CARGO_SALARIO_PR_ALTERAR", lstSqlParameter.ToArray(), null, ref dtRetorno);

            }
            catch (Exception ex)
            {
                return null;
            }

            return dtRetorno;
        }

        public DataTable SelecionarAlteracaoCargoSalarior(AlteracaoCargoSalariorVO usuario)
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

                dtRetorno = new DataTable();

                objSql.Execute("SPVRT074_ALTERACAO_CARGO_SALARIO_PR_SELECIONAR", lstSqlParameter.ToArray(), null, ref dtRetorno);

            }
            catch (Exception ex)
            {
                return null;
            }

            return dtRetorno;
        }
    }
}
