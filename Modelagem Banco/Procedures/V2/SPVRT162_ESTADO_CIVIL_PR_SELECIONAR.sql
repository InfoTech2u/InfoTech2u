USE [DBVERITHUS]
GO

/****** Object:  StoredProcedure [dbo].[SPVRT162_ESTADO_CIVIL_PR_SELECIONAR]    Script Date: 28/08/2014 18:14:02 ******/
DROP PROCEDURE [dbo].[SPVRT162_ESTADO_CIVIL_PR_SELECIONAR]
GO

/****** Object:  StoredProcedure [dbo].[SPVRT162_ESTADO_CIVIL_PR_SELECIONAR]    Script Date: 28/08/2014 18:14:02 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




CREATE PROCEDURE [dbo].[SPVRT162_ESTADO_CIVIL_PR_SELECIONAR]
(
	@CODIGO_ESTADO_CIVIL		 INT = NULL,
	@DESCRICAO			 NVARCHAR(100) = NULL
)
AS
BEGIN
			
			SELECT 
				CODIGO_ESTADO_CIVIL,
				DESCRICAO,
				CODIGO_USUARIO_CADASTRO,
				DATA_CADASTRO,
				CODIGO_USUARIO_ALTERACAO,
				DATA_ALTERACAO,
				CODIGO_STATUS
			FROM TBVRT040_ESTADO_CIVIL
			WHERE 
				(CODIGO_ESTADO_CIVIL = @CODIGO_ESTADO_CIVIL OR @CODIGO_ESTADO_CIVIL IS NULL) AND
				(DESCRICAO = @DESCRICAO OR @DESCRICAO IS NULL)
			

			IF(@@ERROR <>0)
				BEGIN
					SELECT  @@ERROR as Erro, 'ERRO NO SELECT DA TABELA TBVRT001_USUARIOS.' as Mensagem 
				END
			RETURN
		
END



GO


