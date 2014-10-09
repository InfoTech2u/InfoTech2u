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
    public class AcidenteTrabalhoBS
    {
        public DataTable SelecionarAdmissao(AcidenteTrabalhoVO param)
        {
            AcidenteTrabalhoDA objRetorno = new AcidenteTrabalhoDA();

            try
            {
                return objRetorno.SelecionarAcidenteTrabalho(param);
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

        public DataTable IncluirAdmissao(AcidenteTrabalhoVO usuario)
        {
            AcidenteTrabalhoDA objRetorno = new AcidenteTrabalhoDA();

            return objRetorno.IncluirAcidenteTrabalho(usuario);
        }

        public DataTable AlterarAdmissao(AcidenteTrabalhoVO usuario)
        {
            AcidenteTrabalhoDA objRetorno = new AcidenteTrabalhoDA();

            return objRetorno.AlterarAcidenteTrabalho(usuario);
        }
    }
}
