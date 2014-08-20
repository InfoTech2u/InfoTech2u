using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfoTech2u.Verithus.VO;
using InfoTech2u.Verithus.DA;

namespace InfoTech2u.Verithus.BS
{
    public class PaisBS
    {
        public List<PaisVO> SelecionarUsuarioLista(PaisVO param)
        {
            PaisDA objRetorno = new PaisDA();

            try
            {
                return objRetorno.SelecionarPaisLista(param);
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
