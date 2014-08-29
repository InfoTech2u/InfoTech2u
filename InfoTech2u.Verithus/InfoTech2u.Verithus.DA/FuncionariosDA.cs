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
        //SPVRT022_FUNCIONARIO_PR_INCLUIR
        public void IncluirFuncionario(FuncionariosVO param)
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

                if (param.EnderecoVO.DetalheEndereco.CodigoTipoEndereco == null)
                    lstSqlParameter.Add(new SqlParameter("@CODIGO_TIPO_ENDERECO_FUNCIONARIO", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@CODIGO_TIPO_ENDERECO_FUNCIONARIO", param.EnderecoVO.DetalheEndereco.CodigoTipoEndereco));

                if (param.CodigoFuncionario == null)
                    lstSqlParameter.Add(new SqlParameter("@CODIGO_TIPO_LOGRADOURO_FUNCIONARIO", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@CODIGO_TIPO_LOGRADOURO_FUNCIONARIO", param.CodigoFuncionario));

                if (param.CodigoFuncionario == null)
                    lstSqlParameter.Add(new SqlParameter("@LOGRADOURO_FUNCIONARIO", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@LOGRADOURO_FUNCIONARIO", param.CodigoFuncionario));

                if (param.CodigoFuncionario == null)
                    lstSqlParameter.Add(new SqlParameter("@NUMERO_FUNCIONARIO", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@NUMERO_FUNCIONARIO", param.CodigoFuncionario));

                if (param.CodigoFuncionario == null)
                    lstSqlParameter.Add(new SqlParameter("@BAIRRO_FUNCIONARIO", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@BAIRRO_FUNCIONARIO", param.CodigoFuncionario));

                if (param.CodigoFuncionario == null)
                    lstSqlParameter.Add(new SqlParameter("@COMPLEMENTO_FUNCIONARIO", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@COMPLEMENTO_FUNCIONARIO", param.CodigoFuncionario));

                if (param.CodigoFuncionario == null)
                    lstSqlParameter.Add(new SqlParameter("@CEP_FUNCIONARIO", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@CEP_FUNCIONARIO", param.CodigoFuncionario));

                if (param.CodigoFuncionario == null)
                    lstSqlParameter.Add(new SqlParameter("@NOME_PAI_FUNCIONARIO", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@NOME_PAI_FUNCIONARIO", param.CodigoFuncionario));

                if (param.CodigoFuncionario == null)
                    lstSqlParameter.Add(new SqlParameter("@NACIONALIDADE_PAI_FUNCIONARIO", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@NACIONALIDADE_PAI_FUNCIONARIO", param.CodigoFuncionario));

                if (param.CodigoFuncionario == null)
                    lstSqlParameter.Add(new SqlParameter("@NOME_MAE_FUNCIONARIO", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@NOME_MAE_FUNCIONARIO", param.CodigoFuncionario));

                if (param.CodigoFuncionario == null)
                    lstSqlParameter.Add(new SqlParameter("@NACIONALIDADE_MAE_FUNCIONARIO", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@NACIONALIDADE_MAE_FUNCIONARIO", param.CodigoFuncionario));

                if (param.CodigoFuncionario == null)
                    lstSqlParameter.Add(new SqlParameter("@NUMERO_IDENTIDADE", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@NUMERO_IDENTIDADE", param.CodigoFuncionario));

                if (param.CodigoFuncionario == null)
                    lstSqlParameter.Add(new SqlParameter("@NUMERO_CARTEIRA_TRABALHO", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@NUMERO_CARTEIRA_TRABALHO", param.CodigoFuncionario));

                if (param.CodigoFuncionario == null)
                    lstSqlParameter.Add(new SqlParameter("@NUMERO_SERIE", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@NUMERO_SERIE", param.CodigoFuncionario));

                if (param.CodigoFuncionario == null)
                    lstSqlParameter.Add(new SqlParameter("@NUMERO_CERTIFICADO_RESERVISTA", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@NUMERO_CERTIFICADO_RESERVISTA", param.CodigoFuncionario));

                if (param.CodigoFuncionario == null)
                    lstSqlParameter.Add(new SqlParameter("@CATEGORIA", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@CATEGORIA", param.CodigoFuncionario));

                if (param.CodigoFuncionario == null)
                    lstSqlParameter.Add(new SqlParameter("@NUMERO_CPF", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@NUMERO_CPF", param.CodigoFuncionario));

                if (param.CodigoFuncionario == null)
                    lstSqlParameter.Add(new SqlParameter("@TITULO_ELEITOR", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@TITULO_ELEITOR", param.CodigoFuncionario));

                if (param.CodigoFuncionario == null)
                    lstSqlParameter.Add(new SqlParameter("@NUMERO_CARTEIRA_SAUDE", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@NUMERO_CARTEIRA_SAUDE", param.CodigoFuncionario));

                if (param.CodigoFuncionario == null)
                    lstSqlParameter.Add(new SqlParameter("@NUMERO_CBO", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@NUMERO_CBO", param.CodigoFuncionario));

                if (param.CodigoFuncionario == null)
                    lstSqlParameter.Add(new SqlParameter("@NUMERO_CARTEIRA_19", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@NUMERO_CARTEIRA_19", param.CodigoFuncionario));

                if (param.CodigoFuncionario == null)
                    lstSqlParameter.Add(new SqlParameter("@NUMERO_RESISTRO_GERAL", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@NUMERO_RESISTRO_GERAL", param.CodigoFuncionario));
                if (param.CodigoFuncionario == null)
                    lstSqlParameter.Add(new SqlParameter("@CASADO_BRASILEIRO", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@CASADO_BRASILEIRO", param.CodigoFuncionario));

                if (param.CodigoFuncionario == null)
                    lstSqlParameter.Add(new SqlParameter("@NUTURALIZADO", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@NUTURALIZADO", param.CodigoFuncionario));

                if (param.CodigoFuncionario == null)
                    lstSqlParameter.Add(new SqlParameter("@FILHO_BRASILEIRO", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@FILHO_BRASILEIRO", param.CodigoFuncionario));

                if (param.CodigoFuncionario == null)
                    lstSqlParameter.Add(new SqlParameter("@DATA_CHEGADA_BRASIL", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@DATA_CHEGADA_BRASIL", param.CodigoFuncionario));

                if (param.CodigoFuncionario == null)
                    lstSqlParameter.Add(new SqlParameter("@DATA_CADASTRO_PIS", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@DATA_CADASTRO_PIS", param.CodigoFuncionario));

                if (param.CodigoFuncionario == null)
                    lstSqlParameter.Add(new SqlParameter("@SOB_NUMERO_PIS", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@SOB_NUMERO_PIS", param.CodigoFuncionario));

                if (param.CodigoFuncionario == null)
                    lstSqlParameter.Add(new SqlParameter("@NUMERO_BANCO_PIS", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@NUMERO_BANCO_PIS", param.CodigoFuncionario));

                if (param.CodigoFuncionario == null)
                    lstSqlParameter.Add(new SqlParameter("@AGENCIA_PIS", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@AGENCIA_PIS", param.CodigoFuncionario));

                if (param.CodigoFuncionario == null)
                    lstSqlParameter.Add(new SqlParameter("@DIGITO_PIS", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@DIGITO_PIS", param.CodigoFuncionario));

                if (param.CodigoFuncionario == null)
                    lstSqlParameter.Add(new SqlParameter("@CODIGO_TIPO_ENDERECO_PIS", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@CODIGO_TIPO_ENDERECO_PIS", param.CodigoFuncionario));
                if (param.CodigoFuncionario == null)
                    lstSqlParameter.Add(new SqlParameter("@CODIGO_TIPO_LOGRADOURO_PIS", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@CODIGO_TIPO_LOGRADOURO_PIS", param.CodigoFuncionario));

                if (param.CodigoFuncionario == null)
                    lstSqlParameter.Add(new SqlParameter("@LOGRADOURO_PIS", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@LOGRADOURO_PIS", param.CodigoFuncionario));

                if (param.CodigoFuncionario == null)
                    lstSqlParameter.Add(new SqlParameter("@NUMERO_PIS", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@NUMERO_PIS", param.CodigoFuncionario));

                if (param.CodigoFuncionario == null)
                    lstSqlParameter.Add(new SqlParameter("@BAIRRO_PIS", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@BAIRRO_PIS", param.CodigoFuncionario));

                if (param.CodigoFuncionario == null)
                    lstSqlParameter.Add(new SqlParameter("@COMPLEMENTO_PIS", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@COMPLEMENTO_PIS", param.CodigoFuncionario));

                if (param.CodigoFuncionario == null)
                    lstSqlParameter.Add(new SqlParameter("@CEP_PIS", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@CEP_PIS", param.CodigoFuncionario));

                if (param.CodigoFuncionario == null)
                    lstSqlParameter.Add(new SqlParameter("@OPTANTE", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@OPTANTE", param.CodigoFuncionario));

                if (param.CodigoFuncionario == null)
                    lstSqlParameter.Add(new SqlParameter("@DATA_OPCAO", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@DATA_OPCAO", param.CodigoFuncionario));

                if (param.CodigoFuncionario == null)
                    lstSqlParameter.Add(new SqlParameter("@DATA_RETRATACAO", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@DATA_RETRATACAO", param.CodigoFuncionario));

                if (param.CodigoFuncionario == null)
                    lstSqlParameter.Add(new SqlParameter("@NUMERO_BANCO_FUNDO_GARANTIA", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@NUMERO_BANCO_FUNDO_GARANTIA", param.CodigoFuncionario));
                if (param.CodigoFuncionario == null)
                    lstSqlParameter.Add(new SqlParameter("@AGENCIA_FUNDO_GARANTIA", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@AGENCIA_FUNDO_GARANTIA", param.CodigoFuncionario));

                if (param.CodigoFuncionario == null)
                    lstSqlParameter.Add(new SqlParameter("@DIGITO_FUNDO_GARANTIA", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@DIGITO_FUNDO_GARANTIA", param.CodigoFuncionario));

                if (param.CodigoFuncionario == null)
                    lstSqlParameter.Add(new SqlParameter("@ALTURA", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@ALTURA", param.CodigoFuncionario));

                if (param.CodigoFuncionario == null)
                    lstSqlParameter.Add(new SqlParameter("@PESO", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@PESO", param.CodigoFuncionario));

                if (param.CodigoFuncionario == null)
                    lstSqlParameter.Add(new SqlParameter("@SINAIS", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@SINAIS", param.CodigoFuncionario));

                if (param.CodigoFuncionario == null)
                    lstSqlParameter.Add(new SqlParameter("@CODIGO_TIPO_COR", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@CODIGO_TIPO_COR", param.CodigoFuncionario));

                if (param.CodigoFuncionario == null)
                    lstSqlParameter.Add(new SqlParameter("@CODIGO_TIPO_CABELO", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@CODIGO_TIPO_CABELO", param.CodigoFuncionario));

                if (param.CodigoFuncionario == null)
                    lstSqlParameter.Add(new SqlParameter("@CODIGO_TIPO_OLHO", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@CODIGO_TIPO_OLHO", param.CodigoFuncionario));

                if (param.CodigoFuncionario == null)
                    lstSqlParameter.Add(new SqlParameter("@CODIGO_USUARIO_CADASTRO", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@CODIGO_USUARIO_CADASTRO", param.CodigoFuncionario));

                if (param.CodigoFuncionario == null)
                    lstSqlParameter.Add(new SqlParameter("@DATA_CADASTRO", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@DATA_CADASTRO", param.CodigoFuncionario));
                if (param.CodigoFuncionario == null)
                    lstSqlParameter.Add(new SqlParameter("@CODIGO_USUARIO_ALTERACAO", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@CODIGO_USUARIO_ALTERACAO", param.CodigoFuncionario));

                if (param.CodigoFuncionario == null)
                    lstSqlParameter.Add(new SqlParameter("@DATA_ALTERACAO", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@DATA_ALTERACAO", param.CodigoFuncionario));

                if (param.CodigoFuncionario == null)
                    lstSqlParameter.Add(new SqlParameter("@CODIGO_STATUS", DBNull.Value));
                else
                    lstSqlParameter.Add(new SqlParameter("@CODIGO_STATUS", param.CodigoFuncionario));


                objSql.Execute("dbo.[SPVRT022_FUNCIONARIO_PR_INCLUIR]", lstSqlParameter.ToArray(), null, ref dtRetorno);

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
