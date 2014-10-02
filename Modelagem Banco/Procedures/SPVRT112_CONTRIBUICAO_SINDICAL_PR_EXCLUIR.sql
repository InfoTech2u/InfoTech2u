USE [DBVERITHUS]
GO

/****** Object:  StoredProcedure [dbo].[SPVRT112_CONTRIBUICAO_SINDICAL_PR_EXCLUIR]    Script Date: 14/09/2014 10:13:33 ******/
DROP PROCEDURE [dbo].[SPVRT112_CONTRIBUICAO_SINDICAL_PR_EXCLUIR]
GO

/****** Object:  StoredProcedure [dbo].[SPVRT112_CONTRIBUICAO_SINDICAL_PR_EXCLUIR]    Script Date: 14/09/2014 10:13:33 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- TBVRT028_CONTRIBUICAO_SINDICAL
CREATE PROCEDURE [dbo].[SPVRT112_CONTRIBUICAO_SINDICAL_PR_EXCLUIR]
(
	@CODIGO_CONTRIBUICAO_SINDICAL		 INT = NULL,
	@CODIGO_USUARIO_ALTERACAO INT = NULL
)
AS
BEGIN
	
	DELETE FROM TBVRT028_CONTRIBUICAO_SINDICAL WHERE CODIGO_CONTRIBUICAO_SINDICAL = @CODIGO_CONTRIBUICAO_SINDICAL

	DECLARE @DESC VARCHAR(120)

	IF(@@ERROR <>0)
		BEGIN

			SET @DESC = 'ERRO AO EXCLUIR UMA CONTRIBUI��O SINDICAL - CODIGO DO ERRO' + CAST(@@ERROR AS VARCHAR)

			EXEC dbo.SPVRT168_LOG_PR_INCLUIR 'E', @DESC , @CODIGO_USUARIO_ALTERACAO, 'EXCLUS�O DE CONTRIBUI��O SINDICAL';

			SELECT @@ERROR as Erro, @DESC as Mensagem
			RETURN
		END
	ELSE
		BEGIN
			
			SET @DESC = 'SUCESSO AO EXCLUIR UMA CONTRIBUI��O SINDICAL - CODIGO DA CONTRIBUI��O SINDICAL' + CAST(@CODIGO_CONTRIBUICAO_SINDICAL AS VARCHAR)

			EXEC dbo.SPVRT168_LOG_PR_INCLUIR 'A', '' , @CODIGO_USUARIO_ALTERACAO, 'EXCLUS�O DE CONTRIBUI��O SINDICAL';
			RETURN
		END

END

GO

