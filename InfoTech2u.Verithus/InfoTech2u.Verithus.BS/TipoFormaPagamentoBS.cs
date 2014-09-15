using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfoTech2u.Verithus.VO;
using InfoTech2u.Verithus.DA;
using System.Data;

namespace InfoTech2u.Verithus.BS
{
    public class TipoFormaPagamentoBS
    {

        public List<TipoFormaPagamentoVO> SelecionarFormaPagamentoLista(TipoFormaPagamentoVO objEntrada)
        {
            TipoFormaPagamentoDA objRetorno = new TipoFormaPagamentoDA();

            try
            {
                return objRetorno.SelecionarFormaPagamentoLista(objEntrada);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objRetorno = null;
            }
        }

        public DataTable IncluirTipoFormaPagamento(TipoFormaPagamentoVO param)
        {
            TipoFormaPagamentoDA objRetorno = null;

            try
            {
                objRetorno = new TipoFormaPagamentoDA();

                return objRetorno.IncluirTipoFormaPagamento(param);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                objRetorno = null;
            }
        }

        public bool ExcluirTipoFormaPagamento(TipoFormaPagamentoVO param)
        {
            TipoFormaPagamentoDA objRetorno = null;

            try
            {
                objRetorno = new TipoFormaPagamentoDA();

                return objRetorno.ExcluirTipoFormaPagamento(param);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                objRetorno = null;
            }
        }

    }
}
