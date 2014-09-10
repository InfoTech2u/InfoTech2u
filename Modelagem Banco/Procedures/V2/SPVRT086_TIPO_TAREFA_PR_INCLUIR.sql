-- TBVRT022_TIPO_TAREFA
CREATE PROCEDURE SPVRT085_TIPO_TAREFA_PR_INCLUIR
(
		@DESCRICAO					 nvarchar(80)	=         null,
		@CODIGO_USUARIO_CADASTRO	 int			=         null,
		@DATA_CADASTRO				 datetime		=         null,
		@CODIGO_USUARIO_ALTERACAO	 int			=	      null,
		@DATA_ALTERACAO			     datetime       =	      null,
		@CODIGO_STATUS				 int            =		  null,

		@C_ERR INT			 OUTPUT,
		@T_ERR VARCHAR(255)  OUTPUT 
)		
AS
	BEGIN
		INSERT INTO TBVRT022_TIPO_TAREFA(
			DESCRICAO,
			CODIGO_USUARIO_CADASTRO,	
			DATA_CADASTRO,			
			CODIGO_USUARIO_ALTERACAO,	
			DATA_ALTERACAO,		    
			CODIGO_STATUS			
		)
		VALUES(
			@DESCRICAO,				
			@CODIGO_USUARIO_CADASTRO,
			@DATA_CADASTRO,	
			@CODIGO_USUARIO_ALTERACAO,	
			@DATA_ALTERACAO,  
			@CODIGO_STATUS				
		)

		IF(@@ERROR <>0)
			BEGIN
				SELECT @C_ERR = @@ERROR
				SELECT @T_ERR = 'ERRO NO SELECT DA TABELA TBVRT022_TIPO_TAREFA.'
				RETURN
			END
		ELSE
			BEGIN
				SELECT @C_ERR = 0
				SELECT @T_ERR = 'TIPO TAREFA INSERIDO COM SUCESSO.'
				RETURN
			END
	END