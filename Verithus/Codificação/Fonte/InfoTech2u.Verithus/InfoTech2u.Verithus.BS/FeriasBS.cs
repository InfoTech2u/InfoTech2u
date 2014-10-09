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
    public class FeriasBS
    {
        public DataTable SelecionarFerias(FeriasVO param)
        {
            FeriasDA objRetorno = new FeriasDA();

            try
            {
                return objRetorno.SelecionarFerias(param);
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

        public DataTable IncluirFerias(FeriasVO usuario)
        {
            FeriasDA objRetorno = new FeriasDA();

            return objRetorno.IncluirFerias(usuario);
        }

        public DataTable AlterarFerias(FeriasVO usuario)
        {
            FeriasDA objRetorno = new FeriasDA();

            return objRetorno.AlterarFerias(usuario);
        }
    }
}
