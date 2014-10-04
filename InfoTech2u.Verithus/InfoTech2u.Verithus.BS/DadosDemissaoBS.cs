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
    public class DadosDemissaoBS
    {
        public DataTable IncluirDemissao(DadosDemissaoVO param)
        {
            DadosDemissaoDA objRetorno = null;

            try
            {
                objRetorno = new DadosDemissaoDA();

                return objRetorno.IncluirDemissao(param);
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

        public DataTable AlterarDemissao(DadosDemissaoVO param)
        {
            DadosDemissaoDA objRetorno = null;

            try
            {
                objRetorno = new DadosDemissaoDA();

                return objRetorno.AlterarDemissao(param);
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

        public DataTable Selecionar(DadosDemissaoVO param)
        {
            DadosDemissaoDA objRetorno = null;

            try
            {
                objRetorno = new DadosDemissaoDA();

                return objRetorno.SelecionarDemissao(param);
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
