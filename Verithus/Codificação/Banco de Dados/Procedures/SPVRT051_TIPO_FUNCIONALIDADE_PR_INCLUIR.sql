USE [DBVERITHUS]
GO

/****** Object:  StoredProcedure [dbo].[SPVRT051_TIPO_FUNCIONALIDADE_PR_INCLUIR]    Script Date: 27/09/2014 15:17:24 ******/
DROP PROCEDURE [dbo].[SPVRT051_TIPO_FUNCIONALIDADE_PR_INCLUIR]
GO

/****** Object:  StoredProcedure [dbo].[SPVRT051_TIPO_FUNCIONALIDADE_PR_INCLUIR]    Script Date: 27/09/2014 15:17:24 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO





CREATE PROCEDURE [dbo].[SPVRT051_TIPO_FUNCIONALIDADE_PR_INCLUIR]
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
		
		DECLARE @DESC VARCHAR(120)
		DECLARE @ID INT;
		SET @ID = @@IDENTITY
	IF(@@ERROR <>0)
		BEGIN

			SET @DESC = 'ERRO AO INCLUIR UM TIPO DE FUNCIONALIDADE - CODIGO DO ERRO' + CAST(@@ERROR AS VARCHAR)

			EXEC dbo.SPVRT028_LOG_PR_INCLUIR 'E', @DESC , @CODIGO_USUARIO_CADASTRO, 'INCLUS�O DE TIPO DE FUNCIONALIDADE';

			SELECT @@ERROR as Erro, @DESC as Mensagem
			RETURN
		END
	ELSE
		BEGIN
			
			SET @DESC = 'SUCESSO AO INCLUIR UM TIPO DE FUNCIONALIDADE - CODIGO DO TIPO DE FUNCIONALIDADE' + CAST(@ID AS VARCHAR)

			EXEC dbo.SPVRT028_LOG_PR_INCLUIR 'A', @DESC , @CODIGO_USUARIO_CADASTRO, 'INCLUS�O DE TIPO DE FUNCIONALIDADE';

			SELECT CODIGO_TIPO_FUNCIONALIDADE, DESCRICAO FROM TBVRT046_TIPO_FUNCIONALIDADE_SISTEMA
			WHERE CODIGO_TIPO_FUNCIONALIDADE = @ID
			RETURN
		END



END




GO


