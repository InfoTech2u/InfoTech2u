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
    public class BeneficioBS
    {

        public DataTable SelecionarBeneficios(BeneficioVO Beneficio)
        {
            BeneficioDA objRetorno = new BeneficioDA();

            try
            {
                return objRetorno.SelecionarBeneficios(Beneficio);
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
