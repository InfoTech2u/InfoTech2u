USE [DBVERITHUS]
GO

/****** Object:  StoredProcedure [dbo].[SPVRT041_DEPENDENTE_PR_SELECIONAR]    Script Date: 28/09/2014 19:04:50 ******/
DROP PROCEDURE [dbo].[SPVRT041_DEPENDENTE_PR_SELECIONAR]
GO

/****** Object:  StoredProcedure [dbo].[SPVRT041_DEPENDENTE_PR_SELECIONAR]    Script Date: 28/09/2014 19:04:50 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




CREATE PROCEDURE [dbo].[SPVRT041_DEPENDENTE_PR_SELECIONAR]
(
	@CODIGO_DEPENDENTE		 INT = NULL,
	@CODIGO_FUNCIONARIO		 INT = NULL
)
AS
BEGIN
	if(@CODIGO_FUNCIONARIO IS NULL)
	BEGIN
		SELECT t0.*, t2.CODIGO_TIPO_BENEFICIO, t1.DESCRICAO AS TIPO_PARENTESCO_DESC, CONVERT(varchar, DATA_NASCIMENTO, 103) AS DATA_NASCIMENTO_STR 
		FROM TBVRT011_DEPENDENTE t0 
		INNER JOIN TBVRT014_TIPO_PARENTESCO t1 ON t1.CODIGO_TIPO_PARENTESCO = t0.CODIGO_TIPO_PARENTESCO
		LEFT JOIN TBVRT045_BENEFICIO t2 ON t2.CODIGO_DEPENDENTE = t0.CODIGO_DEPENDENTE
		WHERE (t0.CODIGO_DEPENDENTE = @CODIGO_DEPENDENTE OR @CODIGO_DEPENDENTE IS NULL) 
	END
	ELSE
	BEGIN
		SELECT t0.*, t1.DESCRICAO AS TIPO_PARENTESCO_DESC, CONVERT(varchar, DATA_NASCIMENTO, 103) AS DATA_NASCIMENTO_STR 
		FROM TBVRT011_DEPENDENTE t0 
		INNER JOIN TBVRT014_TIPO_PARENTESCO t1 ON t1.CODIGO_TIPO_PARENTESCO = t0.CODIGO_TIPO_PARENTESCO		
		WHERE (t0.CODIGO_FUNCIONARIO = @CODIGO_FUNCIONARIO)
	END

	IF(@@ERROR <>0)
			BEGIN
				SELECT  @@ERROR as Erro, 'ERRO NO SELECT DA TABELA TBVRT011_DEPENDENTE.' as Mensagem 
			END
		RETURN
	
END



GO

