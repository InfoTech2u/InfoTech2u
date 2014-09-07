using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfoTech2u.Verithus.VO;
using InfoTech2u.Verithus.DA;

namespace InfoTech2u.Verithus.BS
{
    public class DependenteBS
    {
        public List<DependenteVO> SelecionarDependentesDoFuncionario(FuncionariosVO param)
        {

            DependenteDA objRetorno = null;

            try
            {
                objRetorno = new DependenteDA();

                return objRetorno.SelecionarDependentesDoFuncionario(param);
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

        public List<DependenteVO> SelecionarDependentes(DependenteVO param)
        {

            DependenteDA objRetorno = null;

            try
            {
                objRetorno = new DependenteDA();

                return objRetorno.SelecionarDependentes(param);
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

        public List<DependenteVO> SelecionarDependentesLista()
        {
            DependenteDA objRetorno = null;

            try
            {
                objRetorno = new DependenteDA();

                return objRetorno.SelecionarDependentesLista();
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
