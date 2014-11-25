USE [DBVERITHUS]
GO

/****** Object:  StoredProcedure [dbo].[SPVRT074_ALTERACAO_CARGO_SALARIO_PR_SELECIONAR]    Script Date: 23/11/2014 07:00:38 ******/
DROP PROCEDURE [dbo].[SPVRT074_ALTERACAO_CARGO_SALARIO_PR_SELECIONAR]
GO

/****** Object:  StoredProcedure [dbo].[SPVRT074_ALTERACAO_CARGO_SALARIO_PR_SELECIONAR]    Script Date: 23/11/2014 07:00:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




CREATE PROCEDURE [dbo].[SPVRT074_ALTERACAO_CARGO_SALARIO_PR_SELECIONAR]
(
	@CODIGO_FUNCIONARIO					INT				=	NULL,
	@CODIGO_USUARIO_CADASTRO int = null
)
AS
BEGIN

	SELECT
		ACS.CODIGO_ALTERACAO_CARGO_SALARIO,
		ACS.CODIGO_FUNCIONARIO,
		CONVERT(varchar, ACS.DATA, 103) AS DATA,
		ACS.CODIGO_TIPO_CARGO,
		TC.DESCRICAO AS TIPO_CARGO_DESCRICAO,
		ACS.SALARIO,
		ACS.HORARIO_INICIO,
		ACS.HORARIO_FIM,
		ACS.CODIGO_USUARIO_CADASTRO,
		ACS.DATA_CADASTRO,
		ACS.CODIGO_USUARIO_ALTERACAO,
		ACS.DATA_ALTERACAO,
		ACS.CODIGO_STATUS
	FROM 
		TBVRT027_ALTERACAO_CARGO_SALARIO ACS
		INNER JOIN TBVRT020_TIPO_CARGO TC
		ON TC.CODIGO_TIPO_CARGO = ACS.CODIGO_TIPO_CARGO
	WHERE
		CODIGO_FUNCIONARIO = @CODIGO_FUNCIONARIO

	IF(@@ERROR <>0)
		BEGIN
			SELECT  @@ERROR as Erro, 'ERRO NO SELECT DA TABELA TBVRT027_ALTERACAO_CARGO_SALARIO.' as Mensagem
			
			DECLARE @DESC VARCHAR(120)

			SET @DESC = 'ERRO NO SELECT DA TABELA TBVRT027_ALTERACAO_CARGO_SALARIO - CODIGO DO ERRO: ' + CAST(@@ERROR AS VARCHAR)

			EXEC dbo.SPVRT028_LOG_PR_INCLUIR 'E', @DESC , @CODIGO_USUARIO_CADASTRO, 'CONSULTA ALTERA��O DE CARGO SALARIO';
			 
		END
	RETURN

END







GO


