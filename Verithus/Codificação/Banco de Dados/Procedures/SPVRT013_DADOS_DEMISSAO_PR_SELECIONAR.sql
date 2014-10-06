USE [DBVERITHUS]
GO

/****** Object:  StoredProcedure [dbo].[SPVRT013_DADOS_DEMISSAO_PR_SELECIONAR]    Script Date: 04/10/2014 05:41:05 ******/
DROP PROCEDURE [dbo].[SPVRT013_DADOS_DEMISSAO_PR_SELECIONAR]
GO

/****** Object:  StoredProcedure [dbo].[SPVRT013_DADOS_DEMISSAO_PR_SELECIONAR]    Script Date: 04/10/2014 05:41:05 ******/
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
		CODIGO_DEMISSAO,
		CODIGO_FUNCIONARIO,
		DATA_DEMISSAO,				
		DATA_REGISTRO,				
		CODIGO_TIPO_CARGO,			
		CODIGO_TIPO_SECAO,
		SALARIO_INICIAL,
		COMISSAO,
		CODIGO_TIPO_TAREFA,
		CODIGO_TIPO_FORMA_PAGAMENTO,
		CODIGO_FORMA_PAGAMENTO,
		DATA_CADASTRO,				
		CODIGO_USUARIO_ALTERACAO,	
		DATA_ALTERACAO,				
		CODIGO_STATUS
	FROM 
		TBVRT024_DADOS_DEMISSAO
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


