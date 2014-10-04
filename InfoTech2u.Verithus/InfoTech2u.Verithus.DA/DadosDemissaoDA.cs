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
    public class DadosDemissaoDA
    {
        public DataTable IncluirDemissao(DadosDemissaoVO param)
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

                lstSqlParameter.Add(new SqlParameter("@CODIGO_FUNCIONARIO", param.CodigoFuncionario));

                lstSqlParameter.Add(new SqlParameter("@DATA_DEMISSAO", param.DataDemissao));
                lstSqlParameter.Add(new SqlParameter("@DATA_REGISTRO", param.DataRegistro));

                lstSqlParameter.Add(new SqlParameter("@CODIGO_TIPO_CARGO", param.CodigoTipoCargo));
                lstSqlParameter.Add(new SqlParameter("@CODIGO_TIPO_SECAO", param.CodigoTipoSecao));

                lstSqlParameter.Add(new SqlParameter("@SALARIO_INICIAL", param.SalarioInicial));
                lstSqlParameter.Add(new SqlParameter("@COMISSAO", param.Comissao));

                lstSqlParameter.Add(new SqlParameter("@CODIGO_TIPO_TAREFA", param.CodigoTipoTarefa));
                lstSqlParameter.Add(new SqlParameter("@CODIGO_TIPO_FORMA_PAGAMENTO", param.CodigoTipoFormaPagamento));

                lstSqlParameter.Add(new SqlParameter("@CODIGO_FORMA_PAGAMENTO", param.CodigoFormaPagamento));

                lstSqlParameter.Add(new SqlParameter("@CODIGO_USUARIO_CADASTRO", param.CodigoUsuarioCadastro));
                lstSqlParameter.Add(new SqlParameter("@DATA_CADASTRO", param.DataCadastro));
                lstSqlParameter.Add(new SqlParameter("@CODIGO_USUARIO_ALTERACAO", param.CodigoUsuarioAlteracao));
                lstSqlParameter.Add(new SqlParameter("@DATA_ALTERACAO", param.DataAlteracao));
                lstSqlParameter.Add(new SqlParameter("@CODIGO_STATUS", param.CodigoStatus));

                
                dtRetorno = new DataTable();

                objSql.Execute("SPVRT094_DADOS_DEMISSAO_PR_INCLUIR", lstSqlParameter.ToArray(), null, ref dtRetorno);

                
            }
            catch (Exception ex)
            {
                return null;
            }

            return dtRetorno;
        }

        public DataTable AlterarDemissao(DadosDemissaoVO param)
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

                lstSqlParameter.Add(new SqlParameter("@CODIGO_DEMISSAO", param.CodigoDEMISSAO));

                lstSqlParameter.Add(new SqlParameter("@CODIGO_FUNCIONARIO", param.CodigoFuncionario));

                lstSqlParameter.Add(new SqlParameter("@DATA_DEMISSAO", param.DataDemissao));
                lstSqlParameter.Add(new SqlParameter("@DATA_REGISTRO", param.DataRegistro));

                lstSqlParameter.Add(new SqlParameter("@CODIGO_TIPO_CARGO", param.CodigoTipoCargo));
                lstSqlParameter.Add(new SqlParameter("@CODIGO_TIPO_SECAO", param.CodigoTipoSecao));

                lstSqlParameter.Add(new SqlParameter("@SALARIO_INICIAL", param.SalarioInicial));
                lstSqlParameter.Add(new SqlParameter("@COMISSAO", param.Comissao));

                lstSqlParameter.Add(new SqlParameter("@CODIGO_TIPO_TAREFA", param.CodigoTipoTarefa));
                lstSqlParameter.Add(new SqlParameter("@CODIGO_TIPO_FORMA_PAGAMENTO", param.CodigoTipoFormaPagamento));

                lstSqlParameter.Add(new SqlParameter("@CODIGO_FORMA_PAGAMENTO", param.CodigoFormaPagamento));

                lstSqlParameter.Add(new SqlParameter("@CODIGO_USUARIO_CADASTRO", param.CodigoUsuarioCadastro));
                lstSqlParameter.Add(new SqlParameter("@DATA_CADASTRO", param.DataCadastro));
                lstSqlParameter.Add(new SqlParameter("@CODIGO_USUARIO_ALTERACAO", param.CodigoUsuarioAlteracao));
                lstSqlParameter.Add(new SqlParameter("@DATA_ALTERACAO", param.DataAlteracao));
                lstSqlParameter.Add(new SqlParameter("@CODIGO_STATUS", param.CodigoStatus));


                dtRetorno = new DataTable();

                objSql.Execute("SPVRT173_DADOS_DEMISSAO_PR_ALTERAR", lstSqlParameter.ToArray(), null, ref dtRetorno);


            }
            catch (Exception ex)
            {
                return null;
            }

            return dtRetorno;
        }

        public DataTable SelecionarDemissao(DadosDemissaoVO usuario)
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

                objSql.Execute("SPVRT172_DADOS_DEMISSAO_PR_SELECIONAR", lstSqlParameter.ToArray(), null, ref dtRetorno);

            }
            catch (Exception ex)
            {
                return null;
            }

            return dtRetorno;
        }


    }
}
