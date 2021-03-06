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
    
    public partial class DadosDemissaoVO
    {
        public int CodigoDEMISSAO { get; set; }
        public Nullable<int> CodigoFuncionario { get; set; }
        public Nullable<System.DateTime> DataDemissao { get; set; }
        public Nullable<System.DateTime> DataRegistro { get; set; }
        public Nullable<int> CodigoTipoCargo { get; set; }
        public Nullable<int> CodigoTipoSecao { get; set; }
        public string SalarioInicial { get; set; }
        public string Comissao { get; set; }
        public Nullable<int> CodigoTipoTarefa { get; set; }
        public Nullable<int> CodigoTipoFormaPagamento { get; set; }
        public Nullable<int> CodigoFormaPagamento { get; set; }
        public Nullable<int> CodigoUsuarioCadastro { get; set; }
        public Nullable<System.DateTime> DataCadastro { get; set; }
        public Nullable<int> CodigoUsuarioAlteracao { get; set; }
        public Nullable<System.DateTime> DataAlteracao { get; set; }
        public Nullable<int> CodigoStatus { get; set; }
    
        public virtual FuncionariosVO FuncionariosVO { get; set; }
        public virtual TipoCargoVO TipoCargoVO { get; set; }
        public virtual TipoSecaoVO TipoSecaoVO { get; set; }
        public virtual TipoTarefaVO TipoTarefaVO { get; set; }
        public virtual TipoFormaPagamentoVO TipoFormaPagamentoVO { get; set; }
    }
}
