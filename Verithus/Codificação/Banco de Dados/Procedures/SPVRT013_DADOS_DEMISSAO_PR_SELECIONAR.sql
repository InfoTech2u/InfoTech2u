USE [DBVERITHUS]
GO

/****** Object:  StoredProcedure [dbo].[SPVRT013_DADOS_DEMISSAO_PR_SELECIONAR]    Script Date: 20/10/2014 15:51:27 ******/
DROP PROCEDURE [dbo].[SPVRT013_DADOS_DEMISSAO_PR_SELECIONAR]
GO

/****** Object:  StoredProcedure [dbo].[SPVRT013_DADOS_DEMISSAO_PR_SELECIONAR]    Script Date: 20/10/2014 15:51:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




CREATE PROCEDURE [dbo].[SPVRT013_DADOS_DEMISSAO_PR_SELECIONAR]
(
	@CODIGO_USUARIO_CADASTRO int = null,
	@CODIGO_FUNCIONARIO					INT				=	NULL
)
AS
BEGIN

	SELECT
		DD.CODIGO_DEMISSAO,
		DD.CODIGO_FUNCIONARIO,
		DD.DATA_DEMISSAO,				
		CONVERT(NVARCHAR, DD.DATA_DEMISSAO, 103) AS DATA_DEMISSAO_STR,				
		DD.DATA_REGISTRO,
		CONVERT(NVARCHAR, DD.DATA_REGISTRO, 103) AS DATA_REGISTRO_STR,				
		DD.CODIGO_TIPO_CARGO,	
		TG.DESCRICAO AS TIPO_CARGO,		
		DD.CODIGO_TIPO_SECAO,
		TS.DESCRICAO AS TIPO_SECAO,
		DD.SALARIO_INICIAL,
		DD.COMISSAO,
		DD.CODIGO_TIPO_TAREFA,
		TT.DESCRICAO AS TIPO_TAREFA,
		DD.CODIGO_TIPO_FORMA_PAGAMENTO,
		TFP.DESCRICAO AS TIPO_FORMA_PAGAMENTO,
		DD.CODIGO_FORMA_PAGAMENTO,
		DD.DATA_CADASTRO,				
		DD.CODIGO_USUARIO_ALTERACAO,	
		DD.DATA_ALTERACAO,				
		DD.CODIGO_STATUS
	FROM 
		TBVRT024_DADOS_DEMISSAO DD
		INNER JOIN TBVRT020_TIPO_CARGO TG ON DD.CODIGO_TIPO_CARGO = TG.CODIGO_TIPO_CARGO
		INNER JOIN TBVRT021_TIPO_SECAO TS ON DD.CODIGO_TIPO_SECAO = TS.CODIGO_TIPO_SECAO
		INNER JOIN TBVRT022_TIPO_TAREFA TT ON DD.CODIGO_TIPO_TAREFA = TT.CODIGO_TIPO_TAREFA
		INNER JOIN TBVRT023_TIPO_FORMA_PAGAMENTO TFP ON DD.CODIGO_TIPO_FORMA_PAGAMENTO = TFP.CODIGO_TIPO_FORMA_PAGAMENTO
	WHERE
		CODIGO_FUNCIONARIO = @CODIGO_FUNCIONARIO

	IF(@@ERROR <>0)
		BEGIN
			SELECT  @@ERROR as Erro, 'ERRO NO SELECT DA TABELA TBVRT024_DADOS_DEMISSAO.' as Mensagem 

			DECLARE @DESC VARCHAR(120)

			SET @DESC = 'ERRO NO SELECT DA TABELA TBVRT024_DADOS_DEMISSAO - CODIGO DO ERRO' + CAST(@@ERROR AS VARCHAR)

			EXEC dbo.SPVRT028_LOG_PR_INCLUIR 'E', @DESC , @CODIGO_USUARIO_CADASTRO, 'INCLUS�O DE USU�RIO';

		END
	RETURN

END







GO


