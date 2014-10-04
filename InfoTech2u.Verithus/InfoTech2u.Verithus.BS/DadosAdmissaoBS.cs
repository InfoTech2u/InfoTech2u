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
    public class DadosAdmissaoBS
    {
        public DataTable SelecionarAdmissao(DadosAdmissaoVO param)
        {
            DadosAdmissaoDA objRetorno = new DadosAdmissaoDA();

            try
            {
                return objRetorno.SelecionarAdmissao(param);
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

        public DataTable IncluirAdmissao(DadosAdmissaoVO usuario)
        {
            DadosAdmissaoDA objRetorno = new DadosAdmissaoDA();

            return objRetorno.IncluirAdmissao(usuario);
        }

        public DataTable AlterarAdmissao(DadosAdmissaoVO usuario)
        {
            DadosAdmissaoDA objRetorno = new DadosAdmissaoDA();

            return objRetorno.AlterarAdmissao(usuario);
        }
    }
}
