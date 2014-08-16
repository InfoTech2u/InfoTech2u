/*==============================================================*/
/* DBMS name:      Microsoft SQL Server 2008                    */
/* Created on:     16/08/2014 16:30:44                          */
/*==============================================================*/


if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('TBVRT001_USUARIOS') and o.name = 'FK_TBVRT001_TIPO_ACES_TBVRT002')
alter table TBVRT001_USUARIOS
   drop constraint FK_TBVRT001_TIPO_ACES_TBVRT002
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('TBVRT006_FUNCIONARIO') and o.name = 'FK_TBVRT006_CONTATO_F_TBVRT035')
alter table TBVRT006_FUNCIONARIO
   drop constraint FK_TBVRT006_CONTATO_F_TBVRT035
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('TBVRT006_FUNCIONARIO') and o.name = 'FK_TBVRT006_EMPRESA_F_TBVRT030')
alter table TBVRT006_FUNCIONARIO
   drop constraint FK_TBVRT006_EMPRESA_F_TBVRT030
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('TBVRT006_FUNCIONARIO') and o.name = 'FK_TBVRT006_ENDERECO__TBVRT031')
alter table TBVRT006_FUNCIONARIO
   drop constraint FK_TBVRT006_ENDERECO__TBVRT031
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('TBVRT006_FUNCIONARIO') and o.name = 'FK_TBVRT006_ESTADO_CI_TBVRT040')
alter table TBVRT006_FUNCIONARIO
   drop constraint FK_TBVRT006_ESTADO_CI_TBVRT040
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('TBVRT007_DOCUMENTO') and o.name = 'FK_TBVRT007_FUNCIONAR_TBVRT006')
alter table TBVRT007_DOCUMENTO
   drop constraint FK_TBVRT007_FUNCIONAR_TBVRT006
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('TBVRT008_DOCUMENTO_ESTRANGEIRO') and o.name = 'FK_TBVRT008_FUNCIONAR_TBVRT006')
alter table TBVRT008_DOCUMENTO_ESTRANGEIRO
   drop constraint FK_TBVRT008_FUNCIONAR_TBVRT006
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('TBVRT009_DOCUMENTO_PIS') and o.name = 'FK_TBVRT009_BANCO_DOC_TBVRT039')
alter table TBVRT009_DOCUMENTO_PIS
   drop constraint FK_TBVRT009_BANCO_DOC_TBVRT039
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('TBVRT009_DOCUMENTO_PIS') and o.name = 'FK_TBVRT009_ENDERECO_TBVRT031')
alter table TBVRT009_DOCUMENTO_PIS
   drop constraint FK_TBVRT009_ENDERECO_TBVRT031
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('TBVRT009_DOCUMENTO_PIS') and o.name = 'FK_TBVRT009_FUNCIONAR_TBVRT006')
alter table TBVRT009_DOCUMENTO_PIS
   drop constraint FK_TBVRT009_FUNCIONAR_TBVRT006
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('TBVRT010_DOCUMENTO_FUNDO_GARANTIA') and o.name = 'FK_TBVRT010_BANCO_DOC_TBVRT039')
alter table TBVRT010_DOCUMENTO_FUNDO_GARANTIA
   drop constraint FK_TBVRT010_BANCO_DOC_TBVRT039
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('TBVRT010_DOCUMENTO_FUNDO_GARANTIA') and o.name = 'FK_TBVRT010_FUNCIONAR_TBVRT006')
alter table TBVRT010_DOCUMENTO_FUNDO_GARANTIA
   drop constraint FK_TBVRT010_FUNCIONAR_TBVRT006
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('TBVRT011_DEPENDENTE') and o.name = 'FK_TBVRT011_FUNCIONAR_TBVRT006')
alter table TBVRT011_DEPENDENTE
   drop constraint FK_TBVRT011_FUNCIONAR_TBVRT006
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('TBVRT011_DEPENDENTE') and o.name = 'FK_TBVRT011_TIPO_BENE_TBVRT012')
alter table TBVRT011_DEPENDENTE
   drop constraint FK_TBVRT011_TIPO_BENE_TBVRT012
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('TBVRT011_DEPENDENTE') and o.name = 'FK_TBVRT011_TIPO_PARE_TBVRT014')
alter table TBVRT011_DEPENDENTE
   drop constraint FK_TBVRT011_TIPO_PARE_TBVRT014
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('TBVRT012_TIPO_BENEFICIO') and o.name = 'FK_TBVRT012_CATEGORIA_TBVRT013')
alter table TBVRT012_TIPO_BENEFICIO
   drop constraint FK_TBVRT012_CATEGORIA_TBVRT013
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('TBVRT015_CARACTERISTICA_FISICA') and o.name = 'FK_TBVRT015_FUNCIONAR_TBVRT006')
alter table TBVRT015_CARACTERISTICA_FISICA
   drop constraint FK_TBVRT015_FUNCIONAR_TBVRT006
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('TBVRT015_CARACTERISTICA_FISICA') and o.name = 'FK_TBVRT015_TIPO_CABE_TBVRT017')
alter table TBVRT015_CARACTERISTICA_FISICA
   drop constraint FK_TBVRT015_TIPO_CABE_TBVRT017
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('TBVRT015_CARACTERISTICA_FISICA') and o.name = 'FK_TBVRT015_TIPO_COR__TBVRT016')
alter table TBVRT015_CARACTERISTICA_FISICA
   drop constraint FK_TBVRT015_TIPO_COR__TBVRT016
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('TBVRT015_CARACTERISTICA_FISICA') and o.name = 'FK_TBVRT015_TIPO_OLHO_TBVRT018')
alter table TBVRT015_CARACTERISTICA_FISICA
   drop constraint FK_TBVRT015_TIPO_OLHO_TBVRT018
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('TBVRT019_DADOS_ADMISSAO') and o.name = 'FK_TBVRT019_FUNCIONAR_TBVRT006')
alter table TBVRT019_DADOS_ADMISSAO
   drop constraint FK_TBVRT019_FUNCIONAR_TBVRT006
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('TBVRT019_DADOS_ADMISSAO') and o.name = 'FK_TBVRT019_TIPO_CARG_TBVRT020')
alter table TBVRT019_DADOS_ADMISSAO
   drop constraint FK_TBVRT019_TIPO_CARG_TBVRT020
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('TBVRT019_DADOS_ADMISSAO') and o.name = 'FK_TBVRT019_TIPO_FORM_TBVRT023')
alter table TBVRT019_DADOS_ADMISSAO
   drop constraint FK_TBVRT019_TIPO_FORM_TBVRT023
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('TBVRT019_DADOS_ADMISSAO') and o.name = 'FK_TBVRT019_TIPO_SECA_TBVRT021')
alter table TBVRT019_DADOS_ADMISSAO
   drop constraint FK_TBVRT019_TIPO_SECA_TBVRT021
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('TBVRT019_DADOS_ADMISSAO') and o.name = 'FK_TBVRT019_TIPO_TARE_TBVRT022')
alter table TBVRT019_DADOS_ADMISSAO
   drop constraint FK_TBVRT019_TIPO_TARE_TBVRT022
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('TBVRT024_DADOS_DEMISSAO') and o.name = 'FK_TBVRT024_FUNCIONAR_TBVRT006')
alter table TBVRT024_DADOS_DEMISSAO
   drop constraint FK_TBVRT024_FUNCIONAR_TBVRT006
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('TBVRT024_DADOS_DEMISSAO') and o.name = 'FK_TBVRT024_TIPO_CARG_TBVRT020')
alter table TBVRT024_DADOS_DEMISSAO
   drop constraint FK_TBVRT024_TIPO_CARG_TBVRT020
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('TBVRT024_DADOS_DEMISSAO') and o.name = 'FK_TBVRT024_TIPO_FORM_TBVRT023')
alter table TBVRT024_DADOS_DEMISSAO
   drop constraint FK_TBVRT024_TIPO_FORM_TBVRT023
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('TBVRT024_DADOS_DEMISSAO') and o.name = 'FK_TBVRT024_TIPO_SECA_TBVRT021')
alter table TBVRT024_DADOS_DEMISSAO
   drop constraint FK_TBVRT024_TIPO_SECA_TBVRT021
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('TBVRT024_DADOS_DEMISSAO') and o.name = 'FK_TBVRT024_TIPO_TARE_TBVRT022')
alter table TBVRT024_DADOS_DEMISSAO
   drop constraint FK_TBVRT024_TIPO_TARE_TBVRT022
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('TBVRT025_FERIAS') and o.name = 'FK_TBVRT025_FUNCIONAR_TBVRT006')
alter table TBVRT025_FERIAS
   drop constraint FK_TBVRT025_FUNCIONAR_TBVRT006
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('TBVRT026_ACIDENTE_TRABALHO') and o.name = 'FK_TBVRT026_FUNCIONAR_TBVRT006')
alter table TBVRT026_ACIDENTE_TRABALHO
   drop constraint FK_TBVRT026_FUNCIONAR_TBVRT006
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('TBVRT027_ALTERACAO_CARGO_SALARIO') and o.name = 'FK_TBVRT027_FUNCIONAR_TBVRT006')
alter table TBVRT027_ALTERACAO_CARGO_SALARIO
   drop constraint FK_TBVRT027_FUNCIONAR_TBVRT006
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('TBVRT028_CONTRIBUICAO_SINDICAL') and o.name = 'FK_TBVRT028_FUNCIONAR_TBVRT006')
alter table TBVRT028_CONTRIBUICAO_SINDICAL
   drop constraint FK_TBVRT028_FUNCIONAR_TBVRT006
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('TBVRT028_CONTRIBUICAO_SINDICAL') and o.name = 'FK_TBVRT028_SINDICATO_TBVRT029')
alter table TBVRT028_CONTRIBUICAO_SINDICAL
   drop constraint FK_TBVRT028_SINDICATO_TBVRT029
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('TBVRT030_EMPRESA') and o.name = 'FK_TBVRT030_CONTATO_E_TBVRT035')
alter table TBVRT030_EMPRESA
   drop constraint FK_TBVRT030_CONTATO_E_TBVRT035
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('TBVRT030_EMPRESA') and o.name = 'FK_TBVRT030_ENDERECO__TBVRT031')
alter table TBVRT030_EMPRESA
   drop constraint FK_TBVRT030_ENDERECO__TBVRT031
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('TBVRT032_DETALHE_ENDERECO') and o.name = 'FK_TBVRT032_ENDERECO__TBVRT031')
alter table TBVRT032_DETALHE_ENDERECO
   drop constraint FK_TBVRT032_ENDERECO__TBVRT031
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('TBVRT032_DETALHE_ENDERECO') and o.name = 'FK_TBVRT032_TIPO_ENDE_TBVRT033')
alter table TBVRT032_DETALHE_ENDERECO
   drop constraint FK_TBVRT032_TIPO_ENDE_TBVRT033
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('TBVRT032_DETALHE_ENDERECO') and o.name = 'FK_TBVRT032_TIPO_LOGR_TBVRT034')
alter table TBVRT032_DETALHE_ENDERECO
   drop constraint FK_TBVRT032_TIPO_LOGR_TBVRT034
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('TBVRT036_DETALHE_CONTATO_MAIL') and o.name = 'FK_TBVRT036_CONTATO_D_TBVRT035')
alter table TBVRT036_DETALHE_CONTATO_MAIL
   drop constraint FK_TBVRT036_CONTATO_D_TBVRT035
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('TBVRT036_DETALHE_CONTATO_MAIL') and o.name = 'FK_TBVRT036_TIPO_CONT_TBVRT038')
alter table TBVRT036_DETALHE_CONTATO_MAIL
   drop constraint FK_TBVRT036_TIPO_CONT_TBVRT038
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('TBVRT037_DETALHE_CONTATO_TELEFONICO') and o.name = 'FK_TBVRT037_CONTATO_D_TBVRT035')
alter table TBVRT037_DETALHE_CONTATO_TELEFONICO
   drop constraint FK_TBVRT037_CONTATO_D_TBVRT035
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('TBVRT037_DETALHE_CONTATO_TELEFONICO') and o.name = 'FK_TBVRT037_TIPO_CONT_TBVRT038')
alter table TBVRT037_DETALHE_CONTATO_TELEFONICO
   drop constraint FK_TBVRT037_TIPO_CONT_TBVRT038
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('TBVRT039_BANCO') and o.name = 'FK_TBVRT039_CONTATO_B_TBVRT035')
alter table TBVRT039_BANCO
   drop constraint FK_TBVRT039_CONTATO_B_TBVRT035
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TBVRT001_USUARIOS')
            and   type = 'U')
   drop table TBVRT001_USUARIOS
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TBVRT002_TIPO_ACESSO')
            and   type = 'U')
   drop table TBVRT002_TIPO_ACESSO
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TBVRT003_STATUS')
            and   type = 'U')
   drop table TBVRT003_STATUS
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TBVRT004_LOG_ERRO')
            and   type = 'U')
   drop table TBVRT004_LOG_ERRO
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TBVRT005_LOG_ACAO')
            and   type = 'U')
   drop table TBVRT005_LOG_ACAO
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TBVRT006_FUNCIONARIO')
            and   type = 'U')
   drop table TBVRT006_FUNCIONARIO
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TBVRT007_DOCUMENTO')
            and   type = 'U')
   drop table TBVRT007_DOCUMENTO
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TBVRT008_DOCUMENTO_ESTRANGEIRO')
            and   type = 'U')
   drop table TBVRT008_DOCUMENTO_ESTRANGEIRO
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TBVRT009_DOCUMENTO_PIS')
            and   type = 'U')
   drop table TBVRT009_DOCUMENTO_PIS
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TBVRT010_DOCUMENTO_FUNDO_GARANTIA')
            and   type = 'U')
   drop table TBVRT010_DOCUMENTO_FUNDO_GARANTIA
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TBVRT011_DEPENDENTE')
            and   type = 'U')
   drop table TBVRT011_DEPENDENTE
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TBVRT012_TIPO_BENEFICIO')
            and   type = 'U')
   drop table TBVRT012_TIPO_BENEFICIO
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TBVRT013_CATEGORIA_BENEFICIO')
            and   type = 'U')
   drop table TBVRT013_CATEGORIA_BENEFICIO
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TBVRT014_TIPO_PARENTESCO')
            and   type = 'U')
   drop table TBVRT014_TIPO_PARENTESCO
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TBVRT015_CARACTERISTICA_FISICA')
            and   type = 'U')
   drop table TBVRT015_CARACTERISTICA_FISICA
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TBVRT016_TIPO_COR')
            and   type = 'U')
   drop table TBVRT016_TIPO_COR
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TBVRT017_TIPO_CABELO')
            and   type = 'U')
   drop table TBVRT017_TIPO_CABELO
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TBVRT018_TIPO_OLHO')
            and   type = 'U')
   drop table TBVRT018_TIPO_OLHO
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TBVRT019_DADOS_ADMISSAO')
            and   type = 'U')
   drop table TBVRT019_DADOS_ADMISSAO
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TBVRT020_TIPO_CARGO')
            and   type = 'U')
   drop table TBVRT020_TIPO_CARGO
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TBVRT021_TIPO_SECAO')
            and   type = 'U')
   drop table TBVRT021_TIPO_SECAO
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TBVRT022_TIPO_TAREFA')
            and   type = 'U')
   drop table TBVRT022_TIPO_TAREFA
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TBVRT023_TIPO_FORMA_PAGAMENTO')
            and   type = 'U')
   drop table TBVRT023_TIPO_FORMA_PAGAMENTO
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TBVRT024_DADOS_DEMISSAO')
            and   type = 'U')
   drop table TBVRT024_DADOS_DEMISSAO
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TBVRT025_FERIAS')
            and   type = 'U')
   drop table TBVRT025_FERIAS
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TBVRT026_ACIDENTE_TRABALHO')
            and   type = 'U')
   drop table TBVRT026_ACIDENTE_TRABALHO
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TBVRT027_ALTERACAO_CARGO_SALARIO')
            and   type = 'U')
   drop table TBVRT027_ALTERACAO_CARGO_SALARIO
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TBVRT028_CONTRIBUICAO_SINDICAL')
            and   type = 'U')
   drop table TBVRT028_CONTRIBUICAO_SINDICAL
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TBVRT029_SINDICATO')
            and   type = 'U')
   drop table TBVRT029_SINDICATO
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TBVRT030_EMPRESA')
            and   type = 'U')
   drop table TBVRT030_EMPRESA
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TBVRT031_ENDERECO')
            and   type = 'U')
   drop table TBVRT031_ENDERECO
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TBVRT032_DETALHE_ENDERECO')
            and   type = 'U')
   drop table TBVRT032_DETALHE_ENDERECO
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TBVRT033_TIPO_ENDERECO')
            and   type = 'U')
   drop table TBVRT033_TIPO_ENDERECO
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TBVRT034_TIPO_LOGRADOURO')
            and   type = 'U')
   drop table TBVRT034_TIPO_LOGRADOURO
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TBVRT035_CONTATO')
            and   type = 'U')
   drop table TBVRT035_CONTATO
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TBVRT036_DETALHE_CONTATO_MAIL')
            and   type = 'U')
   drop table TBVRT036_DETALHE_CONTATO_MAIL
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TBVRT037_DETALHE_CONTATO_TELEFONICO')
            and   type = 'U')
   drop table TBVRT037_DETALHE_CONTATO_TELEFONICO
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TBVRT038_TIPO_CONTATO')
            and   type = 'U')
   drop table TBVRT038_TIPO_CONTATO
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TBVRT039_BANCO')
            and   type = 'U')
   drop table TBVRT039_BANCO
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TBVRT040_ESTADO_CIVIL')
            and   type = 'U')
   drop table TBVRT040_ESTADO_CIVIL
go

/*==============================================================*/
/* Table: TBVRT001_USUARIOS                                     */
/*==============================================================*/
create table TBVRT001_USUARIOS (
   CODIGO_USUARIO       int                  not null,
   NOME                 nvarchar(80)         null,
   MAIL                 nvarchar(120)        null,
   LOGIN                nvarchar(80)         null,
   SENHA                nvarchar(80)         null,
   CODIGO_TIPO_ACESSO   int                  null,
   CODIGO_USUARIO_CADASTRO int                  null,
   DATA_CADASTRO        datetime             null,
   CODIGO_USUARIO_ALTERACAO int                  null,
   DATA_ALTERACAO       datetime             null,
   CODIGO_STATUS        int                  null,
   constraint PK_TBVRT001_USUARIOS primary key (CODIGO_USUARIO)
)
go

/*==============================================================*/
/* Table: TBVRT002_TIPO_ACESSO                                  */
/*==============================================================*/
create table TBVRT002_TIPO_ACESSO (
   CODIGO_TIPO_ACESSO   int                  not null,
   DESCRICAO            nvarchar(80)         null,
   CODIGO_USUARIO_CADASTRO int                  null,
   DATA_CADASTRO        datetime             null,
   CODIGO_USUARIO_ALTERACAO int                  null,
   DATA_ALTERACAO       datetime             null,
   CODIGO_STATUS        int                  null,
   constraint PK_TBVRT002_TIPO_ACESSO primary key (CODIGO_TIPO_ACESSO)
)
go

/*==============================================================*/
/* Table: TBVRT003_STATUS                                       */
/*==============================================================*/
create table TBVRT003_STATUS (
   CODIGO_STATUS        int                  not null,
   DESCRICAO            nvarchar(80)         null,
   CODIGO_USUARIO_CADASTRO int                  null,
   DATA_CADASTRO        datetime             null,
   CODIGO_USUARIO_ALTERACAO int                  null,
   DATA_ALTERACAO       datetime             null,
   constraint PK_TBVRT003_STATUS primary key (CODIGO_STATUS)
)
go

/*==============================================================*/
/* Table: TBVRT004_LOG_ERRO                                     */
/*==============================================================*/
create table TBVRT004_LOG_ERRO (
   CODIGO_LOG_ERRO      int                  not null,
   DESCRICAO            xml                  null,
   DATA                 datetime             null,
   CODIGO_USUARIO_EXECUCAO int                  null,
   constraint PK_TBVRT004_LOG_ERRO primary key (CODIGO_LOG_ERRO)
)
go

/*==============================================================*/
/* Table: TBVRT005_LOG_ACAO                                     */
/*==============================================================*/
create table TBVRT005_LOG_ACAO (
   CODIGO_LOG_ACAO      int                  not null,
   DESCRICAO            xml                  null,
   DATA                 datetime             null,
   CODIGO_USUARIO_EXECUCAO int                  null,
   constraint PK_TBVRT005_LOG_ACAO primary key (CODIGO_LOG_ACAO)
)
go

/*==============================================================*/
/* Table: TBVRT006_FUNCIONARIO                                  */
/*==============================================================*/
create table TBVRT006_FUNCIONARIO (
   CODIGO_FUNCIONARIO   int                  not null,
   CODIGO_ENDERECO      int                  null,
   CODIGO_EMPRESA       int                  null,
   CODIGO_CONTATO       int                  null,
   NOME_FUNCIONARIO     nvarchar(100)        null,
   NUMERO_ORDEM_MATRICULA int                  null,
   NUMERO_MATRICULA     int                  null,
   NOME_PAI             nvarchar(100)        null,
   NACIONALIDADE_PAI    nvarchar(100)        null,
   NOME_MAE             nvarchar(100)        null,
   NACIONALIDADE_MAE    nvarchar(100)        null,
   DATA_NASCIMENTO      nvarchar(100)        null,
   NACIMENTO            datetime             null,
   CODIGO_ESTADO_CIVIL  int                  null,
   LOCAL_NASCIMENTO     nvarchar(100)        null,
   ESTADO               char(2)              null,
   NOME_CONJUGE         nvarchar(100)        null,
   QUANTOS_FILHOS       smallint             null,
   CODIGO_USUARIO_CADASTRO int                  null,
   DATA_CADASTRO        datetime             null,
   CODIGO_USUARIO_ALTERACAO int                  null,
   DATA_ALTERACAO       datetime             null,
   CODIGO_STATUS        int                  null,
   constraint PK_TBVRT006_FUNCIONARIO primary key (CODIGO_FUNCIONARIO)
)
go

/*==============================================================*/
/* Table: TBVRT007_DOCUMENTO                                    */
/*==============================================================*/
create table TBVRT007_DOCUMENTO (
   CODIGO_DOCUMENTO     int                  not null,
   CODIGO_FUNCIONARIO   int                  null,
   NUMERO_IDENTIDADE    nvarchar(11)         null,
   NUMERO_CARTEIRA_TRABALHO nvarchar(15)         null,
   NUMERO_SERIE         nvarchar(15)         null,
   NUMERO_CERTIFICADO_RESERVISTA nvarchar(15)         null,
   CATEGORIA            nvarchar(15)         null,
   NUMERO_CPF           nvarchar(11)         null,
   TITULO_DE_ELEITOR    nvarchar(15)         null,
   NUMERO_CARTEIRA_SAUDE nvarchar(15)         null,
   CODIGO_USUARIO_CADASTRO int                  null,
   DATA_CADASTRO        datetime             null,
   CODIGO_USUARIO_ALTERACAO int                  null,
   DATA_ALTERACAO       datetime             null,
   CODIGO_STATUS        int                  null,
   constraint PK_TBVRT007_DOCUMENTO primary key (CODIGO_DOCUMENTO)
)
go

/*==============================================================*/
/* Table: TBVRT008_DOCUMENTO_ESTRANGEIRO                        */
/*==============================================================*/
create table TBVRT008_DOCUMENTO_ESTRANGEIRO (
   CODIGO_DOCUMENTO_ESTRAGEIRO int                  not null,
   CODIGO_FUNCIONARIO   int                  null,
   NUMERO_CBO           nvarchar(80)         null,
   NUMERO_CARTEIRA_19   nvarchar(80)         null,
   NUMERO_RESISTRO_GERAL nvarchar(80)         null,
   CASADO_BRASILEIRO    char(1)              null,
   NUTURALIZADO         char(1)              null,
   FILHO_BRASILEIRO     char(1)              null,
   DATA_CHEGADA_BRASIL  datetime             null,
   CODIGO_USUARIO_CADASTRO int                  null,
   DATA_CADASTRO        datetime             null,
   CODIGO_USUARIO_ALTERACAO int                  null,
   DATA_ALTERACAO       datetime             null,
   CODIGO_STATUS        int                  null,
   constraint PK_TBVRT008_DOCUMENTO_ESTRANGE primary key (CODIGO_DOCUMENTO_ESTRAGEIRO)
)
go

/*==============================================================*/
/* Table: TBVRT009_DOCUMENTO_PIS                                */
/*==============================================================*/
create table TBVRT009_DOCUMENTO_PIS (
   CODIGO_PIS           int                  not null,
   DATA_CADASTRO_PIS    datetime             null,
   SOB_NUMERO           nvarchar(10)         null,
   SOB_BANCO            nvarchar(10)         null,
   CODIGO_ENDERECO      int                  null,
   CODIGO_FUNCIONARIO   int                  null,
   CODIGO_BANCO         int                  null,
   CODIGO_USUARIO_CADASTRO int                  null,
   DATA_CADASTRO        datetime             null,
   CODIGO_USUARIO_ALTERACAO int                  null,
   DATA_ALTERACAO       int                  null,
   CODIGO_STATUS        int                  null,
   constraint PK_TBVRT009_DOCUMENTO_PIS primary key (CODIGO_PIS)
)
go

/*==============================================================*/
/* Table: TBVRT010_DOCUMENTO_FUNDO_GARANTIA                     */
/*==============================================================*/
create table TBVRT010_DOCUMENTO_FUNDO_GARANTIA (
   CODIGO_DOCUMENTO_FUNDO_GARANTIA int                  not null,
   CODIGO_FUNCIONARIO   int                  null,
   OPTANTE              char(1)              null,
   DATA_OPCAO           datetime             null,
   DATA_RETRATACAO      datetime             null,
   CODIGO_BANCO         int                  null,
   CODIGO_USUARIO_CADASTRO int                  null,
   DATA_CADASTRO        datetime             null,
   CODIGO_USUARIO_ALTERACAO int                  null,
   DATA_ALTERACAO       datetime             null,
   CODIGO_STATUS        int                  null,
   constraint PK_TBVRT010_DOCUMENTO_FUNDO_GA primary key (CODIGO_DOCUMENTO_FUNDO_GARANTIA)
)
go

/*==============================================================*/
/* Table: TBVRT011_DEPENDENTE                                   */
/*==============================================================*/
create table TBVRT011_DEPENDENTE (
   CODIGO_DEPENDENTE    int                  not null,
   COD_DETL_FUNC        int                  null,
   CODIGO_TIPO_BENECIFIO int                  null,
   NOME                 nvarchar(100)        null,
   CODIGO_TIPO_PARENTESCO int                  null,
   DATA_NASCIMENTO      datetime             null,
   CODIGO_USUARIO_CADASTRO int                  null,
   DATA_CADASTRO        datetime             null,
   CODIGO_USUARIO_ALTERACAO int                  null,
   DATA_ALTERACAO       datetime             null,
   CODIGO_STATUS        int                  null,
   constraint PK_TBVRT011_DEPENDENTE primary key (CODIGO_DEPENDENTE)
)
go

/*==============================================================*/
/* Table: TBVRT012_TIPO_BENEFICIO                               */
/*==============================================================*/
create table TBVRT012_TIPO_BENEFICIO (
   CODIGO_TIPO_BENECIFIO int                  not null,
   CODIGO_CATEGORIA_BENEFICIO int                  null,
   DESCRICAO            nvarchar(80)         null,
   CODIGO_USUARIO_CADASTRO int                  null,
   DATA_CADASTRO        datetime             null,
   CODIGO_USUARIO_ATUALIZACAO int                  null,
   DATA_ATUALIZACAO     datetime             null,
   CODIGO_STATUS        int                  null,
   constraint PK_TBVRT012_TIPO_BENEFICIO primary key (CODIGO_TIPO_BENECIFIO)
)
go

/*==============================================================*/
/* Table: TBVRT013_CATEGORIA_BENEFICIO                          */
/*==============================================================*/
create table TBVRT013_CATEGORIA_BENEFICIO (
   CODIGO_CATEGORIA_BENEFICIO int                  not null,
   DESCRICAO            nvarchar(80)         null,
   CODIGO_USUARIO_CADASTRO int                  null,
   DATA_CADASTRO        datetime             null,
   CODIGO_USUARIO_ATUALIZACAO int                  null,
   DATA_ATUALIZACAO     datetime             null,
   CODIGO_STATUS        int                  null,
   constraint PK_TBVRT013_CATEGORIA_BENEFICI primary key (CODIGO_CATEGORIA_BENEFICIO)
)
go

/*==============================================================*/
/* Table: TBVRT014_TIPO_PARENTESCO                              */
/*==============================================================*/
create table TBVRT014_TIPO_PARENTESCO (
   CODIGO_TIPO_PARENTESCO int                  not null,
   DESCRICAO            nvarchar(80)         null,
   CODIGO_USUARIO_CADASTRO int                  null,
   DATA_CADASTRO        datetime             null,
   CODIGO_USUARIO_ALTERACAO int                  null,
   DATA_ALTERACAO       datetime             null,
   CODIGO_STATUS        int                  null,
   constraint PK_TBVRT014_TIPO_PARENTESCO primary key (CODIGO_TIPO_PARENTESCO)
)
go

/*==============================================================*/
/* Table: TBVRT015_CARACTERISTICA_FISICA                        */
/*==============================================================*/
create table TBVRT015_CARACTERISTICA_FISICA (
   CODIGO_CARACTERISTICA_FISICA int                  null,
   COD_DETL_FUNC        int                  null,
   CODIGO_TIPO_COR      int                  null,
   ALTURA               decimal(3,2)         null,
   PESO                 decimal(5,2)         null,
   CODIGO_TIPO_CABELO   int                  null,
   CODIGO_TIPO_OLHO     int                  null,
   SINAIS               nvarchar(80)         null,
   CODIGO_USUARIO_CADASTRO int                  null,
   DATA_CADASTRO        datetime             null,
   CODIGO_USUARIO_ALTERACAO int                  null,
   DATA_ALTERACAO       datetime             null,
   CODIGO_STATUS        int                  null
)
go

/*==============================================================*/
/* Table: TBVRT016_TIPO_COR                                     */
/*==============================================================*/
create table TBVRT016_TIPO_COR (
   CODIGO_TIPO_COR      int                  not null,
   DESCRICAO            nvarchar(80)         null,
   CODIGO_USUARIO_CADASTRO int                  null,
   DATA_CADASTRO        datetime             null,
   CODIGO_USUARIO_ALTERACAO int                  null,
   DATA_ALTERACAO       datetime             null,
   CODIGO_STATUS        int                  null,
   constraint PK_TBVRT016_TIPO_COR primary key (CODIGO_TIPO_COR)
)
go

/*==============================================================*/
/* Table: TBVRT017_TIPO_CABELO                                  */
/*==============================================================*/
create table TBVRT017_TIPO_CABELO (
   CODIGO_TIPO_CABELO   int                  not null,
   DESCRICAO            nvarchar(80)         null,
   CODIGO_USUARIO_CADASTRO int                  null,
   DATA_CADASTRO        datetime             null,
   CODIGO_USUARIO_ALTERACAO int                  null,
   DATA_ALTERACAO       datetime             null,
   CODIGO_STATUS        int                  null,
   constraint PK_TBVRT017_TIPO_CABELO primary key (CODIGO_TIPO_CABELO)
)
go

/*==============================================================*/
/* Table: TBVRT018_TIPO_OLHO                                    */
/*==============================================================*/
create table TBVRT018_TIPO_OLHO (
   CODIGO_TIPO_OLHO     int                  not null,
   DESCRICAO            nvarchar(80)         null,
   CODIGO_USUARIO_CADASTRO int                  null,
   DATA_CADASTRO        datetime             null,
   CODIGO_USUARIO_ALTERACAO int                  null,
   DATA_ALTERACAO       datetime             null,
   CODIGO_STATUS        int                  null,
   constraint PK_TBVRT018_TIPO_OLHO primary key (CODIGO_TIPO_OLHO)
)
go

/*==============================================================*/
/* Table: TBVRT019_DADOS_ADMISSAO                               */
/*==============================================================*/
create table TBVRT019_DADOS_ADMISSAO (
   CODIGO_ADMISSAO      int                  not null,
   COD_DETL_FUNC        int                  null,
   DATA_ADMISSAO        datetime             null,
   DATA_REGISTRO        datetime             null,
   CODIGO_TIPO_CARGO    int                  null,
   CODIGO_TIPO_SECAO    int                  null,
   SALARIO_INICIAL      decimal(8,2)         null,
   COMISSAO             nvarchar(80)         null,
   CODIGO_TIPO_TAREFA   int                  null,
   CODIGO_TIPO_FORMA_PAGAMENTO int                  null,
   HORARIO_TRABALHO_INICIO datetime             null,
   HORARIO_TRABALHO_FIM datetime             null,
   INTERVALO_ALMOCO_INICIO datetime             null,
   INTERVALO_ALMOCO_FIM datetime             null,
   DESCANSO_SEMANAL_INICIO datetime             null,
   DESCANSO_SEMANAL_FIM datetime             null,
   CODIGO_USUARIO_CADASTRO int                  null,
   DATA_CADASTRO        datetime             null,
   CODIGO_USUARIO_ALTERACAO int                  null,
   DATA_ALTERACAO       datetime             null,
   CODIGO_STATUS        int                  null,
   constraint PK_TBVRT019_DADOS_ADMISSAO primary key (CODIGO_ADMISSAO)
)
go

/*==============================================================*/
/* Table: TBVRT020_TIPO_CARGO                                   */
/*==============================================================*/
create table TBVRT020_TIPO_CARGO (
   CODIGO_TIPO_CARGO    int                  not null,
   DESCRICAO            nvarchar(80)         null,
   CODIGO_USUARIO_CADASTRO int                  null,
   DATA_CADASTRO        datetime             null,
   CODIGO_USUARIO_ALTERACAO int                  null,
   CODIGO_ALTERACAO     datetime             null,
   CODIGO_STATUS        int                  null,
   constraint PK_TBVRT020_TIPO_CARGO primary key (CODIGO_TIPO_CARGO)
)
go

/*==============================================================*/
/* Table: TBVRT021_TIPO_SECAO                                   */
/*==============================================================*/
create table TBVRT021_TIPO_SECAO (
   CODIGO_TIPO_SECAO    int                  not null,
   DESCRICAO            nvarchar(80)         null,
   CODIGO_USUARIO_CADASTRO int                  null,
   DATA_CADASTRO        datetime             null,
   CODIGO_USUARIO_ATUALIZACAO int                  null,
   DATA_ATUALIZACAO     datetime             null,
   CODIGO_STATUS        int                  null,
   constraint PK_TBVRT021_TIPO_SECAO primary key (CODIGO_TIPO_SECAO)
)
go

/*==============================================================*/
/* Table: TBVRT022_TIPO_TAREFA                                  */
/*==============================================================*/
create table TBVRT022_TIPO_TAREFA (
   CODIGO_TIPO_TAREFA   int                  not null,
   DESCRICAO            nvarchar(80)         null,
   CODIGO_USUARIO_CADASTRO int                  null,
   DATA_CADASTRO        datetime             null,
   CODIGO_USUARIO_ALTERACAO int                  null,
   DATA_ALTERACAO       datetime             null,
   CODIGO_STATUS        int                  null,
   constraint PK_TBVRT022_TIPO_TAREFA primary key (CODIGO_TIPO_TAREFA)
)
go

/*==============================================================*/
/* Table: TBVRT023_TIPO_FORMA_PAGAMENTO                         */
/*==============================================================*/
create table TBVRT023_TIPO_FORMA_PAGAMENTO (
   CODIGO_TIPO_FORMA_PAGAMENTO int                  not null,
   DESCRICAO            nvarchar(80)         null,
   CODIGO_USUARIO_CADASTRO int                  null,
   DATA_CADASTRO        datetime             null,
   CODIGO_USUARIO_ALTERACAO int                  null,
   DATA_ALTERACAO       datetime             null,
   CODIGO_STATUS        int                  null,
   constraint PK_TBVRT023_TIPO_FORMA_PAGAMEN primary key (CODIGO_TIPO_FORMA_PAGAMENTO)
)
go

/*==============================================================*/
/* Table: TBVRT024_DADOS_DEMISSAO                               */
/*==============================================================*/
create table TBVRT024_DADOS_DEMISSAO (
   CODIGO_DEMISSAO      int                  not null,
   COD_DETL_FUNC        int                  null,
   DATA_DEMISSAO        datetime             null,
   DATA_REGISTRO        datetime             null,
   CODIGO_TIPO_CARGO    int                  null,
   CODIGO_TIPO_SECAO    int                  null,
   SALARIO_INICIAL      decimal(8,2)         null,
   COMISSAO             nvarchar(80)         null,
   CODIGO_TIPO_TAREFA   int                  null,
   CODIGO_TIPO_FORMA_PAGAMENTO int                  null,
   CODIGO_FORMA_PAGAMENTO int                  null,
   CODIGO_USUARIO_CADASTRO int                  null,
   DATA_CADASTRO        datetime             null,
   CODIGO_USUARIO_ALTERACAO int                  null,
   DATA_ALTERACAO       datetime             null,
   CODIGO_STATUS        int                  null,
   constraint PK_TBVRT024_DADOS_DEMISSAO primary key (CODIGO_DEMISSAO)
)
go

/*==============================================================*/
/* Table: TBVRT025_FERIAS                                       */
/*==============================================================*/
create table TBVRT025_FERIAS (
   CODIGO_FERIAS        int                  not null,
   COD_DETL_FUNC        int                  null,
   DATA_PERIODO_INICIO  datetime             null,
   DATA_PERIODO_FIM     datetime             null,
   DATA_GOZADA_INICIO   datetime             null,
   DATA_GOZADA_FIM      datetime             null,
   CODIGO_USUARIO_CADASTRO int                  null,
   DATA_CADASTRO        datetime             null,
   CODIGO_USUARIO_ALTERACAO int                  null,
   DATA_ALTERACAO       datetime             null,
   CODIGO_STATUS        int                  null,
   constraint PK_TBVRT025_FERIAS primary key (CODIGO_FERIAS)
)
go

/*==============================================================*/
/* Table: TBVRT026_ACIDENTE_TRABALHO                            */
/*==============================================================*/
create table TBVRT026_ACIDENTE_TRABALHO (
   CODIGO_ACIDENTE_TRABALHO int                  null,
   COD_DETL_FUNC        int                  null,
   DATA                 datetime             null,
   LOCAL                text                 null,
   CAUSA                text                 null,
   DATA_ALTA            datetime             null,
   RESULTADO            text                 null,
   OBSERVACOES          text                 null,
   CODIGO_USUARIO_CADASTRO int                  null,
   DATA_CADASTRO        datetime             null,
   CODIGO_USUARIO_ALTERACAO int                  null,
   DATA_ALTERACAO       datetime             null,
   CODIGO_STATUS        int                  null
)
go

/*==============================================================*/
/* Table: TBVRT027_ALTERACAO_CARGO_SALARIO                      */
/*==============================================================*/
create table TBVRT027_ALTERACAO_CARGO_SALARIO (
   CODIGO_ALTERACAO_CARGO_SALARIO int                  not null,
   COD_DETL_FUNC        int                  null,
   DATA                 datetime             null,
   CODIGO_TIPO_CARGO    int                  null,
   SALARIO              nvarchar(80)         null,
   HORARIO_INICIO       time                 null,
   HORARIO_FIM          time                 null,
   CODIGO_USUARIO_CADASTRO int                  null,
   DATA_CADASTRO        datetime             null,
   CODIGO_USUARIO_ALTERACAO int                  null,
   DATA_ALTERACAO       datetime             null,
   CODIGO_STATUS        int                  null,
   constraint PK_TBVRT027_ALTERACAO_CARGO_SA primary key (CODIGO_ALTERACAO_CARGO_SALARIO)
)
go

/*==============================================================*/
/* Table: TBVRT028_CONTRIBUICAO_SINDICAL                        */
/*==============================================================*/
create table TBVRT028_CONTRIBUICAO_SINDICAL (
   CODIGO_CONTRIBUICAO_SINDICAL int                  not null,
   COD_DETL_FUNC        int                  null,
   PERIODO_ANO          datetime             null,
   CODIGO_SINDICATO     int                  null,
   VALOR_RECOLHIDO      nvarchar(80)         null,
   CODIGO_USUARIO_CADASTRO int                  null,
   DATA_CADASTRO        datetime             null,
   CODIGO_USUARIO_ALTERACAO int                  null,
   DATA_ALTERACAO       datetime             null,
   CODIGO_STATUS        int                  null,
   constraint PK_TBVRT028_CONTRIBUICAO_SINDI primary key (CODIGO_CONTRIBUICAO_SINDICAL)
)
go

/*==============================================================*/
/* Table: TBVRT029_SINDICATO                                    */
/*==============================================================*/
create table TBVRT029_SINDICATO (
   CODIGO_SINDICATO     int                  not null,
   NOME                 nvarchar(80)         null,
   CODIGO_USUARIO_CADASTRO int                  null,
   DATA_CADASTRO        datetime             null,
   CODIGO_USUARIO_ALTERACAO int                  null,
   DATA_ALTERACAO       datetime             null,
   CODIGO_STATUS        int                  null,
   constraint PK_TBVRT029_SINDICATO primary key (CODIGO_SINDICATO)
)
go

/*==============================================================*/
/* Table: TBVRT030_EMPRESA                                      */
/*==============================================================*/
create table TBVRT030_EMPRESA (
   CODIGO_EMPRESA       int                  not null,
   CODIGO_ENDERECO      int                  null,
   CODIGO_CONTATO       int                  null,
   CNJP                 nvarchar(14)         null,
   RAZAO_SOCIAL         varchar(80)          null,
   NOME_FANTASIA        varchar(80)          null,
   INCRICAO_ESTADUAL    varchar(80)          null,
   CODIGO_USUARIO_CADASTRO int                  null,
   DATA_CADASTRO        datetime             null,
   CODIGO_USUARIO_ALTERACAO int                  null,
   DATA_ALTERACAO       datetime             null,
   CODIGO_STATUS        int                  null,
   constraint PK_TBVRT030_EMPRESA primary key (CODIGO_EMPRESA)
)
go

/*==============================================================*/
/* Table: TBVRT031_ENDERECO                                     */
/*==============================================================*/
create table TBVRT031_ENDERECO (
   CODIGO_ENDERECO      int                  not null,
   CODIGO_USUARIO_CADASTRO int                  null,
   DATA_CADASTRO        datetime             null,
   CODIGO_USUARIO_ALTERACAO int                  null,
   DATA_ALTERACAO       datetime             null,
   CODIGO_STATUS        int                  null,
   constraint PK_TBVRT031_ENDERECO primary key (CODIGO_ENDERECO)
)
go

/*==============================================================*/
/* Table: TBVRT032_DETALHE_ENDERECO                             */
/*==============================================================*/
create table TBVRT032_DETALHE_ENDERECO (
   CODIGO_DETALHE_ENDERECO int                  not null,
   CODIGO_ENDERECO      int                  null,
   CODIGO_TIPO_ENDERECO int                  null,
   CODIGO_TIPO_LOGRADOURO int                  null,
   LOGRADOURO           nvarchar(120)        null,
   NUMERO               char varying(8)      null,
   BAIRRO               nvarchar(80)         null,
   COMPLEMENTO          nvarchar(80)         null,
   CEP                  char(8)              null,
   CODIGO_USUARIO_CADASTRO int                  null,
   DATA_CADASTRO        datetime             null,
   CODIGO_USUARIO_ALTERACAO int                  null,
   DATA_ALTERACAO       datetime             null,
   CODIGO_STATUS        int                  null,
   constraint PK_TBVRT032_DETALHE_ENDERECO primary key (CODIGO_DETALHE_ENDERECO)
)
go

/*==============================================================*/
/* Table: TBVRT033_TIPO_ENDERECO                                */
/*==============================================================*/
create table TBVRT033_TIPO_ENDERECO (
   CODIGO_TIPO_ENDERECO int                  not null,
   DESCRICAO            nvarchar(80)         null,
   CODIGO_USUARIO_CADASTRO_ int                  null,
   DATA_CADASTRO        datetime             null,
   CODIGO_USUARIO_ALTERACAO int                  null,
   DATA_ALTERACAO       datetime             null,
   CODIGO_STATUS        int                  null,
   constraint PK_TBVRT033_TIPO_ENDERECO primary key (CODIGO_TIPO_ENDERECO)
)
go

/*==============================================================*/
/* Table: TBVRT034_TIPO_LOGRADOURO                              */
/*==============================================================*/
create table TBVRT034_TIPO_LOGRADOURO (
   CODIGO_TIPO_LOGRADOURO int                  not null,
   DESCRICAO            nvarchar(80)         null,
   CODIGO_USUARIO_CADASTRO int                  null,
   DATA_CADASTRO        datetime             null,
   CODIGO_USUARIO_ALTERACAO int                  null,
   DATA_ALTERACAO       datetime             null,
   CODIGO_STATUS        int                  null,
   constraint PK_TBVRT034_TIPO_LOGRADOURO primary key (CODIGO_TIPO_LOGRADOURO)
)
go

/*==============================================================*/
/* Table: TBVRT035_CONTATO                                      */
/*==============================================================*/
create table TBVRT035_CONTATO (
   CODIGO_CONTATO       int                  not null,
   CODIGO_USUARIO_CADASTRO int                  null,
   DATA_CADASTRO        datetime             null,
   CODIGO_USUARIO_ALTERACAO int                  null,
   DATA_ALTERACAO       datetime             null,
   CODIGO_STATUS        int                  null,
   constraint PK_TBVRT035_CONTATO primary key (CODIGO_CONTATO)
)
go

/*==============================================================*/
/* Table: TBVRT036_DETALHE_CONTATO_MAIL                         */
/*==============================================================*/
create table TBVRT036_DETALHE_CONTATO_MAIL (
   CODIGO_DETALHE_CONTATO_MAIL int                  not null,
   CODIGO_CONTATO       int                  null,
   CODIGO_TIPO_CONTATO  int                  null,
   MAIL                 nvarchar(120)        null,
   NOME_CONTATO         nvarchar(80)         null,
   CODIGO_USUARIO_CADASTRO int                  null,
   DATA_CADASTRO        datetime             null,
   CODIGO_USUARIO_ALTERACAO int                  null,
   DATA_ALTERACAO       datetime             null,
   CODIGO_STATUS        int                  null,
   constraint PK_TBVRT036_DETALHE_CONTATO_MA primary key (CODIGO_DETALHE_CONTATO_MAIL)
)
go

/*==============================================================*/
/* Table: TBVRT037_DETALHE_CONTATO_TELEFONICO                   */
/*==============================================================*/
create table TBVRT037_DETALHE_CONTATO_TELEFONICO (
   CODIGO_DETALHE_CONTATO_TELEFONICO int                  not null,
   CODIGO_CONTATO       int                  null,
   CODIGO_TIPO_CONTATO  int                  null,
   DDI                  char(3)              null,
   DDD                  char(3)              null,
   TELEFONE_RAMAL       char(9)              null,
   NOME_CONTATO         nvarchar(80)         null,
   NOME_RECADO          nvarchar(80)         null,
   CODIGO_USUARIO_CADASTRO int                  null,
   DATA_CADASTRO        datetime             null,
   CODIGO_USUARIO_ALTERACAO int                  null,
   DATA_ALTERACAO       datetime             null,
   CODIGO_STATUS        int                  null,
   constraint PK_TBVRT037_DETALHE_CONTATO_TE primary key (CODIGO_DETALHE_CONTATO_TELEFONICO)
)
go

/*==============================================================*/
/* Table: TBVRT038_TIPO_CONTATO                                 */
/*==============================================================*/
create table TBVRT038_TIPO_CONTATO (
   CODIGO_TIPO_CONTATO  int                  not null,
   DESCRICAO            nvarchar(80)         null,
   CODIGO_USUARIO_CADASTRO int                  null,
   DATA_CADASTRO        datetime             null,
   CODIGO_USUARIO_ALTERACAO int                  null,
   DATA_ALTERACAO       datetime             null,
   CODIGO_STATUS        int                  null,
   constraint PK_TBVRT038_TIPO_CONTATO primary key (CODIGO_TIPO_CONTATO)
)
go

/*==============================================================*/
/* Table: TBVRT039_BANCO                                        */
/*==============================================================*/
create table TBVRT039_BANCO (
   CODIGO_BANCO         int                  not null,
   NUMERO_BANCO         char(3)              null,
   AGENCIA              char(10)             null,
   DIGITO               char(2)              null,
   CODIGO_ENDERECO      int                  null,
   CODIGO_CONTATO       int                  null,
   CODIGO_USUARIO_CADASTRO int                  null,
   DATA_CADASTRO        datetime             null,
   CODIGO_USUARIO_ALTERACAO int                  null,
   DATA_ALTERACAO       datetime             null,
   CODIGO_STATUS        int                  null,
   constraint PK_TBVRT039_BANCO primary key (CODIGO_BANCO)
)
go

/*==============================================================*/
/* Table: TBVRT040_ESTADO_CIVIL                                 */
/*==============================================================*/
create table TBVRT040_ESTADO_CIVIL (
   CODIGO_ESTADO_CIVIL  int                  not null,
   DESCRICAO            nvarchar(80)         null,
   CODIGO_USUARIO_CADASTRO int                  null,
   DATA_CADASTRO        datetime             null,
   CODIGO_USUARIO_ALTERACAO int                  null,
   DATA_ALTERACAO       datetime             null,
   CODIGO_STATUS        int                  null,
   constraint PK_TBVRT040_ESTADO_CIVIL primary key (CODIGO_ESTADO_CIVIL)
)
go

alter table TBVRT001_USUARIOS
   add constraint FK_TBVRT001_TIPO_ACES_TBVRT002 foreign key (CODIGO_TIPO_ACESSO)
      references TBVRT002_TIPO_ACESSO (CODIGO_TIPO_ACESSO)
go

alter table TBVRT006_FUNCIONARIO
   add constraint FK_TBVRT006_CONTATO_F_TBVRT035 foreign key (CODIGO_CONTATO)
      references TBVRT035_CONTATO (CODIGO_CONTATO)
go

alter table TBVRT006_FUNCIONARIO
   add constraint FK_TBVRT006_EMPRESA_F_TBVRT030 foreign key (CODIGO_EMPRESA)
      references TBVRT030_EMPRESA (CODIGO_EMPRESA)
go

alter table TBVRT006_FUNCIONARIO
   add constraint FK_TBVRT006_ENDERECO__TBVRT031 foreign key (CODIGO_ENDERECO)
      references TBVRT031_ENDERECO (CODIGO_ENDERECO)
go

alter table TBVRT006_FUNCIONARIO
   add constraint FK_TBVRT006_ESTADO_CI_TBVRT040 foreign key (CODIGO_ESTADO_CIVIL)
      references TBVRT040_ESTADO_CIVIL (CODIGO_ESTADO_CIVIL)
go

alter table TBVRT007_DOCUMENTO
   add constraint FK_TBVRT007_FUNCIONAR_TBVRT006 foreign key (CODIGO_FUNCIONARIO)
      references TBVRT006_FUNCIONARIO (CODIGO_FUNCIONARIO)
go

alter table TBVRT008_DOCUMENTO_ESTRANGEIRO
   add constraint FK_TBVRT008_FUNCIONAR_TBVRT006 foreign key (CODIGO_FUNCIONARIO)
      references TBVRT006_FUNCIONARIO (CODIGO_FUNCIONARIO)
go

alter table TBVRT009_DOCUMENTO_PIS
   add constraint FK_TBVRT009_BANCO_DOC_TBVRT039 foreign key (CODIGO_BANCO)
      references TBVRT039_BANCO (CODIGO_BANCO)
go

alter table TBVRT009_DOCUMENTO_PIS
   add constraint FK_TBVRT009_ENDERECO_TBVRT031 foreign key (CODIGO_ENDERECO)
      references TBVRT031_ENDERECO (CODIGO_ENDERECO)
go

alter table TBVRT009_DOCUMENTO_PIS
   add constraint FK_TBVRT009_FUNCIONAR_TBVRT006 foreign key (CODIGO_FUNCIONARIO)
      references TBVRT006_FUNCIONARIO (CODIGO_FUNCIONARIO)
go

alter table TBVRT010_DOCUMENTO_FUNDO_GARANTIA
   add constraint FK_TBVRT010_BANCO_DOC_TBVRT039 foreign key (CODIGO_BANCO)
      references TBVRT039_BANCO (CODIGO_BANCO)
go

alter table TBVRT010_DOCUMENTO_FUNDO_GARANTIA
   add constraint FK_TBVRT010_FUNCIONAR_TBVRT006 foreign key (CODIGO_FUNCIONARIO)
      references TBVRT006_FUNCIONARIO (CODIGO_FUNCIONARIO)
go

alter table TBVRT011_DEPENDENTE
   add constraint FK_TBVRT011_FUNCIONAR_TBVRT006 foreign key (COD_DETL_FUNC)
      references TBVRT006_FUNCIONARIO (CODIGO_FUNCIONARIO)
go

alter table TBVRT011_DEPENDENTE
   add constraint FK_TBVRT011_TIPO_BENE_TBVRT012 foreign key (CODIGO_TIPO_BENECIFIO)
      references TBVRT012_TIPO_BENEFICIO (CODIGO_TIPO_BENECIFIO)
go

alter table TBVRT011_DEPENDENTE
   add constraint FK_TBVRT011_TIPO_PARE_TBVRT014 foreign key (CODIGO_TIPO_PARENTESCO)
      references TBVRT014_TIPO_PARENTESCO (CODIGO_TIPO_PARENTESCO)
go

alter table TBVRT012_TIPO_BENEFICIO
   add constraint FK_TBVRT012_CATEGORIA_TBVRT013 foreign key (CODIGO_CATEGORIA_BENEFICIO)
      references TBVRT013_CATEGORIA_BENEFICIO (CODIGO_CATEGORIA_BENEFICIO)
go

alter table TBVRT015_CARACTERISTICA_FISICA
   add constraint FK_TBVRT015_FUNCIONAR_TBVRT006 foreign key (COD_DETL_FUNC)
      references TBVRT006_FUNCIONARIO (CODIGO_FUNCIONARIO)
go

alter table TBVRT015_CARACTERISTICA_FISICA
   add constraint FK_TBVRT015_TIPO_CABE_TBVRT017 foreign key (CODIGO_TIPO_CABELO)
      references TBVRT017_TIPO_CABELO (CODIGO_TIPO_CABELO)
go

alter table TBVRT015_CARACTERISTICA_FISICA
   add constraint FK_TBVRT015_TIPO_COR__TBVRT016 foreign key (CODIGO_TIPO_COR)
      references TBVRT016_TIPO_COR (CODIGO_TIPO_COR)
go

alter table TBVRT015_CARACTERISTICA_FISICA
   add constraint FK_TBVRT015_TIPO_OLHO_TBVRT018 foreign key (CODIGO_TIPO_OLHO)
      references TBVRT018_TIPO_OLHO (CODIGO_TIPO_OLHO)
go

alter table TBVRT019_DADOS_ADMISSAO
   add constraint FK_TBVRT019_FUNCIONAR_TBVRT006 foreign key (COD_DETL_FUNC)
      references TBVRT006_FUNCIONARIO (CODIGO_FUNCIONARIO)
go

alter table TBVRT019_DADOS_ADMISSAO
   add constraint FK_TBVRT019_TIPO_CARG_TBVRT020 foreign key (CODIGO_TIPO_CARGO)
      references TBVRT020_TIPO_CARGO (CODIGO_TIPO_CARGO)
go

alter table TBVRT019_DADOS_ADMISSAO
   add constraint FK_TBVRT019_TIPO_FORM_TBVRT023 foreign key (CODIGO_TIPO_FORMA_PAGAMENTO)
      references TBVRT023_TIPO_FORMA_PAGAMENTO (CODIGO_TIPO_FORMA_PAGAMENTO)
go

alter table TBVRT019_DADOS_ADMISSAO
   add constraint FK_TBVRT019_TIPO_SECA_TBVRT021 foreign key (CODIGO_TIPO_SECAO)
      references TBVRT021_TIPO_SECAO (CODIGO_TIPO_SECAO)
go

alter table TBVRT019_DADOS_ADMISSAO
   add constraint FK_TBVRT019_TIPO_TARE_TBVRT022 foreign key (CODIGO_TIPO_TAREFA)
      references TBVRT022_TIPO_TAREFA (CODIGO_TIPO_TAREFA)
go

alter table TBVRT024_DADOS_DEMISSAO
   add constraint FK_TBVRT024_FUNCIONAR_TBVRT006 foreign key (COD_DETL_FUNC)
      references TBVRT006_FUNCIONARIO (CODIGO_FUNCIONARIO)
go

alter table TBVRT024_DADOS_DEMISSAO
   add constraint FK_TBVRT024_TIPO_CARG_TBVRT020 foreign key (CODIGO_TIPO_CARGO)
      references TBVRT020_TIPO_CARGO (CODIGO_TIPO_CARGO)
go

alter table TBVRT024_DADOS_DEMISSAO
   add constraint FK_TBVRT024_TIPO_FORM_TBVRT023 foreign key (CODIGO_TIPO_FORMA_PAGAMENTO)
      references TBVRT023_TIPO_FORMA_PAGAMENTO (CODIGO_TIPO_FORMA_PAGAMENTO)
go

alter table TBVRT024_DADOS_DEMISSAO
   add constraint FK_TBVRT024_TIPO_SECA_TBVRT021 foreign key (CODIGO_TIPO_SECAO)
      references TBVRT021_TIPO_SECAO (CODIGO_TIPO_SECAO)
go

alter table TBVRT024_DADOS_DEMISSAO
   add constraint FK_TBVRT024_TIPO_TARE_TBVRT022 foreign key (CODIGO_TIPO_TAREFA)
      references TBVRT022_TIPO_TAREFA (CODIGO_TIPO_TAREFA)
go

alter table TBVRT025_FERIAS
   add constraint FK_TBVRT025_FUNCIONAR_TBVRT006 foreign key (COD_DETL_FUNC)
      references TBVRT006_FUNCIONARIO (CODIGO_FUNCIONARIO)
go

alter table TBVRT026_ACIDENTE_TRABALHO
   add constraint FK_TBVRT026_FUNCIONAR_TBVRT006 foreign key (COD_DETL_FUNC)
      references TBVRT006_FUNCIONARIO (CODIGO_FUNCIONARIO)
go

alter table TBVRT027_ALTERACAO_CARGO_SALARIO
   add constraint FK_TBVRT027_FUNCIONAR_TBVRT006 foreign key (COD_DETL_FUNC)
      references TBVRT006_FUNCIONARIO (CODIGO_FUNCIONARIO)
go

alter table TBVRT028_CONTRIBUICAO_SINDICAL
   add constraint FK_TBVRT028_FUNCIONAR_TBVRT006 foreign key (COD_DETL_FUNC)
      references TBVRT006_FUNCIONARIO (CODIGO_FUNCIONARIO)
go

alter table TBVRT028_CONTRIBUICAO_SINDICAL
   add constraint FK_TBVRT028_SINDICATO_TBVRT029 foreign key (CODIGO_SINDICATO)
      references TBVRT029_SINDICATO (CODIGO_SINDICATO)
go

alter table TBVRT030_EMPRESA
   add constraint FK_TBVRT030_CONTATO_E_TBVRT035 foreign key (CODIGO_CONTATO)
      references TBVRT035_CONTATO (CODIGO_CONTATO)
go

alter table TBVRT030_EMPRESA
   add constraint FK_TBVRT030_ENDERECO__TBVRT031 foreign key (CODIGO_ENDERECO)
      references TBVRT031_ENDERECO (CODIGO_ENDERECO)
go

alter table TBVRT032_DETALHE_ENDERECO
   add constraint FK_TBVRT032_ENDERECO__TBVRT031 foreign key (CODIGO_ENDERECO)
      references TBVRT031_ENDERECO (CODIGO_ENDERECO)
go

alter table TBVRT032_DETALHE_ENDERECO
   add constraint FK_TBVRT032_TIPO_ENDE_TBVRT033 foreign key (CODIGO_TIPO_ENDERECO)
      references TBVRT033_TIPO_ENDERECO (CODIGO_TIPO_ENDERECO)
go

alter table TBVRT032_DETALHE_ENDERECO
   add constraint FK_TBVRT032_TIPO_LOGR_TBVRT034 foreign key (CODIGO_TIPO_LOGRADOURO)
      references TBVRT034_TIPO_LOGRADOURO (CODIGO_TIPO_LOGRADOURO)
go

alter table TBVRT036_DETALHE_CONTATO_MAIL
   add constraint FK_TBVRT036_CONTATO_D_TBVRT035 foreign key (CODIGO_CONTATO)
      references TBVRT035_CONTATO (CODIGO_CONTATO)
go

alter table TBVRT036_DETALHE_CONTATO_MAIL
   add constraint FK_TBVRT036_TIPO_CONT_TBVRT038 foreign key (CODIGO_TIPO_CONTATO)
      references TBVRT038_TIPO_CONTATO (CODIGO_TIPO_CONTATO)
go

alter table TBVRT037_DETALHE_CONTATO_TELEFONICO
   add constraint FK_TBVRT037_CONTATO_D_TBVRT035 foreign key (CODIGO_CONTATO)
      references TBVRT035_CONTATO (CODIGO_CONTATO)
go

alter table TBVRT037_DETALHE_CONTATO_TELEFONICO
   add constraint FK_TBVRT037_TIPO_CONT_TBVRT038 foreign key (CODIGO_TIPO_CONTATO)
      references TBVRT038_TIPO_CONTATO (CODIGO_TIPO_CONTATO)
go

alter table TBVRT039_BANCO
   add constraint FK_TBVRT039_CONTATO_B_TBVRT035 foreign key (CODIGO_CONTATO)
      references TBVRT035_CONTATO (CODIGO_CONTATO)
go

