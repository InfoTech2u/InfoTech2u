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
        public DataTable SelecionarDependentesDoFuncionario(FuncionariosVO param)
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
                lstSqlParameter.Add(new SqlParameter("@CODIGO_DEPENDENTE", DBNull.Value));


                objSql.Execute("dbo.[SPVRT041_DEPENDENTE_PR_SELECIONAR]", lstSqlParameter.ToArray(), null, ref dtRetorno);


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

        public DataTable IncluirDependente(DependenteVO param)
        {
            InfoTech2uSQLUtil objSql = null;
            List<SqlParameter> lstSqlParameter = null;
            DataTable dtRetornoDependente = null;
            DataTable dtRetornoExcluir = null;
            SqlTransaction transaction = null;


            try
            {
                objSql = new InfoTech2uSQLUtil();
                dtRetornoDependente = new DataTable();
                int rowsAffected = 0;

                objSql.Sigla = objSql.GetDataBase();
                objSql.ConnectionString = objSql.GetConnectionString(objSql.Sigla);
                objSql.Open();
                transaction = objSql.GetConnection().BeginTransaction();
                
                lstSqlParameter = new List<SqlParameter>();
               
                lstSqlParameter.Add(new SqlParameter("@CODIGO_FUNCIONARIO", param.CodigoFuncionario));
                lstSqlParameter.Add(new SqlParameter("@NOME", param.Nome));
                lstSqlParameter.Add(new SqlParameter("@CODIGO_STATUS", param.CodigoStatus));
                lstSqlParameter.Add(new SqlParameter("@CODIGO_TIPO_PARENTESCO", param.CodigoTipoParentesco));
                lstSqlParameter.Add(new SqlParameter("@CODIGO_USUARIO_ALTERACAO", param.CodigoUsuarioAlteracao));
                lstSqlParameter.Add(new SqlParameter("@CODIGO_USUARIO_CADASTRO", param.CodigoUsuarioCadastro));
                lstSqlParameter.Add(new SqlParameter("@DATA_ALTERACAO", param.DataAlteracao));
                lstSqlParameter.Add(new SqlParameter("@DATA_CADASTRO", param.DataCadastro));
                lstSqlParameter.Add(new SqlParameter("@DATA_NASCIMENTO", param.DataNascimento));

                objSql.Execute("SPVRT042_DEPENDENTE_PR_INCLUIR", lstSqlParameter.ToArray(), transaction, ref dtRetornoDependente);

                if (dtRetornoDependente != null && dtRetornoDependente.Rows.Count > 0)
                {
                    param.CodigoDependente = Convert.ToInt32(dtRetornoDependente.Rows[0]["CODIGO_DEPENDENTE"]);
                    lstSqlParameter = new List<SqlParameter>();
                    lstSqlParameter.Add(new SqlParameter("@CODIGO_DEPENDENTE", param.CodigoDependente));
                    dtRetornoExcluir = new DataTable();

                    //Exclui todos benefícios do dependente caso exista
                    objSql.Execute("SPVRT052_BENEFICIO_PR_EXCLUIR", lstSqlParameter.ToArray(), transaction, ref dtRetornoExcluir);

                    //Verifica se exclusao ocorreu com sucesso
                    if (dtRetornoExcluir != null && dtRetornoExcluir.Rows.Count > 0 && Convert.ToInt32(dtRetornoExcluir.Rows[0]["Mensagem"]) == 100)
                    {
                        transaction.Rollback();
                        return new DataTable();
                    }

                    if (param.BeneficioVO.Count > 0)
                    {
                        foreach (var item in param.BeneficioVO)
                        {
                            rowsAffected = 0;
                            lstSqlParameter = new List<SqlParameter>();
                            lstSqlParameter.Add(new SqlParameter("@CODIGO_TIPO_BENEFICIO", item.TipoBeneficio.CodigoTipoBeneficio));
                            lstSqlParameter.Add(new SqlParameter("@CODIGO_DEPENDENTE", param.CodigoDependente));

                            objSql.ExecuteNonQuery("SPVRT049_BENEFICIO_PR_INCLUIR", lstSqlParameter.ToArray(), transaction, out rowsAffected);

                            if (rowsAffected <= 0)
                            {
                                transaction.Rollback();
                                return new DataTable();
                            }

                        }
                    }
                }
                transaction.Commit();

                return dtRetornoDependente;
            }
            catch (Exception)
            {
                transaction.Rollback();
                return new DataTable();
            }
            finally
            {
                objSql = null;
                lstSqlParameter = null;
                dtRetornoDependente = null;
                dtRetornoExcluir = null;
                transaction = null;
            }

        }


        public DataTable SelecionarDependente(DependenteVO param)
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


                lstSqlParameter.Add(new SqlParameter("@CODIGO_FUNCIONARIO", DBNull.Value));
                lstSqlParameter.Add(new SqlParameter("@CODIGO_DEPENDENTE", param.CodigoDependente));


                objSql.Execute("dbo.[SPVRT041_DEPENDENTE_PR_SELECIONAR]", lstSqlParameter.ToArray(), null, ref dtRetorno);


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
                    
        public DataTable AlterarDependente(DependenteVO param)
        {
            InfoTech2uSQLUtil objSql = null;
            List<SqlParameter> lstSqlParameter = null;
            DataTable dtRetornoDependente = null;
            DataTable dtRetornoExcluir = null;
            SqlTransaction transaction = null;


            try
            {
                objSql = new InfoTech2uSQLUtil();
                dtRetornoDependente = new DataTable();
                int rowsAffected = 0;

                objSql.Sigla = objSql.GetDataBase();
                objSql.ConnectionString = objSql.GetConnectionString(objSql.Sigla);
                objSql.Open();
                transaction = objSql.GetConnection().BeginTransaction();

                lstSqlParameter = new List<SqlParameter>();

                lstSqlParameter.Add(new SqlParameter("@CODIGO_DEPENDENTE", param.CodigoDependente));
                lstSqlParameter.Add(new SqlParameter("@NOME", param.Nome));
                lstSqlParameter.Add(new SqlParameter("@CODIGO_STATUS", param.CodigoStatus));
                lstSqlParameter.Add(new SqlParameter("@CODIGO_TIPO_PARENTESCO", param.CodigoTipoParentesco));
                lstSqlParameter.Add(new SqlParameter("@CODIGO_USUARIO_ALTERACAO", param.CodigoUsuarioAlteracao));
                lstSqlParameter.Add(new SqlParameter("@DATA_ALTERACAO", param.DataAlteracao));
                lstSqlParameter.Add(new SqlParameter("@DATA_NASCIMENTO", param.DataNascimento));

                objSql.Execute("SPVRT043_DEPENDENTE_PR_ALTERAR", lstSqlParameter.ToArray(), transaction, ref dtRetornoDependente);

                if (dtRetornoDependente != null && dtRetornoDependente.Rows.Count > 0)
                {
                    lstSqlParameter = new List<SqlParameter>();
                    lstSqlParameter.Add(new SqlParameter("@CODIGO_DEPENDENTE", param.CodigoDependente));
                    dtRetornoExcluir = new DataTable();

                    //Exclui todos benefícios do dependente caso exista
                    objSql.Execute("SPVRT052_BENEFICIO_PR_EXCLUIR", lstSqlParameter.ToArray(), transaction, ref dtRetornoExcluir);

                    //Verifica se exclusao ocorreu com sucesso
                    if (dtRetornoExcluir != null && dtRetornoExcluir.Rows.Count > 0 && Convert.ToInt32(dtRetornoExcluir.Rows[0]["Mensagem"]) == 100)
                    {
                        transaction.Rollback();
                        return new DataTable();
                }

                    if (param.BeneficioVO.Count > 0)
                    {
                        foreach (var item in param.BeneficioVO)
                        {
                            rowsAffected = 0;
                            lstSqlParameter = new List<SqlParameter>();
                            lstSqlParameter.Add(new SqlParameter("@CODIGO_TIPO_BENEFICIO", item.TipoBeneficio.CodigoTipoBeneficio));
                            lstSqlParameter.Add(new SqlParameter("@CODIGO_DEPENDENTE", param.CodigoDependente));

                            objSql.ExecuteNonQuery("SPVRT049_BENEFICIO_PR_INCLUIR", lstSqlParameter.ToArray(), transaction, out rowsAffected);

                            if (rowsAffected <= 0)
                            {
                                transaction.Rollback();
                                return new DataTable();
            }

                        }
                    }
                    transaction.Commit();
                }
               

                return dtRetornoDependente;
            }
            catch (Exception)
            {
                transaction.Rollback();
                return new DataTable();
            }
            finally
            {
                objSql = null;
                lstSqlParameter = null;
                dtRetornoDependente = null;
                dtRetornoExcluir = null;
                transaction = null;
            }
        }

        public bool ExcluirDependente(DependenteVO param)
        {
            InfoTech2uSQLUtil objSql = null;
            List<SqlParameter> lstSqlParameter = null;
            DataTable dtRetorno = null;
            SqlTransaction transaction = null;


            try
            {
                objSql = new InfoTech2uSQLUtil();
                int rowsAffected = 0;

                objSql.Sigla = objSql.GetDataBase();
                objSql.ConnectionString = objSql.GetConnectionString(objSql.Sigla);
                objSql.Open();
                transaction = objSql.GetConnection().BeginTransaction();

                lstSqlParameter = new List<SqlParameter>();
                lstSqlParameter.Add(new SqlParameter("@CODIGO_DEPENDENTE", param.CodigoDependente));
                dtRetorno = new DataTable();

                //Exclui todos benefícios do dependente caso exista
                objSql.Execute("SPVRT052_BENEFICIO_PR_EXCLUIR", lstSqlParameter.ToArray(), transaction, ref dtRetorno);

                //Verifica se exclusao ocorreu com sucesso
                if (dtRetorno != null && dtRetorno.Rows.Count > 0 && Convert.ToInt32(dtRetorno.Rows[0]["Mensagem"]) == 100)
                {
                    transaction.Rollback();
                    return false;
                }

                lstSqlParameter = new List<SqlParameter>();

                lstSqlParameter.Add(new SqlParameter("@CODIGO_DEPENDENTE", param.CodigoDependente));

                rowsAffected = 0;
                objSql.ExecuteNonQuery("SPVRT044_DEPENDENTE_PR_EXCLUIR", lstSqlParameter.ToArray(), transaction, out rowsAffected);

                if (rowsAffected <= 0)
                {
                    transaction.Rollback();
                    return false;
                }

                transaction.Commit();
                return true;
            }
            catch (Exception)
            {
                transaction.Rollback();
                return false;
            }
            finally
            {
                objSql = null;
                lstSqlParameter = null;
                dtRetorno.Dispose();
                transaction.Dispose();
            }
        }
    }
}
