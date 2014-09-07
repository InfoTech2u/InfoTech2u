using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfoTech2u.Verithus.VO;
using InfoTech2u.Verithus.DA;

namespace InfoTech2u.Verithus.BS
{
    public class EstadoBS
    {
        public List<EstadoVO> SelecionarEstado(EstadoVO param)
        {

            EstadoDA objRetorno = null;

            try
            {
                objRetorno = new EstadoDA();

                return objRetorno.SelecionarEstado(param);
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
