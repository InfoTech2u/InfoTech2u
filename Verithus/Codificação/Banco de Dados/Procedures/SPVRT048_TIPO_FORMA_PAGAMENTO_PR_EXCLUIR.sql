USE [DBVERITHUS]
GO

/****** Object:  StoredProcedure [dbo].[SPVRT017_DEPENDENTE_PR_SELECIONAR]    Script Date: 28/09/2014 19:04:50 ******/
DROP PROCEDURE [dbo].[SPVRT048_TIPO_FORMA_PAGAMENTO_PR_EXCLUIR]

/****** Object:  StoredProcedure [dbo].[SPVRT048_TIPO_FORMA_PAGAMENTO_PR_EXCLUIR]    Script Date: 27/09/2014 21:39:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- TBVRT023_TIPO_FORMA_PAGAMENTO
CREATE PROCEDURE [dbo].[SPVRT048_TIPO_FORMA_PAGAMENTO_PR_EXCLUIR]
(
	@CODIGO_TIPO_FORMA_PAGAMENTO INT = NULL,
	@CODIGO_USUARIO_ALTERACAO INT = NULL
)
AS
BEGIN
	IF(@CODIGO_TIPO_FORMA_PAGAMENTO IS NOT NULL)
		BEGIN
			DECLARE @countAdmissao INT = 0;
			DECLARE @countDemissao INT = 0;
			DECLARE @DESC VARCHAR(120);

			SET @countAdmissao = (SELECT COUNT(0) FROM TBVRT019_DADOS_ADMISSAO WHERE CODIGO_TIPO_FORMA_PAGAMENTO = @CODIGO_TIPO_FORMA_PAGAMENTO);
			SET @countDemissao = (SELECT COUNT(0) FROM TBVRT024_DADOS_DEMISSAO WHERE CODIGO_TIPO_FORMA_PAGAMENTO = @CODIGO_TIPO_FORMA_PAGAMENTO);
			IF(@countAdmissao <= 0 AND @countDemissao <= 0)
				BEGIN
					DELETE FROM TBVRT023_TIPO_FORMA_PAGAMENTO WHERE CODIGO_TIPO_FORMA_PAGAMENTO = @CODIGO_TIPO_FORMA_PAGAMENTO

					IF(@@ERROR <>0)
						BEGIN

							SET @DESC = 'ERRO AO EXCLUIR UM TIPO DE FORMA DE PAGAMENTO - CODIGO DO ERRO' + CAST(@@ERROR AS VARCHAR)

							EXEC dbo.SPVRT028_LOG_PR_INCLUIR 'E', @DESC , @CODIGO_USUARIO_ALTERACAO, 'EXCLUS�O DE TIPO DE FORMA DE PAGAMENTO';

							SELECT @@ERROR as Erro, @DESC as Mensagem
							RETURN
						END
					ELSE
						BEGIN
			
							SET @DESC = 'SUCESSO AO EXCLUIR UM TIPO DE FORMA DE PAGAMENTO - CODIGO DO TIPO DE FORMA DE PAGAMENTO' + CAST(@CODIGO_TIPO_FORMA_PAGAMENTO AS VARCHAR)

							EXEC dbo.SPVRT028_LOG_PR_INCLUIR 'A', @DESC , @CODIGO_USUARIO_ALTERACAO, 'EXCLUS�O DE TIPO DE FORMA DE PAGAMENTO';
							RETURN
						END
				END
			ELSE
				BEGIN
					SELECT 'RELACIONAMENTO' as Erro, 'RELACIONAMENTO COM DADOS ADMISS�O OU DEMISS�O AINDA EXISTEM' as Mensagem;
					RETURN;
				END
		END
	ELSE
		BEGIN
			SELECT 'CODIGO NULO' as Erro, 'C�DIGO NULO - N�O FOI POSS�VEL EXCLUIR' as Mensagem;
			RETURN;
		END
END