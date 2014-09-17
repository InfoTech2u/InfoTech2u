USE [DBVERITHUS]
GO

/****** Object:  StoredProcedure [dbo].[SPVRT045_TIPO_BENEFICIO_PR_SELECIONAR]    Script Date: 16/09/2014 21:52:50 ******/
DROP PROCEDURE [dbo].[SPVRT045_TIPO_BENEFICIO_PR_SELECIONAR]
GO

/****** Object:  StoredProcedure [dbo].[SPVRT045_TIPO_BENEFICIO_PR_SELECIONAR]    Script Date: 16/09/2014 21:52:50 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[SPVRT045_TIPO_BENEFICIO_PR_SELECIONAR]
(
	@CODIGO_TIPO_BENEFICIO		 INT = NULL
)
AS
BEGIN
	SELECT * FROM TBVRT012_TIPO_BENEFICIO WHERE 
		(CODIGO_TIPO_BENEFICIO = @CODIGO_TIPO_BENEFICIO OR @CODIGO_TIPO_BENEFICIO IS NULL) 
	IF(@@ERROR <>0)
		BEGIN
			SELECT  @@ERROR as Erro, 'ERRO NO SELECT DA TABELA TBVRT012_TIPO_BENEFICIO.' as Mensagem 
		END
	RETURN	
END


GO


