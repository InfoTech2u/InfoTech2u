USE [DBVERITHUS]
GO

/****** Object:  StoredProcedure [dbo].[SPVRT064_STATUS_PR_SELECIONAR]    Script Date: 24/09/2014 06:18:24 ******/
DROP PROCEDURE [dbo].SPVRT064_STATUS_PR_SELECIONAR
GO

/****** Object:  StoredProcedure [dbo].[SPVRT064_STATUS_PR_SELECIONAR]    Script Date: 24/09/2014 06:18:24 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[SPVRT064_STATUS_PR_SELECIONAR]
(
	@CODIGO_USUARIO_CADASTRO	INT = NULL,
	@CODIGO_STATUS	 INT = NULL
)
AS
BEGIN
	SELECT * FROM TBVRT003_STATUS WHERE 
		(CODIGO_STATUS = @CODIGO_STATUS OR @CODIGO_STATUS IS NULL) 
	IF(@@ERROR <>0)
		BEGIN
			SELECT  @@ERROR as Erro, 'ERRO NO SELECT DA TABELA TBVRT003_STATUS.' as Mensagem
			
			DECLARE @DESC VARCHAR(120)

			SET @DESC = 'ERRO NO SELECT DA TABELA TBVRT003_STATUS - CODIGO DO ERRO' + CAST(@@ERROR AS VARCHAR)

			EXEC dbo.SPVRT168_LOG_PR_INCLUIR 'E', @DESC , @CODIGO_USUARIO_CADASTRO, 'INCLUS�O DE USU�RIO';
			 
		END
	RETURN
END


GO


