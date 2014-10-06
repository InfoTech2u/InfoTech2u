using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfoTech2u.Verithus.VO;
using InfoTech2u.Verithus.DA;

namespace InfoTech2u.Verithus.BS
{
    public class TipoCorBS
    {

        public List<TipoCorVO> SelecionarTipoCor(TipoCorVO param)
        {

            TipoCorDA objRetorno = null;

            try
            {
                objRetorno = new TipoCorDA();

                return objRetorno.SelecionarTipoCor(param);
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

        public List<TipoCorVO> SelecionarTipoCorLista()
        {
            TipoCorDA objRetorno = null;

            try
            {
                objRetorno = new TipoCorDA();

                return objRetorno.SelecionarTipoCorLista();
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
    }
}
