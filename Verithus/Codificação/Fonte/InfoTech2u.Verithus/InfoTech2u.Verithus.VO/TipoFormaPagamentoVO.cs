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
    
    public partial class TipoFormaPagamentoVO
    {
        public TipoFormaPagamentoVO()
        {
            this.DadosAdmissaoVO = new HashSet<DadosAdmissaoVO>();
            this.DadosDemissaoVO = new HashSet<DadosDemissaoVO>();
        }

        public Nullable<int> CodigoTipoFormaPagamento { get; set; }
        public string Descricao { get; set; }
        public Nullable<int> CodigoUsuarioCadastro { get; set; }
        public Nullable<System.DateTime> DataCadastro { get; set; }
        public Nullable<int> CodigoUsuarioAlteracao { get; set; }
        public Nullable<System.DateTime> DataAlteracao { get; set; }
        public Nullable<int> CodigoStatus { get; set; }
    
        public virtual ICollection<DadosAdmissaoVO> DadosAdmissaoVO { get; set; }
        public virtual ICollection<DadosDemissaoVO> DadosDemissaoVO { get; set; }
    }
}
