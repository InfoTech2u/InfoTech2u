using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfoTech2u.Verithus.VO;
using InfoTech2u.Verithus.DA;
using System.Data;

namespace InfoTech2u.Verithus.BS
{
    public class TipoBeneficioBS
    {
        public List<TipoBeneficioVO> SelecionarTipoBeneficio(TipoBeneficioVO param)
        {

            TipoBeneficioDA objRetorno = null;

            try
            {
                objRetorno = new TipoBeneficioDA();

                return objRetorno.SelecionarTipoBeneficio(param);
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

        public List<TipoBeneficioVO> SelecionarTipoBeneficioLista()
        {
            TipoBeneficioDA objRetorno = null;

            try
            {
                objRetorno = new TipoBeneficioDA();

                return objRetorno.SelecionarTipoBeneficioLista();
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

        public DataTable IncluirTipoBeneficio(TipoBeneficioVO param)
        {
            TipoBeneficioDA objRetorno = null;

            try
            {
                objRetorno = new TipoBeneficioDA();

                return objRetorno.IncluirTipoBeneficio(param);
            }
            catch (Exception)
            {
                
                throw;
            }
            finally
            {
                objRetorno = null;
            }
        }

        public DataTable ExcluirTipoBeneficio(TipoBeneficioVO param)
        {
            TipoBeneficioDA objRetorno = null;

            try
            {
                objRetorno = new TipoBeneficioDA();

                return objRetorno.ExcluirTipoBeneficio(param);
            }
            catch (Exception)
            {
                
                throw;
            }
            finally
            {
                objRetorno = null;
            }
        }
    }
}
