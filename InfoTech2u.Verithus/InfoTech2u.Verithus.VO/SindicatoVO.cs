//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace InfoTech2u.Verithus.VO
{
    using System;
    using System.Collections.Generic;
    
    public partial class SindicatoVO
    {
        public SindicatoVO()
        {
            this.ContribuicaoSindicalVO = new HashSet<ContribuicaoSindicalVO>();
        }
    
        public int CodigoSindicato { get; set; }
        public string Nome { get; set; }
        public Nullable<int> CodigoUsuarioCadastro { get; set; }
        public Nullable<System.DateTime> DataCadastro { get; set; }
        public Nullable<int> CodigoUsuarioAlteracao { get; set; }
        public Nullable<System.DateTime> DataAlteracao { get; set; }
        public Nullable<int> CodigoStatus { get; set; }
    
        public virtual ICollection<ContribuicaoSindicalVO> ContribuicaoSindicalVO { get; set; }
    }
}
