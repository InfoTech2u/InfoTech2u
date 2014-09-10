-- TBVRT021_TIPO_SECAO
CREATE PROCEDURE SPVRT084_TIPO_SECAO_PR_EXCLUIR
(
	@CODIGO_TIPO_SECAO	 INT = NULL,
	@C_ERR INT			 OUTPUT,
	@T_ERR VARCHAR(255)  OUTPUT 
)
AS
BEGIN
	IF(@CODIGO_TIPO_SECAO IS NOT NULL)
		BEGIN
			DELETE FROM TBVRT021_TIPO_SECAO WHERE CODIGO_TIPO_SECAO = @CODIGO_TIPO_SECAO

			IF(@@ERROR <>0)
				BEGIN
					SELECT @C_ERR = @@ERROR
					SELECT @T_ERR = 'ERRO NO DELETE DA TABELA TBVRT021_TIPO_SECAO.'
				END
			ELSE
				BEGIN
					SELECT @C_ERR = @@ERROR
					SELECT @T_ERR = 'TIPO SECAO EXCLUIDO COM SUCESSO.'
				END
			RETURN
		END
END