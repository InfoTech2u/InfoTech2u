USE [DBVERITHUS]
GO

/****** Object:  StoredProcedure [dbo].[SPVRT111_CONTRIBUICAO_SINDICAL_PR_ALTERAR]    Script Date: 14/09/2014 09:31:06 ******/
DROP PROCEDURE [dbo].[SPVRT109_CONTRIBUICAO_SINDICAL_PR_SELECIONAR]
GO

/****** Object:  StoredProcedure [dbo].[SPVRT111_CONTRIBUICAO_SINDICAL_PR_ALTERAR]    Script Date: 14/09/2014 09:31:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- TBVRT028_CONTRIBUICAO_SINDICAL
CREATE PROCEDURE [dbo].[SPVRT109_CONTRIBUICAO_SINDICAL_PR_SELECIONAR]
(
	@CODIGO_CONTRIBUICAO_SINDICAL		 INT = NULL@,
	@CODIGO_FUNCIONARIO	INT = NULL
)
AS
BEGIN
	IF(@CODIGO_FUNCIONARIO IS NOT NULL)
		BEGIN
			SELECT T0.CODIGO_CONTRIBUICAO_SINDICAL, T0.CODIGO_SINDICATO, T0.VALOR_RECOLHIDO, CONVERT(NVARCHAR, T0.PERIODO_ANO, 103) AS PERIODO_ANO_STR FROM TBVRT028_CONTRIBUICAO_SINDICAL T0
			INNER JOIN TBVRT029_SINDICATO T1 ON T0.CODIGO_SINDICATO = T1.CODIGO_SINDICATO
			WHERE T0.CODIGO_FUNCIONARIO = @CODIGO_FUNCIONARIO;
		END
	ELSE
		BEGIN
			SELECT * FROM TBVRT028_CONTRIBUICAO_SINDICAL WHERE 
			(CODIGO_CONTRIBUICAO_SINDICAL = @CODIGO_CONTRIBUICAO_SINDICAL OR @CODIGO_CONTRIBUICAO_SINDICAL IS NULL) 
		END
	
	IF(@@ERROR <> 0)
		BEGIN
			SELECT @@ERROR AS Erro, 'ERRO AO SELECIONAR NA TABELA TBVRT028_CONTRIBUICAO_SINDICAL' AS Mensagem;
		END

END