using InfoTech2u.Verithus.DA;
using InfoTech2u.Verithus.VO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoTech2u.Verithus.BS
{
    public class SistemaBS
    {
        public List<SistemaVO> SelecionarSistema(SistemaVO param)
        {

            SistemaDA objRetorno = null;

            try
            {
                objRetorno = new SistemaDA();

                return objRetorno.SelecionarSistema(param);
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

        public List<SistemaVO> SelecionarSistemaLista()
        {
            SistemaDA objRetorno = null;

            try
            {
                objRetorno = new SistemaDA();

                return objRetorno.SelecionarSistemaLista();
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

        public DataTable IncluirSistema(SistemaVO param)
        {
            SistemaDA objRetorno = null;

            try
            {
                objRetorno = new SistemaDA();

                return objRetorno.IncluirSistema(param);
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

        public DataTable ExcluirSistema(SistemaVO param)
        {
            SistemaDA objRetorno = null;

            try
            {
                objRetorno = new SistemaDA();

                return objRetorno.ExcluirSistema(param);
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
