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

        public List<TipoCabeloVO> SelecionarTipoOlho(TipoCabeloVO param)
        {

            TipoCabeloDA objRetorno = null;

            try
            {
                objRetorno = new TipoCabeloDA();

                return objRetorno.SelecionarTipoOlho(param);
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

        public List<TipoCabeloVO> SelecionarTipoOlhoLista(TipoCabeloVO param)
        {
            TipoCabeloDA objRetorno = null;

            try
            {
                objRetorno = new TipoCabeloDA();

                return objRetorno.SelecionarTipoOlhoLista();
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
