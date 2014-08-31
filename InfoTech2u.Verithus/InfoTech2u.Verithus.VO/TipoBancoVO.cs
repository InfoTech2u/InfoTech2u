using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoTech2u.Verithus.VO
{
    public class TipoBancoVO
    {
        public int? CodigoBanco { get; set; }
        public string NumeroBanco { get; set; }
        public string NomeBanco { get; set; }

        public Nullable<int> CodigoUsuarioCadastro { get; set; }
        public Nullable<System.DateTime> DataCadastro { get; set; }
        public Nullable<int> CodigoUsuarioAlteracao { get; set; }
        public Nullable<System.DateTime> DataAlteracao { get; set; }
        public Nullable<int> CodigoStatus { get; set; }

    }
}
