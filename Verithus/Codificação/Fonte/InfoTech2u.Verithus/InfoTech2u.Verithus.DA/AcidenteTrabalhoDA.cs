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
    public class AcidenteTrabalhoDA
    {
        public DataTable IncluirAcidenteTrabalho(AcidenteTrabalhoVO usuario)
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

                lstSqlParameter.Add(new SqlParameter("@CODIGO_ACIDENTE_TRABALHO", usuario.CodigoAcidenteTrabalho));
                lstSqlParameter.Add(new SqlParameter("@CODIGO_FUNCIONARIO", usuario.CodigoFuncionario));
                lstSqlParameter.Add(new SqlParameter("@DATA", usuario.Data));
                lstSqlParameter.Add(new SqlParameter("@ACIDENTE_TRABALHO_LOCAL", usuario.Local));
                lstSqlParameter.Add(new SqlParameter("@CAUSA", usuario.Causa));
                lstSqlParameter.Add(new SqlParameter("@DATA_ALTA", usuario.DataAlta));
                lstSqlParameter.Add(new SqlParameter("@RESULTADO", usuario.Resultado));
                lstSqlParameter.Add(new SqlParameter("@OBSERVACOES", usuario.Observacoes));
                
                //TODO: Pegar Usuario da SESSION
                lstSqlParameter.Add(new SqlParameter("@CODIGO_USUARIO_CADASTRO", usuario.CodigoUsuarioCadastro));
                lstSqlParameter.Add(new SqlParameter("@DATA_CADASTRO", usuario.DataCadastro));
                lstSqlParameter.Add(new SqlParameter("@CODIGO_USUARIO_ALTERACAO", usuario.CodigoUsuarioAlteracao));
                lstSqlParameter.Add(new SqlParameter("@DATA_ALTERACAO", usuario.DataAlteracao));
                //lstSqlParameter.Add(new SqlParameter("@CODIGO_STATUS", usuario.CodigoStatus));

                dtRetorno = new DataTable();

                objSql.Execute("SPVRT070_ACIDENTE_TRABALHO_PR_INCLUIR", lstSqlParameter.ToArray(), null, ref dtRetorno);

            }
            catch (Exception ex)
            {
                return null;
            }

            return dtRetorno;
        }

        public DataTable AlterarAcidenteTrabalho(AcidenteTrabalhoVO usuario)
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

                lstSqlParameter.Add(new SqlParameter("@CODIGO_ACIDENTE_TRABALHO", usuario.CodigoAcidenteTrabalho));
                lstSqlParameter.Add(new SqlParameter("@CODIGO_FUNCIONARIO", usuario.CodigoFuncionario));
                lstSqlParameter.Add(new SqlParameter("@DATA", usuario.Data));
                lstSqlParameter.Add(new SqlParameter("@ACIDENTE_TRABALHO_LOCAL", usuario.Local));
                lstSqlParameter.Add(new SqlParameter("@CAUSA", usuario.Causa));
                lstSqlParameter.Add(new SqlParameter("@DATA_ALTA", usuario.DataAlta));
                lstSqlParameter.Add(new SqlParameter("@RESULTADO", usuario.Resultado));
                lstSqlParameter.Add(new SqlParameter("@OBSERVACOES", usuario.Observacoes));

                //TODO: Pegar Usuario da SESSION
                lstSqlParameter.Add(new SqlParameter("@CODIGO_USUARIO_CADASTRO", usuario.CodigoUsuarioCadastro));
                lstSqlParameter.Add(new SqlParameter("@DATA_CADASTRO", usuario.DataCadastro));
                lstSqlParameter.Add(new SqlParameter("@CODIGO_USUARIO_ALTERACAO", usuario.CodigoUsuarioAlteracao));
                lstSqlParameter.Add(new SqlParameter("@DATA_ALTERACAO", usuario.DataAlteracao));
                //lstSqlParameter.Add(new SqlParameter("@CODIGO_STATUS", usuario.CodigoStatus));

                dtRetorno = new DataTable();

                objSql.Execute("SPVRT069_ACIDENTE_TRABALHO_PR_ALTERAR", lstSqlParameter.ToArray(), null, ref dtRetorno);

            }
            catch (Exception ex)
            {
                return null;
            }

            return dtRetorno;
        }

        public DataTable SelecionarAcidenteTrabalho(AcidenteTrabalhoVO usuario)
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

                objSql.Execute("SPVRT071_ACIDENTE_TRABALHO_PR_SELECIONAR", lstSqlParameter.ToArray(), null, ref dtRetorno);

            }
            catch (Exception ex)
            {
                return null;
            }

            return dtRetorno;
        }
    }
}
