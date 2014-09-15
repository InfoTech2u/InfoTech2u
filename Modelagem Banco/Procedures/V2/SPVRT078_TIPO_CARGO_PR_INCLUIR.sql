CREATE PROCEDURE SPVRT078_TIPO_CARGO_PR_INCLUIR
(
    @DESCRICAO            nvarchar(80)     =    null,
    @CODIGO_USUARIO_CADASTRO int           =    null,
    @DATA_CADASTRO        datetime         =    null,
    @CODIGO_USUARIO_ALTERACAO int          =    null,
    @CODIGO_ALTERACAO     datetime         =    null,
    @CODIGO_STATUS        int              =    null
)
AS
BEGIN

	INSERT INTO TBVRT020_TIPO_CARGO(
		DESCRICAO,
		CODIGO_USUARIO_CADASTRO,
		DATA_CADASTRO,
		CODIGO_USUARIO_ALTERACAO,
		CODIGO_ALTERACAO,
		CODIGO_STATUS
	)
	VALUES(
		@DESCRICAO,
		@CODIGO_USUARIO_CADASTRO,
		@DATA_CADASTRO,
		@CODIGO_USUARIO_ALTERACAO,
		@CODIGO_ALTERACAO,
		@CODIGO_STATUS
	)

	IF(@@ERROR = 0)
	BEGIN
		SELECT * FROM  TBVRT020_TIPO_CARGO
		WHERE CODIGO_TIPO_CARGO = @@IDENTITY
	END	

END