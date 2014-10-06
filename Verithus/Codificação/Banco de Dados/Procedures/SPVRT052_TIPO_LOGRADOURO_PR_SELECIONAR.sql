USE [DBVERITHUS]
GO

/****** Object:  StoredProcedure [dbo].[SPVRT052_TIPO_LOGRADOURO_PR_SELECIONAR]    Script Date: 16/09/2014 21:57:58 ******/
DROP PROCEDURE [dbo].[SPVRT052_TIPO_LOGRADOURO_PR_SELECIONAR]
GO

/****** Object:  StoredProcedure [dbo].[SPVRT052_TIPO_LOGRADOURO_PR_SELECIONAR]    Script Date: 16/09/2014 21:57:58 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO






CREATE PROCEDURE [dbo].[SPVRT052_TIPO_LOGRADOURO_PR_SELECIONAR]
(
	@CODIGO_TIPO_LOGRADOURO		 INT = NULL,
	@CODIGO_USUARIO_CADASTRO	INT = NULL,
	@DESCRICAO			 NVARCHAR(100) = NULL
)
AS
BEGIN
			
			SELECT 
				CODIGO_TIPO_LOGRADOURO,
				DESCRICAO,
				CODIGO_USUARIO_CADASTRO,
				DATA_CADASTRO,
				CODIGO_USUARIO_ALTERACAO,
				DATA_ALTERACAO,
				CODIGO_STATUS
			FROM TBVRT034_TIPO_LOGRADOURO
			WHERE 
				(CODIGO_TIPO_LOGRADOURO = @CODIGO_TIPO_LOGRADOURO OR @CODIGO_TIPO_LOGRADOURO IS NULL) AND
				(DESCRICAO = @DESCRICAO OR @DESCRICAO IS NULL)
			

			IF(@@ERROR <>0)
				BEGIN
					SELECT  @@ERROR as Erro, 'ERRO NO SELECT DA TABELA TBVRT034_TIPO_LOGRADOURO.' as Mensagem 

					DECLARE @DESC VARCHAR(120)

					SET @DESC = 'ERRO NO SELECT DA TABELA TBVRT034_TIPO_LOGRADOURO - CODIGO DO ERRO' + CAST(@@ERROR AS VARCHAR)

					EXEC dbo.SPVRT028_LOG_PR_INCLUIR 'E', @DESC , @CODIGO_USUARIO_CADASTRO, 'INCLUS�O DE USU�RIO';

				END
			RETURN
		
END





GO


