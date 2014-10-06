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
    public class TipoAcessoDA
    {
        public System.Data.DataTable SelecionarTipoAcessoLista()
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


                lstSqlParameter.Add(new SqlParameter("@CODIGO_TIPO_ACESSO", DBNull.Value));


                objSql.Execute("dbo.[SPVRT035_TIPO_ACESSO_PR_SELECIONAR]", lstSqlParameter.ToArray(), null, ref dtRetorno);
               
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objSql = null;
                lstSqlParameter = null;
            }

            return dtRetorno;
        }
    }
}
