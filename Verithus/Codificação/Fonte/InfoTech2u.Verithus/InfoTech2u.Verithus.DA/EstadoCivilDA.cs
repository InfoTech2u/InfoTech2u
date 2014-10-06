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
    public class EstadoCivilDA
    {
        public List<EstadoCivilVO> SelecionarEstadoCivilLista(EstadoCivilVO param)
        {
            List<EstadoCivilVO> listaRetorno = new List<EstadoCivilVO>();
            EstadoCivilVO retorno;
            InfoTech2uSQLUtil objSql = new InfoTech2uSQLUtil();
            List<SqlParameter> lstSqlParameter = new List<SqlParameter>();
            DataTable dtRetorno = new DataTable();

            try
            {
                objSql.Sigla = objSql.GetDataBase();
                objSql.ConnectionString = objSql.GetConnectionString(objSql.Sigla);
                objSql.Open();

                if (param.CodigoEstadoCivil == null)
                    lstSqlParameter.Add(new SqlParameter("@CODIGO_ESTADO_CIVIL", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@CODIGO_ESTADO_CIVIL", param.CodigoEstadoCivil));

                if (String.IsNullOrWhiteSpace(param.Descricao))
                    lstSqlParameter.Add(new SqlParameter("@DESCRICAO", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@DESCRICAO", param.Descricao));


                objSql.Execute("dbo.[SPVRT022_ESTADO_CIVIL_PR_SELECIONAR]", lstSqlParameter.ToArray(), null, ref dtRetorno);


                DataTable dt = dtRetorno;

                int i = 0;
                while (i < dtRetorno.Rows.Count)
                {

                    retorno = new EstadoCivilVO();

                    retorno.CodigoEstadoCivil = Convert.ToInt32(dtRetorno.Rows[i]["CODIGO_ESTADO_CIVIL"].ToString());
                    retorno.Descricao = string.IsNullOrWhiteSpace(dtRetorno.Rows[i]["DESCRICAO"].ToString()) ? null : dtRetorno.Rows[i]["DESCRICAO"].ToString();


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
