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
    public class LogDA
    {
        public List<LogVO> SelecionarLog(LogVO param)
        {
            InfoTech2uSQLUtil objSql = null;
            List<SqlParameter> lstSqlParameter = null;
            DataTable dtRetorno = null;
            List<LogVO> listaRetorno = null;
            LogVO retorno = null;

            try
            {

                objSql = new InfoTech2uSQLUtil();
                lstSqlParameter = new List<SqlParameter>();
                dtRetorno = new DataTable();

                objSql.Sigla = objSql.GetDataBase();
                objSql.ConnectionString = objSql.GetConnectionString(objSql.Sigla);
                objSql.Open();

                if (param.CodigoLog == null)
                    lstSqlParameter.Add(new SqlParameter("@CODIGO_TIPO_BENEFICIO", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@CODIGO_TIPO_BENEFICIO", param.CodigoLog));

                if (param.TipoLog == null)
                    lstSqlParameter.Add(new SqlParameter("@TIPO_LOG", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@TIPO_LOG", param.TipoLog));

                if (param.CodigoUsuarioExecucao == null)
                    lstSqlParameter.Add(new SqlParameter("@CODIGO_USUARIO_EXECUCAO", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@CODIGO_USUARIO_EXECUCAO", param.CodigoUsuarioExecucao));

                if (param.DataGeracaoInicio == null)
                    lstSqlParameter.Add(new SqlParameter("@DATA_GERACAO_INICIO", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@DATA_GERACAO_INICIO", param.DataGeracaoInicio));

                if (param.DataGeracaoFim== null)
                    lstSqlParameter.Add(new SqlParameter("@DATA_GERACAO_FIM", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@DATA_GERACAO_FIM", param.DataGeracaoFim));

                if (param.Metodo == null)
                    lstSqlParameter.Add(new SqlParameter("@METODO", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@METODO", param.Metodo));

                if (param.Descricao == null)
                    lstSqlParameter.Add(new SqlParameter("@DESCRICAO", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@DESCRICAO", param.Descricao));

                objSql.Execute("dbo.[SPVRT075_LOG_PR_SELECIONAR]", lstSqlParameter.ToArray(), null, ref dtRetorno);

                listaRetorno = new List<LogVO>();

                int i = 0;
                while (i < dtRetorno.Rows.Count)
                {

                    retorno = new LogVO();

                    retorno.CodigoLog = Convert.ToInt32(dtRetorno.Rows[i]["CODIGO_LOG"].ToString());

                    retorno.TipoLog = string.IsNullOrWhiteSpace(dtRetorno.Rows[i]["TIPO_LOG"].ToString()) ? null : dtRetorno.Rows[i]["TIPO_LOG"].ToString();

                    retorno.Descricao = string.IsNullOrWhiteSpace(dtRetorno.Rows[i]["DESCRICAO"].ToString()) ? null : dtRetorno.Rows[i]["DESCRICAO"].ToString();

                    if (!String.IsNullOrWhiteSpace(dtRetorno.Rows[i]["DATA_GERACAO"].ToString()))
                        retorno.DataGeracao = Convert.ToDateTime(dtRetorno.Rows[i]["DATA_GERACAO"].ToString());

                    retorno.NomeUsuario = string.IsNullOrWhiteSpace(dtRetorno.Rows[i]["NOME"].ToString()) ? null : dtRetorno.Rows[i]["NOME"].ToString();

                    retorno.Descricao = string.IsNullOrWhiteSpace(dtRetorno.Rows[i]["METODO"].ToString()) ? null : dtRetorno.Rows[i]["METODO"].ToString();

                    retorno.CodigoUsuarioExecucao = Convert.ToInt32(dtRetorno.Rows[i]["CODIGO_USUARIO_EXECUCAO"].ToString());

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
