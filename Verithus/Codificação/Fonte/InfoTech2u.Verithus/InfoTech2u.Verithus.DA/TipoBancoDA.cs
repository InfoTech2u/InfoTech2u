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
    public class TipoBancoDA
    {
        public List<TipoBancoVO> SelecionarTipoBanco(TipoBancoVO param)
        {
            InfoTech2uSQLUtil objSql = null;
            List<SqlParameter> lstSqlParameter = null;
            DataTable dtRetorno = null;
            List<TipoBancoVO> listaRetorno = null;
            TipoBancoVO retorno = null;

            try
            {
                objSql = new InfoTech2uSQLUtil();
                lstSqlParameter = new List<SqlParameter>();
                dtRetorno = new DataTable();

                objSql.Sigla = objSql.GetDataBase();
                objSql.ConnectionString = objSql.GetConnectionString(objSql.Sigla);
                objSql.Open();

                if (param.CodigoBanco == null)
                    lstSqlParameter.Add(new SqlParameter("@CODIGO_BANCO", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@CODIGO_BANCO", param.CodigoBanco));

                if (param.CodigoBanco == null)
                    lstSqlParameter.Add(new SqlParameter("@NOME_BANCO", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@NOME_BANCO", param.CodigoBanco));

                if (param.CodigoBanco == null)
                    lstSqlParameter.Add(new SqlParameter("@NUMERO_BANCO", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@NUMERO_BANCO", param.CodigoBanco));


                objSql.Execute("dbo.[SPVRT036_TIPO_BANCO_PR_SELECIONAR]", lstSqlParameter.ToArray(), null, ref dtRetorno);

                listaRetorno = new List<TipoBancoVO>();
                int i = 0;
                while (i < dtRetorno.Rows.Count)
                {


                    retorno = new TipoBancoVO();

                    retorno.CodigoBanco = Convert.ToInt32(dtRetorno.Rows[i]["CODIGO_BANCO"].ToString());

                    retorno.NumeroBanco = string.IsNullOrWhiteSpace(dtRetorno.Rows[i]["NUMERO_BANCO"].ToString()) ? null : dtRetorno.Rows[i]["NUMERO_BANCO"].ToString();

                    //retorno.NomeBanco = string.IsNullOrWhiteSpace(dtRetorno.Rows[i]["NOME_BANCO"].ToString()) ? null : dtRetorno.Rows[i]["NOME_BANCO"].ToString();

                    retorno.NomeBanco = dtRetorno.Rows[i]["NUMERO_BANCO"].ToString() + " - " + dtRetorno.Rows[i]["NOME_BANCO"].ToString();

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
