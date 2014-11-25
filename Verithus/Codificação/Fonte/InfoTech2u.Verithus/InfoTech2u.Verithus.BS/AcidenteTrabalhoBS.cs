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
    public class AcidenteTrabalhoBS
    {

        public DataTable ExcluirAcidenteTrabalho(AcidenteTrabalhoVO param)
        {
            AcidenteTrabalhoDA objRetorno = new AcidenteTrabalhoDA();

            try
            {
                return objRetorno.ExcluirAcidenteTrabalho(param);
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
        public DataTable SelecionarAcidenteTrabalho(AcidenteTrabalhoVO param)
        {
            AcidenteTrabalhoDA objRetorno = new AcidenteTrabalhoDA();

            try
            {
                return objRetorno.SelecionarAcidenteTrabalho(param);
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

        public DataTable IncluirAcidenteTrabalho(AcidenteTrabalhoVO usuario)
        {
            AcidenteTrabalhoDA objRetorno = new AcidenteTrabalhoDA();

            return objRetorno.IncluirAcidenteTrabalho(usuario);
        }

        public DataTable AlterarAcidenteTrabalho(AcidenteTrabalhoVO usuario)
        {
            AcidenteTrabalhoDA objRetorno = new AcidenteTrabalhoDA();

            return objRetorno.AlterarAcidenteTrabalho(usuario);
        }
    }
}
