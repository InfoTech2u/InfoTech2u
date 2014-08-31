USE [DBVERITHUS]
GO

/****** Object:  StoredProcedure [dbo].[SPVRT149_TIPO_CONTATO_PR_SELECIONAR]    Script Date: 28/08/2014 18:13:41 ******/
DROP PROCEDURE [dbo].[SPVRT149_TIPO_CONTATO_PR_SELECIONAR]
GO

/****** Object:  StoredProcedure [dbo].[SPVRT149_TIPO_CONTATO_PR_SELECIONAR]    Script Date: 28/08/2014 18:13:41 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


--TBVRT038_TIPO_CONTATO
CREATE PROCEDURE [dbo].[SPVRT149_TIPO_CONTATO_PR_SELECIONAR]
(
	@CODIGO_TIPO_CONTATO		 INT = NULL
)
AS
BEGIN
	SELECT * FROM TBVRT038_TIPO_CONTATO WHERE 
		(CODIGO_TIPO_CONTATO = @CODIGO_TIPO_CONTATO OR @CODIGO_TIPO_CONTATO IS NULL) 
	IF(@@ERROR <>0)
		BEGIN
			SELECT  @@ERROR as Erro, 'ERRO NO SELECT DA TABELA TBVRT038_TIPO_CONTATO.' as Mensagem 
		END
	RETURN
END

GO

