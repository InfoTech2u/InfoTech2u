USE [DBVERITHUS]
GO

/****** Object:  StoredProcedure [dbo].[SPVRT002_USUARIOS_PR_VERIFICAR]    Script Date: 13/09/2014 08:26:44 ******/
DROP PROCEDURE [dbo].[SPVRT002_USUARIOS_PR_VERIFICAR]
GO

/****** Object:  StoredProcedure [dbo].[SPVRT002_USUARIOS_PR_VERIFICAR]    Script Date: 13/09/2014 08:26:44 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




CREATE PROCEDURE [dbo].[SPVRT002_USUARIOS_PR_VERIFICAR]
(
	@LOGIN_USUARIO		NVARCHAR(80),
	@SENHA				NVARCHAR(80)
)
AS
BEGIN

--@EXISTE = CASE WHEN COUNT(*) > 0 THEN 1 ELSE 0 END			

			SELECT * FROM TBVRT001_USUARIOS WHERE 
			LOGIN_USUARIO = @LOGIN_USUARIO AND
			SENHA = @SENHA AND
			CODIGO_STATUS = 1

			

			IF(@@ERROR <>0)
				BEGIN
					SELECT  @@ERROR as Erro, 'ERRO NO SELECT DA TABELA TBVRT001_USUARIOS.' as Mensagem 
				END
			RETURN
		
END



GO


