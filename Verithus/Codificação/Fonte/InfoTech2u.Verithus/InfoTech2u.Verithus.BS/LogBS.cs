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
    public class LogBS
    {
        public List<LogVO> SelecionarLog(LogVO param)
        {

            LogDA objRetorno = null;

            try
            {
                objRetorno = new LogDA();

                return objRetorno.SelecionarLog(param);
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
