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
    public class EmpresaDA
    {
        public DataTable IncluirEmpresa(EmpresaVO usuario)
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

                if (usuario.CodigoEmpresa == null || usuario.CodigoEmpresa == 0)
                    lstSqlParameter.Add(new SqlParameter("@CODIGO_EMPRESA", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@CODIGO_EMPRESA", usuario.CodigoEmpresa));

                if (usuario.CNJP == null || String.IsNullOrWhiteSpace(usuario.CNJP))
                    lstSqlParameter.Add(new SqlParameter("@CNJP", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@CNJP", usuario.CNJP));

                if (usuario.RazaoSocial == null || String.IsNullOrWhiteSpace(usuario.RazaoSocial))
                    lstSqlParameter.Add(new SqlParameter("@RAZAO_SOCIAL", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@RAZAO_SOCIAL", usuario.RazaoSocial));

                if (usuario.NomeFantasia == null || String.IsNullOrWhiteSpace(usuario.NomeFantasia))
                    lstSqlParameter.Add(new SqlParameter("@NOME_FANTASIA", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@NOME_FANTASIA", usuario.NomeFantasia));

                if (usuario.InscricaoEstadual == null || String.IsNullOrWhiteSpace(usuario.InscricaoEstadual))
                    lstSqlParameter.Add(new SqlParameter("@INCRICAO_ESTADUAL", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@INCRICAO_ESTADUAL", usuario.InscricaoEstadual));

                if (usuario.CodigoUsuarioCadastro == null || String.IsNullOrWhiteSpace(usuario.CodigoUsuarioCadastro.ToString()))
                    lstSqlParameter.Add(new SqlParameter("@CODIGO_USUARIO_CADASTRO", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@CODIGO_USUARIO_CADASTRO", usuario.CodigoUsuarioCadastro));

                if (usuario.DataCadastro == null || String.IsNullOrWhiteSpace(usuario.DataCadastro.ToString()))
                    lstSqlParameter.Add(new SqlParameter("@DATA_CADASTRO", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@DATA_CADASTRO", usuario.DataCadastro));

                if (usuario.CodigoUsuarioAlteracao == null || String.IsNullOrWhiteSpace(usuario.CodigoUsuarioAlteracao.ToString()))
                    lstSqlParameter.Add(new SqlParameter("@CODIGO_USUARIO_ALTERACAO", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@CODIGO_USUARIO_ALTERACAO", usuario.CodigoUsuarioAlteracao));

                if (usuario.DataAlteracao == null || String.IsNullOrWhiteSpace(usuario.DataAlteracao.ToString()))
                    lstSqlParameter.Add(new SqlParameter("@DATA_ALTERACAO", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@DATA_ALTERACAO", usuario.DataAlteracao));

                if (usuario.CodigoStatus == null || String.IsNullOrWhiteSpace(usuario.CodigoStatus.ToString()))
                    lstSqlParameter.Add(new SqlParameter("@CODIGO_STATUS", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@CODIGO_STATUS", usuario.CodigoStatus));

                dtRetorno = new DataTable();

                objSql.Execute("SPVRT175_EMPRESA_PR_INCLUIR", lstSqlParameter.ToArray(), null, ref dtRetorno);

            }
            catch (Exception ex)
            {
                return null;
            }

            return dtRetorno;
        }

        public DataTable AlterarEmpresa(EmpresaVO usuario)
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

                if (usuario.CodigoEmpresa == null || usuario.CodigoEmpresa == 0)
                    lstSqlParameter.Add(new SqlParameter("@CODIGO_EMPRESA", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@CODIGO_EMPRESA", usuario.CodigoEmpresa));

                if (usuario.CNJP == null || String.IsNullOrWhiteSpace(usuario.CNJP))
                    lstSqlParameter.Add(new SqlParameter("@CNJP", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@CNJP", usuario.CNJP));

                if (usuario.RazaoSocial == null || String.IsNullOrWhiteSpace(usuario.RazaoSocial))
                    lstSqlParameter.Add(new SqlParameter("@RAZAO_SOCIAL", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@RAZAO_SOCIAL", usuario.RazaoSocial));

                if (usuario.NomeFantasia == null || String.IsNullOrWhiteSpace(usuario.NomeFantasia))
                    lstSqlParameter.Add(new SqlParameter("@NOME_FANTASIA", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@NOME_FANTASIA", usuario.NomeFantasia));

                if (usuario.InscricaoEstadual == null || String.IsNullOrWhiteSpace(usuario.InscricaoEstadual))
                    lstSqlParameter.Add(new SqlParameter("@INCRICAO_ESTADUAL", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@INCRICAO_ESTADUAL", usuario.InscricaoEstadual));

                if (usuario.CodigoUsuarioCadastro == null || String.IsNullOrWhiteSpace(usuario.CodigoUsuarioCadastro.ToString()))
                    lstSqlParameter.Add(new SqlParameter("@CODIGO_USUARIO_CADASTRO", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@CODIGO_USUARIO_CADASTRO", usuario.CodigoUsuarioCadastro));

                if (usuario.DataCadastro == null || String.IsNullOrWhiteSpace(usuario.DataCadastro.ToString()))
                    lstSqlParameter.Add(new SqlParameter("@DATA_CADASTRO", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@DATA_CADASTRO", usuario.DataCadastro));

                if (usuario.CodigoUsuarioAlteracao == null || String.IsNullOrWhiteSpace(usuario.CodigoUsuarioAlteracao.ToString()))
                    lstSqlParameter.Add(new SqlParameter("@CODIGO_USUARIO_ALTERACAO", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@CODIGO_USUARIO_ALTERACAO", usuario.CodigoUsuarioAlteracao));

                if (usuario.DataAlteracao == null || String.IsNullOrWhiteSpace(usuario.DataAlteracao.ToString()))
                    lstSqlParameter.Add(new SqlParameter("@DATA_ALTERACAO", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@DATA_ALTERACAO", usuario.DataAlteracao));

                if (usuario.CodigoStatus == null || String.IsNullOrWhiteSpace(usuario.CodigoStatus.ToString()))
                    lstSqlParameter.Add(new SqlParameter("@CODIGO_STATUS", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@CODIGO_STATUS", usuario.CodigoStatus));

                dtRetorno = new DataTable();

                objSql.Execute("SPVRT176_EMPRESA_PR_ALTERAR", lstSqlParameter.ToArray(), null, ref dtRetorno);

            }
            catch (Exception ex)
            {
                return null;
            }

            return dtRetorno;
        }

        public DataTable ExcluirEmpresa(EmpresaVO usuario)
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

                if (usuario.CodigoEmpresa == null || usuario.CodigoEmpresa == 0)
                    lstSqlParameter.Add(new SqlParameter("@CODIGO_EMPRESA", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@CODIGO_EMPRESA", usuario.CodigoEmpresa));

                //TODO: Pegar Usuario da SESSION

                if (usuario.CodigoUsuarioAlteracao == null || String.IsNullOrWhiteSpace(usuario.CodigoUsuarioAlteracao.ToString()))
                    lstSqlParameter.Add(new SqlParameter("@CODIGO_USUARIO_ALTERACAO", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@CODIGO_USUARIO_ALTERACAO", usuario.CodigoUsuarioAlteracao));

                dtRetorno = new DataTable();

                objSql.Execute("SPVRT177_EMPRESA_PR_EXCLUIR", lstSqlParameter.ToArray(), null, ref dtRetorno);

            }
            catch (Exception ex)
            {
                return null;
            }

            return dtRetorno;
        }

        public DataTable SelecionarEmpresa(EmpresaVO usuario)
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

                if (usuario.CodigoEmpresa == null || usuario.CodigoEmpresa == 0)
                    lstSqlParameter.Add(new SqlParameter("@CODIGO_EMPRESA", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@CODIGO_EMPRESA", usuario.CodigoEmpresa));

                if (usuario.CNJP == null || String.IsNullOrWhiteSpace(usuario.CNJP))
                    lstSqlParameter.Add(new SqlParameter("@CNJP", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@CNJP", usuario.CNJP));

                if (usuario.RazaoSocial == null || String.IsNullOrWhiteSpace(usuario.RazaoSocial))
                    lstSqlParameter.Add(new SqlParameter("@RAZAO_SOCIAL", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@RAZAO_SOCIAL", usuario.RazaoSocial));

                if (usuario.NomeFantasia == null || String.IsNullOrWhiteSpace(usuario.NomeFantasia))
                    lstSqlParameter.Add(new SqlParameter("@NOME_FANTASIA", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@NOME_FANTASIA", usuario.NomeFantasia));

                if (usuario.InscricaoEstadual == null || String.IsNullOrWhiteSpace(usuario.InscricaoEstadual))
                    lstSqlParameter.Add(new SqlParameter("@INCRICAO_ESTADUAL", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@INCRICAO_ESTADUAL", usuario.InscricaoEstadual));

                if (usuario.CodigoStatus == null || String.IsNullOrWhiteSpace(usuario.CodigoStatus.ToString()))
                    lstSqlParameter.Add(new SqlParameter("@CODIGO_STATUS", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@CODIGO_STATUS", usuario.CodigoStatus));

                dtRetorno = new DataTable();

                objSql.Execute("SPVRT174_EMPRESA_PR_SELECIONAR", lstSqlParameter.ToArray(), null, ref dtRetorno);

            }
            catch (Exception ex)
            {
                return null;
            }

            return dtRetorno;
        }
    }
}
