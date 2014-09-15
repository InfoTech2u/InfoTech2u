-- TBVRT021_TIPO_SECAO
CREATE PROCEDURE SPVRT081_TIPO_SECAO_PR_SELECIONAR
(
	@CODIGO_TIPO_SECAO INT = NULL
)

AS
BEGIN
	SELECT * FROM TBVRT021_TIPO_SECAO WHERE 
		(CODIGO_TIPO_SECAO = @CODIGO_TIPO_SECAO OR @CODIGO_TIPO_SECAO IS NULL) 
	IF(@@ERROR <>0)
		BEGIN
			SELECT  @@ERROR as Erro, 'ERRO NO SELECT DA TABELA TBVRT021_TIPO_SECAO.' as Mensagem 
		END
	RETURN
END
