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
    
    public partial class DetalheEnderecoVO
    {
        public int CodigoDetalheEndereco { get; set; }
        public Nullable<int> CodigoEndereco { get; set; }
        public Nullable<int> CodigoTipoEndereco { get; set; }
        public Nullable<int> CodigoTipoLogradouro { get; set; }
        public Nullable<int> CodigoCidade { get; set; }
        public Nullable<int> CodigoEstado { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Complemento { get; set; }
        public string CEP { get; set; }
        public Nullable<int> CodigoUsuarioCadastro { get; set; }
        public Nullable<System.DateTime> DataCadastro { get; set; }
        public Nullable<int> CodigoUsuarioAlteracao { get; set; }
        public Nullable<System.DateTime> DataAlteracao { get; set; }
        public Nullable<int> CodigoStatus { get; set; }
    
        public virtual EnderecoVO EnderecoVO { get; set; }
        public virtual TipoEnderecoVO TipoEnderecoVO { get; set; }
        public virtual TipoLogradouroVO TipoLogradouroVO { get; set; }
    }
}
