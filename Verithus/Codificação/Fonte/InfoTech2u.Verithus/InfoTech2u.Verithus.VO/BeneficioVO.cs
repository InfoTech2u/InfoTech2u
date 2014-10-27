using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoTech2u.Verithus.VO
{
    public class BeneficioVO
    {
        public BeneficioVO()
        {}

        public int? CodigoBeneficio { get; set; }

        public int? CodigoDependente { get; set; }
        public TipoBeneficioVO TipoBeneficio { get; set; }

        public string DescricaoTipoBeneficio { get; set; }

        public DependenteVO Dependente { get; set; }
    }
}
