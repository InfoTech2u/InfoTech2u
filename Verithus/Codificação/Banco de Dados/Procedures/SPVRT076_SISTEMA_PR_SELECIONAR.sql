USE [DBVERITHUS]
GO

/****** Object:  StoredProcedure [dbo].[SPVRT076_SISTEMA_PR_SELECIONAR]    Script Date: 16/09/2014 21:57:23 ******/
DROP PROCEDURE [dbo].[SPVRT076_SISTEMA_PR_SELECIONAR]
GO

/****** Object:  StoredProcedure [dbo].[SPVRT076_SISTEMA_PR_SELECIONAR]    Script Date: 16/09/2014 21:57:23 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




CREATE PROCEDURE [dbo].[SPVRT076_SISTEMA_PR_SELECIONAR]
(
	@CODIGO_USUARIO_CADASTRO	INT = NULL,
	@CODIGO_SISTEMA		 INT = NULL
)
AS
BEGIN
	SELECT * FROM TBVRT047_SISTEMA WHERE 
		(CODIGO_SISTEMA = @CODIGO_SISTEMA OR @CODIGO_SISTEMA IS NULL) 
	IF(@@ERROR <>0)
		BEGIN
			SELECT  @@ERROR as Erro, 'ERRO NO SELECT DA TABELA TBVRT047_SISTEMA.' as Mensagem 

			DECLARE @DESC VARCHAR(120)

			SET @DESC = 'ERRO NO SELECT DA TABELA TBVRT047_SISTEMA - CODIGO DO ERRO: ' + CAST(@@ERROR AS VARCHAR)

			EXEC dbo.SPVRT028_LOG_PR_INCLUIR 'E', @DESC , @CODIGO_USUARIO_CADASTRO, 'INCLUS�O DE SISTEMA';

		END
	RETURN	
END



GO


