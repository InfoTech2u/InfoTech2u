USE [DBVERITHUS]
GO

/****** Object:  StoredProcedure [dbo].[SPVRT167_TIPO_FUNCIONALIDADE_PR_INCLUIR]    Script Date: 27/09/2014 15:17:24 ******/
DROP PROCEDURE [dbo].[SPVRT167_TIPO_FUNCIONALIDADE_PR_INCLUIR]
GO

/****** Object:  StoredProcedure [dbo].[SPVRT167_TIPO_FUNCIONALIDADE_PR_INCLUIR]    Script Date: 27/09/2014 15:17:24 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO





CREATE PROCEDURE [dbo].[SPVRT167_TIPO_FUNCIONALIDADE_PR_INCLUIR]
(
    @DESCRICAO				  nvarchar(120)  =      NULL,
    @CODIGO_USUARIO_CADASTRO  int			 =      NULL,
    @DATA_CADASTRO			  datetime       =      NULL,
    @CODIGO_USUARIO_ALTERACAO int			 =      NULL,
    @DATA_ALTERACAO			  datetime       =      NULL,
    @CODIGO_STATUS			  int            =      NULL
)
AS
BEGIN
	
	INSERT INTO TBVRT046_TIPO_FUNCIONALIDADE_SISTEMA(
		DESCRICAO,
		CODIGO_USUARIO_CADASTRO,
		DATA_USUARIO_CADASTRO,
		CODIGO_USUARIO_ALTERACAO,
		DATA_USUARIO_ALTERACAO,
		CODIGO_STATUS
	)
	VALUES(
		@DESCRICAO,
		@CODIGO_USUARIO_CADASTRO,
		GETDATE(),
		NULL,
		NULL,
		@CODIGO_STATUS
	)

	IF(@@ERROR <> 0)
		BEGIN
			SELECT @@ERROR as Erro, 'ERRO NO SELECT DA TABELA TBVRT047_SISTEMA.' as Mensagem
			RETURN
		END
	ELSE
		BEGIN
			SELECT CODIGO_TIPO_FUNCIONALIDADE, DESCRICAO FROM TBVRT046_TIPO_FUNCIONALIDADE_SISTEMA
			WHERE CODIGO_TIPO_FUNCIONALIDADE = @@IDENTITY
			RETURN
		END
END




GO


