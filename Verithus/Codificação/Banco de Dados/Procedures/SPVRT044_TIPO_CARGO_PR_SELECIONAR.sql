USE [DBVERITHUS]
GO

/****** Object:  StoredProcedure [dbo].[SPVRT017_DEPENDENTE_PR_SELECIONAR]    Script Date: 28/09/2014 19:04:50 ******/
DROP PROCEDURE [dbo].[SPVRT044_TIPO_CARGO_PR_SELECIONAR]

/****** Object:  StoredProcedure [dbo].[SPVRT044_TIPO_CARGO_PR_SELECIONAR]    Script Date: 27/09/2014 21:30:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[SPVRT044_TIPO_CARGO_PR_SELECIONAR]
(
	@CODIGO_USUARIO_CADASTRO	INT = NULL,
	@CODIGO_TIPO_CARGO	 INT = NULL
)
AS
BEGIN
	SELECT * FROM TBVRT020_TIPO_CARGO WHERE 
		(CODIGO_TIPO_CARGO = @CODIGO_TIPO_CARGO OR @CODIGO_TIPO_CARGO IS NULL) 
	IF(@@ERROR <>0)
		BEGIN
			SELECT  @@ERROR as Erro, 'ERRO NO SELECT DA TABELA TBVRT020_TIPO_CARGO.' as Mensagem
			
			DECLARE @DESC VARCHAR(120)

			SET @DESC = 'ERRO NO SELECT DA TABELA TBVRT020_TIPO_CARGO - CODIGO DO ERRO' + CAST(@@ERROR AS VARCHAR)

			EXEC dbo.SPVRT028_LOG_PR_INCLUIR 'E', @DESC , @CODIGO_USUARIO_CADASTRO, 'INCLUS�O DE USU�RIO';
			 
		END
	RETURN
END

