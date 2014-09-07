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
    public class CidadeBS
    {
        public DataTable SelecionarCidade(CidadeVO param)
        {

            CidadeDA objRetorno = null;

            try
            {
                objRetorno = new CidadeDA();

                return objRetorno.SelecionarCidade(param);
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
