/*
 * Additional function for forms.html
 *	Written by ThemePixels	
 *	http://themepixels.com/
 *
 *	Copyright (c) 2012 ThemePixels (http://themepixels.com)
 *	
 *	Built for Katniss Premium Responsive Admin Template
 *  http://themeforest.net/category/site-templates/admin-templates
 */

jQuery(document).ready(function () {


    //Mascaras Campos
    //CEP
    jQuery(".CEP").mask("99999-999");
    //Telefone Fixo e Celular fora de São Paulo
    jQuery(".Tel8").mask("9999-9999");
    //Celular em São Paulo
    jQuery(".Tel9").mask("99999-9999");
    //CPF
    jQuery(".CPF").mask("999.999.999-99");
    //CNPJ
    jQuery(".CNPJ").mask("99.999.999/9999-99");

    //Data dataddmmaaaa
    jQuery(".dataddmmaaaa").mask("99/99/9999");

    //Altura
    jQuery(".Altura").mask("9.99");

    //Peso
    jQuery(".Peso").mask("999.999");

    //Monetario
    jQuery(".Monetario").maskMoney({
        symbol: 'R$ ',
        showSymbol: true, thousands: '.', decimal: ',', symbolStay: true
    });



    // Data com opção de Filtro de Mes e Ano
    jQuery(".txtDataFilMesAno").datepicker({
        dateFormat: 'dd/mm/yy',
        changeMonth: true,
        changeYear: true,
        yearRange: '-100y:c+nn',
        maxDate: '-1d'
    });

    // Data com opção de Filtro de Mes e Ano
    jQuery(".txtDataFilMes").datepicker({
        dateFormat: 'dd/mm',
        changeMonth: true,
        changeYear: false,
        yearRange: '-100y:c+nn',
        maxDate: '-1d'
    });

    var passoAtivo;

    // Data Padrão
    jQuery(".DataPadrao").datepicker();

    //Horario
    jQuery('.horario').timepicker();


    // Select with Search
    jQuery(".chzn-select").chosen();


    // Spinner
    jQuery("#txtQtdFilhos").spinner({ min: 0, max: 100, increment: 2 });


    //jQuery('#wizard3').smartWizard({ onFinish: onFinishCallback });
    jQuery('#wizard3').smartWizard({ transitionEffect: 'slideleft', onLeaveStep: leaveAStepCallback, onFinish: onFinishCallback });

    function onFinishCallback() {
        finalizar();
        if (validateAllSteps()) {
            alert('Finish Clicked');

        }
    }

    function leaveAStepCallback(obj) {
        passoAtivo = obj.attr('rel');
        return validarFuncionario(passoAtivo);
    }
    //ddlNacionalidadeFuncionario

    jQuery("#ddlNacionalidadeFuncionario").change(function () {
        //alert(jQuery("#ddlNacionalidadeFuncionario option:selected").text());
        var nacionalidade = jQuery("#ddlNacionalidadeFuncionario option:selected").text();

        if (nacionalidade == "Brasil") {
            jQuery('.divBrasil').show();
            jQuery('.divEstrangeiro').hide();
        }
        else {
            //divBrasil
            //divEstrangeiro
            jQuery('.divBrasil').hide();
            jQuery('.divEstrangeiro').show();
        }
    });

    jQuery.fn.scrollView = function () {
        return this.each(function () {
            jQuery('html, body').animate({
                scrollTop: jQuery(this).offset().top
            }, 1000);
        });
    }

    jQuery('.buttonNext').click(function (event) {
        event.preventDefault();
        jQuery('#wizard3').scrollView();
    });

    jQuery('.buttonPrevious').click(function (event) {
        event.preventDefault();
        jQuery('#wizard3').scrollView();
    });


    //buttonNext

    //jQuery('input:checkbox').uniform();


    //btnBuscarCEP

    jQuery('#btnBuscarCEP').click(function (event) {

        var cep = jQuery('#txtCEP').val();

        jQuery.ajax({
            type: "GET",
            crossDomain: true,
            url: "../../Handler/BuscarCep.ashx?txtCEP=" + cep,
            contentType: "json",
            cache: false,
            success: function (data) {


                var arrCEP = eval(data);

                jQuery('#txtBairro').val(arrCEP[0].Bairro)
                jQuery('#txtLogradouro').val(arrCEP[0].Logradouro)

                jQuery('#ddlTipoLogradouro option:selected').removeAttr('selected');

                jQuery("#ddlTipoLogradouro option[value='131']").attr('selected', 'selected');

            },
            error: function (XMLHttpRequest, textStatus, errorThrow) {
                errorAjax(textStatus);
                alert(textStatus);
            }
        });
    });

});

/*
    txtNumeroOrdemMatricula
    txtNumeroMatricula
    txtNomeFuncionario
    txtDataNascimento
    ddlNacionalidadeFuncionario
    ddlEstadoCivil
    txtNomeConjuge
    txtQtdFilhos
    
    ddlTipoEndereco
    ddlTipoLogradouro
    txtLogradouro
    txtNumeroEndereco
    txtBairro
    txtComplemento
    txtCEP

    txtNomePai
    ddlNacionalidadePai
    txtNomeMae
    ddlNacionalidadeMae
    */

function validarFuncionario(passoAtivo) {
    var retorno = true;

    //Validar Dados Pessoais
    if (passoAtivo == 1) {

        var NumeroOrdemMatricula = jQuery('#txtNumeroOrdemMatricula').val();
        var NumeroMatricula = jQuery('#txtNumeroMatricula').val();
        var NomeFuncionario = jQuery('#txtNomeFuncionario').val();
        var DataNascimento = jQuery('#txtDataNascimento').val();
        var NacionalidadeFuncionario = jQuery('#ddlNacionalidadeFuncionario option:selected').text();
        var EstadoCivil = jQuery('#ddlEstadoCivil  option:selected').text();
        var NomeConjuge = jQuery('#txtNomeConjuge').val();

        var matchdata = new RegExp(/((0[1-9]|[12][0-9]|3[01])\/(0[13578]|1[02])\/[12][0-9]{3})|((0[1-9]|[12][0-9]|30)\/(0[469]|11)\/[12][0-9]{3})|((0[1-9]|1[0-9]|2[0-8])\/02\/[12][0-9]([02468][1235679]|[13579][01345789]))|((0[1-9]|[12][0-9])\/02\/[12][0-9]([02468][048]|[13579][26]))/gi);



        if (!NumeroOrdemMatricula && NumeroOrdemMatricula.length <= 0) {
            jQuery('#msgNumeroOrdemMatricula').html('O Campo Numero Ordem Matricula Deve ser preenchido').show();
            jQuery("#validaNumeroOrdemMatricula").removeClass("par control-group success").addClass("par control-group error");
            retorno = false;
        }
        else {
            jQuery('#msgNumeroOrdemMatricula').html('').hide();
            jQuery("#validaNumeroOrdemMatricula").removeClass("par control-group error").addClass("par control-group success");
        }

        if (!NumeroMatricula && NumeroMatricula.length <= 0) {
            jQuery('#msgNumeroMatricula').html('O Campo Numero Matricula Deve ser preenchido').show();
            jQuery("#validaNumeroMatricula").removeClass("par control-group success").addClass("par control-group error");
            retorno = false;
        }
        else {
            jQuery('#msgNumeroMatricula').html('').hide();
            jQuery("#validaNumeroMatricula").removeClass("par control-group error").addClass("par control-group success");
        }

        if (!NomeFuncionario && NomeFuncionario.length <= 0) {
            jQuery('#msgNomeFuncionario').html('O Campo Nome Funcionario Deve ser preenchido').show();
            jQuery("#validaNomeFuncionario").removeClass("par control-group success").addClass("par control-group error");
            retorno = false;
        }
        else {
            jQuery('#msgNomeFuncionario').html('').hide();
            jQuery("#validaNomeFuncionario").removeClass("par control-group error").addClass("par control-group success");
        }

        if (!DataNascimento && DataNascimento.length <= 0) {
            jQuery('#msgDataNascimento').html('O Campo Data de Nascimento Deve ser preenchido').show();
            jQuery("#validaDataNascimento").removeClass("par control-group success").addClass("par control-group error");
            retorno = false;
        }
        else {
            if (!DataNascimento.match(matchdata)) {
                jQuery('#msgDataNascimento').html('O Campo Data de Nascimento Deve ser preenchido Corretamente').show();
                jQuery("#validaDataNascimento").removeClass("par control-group success").addClass("par control-group error");
                retorno = false;
            }
            else {
                jQuery('#msgDataNascimento').html('').hide();
                jQuery("#validaDataNascimento").removeClass("par control-group error").addClass("par control-group success");
            }
        }

        if (NacionalidadeFuncionario == 'Selecionar') {
            jQuery('#msgNacionalidadeFuncionario').html('O Campo Nacionalidade Deve ser Selecionado um Item').show();
            jQuery("#validaNacionalidadeFuncionario").removeClass("par control-group success").addClass("par control-group error");
            retorno = false;
        }
        else {
            jQuery('#msgNacionalidadeFuncionario').html('').hide();
            jQuery("#validaNacionalidadeFuncionario").removeClass("par control-group error").addClass("par control-group success");
        }

        if (EstadoCivil == 'Selecionar') {
            jQuery('#msgEstadoCivil').html('O Campo Estado Civi Deve ser Selecionado um Item').show();
            jQuery("#validaEstadoCivil").removeClass("par control-group success").addClass("par control-group error");
            retorno = false;
        }
        else {
            jQuery('#msgEstadoCivil').html('').hide();
            jQuery("#validaEstadoCivil").removeClass("par control-group error").addClass("par control-group success");
        }

        if (EstadoCivil == 'Casado(a)') {
            if (!NomeConjuge && NomeConjuge.length <= 0) {
                jQuery('#msgNomeConjuge').html('O Campo Nome do Conjuge Deve ser preenchido').show();
                jQuery("#validaNomeConjuge").removeClass("par control-group success").addClass("par control-group error");
                retorno = false;
            }
            else {
                jQuery('#msgNomeConjuge').html('').hide();
                jQuery("#validaNomeConjuge").removeClass("par control-group error").addClass("par control-group success");
            }
        }

        return retorno;
    }

    // Validar Endereço
    if (passoAtivo == 2) {

        var TipoEndereco = jQuery('#ddlTipoEndereco option:selected').text();
        var TipoLogradouro = jQuery('#ddlTipoLogradouro option:selected').text();
        var Logradouro = jQuery('#txtLogradouro').val();
        var NumeroEndereco = jQuery('#txtNumeroEndereco').val();
        var Bairro = jQuery('#txtBairro').val();
        var Complemento = jQuery('#txtComplemento').val();
        var CEP = jQuery('#txtCEP').val();


        if (TipoEndereco == 'Selecionar') {
            jQuery('#msgTipoEndereco').html('O Campo Tipo de Endereço Deve ser Selecionado um Item').show();
            jQuery("#validaTipoEndereco").removeClass("par control-group success").addClass("par control-group error");
            retorno = false;
        }
        else {
            jQuery('#msgTipoEndereco').html('').hide();
            jQuery("#validaTipoEndereco").removeClass("par control-group error").addClass("par control-group success");
        }

        if (TipoLogradouro == 'Selecionar') {
            jQuery('#msgTipoLogradouro').html('O Campo Tipo de logradouro Deve ser Selecionado um Item').show();
            jQuery("#validaTipoLogradouro").removeClass("par control-group success").addClass("par control-group error");
            retorno = false;
        }
        else {
            jQuery('#msgTipoLogradouro').html('').hide();
            jQuery("#validaTipoLogradouro").removeClass("par control-group error").addClass("par control-group success");
        }

        if (!Logradouro && Logradouro.length <= 0) {
            jQuery('#msgLogradouro').html('O Campo Logradouro Deve ser preenchido').show();
            jQuery("#validaLogradouro").removeClass("par control-group success").addClass("par control-group error");
            retorno = false;
        }
        else {
            jQuery('#msgLogradouro').html('').hide();
            jQuery("#validaLogradouro").removeClass("par control-group error").addClass("par control-group success");
        }

        if (!NumeroEndereco && NumeroEndereco.length <= 0) {
            jQuery('#msgNumeroEndereco').html('O Campo Numero Deve ser preenchido').show();
            jQuery("#validaNumeroEndereco").removeClass("par control-group success").addClass("par control-group error");
            retorno = false;
        }
        else {
            jQuery('#msgNumeroEndereco').html('').hide();
            jQuery("#validaNumeroEndereco").removeClass("par control-group error").addClass("par control-group success");
        }

        if (!Bairro && Bairro.length <= 0) {
            jQuery('#msgBairro').html('O Campo Bairro Deve ser preenchido').show();
            jQuery("#validaBairro").removeClass("par control-group success").addClass("par control-group error");
            retorno = false;
        }
        else {
            jQuery('#msgBairro').html('').hide();
            jQuery("#validaBairro").removeClass("par control-group error").addClass("par control-group success");
        }

        return retorno;
    }

    // Validar Endereço
    if (passoAtivo == 3) {

        var NomePai = jQuery('#txtNomePai').val();
        var NacionalidadePai = jQuery('#ddlNacionalidadePai option:selected').text();
        var NomeMae = jQuery('#txtNomeMae').val();
        var NacionalidadeMae = jQuery('#ddlNacionalidadeMae option:selected').text();

        if (!NomePai && NomePai.length <= 0) {
            jQuery('#msgNomePai').html('O Campo Bairro Deve ser preenchido').show();
            jQuery("#validaNomePai").removeClass("par control-group success").addClass("par control-group error");
            retorno = false;
        }
        else {
            jQuery('#msgNomePai').html('').hide();
            jQuery("#validaNomePai").removeClass("par control-group error").addClass("par control-group success");

            if (NacionalidadePai == 'Selecionar') {
                jQuery('#msgNacionalidadePai').html('O Campo Nacionalidade do Pai Deve ser Selecionado um Item').show();
                jQuery("#validaNacionalidadePai").removeClass("par control-group success").addClass("par control-group error");
                retorno = false;
            }
            else {
                jQuery('#msgNacionalidadePai').html('').hide();
                jQuery("#validaNacionalidadePai").removeClass("par control-group error").addClass("par control-group success");
            }
        }

        if (!NomeMae && NomeMae.length <= 0) {
            jQuery('#msgNomeMae').html('O Campo Bairro Deve ser preenchido').show();
            jQuery("#validaNomeMae").removeClass("par control-group success").addClass("par control-group error");
            retorno = false;
        }
        else {
            jQuery('#msgNomeMae').html('').hide();
            jQuery("#validaNomeMae").removeClass("par control-group error").addClass("par control-group success");

            if (NacionalidadeMae == 'Selecionar') {
                jQuery('#msgNacionalidadeMae').html('O Campo Nacionalidade Mãe Deve ser Selecionado um Item').show();
                jQuery("#validaNacionalidadeMae").removeClass("par control-group success").addClass("par control-group error");
                retorno = false;
            }
            else {
                jQuery('#msgNacionalidadeMae').html('').hide();
                jQuery("#validaNacionalidadeMae").removeClass("par control-group error").addClass("par control-group success");
            }
        }

        return retorno;
    }

    // Validar Documentos Pessoais
    if (passoAtivo == 4) {

        var nacionalidade = jQuery("#ddlNacionalidadeFuncionario option:selected").text();

        if (nacionalidade == "Brasil") {

            var RG = jQuery('#txtRG').val();
            var CarteiraTrabalho = jQuery('#txtCarteiraTrabalho').val();
            var NumeroSerie = jQuery('#txtNumeroSerie').val();
            var NumeroCertificadoReservista = jQuery('#txtNumeroCertificadoReservista').val();
            var Categoria = jQuery('#txtCategoria').val();
            var CPF = jQuery('#txtCPF').val();
            var TituloEleitor = jQuery('#txtTituloEleitor').val();
            var CateiraSaude = jQuery('#txtCateiraSaude').val();

            if (!RG && RG.length <= 0) {
                jQuery('#msgRG').html('O Campo RG Deve ser preenchido').show();
                jQuery("#validaRG").removeClass("par control-group success").addClass("par control-group error");
                retorno = false;
            }
            else {
                jQuery('#msgRG').html('').hide();
                jQuery("#validaRG").removeClass("par control-group error").addClass("par control-group success");
            }

            if (!CarteiraTrabalho && CarteiraTrabalho.length <= 0) {
                jQuery('#msgCarteiraTrabalho').html('O Campo CarteiraTrabalho Deve ser preenchido').show();
                jQuery("#validaCarteiraTrabalho").removeClass("par control-group success").addClass("par control-group error");
                retorno = false;
            }
            else {
                jQuery('#msgCarteiraTrabalho').html('').hide();
                jQuery("#validaCarteiraTrabalho").removeClass("par control-group error").addClass("par control-group success");
            }

            if (!NumeroSerie && NumeroSerie.length <= 0) {
                jQuery('#msgNumeroSerie').html('O Campo NumeroSerie Deve ser preenchido').show();
                jQuery("#validaNumeroSerie").removeClass("par control-group success").addClass("par control-group error");
                retorno = false;
            }
            else {
                jQuery('#msgNumeroSerie').html('').hide();
                jQuery("#validaNumeroSerie").removeClass("par control-group error").addClass("par control-group success");
            }

            if (!NumeroCertificadoReservista && NumeroCertificadoReservista.length <= 0) {
                jQuery('#msgNumeroCertificadoReservista').html('O Campo NumeroCertificadoReservista Deve ser preenchido').show();
                jQuery("#validaNumeroCertificadoReservista").removeClass("par control-group success").addClass("par control-group error");
                retorno = false;
            }
            else {
                jQuery('#msgNumeroCertificadoReservista').html('').hide();
                jQuery("#validaNumeroCertificadoReservista").removeClass("par control-group error").addClass("par control-group success");
            }

            if (!Categoria && Categoria.length <= 0) {
                jQuery('#msgCategoria').html('O Campo Categoria Deve ser preenchido').show();
                jQuery("#validaCategoria").removeClass("par control-group success").addClass("par control-group error");
                retorno = false;
            }
            else {
                jQuery('#msgCategoria').html('').hide();
                jQuery("#validaCategoria").removeClass("par control-group error").addClass("par control-group success");
            }

            if (!CPF && CPF.length <= 0) {
                jQuery('#msgCPF').html('O Campo CPF Deve ser preenchido').show();
                jQuery("#validaCPF").removeClass("par control-group success").addClass("par control-group error");
                retorno = false;
            }
            else {
                jQuery('#msgCPF').html('').hide();
                jQuery("#validaCPF").removeClass("par control-group error").addClass("par control-group success");
            }

            if (!TituloEleitor && TituloEleitor.length <= 0) {
                jQuery('#msgTituloEleitor').html('O Campo TituloEleitor Deve ser preenchido').show();
                jQuery("#validaTituloEleitor").removeClass("par control-group success").addClass("par control-group error");
                retorno = false;
            }
            else {
                jQuery('#msgTituloEleitor').html('').hide();
                jQuery("#validaTituloEleitor").removeClass("par control-group error").addClass("par control-group success");
            }

            if (!CateiraSaude && CateiraSaude.length <= 0) {
                jQuery('#msgCateiraSaude').html('O Campo CateiraSaude Deve ser preenchido').show();
                jQuery("#validaCateiraSaude").removeClass("par control-group success").addClass("par control-group error");
                retorno = false;
            }
            else {
                jQuery('#msgCateiraSaude').html('').hide();
                jQuery("#validaCateiraSaude").removeClass("par control-group error").addClass("par control-group success");
            }

        }
        else {

            var CBO = jQuery('#txtCBO').val();
            var Carteira19 = jQuery('#txtCarteira19').val();
            var RegistroGeral = jQuery('#txtRegistroGeral').val();
            var CasadoBrasileiro = jQuery('input[name$=rdbCasadoBrasileiro]:checked').val();
            var Naturalizado = jQuery('input[name$=rblNaturalizado]:checked').val();
            var FilhoBrasileiro = jQuery('input[name$=rblFilhoBrasileiro]:checked').val();
            var DataChegadaBrasil = jQuery('#txtDataChegadaBrasil').val();

            if (!CBO && CBO.length <= 0) {
                jQuery('#msgCBO').html('O Campo CBO Deve ser preenchido').show();
                jQuery("#validaCBO").removeClass("par control-group success").addClass("par control-group error");
                retorno = false;
            }
            else {
                jQuery('#msgCBO').html('').hide();
                jQuery("#validaCBO").removeClass("par control-group error").addClass("par control-group success");
            }

            if (!Carteira19 && Carteira19.length <= 0) {
                jQuery('#msgCarteira19').html('O Campo Carteira19 Deve ser preenchido').show();
                jQuery("#validaCarteira19").removeClass("par control-group success").addClass("par control-group error");
                retorno = false;
            }
            else {
                jQuery('#msgCarteira19').html('').hide();
                jQuery("#validaCarteira19").removeClass("par control-group error").addClass("par control-group success");
            }

            if (!RegistroGeral && RegistroGeral.length <= 0) {
                jQuery('#msgRegistroGeral').html('O Campo RegistroGeral Deve ser preenchido').show();
                jQuery("#validaRegistroGeral").removeClass("par control-group success").addClass("par control-group error");
                retorno = false;
            }
            else {
                jQuery('#msgRegistroGeral').html('').hide();
                jQuery("#validaRegistroGeral").removeClass("par control-group error").addClass("par control-group success");
            }

            if (!DataChegadaBrasil && DataChegadaBrasil.length <= 0) {
                jQuery('#msgDataChegadaBrasil').html('O Campo DataChegadaBrasil Deve ser preenchido').show();
                jQuery("#validaDataChegadaBrasil").removeClass("par control-group success").addClass("par control-group error");
                retorno = false;
            }
            else {
                jQuery('#msgDataChegadaBrasil').html('').hide();
                jQuery("#validaDataChegadaBrasil").removeClass("par control-group error").addClass("par control-group success");
            }

        }

        return retorno;
    }

    // Validar Documentos PIS
    if (passoAtivo == 5) {



        return retorno;
    }
    /*
    
    txtCadastroPIS
    txtSobNumero
    txtBancoPIS
    txtAgencia
    txtDigito
    txtTipoEnderecoPIS
    ddlTipoLogradouroPIS
    txtLogradouroPIS
    txtNumeroEnredecoPIS
    txtBairroPIS
    txtComplementoPIS
    txtCEPPIS

    var CadastroPIS
    var SobNumero
    var BancoPIS
    var Agencia
    var Digito
    var TipoEnderecoPIS
    var TipoLogradouroPIS
    var LogradouroPIS
    var NumeroEnredecoPIS
    var BairroPIS
    var ComplementoPIS
    var CEPPIS


    rdpOptanteFGTS
    txtDataOpcao
    txtDataRetratacao
    txtBancoFGTS
    txtAgenciaFGTS
    txtDigitoFGTS

    var OptanteFGTS
    var DataOpcao
    var DataRetratacao
    var BancoFGTS
    var AgenciaFGTS
    var DigitoFGTS


   


    */
}


function IncluirDadosFuncionario() {

    jQuery.ajax({
        type: "GET",
        url: "",
        data: {
            txtNumeroOrdemMatricula: txtNumeroOrdemMatricula,
            txtNumeroMatricula: txtNumeroMatricula,
            txtNomePai: txtNomePai,
            ddlNacionalidadePai: ddlNacionalidadePai,
            txtNomeMae: txtNomeMae,
            ddlNacionalidadeMae: ddlNacionalidadeMae,
            txtDataNascimento: txtDataNascimento,
            ddlNacionalidadeFuncionario: ddlNacionalidadeFuncionario,
            ddlEstadoCivil: ddlEstadoCivil,
            txtNomeConjuge: txtNomeConjuge,
            txtQtdFilhos: txtQtdFilhos,
            ddlTipoEndereco: ddlTipoEndereco,
            ddlTipoLogradouro: ddlTipoLogradouro,
            txtLogradouro: txtLogradouro,
            txtNumeroEndereco: txtNumeroEndereco,
            txtBairro: txtBairro,
            txtComplemento: txtComplemento,
            txtCEP: txtCEP
        },
        contentType: "json",
        cache: false,
        success: function (data) {
            alert(data);

            for (var i = 0; i < data.le; i++) {
                //data[i].atributo
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrow) {
            errorAjax(textStatus);
        }
    });

}

