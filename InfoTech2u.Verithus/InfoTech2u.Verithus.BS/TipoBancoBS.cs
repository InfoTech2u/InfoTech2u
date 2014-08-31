using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfoTech2u.Verithus.VO;
using InfoTech2u.Verithus.DA;

namespace InfoTech2u.Verithus.BS
{
    public class TipoBancoBS
    {
        public List<TipoBancoVO> SelecionarTipoBanco(TipoBancoVO param)
        {

            TipoBancoDA objRetorno = null;

            try
            {
                objRetorno = new TipoBancoDA();

                return objRetorno.SelecionarTipoBanco(param);
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
