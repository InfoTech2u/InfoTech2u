using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoTech2u.Verithus.VO
{
    public class ConsultaCEPServicoFreeVO
    {
        private string _uf;

        public string Uf
        {
            get { return _uf; }
            set { _uf = value; }
        }
        private string _cidade;

        public string Cidade
        {
            get { return _cidade; }
            set { _cidade = value; }
        }
        private string _bairro;

        public string Bairro
        {
            get { return _bairro; }
            set { _bairro = value; }
        }
        private string _tipo_logradouro;

        public string Tipo_logradouro
        {
            get { return _tipo_logradouro; }
            set { _tipo_logradouro = value; }
        }
        private string _logradouro;

        public string Logradouro
        {
            get { return _logradouro; }
            set { _logradouro = value; }
        }
        private string _resultado;

        public string Resultado
        {
            get { return _resultado; }
            set { _resultado = value; }
        }
        private string _resultato_txt;

        public string Resultato_txt
        {
            get { return _resultato_txt; }
            set { _resultato_txt = value; }
        }
    }
}
