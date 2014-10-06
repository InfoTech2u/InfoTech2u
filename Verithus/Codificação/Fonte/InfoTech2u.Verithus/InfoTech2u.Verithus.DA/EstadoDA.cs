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
    public class EstadoDA
    {
        public List<EstadoVO> SelecionarEstado(EstadoVO param)
        {
            InfoTech2uSQLUtil objSql = null;
            List<SqlParameter> lstSqlParameter = null;
            DataTable dtRetorno = null;
            List<EstadoVO> listaRetorno = null;
            EstadoVO retorno = null;

            try
            {
                objSql = new InfoTech2uSQLUtil();
                lstSqlParameter = new List<SqlParameter>();
                dtRetorno = new DataTable();

                objSql.Sigla = objSql.GetDataBase();
                objSql.ConnectionString = objSql.GetConnectionString(objSql.Sigla);
                objSql.Open();

                if (param.CodigoEstado == null)
                    lstSqlParameter.Add(new SqlParameter("@CODIGO_ESTADO", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@CODIGO_ESTADO", param.CodigoEstado));

                if (param.Sigla == null)
                    lstSqlParameter.Add(new SqlParameter("@SIGLA", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@SIGLA", param.Sigla));

                if (param.Descricao == null)
                    lstSqlParameter.Add(new SqlParameter("@DESCRICAO", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@DESCRICAO", param.Descricao));


                objSql.Execute("dbo.[SPVRT023_ESTADO_PR_SELECIONAR]", lstSqlParameter.ToArray(), null, ref dtRetorno);

                listaRetorno = new List<EstadoVO>();
                int i = 0;
                while (i < dtRetorno.Rows.Count)
                {


                    retorno = new EstadoVO();

                    retorno.CodigoEstado = Convert.ToInt32(dtRetorno.Rows[i]["CODIGO_ESTADO"].ToString());

                    retorno.Sigla = string.IsNullOrWhiteSpace(dtRetorno.Rows[i]["SIGLA"].ToString()) ? null : dtRetorno.Rows[i]["SIGLA"].ToString();

                    retorno.Descricao = string.IsNullOrWhiteSpace(dtRetorno.Rows[i]["DESCRICAO"].ToString()) ? null : dtRetorno.Rows[i]["DESCRICAO"].ToString();

                    //retorno.Descricao = dtRetorno.Rows[i]["DESCRICAO"].ToString() + " - (" + dtRetorno.Rows[i]["SIGLA"].ToString() +")";
                    /*
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
                    */
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
