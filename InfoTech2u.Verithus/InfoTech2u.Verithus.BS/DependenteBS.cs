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
    public class DependenteBS
    {
        public DataTable SelecionarDependentesDoFuncionario(FuncionariosVO param)
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

        public DataTable IncluirDependente(DependenteVO param)
        {
            DependenteDA objRetorno = null;

            try
            {
                objRetorno = new DependenteDA();

                return objRetorno.IncluirDependente(param);
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

        public DataTable SelecionarDependente(DependenteVO param)
        {
            DependenteDA objRetorno = null;

            try
            {
                objRetorno = new DependenteDA();

                return objRetorno.SelecionarDependente(param);
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

        public DataTable AlterarDependente(DependenteVO param)
        {
            DependenteDA objRetorno = null;

            try
            {
                objRetorno = new DependenteDA();

                return objRetorno.AlterarDependente(param);
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

        public bool ExcluirDependente(DependenteVO param)
        {
            DependenteDA objRetorno = null;

            try
            {
                objRetorno = new DependenteDA();

                return objRetorno.ExcluirDependente(param);
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
