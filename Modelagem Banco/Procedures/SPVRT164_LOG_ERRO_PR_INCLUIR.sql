USE [DBVERITHUS]
GO

/****** Object:  StoredProcedure [dbo].[SPVRT164_LOG_ERRO_PR_INCLUIR]    Script Date: 27/09/2014 05:47:58 ******/
DROP PROCEDURE [dbo].[SPVRT164_LOG_ERRO_PR_INCLUIR]
GO

/****** Object:  StoredProcedure [dbo].[SPVRT164_LOG_ERRO_PR_INCLUIR]    Script Date: 27/09/2014 05:47:58 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[SPVRT164_LOG_ERRO_PR_INCLUIR]
(
    @DESCRICAO					XML	=	NULL,
    @CODIGO_USUARIO_EXECUCAO	INT	=	NULL
)
AS
BEGIN

	INSERT INTO TBVRT004_LOG_ERRO(
		DATA,
		DESCRICAO,
		CODIGO_USUARIO_EXECUCAO
	)
	VALUES(
		GETDATE(),
		@DESCRICAO,
		@CODIGO_USUARIO_EXECUCAO
	)

	IF(@@ERROR <> 0)
		BEGIN
			SELECT @@ERROR as Erro, 'ERRO NO SELECT DA TABELA TBVRT001_USUARIOS.' as Mensagem
			RETURN
		END
	ELSE
		BEGIN
			SELECT CODIGO_LOG_ERRO, DATA, DESCRICAO, CODIGO_USUARIO_EXECUCAO FROM TBVRT004_LOG_ERRO
			WHERE CODIGO_LOG_ERRO = @@IDENTITY
			RETURN
		END
END



GO


