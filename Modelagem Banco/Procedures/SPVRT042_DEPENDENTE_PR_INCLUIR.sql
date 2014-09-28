USE [DBVERITHUS]
GO

/****** Object:  StoredProcedure [dbo].[SPVRT042_DEPENDENTE_PR_INCLUIR]    Script Date: 28/09/2014 15:54:25 ******/
DROP PROCEDURE [dbo].[SPVRT042_DEPENDENTE_PR_INCLUIR]
GO

/****** Object:  StoredProcedure [dbo].[SPVRT042_DEPENDENTE_PR_INCLUIR]    Script Date: 28/09/2014 15:54:25 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[SPVRT042_DEPENDENTE_PR_INCLUIR]
(
	@CODIGO_FUNCIONARIO   int              =    null,
    @NOME                 nvarchar(100)    =    null,
    @CODIGO_TIPO_PARENTESCO int            =    null,
    @DATA_NASCIMENTO      datetime         =    null,
    @CODIGO_USUARIO_CADASTRO int           =    null,
    @DATA_CADASTRO        datetime         =    null,
    @CODIGO_USUARIO_ALTERACAO int          =    null,
    @DATA_ALTERACAO       datetime         =    null,
    @CODIGO_STATUS        int              =    null
)
AS
BEGIN

	INSERT INTO TBVRT011_DEPENDENTE(
		CODIGO_FUNCIONARIO,
		NOME,
		CODIGO_TIPO_PARENTESCO,
		DATA_NASCIMENTO,
		CODIGO_USUARIO_CADASTRO,
		DATA_CADASTRO,
		CODIGO_USUARIO_ALTERACAO,
		DATA_ALTERACAO,
		CODIGO_STATUS
	)
	VALUES(
		@CODIGO_FUNCIONARIO,
		@NOME,
		@CODIGO_TIPO_PARENTESCO,
		@DATA_NASCIMENTO,
		@CODIGO_USUARIO_CADASTRO,
		@DATA_CADASTRO,
		@CODIGO_USUARIO_ALTERACAO,
		@DATA_ALTERACAO,
		@CODIGO_STATUS
	)

	IF(@@ERROR = 0)
		BEGIN
			SELECT t0.*, t1.DESCRICAO AS TIPO_PARENTESCO_DESC, CONVERT(varchar, DATA_NASCIMENTO, 103) AS DATA_NASCIMENTO_STR FROM TBVRT011_DEPENDENTE t0 
			INNER JOIN TBVRT014_TIPO_PARENTESCO t1 ON t1.CODIGO_TIPO_PARENTESCO = t0.CODIGO_TIPO_PARENTESCO
			WHERE CODIGO_DEPENDENTE = @@IDENTITY
			RETURN
		END
END

GO


