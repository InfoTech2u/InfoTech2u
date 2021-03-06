USE [DBVERITHUS]
GO

/****** Object:  StoredProcedure [dbo].[SPVRT041_DEPENDENTE_PR_SELECIONAR]    Script Date: 28/09/2014 19:04:50 ******/
DROP PROCEDURE [dbo].[SPVRT090_TIPO_FORMA_PAGAMENTO_PR_INCLUIR]

/****** Object:  StoredProcedure [dbo].[SPVRT090_TIPO_FORMA_PAGAMENTO_PR_INCLUIR]    Script Date: 27/09/2014 21:39:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- TBVRT023_TIPO_FORMA_PAGAMENTO
CREATE PROCEDURE [dbo].[SPVRT090_TIPO_FORMA_PAGAMENTO_PR_INCLUIR]
(
	@DESCRICAO					nvarchar(80)	=	null,
	@CODIGO_USUARIO_CADASTRO	int				=	null,
	@DATA_CADASTRO				datetime        =   null,
	@CODIGO_USUARIO_ALTERACAO	int             =   null,
	@DATA_ALTERACAO				datetime        =   null,
	@CODIGO_STATUS				int             =   null
)
AS
BEGIN

	INSERT INTO TBVRT023_TIPO_FORMA_PAGAMENTO(
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

			SET @DESC = 'ERRO AO INCLUIR UM TIPO DE FORMA DE PAGAMENTO - CODIGO DO ERRO' + CAST(@@ERROR AS VARCHAR)

			EXEC dbo.SPVRT168_LOG_PR_INCLUIR 'E', @DESC , @CODIGO_USUARIO_CADASTRO, 'INCLUS�O DE TIPO DE FORMA DE PAGAMENTO';

			SELECT @@ERROR as Erro, @DESC as Mensagem
			RETURN
		END
	ELSE
		BEGIN
			
			SET @DESC = 'SUCESSO AO INCLUIR UM TIPO DE FORMA DE PAGAMENTO - CODIGO DO TIPO DE FORMA DE PAGAMENTO' + CAST(@ID AS VARCHAR)

			EXEC dbo.SPVRT168_LOG_PR_INCLUIR 'A', @DESC , @CODIGO_USUARIO_CADASTRO, 'INCLUS�O DE TIPO DE FORMA DE PAGAMENTO';

			SELECT * FROM  TBVRT023_TIPO_FORMA_PAGAMENTO
			WHERE CODIGO_TIPO_FORMA_PAGAMENTO = @ID
			RETURN
		END



END