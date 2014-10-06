USE [DBVERITHUS]
GO

/****** Object:  StoredProcedure [dbo].[SPVRT014_DEPENDENTE_PR_ALTERAR]    Script Date: 28/09/2014 15:47:42 ******/
DROP PROCEDURE [dbo].[SPVRT014_DEPENDENTE_PR_ALTERAR]
GO

/****** Object:  StoredProcedure [dbo].[SPVRT014_DEPENDENTE_PR_ALTERAR]    Script Date: 28/09/2014 15:47:42 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SPVRT014_DEPENDENTE_PR_ALTERAR]
(
	@CODIGO_DEPENDENTE			  int      =    null,
    @NOME                 nvarchar(100)    =    null,
    @CODIGO_TIPO_PARENTESCO int            =    null,
    @DATA_NASCIMENTO      datetime         =    null,
    @CODIGO_USUARIO_ALTERACAO int          =    null,
    @DATA_ALTERACAO       datetime         =    null,
    @CODIGO_STATUS        int              =    null
)
AS
BEGIN
	IF(@CODIGO_DEPENDENTE IS NOT NULL)
		BEGIN
			UPDATE TBVRT011_DEPENDENTE SET
				NOME = @NOME,
				CODIGO_TIPO_PARENTESCO = @CODIGO_TIPO_PARENTESCO,
				DATA_NASCIMENTO = @DATA_NASCIMENTO,
				CODIGO_USUARIO_ALTERACAO = @CODIGO_USUARIO_ALTERACAO,
				DATA_ALTERACAO = @DATA_ALTERACAO,
				CODIGO_STATUS = @CODIGO_STATUS
			WHERE
				CODIGO_DEPENDENTE = @CODIGO_DEPENDENTE

			DECLARE @DESC VARCHAR(120)

			IF(@@ERROR <>0)
				BEGIN

					SET @DESC = 'ERRO AO ALTERAR UM DEPENDENTE - CODIGO DO ERRO' + CAST(@@ERROR AS VARCHAR)

					EXEC dbo.SPVRT028_LOG_PR_INCLUIR 'E', @DESC , @CODIGO_USUARIO_ALTERACAO, 'ALTERA��O DE DEPENDENTE';

					SELECT @@ERROR as Erro, @DESC as Mensagem
					RETURN
				END
			ELSE
				BEGIN
			
					SET @DESC = 'SUCESSO AO ALTERAR UM DEPENDENTE - CODIGO DO DEPENDENTE' + CAST(@CODIGO_DEPENDENTE AS VARCHAR)

					EXEC dbo.SPVRT028_LOG_PR_INCLUIR 'A', @DESC , @CODIGO_USUARIO_ALTERACAO, 'ALTERA��O DE DEPENDENTE';

					SELECT t0.*, t1.DESCRICAO AS TIPO_PARENTESCO_DESC, CONVERT(varchar, DATA_NASCIMENTO, 103) AS DATA_NASCIMENTO_STR FROM TBVRT011_DEPENDENTE t0 
					INNER JOIN TBVRT014_TIPO_PARENTESCO t1 ON t1.CODIGO_TIPO_PARENTESCO = t0.CODIGO_TIPO_PARENTESCO
					WHERE CODIGO_DEPENDENTE = @CODIGO_DEPENDENTE
					RETURN
				END
		END
END
GO


