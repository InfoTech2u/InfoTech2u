namespace InfoTech2u.Verithus.VO
{
    using System;
    using System.Collections.Generic;
    public partial class CidadeVO
    {
        public int CodigoCidade { get; set; }

        public string Sigla { get; set; }

        public string Descricao { get; set; }
        public Nullable<int> CodigoUsuarioCadastro { get; set; }
        public Nullable<System.DateTime> DataCadastro { get; set; }
        public Nullable<int> CodigoUsuarioAlteracao { get; set; }
        public Nullable<System.DateTime> DataAlteracao { get; set; }
        public Nullable<int> CodigoStatus { get; set; }
    }
}
