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
    public class ContribuicaoSindicalBS
    {
        public DataTable SelecionarContribuicaoFuncionario(ContribuicaoSindicalVO contribuicao)
        {
            ContribuicaoSindicalDA objDA = null;

            try
            {
                objDA = new ContribuicaoSindicalDA();

                return objDA.SelecionarContribuicaoFuncionario(contribuicao);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objDA = null;
            }
        }

        public DataTable IncluirContribuicaoSindical(ContribuicaoSindicalVO contribuicao)
        {
            ContribuicaoSindicalDA objDA = null;

            try
            {
                objDA = new ContribuicaoSindicalDA();

                return objDA.IncluirContribuicaoSindical(contribuicao);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objDA = null;
            }
        }

        public DataTable AlterarContribuicaoSindical(ContribuicaoSindicalVO contribuicao)
        {
            ContribuicaoSindicalDA objDA = null;

            try
            {
                objDA = new ContribuicaoSindicalDA();

                return objDA.AlterarContribuicaoSindical(contribuicao);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objDA = null;
            }
        }

        public bool ExcluirContribuicaoSindical(ContribuicaoSindicalVO contribuicao)
        {
            ContribuicaoSindicalDA objDA = null;

            try
            {
                objDA = new ContribuicaoSindicalDA();

                return objDA.ExcluirContribuicaoSindical(contribuicao);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objDA = null;
            }
        }
    }
}
