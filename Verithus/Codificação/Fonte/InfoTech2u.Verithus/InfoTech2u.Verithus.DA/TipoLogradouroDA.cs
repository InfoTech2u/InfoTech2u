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
    public class TipoLogradouroDA
    {
        public List<TipoLogradouroVO> SelecionarTipoLogradouroLista(TipoLogradouroVO param)
        {
            InfoTech2uSQLUtil objSql = null;
            List<SqlParameter> lstSqlParameter = null;
            DataTable dtRetorno = null;
            List<TipoLogradouroVO> listaRetorno = null;
            TipoLogradouroVO retorno = null;

            try
            {
                objSql = new InfoTech2uSQLUtil();
                lstSqlParameter = new List<SqlParameter>();
                dtRetorno = new DataTable();

                objSql.Sigla = objSql.GetDataBase();
                objSql.ConnectionString = objSql.GetConnectionString(objSql.Sigla);
                objSql.Open();

                if (param.CodigoTipoLogradouro == null)
                    lstSqlParameter.Add(new SqlParameter("@CODIGO_TIPO_LOGRADOURO", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@CODIGO_TIPO_LOGRADOURO", param.CodigoTipoLogradouro));


                objSql.Execute("dbo.[SPVRT052_TIPO_LOGRADOURO_PR_SELECIONAR]", lstSqlParameter.ToArray(), null, ref dtRetorno);

                listaRetorno = new List<TipoLogradouroVO>();
                int i = 0;
                while (i < dtRetorno.Rows.Count)
                {


                    retorno = new TipoLogradouroVO();

                    retorno.CodigoTipoLogradouro = Convert.ToInt32(dtRetorno.Rows[i]["CODIGO_TIPO_LOGRADOURO"].ToString());

                    retorno.Descricao = string.IsNullOrWhiteSpace(dtRetorno.Rows[i]["DESCRICAO"].ToString()) ? null : dtRetorno.Rows[i]["DESCRICAO"].ToString();

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

            return listaRetorno;
        }
    }
}
