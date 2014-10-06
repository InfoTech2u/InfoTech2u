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
    public class CidadeDA
    {
        public DataTable SelecionarCidade(CidadeVO param)
        {
            InfoTech2uSQLUtil objSql = null;
            List<SqlParameter> lstSqlParameter = null;
            DataTable dtRetorno = null;
            List<CidadeVO> listaRetorno = null;
            CidadeVO retorno = null;

            try
            {
                objSql = new InfoTech2uSQLUtil();
                lstSqlParameter = new List<SqlParameter>();
                dtRetorno = new DataTable();

                objSql.Sigla = objSql.GetDataBase();
                objSql.ConnectionString = objSql.GetConnectionString(objSql.Sigla);
                objSql.Open();

                if (param.CodigoCidade == null)
                    lstSqlParameter.Add(new SqlParameter("@CODIGO_CIDADE", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@CODIGO_CIDADE", param.CodigoCidade));

                if (param.Sigla == null)
                    lstSqlParameter.Add(new SqlParameter("@SIGLA", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@SIGLA", param.Sigla));

                if (param.Descricao == null)
                    lstSqlParameter.Add(new SqlParameter("@DESCRICAO", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@DESCRICAO", param.Descricao));

                if (param.CodigoEstado == null)
                    lstSqlParameter.Add(new SqlParameter("@CODIGO_ESTADO", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@CODIGO_ESTADO", param.CodigoEstado));


                objSql.Execute("dbo.[SPVRT003_CIDADE_PR_SELECIONAR]", lstSqlParameter.ToArray(), null, ref dtRetorno);

                return dtRetorno;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
