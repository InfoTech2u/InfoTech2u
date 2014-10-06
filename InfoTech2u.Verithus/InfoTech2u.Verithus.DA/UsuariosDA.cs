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
    public class UsuariosDA
    {
        public DataTable SelecionarUsuario(UsuariosVO param)
        {
            InfoTech2uSQLUtil objSql = new InfoTech2uSQLUtil();
            List<SqlParameter> lstSqlParameter = new List<SqlParameter>();
            DataTable dtRetorno = new DataTable();

            try
            {
                objSql.Sigla = objSql.GetDataBase();
                objSql.ConnectionString = objSql.GetConnectionString(objSql.Sigla);
                objSql.Open();

                if (param.CodigoUsuario == null)
                    lstSqlParameter.Add(new SqlParameter("@CODIGO_USUARIO", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@CODIGO_USUARIO", param.CodigoUsuario));


                objSql.Execute("dbo.[SPVRT001_USUARIOS_PR_SELECIONAR]", lstSqlParameter.ToArray(), null, ref dtRetorno);

                //DataSet ds = dtRetorno;

                //string xmlRetorno = ds.GetXml();

                //xmlRetorno = xmlRetorno.Replace("NewDataSet", "usuario");
                //xmlRetorno = xmlRetorno.Replace("Table", "row");

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
                param = null;
            }
        }

        public List<UsuariosVO> SelecionarUsuarioLista(UsuariosVO param)
        {

            List<UsuariosVO> listaRetorno = new List<UsuariosVO>();
            UsuariosVO retorno;
            InfoTech2uSQLUtil objSql = new InfoTech2uSQLUtil();
            List<SqlParameter> lstSqlParameter = new List<SqlParameter>();
            //DataSet dtRetorno = new DataSet();
            DataTable dtRetorno = new DataTable();

            try
            {
                objSql.Sigla = objSql.GetDataBase();
                objSql.ConnectionString = objSql.GetConnectionString(objSql.Sigla);
                objSql.Open();

                if (param.CodigoUsuario == null)
                    lstSqlParameter.Add(new SqlParameter("@CODIGO_USUARIO", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@CODIGO_USUARIO", param.CodigoUsuario));


                objSql.Execute("dbo.[SPVRT001_USUARIOS_PR_SELECIONAR]", lstSqlParameter.ToArray(), null, ref dtRetorno);


                DataTable dt = dtRetorno;

                int i = 0;
                while (i < dtRetorno.Rows.Count)
                {


                    retorno = new UsuariosVO();

                    TipoAcessoVO tipoAcesso = new TipoAcessoVO();

                    retorno.CodigoUsuario = Convert.ToInt32(dtRetorno.Rows[i]["CODIGO_USUARIO"].ToString());

                    retorno.Nome = string.IsNullOrWhiteSpace(dtRetorno.Rows[i]["NOME"].ToString()) ? null : dtRetorno.Rows[i]["NOME"].ToString();
                    retorno.Mail = string.IsNullOrWhiteSpace(dtRetorno.Rows[i]["MAIL"].ToString()) ? null : dtRetorno.Rows[i]["MAIL"].ToString();
                    retorno.LoginUsuario = string.IsNullOrWhiteSpace(dtRetorno.Rows[i]["LOGIN_USUARIO"].ToString()) ? null : dtRetorno.Rows[i]["LOGIN_USUARIO"].ToString();
                    retorno.Senha = string.IsNullOrWhiteSpace(dtRetorno.Rows[i]["SENHA"].ToString()) ? null : dtRetorno.Rows[i]["SENHA"].ToString();

                    if (!String.IsNullOrWhiteSpace(dtRetorno.Rows[i]["CODIGO_TIPO_ACESSO"].ToString()))
                    {
                        tipoAcesso.CodigoTipoAcesso = Convert.ToInt32(dtRetorno.Rows[i]["CODIGO_TIPO_ACESSO"].ToString());
                        retorno.TipoAcessoVO = tipoAcesso;
                    }

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



                return listaRetorno;
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
                param = null;
            }
        }

        public DataTable VerificarUsuario(UsuariosVO param)
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


                if (param.LoginUsuario == null)
                    lstSqlParameter.Add(new SqlParameter("@LOGIN_USUARIO", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@LOGIN_USUARIO", param.LoginUsuario));

                if (param.Senha == null)
                    lstSqlParameter.Add(new SqlParameter("@SENHA", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@SENHA", param.Senha));


                objSql.Execute("dbo.[SPVRT002_USUARIOS_PR_VERIFICAR]", lstSqlParameter.ToArray(), null, ref dtRetorno);

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

        public DataTable VerificarLogin(string login)
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
                
                lstSqlParameter.Add(new SqlParameter("@LOGIN_USUARIO", login));

                objSql.Execute("dbo.[SPVRT001_USUARIOS_PR_SELECIONAR]", lstSqlParameter.ToArray(), null, ref dtRetorno);

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

        public DataTable IncluirUsuario(UsuariosVO usuario)
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

                lstSqlParameter.Add(new SqlParameter("@NOME", usuario.Nome));
                lstSqlParameter.Add(new SqlParameter("@MAIL", usuario.Mail));
                lstSqlParameter.Add(new SqlParameter("@LOGIN_USUARIO", usuario.LoginUsuario));
                lstSqlParameter.Add(new SqlParameter("@SENHA", usuario.Senha));
                lstSqlParameter.Add(new SqlParameter("@CODIGO_TIPO_ACESSO", usuario.CodigoTipoAcesso));

                //TODO: Pegar Usuario da SESSION
                lstSqlParameter.Add(new SqlParameter("@CODIGO_USUARIO_CADASTRO", usuario.CodigoUsuarioCadastro));
                lstSqlParameter.Add(new SqlParameter("@DATA_CADASTRO", usuario.DataCadastro));
                lstSqlParameter.Add(new SqlParameter("@CODIGO_USUARIO_ALTERACAO", usuario.CodigoUsuarioAlteracao));
                lstSqlParameter.Add(new SqlParameter("@DATA_ALTERACAO", usuario.DataAlteracao));
                lstSqlParameter.Add(new SqlParameter("@CODIGO_STATUS", usuario.CodigoStatus));

                dtRetorno = new DataTable();

                objSql.Execute("SPVRT002_USUARIOS_PR_INCLUIR", lstSqlParameter.ToArray(), null, ref dtRetorno);

            }
            catch (Exception ex)
            {
                return null;
            }

            return dtRetorno;
        }

        public bool ExcluirUsuario(UsuariosVO usuario)
        {
            InfoTech2uSQLUtil objSql = null;
            StringBuilder query = null;
            List<SqlParameter> lstSqlParameter = null;
            bool foiExcluido = false;

            try
            {

                objSql = new InfoTech2uSQLUtil();
                lstSqlParameter = new List<SqlParameter>();
                query = new StringBuilder();

                objSql.Sigla = objSql.GetDataBase();
                objSql.ConnectionString = objSql.GetConnectionString(objSql.Sigla);
                objSql.Open();

                lstSqlParameter.Add(new SqlParameter("@CODIGO_USUARIO", usuario.CodigoUsuario));

                lstSqlParameter.Add(new SqlParameter("@CODIGO_USUARIO_ALTERACAO", usuario.CodigoUsuarioAlteracao));

                int rowsAffected = 0;

                objSql.ExecuteNonQuery("SPVRT004_USUARIOS_PR_EXCLUIR", lstSqlParameter.ToArray(), null, out rowsAffected);

                foiExcluido = rowsAffected > 0;
            }
            catch (Exception ex)
            {
                foiExcluido = false;
            }
            finally
            {
                objSql = null;
                lstSqlParameter = null;
                query = null;
            }

            return foiExcluido;
        }

        public DataTable AlterarUsuario(UsuariosVO usuario)
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
                lstSqlParameter.Add(new SqlParameter("@CODIGO_USUARIO", usuario.CodigoUsuario));
                lstSqlParameter.Add(new SqlParameter("@NOME", usuario.Nome));
                lstSqlParameter.Add(new SqlParameter("@MAIL", usuario.Mail));
                lstSqlParameter.Add(new SqlParameter("@CODIGO_TIPO_ACESSO", usuario.CodigoTipoAcesso));

                //TODO: Pegar Usuario da SESSION
                lstSqlParameter.Add(new SqlParameter("@CODIGO_USUARIO_ALTERACAO", usuario.CodigoUsuarioAlteracao));
                lstSqlParameter.Add(new SqlParameter("@DATA_ALTERACAO", usuario.DataAlteracao));

                dtRetorno = new DataTable();

                objSql.Execute("SPVRT003_USUARIOS_PR_ALTERAR", lstSqlParameter.ToArray(), null, ref dtRetorno);

            }
            catch (Exception ex)
            {
                return null;
            }

            return dtRetorno;
        }
    }
}
