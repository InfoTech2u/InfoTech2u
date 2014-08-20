using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfoTech2u.Verithus.VO;
using InfoTech2u.Verithus.DA;

namespace InfoTech2u.Verithus.BS
{
    public class TipoOlhoBS
    {

        public string SelecionarTipoOlho(TipoOlhoVO param)
        {

            TipoOlhoDA objRetorno = new TipoOlhoDA();

            try
            {
                return objRetorno.SelecionarTipoOlho(param);
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

        public List<TipoOlhoVO> SelecionarTipoOlhoLista(TipoOlhoVO param)
        {
            TipoOlhoDA objRetorno = new TipoOlhoDA();

            try
            {
                return objRetorno.SelecionarTipoOlhoLista(param);
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
