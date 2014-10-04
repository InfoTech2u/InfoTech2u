USE [DBVERITHUS]
GO

/****** Object:  StoredProcedure [dbo].[SPVRT176_EMPRESA_PR_ALTERAR]    Script Date: 04/10/2014 13:29:45 ******/
DROP PROCEDURE [dbo].[SPVRT176_EMPRESA_PR_ALTERAR]
GO

/****** Object:  StoredProcedure [dbo].[SPVRT176_EMPRESA_PR_ALTERAR]    Script Date: 04/10/2014 13:29:45 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO






CREATE PROCEDURE [dbo].[SPVRT176_EMPRESA_PR_ALTERAR]
(
    @CODIGO_EMPRESA				INT = NULL,
@CNJP						NVARCHAR(14) = NULL,
@RAZAO_SOCIAL				NVARCHAR(80) = NULL,
@NOME_FANTASIA				NVARCHAR(80) = NULL,
@INCRICAO_ESTADUAL			NVARCHAR(80) = NULL,
@CODIGO_USUARIO_CADASTRO	INT = NULL,
@DATA_CADASTRO				DATETIME,
@CODIGO_USUARIO_ALTERACAO	INT = NULL,
@DATA_ALTERACAO				DATETIME,
@CODIGO_STATUS				INT = NULL
)
AS
BEGIN

	UPDATE TBVRT030_EMPRESA SET
		CNJP = @CNJP,
		RAZAO_SOCIAL = @RAZAO_SOCIAL,
		NOME_FANTASIA = @NOME_FANTASIA,
		INCRICAO_ESTADUAL = @INCRICAO_ESTADUAL,
		CODIGO_USUARIO_ALTERACAO = @CODIGO_USUARIO_ALTERACAO,
		DATA_ALTERACAO = GETDATE(),
		CODIGO_STATUS = @CODIGO_STATUS
	WHERE
		CODIGO_EMPRESA = @CODIGO_EMPRESA

	DECLARE @DESC VARCHAR(120);
	DECLARE @ID INT;
	SET @ID = @@IDENTITY;

	IF(@@ERROR <>0)
		BEGIN

			SET @DESC = 'ERRO AO ALTERAR DADOS DE EMPRESA - CODIGO DO ERRO' + CAST(@@ERROR AS VARCHAR)

			EXEC dbo.SPVRT168_LOG_PR_INCLUIR 'E', @DESC , @CODIGO_USUARIO_CADASTRO, 'ALTERA��O DE DADOS DE EMPRESA';

			SELECT @@ERROR as Erro, @DESC as Mensagem
			RETURN
		END
	ELSE
		BEGIN
			
			SET @DESC = 'SUCESSO AO ALTERAR DADOS DE ADMISS�O - CODIGO DO EMPRESA' + CAST(@ID AS VARCHAR)

			EXEC dbo.SPVRT168_LOG_PR_INCLUIR 'A', '' , @CODIGO_USUARIO_CADASTRO, 'ALTERA��O DE DADOS DE EMPRESA';

			SELECT
				CODIGO_EMPRESA,
				CNJP,
				RAZAO_SOCIAL,
				NOME_FANTASIA,
				INCRICAO_ESTADUAL,
				CODIGO_USUARIO_CADASTRO,
				DATA_CADASTRO,
				CODIGO_USUARIO_ALTERACAO,
				DATA_ALTERACAO,
				CODIGO_STATUS
			FROM 
				TBVRT030_EMPRESA
			WHERE CODIGO_EMPRESA = @CODIGO_EMPRESA

			RETURN
		END
END






GO


