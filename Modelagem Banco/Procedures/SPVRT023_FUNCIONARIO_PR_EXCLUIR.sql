USE [DBVERITHUS]
GO

/****** Object:  StoredProcedure [dbo].[SPVRT023_FUNCIONARIO_PR_EXCLUIR]    Script Date: 23/09/2014 15:08:45 ******/
DROP PROCEDURE [dbo].[SPVRT023_FUNCIONARIO_PR_EXCLUIR]
GO

/****** Object:  StoredProcedure [dbo].[SPVRT023_FUNCIONARIO_PR_EXCLUIR]    Script Date: 23/09/2014 15:08:45 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[SPVRT023_FUNCIONARIO_PR_EXCLUIR]
(
	@CODIGO_FUNCIONARIO		 INT = NULL,
	@CODIGO_USUARIO_ALTERACAO INT = NULL
)
AS
BEGIN
	IF(@CODIGO_FUNCIONARIO IS NOT NULL)
		BEGIN
			
			DELETE FROM TBVRT007_DOCUMENTO WHERE CODIGO_FUNCIONARIO = @CODIGO_FUNCIONARIO
			DELETE FROM TBVRT008_DOCUMENTO_ESTRANGEIRO WHERE CODIGO_FUNCIONARIO = @CODIGO_FUNCIONARIO
			DELETE FROM TBVRT009_DOCUMENTO_PIS WHERE CODIGO_FUNCIONARIO = @CODIGO_FUNCIONARIO
			DELETE FROM TBVRT010_DOCUMENTO_FUNDO_GARANTIA WHERE CODIGO_FUNCIONARIO = @CODIGO_FUNCIONARIO
			DELETE FROM TBVRT011_DEPENDENTE WHERE CODIGO_FUNCIONARIO = @CODIGO_FUNCIONARIO
			DELETE FROM TBVRT015_CARACTERISTICA_FISICA WHERE CODIGO_FUNCIONARIO = @CODIGO_FUNCIONARIO
			DELETE FROM TBVRT019_DADOS_ADMISSAO WHERE CODIGO_FUNCIONARIO = @CODIGO_FUNCIONARIO
			DELETE FROM TBVRT024_DADOS_DEMISSAO WHERE CODIGO_FUNCIONARIO = @CODIGO_FUNCIONARIO
			DELETE FROM TBVRT025_FERIAS WHERE CODIGO_FUNCIONARIO = @CODIGO_FUNCIONARIO
			DELETE FROM TBVRT026_ACIDENTE_TRABALHO WHERE CODIGO_FUNCIONARIO = @CODIGO_FUNCIONARIO
			DELETE FROM TBVRT027_ALTERACAO_CARGO_SALARIO WHERE CODIGO_FUNCIONARIO = @CODIGO_FUNCIONARIO
			DELETE FROM TBVRT028_CONTRIBUICAO_SINDICAL WHERE CODIGO_FUNCIONARIO = @CODIGO_FUNCIONARIO
			DELETE FROM TBVRT006_FUNCIONARIO WHERE CODIGO_FUNCIONARIO = @CODIGO_FUNCIONARIO

			DECLARE @DESC VARCHAR(120)

	IF(@@ERROR <>0)
		BEGIN

			SET @DESC = 'ERRO AO EXCLUIR UM FUNCION�RIO - CODIGO DO ERRO' + CAST(@CODIGO_FUNCIONARIO AS VARCHAR)

			EXEC dbo.SPVRT168_LOG_PR_INCLUIR 'E', @DESC , @CODIGO_USUARIO_ALTERACAO, 'EXCLUS�O DE FUNCION�RIO';

			SELECT @@ERROR as Erro, @DESC as Mensagem
			RETURN
		END
	ELSE
		BEGIN
			
			SET @DESC = 'SUCESSO AO EXCLUIR UM FUNCION�RIO - CODIGO DO FUNCION�RIO' + CAST(@CODIGO_FUNCIONARIO AS VARCHAR)

			EXEC dbo.SPVRT168_LOG_PR_INCLUIR 'A', '' , @CODIGO_USUARIO_ALTERACAO, 'EXCLUS�O DE FUNCION�RIO';
			RETURN
		END

				
		END
END



GO

