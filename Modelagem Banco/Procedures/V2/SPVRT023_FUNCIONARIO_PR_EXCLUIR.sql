USE [DBVERITHUS]
GO

/****** Object:  StoredProcedure [dbo].[SPVRT023_FUNCIONARIO_PR_EXCLUIR]    Script Date: 16/09/2014 21:08:15 ******/
DROP PROCEDURE [dbo].[SPVRT023_FUNCIONARIO_PR_EXCLUIR]
GO

/****** Object:  StoredProcedure [dbo].[SPVRT023_FUNCIONARIO_PR_EXCLUIR]    Script Date: 16/09/2014 21:08:15 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[SPVRT023_FUNCIONARIO_PR_EXCLUIR]
(
	@CODIGO_FUNCIONARIO		 INT = NULL
)
AS
BEGIN
	IF(@CODIGO_FUNCIONARIO IS NOT NULL)
		BEGIN
			DELETE FROM TBVRT006_FUNCIONARIO WHERE CODIGO_FUNCIONARIO = @CODIGO_FUNCIONARIO

			IF(@@ERROR <>0)
			BEGIN				
				SELECT 'ERRO NO DELETE DA TABELA TBVRT001_USUARIOS.' as Mensagem
			END			
		END
END


GO

