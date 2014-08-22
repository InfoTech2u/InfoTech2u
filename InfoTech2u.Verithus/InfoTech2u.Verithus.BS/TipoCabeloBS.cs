using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfoTech2u.Verithus.VO;
using InfoTech2u.Verithus.DA;

namespace InfoTech2u.Verithus.BS
{
    public class TipoCabeloBS
    {

        public List<TipoCabeloVO> SelecionarTipoCabelo(TipoCabeloVO param)
        {

            TipoCabeloDA objRetorno = null;

            try
            {
                objRetorno = new TipoCabeloDA();

                return objRetorno.SelecionarTipoCabelo(param);
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

        public List<TipoCabeloVO> SelecionarTipoCabeloLista(TipoCabeloVO param)
        {
            TipoCabeloDA objRetorno = null;

            try
            {
                objRetorno = new TipoCabeloDA();

                return objRetorno.SelecionarTipoCabeloLista();
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
