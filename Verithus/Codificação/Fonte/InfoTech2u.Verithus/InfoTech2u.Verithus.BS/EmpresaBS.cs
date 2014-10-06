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
    public class EmpresaBS
    {
        public DataTable SelecionarEmpresa(EmpresaVO param)
        {
            EmpresaDA objRetorno = new EmpresaDA();

            try
            {
                return objRetorno.SelecionarEmpresa(param);
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

        public DataTable IncluirEmpresa(EmpresaVO param)
        {
            EmpresaDA objRetorno = new EmpresaDA();

            try
            {
                return objRetorno.IncluirEmpresa(param);
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

        public DataTable AlterarEmpresa(EmpresaVO param)
        {
            EmpresaDA objRetorno = new EmpresaDA();

            try
            {
                return objRetorno.AlterarEmpresa(param);
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

        public DataTable ExcluirEmpresa(EmpresaVO param)
        {
            EmpresaDA objRetorno = new EmpresaDA();

            try
            {
                return objRetorno.ExcluirEmpresa(param);
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
