-- TBVRT023_TIPO_FORMA_PAGAMENTO
CREATE PROCEDURE SPVRT089_TIPO_FORMA_PAGAMENTO_PR_SELECIONAR
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

