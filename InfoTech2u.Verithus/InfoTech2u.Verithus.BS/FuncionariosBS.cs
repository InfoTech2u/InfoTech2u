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
    public class FuncionariosBS
    {
       public DataTable SelecionarFuncionario(FuncionariosVO param)
        {
            FuncionariosDA objRetorno = new FuncionariosDA();

            return objRetorno.SelecionarFuncionario(param);
        }

       public DataTable IncluirFuncionario(FuncionariosVO param)
        {
            FuncionariosDA objFuncionario = new FuncionariosDA();

            return objFuncionario.IncluirFuncionario(param);
        }
    }
}
