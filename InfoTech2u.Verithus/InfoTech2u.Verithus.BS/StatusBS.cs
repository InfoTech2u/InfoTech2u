﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfoTech2u.Verithus.VO;
using InfoTech2u.Verithus.DA;

namespace InfoTech2u.Verithus.BS
{
    public class StatusBS
    {
        public List<StatusVO> SelecionarStatus(StatusVO param)
        {

            StatusDA objRetorno = null;

            try
            {
                objRetorno = new StatusDA();

                return objRetorno.SelecionarStatus(param);
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
