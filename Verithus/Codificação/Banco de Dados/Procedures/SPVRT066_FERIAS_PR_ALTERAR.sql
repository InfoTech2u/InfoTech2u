USE [DBVERITHUS]
GO

/****** Object:  StoredProcedure [dbo].[SPVRT066_FERIAS_PR_ALTERAR]    Script Date: 24/10/2014 20:24:06 ******/
DROP PROCEDURE [dbo].[SPVRT066_FERIAS_PR_ALTERAR]
GO

/****** Object:  StoredProcedure [dbo].[SPVRT066_FERIAS_PR_ALTERAR]    Script Date: 24/10/2014 20:24:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO





CREATE PROCEDURE [dbo].[SPVRT066_FERIAS_PR_ALTERAR]
(
    @CODIGO_FERIAS				INT = NULL,
	@CODIGO_FUNCIONARIO			INT = NULL,
	@DATA_PERIODO_INICIO		DATETIME = NULL,
	@DATA_PERIODO_FIM			DATETIME = NULL,
	@DATA_GOZADA_INICIO			DATETIME = NULL,
	@DATA_GOZADA_FIM			DATETIME = NULL,
	@CODIGO_USUARIO_CADASTRO	INT = NULL,
	@DATA_CADASTRO				DATETIME = NULL,
	@CODIGO_USUARIO_ALTERACAO	INT = NULL,
	@DATA_ALTERACAO				DATETIME = NULL,
	@CODIGO_STATUS				INT = NULL
)
AS
BEGIN

	UPDATE TBVRT025_FERIAS SET
		DATA_PERIODO_INICIO			=	@DATA_PERIODO_INICIO,
		DATA_PERIODO_FIM			=	@DATA_PERIODO_FIM,
		DATA_GOZADA_INICIO			=	@DATA_GOZADA_INICIO,
		DATA_GOZADA_FIM				=	@DATA_GOZADA_FIM,
		CODIGO_USUARIO_ALTERACAO	=	@CODIGO_USUARIO_ALTERACAO,
		DATA_ALTERACAO				=	GETDATE(),
		CODIGO_STATUS				=	@CODIGO_STATUS
	WHERE
		CODIGO_FERIAS = @CODIGO_FERIAS AND
		CODIGO_FUNCIONARIO = @CODIGO_FUNCIONARIO

	DECLARE @DESC VARCHAR(120);
	DECLARE @ID INT;
	SET @ID = @@IDENTITY;

	IF(@@ERROR <>0)
		BEGIN

			SET @DESC = 'ERRO AO ALTERAR DADOS DE F�RIAS - CODIGO DO ERRO: ' + CAST(@@ERROR AS VARCHAR)

			EXEC dbo.SPVRT028_LOG_PR_INCLUIR 'E', @DESC , @CODIGO_USUARIO_CADASTRO, 'ALTERA��O DE DADOS DE F�RIAS';

			SELECT @@ERROR as Erro, @DESC as Mensagem
			RETURN
		END
	ELSE
		BEGIN
			
			SET @DESC = 'SUCESSO AO ALTERAR DADOS DE F�RIAS - CODIGO DO USU�RIO: ' + CAST(@ID AS VARCHAR)

			EXEC dbo.SPVRT028_LOG_PR_INCLUIR 'A', @DESC , @CODIGO_USUARIO_CADASTRO, 'ALTERA��O DE DADOS DE F�RIAS';

			SELECT 
				CODIGO_FERIAS,
				CODIGO_FUNCIONARIO,
				CONVERT(varchar, DATA_PERIODO_INICIO, 103) AS DATA_PERIODO_INICIO,
				CONVERT(varchar, DATA_PERIODO_FIM, 103) AS DATA_PERIODO_FIM,
				CONVERT(varchar, DATA_GOZADA_INICIO, 103) AS DATA_GOZADA_INICIO,
				CONVERT(varchar, DATA_GOZADA_FIM, 103) AS DATA_GOZADA_FIM,
				CODIGO_USUARIO_CADASTRO,
				DATA_CADASTRO,
				CODIGO_USUARIO_ALTERACAO,
				DATA_ALTERACAO,
				CODIGO_STATUS
			FROM TBVRT025_FERIAS WHERE
				CODIGO_FUNCIONARIO = @CODIGO_FUNCIONARIO
			RETURN
		END
END





GO


