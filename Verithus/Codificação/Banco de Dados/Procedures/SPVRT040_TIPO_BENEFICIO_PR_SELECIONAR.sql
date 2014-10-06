USE [DBVERITHUS]
GO

/****** Object:  StoredProcedure [dbo].[SPVRT040_TIPO_BENEFICIO_PR_SELECIONAR]    Script Date: 16/09/2014 21:52:50 ******/
DROP PROCEDURE [dbo].[SPVRT040_TIPO_BENEFICIO_PR_SELECIONAR]
GO

/****** Object:  StoredProcedure [dbo].[SPVRT040_TIPO_BENEFICIO_PR_SELECIONAR]    Script Date: 16/09/2014 21:52:50 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[SPVRT040_TIPO_BENEFICIO_PR_SELECIONAR]
(
	@CODIGO_USUARIO_CADASTRO	INT = NULL,
	@CODIGO_TIPO_BENEFICIO		 INT = NULL
)
AS
BEGIN
	SELECT * FROM TBVRT012_TIPO_BENEFICIO WHERE 
		(CODIGO_TIPO_BENEFICIO = @CODIGO_TIPO_BENEFICIO OR @CODIGO_TIPO_BENEFICIO IS NULL) 
	IF(@@ERROR <>0)
		BEGIN
			SELECT  @@ERROR as Erro, 'ERRO NO SELECT DA TABELA TBVRT012_TIPO_BENEFICIO.' as Mensagem
			
			DECLARE @DESC VARCHAR(120)

			SET @DESC = 'ERRO NO SELECT DA TABELA TBVRT012_TIPO_BENEFICIO - CODIGO DO ERRO' + CAST(@@ERROR AS VARCHAR)

			EXEC dbo.SPVRT028_LOG_PR_INCLUIR 'E', @DESC , @CODIGO_USUARIO_CADASTRO, 'INCLUS�O DE USU�RIO';
			 
		END
	RETURN	
END


GO


