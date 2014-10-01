USE [DBVERITHUS]
GO

/****** Object:  StoredProcedure [dbo].[SPVRT003_USUARIOS_PR_ALTERAR]    Script Date: 22/09/2014 02:04:33 ******/
DROP PROCEDURE [dbo].[SPVRT003_USUARIOS_PR_ALTERAR]
GO

/****** Object:  StoredProcedure [dbo].[SPVRT003_USUARIOS_PR_ALTERAR]    Script Date: 22/09/2014 02:04:33 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SPVRT003_USUARIOS_PR_ALTERAR]
(
	@CODIGO_USUARIO			  int            =      NULL, 
	@NOME					  nvarchar(80)   =      NULL,
    @MAIL					  nvarchar(120)  =      NULL,
    @CODIGO_TIPO_ACESSO		  int            =      NULL,
    @CODIGO_USUARIO_ALTERACAO int			 =      NULL,
    @DATA_ALTERACAO			  datetime       =      NULL
)
AS
BEGIN
	IF(@CODIGO_USUARIO IS NOT NULL)
		BEGIN
			UPDATE TBVRT001_USUARIOS SET
				NOME = @NOME,
				MAIL = @MAIL,
				CODIGO_TIPO_ACESSO = @CODIGO_TIPO_ACESSO,
				CODIGO_USUARIO_ALTERACAO = @CODIGO_USUARIO_ALTERACAO,
				DATA_ALTERACAO = @DATA_ALTERACAO
			WHERE
				CODIGO_USUARIO = @CODIGO_USUARIO
			
			DECLARE @DESC VARCHAR(120)

			IF(@@ERROR <>0)
				BEGIN

					SET @DESC = 'ERRO AO ALTERAR UM USU�RIO - CODIGO DO ERRO' + CAST(@@ERROR AS VARCHAR)

					EXEC dbo.SPVRT168_LOG_PR_INCLUIR 'E', @DESC , @CODIGO_USUARIO_ALTERACAO, 'ALTERA��O DE USU�RIO';

					SELECT @@ERROR as Erro, @DESC as Mensagem
					RETURN
				END
			ELSE
				BEGIN
			
					SET @DESC = 'SUCESSO AO ALTERAR UM USU�RIO - CODIGO DO USU�RIO' + CAST(@CODIGO_USUARIO AS VARCHAR)

					EXEC dbo.SPVRT168_LOG_PR_INCLUIR 'A', '' , @CODIGO_USUARIO_ALTERACAO, 'ALTERA��O DE USUSU�RIOUARIO';

					SELECT CODIGO_USUARIO, NOME, MAIL, LOGIN_USUARIO FROM TBVRT001_USUARIOS
					WHERE CODIGO_USUARIO = @CODIGO_USUARIO
					RETURN
				END
		END
END

GO


