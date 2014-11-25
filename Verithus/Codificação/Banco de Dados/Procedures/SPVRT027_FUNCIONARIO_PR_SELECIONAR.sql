USE [DBVERITHUS]
GO

/****** Object:  StoredProcedure [dbo].[SPVRT027_FUNCIONARIO_PR_SELECIONAR]    Script Date: 24/11/2014 06:25:46 ******/
DROP PROCEDURE [dbo].[SPVRT027_FUNCIONARIO_PR_SELECIONAR]
GO

/****** Object:  StoredProcedure [dbo].[SPVRT027_FUNCIONARIO_PR_SELECIONAR]    Script Date: 24/11/2014 06:25:46 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO














CREATE PROCEDURE [dbo].[SPVRT027_FUNCIONARIO_PR_SELECIONAR]
(
	@CODIGO_FUNCIONARIO						INT = NULL,
	@NUMERO_ORDEM_MATRICULA_FUNCIONARIO		INT = NULL,
	@NUMERO_MATRICULA_FUNCIONARIO			INT = NULL,
	@CODIGO_USUARIO_CADASTRO	INT = NULL,
	@NOME_FUNCIONARIO_FUNCIONARIO			NVARCHAR(100) = NULL
)
AS
BEGIN

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
		CONVERT(NVARCHAR, FUNC.DATA_NASCIMENTO, 103) AS FUNC_DATA_NASCIMENTO_STR,
		FUNC.CODIGO_ESTADO_CIVIL AS	FUNC_CODIGO_ESTADO_CIVIL,
		CIVIL.DESCRICAO AS	CIVIL_DESCRICAO,
		FUNC.LOCAL_NASCIMENTO AS	FUNC_LOCAL_NASCIMENTO,
		FUNC.NOME_CONJUGE AS	FUNC_NOME_CONJUGE,
		FUNC.QUANTOS_FILHOS AS	FUNC_QUANTOS_FILHOS,
		DETL_END.CODIGO_ENDERECO AS	DETL_END_CODIGO_ENDERECO,
		DETL_END.CODIGO_TIPO_ENDERECO AS	DETL_END_CODIGO_TIPO_ENDERECO,
		TIPO_END_FUNC.DESCRICAO AS	TIPO_END_FUNC_DESCRICAO,
		DETL_END.CODIGO_TIPO_LOGRADOURO AS	DETL_END_CODIGO_TIPO_LOGRADOURO,
		DETL_END.CODIGO_ESTADO AS DETL_END_CODIGO_ESTADO,
		DETL_END.CODIGO_CIDADE AS DETL_END_CODIGO_CIDADE,
		TIPO_LOG_FUNC.DESCRICAO AS	TIPO_LOG_FUNC_DESCRICAO,
		DETL_END.LOGRADOURO AS	DETL_END_LOGRADOURO,
		DETL_END.NUMERO AS	DETL_END_NUMERO,
		DETL_END.BAIRRO AS	DETL_END_BAIRRO,
		DETL_END.COMPLEMENTO AS	DETL_END_COMPLEMENTO,
		DETL_END.CEP AS	DETL_END_CEP,
		DOC_FUNC.CODIGO_DOCUMENTO AS	DOC_FUNC_CODIGO_DOCUMENTO,
		DOC_FUNC.NUMERO_IDENTIDADE AS	DOC_FUNC_NUMERO_IDENTIDADE,
		DOC_FUNC.NUMERO_CARTEIRA_TRABALHO AS	DOC_FUNC_NUMERO_CARTEIRA_TRABALHO,
		DOC_FUNC.NUMERO_SERIE AS	DOC_FUNC_NUMERO_SERIE,
		DOC_FUNC.NUMERO_CERTIFICADO_RESERVISTA AS	DOC_FUNC_NUMERO_CERTIFICADO_RESERVISTA,
		DOC_FUNC.CATEGORIA AS	DOC_FUNC_CATEGORIA,
		DOC_FUNC.NUMERO_CPF AS	DOC_FUNC_NUMERO_CPF,
		DOC_FUNC.TITULO_ELEITOR AS	DOC_FUNC_TITULO_ELEITOR,
		DOC_FUNC.NUMERO_CARTEIRA_SAUDE AS	DOC_FUNC_NUMERO_CARTEIRA_SAUDE,
		DOC_EST_FUNC.CODIGO_DOCUMENTO_ESTRAGEIRO AS	DOC_EST_FUNC_CODIGO_DOCUMENTO_ESTRAGEIRO,
		DOC_EST_FUNC.NUMERO_CBO AS	DOC_EST_FUNC_NUMERO_CBO,
		DOC_EST_FUNC.NUMERO_CARTEIRA_19 AS	DOC_EST_FUNC_NUMERO_CARTEIRA_19,
		DOC_EST_FUNC.NUMERO_RESISTRO_GERAL AS	DOC_EST_FUNC_NUMERO_RESISTRO_GERAL,
		DOC_EST_FUNC.CASADO_BRASILEIRO AS	DOC_EST_FUNC_CASADO_BRASILEIRO,
		DOC_EST_FUNC.NUTURALIZADO AS	DOC_EST_FUNC_NUTURALIZADO,
		DOC_EST_FUNC.FILHO_BRASILEIRO AS	DOC_EST_FUNC_FILHO_BRASILEIRO,
		DOC_EST_FUNC.DATA_CHEGADA_BRASIL AS	DOC_EST_FUNC_DATA_CHEGADA_BRASIL,
		DOC_PIS_FUNC.DATA_CADASTRO_PIS AS	DOC_PIS_FUNC_DATA_CADASTRO_PIS,
		CONVERT(NVARCHAR, DOC_PIS_FUNC.DATA_CADASTRO_PIS, 103) AS DOC_PIS_FUNC_DATA_CADASTRO_PIS_STR,
		DOC_PIS_FUNC.SOB_NUMERO AS	DOC_PIS_FUNC_SOB_NUMERO,
		DOC_PIS_FUNC.CODIGO_PIS AS DOC_PIS_FUNC_CODIGO_PIS,
		DOC_PIS_FUNC.CODIGO_ENDERECO AS	DOC_PIS_FUNC_CODIGO_ENDERECO,
		DOC_PIS_FUNC.CODIGO_FUNCIONARIO AS	DOC_PIS_FUNC_CODIGO_FUNCIONARIO,
		DOC_PIS_FUNC.CODIGO_BANCO AS	DOC_PIS_FUNC_CODIGO_BANCO,
		DETL_PIS.CODIGO_ENDERECO AS	DETL_PIS_CODIGO_ENDERECO,
		DETL_PIS.CODIGO_TIPO_ENDERECO AS	DETL_PIS_CODIGO_TIPO_ENDERECO,
		TIPO_END_PIS.DESCRICAO AS	TIPO_END_PIS_DESCRICAO,
		DETL_PIS.CODIGO_TIPO_LOGRADOURO AS	DETL_PIS_CODIGO_TIPO_LOGRADOURO,
		DETL_PIS.CODIGO_ESTADO AS DETL_PIS_CODIGO_ESTADO,
		DETL_PIS.CODIGO_CIDADE AS DETL_PIS_CODIGO_CIDADE,
		TIPO_LOG_PIS.DESCRICAO AS	TIPO_LOG_PIS_DESCRICAO,
		DETL_PIS.LOGRADOURO AS	DETL_PIS_LOGRADOURO,
		DETL_PIS.NUMERO AS	DETL_PIS_NUMERO,
		DETL_PIS.BAIRRO AS	DETL_PIS_BAIRRO,
		DETL_PIS.COMPLEMENTO AS	DETL_PIS_COMPLEMENTO,
		DETL_PIS.CEP AS	DETL_PIS_CEP,
		BANCO_PIS.CODIGO_BANCO AS BANCO_PIS_CODIGO_BANCO,
		BANCO_PIS.NUMERO_BANCO AS	BANCO_PIS_NUMERO_BANCO,
		BANCO_PIS.AGENCIA AS	BANCO_PIS_AGENCIA,
		BANCO_PIS.DIGITO AS	BANCO_PIS_DIGITO,
		BANCO_PIS.CONTA AS BANCO_PIS_CONTA,
		BANCO_PIS.CODIGO_ENDERECO AS	BANCO_PIS_CODIGO_ENDERECO,
		DOC_FGTS_FUNC.CODIGO_DOCUMENTO_FUNDO_GARANTIA AS	DOC_FGTS_FUNC_CODIGO_DOCUMENTO_FUNDO_GARANTIA,
		DOC_FGTS_FUNC.OPTANTE AS	DOC_FGTS_FUNC_OPTANTE,
		DOC_FGTS_FUNC.DATA_OPCAO AS	DOC_FGTS_FUNC_DATA_OPCAO,
		CONVERT(NVARCHAR, DOC_FGTS_FUNC.DATA_OPCAO, 103) AS DOC_FGTS_FUNC_DATA_OPCAO_STR,
		DOC_FGTS_FUNC.DATA_RETRATACAO AS	DOC_FGTS_FUNC_DATA_RETRATACAO,
		CONVERT(NVARCHAR, DOC_FGTS_FUNC.DATA_RETRATACAO, 103) AS DOC_FGTS_FUNC_DATA_RETRATACAO_STR,
		DOC_FGTS_FUNC.CODIGO_BANCO AS	DOC_FGTS_FUNC_CODIGO_BANCO,
		BANCO_FGTS.CODIGO_BANCO AS BANCO_FGTS_CODIGO_BANCO,
		BANCO_FGTS.NUMERO_BANCO AS	BANCO_FGTS_NUMERO_BANCO,
		BANCO_FGTS.AGENCIA AS	BANCO_FGTS_AGENCIA,
		BANCO_FGTS.DIGITO AS	BANCO_FGTS_DIGITO,
		BANCO_FGTS.CONTA AS BANCO_FGTS_CONTA,
		BANCO_FGTS.CODIGO_ENDERECO AS	BANCO_FGTS_CODIGO_ENDERECO,
		CARACTERISTICA_FUNC.CODIGO_CARACTERISTICA_FISICA AS	CARACTERISTICA_FUNC_CODIGO_CARACTERISTICA_FISICA,
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
		FUNC.CODIGO_STATUS AS	FUNC_CODIGO_STATUS,
		EMPR.CODIGO_EMPRESA AS EMPR_CODIGO_EMPRESA,
		EMPR.RAZAO_SOCIAL AS EMPR_RAZAO_SOCIAL,
		EST_FUNC.DESCRICAO AS EST_FUNC_DESCRICAO,
		CID_FUNC.DESCRICAO AS CID_FUNC_DESCRICAO,
		TP_COR.DESCRICAO AS COR_DESCRICAO,
		TP_CAB.DESCRICAO AS CABELO_DESCRICAO,
		TP_OLH.DESCRICAO AS OLHO_DESCRICAO,
		TP_BANCO_PIS.NOME_BANCO AS BANCO_PIS_DESCRICAO,
		CID_PIS.DESCRICAO AS CIDADE_PIS_DESCRICAO,
		EST_PIS.DESCRICAO AS ESTADO_PIS_DESCRICAO,
		TP_BANCO_FGTS.NOME_BANCO AS	BANCO_FGTS_DESCRICAO,
		PAIS_PAI.DESCRICAO AS FUNC_NACIONALIDADE_PAI_PAIS,
		PAIS_MAE.DESCRICAO AS FUNC_NACIONALIDADE_MAE_PAIS,
		PAIS_FUNC.DESCRICAO AS FUNC_LOCAL_NASCIMENTO_PAIS
	FROM TBVRT006_FUNCIONARIO FUNC
	INNER JOIN TBVRT040_ESTADO_CIVIL AS CIVIL
	ON FUNC.CODIGO_ESTADO_CIVIL = CIVIL.CODIGO_ESTADO_CIVIL
	INNER JOIN TBVRT031_ENDERECO END_FUNC
	ON FUNC.CODIGO_ENDERECO = END_FUNC.CODIGO_ENDERECO
	INNER JOIN TBVRT032_DETALHE_ENDERECO DETL_END
	ON END_FUNC.CODIGO_ENDERECO = DETL_END.CODIGO_ENDERECO
	INNER JOIN TBVRT042_CIDADE CID_FUNC
	ON DETL_END.CODIGO_CIDADE = CID_FUNC.CODIGO_CIDADE
	INNER JOIN TBVRT043_ESTADO EST_FUNC
	ON DETL_END.CODIGO_ESTADO = EST_FUNC.CODIGO_ESTADO
	INNER JOIN TBVRT007_DOCUMENTO AS DOC_FUNC
	ON FUNC.CODIGO_FUNCIONARIO = DOC_FUNC.CODIGO_FUNCIONARIO
	INNER JOIN TBVRT008_DOCUMENTO_ESTRANGEIRO AS DOC_EST_FUNC
	ON FUNC.CODIGO_FUNCIONARIO = DOC_EST_FUNC.CODIGO_FUNCIONARIO
	INNER JOIN TBVRT009_DOCUMENTO_PIS AS DOC_PIS_FUNC
	ON FUNC.CODIGO_FUNCIONARIO = DOC_PIS_FUNC.CODIGO_FUNCIONARIO
	INNER JOIN TBVRT031_ENDERECO END_PIS
	ON DOC_PIS_FUNC.CODIGO_ENDERECO = END_PIS.CODIGO_ENDERECO
	INNER JOIN TBVRT032_DETALHE_ENDERECO DETL_PIS
	ON DOC_PIS_FUNC.CODIGO_ENDERECO = DETL_PIS.CODIGO_ENDERECO
	INNER JOIN TBVRT039_BANCO BANCO_PIS
	ON DOC_PIS_FUNC.CODIGO_BANCO = BANCO_PIS.CODIGO_BANCO
	INNER JOIN TBVRT010_DOCUMENTO_FUNDO_GARANTIA AS DOC_FGTS_FUNC
	ON FUNC.CODIGO_FUNCIONARIO = DOC_FGTS_FUNC.CODIGO_FUNCIONARIO
	INNER JOIN TBVRT039_BANCO BANCO_FGTS
	ON DOC_FGTS_FUNC.CODIGO_BANCO = BANCO_FGTS.CODIGO_BANCO
	INNER JOIN TBVRT015_CARACTERISTICA_FISICA CARACTERISTICA_FUNC
	ON FUNC.CODIGO_FUNCIONARIO = CARACTERISTICA_FUNC.CODIGO_FUNCIONARIO
	INNER JOIN TBVRT033_TIPO_ENDERECO TIPO_END_FUNC
	ON DETL_END.CODIGO_TIPO_ENDERECO = TIPO_END_FUNC.CODIGO_TIPO_ENDERECO
	INNER JOIN TBVRT033_TIPO_ENDERECO TIPO_END_PIS
	ON DETL_PIS.CODIGO_TIPO_ENDERECO = TIPO_END_PIS.CODIGO_TIPO_ENDERECO
	INNER JOIN TBVRT034_TIPO_LOGRADOURO TIPO_LOG_FUNC
	ON DETL_END.CODIGO_TIPO_LOGRADOURO = TIPO_LOG_FUNC.CODIGO_TIPO_LOGRADOURO
	INNER JOIN TBVRT034_TIPO_LOGRADOURO TIPO_LOG_PIS
	ON DETL_PIS.CODIGO_TIPO_LOGRADOURO = TIPO_LOG_PIS.CODIGO_TIPO_LOGRADOURO
	INNER JOIN TBVRT030_EMPRESA EMPR
	ON EMPR.CODIGO_EMPRESA = FUNC.CODIGO_EMPRESA
	INNER JOIN TBVRT016_TIPO_COR TP_COR
	ON TP_COR.CODIGO_TIPO_COR = CARACTERISTICA_FUNC.CODIGO_TIPO_COR
	INNER JOIN TBVRT017_TIPO_CABELO TP_CAB
	ON TP_CAB.CODIGO_TIPO_CABELO = CARACTERISTICA_FUNC.CODIGO_TIPO_CABELO
	INNER JOIN TBVRT018_TIPO_OLHO TP_OLH
	ON TP_OLH.CODIGO_TIPO_OLHO = CARACTERISTICA_FUNC.CODIGO_TIPO_OLHO
	INNER JOIN TBVRT044_TIPO_BANCO TP_BANCO_PIS
	ON TP_BANCO_PIS.CODIGO_BANCO = DOC_PIS_FUNC.CODIGO_BANCO
	INNER JOIN TBVRT042_CIDADE CID_PIS
	ON CID_PIS.CODIGO_CIDADE = DETL_PIS.CODIGO_CIDADE
	INNER JOIN TBVRT043_ESTADO EST_PIS
	ON EST_PIS.CODIGO_ESTADO = DETL_PIS.CODIGO_ESTADO
	INNER JOIN TBVRT044_TIPO_BANCO TP_BANCO_FGTS
	ON TP_BANCO_FGTS.CODIGO_BANCO = DOC_FGTS_FUNC.CODIGO_BANCO
	INNER JOIN TBVRT041_PAIS PAIS_PAI
	ON PAIS_PAI.CODIGO_PAIS = FUNC.NACIONALIDADE_PAI
	INNER JOIN TBVRT041_PAIS PAIS_MAE
	ON PAIS_MAE.CODIGO_PAIS = FUNC.NACIONALIDADE_MAE
	INNER JOIN TBVRT041_PAIS PAIS_FUNC
	ON PAIS_FUNC.CODIGO_PAIS = FUNC.LOCAL_NASCIMENTO
	WHERE
	(FUNC.CODIGO_FUNCIONARIO = @CODIGO_FUNCIONARIO OR @CODIGO_FUNCIONARIO IS NULL) AND
	(FUNC.NUMERO_ORDEM_MATRICULA = @NUMERO_ORDEM_MATRICULA_FUNCIONARIO OR @NUMERO_ORDEM_MATRICULA_FUNCIONARIO IS NULL) AND
	(FUNC.NUMERO_MATRICULA = @NUMERO_MATRICULA_FUNCIONARIO OR @NUMERO_MATRICULA_FUNCIONARIO IS NULL) AND
	(FUNC.NOME_FUNCIONARIO LIKE '%'+@NOME_FUNCIONARIO_FUNCIONARIO+'%' OR @NOME_FUNCIONARIO_FUNCIONARIO IS NULL)
	ORDER BY FUNC.CODIGO_FUNCIONARIO ASC
	
	/*
	@CODIGO_FUNCIONARIO
	*/
	IF(@@ERROR <>0)
		BEGIN
			SELECT  @@ERROR as Erro, 'ERRO NO SELECT DA TABELA TBVRT006_FUNCIONARIO.' as Mensagem
			
			DECLARE @DESC VARCHAR(120)

			SET @DESC = 'ERRO NO SELECT DA TABELA TBVRT006_FUNCIONARIO - CODIGO DO ERRO' + CAST(@@ERROR AS VARCHAR)

			EXEC dbo.SPVRT028_LOG_PR_INCLUIR 'E', @DESC , @CODIGO_USUARIO_CADASTRO, 'INCLUS�O DE USU�RIO';
			 
		END
	RETURN

END













GO


