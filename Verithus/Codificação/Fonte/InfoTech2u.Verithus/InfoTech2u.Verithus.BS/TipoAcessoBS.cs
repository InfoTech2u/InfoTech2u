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
    public class TipoAcessoBS
    {
        public DataTable SelecionarTipoAcessoLista()
        {
            TipoAcessoDA objDA = new TipoAcessoDA();
            return objDA.SelecionarTipoAcessoLista();
        }
    }
}
