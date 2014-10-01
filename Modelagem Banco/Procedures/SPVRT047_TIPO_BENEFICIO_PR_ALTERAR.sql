USE [DBVERITHUS]
GO

/****** Object:  StoredProcedure [dbo].[SPVRT047_TIPO_BENEFICIO_PR_ALTERAR]    Script Date: 16/09/2014 21:53:13 ******/
DROP PROCEDURE [dbo].[SPVRT047_TIPO_BENEFICIO_PR_ALTERAR]
GO

/****** Object:  StoredProcedure [dbo].[SPVRT047_TIPO_BENEFICIO_PR_ALTERAR]    Script Date: 16/09/2014 21:53:13 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SPVRT047_TIPO_BENEFICIO_PR_ALTERAR]
(
	@CODIGO_TIPO_BENEFICIO	int          =      NULL,
	@DESCRICAO            nvarchar(80)   =      null,
    @CODIGO_USUARIO_CADASTRO int         =      null,
    @DATA_CADASTRO        datetime       =      null,
    @CODIGO_USUARIO_ALTERACAO int      =      null,
    @DATA_ALTERACAO     datetime       =      null,
    @CODIGO_STATUS        int            =      null,

	@C_ERR INT			 OUTPUT,
	@T_ERR VARCHAR(255)  OUTPUT 
)
AS
BEGIN
	IF(@CODIGO_TIPO_BENEFICIO IS NOT NULL)
		BEGIN
			UPDATE TBVRT012_TIPO_BENEFICIO SET
				DESCRICAO = @DESCRICAO,
				CODIGO_USUARIO_CADASTRO = @CODIGO_USUARIO_CADASTRO,
				DATA_CADASTRO = @DATA_CADASTRO,
				CODIGO_USUARIO_ALTERACAO = @CODIGO_USUARIO_ALTERACAO,
				DATA_ALTERACAO = @DATA_ALTERACAO,
				CODIGO_STATUS = @CODIGO_STATUS
			WHERE
				CODIGO_TIPO_BENEFICIO = @CODIGO_TIPO_BENEFICIO
			
			
					DECLARE @DESC VARCHAR(120)

	IF(@@ERROR <>0)
		BEGIN

			SET @DESC = 'ERRO AO ALTERAR UM TIPO DE BENEF�CIO - CODIGO DO ERRO' + CAST(@CODIGO_TIPO_BENEFICIO AS VARCHAR)

			EXEC dbo.SPVRT168_LOG_PR_INCLUIR 'E', @DESC , @CODIGO_USUARIO_ALTERACAO, 'ALTERA��O DE TIPO DE BENEF�CIO';

			SELECT @@ERROR as Erro, @DESC as Mensagem
			RETURN
		END
	ELSE
		BEGIN
			
			SET @DESC = 'SUCESSO AO ALTERAR UM TIPO DE BENEF�CIO - CODIGO DO TIPO DE BENEF�CIO' + CAST(@CODIGO_TIPO_BENEFICIO AS VARCHAR)

			EXEC dbo.SPVRT168_LOG_PR_INCLUIR 'A', '' , @CODIGO_USUARIO_ALTERACAO, 'ALTERA��O DE TIPO DE BENEF�CIO';

			SELECT * FROM TBVRT012_TIPO_BENEFICIO
			WHERE CODIGO_TIPO_BENEFICIO = @CODIGO_TIPO_BENEFICIO
			RETURN
		END


		END
END
GO


