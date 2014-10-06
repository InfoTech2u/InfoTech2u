using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfoTech2u.Verithus.VO;
using InfoTech2u.Verithus.DA;

namespace InfoTech2u.Verithus.BS
{
    public class EstadoCivilBS
    {
        public List<EstadoCivilVO> SelecionarEstadoCivilLista(EstadoCivilVO param)
        {
            EstadoCivilDA objRetorno = new EstadoCivilDA();

            try
            {
                return objRetorno.SelecionarEstadoCivilLista(param);
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
