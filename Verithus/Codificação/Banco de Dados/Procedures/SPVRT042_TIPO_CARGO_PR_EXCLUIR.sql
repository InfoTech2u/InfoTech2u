USE [DBVERITHUS]
GO

/****** Object:  StoredProcedure [dbo].[SPVRT017_DEPENDENTE_PR_SELECIONAR]    Script Date: 28/09/2014 19:04:50 ******/
DROP PROCEDURE [dbo].[SPVRT042_TIPO_CARGO_PR_EXCLUIR]

/****** Object:  StoredProcedure [dbo].[SPVRT042_TIPO_CARGO_PR_EXCLUIR]    Script Date: 27/09/2014 21:30:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SPVRT042_TIPO_CARGO_PR_EXCLUIR]
(
	@CODIGO_TIPO_CARGO     INT = NULL,
	@CODIGO_USUARIO_ALTERACAO INT = NULL
)
AS
BEGIN
	IF(@CODIGO_TIPO_CARGO IS NOT NULL)
		BEGIN
			DECLARE @countAdmissao INT = 0;
			DECLARE @countDemissao INT = 0;
				DECLARE @DESC VARCHAR(120)

			SET @countAdmissao = (SELECT COUNT(0) FROM TBVRT019_DADOS_ADMISSAO WHERE CODIGO_TIPO_CARGO = @CODIGO_TIPO_CARGO);
			SET @countDemissao = (SELECT COUNT(0) FROM TBVRT024_DADOS_DEMISSAO WHERE CODIGO_TIPO_CARGO = @CODIGO_TIPO_CARGO);
			IF(@countAdmissao <= 0 AND @countDemissao <= 0)
				BEGIN
					DELETE FROM TBVRT020_TIPO_CARGO WHERE CODIGO_TIPO_CARGO = @CODIGO_TIPO_CARGO;			

	IF(@@ERROR <>0)
		BEGIN

							SET @DESC = 'ERRO AO EXCLUIR UM TIPO DE CARGO - CODIGO DO ERRO: ' + CAST(@@ERROR AS VARCHAR)

			EXEC dbo.SPVRT028_LOG_PR_INCLUIR 'E', @DESC , @CODIGO_USUARIO_ALTERACAO, 'EXCLUS�O DE TIPO DE CARGO';

			SELECT @@ERROR as Erro, @DESC as Mensagem
			RETURN
		END
	ELSE
		BEGIN
			
							SET @DESC = 'SUCESSO AO EXCLUIR UM TIPO DE CARGO - CODIGO DO TIPO DE CARGO: ' + CAST(@CODIGO_TIPO_CARGO AS VARCHAR)

			EXEC dbo.SPVRT028_LOG_PR_INCLUIR 'A', @DESC , @CODIGO_USUARIO_ALTERACAO, 'EXCLUS�O DE TIPO DE CARGO';
			RETURN
		END
				END
			ELSE
				BEGIN
					SELECT 'RELACIONAMENTO' as Erro, 'RELACIONAMENTO COM DADOS ADMISS�O OU DEMISS�O AINDA EXISTEM' as Mensagem
					RETURN
				END		
		END
	ELSE
		BEGIN
			SELECT 'CODIGO NULO' as Erro, 'C�DIGO NULO - N�O FOI POSS�VEL EXCLUIR' as Mensagem
			RETURN
		END
END