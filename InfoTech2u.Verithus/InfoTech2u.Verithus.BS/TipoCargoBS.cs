using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfoTech2u.Verithus.VO;
using InfoTech2u.Verithus.DA;

namespace InfoTech2u.Verithus.BS
{
    public class TipoCargoBS
    {
        public List<TipoCargoVO> SelecionarCargoLista(TipoCargoVO objEntrada)
        {
            TipoCargoDA objRetorno = new TipoCargoDA();

            try
            {
                return objRetorno.SelecionarCargoLista(objEntrada);
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
