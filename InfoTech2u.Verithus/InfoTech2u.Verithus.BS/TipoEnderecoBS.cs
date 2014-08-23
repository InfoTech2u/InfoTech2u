using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfoTech2u.Verithus.VO;
using InfoTech2u.Verithus.DA;

namespace InfoTech2u.Verithus.BS
{
    public class TipoEnderecoBS
    {

        public List<TipoEnderecoVO> SelecionarTipoCor(TipoEnderecoVO param)
        {

            TipoEnderecoDA objRetorno = null;

            try
            {
                objRetorno = new TipoEnderecoDA();

                return objRetorno.SelecionarTipoEndereco(param);
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

        public List<TipoEnderecoVO> SelecionarTipoCorLista()
        {
            TipoEnderecoDA objRetorno = null;

            try
            {
                objRetorno = new TipoEnderecoDA();

                return objRetorno.SelecionarTipoEndereciLista();
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
