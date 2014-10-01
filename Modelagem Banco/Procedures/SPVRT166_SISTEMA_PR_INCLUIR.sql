USE [DBVERITHUS]
GO

/****** Object:  StoredProcedure [dbo].[SPVRT166_SISTEMA_PR_INCLUIR]    Script Date: 27/09/2014 15:06:08 ******/
DROP PROCEDURE [dbo].[SPVRT166_SISTEMA_PR_INCLUIR]
GO

/****** Object:  StoredProcedure [dbo].[SPVRT166_SISTEMA_PR_INCLUIR]    Script Date: 27/09/2014 15:06:08 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[SPVRT166_SISTEMA_PR_INCLUIR]
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
	
	INSERT INTO TBVRT047_SISTEMA(
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

	DECLARE @DESC VARCHAR(120);

	IF(@@ERROR <>0)
		BEGIN

			SET @DESC = 'ERRO AO INCLUIR UM SISTEMA - CODIGO DO ERRO' + CAST(@@ERROR AS VARCHAR)

			EXEC dbo.SPVRT168_LOG_PR_INCLUIR 'E', @DESC , @CODIGO_USUARIO_CADASTRO, 'INCLUS�O DE SISTEMA';

			SELECT @@ERROR as Erro, @DESC as Mensagem
			RETURN
		END
	ELSE
		BEGIN
			
			SET @DESC = 'SUCESSO AO INCLUIR UM SISTEMA - CODIGO DO SISTEMA' + CAST(@@IDENTITY AS VARCHAR)

			EXEC dbo.SPVRT168_LOG_PR_INCLUIR 'A', '' , @CODIGO_USUARIO_CADASTRO, 'INCLUS�O DE SISTEMA';

			SELECT CODIGO_SISTEMA, DESCRICAO FROM TBVRT047_SISTEMA
			WHERE CODIGO_SISTEMA = @@IDENTITY
			RETURN
		END

END



GO


