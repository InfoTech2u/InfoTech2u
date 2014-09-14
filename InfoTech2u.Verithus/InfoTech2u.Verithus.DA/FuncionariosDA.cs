using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfoTech2u.Verithus.Util;
using InfoTech2u.Verithus.VO;
using System.Data.SqlClient;
using System.Data;

namespace InfoTech2u.Verithus.DA
{
    public class FuncionariosDA
    {
        //SPVRT021_FUNCIONARIO_PR_SELECIONAR
        public DataTable SelecionarFuncionario(FuncionariosVO param)
        {
            InfoTech2uSQLUtil objSql = null;
            List<SqlParameter> lstSqlParameter = null;
            DataTable dtRetorno = null;

            try
            {
                objSql = new InfoTech2uSQLUtil();
                lstSqlParameter = new List<SqlParameter>();
                dtRetorno = new DataTable();

                objSql.Sigla = objSql.GetDataBase();
                objSql.ConnectionString = objSql.GetConnectionString(objSql.Sigla);
                objSql.Open();

                if (param.CodigoFuncionario== null)
                    lstSqlParameter.Add(new SqlParameter("@CODIGO_FUNCIONARIO", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@CODIGO_FUNCIONARIO", param.CodigoFuncionario));

                if (param.NumeroOrdemMatricula == null)
                    lstSqlParameter.Add(new SqlParameter("@NUMERO_ORDEM_MATRICULA_FUNCIONARIO", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@NUMERO_ORDEM_MATRICULA_FUNCIONARIO", param.NumeroOrdemMatricula));

                if (param.NumeroMatricula == null)
                    lstSqlParameter.Add(new SqlParameter("@NUMERO_MATRICULA_FUNCIONARIO", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@NUMERO_MATRICULA_FUNCIONARIO", param.NumeroMatricula));

                if (param.NomeFuncionario == null)
                    lstSqlParameter.Add(new SqlParameter("@NOME_FUNCIONARIO_FUNCIONARIO", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@NOME_FUNCIONARIO_FUNCIONARIO", param.NomeFuncionario));


                objSql.Execute("dbo.[SPVRT021_FUNCIONARIO_PR_SELECIONAR]", lstSqlParameter.ToArray(), null, ref dtRetorno);

               return dtRetorno;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objSql = null;
                lstSqlParameter = null;
                dtRetorno = null;
            }

        }
        
        //SPVRT022_FUNCIONARIO_PR_INCLUIR
        public DataTable IncluirFuncionario(FuncionariosVO param)
        {
            InfoTech2uSQLUtil objSql = null;
            List<SqlParameter> lstSqlParameter = null;
            DataTable dtRetorno = null;

            try
            {

                objSql = new InfoTech2uSQLUtil();
                lstSqlParameter = new List<SqlParameter>();
                dtRetorno = new DataTable();

                objSql.Sigla = objSql.GetDataBase();
                objSql.ConnectionString = objSql.GetConnectionString(objSql.Sigla);
                objSql.Open();


                if (param.NumeroOrdemMatricula == null)
                    lstSqlParameter.Add(new SqlParameter("@NUMERO_ORDEM_MATRICULA_FUNCIONARIO", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@NUMERO_ORDEM_MATRICULA_FUNCIONARIO", param.NumeroOrdemMatricula));

                if (param.NumeroMatricula == null)
                    lstSqlParameter.Add(new SqlParameter("@NUMERO_MATRICULA_FUNCIONARIO", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@NUMERO_MATRICULA_FUNCIONARIO", param.NumeroMatricula));

                if (param.NomeFuncionario == null)
                    lstSqlParameter.Add(new SqlParameter("@NOME_FUNCIONARIO_FUNCIONARIO", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@NOME_FUNCIONARIO_FUNCIONARIO", param.NomeFuncionario));

                if (param.DataNascimento == null)
                    lstSqlParameter.Add(new SqlParameter("@DATA_NASCIMENTO_FUNCIONARIO", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@DATA_NASCIMENTO_FUNCIONARIO", param.DataNascimento));

                if (param.LocalNascimento == null)
                    lstSqlParameter.Add(new SqlParameter("@LOCAL_NASCIMENTO_FUNCIONARIO", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@LOCAL_NASCIMENTO_FUNCIONARIO", param.LocalNascimento));

                if (param.CodigoEstadoCivil == null)
                    lstSqlParameter.Add(new SqlParameter("@CODIGO_ESTADO_CIVIL_FUNCIONARIO", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@CODIGO_ESTADO_CIVIL_FUNCIONARIO", param.CodigoEstadoCivil));

                if (param.NomeConjuge == null)
                    lstSqlParameter.Add(new SqlParameter("@NOME_CONJUGE_FUNCIONARIO", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@NOME_CONJUGE_FUNCIONARIO", param.NomeConjuge));

                if (param.QuantosFilhos == null)
                    lstSqlParameter.Add(new SqlParameter("@QUANTOS_FILHOS_FUNCIONARIO", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@QUANTOS_FILHOS_FUNCIONARIO", param.QuantosFilhos));

                if (param.Endereco.DetalheEndereco.CodigoTipoEndereco == null)
                    lstSqlParameter.Add(new SqlParameter("@CODIGO_TIPO_ENDERECO_FUNCIONARIO", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@CODIGO_TIPO_ENDERECO_FUNCIONARIO", param.Endereco.DetalheEndereco.CodigoTipoEndereco));

                if (param.Endereco.DetalheEndereco.CodigoTipoLogradouro == null)
                    lstSqlParameter.Add(new SqlParameter("@CODIGO_TIPO_LOGRADOURO_FUNCIONARIO", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@CODIGO_TIPO_LOGRADOURO_FUNCIONARIO", param.Endereco.DetalheEndereco.CodigoTipoLogradouro));

                if (param.Endereco.DetalheEndereco.CodigoCidade == null)
                    lstSqlParameter.Add(new SqlParameter("@CODIGO_CIDADE_FUNCIONARIO", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@CODIGO_CIDADE_FUNCIONARIO", param.Endereco.DetalheEndereco.CodigoCidade));

                if (param.Endereco.DetalheEndereco.CodigoEstado == null)
                    lstSqlParameter.Add(new SqlParameter("@CODIGO_ESTADO_FUNCIONARIO", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@CODIGO_ESTADO_FUNCIONARIO", param.Endereco.DetalheEndereco.CodigoEstado));

                if (param.Endereco.DetalheEndereco.Logradouro == null)
                    lstSqlParameter.Add(new SqlParameter("@LOGRADOURO_FUNCIONARIO", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@LOGRADOURO_FUNCIONARIO", param.Endereco.DetalheEndereco.Logradouro));

                if (param.Endereco.DetalheEndereco.Numero == null)
                    lstSqlParameter.Add(new SqlParameter("@NUMERO_FUNCIONARIO", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@NUMERO_FUNCIONARIO", param.Endereco.DetalheEndereco.Numero));

                if (param.Endereco.DetalheEndereco.Bairro == null)
                    lstSqlParameter.Add(new SqlParameter("@BAIRRO_FUNCIONARIO", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@BAIRRO_FUNCIONARIO", param.Endereco.DetalheEndereco.Bairro));

                if (param.Endereco.DetalheEndereco.Complemento == null)
                    lstSqlParameter.Add(new SqlParameter("@COMPLEMENTO_FUNCIONARIO", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@COMPLEMENTO_FUNCIONARIO", param.Endereco.DetalheEndereco.Complemento));

                if (param.Endereco.DetalheEndereco.CEP == null)
                    lstSqlParameter.Add(new SqlParameter("@CEP_FUNCIONARIO", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@CEP_FUNCIONARIO", param.Endereco.DetalheEndereco.CEP));

                if (param.NomePai == null)
                    lstSqlParameter.Add(new SqlParameter("@NOME_PAI_FUNCIONARIO", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@NOME_PAI_FUNCIONARIO", param.NomePai));

                if (param.NacionalidadePai == null)
                    lstSqlParameter.Add(new SqlParameter("@NACIONALIDADE_PAI_FUNCIONARIO", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@NACIONALIDADE_PAI_FUNCIONARIO", param.NacionalidadePai));

                if (param.NomeMae == null)
                    lstSqlParameter.Add(new SqlParameter("@NOME_MAE_FUNCIONARIO", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@NOME_MAE_FUNCIONARIO", param.NomeMae));

                if (param.NacionalidadeMae == null)
                    lstSqlParameter.Add(new SqlParameter("@NACIONALIDADE_MAE_FUNCIONARIO", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@NACIONALIDADE_MAE_FUNCIONARIO", param.NacionalidadeMae));

                if (param.Documento.NumeroIdentidade == null)
                    lstSqlParameter.Add(new SqlParameter("@NUMERO_IDENTIDADE", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@NUMERO_IDENTIDADE", param.Documento.NumeroIdentidade));

                if (param.Documento.NumeroCarteiraTrabalho == null)
                    lstSqlParameter.Add(new SqlParameter("@NUMERO_CARTEIRA_TRABALHO", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@NUMERO_CARTEIRA_TRABALHO", param.Documento.NumeroCarteiraTrabalho));

                if (param.Documento.NumeroSerie == null)
                    lstSqlParameter.Add(new SqlParameter("@NUMERO_SERIE", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@NUMERO_SERIE", param.Documento.NumeroSerie));

                if (param.Documento.NumeroCertificadoReservista == null)
                    lstSqlParameter.Add(new SqlParameter("@NUMERO_CERTIFICADO_RESERVISTA", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@NUMERO_CERTIFICADO_RESERVISTA", param.Documento.NumeroCertificadoReservista));

                if (param.Documento.Categoria == null)
                    lstSqlParameter.Add(new SqlParameter("@CATEGORIA", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@CATEGORIA", param.Documento.Categoria));

                if (param.Documento.NumeroCPF == null)
                    lstSqlParameter.Add(new SqlParameter("@NUMERO_CPF", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@NUMERO_CPF", param.Documento.NumeroCPF));

                if (param.Documento.TituloEleitor == null)
                    lstSqlParameter.Add(new SqlParameter("@TITULO_ELEITOR", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@TITULO_ELEITOR", param.Documento.TituloEleitor));

                if (param.Documento.NumeroCarteiraSaude == null)
                    lstSqlParameter.Add(new SqlParameter("@NUMERO_CARTEIRA_SAUDE", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@NUMERO_CARTEIRA_SAUDE", param.Documento.NumeroCarteiraSaude));

                if (param.DocumentoEstrangeiro.NumeroCBO == null)
                    lstSqlParameter.Add(new SqlParameter("@NUMERO_CBO", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@NUMERO_CBO", param.DocumentoEstrangeiro.NumeroCBO));

                if (param.DocumentoEstrangeiro.NumeroCarteira19 == null)
                    lstSqlParameter.Add(new SqlParameter("@NUMERO_CARTEIRA_19", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@NUMERO_CARTEIRA_19", param.DocumentoEstrangeiro.NumeroCarteira19));

                if (param.DocumentoEstrangeiro.NumeroRegistroGeral == null)
                    lstSqlParameter.Add(new SqlParameter("@NUMERO_RESISTRO_GERAL", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@NUMERO_RESISTRO_GERAL", param.DocumentoEstrangeiro.NumeroRegistroGeral));
                if (param.DocumentoEstrangeiro.CasadoBrasileiro == null)
                    lstSqlParameter.Add(new SqlParameter("@CASADO_BRASILEIRO", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@CASADO_BRASILEIRO", param.DocumentoEstrangeiro.CasadoBrasileiro));

                if (param.DocumentoEstrangeiro.Naturalizado == null)
                    lstSqlParameter.Add(new SqlParameter("@NUTURALIZADO", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@NUTURALIZADO", param.DocumentoEstrangeiro.Naturalizado));

                if (param.DocumentoEstrangeiro.FilhoBrasileiro == null)
                    lstSqlParameter.Add(new SqlParameter("@FILHO_BRASILEIRO", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@FILHO_BRASILEIRO", param.DocumentoEstrangeiro.FilhoBrasileiro));

                if (param.DocumentoEstrangeiro.DataChegadaBrasil == null)
                    lstSqlParameter.Add(new SqlParameter("@DATA_CHEGADA_BRASIL", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@DATA_CHEGADA_BRASIL", param.DocumentoEstrangeiro.DataChegadaBrasil));

                if (param.DocumentoPIS.DataCadastro == null)
                    lstSqlParameter.Add(new SqlParameter("@DATA_CADASTRO_PIS", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@DATA_CADASTRO_PIS", param.DocumentoPIS.DataCadastro));

                if (param.DocumentoPIS.SOBNumero == null)
                    lstSqlParameter.Add(new SqlParameter("@SOB_NUMERO_PIS", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@SOB_NUMERO_PIS", param.DocumentoPIS.SOBNumero));

                if (param.DocumentoPIS.BancoVO.CodigoBanco == null)
                    lstSqlParameter.Add(new SqlParameter("@NUMERO_BANCO_PIS", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@NUMERO_BANCO_PIS", param.DocumentoPIS.BancoVO.CodigoBanco));

                if (param.DocumentoPIS.BancoVO.Agencia == null)
                    lstSqlParameter.Add(new SqlParameter("@AGENCIA_PIS", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@AGENCIA_PIS", param.DocumentoPIS.BancoVO.Agencia));

                if (param.DocumentoPIS.BancoVO.Digito == null)
                    lstSqlParameter.Add(new SqlParameter("@DIGITO_PIS", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@DIGITO_PIS", param.DocumentoPIS.BancoVO.Digito));

                if (param.DocumentoPIS.EnderecoVO.DetalheEndereco.TipoEnderecoVO.CodigoTipoEndereco == null)
                    lstSqlParameter.Add(new SqlParameter("@CODIGO_TIPO_ENDERECO_PIS", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@CODIGO_TIPO_ENDERECO_PIS", param.DocumentoPIS.EnderecoVO.DetalheEndereco.TipoEnderecoVO.CodigoTipoEndereco));
                
                if (param.DocumentoPIS.EnderecoVO.DetalheEndereco.TipoLogradouroVO.CodigoTipoLogradouro == null)
                    lstSqlParameter.Add(new SqlParameter("@CODIGO_TIPO_LOGRADOURO_PIS", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@CODIGO_TIPO_LOGRADOURO_PIS", param.DocumentoPIS.EnderecoVO.DetalheEndereco.TipoLogradouroVO.CodigoTipoLogradouro));

                if (param.DocumentoPIS.EnderecoVO.DetalheEndereco.CodigoCidade == null)
                    lstSqlParameter.Add(new SqlParameter("@CODIGO_CIDADE_PIS", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@CODIGO_CIDADE_PIS", param.DocumentoPIS.EnderecoVO.DetalheEndereco.CodigoCidade));

                if (param.DocumentoPIS.EnderecoVO.DetalheEndereco.CodigoEstado == null)
                    lstSqlParameter.Add(new SqlParameter("@CODIGO_ESTADO_PIS", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@CODIGO_ESTADO_PIS", param.DocumentoPIS.EnderecoVO.DetalheEndereco.CodigoEstado));

                if (param.DocumentoPIS.EnderecoVO.DetalheEndereco.Logradouro == null)
                    lstSqlParameter.Add(new SqlParameter("@LOGRADOURO_PIS", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@LOGRADOURO_PIS", param.DocumentoPIS.EnderecoVO.DetalheEndereco.Logradouro));

                if (param.DocumentoPIS.EnderecoVO.DetalheEndereco.Numero == null)
                    lstSqlParameter.Add(new SqlParameter("@NUMERO_PIS", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@NUMERO_PIS", param.DocumentoPIS.EnderecoVO.DetalheEndereco.Numero));

                if (param.DocumentoPIS.EnderecoVO.DetalheEndereco.Bairro == null)
                    lstSqlParameter.Add(new SqlParameter("@BAIRRO_PIS", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@BAIRRO_PIS", param.DocumentoPIS.EnderecoVO.DetalheEndereco.Bairro));

                if (param.DocumentoPIS.EnderecoVO.DetalheEndereco.Complemento == null)
                    lstSqlParameter.Add(new SqlParameter("@COMPLEMENTO_PIS", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@COMPLEMENTO_PIS", param.DocumentoPIS.EnderecoVO.DetalheEndereco.Complemento));

                if (param.DocumentoPIS.EnderecoVO.DetalheEndereco.CEP == null)
                    lstSqlParameter.Add(new SqlParameter("@CEP_PIS", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@CEP_PIS", param.DocumentoPIS.EnderecoVO.DetalheEndereco.CEP));

                if (param.DocumentoFundoGarantia.Optante == null)
                    lstSqlParameter.Add(new SqlParameter("@OPTANTE", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@OPTANTE", param.DocumentoFundoGarantia.Optante));

                if (param.DocumentoFundoGarantia.DataOpcao == null)
                    lstSqlParameter.Add(new SqlParameter("@DATA_OPCAO", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@DATA_OPCAO", param.DocumentoFundoGarantia.DataOpcao));

                if (param.DocumentoFundoGarantia.DataRetratacao == null)
                    lstSqlParameter.Add(new SqlParameter("@DATA_RETRATACAO", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@DATA_RETRATACAO", param.DocumentoFundoGarantia.DataRetratacao));

                if (param.DocumentoFundoGarantia.BancoVO.CodigoBanco == null)
                    lstSqlParameter.Add(new SqlParameter("@NUMERO_BANCO_FUNDO_GARANTIA", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@NUMERO_BANCO_FUNDO_GARANTIA", param.DocumentoFundoGarantia.BancoVO.CodigoBanco));
                if (param.DocumentoFundoGarantia.BancoVO.Agencia == null)
                    lstSqlParameter.Add(new SqlParameter("@AGENCIA_FUNDO_GARANTIA", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@AGENCIA_FUNDO_GARANTIA", param.DocumentoFundoGarantia.BancoVO.Agencia));

                if (param.DocumentoFundoGarantia.BancoVO.Digito == null)
                    lstSqlParameter.Add(new SqlParameter("@DIGITO_FUNDO_GARANTIA", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@DIGITO_FUNDO_GARANTIA", param.DocumentoFundoGarantia.BancoVO.Digito));

                if (param.CaractesristicaFisica.Altura == null)
                    lstSqlParameter.Add(new SqlParameter("@ALTURA", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@ALTURA", param.CaractesristicaFisica.Altura));

                if (param.CaractesristicaFisica.Peso == null)
                    lstSqlParameter.Add(new SqlParameter("@PESO", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@PESO", param.CaractesristicaFisica.Peso));

                if (param.CaractesristicaFisica.Sinais == null)
                    lstSqlParameter.Add(new SqlParameter("@SINAIS", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@SINAIS", param.CaractesristicaFisica.Sinais));

                if (param.CaractesristicaFisica.TipoCorVO.CodigoTipoCor == null)
                    lstSqlParameter.Add(new SqlParameter("@CODIGO_TIPO_COR", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@CODIGO_TIPO_COR", param.CaractesristicaFisica.TipoCorVO.CodigoTipoCor));

                if (param.CaractesristicaFisica.TipoCabeloVO.CodigoTipoCabelo == null)
                    lstSqlParameter.Add(new SqlParameter("@CODIGO_TIPO_CABELO", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@CODIGO_TIPO_CABELO", param.CaractesristicaFisica.TipoCabeloVO.CodigoTipoCabelo));

                if (param.CaractesristicaFisica.TipoOlhoVO.CodigoTipoOlho == null)
                    lstSqlParameter.Add(new SqlParameter("@CODIGO_TIPO_OLHO", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@CODIGO_TIPO_OLHO", param.CaractesristicaFisica.TipoOlhoVO.CodigoTipoOlho));

                if (param.CodigoFuncionario == null)
                    lstSqlParameter.Add(new SqlParameter("@CODIGO_USUARIO_CADASTRO", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@CODIGO_USUARIO_CADASTRO", param.CodigoFuncionario));

                if (param.DataCadastro == null)
                    lstSqlParameter.Add(new SqlParameter("@DATA_CADASTRO", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@DATA_CADASTRO", param.DataCadastro));
                if (param.CodigoFuncionario == null)
                    lstSqlParameter.Add(new SqlParameter("@CODIGO_USUARIO_ALTERACAO", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@CODIGO_USUARIO_ALTERACAO", param.CodigoFuncionario));

                if (param.DataAlteracao == null)
                    lstSqlParameter.Add(new SqlParameter("@DATA_ALTERACAO", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@DATA_ALTERACAO", param.DataAlteracao));

                if (param.CodigoStatus == null)
                    lstSqlParameter.Add(new SqlParameter("@CODIGO_STATUS", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@CODIGO_STATUS", param.CodigoStatus));


                objSql.Execute("dbo.[SPVRT022_FUNCIONARIO_PR_INCLUIR]", lstSqlParameter.ToArray(), null, ref dtRetorno);

                return dtRetorno;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objSql = null;
                lstSqlParameter = null;
                dtRetorno = null;
            }
        }
    }
}
