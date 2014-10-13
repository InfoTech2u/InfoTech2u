using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoTech2u.Verithus.VO
{
    public class LogVO
    {
        public int? CodigoLog { get; set; }
        public string TipoLog { get; set; }
        public string Descricao { get; set; }
        public DateTime? DataGeracao { get; set; }
        public int? CodigoUsuarioExecucao{ get; set; }
        public string Metodo{ get; set; }

        public string NomeUsuario{ get; set; }

        public DateTime? DataGeracaoInicio { get; set; }

        public DateTime? DataGeracaoFim { get; set; }
    }
}
