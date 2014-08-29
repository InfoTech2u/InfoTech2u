/****** Object:  StoredProcedure [dbo].[SPVRT022_FUNCIONARIO_PR_INCLUIR]    Script Date: 19/08/2014 22:25:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SPVRT022_FUNCIONARIO_PR_INCLUIR]
(
    @CODIGO_ENDERECO      int             =     null,
    @CODIGO_EMPRESA       int             =     null,
    @CODIGO_CONTATO       int             =     null,
    @NOME_FUNCIONARIO     nvarchar(100)   =     null,
    @NUMERO_ORDEM_MATRICULA int           =     null,
    @NUMERO_MATRICULA     int             =     null,
    @NOME_PAI             nvarchar(100)   =     null,
    @NACIONALIDADE_PAI    nvarchar(100)   =     null,
    @NOME_MAE             nvarchar(100)   =     null,
    @NACIONALIDADE_MAE    nvarchar(100)   =     null,
    @DATA_NASCIMENTO      nvarchar(100)   =     null,
    @NACIMENTO            datetime        =     null,
    @CODIGO_ESTADO_CIVIL  int             =     null,
    @LOCAL_NASCIMENTO     int   =     null,
    @NOME_CONJUGE         nvarchar(100)   =     null,
    @QUANTOS_FILHOS       smallint        =     null,
    @CODIGO_USUARIO_CADASTRO int          =     null,
    @DATA_CADASTRO        datetime        =     null,
    @CODIGO_USUARIO_ALTERACAO int         =     null,
    @DATA_ALTERACAO       datetime        =     null,
    @CODIGO_STATUS        int             =     null
)
AS
BEGIN

	INSERT INTO TBVRT006_FUNCIONARIO(
		CODIGO_ENDERECO,
		CODIGO_EMPRESA,
		CODIGO_CONTATO,
		NOME_FUNCIONARIO,
		NUMERO_ORDEM_MATRICULA,
		NUMERO_MATRICULA,
		NOME_PAI,
		NACIONALIDADE_PAI,
		NOME_MAE,
		NACIONALIDADE_MAE,
		DATA_NASCIMENTO,
		NACIMENTO,
		CODIGO_ESTADO_CIVIL,
		LOCAL_NASCIMENTO,
		NOME_CONJUGE,
		QUANTOS_FILHOS,
		CODIGO_USUARIO_CADASTRO,
		DATA_CADASTRO,
		CODIGO_USUARIO_ALTERACAO,
		DATA_ALTERACAO,
		CODIGO_STATUS
	)
	VALUES(
		@CODIGO_ENDERECO,
		@CODIGO_EMPRESA,
		@CODIGO_CONTATO,
		@NOME_FUNCIONARIO,
		@NUMERO_ORDEM_MATRICULA,
		@NUMERO_MATRICULA,
		@NOME_PAI,
		@NACIONALIDADE_PAI,
		@NOME_MAE,
		@NACIONALIDADE_MAE,
		@DATA_NASCIMENTO,
		@NACIMENTO,
		@CODIGO_ESTADO_CIVIL,
		@LOCAL_NASCIMENTO,
		@NOME_CONJUGE,
		@QUANTOS_FILHOS,
		@CODIGO_USUARIO_CADASTRO,
		@DATA_CADASTRO,
		@CODIGO_USUARIO_ALTERACAO,
		@DATA_ALTERACAO,
		@CODIGO_STATUS
	)

	
END
GO