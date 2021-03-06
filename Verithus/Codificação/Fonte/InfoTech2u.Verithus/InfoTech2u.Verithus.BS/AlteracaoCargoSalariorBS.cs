﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfoTech2u.Verithus.VO;
using InfoTech2u.Verithus.DA;
using System.Data;

namespace InfoTech2u.Verithus.BS
{
    public class AlteracaoCargoSalariorBS
    {
        public DataTable ExcluirAlteracaoCargoSalarior(AlteracaoCargoSalariorVO param)
        {
            AlteracaoCargoSalariorDA objRetorno = new AlteracaoCargoSalariorDA();

            try
            {
                return objRetorno.ExcluirAlteracaoCargoSalarior(param);
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
        public DataTable SelecionarAlteracaoCargoSalarior(AlteracaoCargoSalariorVO param)
        {
            AlteracaoCargoSalariorDA objRetorno = new AlteracaoCargoSalariorDA();

            try
            {
                return objRetorno.SelecionarAlteracaoCargoSalarior(param);
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

        public DataTable IncluirAlteracaoCargoSalarior(AlteracaoCargoSalariorVO usuario)
        {
            AlteracaoCargoSalariorDA objRetorno = new AlteracaoCargoSalariorDA();

            return objRetorno.IncluirAlteracaoCargoSalarior(usuario);
        }

        public DataTable AlterarAlteracaoCargoSalarior(AlteracaoCargoSalariorVO usuario)
        {
            AlteracaoCargoSalariorDA objRetorno = new AlteracaoCargoSalariorDA();

            return objRetorno.AlterarAlteracaoCargoSalarior(usuario);
        }
    }
}
