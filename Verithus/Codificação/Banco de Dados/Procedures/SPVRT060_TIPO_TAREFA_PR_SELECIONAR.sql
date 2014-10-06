USE [DBVERITHUS]
GO

/****** Object:  StoredProcedure [dbo].[SPVRT017_DEPENDENTE_PR_SELECIONAR]    Script Date: 28/09/2014 19:04:50 ******/
DROP PROCEDURE [dbo].[SPVRT060_TIPO_TAREFA_PR_SELECIONAR]
GO

/****** Object:  StoredProcedure [dbo].[SPVRT060_TIPO_TAREFA_PR_SELECIONAR]    Script Date: 27/09/2014 21:37:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[SPVRT060_TIPO_TAREFA_PR_SELECIONAR]
(
	@CODIGO_USUARIO_CADASTRO	INT = NULL,
	@CODIGO_TIPO_TAREFA	 INT = NULL
)
AS
BEGIN
	SELECT * FROM TBVRT022_TIPO_TAREFA WHERE 
		(CODIGO_TIPO_TAREFA = @CODIGO_TIPO_TAREFA OR @CODIGO_TIPO_TAREFA IS NULL) 
	IF(@@ERROR <>0)
		BEGIN
			SELECT  @@ERROR as Erro, 'ERRO NO SELECT DA TABELA TBVRT022_TIPO_TAREFA.' as Mensagem
			
			DECLARE @DESC VARCHAR(120)

			SET @DESC = 'ERRO NO SELECT DA TABELA TBVRT022_TIPO_TAREFA - CODIGO DO ERRO' + CAST(@@ERROR AS VARCHAR)

			EXEC dbo.SPVRT028_LOG_PR_INCLUIR 'E', @DESC , @CODIGO_USUARIO_CADASTRO, 'INCLUS�O DE USU�RIO';
			 
		END
	RETURN
END

