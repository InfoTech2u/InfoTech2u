using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfoTech2u.Verithus.VO;
using InfoTech2u.Verithus.DA;

namespace InfoTech2u.Verithus.BS
{
    public class TipoLogradouroBS
    {
        public List<TipoLogradouroVO> SelecionarTipoLogradouroLista(TipoLogradouroVO param)
        {

            TipoLogradouroDA objRetorno = null;

            try
            {
                objRetorno = new TipoLogradouroDA();

                return objRetorno.SelecionarTipoLogradouroLista(param);
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
