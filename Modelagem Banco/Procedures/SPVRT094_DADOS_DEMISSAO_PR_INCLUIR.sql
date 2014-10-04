USE [DBVERITHUS]
GO

/****** Object:  StoredProcedure [dbo].[SPVRT094_DADOS_DEMISSAO_PR_INCLUIR]    Script Date: 04/10/2014 05:41:16 ******/
DROP PROCEDURE [dbo].[SPVRT094_DADOS_DEMISSAO_PR_INCLUIR]
GO

/****** Object:  StoredProcedure [dbo].[SPVRT094_DADOS_DEMISSAO_PR_INCLUIR]    Script Date: 04/10/2014 05:41:16 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- TBVRT024_DADOS_DEMISSAO
CREATE PROCEDURE [dbo].[SPVRT094_DADOS_DEMISSAO_PR_INCLUIR]
(
	@CODIGO_FUNCIONARIO					int        =      null,
	@DATA_DEMISSAO					datetime       =      null,
	@DATA_REGISTRO					datetime       =      null,
	@CODIGO_TIPO_CARGO				int            =      null,
	@CODIGO_TIPO_SECAO				int            =      null,
	@SALARIO_INICIAL				nvarchar(80)   =      null,
	@COMISSAO						nvarchar(80)   =      null,
	@CODIGO_TIPO_TAREFA				int            =      null,
	@CODIGO_TIPO_FORMA_PAGAMENTO	int            =      null,
	@CODIGO_FORMA_PAGAMENTO			int            =      null,
	@CODIGO_USUARIO_CADASTRO		int            =      null,
	@DATA_CADASTRO					datetime       =      null,
	@CODIGO_USUARIO_ALTERACAO		int            =      null,
	@DATA_ALTERACAO					datetime       =      null,
	@CODIGO_STATUS					int            =      null
)
AS
BEGIN

	INSERT INTO TBVRT024_DADOS_DEMISSAO(
		CODIGO_FUNCIONARIO,
		DATA_DEMISSAO,				
		DATA_REGISTRO,				
		CODIGO_TIPO_CARGO,			
		CODIGO_TIPO_SECAO,
		SALARIO_INICIAL,
		COMISSAO,
		CODIGO_TIPO_TAREFA,
		CODIGO_TIPO_FORMA_PAGAMENTO,
		CODIGO_FORMA_PAGAMENTO,
		CODIGO_USUARIO_CADASTRO,
		DATA_CADASTRO,				
		CODIGO_USUARIO_ALTERACAO,	
		DATA_ALTERACAO,				
		CODIGO_STATUS								
	)
	VALUES(
		@CODIGO_FUNCIONARIO,
		@DATA_DEMISSAO,				
		@DATA_REGISTRO,				
		@CODIGO_TIPO_CARGO,			
		@CODIGO_TIPO_SECAO,
		@SALARIO_INICIAL,
		@COMISSAO,
		@CODIGO_TIPO_TAREFA,
		@CODIGO_TIPO_FORMA_PAGAMENTO,
		@CODIGO_FORMA_PAGAMENTO,
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

			SET @DESC = 'ERRO AO INCLUIR UM DADOS DEMISSAO - CODIGO DO ERRO' + CAST(@@ERROR AS VARCHAR)

			EXEC dbo.SPVRT168_LOG_PR_INCLUIR 'E', @DESC , @CODIGO_USUARIO_CADASTRO, 'INCLUS�O DE DADOS DEMISSAO';

			
		END
	ELSE
		BEGIN
			
			SET @DESC = 'SUCESSO AO INCLUIR UM DADOS DEMISSAO - CODIGO DO DADOS DEMISSAO' + CAST(@ID AS VARCHAR)

			EXEC dbo.SPVRT168_LOG_PR_INCLUIR 'A', '' , @CODIGO_USUARIO_CADASTRO, 'INCLUS�O DE DADOS DEMISSAO';

			
		END


END

GO


