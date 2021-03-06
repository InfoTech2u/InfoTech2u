USE [DBVERITHUS]
GO

/****** Object:  StoredProcedure [dbo].[SPVRT064_USUARIOS_PR_SELECIONAR]    Script Date: 27/09/2014 06:42:56 ******/
DROP PROCEDURE [dbo].[SPVRT064_USUARIOS_PR_SELECIONAR]
GO

/****** Object:  StoredProcedure [dbo].[SPVRT064_USUARIOS_PR_SELECIONAR]    Script Date: 27/09/2014 06:42:56 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[SPVRT064_USUARIOS_PR_SELECIONAR]
(
	@CODIGO_USUARIO		 INT = NULL,
	@CODIGO_USUARIO_CADASTRO	INT = NULL,
	@LOGIN_USUARIO		 NVARCHAR(80) = NULL
)
AS
BEGIN
	if(@LOGIN_USUARIO IS NOT NULL)
	BEGIN
		SELECT LOGIN_USUARIO FROM TBVRT001_USUARIOS WHERE 
			(LOGIN_USUARIO = @LOGIN_USUARIO) 
	END
	ELSE
	BEGIN
			
			SELECT *, t1.DESCRICAO as STATUS_DESCRICAO FROM TBVRT001_USUARIOS t0 
			INNER JOIN TBVRT003_STATUS t1 ON t1.CODIGO_STATUS = t0.CODIGO_STATUS
			WHERE
			(CODIGO_USUARIO = @CODIGO_USUARIO OR @CODIGO_USUARIO IS NULL) 
	END
			

	IF(@@ERROR <>0)
		BEGIN
			SELECT  @@ERROR as Erro, 'ERRO NO SELECT DA TABELA TBVRT001_USUARIOS.' as Mensagem
			
			DECLARE @DESC VARCHAR(120)

			SET @DESC = 'ERRO NO SELECT DA TABELA TBVRT001_USUARIOS - CODIGO DO ERRO' + CAST(@@ERROR AS VARCHAR)

			EXEC dbo.SPVRT028_LOG_PR_INCLUIR 'E', @DESC , @CODIGO_USUARIO_CADASTRO, 'INCLUS�O DE USU�RIO';
			 
		END
	RETURN
		
END




GO


