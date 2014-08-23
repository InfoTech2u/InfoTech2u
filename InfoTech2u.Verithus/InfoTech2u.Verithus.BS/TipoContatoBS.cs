using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfoTech2u.Verithus.VO;
using InfoTech2u.Verithus.DA;

namespace InfoTech2u.Verithus.BS
{
    public class TipoContatoBS
    {
        public List<TipoContatoVO> SelecionarTipoContato(TipoContatoVO param)
        {

            TipoContatoDA objRetorno = null;

            try
            {
                objRetorno = new TipoContatoDA();

                return objRetorno.SelecionarTipoContato(param);
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

        public List<TipoContatoVO> SelecionarTipoContatoLista()
        {
            TipoContatoDA objRetorno = null;

            try
            {
                objRetorno = new TipoContatoDA();

                return objRetorno.SelecionarTipoContatoLista();
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
