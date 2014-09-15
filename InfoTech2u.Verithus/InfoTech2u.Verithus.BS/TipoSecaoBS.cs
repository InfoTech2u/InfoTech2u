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
    public class TipoSecaoBS
    {
        public List<TipoSecaoVO> SelecionarSecaoLista(TipoSecaoVO objEntrada)
        {
            TipoSecaoDA objRetorno = new TipoSecaoDA();

            try
            {
                return objRetorno.SelecionarSecaoLista(objEntrada);
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

        public DataTable IncluirTipoSecao(TipoSecaoVO param)
        {
            TipoSecaoDA objRetorno = null;

            try
            {
                objRetorno = new TipoSecaoDA();

                return objRetorno.IncluirTipoSecao(param);
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

        public bool ExcluirTipoSecao(TipoSecaoVO param)
        {
            TipoSecaoDA objRetorno = null;

            try
            {
                objRetorno = new TipoSecaoDA();

                return objRetorno.ExcluirTipoSecao(param);
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
