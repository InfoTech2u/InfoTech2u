USE [DBVERITHUS]
GO

/****** Object:  StoredProcedure [dbo].[SPVRT046_TIPO_COR_PR_SELECIONAR]    Script Date: 16/09/2014 21:53:51 ******/
DROP PROCEDURE [dbo].[SPVRT046_TIPO_COR_PR_SELECIONAR]
GO

/****** Object:  StoredProcedure [dbo].[SPVRT046_TIPO_COR_PR_SELECIONAR]    Script Date: 16/09/2014 21:53:51 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[SPVRT046_TIPO_COR_PR_SELECIONAR]
(
	@CODIGO_USUARIO_CADASTRO	INT = NULL,
	@CODIGO_TIPO_COR	 INT = NULL
)
AS
BEGIN
	SELECT * FROM TBVRT016_TIPO_COR WHERE 
		(CODIGO_TIPO_COR = @CODIGO_TIPO_COR OR @CODIGO_TIPO_COR IS NULL) 
	IF(@@ERROR <>0)
		BEGIN
			SELECT  @@ERROR as Erro, 'ERRO NO SELECT DA TABELA TBVRT016_TIPO_COR.' as Mensagem
			
			DECLARE @DESC VARCHAR(120)

			SET @DESC = 'ERRO NO SELECT DA TABELA TBVRT016_TIPO_COR - CODIGO DO ERRO' + CAST(@@ERROR AS VARCHAR)

			EXEC dbo.SPVRT028_LOG_PR_INCLUIR 'E', @DESC , @CODIGO_USUARIO_CADASTRO, 'INCLUS�O DE USU�RIO';
			 
		END
	RETURN
END


GO


