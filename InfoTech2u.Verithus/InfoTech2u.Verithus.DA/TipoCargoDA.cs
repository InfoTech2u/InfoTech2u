﻿using System;
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
    public class TipoCargoDA
    {
        public List<TipoCargoVO> SelecionarCargoLista(TipoCargoVO param)
        {
            List<TipoCargoVO> listaRetorno = new List<TipoCargoVO>();
            TipoCargoVO retorno;
            InfoTech2uSQLUtil objSql = new InfoTech2uSQLUtil();
            List<SqlParameter> lstSqlParameter = new List<SqlParameter>();
            DataTable dtRetorno = new DataTable();

            try
            {
                objSql.Sigla = objSql.GetDataBase();
                objSql.ConnectionString = objSql.GetConnectionString(objSql.Sigla);
                objSql.Open();

                if (param.CodigoTipoCargo == null)
                    lstSqlParameter.Add(new SqlParameter("@CODIGO_TIPO_CARGO", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@CODIGO_TIPO_CARGO", param.CodigoTipoCargo));

                objSql.Execute("dbo.[SPVRT061_TIPO_CARGO_PR_SELECIONAR]", lstSqlParameter.ToArray(), null, ref dtRetorno);

                DataTable dt = dtRetorno;

                int i = 0;
                while (i < dtRetorno.Rows.Count)
                {
                    retorno = new TipoCargoVO();

                    retorno.CodigoTipoCargo = Convert.ToInt32(dtRetorno.Rows[i]["CODIGO_TIPO_CARGO"].ToString());
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
