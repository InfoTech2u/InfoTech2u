USE [DBVERITHUS]
GO

/****** Object:  StoredProcedure [dbo].[SPVRT021_FUNCIONARIO_PR_SELECIONAR]    Script Date: 14/09/2014 16:15:35 ******/
DROP PROCEDURE [dbo].[SPVRT021_FUNCIONARIO_PR_SELECIONAR]
GO

/****** Object:  StoredProcedure [dbo].[SPVRT021_FUNCIONARIO_PR_SELECIONAR]    Script Date: 14/09/2014 16:15:35 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




CREATE PROCEDURE [dbo].[SPVRT021_FUNCIONARIO_PR_SELECIONAR]
(
	@CODIGO_FUNCIONARIO						INT = NULL,
	@NUMERO_ORDEM_MATRICULA_FUNCIONARIO		INT = NULL,
	@NUMERO_MATRICULA_FUNCIONARIO			INT = NULL,
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
	LEFT JOIN TBVRT042_CIDADE CID_FUNC
	ON DETL_END.CODIGO_CIDADE = CID_FUNC.CODIGO_CIDADE
	LEFT JOIN TBVRT043_ESTADO EST_FUNC
	ON DETL_END.CODIGO_ESTADO = EST_FUNC.CODIGO_ESTADO
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
	(FUNC.CODIGO_FUNCIONARIO = @CODIGO_FUNCIONARIO OR @CODIGO_FUNCIONARIO IS NULL) AND
	(FUNC.NUMERO_ORDEM_MATRICULA = @NUMERO_ORDEM_MATRICULA_FUNCIONARIO OR @NUMERO_ORDEM_MATRICULA_FUNCIONARIO IS NULL) AND
	(FUNC.NUMERO_MATRICULA = @NUMERO_MATRICULA_FUNCIONARIO OR @NUMERO_MATRICULA_FUNCIONARIO IS NULL) AND
	(FUNC.NOME_FUNCIONARIO LIKE '%'+@NOME_FUNCIONARIO_FUNCIONARIO+'%' OR @NOME_FUNCIONARIO_FUNCIONARIO IS NULL)
	
	/*
	@CODIGO_FUNCIONARIO
	*/
	IF(@@ERROR <>0)
		BEGIN
			SELECT  @@ERROR as Erro, 'ERRO NO SELECT DA TABELA TBVRT014_TIPO_PARENTESCO.' as Mensagem 
		END
	RETURN

END



GO


