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
        public string SelecionarUsuario(UsuariosVO param)
        {
            InfoTech2uSQLUtil objSql = new InfoTech2uSQLUtil();
            List<SqlParameter> lstSqlParameter = new List<SqlParameter>();
            DataSet dtRetorno = new DataSet();

            try
            {
                objSql.Sigla = objSql.GetDataBase();
                objSql.ConnectionString = objSql.GetConnectionString(objSql.Sigla);
                objSql.Open();

                if (param.CodigoUsuario != null)
                    lstSqlParameter.Add(new SqlParameter("@CODIGO_USUARIO", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@CODIGO_USUARIO", param.CodigoUsuario));


                objSql.Execute("dbo.[SPVRT001_USUARIOS_PR_SELECIONAR]", lstSqlParameter.ToArray(), null, ref dtRetorno);

                DataSet ds = dtRetorno;

                string xmlRetorno = ds.GetXml();

                xmlRetorno = xmlRetorno.Replace("NewDataSet", "usuario");
                xmlRetorno = xmlRetorno.Replace("Table", "row");

                return xmlRetorno;
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

                if (param.CodigoUsuario != null)
                    lstSqlParameter.Add(new SqlParameter("@CODIGO_USUARIO", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@CODIGO_USUARIO", param.CodigoUsuario));


                objSql.Execute("dbo.[SPVRT001_USUARIOS_PR_SELECIONAR]", lstSqlParameter.ToArray(), null, ref dtRetorno);


                DataTable dt = dtRetorno;

                int i = 0;
                while (i < dtRetorno.Rows.Count)
                {
                    

                    retorno = new UsuariosVO();

                    retorno.CodigoUsuario = Convert.ToInt32(dtRetorno.Rows[i]["CODIGO_USUARIO"].ToString());

                    retorno.Nome = string.IsNullOrWhiteSpace(dtRetorno.Rows[i]["NOME"].ToString()) ? null : dtRetorno.Rows[i]["NOME"].ToString();
                    retorno.Mail = string.IsNullOrWhiteSpace(dtRetorno.Rows[i]["MAIL"].ToString()) ? null : dtRetorno.Rows[i]["MAIL"].ToString();
                    retorno.LoginUsuario = string.IsNullOrWhiteSpace(dtRetorno.Rows[i]["LOGIN_USUARIO"].ToString()) ? null : dtRetorno.Rows[i]["LOGIN_USUARIO"].ToString();
                    retorno.Senha = string.IsNullOrWhiteSpace(dtRetorno.Rows[i]["SENHA"].ToString()) ? null : dtRetorno.Rows[i]["SENHA"].ToString();

                    if (!String.IsNullOrWhiteSpace(dtRetorno.Rows[i]["CODIGO_TIPO_ACESSO"].ToString()))
                        retorno.TipoAcessoVO.CodigoTipoAcesso = Convert.ToInt32(dtRetorno.Rows[i]["CODIGO_TIPO_ACESSO"].ToString());

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
    }
}
