USE [DBVERITHUS]
GO

/****** Object:  StoredProcedure [dbo].[SPVRT170_DADOS_ADMISSAO_PR_ALTERAR]    Script Date: 02/10/2014 16:45:28 ******/
DROP PROCEDURE [dbo].[SPVRT170_DADOS_ADMISSAO_PR_ALTERAR]
GO

/****** Object:  StoredProcedure [dbo].[SPVRT170_DADOS_ADMISSAO_PR_ALTERAR]    Script Date: 02/10/2014 16:45:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




CREATE PROCEDURE [dbo].[SPVRT170_DADOS_ADMISSAO_PR_ALTERAR]
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

	UPDATE TBVRT019_DADOS_ADMISSAO SET
		DATA_ADMISSAO = @DATA_ADMISSAO,
		DATA_REGISTRO = @DATA_REGISTRO,
		CODIGO_TIPO_CARGO = @CODIGO_TIPO_CARGO,
		CODIGO_TIPO_SECAO = @CODIGO_TIPO_SECAO,
		SALARIO_INICIAL = @SALARIO_INICIAL,
		COMISSAO = @COMISSAO,
		CODIGO_TIPO_TAREFA = @CODIGO_TIPO_TAREFA,
		CODIGO_TIPO_FORMA_PAGAMENTO = @CODIGO_TIPO_FORMA_PAGAMENTO,
		HORARIO_TRABALHO_INICIO = @HORARIO_TRABALHO_INICIO,
		HORARIO_TRABALHO_FIM = @HORARIO_TRABALHO_FIM,
		INTERVALO_ALMOCO_INICIO = @INTERVALO_ALMOCO_INICIO,
		INTERVALO_ALMOCO_FIM = @INTERVALO_ALMOCO_FIM,
		DESCANSO_SEMANAL_INICIO = @DESCANSO_SEMANAL_INICIO,
		DESCANSO_SEMANAL_FIM = @DESCANSO_SEMANAL_FIM,
		CODIGO_USUARIO_ALTERACAO = @CODIGO_USUARIO_ALTERACAO,
		DATA_ALTERACAO = GETDATE(),
		CODIGO_STATUS = @CODIGO_STATUS
	WHERE
		CODIGO_ADMISSAO = @CODIGO_ADMISSAO AND
		CODIGO_FUNCIONARIO = @CODIGO_FUNCIONARIO

	DECLARE @DESC VARCHAR(120);
	DECLARE @ID INT;
	SET @ID = @@IDENTITY;

	IF(@@ERROR <>0)
		BEGIN

			SET @DESC = 'ERRO AO ALTERAR DADOS DE ADMISS�O - CODIGO DO ERRO' + CAST(@@ERROR AS VARCHAR)

			EXEC dbo.SPVRT168_LOG_PR_INCLUIR 'E', @DESC , @CODIGO_USUARIO_CADASTRO, 'ALTERA��O DE DADOS DE ADMISS�O';

			SELECT @@ERROR as Erro, @DESC as Mensagem
			RETURN
		END
	ELSE
		BEGIN
			
			SET @DESC = 'SUCESSO AO ALTERAR DADOS DE ADMISS�O - CODIGO DO USU�RIO' + CAST(@ID AS VARCHAR)

			EXEC dbo.SPVRT168_LOG_PR_INCLUIR 'A', @DESC , @CODIGO_USUARIO_CADASTRO, 'ALTERA��O DE DADOS DE ADMISS�O';

			SELECT CODIGO_USUARIO, NOME, MAIL, LOGIN_USUARIO FROM TBVRT001_USUARIOS
			WHERE CODIGO_USUARIO = @ID
			RETURN
		END
END




GO


