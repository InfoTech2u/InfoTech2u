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
    public class DadosAdmissaoDA
    {
        public DataTable IncluirAdmissao(DadosAdmissaoVO usuario)
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

                lstSqlParameter.Add(new SqlParameter("@CODIGO_ADMISSAO", usuario.CodigoAdmissao));
                lstSqlParameter.Add(new SqlParameter("@CODIGO_FUNCIONARIO", usuario.CodigoFuncionario));
                lstSqlParameter.Add(new SqlParameter("@DATA_ADMISSAO", usuario.DataAdmissao));
                lstSqlParameter.Add(new SqlParameter("@DATA_REGISTRO", usuario.DataRegistro));
                lstSqlParameter.Add(new SqlParameter("@CODIGO_TIPO_CARGO", usuario.CodigoTipoCargo));
                lstSqlParameter.Add(new SqlParameter("@CODIGO_TIPO_SECAO", usuario.CodigoTipoSecao));
                lstSqlParameter.Add(new SqlParameter("@SALARIO_INICIAL", usuario.SalarioInicial));
                lstSqlParameter.Add(new SqlParameter("@COMISSAO", usuario.Comissao));
                lstSqlParameter.Add(new SqlParameter("@CODIGO_TIPO_TAREFA", usuario.CodigoTipoTarefa));
                lstSqlParameter.Add(new SqlParameter("@CODIGO_TIPO_FORMA_PAGAMENTO", usuario.CodigoTipoFormaPagamento));
                lstSqlParameter.Add(new SqlParameter("@HORARIO_TRABALHO_INICIO", usuario.HorarioTrabalhoInicio));
                lstSqlParameter.Add(new SqlParameter("@HORARIO_TRABALHO_FIM", usuario.HorarioTrabalhoFim));
                lstSqlParameter.Add(new SqlParameter("@INTERVALO_ALMOCO_INICIO", usuario.IntervaloAlmocoInicio));
                lstSqlParameter.Add(new SqlParameter("@INTERVALO_ALMOCO_FIM", usuario.IntervaloAlmocoFim));
                lstSqlParameter.Add(new SqlParameter("@DESCANSO_SEMANAL_INICIO", usuario.DescansoSemanalInicio));
                lstSqlParameter.Add(new SqlParameter("@DESCANSO_SEMANAL_FIM", usuario.DescansoSemanalFim));

                //TODO: Pegar Usuario da SESSION
                lstSqlParameter.Add(new SqlParameter("@CODIGO_USUARIO_CADASTRO", usuario.CodigoUsuarioCadastro));
                lstSqlParameter.Add(new SqlParameter("@DATA_CADASTRO", usuario.DataCadastro));
                lstSqlParameter.Add(new SqlParameter("@CODIGO_USUARIO_ALTERACAO", usuario.CodigoUsuarioAlteracao));
                lstSqlParameter.Add(new SqlParameter("@DATA_ALTERACAO", usuario.DataAlteracao));
                //lstSqlParameter.Add(new SqlParameter("@CODIGO_STATUS", usuario.CodigoStatus));

                dtRetorno = new DataTable();

                objSql.Execute("SPVRT169_DADOS_ADMISSAO_PR_INCLUIR", lstSqlParameter.ToArray(), null, ref dtRetorno);

            }
            catch (Exception ex)
            {
                return null;
            }

            return dtRetorno;
        }

        public DataTable AlterarAdmissao(DadosAdmissaoVO usuario)
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

                lstSqlParameter.Add(new SqlParameter("@CODIGO_ADMISSAO", usuario.CodigoAdmissao));
                lstSqlParameter.Add(new SqlParameter("@CODIGO_FUNCIONARIO", usuario.CodigoFuncionario));
                lstSqlParameter.Add(new SqlParameter("@DATA_ADMISSAO", usuario.DataAdmissao));
                lstSqlParameter.Add(new SqlParameter("@DATA_REGISTRO", usuario.DataRegistro));
                lstSqlParameter.Add(new SqlParameter("@CODIGO_TIPO_CARGO", usuario.CodigoTipoCargo));
                lstSqlParameter.Add(new SqlParameter("@CODIGO_TIPO_SECAO", usuario.CodigoTipoSecao));
                lstSqlParameter.Add(new SqlParameter("@SALARIO_INICIAL", usuario.SalarioInicial));
                lstSqlParameter.Add(new SqlParameter("@COMISSAO", usuario.Comissao));
                lstSqlParameter.Add(new SqlParameter("@CODIGO_TIPO_TAREFA", usuario.CodigoTipoTarefa));
                lstSqlParameter.Add(new SqlParameter("@CODIGO_TIPO_FORMA_PAGAMENTO", usuario.CodigoTipoFormaPagamento));
                lstSqlParameter.Add(new SqlParameter("@HORARIO_TRABALHO_INICIO", usuario.HorarioTrabalhoInicio));
                lstSqlParameter.Add(new SqlParameter("@HORARIO_TRABALHO_FIM", usuario.IntervaloAlmocoFim));
                lstSqlParameter.Add(new SqlParameter("@INTERVALO_ALMOCO_INICIO", usuario.IntervaloAlmocoInicio));
                lstSqlParameter.Add(new SqlParameter("@INTERVALO_ALMOCO_FIM", usuario.IntervaloAlmocoFim));
                lstSqlParameter.Add(new SqlParameter("@DESCANSO_SEMANAL_INICIO", usuario.DescansoSemanalInicio));
                lstSqlParameter.Add(new SqlParameter("@DESCANSO_SEMANAL_FIM", usuario.DescansoSemanalFim));

                //TODO: Pegar Usuario da SESSION
                lstSqlParameter.Add(new SqlParameter("@CODIGO_USUARIO_CADASTRO", usuario.CodigoUsuarioCadastro));
                lstSqlParameter.Add(new SqlParameter("@DATA_CADASTRO", usuario.DataCadastro));
                lstSqlParameter.Add(new SqlParameter("@CODIGO_USUARIO_ALTERACAO", usuario.CodigoUsuarioAlteracao));
                lstSqlParameter.Add(new SqlParameter("@DATA_ALTERACAO", usuario.DataAlteracao));
                //lstSqlParameter.Add(new SqlParameter("@CODIGO_STATUS", usuario.CodigoStatus));

                dtRetorno = new DataTable();

                objSql.Execute("SPVRT170_DADOS_ADMISSAO_PR_ALTERAR", lstSqlParameter.ToArray(), null, ref dtRetorno);

            }
            catch (Exception ex)
            {
                return null;
            }

            return dtRetorno;
        }

        public DataTable SelecionarAdmissao(DadosAdmissaoVO usuario)
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

                objSql.Execute("SPVRT171_DADOS_ADMISSAO_PR_SELECIONAR", lstSqlParameter.ToArray(), null, ref dtRetorno);

            }
            catch (Exception ex)
            {
                return null;
            }

            return dtRetorno;
        }
    }
}
