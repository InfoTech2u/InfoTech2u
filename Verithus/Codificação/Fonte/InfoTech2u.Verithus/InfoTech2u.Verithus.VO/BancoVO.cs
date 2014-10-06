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
    
    public partial class BancoVO
    {
        public BancoVO()
        {
            this.DocumentoPIS = new HashSet<DocumentoPISVO>();
            this.DocumentoFundoGarantiaVO = new HashSet<DocumentoFundoGarantiaVO>();
        }
    
        public int CodigoBanco { get; set; }
        public string NumeroBanco { get; set; }
        public string Agencia { get; set; }
        public string Conta { get; set; }
        public string Digito { get; set; }
        public Nullable<int> CodigoEndereco { get; set; }
        public Nullable<int> CodigoContato { get; set; }
        public Nullable<int> CodigoUsuarioCadastro { get; set; }
        public Nullable<System.DateTime> DataCadastro { get; set; }
        public Nullable<int> CodigoUsuarioAlteracao { get; set; }
        public Nullable<System.DateTime> DataAlteracao { get; set; }
        public Nullable<int> CodigoStatus { get; set; }
    
        public virtual ICollection<DocumentoPISVO> DocumentoPIS { get; set; }
        public virtual ICollection<DocumentoFundoGarantiaVO> DocumentoFundoGarantiaVO { get; set; }
        public virtual ContatoVO ContatoVO { get; set; }
    }
}
