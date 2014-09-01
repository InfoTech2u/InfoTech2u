using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfoTech2u.Verithus.VO;
using InfoTech2u.Verithus.DA;

namespace InfoTech2u.Verithus.BS
{
    public class TipoParentescoBS
    {

        public List<TipoParentescoVO> SelecionarTipoParentesco(TipoParentescoVO param)
        {

            TipoParentescoDA objRetorno = null;

            try
            {
                objRetorno = new TipoParentescoDA();

                return objRetorno.SelecionarTipoParentesco(param);
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

        public List<TipoParentescoVO> SelecionarTipoParentescoLista()
        {
            TipoParentescoDA objRetorno = null;

            try
            {
                objRetorno = new TipoParentescoDA();

                return objRetorno.SelecionarTipoParentescoLista();
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
