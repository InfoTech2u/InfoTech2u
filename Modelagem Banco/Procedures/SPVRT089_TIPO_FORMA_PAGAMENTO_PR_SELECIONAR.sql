USE [DBVERITHUS]
GO

/****** Object:  StoredProcedure [dbo].[SPVRT041_DEPENDENTE_PR_SELECIONAR]    Script Date: 28/09/2014 19:04:50 ******/
DROP PROCEDURE [dbo].[SPVRT089_TIPO_FORMA_PAGAMENTO_PR_SELECIONAR]


/****** Object:  StoredProcedure [dbo].[SPVRT089_TIPO_FORMA_PAGAMENTO_PR_SELECIONAR]    Script Date: 27/09/2014 21:39:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- TBVRT023_TIPO_FORMA_PAGAMENTO
CREATE PROCEDURE [dbo].[SPVRT089_TIPO_FORMA_PAGAMENTO_PR_SELECIONAR]
(
	@CODIGO_TIPO_FORMA_PAGAMENTO INT = NULL
)

AS
BEGIN
	SELECT * FROM TBVRT023_TIPO_FORMA_PAGAMENTO WHERE 
		(CODIGO_TIPO_FORMA_PAGAMENTO = @CODIGO_TIPO_FORMA_PAGAMENTO OR @CODIGO_TIPO_FORMA_PAGAMENTO IS NULL) 
	IF(@@ERROR <>0)
		BEGIN
			SELECT  @@ERROR as Erro, 'ERRO NO SELECT DA TABELA TBVRT023_TIPO_FORMA_PAGAMENTO.' as Mensagem 
		END
	RETURN
END

