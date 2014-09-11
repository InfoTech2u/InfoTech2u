USE [DBVERITHUS]
GO

/****** Object:  StoredProcedure [dbo].[SPVRT048_TIPO_BENEFICIO_PR_EXCLUIR]    Script Date: 11/09/2014 00:40:54 ******/
DROP PROCEDURE [dbo].[SPVRT116_SINDICATO_PR_EXCLUIR]
GO

/****** Object:  StoredProcedure [dbo].[SPVRT116_SINDICATO_PR_EXCLUIR]    Script Date: 11/09/2014 00:40:54 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[SPVRT116_SINDICATO_PR_EXCLUIR]
(
	@CODIGO_SINDICATO		 INT = NULL
)
AS
BEGIN
	IF(@CODIGO_SINDICATO IS NOT NULL)
		BEGIN
			DELETE FROM TBVRT029_SINDICATO WHERE CODIGO_SINDICATO = @CODIGO_SINDICATO

			IF(@@ERROR <>0)
			BEGIN				
				SELECT 'ERRO NO DELETE DA TABELA TBVRT029_SINDICATO.' as Mensagem
			END			
		END
END


GO

