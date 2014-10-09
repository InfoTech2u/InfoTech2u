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
    public class AlteracaoCargoSalariorBS
    {
        public DataTable SelecionarAdmissao(AlteracaoCargoSalariorVO param)
        {
            AlteracaoCargoSalariorDA objRetorno = new AlteracaoCargoSalariorDA();

            try
            {
                return objRetorno.SelecionarAlteracaoCargoSalarior(param);
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

        public DataTable IncluirAdmissao(AlteracaoCargoSalariorVO usuario)
        {
            AlteracaoCargoSalariorDA objRetorno = new AlteracaoCargoSalariorDA();

            return objRetorno.IncluirAlteracaoCargoSalarior(usuario);
        }

        public DataTable AlterarAdmissao(AlteracaoCargoSalariorVO usuario)
        {
            AlteracaoCargoSalariorDA objRetorno = new AlteracaoCargoSalariorDA();

            return objRetorno.AlterarAlteracaoCargoSalarior(usuario);
        }
    }
}
