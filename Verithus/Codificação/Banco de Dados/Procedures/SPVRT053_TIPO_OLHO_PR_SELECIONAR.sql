USE [DBVERITHUS]
GO

/****** Object:  StoredProcedure [dbo].[SPVRT053_TIPO_OLHO_PR_SELECIONAR]    Script Date: 16/09/2014 21:54:37 ******/
DROP PROCEDURE [dbo].[SPVRT053_TIPO_OLHO_PR_SELECIONAR]
GO

/****** Object:  StoredProcedure [dbo].[SPVRT053_TIPO_OLHO_PR_SELECIONAR]    Script Date: 16/09/2014 21:54:37 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[SPVRT053_TIPO_OLHO_PR_SELECIONAR]
(
	@CODIGO_USUARIO_CADASTRO	INT = NULL,
	@CODIGO_TIPO_OLHO	 INT = NULL
)
AS
BEGIN
	SELECT * FROM TBVRT018_TIPO_OLHO WHERE 
		(CODIGO_TIPO_OLHO = @CODIGO_TIPO_OLHO OR @CODIGO_TIPO_OLHO IS NULL) 
	IF(@@ERROR <>0)
		BEGIN
			SELECT  @@ERROR as Erro, 'ERRO NO SELECT DA TABELA TBVRT018_TIPO_OLHO.' as Mensagem 

			DECLARE @DESC VARCHAR(120)

			SET @DESC = 'ERRO NO SELECT DA TABELA TBVRT018_TIPO_OLHO - CODIGO DO ERRO' + CAST(@@ERROR AS VARCHAR)

			EXEC dbo.SPVRT028_LOG_PR_INCLUIR 'E', @DESC , @CODIGO_USUARIO_CADASTRO, 'INCLUS�O DE USU�RIO';

		END
	RETURN
END




GO


