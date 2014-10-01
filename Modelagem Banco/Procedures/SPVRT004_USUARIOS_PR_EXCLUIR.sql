USE [DBVERITHUS]
GO

/****** Object:  StoredProcedure [dbo].[SPVRT004_USUARIOS_PR_EXCLUIR]    Script Date: 21/09/2014 22:55:56 ******/
DROP PROCEDURE [dbo].[SPVRT004_USUARIOS_PR_EXCLUIR]
GO

/****** Object:  StoredProcedure [dbo].[SPVRT004_USUARIOS_PR_EXCLUIR]    Script Date: 21/09/2014 22:55:56 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SPVRT004_USUARIOS_PR_EXCLUIR]
(
	@CODIGO_USUARIO		 INT = NULL,
	@CODIGO_USUARIO_ALTERACAO INT = NULL
)
AS
BEGIN
	IF(@CODIGO_USUARIO IS NOT NULL)
		BEGIN
			DELETE FROM TBVRT001_USUARIOS WHERE CODIGO_USUARIO = @CODIGO_USUARIO

			DECLARE @DESC VARCHAR(120)

	IF(@@ERROR <>0)
		BEGIN

			SET @DESC = 'ERRO AO EXCLUIR UM USUARIO - CODIGO DO ERRO' + CAST(@@ERROR AS VARCHAR);

			EXEC dbo.SPVRT168_LOG_PR_INCLUIR 'E', @DESC , @CODIGO_USUARIO_ALTERACAO, 'EXCLUS�O DE USUARIO';

			SELECT @@ERROR as Erro, @DESC as Mensagem
			RETURN
		END
	ELSE
		BEGIN
			
			SET @DESC = 'SUCESSO AO EXCLUIR UM USUARIO - CODIGO DO USUARIO' + CAST(@CODIGO_USUARIO AS VARCHAR)

			EXEC dbo.SPVRT168_LOG_PR_INCLUIR 'A', '' , @CODIGO_USUARIO_ALTERACAO, 'EXCLUS�O DE USUARIO';
			RETURN
		END
		END
END

GO


