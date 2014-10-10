USE [DBVERITHUS]
GO

/****** Object:  StoredProcedure [dbo].[SPVRT039_TIPO_BENEFICIO_PR_INCLUIR]    Script Date: 16/09/2014 21:53:01 ******/
DROP PROCEDURE [dbo].[SPVRT039_TIPO_BENEFICIO_PR_INCLUIR]
GO

/****** Object:  StoredProcedure [dbo].[SPVRT039_TIPO_BENEFICIO_PR_INCLUIR]    Script Date: 16/09/2014 21:53:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SPVRT039_TIPO_BENEFICIO_PR_INCLUIR]
(
	@DESCRICAO            nvarchar(80)   =      null,
    @CODIGO_USUARIO_CADASTRO int         =      null,
    @DATA_CADASTRO        datetime       =      null,
    @CODIGO_USUARIO_ALTERACAO int      =      null,
    @DATA_ALTERACAO     datetime       =      null,
    @CODIGO_STATUS        int            =      null
)
AS
BEGIN

	INSERT INTO TBVRT012_TIPO_BENEFICIO(
		DESCRICAO,
		CODIGO_USUARIO_CADASTRO,
		DATA_CADASTRO,
		CODIGO_USUARIO_ALTERACAO,
		DATA_ALTERACAO,
		CODIGO_STATUS
	)
	VALUES(
		@DESCRICAO,
		@CODIGO_USUARIO_CADASTRO,
		@DATA_CADASTRO,
		@CODIGO_USUARIO_ALTERACAO,
		@DATA_ALTERACAO,
		@CODIGO_STATUS
	)

	DECLARE @DESC VARCHAR(120);
	DECLARE @ID INT;
	SET @ID = @@IDENTITY;

	IF(@@ERROR <>0)
		BEGIN

			SET @DESC = 'ERRO AO INCLUIR UM TIPO DE BENEF�CIO - CODIGO DO ERRO: ' + CAST(@@ERROR AS VARCHAR)

			EXEC dbo.SPVRT028_LOG_PR_INCLUIR 'E', @DESC , @CODIGO_USUARIO_CADASTRO, 'INCLUS�O DE TIPO DE BENEF�CIO';

			SELECT @@ERROR as Erro, @DESC as Mensagem
			RETURN
		END
	ELSE
		BEGIN
			
			SET @DESC = 'SUCESSO AO INCLUIR UM TIPO DE BENEF�CIO - CODIGO DO TIPO DE  BENEF�CIO: ' + CAST(@ID AS VARCHAR)

			EXEC dbo.SPVRT028_LOG_PR_INCLUIR 'A', @DESC , @CODIGO_USUARIO_CADASTRO, 'INCLUS�O DE TIPO DE BENEF�CIO';

			SELECT * FROM  TBVRT012_TIPO_BENEFICIO
			WHERE CODIGO_TIPO_BENEFICIO = @ID
			RETURN
		END


END



GO


