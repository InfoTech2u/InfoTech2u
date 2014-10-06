USE [DBVERITHUS]
GO

/****** Object:  StoredProcedure [dbo].[SPVRT009_DADOS_ADMISSAO_PR_INCLUIR]    Script Date: 02/10/2014 16:45:28 ******/
DROP PROCEDURE [dbo].[SPVRT009_DADOS_ADMISSAO_PR_INCLUIR]
GO

/****** Object:  StoredProcedure [dbo].[SPVRT009_DADOS_ADMISSAO_PR_INCLUIR]    Script Date: 02/10/2014 16:45:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




CREATE PROCEDURE [dbo].[SPVRT009_DADOS_ADMISSAO_PR_INCLUIR]
(
    @CODIGO_ADMISSAO					INT				=	NULL,
	@CODIGO_FUNCIONARIO					INT				=	NULL,
	@DATA_ADMISSAO						DATETIME		=	NULL,
	@DATA_REGISTRO						DATETIME		=	NULL,
	@CODIGO_TIPO_CARGO					INT				=	NULL,
	@CODIGO_TIPO_SECAO					INT				=	NULL,
	@SALARIO_INICIAL					NVARCHAR(80)	=	NULL,
	@COMISSAO							NVARCHAR(80)	=	NULL,
	@CODIGO_TIPO_TAREFA					INT				=	NULL,
	@CODIGO_TIPO_FORMA_PAGAMENTO		INT				=	NULL,
	@HORARIO_TRABALHO_INICIO			NVARCHAR(10)	=	NULL,
	@HORARIO_TRABALHO_FIM				NVARCHAR(10)	=	NULL,
	@INTERVALO_ALMOCO_INICIO			NVARCHAR(10)	=	NULL,
	@INTERVALO_ALMOCO_FIM				NVARCHAR(10)	=	NULL,
	@DESCANSO_SEMANAL_INICIO			CHAR(1)			=	NULL,
	@DESCANSO_SEMANAL_FIM				CHAR(1)			=	NULL,
	@CODIGO_USUARIO_CADASTRO			INT				=	NULL,
	@DATA_CADASTRO						DATETIME		=	NULL,
	@CODIGO_USUARIO_ALTERACAO			INT				=	NULL,
	@DATA_ALTERACAO						DATETIME		=	NULL,
	@CODIGO_STATUS						INT				=	NULL
)
AS
BEGIN

	INSERT INTO TBVRT019_DADOS_ADMISSAO(
		CODIGO_FUNCIONARIO,
		DATA_ADMISSAO,
		DATA_REGISTRO,
		CODIGO_TIPO_CARGO,
		CODIGO_TIPO_SECAO,
		SALARIO_INICIAL,
		COMISSAO,
		CODIGO_TIPO_TAREFA,
		CODIGO_TIPO_FORMA_PAGAMENTO,
		HORARIO_TRABALHO_INICIO,
		HORARIO_TRABALHO_FIM,
		INTERVALO_ALMOCO_INICIO,
		INTERVALO_ALMOCO_FIM,
		DESCANSO_SEMANAL_INICIO,
		DESCANSO_SEMANAL_FIM,
		CODIGO_USUARIO_CADASTRO,
		DATA_CADASTRO,
		CODIGO_USUARIO_ALTERACAO,
		DATA_ALTERACAO,
		CODIGO_STATUS
	)
	VALUES(
		@CODIGO_FUNCIONARIO,
		@DATA_ADMISSAO,
		@DATA_REGISTRO,
		@CODIGO_TIPO_CARGO,
		@CODIGO_TIPO_SECAO,
		@SALARIO_INICIAL,
		@COMISSAO,
		@CODIGO_TIPO_TAREFA,
		@CODIGO_TIPO_FORMA_PAGAMENTO,
		@HORARIO_TRABALHO_INICIO,
		@HORARIO_TRABALHO_FIM,
		@INTERVALO_ALMOCO_INICIO,
		@INTERVALO_ALMOCO_FIM,
		@DESCANSO_SEMANAL_INICIO,
		@DESCANSO_SEMANAL_FIM,
		@CODIGO_USUARIO_CADASTRO,
		GETDATE(),
		NULL,
		NULL,
		@CODIGO_STATUS
	)


	DECLARE @DESC VARCHAR(120);
	DECLARE @ID INT;
	SET @ID = @@IDENTITY;

	IF(@@ERROR <>0)
		BEGIN

			SET @DESC = 'ERRO AO INCLUIR DADOS DE ADMISS�O - CODIGO DO ERRO' + CAST(@@ERROR AS VARCHAR)

			EXEC dbo.SPVRT028_LOG_PR_INCLUIR 'E', @DESC , @CODIGO_USUARIO_CADASTRO, 'INCLUS�O DE DADOS DE ADMISS�O';

			SELECT @@ERROR as Erro, @DESC as Mensagem
			RETURN
		END
	ELSE
		BEGIN
			
			SET @DESC = 'SUCESSO AO INCLUIR DADOS DE ADMISS�O - CODIGO DO USU�RIO' + CAST(@ID AS VARCHAR)

			EXEC dbo.SPVRT028_LOG_PR_INCLUIR 'A', @DESC , @CODIGO_USUARIO_CADASTRO, 'INCLUS�O DE DADOS DE ADMISS�O';

			SELECT CODIGO_USUARIO, NOME, MAIL, LOGIN_USUARIO FROM TBVRT001_USUARIOS
			WHERE CODIGO_USUARIO = @ID
			RETURN
		END
END




GO


