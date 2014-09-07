using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfoTech2u.Verithus.VO;
using InfoTech2u.Verithus.DA;

namespace InfoTech2u.Verithus.BS
{
    public class TipoTarefaBS
    {
        public List<TipoTarefaVO> SelecionarTarefaLista(TipoTarefaVO objEntrada)
        {
            TipoTarefaDA objRetorno = new TipoTarefaDA();

            try
            {
                return objRetorno.SelecionarTarefaLista(objEntrada);
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
