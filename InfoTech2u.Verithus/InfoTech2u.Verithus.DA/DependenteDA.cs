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
    public class DependenteDA
    {
        public List<DependenteVO> SelecionarDependentesDoFuncionario(FuncionariosVO param)
        {
            InfoTech2uSQLUtil objSql = null;
            List<SqlParameter> lstSqlParameter = null;
            DataTable dtRetorno = null;
            DependenteVO retorno = null;
            List<DependenteVO> listaRetorno = null;

            try
            {
                objSql = new InfoTech2uSQLUtil();
                lstSqlParameter = new List<SqlParameter>();
                dtRetorno = new DataTable();
                listaRetorno = new List<DependenteVO>();

                objSql.Sigla = objSql.GetDataBase();
                objSql.ConnectionString = objSql.GetConnectionString(objSql.Sigla);
                objSql.Open();


                lstSqlParameter.Add(new SqlParameter("@CODIGO_FUNCIONARIO", param.CodigoFuncionario));
                lstSqlParameter.Add(new SqlParameter("@CODIGO_DEPENDENTE", DBNull.Value));


                objSql.Execute("dbo.[SPVRT041_DEPENDENTE_PR_SELECIONAR]", lstSqlParameter.ToArray(), null, ref dtRetorno);

                int i = 0;
                while (i < dtRetorno.Rows.Count)
                {
                    retorno = new DependenteVO();

                    retorno.CodigoDependente = Convert.ToInt32(dtRetorno.Rows[i]["CODIGO_DEPENDENTE"].ToString());
                    retorno.CodigoFuncionario = param.CodigoFuncionario;
                    retorno.Nome = dtRetorno.Rows[i]["Nome"].ToString();

                    if (!String.IsNullOrWhiteSpace(dtRetorno.Rows[i]["CODIGO_TIPO_PARENTESCO"].ToString()))
                        retorno.CodigoTipoParentesco = Convert.ToInt32(dtRetorno.Rows[i]["CODIGO_TIPO_PARENTESCO"].ToString());

                    if (!String.IsNullOrWhiteSpace(dtRetorno.Rows[i]["DATA_NASCIMENTO"].ToString()))
                        retorno.DataCadastro = Convert.ToDateTime(dtRetorno.Rows[i]["DATA_NASCIMENTO"].ToString());

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

        public List<DependenteVO> SelecionarDependentes(DependenteVO param)
        {
            InfoTech2uSQLUtil objSql = null;
            List<SqlParameter> lstSqlParameter = null;
            DataTable dtRetorno = null;
            DependenteVO retorno = null;
            List<DependenteVO> listaRetorno = null;

            try
            {
                objSql = new InfoTech2uSQLUtil();
                lstSqlParameter = new List<SqlParameter>();
                dtRetorno = new DataTable();
                listaRetorno = new List<DependenteVO>();

                objSql.Sigla = objSql.GetDataBase();
                objSql.ConnectionString = objSql.GetConnectionString(objSql.Sigla);
                objSql.Open();


                lstSqlParameter.Add(new SqlParameter("@CODIGO_FUNCIONARIO", DBNull.Value));

                if(param.CodigoDependente == null)
                    lstSqlParameter.Add(new SqlParameter("@CODIGO_DEPENDENTE", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@CODIGO_DEPENDENTE", param.CodigoDependente));


                objSql.Execute("dbo.[SPVRT041_DEPENDENTE_PR_SELECIONAR]", lstSqlParameter.ToArray(), null, ref dtRetorno);

                int i = 0;
                while (i < dtRetorno.Rows.Count)
                {
                    retorno = new DependenteVO();

                    retorno.CodigoDependente = Convert.ToInt32(dtRetorno.Rows[i]["CODIGO_DEPENDENTE"].ToString());
                    retorno.CodigoFuncionario = param.CodigoFuncionario;
                    retorno.Nome = dtRetorno.Rows[i]["Nome"].ToString();

                    if (!String.IsNullOrWhiteSpace(dtRetorno.Rows[i]["CODIGO_TIPO_PARENTESCO"].ToString()))
                        retorno.CodigoTipoParentesco = Convert.ToInt32(dtRetorno.Rows[i]["CODIGO_TIPO_PARENTESCO"].ToString());

                    if (!String.IsNullOrWhiteSpace(dtRetorno.Rows[i]["DATA_NASCIMENTO"].ToString()))
                        retorno.DataCadastro = Convert.ToDateTime(dtRetorno.Rows[i]["DATA_NASCIMENTO"].ToString());

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

        public List<DependenteVO> SelecionarDependentesLista()
        {
            InfoTech2uSQLUtil objSql = null;
            List<SqlParameter> lstSqlParameter = null;
            DataTable dtRetorno = null;
            DependenteVO retorno = null;
            List<DependenteVO> listaRetorno = null;

            try
            {
                objSql = new InfoTech2uSQLUtil();
                lstSqlParameter = new List<SqlParameter>();
                dtRetorno = new DataTable();
                listaRetorno = new List<DependenteVO>();

                objSql.Sigla = objSql.GetDataBase();
                objSql.ConnectionString = objSql.GetConnectionString(objSql.Sigla);
                objSql.Open();


                lstSqlParameter.Add(new SqlParameter("@CODIGO_FUNCIONARIO", DBNull.Value));
                lstSqlParameter.Add(new SqlParameter("@CODIGO_DEPENDENTE", DBNull.Value));


                objSql.Execute("dbo.[SPVRT041_DEPENDENTE_PR_SELECIONAR]", lstSqlParameter.ToArray(), null, ref dtRetorno);

                int i = 0;
                while (i < dtRetorno.Rows.Count)
                {
                    retorno = new DependenteVO();

                    retorno.CodigoDependente = Convert.ToInt32(dtRetorno.Rows[i]["CODIGO_DEPENDENTE"].ToString());
                    
                    retorno.Nome = dtRetorno.Rows[i]["Nome"].ToString();

                    if (!String.IsNullOrWhiteSpace(dtRetorno.Rows[i]["CODIGO_TIPO_PARENTESCO"].ToString()))
                        retorno.CodigoTipoParentesco = Convert.ToInt32(dtRetorno.Rows[i]["CODIGO_TIPO_PARENTESCO"].ToString());

                    if (!String.IsNullOrWhiteSpace(dtRetorno.Rows[i]["DATA_NASCIMENTO"].ToString()))
                        retorno.DataCadastro = Convert.ToDateTime(dtRetorno.Rows[i]["DATA_NASCIMENTO"].ToString());

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
    }
}
