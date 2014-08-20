USE [DBVERITHUS]
GO

/****** Object:  StoredProcedure [dbo].[SPVRT161_PAIS_PR_SELECIONAR]    Script Date: 18/08/2014 20:34:01 ******/
DROP PROCEDURE [dbo].[SPVRT161_PAIS_PR_SELECIONAR]
GO

/****** Object:  StoredProcedure [dbo].[SPVRT161_PAIS_PR_SELECIONAR]    Script Date: 18/08/2014 20:34:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[SPVRT161_PAIS_PR_SELECIONAR]
(
	@CODIGO_PAIS		 INT = NULL,
	@DESCRICAO			 INT = NULL
)
AS
BEGIN
			
			SELECT
				CODIGO_PAIS,
				DESCRICAO,
				CODIGO_USUARIO_CADASTRO,
				DATA_CADASTRO,
				CODIGO_USUARIO_ALTERACAO,
				DATA_ALTERACAO
			FROM TBVRT041_PAIS WHERE 
			(CODIGO_PAIS = @CODIGO_PAIS OR @CODIGO_PAIS IS NULL) AND
			(DESCRICAO = @DESCRICAO OR @DESCRICAO IS NULL)
			

			IF(@@ERROR <>0)
				BEGIN
					SELECT  @@ERROR as Erro, 'ERRO NO SELECT DA TABELA TBVRT001_USUARIOS.' as Mensagem 
				END
			RETURN
		
END

GO

