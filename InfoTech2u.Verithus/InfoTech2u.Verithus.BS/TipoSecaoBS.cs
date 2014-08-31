using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfoTech2u.Verithus.VO;
using InfoTech2u.Verithus.DA;

namespace InfoTech2u.Verithus.BS
{
    public class TipoSecaoBS
    {
        public List<TipoSecaoVO> SelecionarSecaoLista(TipoSecaoVO objEntrada)
        {
            TipoSecaoDA objRetorno = new TipoSecaoDA();

            try
            {
                return objRetorno.SelecionarSecaoLista(objEntrada);
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
