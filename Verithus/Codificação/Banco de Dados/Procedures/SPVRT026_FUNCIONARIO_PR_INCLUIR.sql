USE [DBVERITHUS]
GO

/****** Object:  StoredProcedure [dbo].[SPVRT026_FUNCIONARIO_PR_INCLUIR]    Script Date: 19/10/2014 21:05:25 ******/
DROP PROCEDURE [dbo].[SPVRT026_FUNCIONARIO_PR_INCLUIR]
GO

/****** Object:  StoredProcedure [dbo].[SPVRT026_FUNCIONARIO_PR_INCLUIR]    Script Date: 19/10/2014 21:05:25 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO





CREATE PROCEDURE [dbo].[SPVRT026_FUNCIONARIO_PR_INCLUIR]
(
@NUMERO_ORDEM_MATRICULA_FUNCIONARIO		INT = NULL,
@NUMERO_MATRICULA_FUNCIONARIO			INT = NULL,
@NOME_FUNCIONARIO_FUNCIONARIO			NVARCHAR(100) = NULL,
@DATA_NASCIMENTO_FUNCIONARIO			DATETIME = NULL,
@LOCAL_NASCIMENTO_FUNCIONARIO			INT = NULL,
@CODIGO_ESTADO_CIVIL_FUNCIONARIO		INT = NULL,
@NOME_CONJUGE_FUNCIONARIO				NVARCHAR(100) = NULL,
@QUANTOS_FILHOS_FUNCIONARIO				SMALLINT = NULL,
@CODIGO_TIPO_ENDERECO_FUNCIONARIO		INT = NULL,
@CODIGO_TIPO_LOGRADOURO_FUNCIONARIO		INT = NULL,
@CODIGO_CIDADE_FUNCIONARIO				INT = NULL,
@CODIGO_ESTADO_FUNCIONARIO				INT = NULL,
@LOGRADOURO_FUNCIONARIO					NVARCHAR(120) = NULL,
@NUMERO_FUNCIONARIO						NVARCHAR(8) = NULL,
@BAIRRO_FUNCIONARIO						NVARCHAR(80) = NULL,
@COMPLEMENTO_FUNCIONARIO				NVARCHAR(80) = NULL,
@CEP_FUNCIONARIO						CHAR(8) = NULL,
@NOME_PAI_FUNCIONARIO					NVARCHAR(100) = NULL,
@NACIONALIDADE_PAI_FUNCIONARIO			INT = NULL,
@NOME_MAE_FUNCIONARIO					NVARCHAR(100) = NULL,
@NACIONALIDADE_MAE_FUNCIONARIO			INT = NULL,
@NUMERO_IDENTIDADE						NVARCHAR(11) = NULL,
@NUMERO_CARTEIRA_TRABALHO				NVARCHAR(15) = NULL,
@NUMERO_SERIE							NVARCHAR(15) = NULL,
@NUMERO_CERTIFICADO_RESERVISTA			NVARCHAR(15) = NULL,
@CATEGORIA								NVARCHAR(15) = NULL,
@NUMERO_CPF								NVARCHAR(11) = NULL,
@TITULO_ELEITOR							NVARCHAR(15) = NULL,
@NUMERO_CARTEIRA_SAUDE					NVARCHAR(15) = NULL,
@NUMERO_CBO								NVARCHAR(80) = NULL,
@NUMERO_CARTEIRA_19						NVARCHAR(80) = NULL,
@NUMERO_RESISTRO_GERAL					NVARCHAR(80) = NULL,
@CASADO_BRASILEIRO						CHAR(1) = NULL,
@NUTURALIZADO							CHAR(1) = NULL,
@FILHO_BRASILEIRO						CHAR(1) = NULL,
@DATA_CHEGADA_BRASIL					DATETIME = NULL,
@DATA_CADASTRO_PIS						DATETIME = NULL,
@SOB_NUMERO_PIS							NVARCHAR(10) = NULL,
@NUMERO_BANCO_PIS						NVARCHAR(5) = NULL,			
@AGENCIA_PIS							NVARCHAR(10) = NULL,
@CONTA_PIS								NVARCHAR(10) = NULL,
@DIGITO_PIS								NVARCHAR(2) = NULL,
@CODIGO_TIPO_ENDERECO_PIS				INT = NULL,
@CODIGO_TIPO_LOGRADOURO_PIS				INT = NULL,
@CODIGO_CIDADE_PIS						INT = NULL,
@CODIGO_ESTADO_PIS						INT = NULL,
@LOGRADOURO_PIS							NVARCHAR(120) = NULL,
@NUMERO_PIS								NVARCHAR(8) = NULL,
@BAIRRO_PIS								NVARCHAR(80) = NULL,
@COMPLEMENTO_PIS						NVARCHAR(80) = NULL,
@CEP_PIS								CHAR(8) = NULL,
@OPTANTE								CHAR(1) = NULL,
@DATA_OPCAO								DATETIME = NULL,
@DATA_RETRATACAO						DATETIME = NULL,
@NUMERO_BANCO_FUNDO_GARANTIA			NVARCHAR(5) = NULL,			
@AGENCIA_FUNDO_GARANTIA					NVARCHAR(10) = NULL,
@CONTA_FUNDO_GARANTIA					NVARCHAR(10) = NULL,
@DIGITO_FUNDO_GARANTIA					NVARCHAR(2) = NULL,
@ALTURA									NVARCHAR(3) = NULL,
@PESO									NVARCHAR(3) = NULL,
@SINAIS									NVARCHAR(80) = NULL,
@CODIGO_TIPO_COR						INT = NULL,
@CODIGO_TIPO_CABELO						INT = NULL,
@CODIGO_TIPO_OLHO						INT = NULL,
@CODIGO_USUARIO_CADASTRO				INT = NULL,
@DATA_CADASTRO							DATETIME = NULL,
@CODIGO_USUARIO_ALTERACAO				INT = NULL,
@DATA_ALTERACAO							DATETIME = NULL,
@CODIGO_STATUS							INT = NULL,
@CODIGO_EMPRESA							INT = NULL

)
AS
BEGIN
	BEGIN TRY
		BEGIN TRANSACTION

			
			--INSERT NA TABELA DE ENDERECO COM LIGA��O DE FUNCIONARIO
			DECLARE @CODIGO_ENDERECO_FUNCIONARIO INT
			INSERT INTO TBVRT031_ENDERECO(
				CODIGO_USUARIO_CADASTRO,
				DATA_CADASTRO,
				CODIGO_USUARIO_ALTERACAO,
				DATA_ALTERACAO,
				CODIGO_STATUS
			)
			VALUES(
				@CODIGO_USUARIO_CADASTRO,
				GETDATE(),
				NULL,
				NULL,
				@CODIGO_STATUS
			)

			SET @CODIGO_ENDERECO_FUNCIONARIO = @@IDENTITY;
			--INSERT NA TABELA DE DETALHE ENDERECO COM LIGA��O DE FUNCIONARIO
			INSERT INTO TBVRT032_DETALHE_ENDERECO(
				CODIGO_ENDERECO,
				CODIGO_TIPO_ENDERECO,
				CODIGO_TIPO_LOGRADOURO,
				CODIGO_CIDADE,
				CODIGO_ESTADO,
				LOGRADOURO,
				NUMERO,
				BAIRRO,
				COMPLEMENTO,
				CEP,
				CODIGO_USUARIO_CADASTRO,
				DATA_CADASTRO,
				CODIGO_USUARIO_ALTERACAO,
				DATA_ALTERACAO,
				CODIGO_STATUS
			)
			VALUES(
				@CODIGO_ENDERECO_FUNCIONARIO,
				@CODIGO_TIPO_ENDERECO_FUNCIONARIO,
				@CODIGO_TIPO_LOGRADOURO_FUNCIONARIO,
				@CODIGO_CIDADE_FUNCIONARIO,
				@CODIGO_ESTADO_FUNCIONARIO,
				@LOGRADOURO_FUNCIONARIO,
				@NUMERO_FUNCIONARIO,
				@BAIRRO_FUNCIONARIO,
				@COMPLEMENTO_FUNCIONARIO,
				@CEP_FUNCIONARIO,
				@CODIGO_USUARIO_CADASTRO,
				GETDATE(),
				NULL,
				NULL,
				@CODIGO_STATUS
			)

			--INSERT NA TABELA DE FUNCIONARIO
			DECLARE @CODIGO_FUNCIONARIO INT
			INSERT INTO TBVRT006_FUNCIONARIO(
				CODIGO_ENDERECO,
				NOME_FUNCIONARIO,
				NUMERO_ORDEM_MATRICULA,
				NUMERO_MATRICULA,
				NOME_PAI,
				NACIONALIDADE_PAI,
				NOME_MAE,
				NACIONALIDADE_MAE,
				DATA_NASCIMENTO,
				CODIGO_ESTADO_CIVIL,
				LOCAL_NASCIMENTO,
				NOME_CONJUGE,
				QUANTOS_FILHOS,
				CODIGO_USUARIO_CADASTRO,
				DATA_CADASTRO,
				CODIGO_USUARIO_ALTERACAO,
				DATA_ALTERACAO,
				CODIGO_STATUS,
				CODIGO_EMPRESA
			)
			VALUES(
				@CODIGO_ENDERECO_FUNCIONARIO,
				@NOME_FUNCIONARIO_FUNCIONARIO,
				@NUMERO_ORDEM_MATRICULA_FUNCIONARIO,
				@NUMERO_MATRICULA_FUNCIONARIO,
				@NOME_PAI_FUNCIONARIO,
				@NACIONALIDADE_PAI_FUNCIONARIO,
				@NOME_MAE_FUNCIONARIO,
				@NACIONALIDADE_MAE_FUNCIONARIO,
				@DATA_NASCIMENTO_FUNCIONARIO,
				@CODIGO_ESTADO_CIVIL_FUNCIONARIO,
				@LOCAL_NASCIMENTO_FUNCIONARIO,
				@NOME_CONJUGE_FUNCIONARIO,
				@QUANTOS_FILHOS_FUNCIONARIO,
				@CODIGO_USUARIO_CADASTRO,
				GETDATE(),
				NULL,
				NULL,
				@CODIGO_STATUS,
				@CODIGO_EMPRESA
			)
			SET @CODIGO_FUNCIONARIO = @@IDENTITY;

			--INSERT NA TABELA DE DOCUMENTO
			INSERT INTO TBVRT007_DOCUMENTO(
				CODIGO_FUNCIONARIO,
				NUMERO_IDENTIDADE,
				NUMERO_CARTEIRA_TRABALHO,
				NUMERO_SERIE,
				NUMERO_CERTIFICADO_RESERVISTA,
				CATEGORIA,
				NUMERO_CPF,
				TITULO_ELEITOR,
				NUMERO_CARTEIRA_SAUDE,
				CODIGO_USUARIO_CADASTRO,
				DATA_CADASTRO,
				CODIGO_USUARIO_ALTERACAO,
				DATA_ALTERACAO,
				CODIGO_STATUS
			)
			VALUES(
				@CODIGO_FUNCIONARIO,
				@NUMERO_IDENTIDADE,
				@NUMERO_CARTEIRA_TRABALHO,
				@NUMERO_SERIE,
				@NUMERO_CERTIFICADO_RESERVISTA,
				@CATEGORIA,
				@NUMERO_CPF,
				@TITULO_ELEITOR,
				@NUMERO_CARTEIRA_SAUDE,
				@CODIGO_USUARIO_CADASTRO,
				GETDATE(),
				NULL,
				NULL,
				@CODIGO_STATUS
			)

			--INSER NA TABELA DE DOCUMENTO ESTRAGEIRO
			INSERT INTO TBVRT008_DOCUMENTO_ESTRANGEIRO(
				CODIGO_FUNCIONARIO,
				NUMERO_CBO,
				NUMERO_CARTEIRA_19,
				NUMERO_RESISTRO_GERAL,
				CASADO_BRASILEIRO,
				NUTURALIZADO,
				FILHO_BRASILEIRO,
				DATA_CHEGADA_BRASIL,
				CODIGO_USUARIO_CADASTRO,
				DATA_CADASTRO,
				CODIGO_USUARIO_ALTERACAO,
				DATA_ALTERACAO,
				CODIGO_STATUS
			)
			VALUES(
				@CODIGO_FUNCIONARIO,
				@NUMERO_CBO,
				@NUMERO_CARTEIRA_19,
				@NUMERO_RESISTRO_GERAL,
				@CASADO_BRASILEIRO,
				@NUTURALIZADO,
				@FILHO_BRASILEIRO,
				@DATA_CHEGADA_BRASIL,
				@CODIGO_USUARIO_CADASTRO,
				GETDATE(),
				NULL,
				NULL,
				@CODIGO_STATUS
			)

			--INSERT NA TABELA DE ENDERECO PARA A TABELA DE DOCUMENTO PIS BANCO
			DECLARE @CODIGO_ENDERECO_PIS INT
			INSERT INTO TBVRT031_ENDERECO(
				CODIGO_USUARIO_CADASTRO,
				DATA_CADASTRO,
				CODIGO_USUARIO_ALTERACAO,
				DATA_ALTERACAO,
				CODIGO_STATUS
			)
			VALUES(
				@CODIGO_USUARIO_CADASTRO,
				GETDATE(),
				NULL,
				NULL,
				@CODIGO_STATUS
			)
			SET @CODIGO_ENDERECO_PIS = @@IDENTITY;
			--INSERT NA TABELA DE DETALHE ENDERECO PARA A TABELA DE DOCUMENTO PIS BANCO
			INSERT INTO TBVRT032_DETALHE_ENDERECO(
				CODIGO_ENDERECO,
				CODIGO_TIPO_ENDERECO,
				CODIGO_TIPO_LOGRADOURO,
				CODIGO_CIDADE,
				CODIGO_ESTADO,
				LOGRADOURO,
				NUMERO,
				BAIRRO,
				COMPLEMENTO,
				CEP,
				CODIGO_USUARIO_CADASTRO,
				DATA_CADASTRO,
				CODIGO_USUARIO_ALTERACAO,
				DATA_ALTERACAO,
				CODIGO_STATUS
			)
			VALUES(
				@CODIGO_ENDERECO_PIS,
				@CODIGO_TIPO_ENDERECO_FUNCIONARIO,
				@CODIGO_TIPO_LOGRADOURO_FUNCIONARIO,
				@CODIGO_CIDADE_PIS,
				@CODIGO_ESTADO_PIS,
				@LOGRADOURO_PIS,
				@NUMERO_PIS,
				@BAIRRO_PIS,
				@COMPLEMENTO_PIS,
				@CEP_PIS,
				@CODIGO_USUARIO_CADASTRO,
				GETDATE(),
				NULL,
				NULL,
				@CODIGO_STATUS
			)
			--INSERT NA TABELA DE BANCO PIS
			DECLARE @CODIGO_BANCO_PIS INT
			INSERT INTO TBVRT039_BANCO(
				NUMERO_BANCO,
				AGENCIA,
				CONTA,
				DIGITO,
				CODIGO_ENDERECO,
				CODIGO_USUARIO_CADASTRO,
				DATA_CADASTRO,
				CODIGO_USUARIO_ALTERACAO,
				DATA_ALTERACAO,
				CODIGO_STATUS
			)
			VALUES(
				@NUMERO_BANCO_PIS,
				@AGENCIA_PIS,
				@CONTA_PIS,
				@DIGITO_PIS,
				@CODIGO_ENDERECO_PIS,
				@CODIGO_USUARIO_CADASTRO,
				GETDATE(),
				NULL,
				NULL,
				@CODIGO_STATUS
			)
			SET @CODIGO_BANCO_PIS = @@IDENTITY;

			--INSERT NA TABELA DE DOCUMENTO PIS
			INSERT INTO TBVRT009_DOCUMENTO_PIS(
				DATA_CADASTRO_PIS,
				SOB_NUMERO,
				CODIGO_ENDERECO,
				CODIGO_FUNCIONARIO,
				CODIGO_BANCO,
				CODIGO_USUARIO_CADASTRO,
				DATA_CADASTRO,
				CODIGO_USUARIO_ALTERACAO,
				DATA_ALTERACAO,
				CODIGO_STATUS
			)
			VALUES(
				@DATA_CADASTRO_PIS,
				@SOB_NUMERO_PIS,
				@CODIGO_ENDERECO_PIS,
				@CODIGO_FUNCIONARIO,
				@CODIGO_BANCO_PIS,
				@CODIGO_USUARIO_CADASTRO,
				GETDATE(),
				NULL,
				NULL,
				@CODIGO_STATUS
			)

			--INSERT NA TABELA DE BANCO FUNDO DE GARANTIA
			DECLARE @CODIGO_BANCO_FUNDO_GARANTIA INT
			INSERT INTO TBVRT039_BANCO(
				NUMERO_BANCO,
				AGENCIA,
				CONTA,
				DIGITO,
				CODIGO_USUARIO_CADASTRO,
				DATA_CADASTRO,
				CODIGO_USUARIO_ALTERACAO,
				DATA_ALTERACAO,
				CODIGO_STATUS
			)
			VALUES(
				@NUMERO_BANCO_FUNDO_GARANTIA,
				@AGENCIA_FUNDO_GARANTIA,
				@CONTA_FUNDO_GARANTIA,
				@DIGITO_FUNDO_GARANTIA,
				@CODIGO_USUARIO_CADASTRO,
				GETDATE(),
				NULL,
				NULL,
				@CODIGO_STATUS
			)
			SET @CODIGO_BANCO_FUNDO_GARANTIA = @@IDENTITY;
			
			--INSERT NA TABELA DE FUNDO DE GARANTIA
			INSERT INTO TBVRT010_DOCUMENTO_FUNDO_GARANTIA(
				CODIGO_FUNCIONARIO,
				OPTANTE,
				DATA_OPCAO,
				DATA_RETRATACAO,
				CODIGO_BANCO,
				CODIGO_USUARIO_CADASTRO,
				DATA_CADASTRO,
				CODIGO_USUARIO_ALTERACAO,
				DATA_ALTERACAO,
				CODIGO_STATUS
			)
			VALUES(
				@CODIGO_FUNCIONARIO,
				@OPTANTE,
				@DATA_OPCAO,
				@DATA_RETRATACAO,
				@CODIGO_BANCO_FUNDO_GARANTIA,
				@CODIGO_USUARIO_CADASTRO,
				GETDATE(),
				NULL,
				NULL,
				@CODIGO_STATUS
			)

			--INSERT NA TABELA DE CARACTERISTICA FISICA
			INSERT INTO TBVRT015_CARACTERISTICA_FISICA(
				CODIGO_FUNCIONARIO,
				CODIGO_TIPO_COR,
				ALTURA,
				PESO,
				CODIGO_TIPO_CABELO,
				CODIGO_TIPO_OLHO,
				SINAIS,
				CODIGO_USUARIO_CADASTRO,
				DATA_CADASTRO,
				CODIGO_USUARIO_ALTERACAO,
				DATA_ALTERACAO,
				CODIGO_STATUS
			)
			VALUES(
				@CODIGO_FUNCIONARIO,
				@CODIGO_TIPO_COR,
				@ALTURA,
				@PESO,
				@CODIGO_TIPO_CABELO,
				@CODIGO_TIPO_OLHO,
				@SINAIS,
				@CODIGO_USUARIO_CADASTRO,
				@DATA_CADASTRO,
				@CODIGO_USUARIO_ALTERACAO,
				@DATA_ALTERACAO,
				@CODIGO_STATUS
			)
			DECLARE @DESC VARCHAR(120)
			IF(@@ERROR = 0)
				BEGIN
				SET @DESC = 'SUCESSO AO INCLUIR UM FUNCION�RIO - CODIGO DO FUNCION�RIO' + CAST(@CODIGO_FUNCIONARIO AS VARCHAR)

				EXEC dbo.SPVRT028_LOG_PR_INCLUIR 'A', @DESC , @CODIGO_USUARIO_CADASTRO, 'INCLUS�O DE FUNCION�RIO';
				--Retorna da inclus�o
				SELECT
					FUNC.CODIGO_FUNCIONARIO AS	FUNC_CODIGO_FUNCIONARIO,
					FUNC.NOME_FUNCIONARIO AS	FUNC_NOME_FUNCIONARIO,
					FUNC.NUMERO_ORDEM_MATRICULA AS	FUNC_NUMERO_ORDEM_MATRICULA,
					FUNC.NUMERO_MATRICULA AS	FUNC_NUMERO_MATRICULA,
					FUNC.NOME_PAI AS	FUNC_NOME_PAI,
					FUNC.NACIONALIDADE_PAI AS	FUNC_NACIONALIDADE_PAI,
					FUNC.NOME_MAE AS	FUNC_NOME_MAE,
					FUNC.NACIONALIDADE_MAE AS	FUNC_NACIONALIDADE_MAE,
					FUNC.DATA_NASCIMENTO AS	FUNC_DATA_NASCIMENTO,
					FUNC.CODIGO_ESTADO_CIVIL AS	FUNC_CODIGO_ESTADO_CIVIL,
					CIVIL.DESCRICAO AS	CIVIL_DESCRICAO,
					FUNC.LOCAL_NASCIMENTO AS	FUNC_LOCAL_NASCIMENTO,
					FUNC.NOME_CONJUGE AS	FUNC_NOME_CONJUGE,
					FUNC.QUANTOS_FILHOS AS	FUNC_QUANTOS_FILHOS,
					DETL_END.CODIGO_ENDERECO AS	DETL_END_CODIGO_ENDERECO,
					DETL_END.CODIGO_TIPO_ENDERECO AS	DETL_END_CODIGO_TIPO_ENDERECO,
					TIPO_END_FUNC.DESCRICAO AS	TIPO_END_FUNC_DESCRICAO,
					DETL_END.CODIGO_TIPO_LOGRADOURO AS	DETL_END_CODIGO_TIPO_LOGRADOURO,
					TIPO_LOG_FUNC.DESCRICAO AS	TIPO_LOG_FUNC_DESCRICAO,
					DETL_END.LOGRADOURO AS	DETL_END_LOGRADOURO,
					DETL_END.NUMERO AS	DETL_END_NUMERO,
					DETL_END.BAIRRO AS	DETL_END_BAIRRO,
					DETL_END.COMPLEMENTO AS	DETL_END_COMPLEMENTO,
					DETL_END.CEP AS	DETL_END_CEP,
					DOC_FUNC.CODIGO_FUNCIONARIO AS	DOC_FUNC_CODIGO_FUNCIONARIO,
					DOC_FUNC.NUMERO_IDENTIDADE AS	DOC_FUNC_NUMERO_IDENTIDADE,
					DOC_FUNC.NUMERO_CARTEIRA_TRABALHO AS	DOC_FUNC_NUMERO_CARTEIRA_TRABALHO,
					DOC_FUNC.NUMERO_SERIE AS	DOC_FUNC_NUMERO_SERIE,
					DOC_FUNC.NUMERO_CERTIFICADO_RESERVISTA AS	DOC_FUNC_NUMERO_CERTIFICADO_RESERVISTA,
					DOC_FUNC.CATEGORIA AS	DOC_FUNC_CATEGORIA,
					DOC_FUNC.NUMERO_CPF AS	DOC_FUNC_NUMERO_CPF,
					DOC_FUNC.TITULO_ELEITOR AS	DOC_FUNC_TITULO_ELEITOR,
					DOC_FUNC.NUMERO_CARTEIRA_SAUDE AS	DOC_FUNC_NUMERO_CARTEIRA_SAUDE,
					DOC_EST_FUNC.CODIGO_FUNCIONARIO AS	DOC_EST_FUNC_CODIGO_FUNCIONARIO,
					DOC_EST_FUNC.NUMERO_CBO AS	DOC_EST_FUNC_NUMERO_CBO,
					DOC_EST_FUNC.NUMERO_CARTEIRA_19 AS	DOC_EST_FUNC_NUMERO_CARTEIRA_19,
					DOC_EST_FUNC.NUMERO_RESISTRO_GERAL AS	DOC_EST_FUNC_NUMERO_RESISTRO_GERAL,
					DOC_EST_FUNC.CASADO_BRASILEIRO AS	DOC_EST_FUNC_CASADO_BRASILEIRO,
					DOC_EST_FUNC.NUTURALIZADO AS	DOC_EST_FUNC_NUTURALIZADO,
					DOC_EST_FUNC.FILHO_BRASILEIRO AS	DOC_EST_FUNC_FILHO_BRASILEIRO,
					DOC_EST_FUNC.DATA_CHEGADA_BRASIL AS	DOC_EST_FUNC_DATA_CHEGADA_BRASIL,
					DOC_PIS_FUNC.DATA_CADASTRO_PIS AS	DOC_PIS_FUNC_DATA_CADASTRO_PIS,
					DOC_PIS_FUNC.SOB_NUMERO AS	DOC_PIS_FUNC_SOB_NUMERO,
					DOC_PIS_FUNC.CODIGO_ENDERECO AS	DOC_PIS_FUNC_CODIGO_ENDERECO,
					DOC_PIS_FUNC.CODIGO_FUNCIONARIO AS	DOC_PIS_FUNC_CODIGO_FUNCIONARIO,
					DOC_PIS_FUNC.CODIGO_BANCO AS	DOC_PIS_FUNC_CODIGO_BANCO,
					DETL_PIS.CODIGO_ENDERECO AS	DETL_PIS_CODIGO_ENDERECO,
					DETL_PIS.CODIGO_TIPO_ENDERECO AS	DETL_PIS_CODIGO_TIPO_ENDERECO,
					TIPO_END_PIS.DESCRICAO AS	TIPO_END_PIS_DESCRICAO,
					DETL_PIS.CODIGO_TIPO_LOGRADOURO AS	DETL_PIS_CODIGO_TIPO_LOGRADOURO,
					TIPO_LOG_PIS.DESCRICAO AS	TIPO_LOG_PIS_DESCRICAO,
					DETL_PIS.LOGRADOURO AS	DETL_PIS_LOGRADOURO,
					DETL_PIS.NUMERO AS	DETL_PIS_NUMERO,
					DETL_PIS.BAIRRO AS	DETL_PIS_BAIRRO,
					DETL_PIS.COMPLEMENTO AS	DETL_PIS_COMPLEMENTO,
					DETL_PIS.CEP AS	DETL_PIS_CEP,
					BANCO_PIS.NUMERO_BANCO AS	BANCO_PIS_NUMERO_BANCO,
					BANCO_PIS.AGENCIA AS	BANCO_PIS_AGENCIA,
					BANCO_PIS.DIGITO AS	BANCO_PIS_DIGITO,
					BANCO_PIS.CODIGO_ENDERECO AS	BANCO_PIS_CODIGO_ENDERECO,
					DOC_FGTS_FUNC.CODIGO_FUNCIONARIO AS	DOC_FGTS_FUNC_CODIGO_FUNCIONARIO,
					DOC_FGTS_FUNC.OPTANTE AS	DOC_FGTS_FUNC_OPTANTE,
					DOC_FGTS_FUNC.DATA_OPCAO AS	DOC_FGTS_FUNC_DATA_OPCAO,
					DOC_FGTS_FUNC.DATA_RETRATACAO AS	DOC_FGTS_FUNC_DATA_RETRATACAO,
					DOC_FGTS_FUNC.CODIGO_BANCO AS	DOC_FGTS_FUNC_CODIGO_BANCO,
					BANCO_FGTS.NUMERO_BANCO AS	BANCO_FGTS_NUMERO_BANCO,
					BANCO_FGTS.AGENCIA AS	BANCO_FGTS_AGENCIA,
					BANCO_FGTS.DIGITO AS	BANCO_FGTS_DIGITO,
					BANCO_FGTS.CODIGO_ENDERECO AS	BANCO_FGTS_CODIGO_ENDERECO,
					CARACTERISTICA_FUNC.CODIGO_FUNCIONARIO AS	CARACTERISTICA_FUNC_CODIGO_FUNCIONARIO,
					CARACTERISTICA_FUNC.CODIGO_TIPO_COR AS	CARACTERISTICA_FUNC_CODIGO_TIPO_COR,
					CARACTERISTICA_FUNC.ALTURA AS	CARACTERISTICA_FUNC_ALTURA,
					CARACTERISTICA_FUNC.PESO AS	CARACTERISTICA_FUNC_PESO,
					CARACTERISTICA_FUNC.CODIGO_TIPO_CABELO AS	CARACTERISTICA_FUNC_CODIGO_TIPO_CABELO,
					CARACTERISTICA_FUNC.CODIGO_TIPO_OLHO AS	CARACTERISTICA_FUNC_CODIGO_TIPO_OLHO,
					CARACTERISTICA_FUNC.SINAIS AS	CARACTERISTICA_FUNC_SINAIS,
					FUNC.CODIGO_USUARIO_CADASTRO AS	FUNC_CODIGO_USUARIO_CADASTRO,
					FUNC.DATA_CADASTRO AS	FUNC_DATA_CADASTRO,
					FUNC.CODIGO_USUARIO_ALTERACAO AS	FUNC_CODIGO_USUARIO_ALTERACAO,
					FUNC.DATA_ALTERACAO AS	FUNC_DATA_ALTERACAO,
					FUNC.CODIGO_STATUS AS	FUNC_CODIGO_STATUS
					FROM TBVRT006_FUNCIONARIO FUNC
						LEFT JOIN TBVRT040_ESTADO_CIVIL AS CIVIL
						ON FUNC.CODIGO_ESTADO_CIVIL = CIVIL.CODIGO_ESTADO_CIVIL
						LEFT JOIN TBVRT031_ENDERECO END_FUNC
						ON FUNC.CODIGO_ENDERECO = END_FUNC.CODIGO_ENDERECO
						LEFT JOIN TBVRT032_DETALHE_ENDERECO DETL_END
						ON END_FUNC.CODIGO_ENDERECO = DETL_END.CODIGO_ENDERECO
						LEFT JOIN TBVRT007_DOCUMENTO AS DOC_FUNC
						ON FUNC.CODIGO_FUNCIONARIO = DOC_FUNC.CODIGO_FUNCIONARIO
						LEFT JOIN TBVRT008_DOCUMENTO_ESTRANGEIRO AS DOC_EST_FUNC
						ON FUNC.CODIGO_FUNCIONARIO = DOC_EST_FUNC.CODIGO_FUNCIONARIO
						LEFT JOIN TBVRT009_DOCUMENTO_PIS AS DOC_PIS_FUNC
						ON FUNC.CODIGO_FUNCIONARIO = DOC_PIS_FUNC.CODIGO_FUNCIONARIO
						LEFT JOIN TBVRT031_ENDERECO END_PIS
						ON DOC_PIS_FUNC.CODIGO_ENDERECO = END_PIS.CODIGO_ENDERECO
						LEFT JOIN TBVRT032_DETALHE_ENDERECO DETL_PIS
						ON DOC_PIS_FUNC.CODIGO_ENDERECO = DETL_PIS.CODIGO_ENDERECO
						LEFT JOIN TBVRT039_BANCO BANCO_PIS
						ON DOC_PIS_FUNC.CODIGO_BANCO = BANCO_PIS.CODIGO_BANCO
						LEFT JOIN TBVRT010_DOCUMENTO_FUNDO_GARANTIA AS DOC_FGTS_FUNC
						ON FUNC.CODIGO_FUNCIONARIO = DOC_FGTS_FUNC.CODIGO_FUNCIONARIO
						LEFT JOIN TBVRT039_BANCO BANCO_FGTS
						ON DOC_FGTS_FUNC.CODIGO_BANCO = BANCO_FGTS.CODIGO_BANCO
						LEFT JOIN TBVRT015_CARACTERISTICA_FISICA CARACTERISTICA_FUNC
						ON FUNC.CODIGO_FUNCIONARIO = CARACTERISTICA_FUNC.CODIGO_FUNCIONARIO
						LEFT JOIN TBVRT033_TIPO_ENDERECO TIPO_END_FUNC
						ON DETL_END.CODIGO_TIPO_ENDERECO = TIPO_END_FUNC.CODIGO_TIPO_ENDERECO
						LEFT JOIN TBVRT033_TIPO_ENDERECO TIPO_END_PIS
						ON DETL_PIS.CODIGO_TIPO_ENDERECO = TIPO_END_PIS.CODIGO_TIPO_ENDERECO
						LEFT JOIN TBVRT034_TIPO_LOGRADOURO TIPO_LOG_FUNC
						ON DETL_END.CODIGO_TIPO_LOGRADOURO = TIPO_LOG_FUNC.CODIGO_TIPO_LOGRADOURO
						LEFT JOIN TBVRT034_TIPO_LOGRADOURO TIPO_LOG_PIS
						ON DETL_PIS.CODIGO_TIPO_LOGRADOURO = TIPO_LOG_PIS.CODIGO_TIPO_LOGRADOURO
					WHERE
						(FUNC.CODIGO_FUNCIONARIO = @CODIGO_FUNCIONARIO OR @CODIGO_FUNCIONARIO IS NULL)
					END

		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION

		SET @DESC = 'ERRO AO INCLUIR UM TIPO DE TAREFA - CODIGO DO ERRO' + CAST(@@ERROR AS VARCHAR)

			EXEC dbo.SPVRT028_LOG_PR_INCLUIR 'E', @DESC , @CODIGO_USUARIO_CADASTRO, 'INCLUS�O DE TIPO DE TAREFA';

			SELECT @@ERROR as Erro, @DESC as Mensagem

		DECLARE @ErrorMessage nvarchar(4000);
		DECLARE @ErrorSeverity INT;
		DECLARE @ErrorState int;
		DECLARE @ERROR_NUMBER int;


		SELECT 
		@ErrorMessage  = ERROR_MESSAGE(), 
		@ErrorSeverity = ERROR_SEVERITY(),
		@ErrorState  = ERROR_STATE(),
		@ERROR_NUMBER = ERROR_NUMBER();

		SET @DESC = 'ERRO AO INCLUIR UM FUNCION�RIO - CODIGO DO ERRO' + CAST(@ERROR_NUMBER AS VARCHAR)

		EXEC dbo.SPVRT028_LOG_PR_INCLUIR 'E', @DESC , @CODIGO_USUARIO_CADASTRO, 'INCLUS�O DE FUNCION�RIO';

		SELECT @ERROR_NUMBER as Erro, @DESC as Mensagem


		RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);

	END CATCH
END





GO


