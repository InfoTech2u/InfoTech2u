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
    }
}
