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
    public class SindicatoBS
    {
        public List<SindicatoVO> SelecionarSindicato(SindicatoVO param)
        {

            SindicatoDA objRetorno = null;

            try
            {
                objRetorno = new SindicatoDA();

                return objRetorno.SelecionarSindicato(param);
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

        public List<SindicatoVO> SelecionarSindicatoLista()
        {
            SindicatoDA objRetorno = null;

            try
            {
                objRetorno = new SindicatoDA();

                return objRetorno.SelecionarSindicatoLista();
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

        public DataTable IncluirSindicato(SindicatoVO param)
        {
            SindicatoDA objRetorno = null;

            try
            {
                objRetorno = new SindicatoDA();

                return objRetorno.IncluirSindicato(param);
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

        public bool ExcluirSindicato(SindicatoVO param)
        {
            SindicatoDA objRetorno = null;

            try
            {
                objRetorno = new SindicatoDA();

                return objRetorno.ExcluirSindicato(param);
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
