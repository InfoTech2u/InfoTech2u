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




    jQuery("#txtCarteiraTrabalho").mask("99999");

    jQuery("#txtNumeroSerie").mask("99999-aa");

    //RA RESERVISTA
    jQuery("#txtNumeroCertificadoReservista").mask("999999999999");

    //Titulo de Eleitor
    jQuery("#txtTituloEleitor").mask("999999999999");

    //Carteira de Saude
    jQuery("#txtCateiraSaude").mask("99999999999 9999");

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
    var verificaValidacao;

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
        if (verificaValidacao) {
            IncluirDadosFuncionario();
            //alert('Finish Clicked');

        }
    }

    function leaveAStepCallback(obj) {
        passoAtivo = obj.attr('rel');
        verificaValidacao = validarFuncionario(passoAtivo);
        return verificaValidacao;
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


    jQuery("#ddlEstadoFuncionario").change(function () {
        var str = "";

        str += jQuery("#ddlEstadoFuncionario option:selected").val();

        jQuery('#spCidadeFuncionario').empty();

        jQuery('#spCidadeFuncionario').append('<select id ="ddlCidadeFuncionario" data-placeholder="Escolha uma Cidade..." Style="width: 350px"  TabIndex="2">');
        
        CarregaComboCidade(str, 1);

    });

    jQuery("#ddlEstadoPIS").change(function () {
        var str = "";

        str += jQuery("#ddlEstadoPIS option:selected").val();

        jQuery('#spCidadePIS').empty();

        jQuery('#spCidadePIS').append('<select id ="ddlCidadePIS" data-placeholder="Escolha uma Cidade..." Style="width: 350px"  TabIndex="2">');

        CarregaComboCidade(str, 2);

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

                jQuery('#txtBairro').val(arrCEP[0].Bairro);
                jQuery('#txtLogradouro').val(arrCEP[0].Logradouro);

                //Cidade
                //Uf

                jQuery('#ddlTipoLogradouro option:selected').removeAttr('selected');

                jQuery("#ddlTipoLogradouro").each(function () {
                    jQuery('option', this).each(function () {
                        if (jQuery(this).text().toLowerCase() == arrCEP[0].Tipo_logradouro.toLowerCase()) {
                            jQuery(this).attr('selected', 'selected')
                        };
                    });
                });

                jQuery('#ddlTipoLogradouro_chzn .chzn-single span').text(arrCEP[0].Tipo_logradouro);

                //Estado
                jQuery('#ddlEstadoFuncionario option:selected').removeAttr('selected');

                jQuery("#ddlEstadoFuncionario").each(function () {
                    jQuery('option', this).each(function () {

                        if (jQuery(this).text().toLowerCase() == jQuery('#ddlEstadoFuncionario option').filter(function () { return jQuery(this).html() == arrCEP[0].Uf; }).text().toLowerCase()) {
                            jQuery(this).attr('selected', 'selected')
                        };

                    });
                });

                jQuery('#ddlEstadoFuncionario_chzn .chzn-single span').text(arrCEP[0].Uf);


                //Cidade
                var str = "";
                str += jQuery("#ddlEstadoFuncionario option:selected").val();
                jQuery('#spCidadeFuncionario').empty();
                jQuery('#spCidadeFuncionario').append('<select id ="ddlCidadeFuncionario" data-placeholder="Escolha uma Cidade..." Style="width: 350px"  TabIndex="2">');
                CarregaComboCidade(str, 1);

                
                jQuery('#ddlCidadeFuncionario option:selected').removeAttr('selected');

                //alert(arrCEP[0].Cidade);

                jQuery(jQuery('#ddlCidadeFuncionario option').filter(function () { return jQuery(this).html() == arrCEP[0].Cidade }).text()).attr('selected', 'selected');

                jQuery("#ddlCidadeFuncionario").each(function () {

                    alert('3');

                    

                    jQuery('option', this).each(function () {

                        alert('4');

                        alert(jQuery(this).text().toLowerCase());
                        alert(jQuery('#ddlCidadeFuncionario option').filter(function () { return jQuery(this).html() == arrCEP[0].Cidade; }).text().toLowerCase());

                        if (jQuery(this).text().toLowerCase() == jQuery('#ddlCidadeFuncionario option').filter(function () { return jQuery(this).html() == arrCEP[0].Cidade }).text().toLowerCase()) {
                            jQuery(this).attr('selected', 'selected')
                        };
                    });
                });

                jQuery('#ddlCidadeFuncionario_chzn .chzn-single span').text(arrCEP[0].Cidade);

                alert('1');
                

            },
            error: function (XMLHttpRequest, textStatus, errorThrow) {
                errorAjax(textStatus);
                alert(textStatus);
            }
        });
    });

    jQuery('#btnBuscarCEPPIS').click(function (event) {

        var cep = jQuery('#txtCEPPIS').val();

        jQuery.ajax({
            type: "GET",
            crossDomain: true,
            url: "../../Handler/BuscarCep.ashx?txtCEP=" + cep,
            contentType: "json",
            cache: false,
            success: function (data) {


                var arrCEP = eval(data);

                jQuery('#txtBairroPIS').val(arrCEP[0].Bairro);
                jQuery('#txtLogradouroPIS').val(arrCEP[0].Logradouro);

                jQuery('#ddlTipoLogradouroPIS option:selected').removeAttr('selected');

                jQuery("#ddlTipoLogradouroPIS").each(function () {
                    jQuery('option', this).each(function () {
                        if (jQuery(this).text().toLowerCase() == arrCEP[0].Tipo_logradouro.toLowerCase()) {
                            jQuery(this).attr('selected', 'selected')
                        };
                    });
                });

                jQuery('#ddlTipoLogradouroPIS_chzn .chzn-single span').text(arrCEP[0].Tipo_logradouro);



            },
            error: function (XMLHttpRequest, textStatus, errorThrow) {
                errorAjax(textStatus);
                alert(textStatus);
            }
        });
    });

});

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
        var CidadeFuncionario = jQuery('#ddlCidadeFuncionario option:selected').text();
        var EstadoFuncionario = jQuery('#ddlEstadoFuncionario option:selected').text();
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
                if (validarCPF(CPF)) {
                    jQuery('#msgCPF').html('').hide();
                    jQuery("#validaCPF").removeClass("par control-group error").addClass("par control-group success");
                }
                else {
                    jQuery('#msgCPF').html('O Campo CPF Deve ser preenchido co um valor valido').show();
                    jQuery("#validaCPF").removeClass("par control-group success").addClass("par control-group error");
                    retorno = false;
                }
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

        var CadastroPIS = jQuery('#txtCadastroPIS').val();
        var SobNumero = jQuery('#txtSobNumero').val();
        var BancoPIS = jQuery('#txtBancoPIS').val();
        var Agencia = jQuery('#txtAgencia').val();
        var Digito = jQuery('#txtDigito').val();
        var TipoEnderecoPIS = jQuery('#ddlTipoEnderecoPIS').val();
        var TipoLogradouroPIS = jQuery('#ddlTipoLogradouroPIS').val();
        var CidadePIS = jQuery('#ddlCidadePIS option:selected').text();
        var EstadoPIS = jQuery('#ddlEstadoPIS option:selected').text();
        var LogradouroPIS = jQuery('#txtLogradouroPIS').val();
        var NumeroEnderecoPIS = jQuery('#txtNumeroEnderecoPIS').val();
        var BairroPIS = jQuery('#txtBairroPIS').val();
        var ComplementoPIS = jQuery('#txtComplementoPIS').val();
        var CEPPIS = jQuery('#txtCEPPIS').val();

        if (!CadastroPIS && CadastroPIS.length <= 0) {
            jQuery('#msgCadastroPIS').html('O Campo CadastroPIS Deve ser preenchido').show();
            jQuery("#validaCadastroPIS").removeClass("par control-group success").addClass("par control-group error");
            retorno = false;
        }
        else {
            jQuery('#msgCadastroPIS').html('').hide();
            jQuery("#validaCadastroPIS").removeClass("par control-group error").addClass("par control-group success");
        }

        if (!SobNumero && SobNumero.length <= 0) {
            jQuery('#msgSobNumero').html('O Campo SobNumero Deve ser preenchido').show();
            jQuery("#validaSobNumero").removeClass("par control-group success").addClass("par control-group error");
            retorno = false;
        }
        else {
            jQuery('#msgSobNumero').html('').hide();
            jQuery("#validaSobNumero").removeClass("par control-group error").addClass("par control-group success");
        }

        if (!BancoPIS && BancoPIS.length <= 0) {
            jQuery('#msgBancoPIS').html('O Campo BancoPIS Deve ser preenchido').show();
            jQuery("#validaBancoPIS").removeClass("par control-group success").addClass("par control-group error");
            retorno = false;
        }
        else {
            jQuery('#msgBancoPIS').html('').hide();
            jQuery("#validaBancoPIS").removeClass("par control-group error").addClass("par control-group success");
        }

        if (!Agencia && Agencia.length <= 0) {
            jQuery('#msgAgencia').html('O Campo Agencia Deve ser preenchido').show();
            jQuery("#validaAgencia").removeClass("par control-group success").addClass("par control-group error");
            retorno = false;
        }
        else {
            jQuery('#msgAgencia').html('').hide();
            jQuery("#validaAgencia").removeClass("par control-group error").addClass("par control-group success");
        }

        if (!Digito && Digito.length <= 0) {
            jQuery('#msgDigito').html('O Campo Digito Deve ser preenchido').show();
            jQuery("#validaDigito").removeClass("par control-group success").addClass("par control-group error");
            retorno = false;
        }
        else {
            jQuery('#msgDigito').html('').hide();
            jQuery("#validaDigito").removeClass("par control-group error").addClass("par control-group success");
        }

        if (TipoEnderecoPIS == 'Selecionar') {
            jQuery('#msgTipoEnderecoPIS').html('O Campo Tipo de Endereço Deve ser Selecionado um Item').show();
            jQuery("#validaTipoEnderecoPIS").removeClass("par control-group success").addClass("par control-group error");
            retorno = false;
        }
        else {
            jQuery('#msgTipoEnderecoPIS').html('').hide();
            jQuery("#validaTipoEnderecoPIS").removeClass("par control-group error").addClass("par control-group success");
        }

        if (TipoLogradouroPIS == 'Selecionar') {
            jQuery('#msgTipoLogradouroPIS').html('O Campo Tipo de LogradouroPIS Deve ser Selecionado um Item').show();
            jQuery("#validaTipoLogradouroPIS").removeClass("par control-group success").addClass("par control-group error");
            retorno = false;
        }
        else {
            jQuery('#msgTipoLogradouroPIS').html('').hide();
            jQuery("#validaTipoLogradouroPIS").removeClass("par control-group error").addClass("par control-group success");
        }

        if (!LogradouroPIS && LogradouroPIS.length <= 0) {
            jQuery('#msgLogradouroPIS').html('O Campo LogradouroPIS Deve ser preenchido').show();
            jQuery("#validaLogradouroPIS").removeClass("par control-group success").addClass("par control-group error");
            retorno = false;
        }
        else {
            jQuery('#msgLogradouroPIS').html('').hide();
            jQuery("#validaLogradouroPIS").removeClass("par control-group error").addClass("par control-group success");
        }

        if (!NumeroEnderecoPIS && NumeroEnderecoPIS.length <= 0) {
            jQuery('#msgNumeroEnderecoPIS').html('O Campo Numero Deve ser preenchido').show();
            jQuery("#validaNumeroEnderecoPIS").removeClass("par control-group success").addClass("par control-group error");
            retorno = false;
        }
        else {
            jQuery('#msgNumeroEnderecoPIS').html('').hide();
            jQuery("#validaNumeroEnderecoPIS").removeClass("par control-group error").addClass("par control-group success");
        }

        if (!BairroPIS && BairroPIS.length <= 0) {
            jQuery('#msgBairroPIS').html('O Campo BairroPIS Deve ser preenchido').show();
            jQuery("#validaBairroPIS").removeClass("par control-group success").addClass("par control-group error");
            retorno = false;
        }
        else {
            jQuery('#msgBairroPIS').html('').hide();
            jQuery("#validaBairroPIS").removeClass("par control-group error").addClass("par control-group success");
        }



        return retorno;
    }

    // Validar Documentos Fundo de Garantia
    if (passoAtivo == 6) {

        var OptanteFGTS = jQuery('#rdpOptanteFGTS').val();
        var DataOpcao = jQuery('#txtDataOpcao').val();
        var DataRetratacao = jQuery('#txtDataRetratacao').val();
        var BancoFGTS = jQuery('#txtBancoFGTS').val();
        var AgenciaFGTS = jQuery('#txtAgenciaFGTS').val();
        var DigitoFGTS = jQuery('#txtDigitoFGTS').val();

        if (!DataOpcao && DataOpcao.length <= 0) {
            jQuery('#msgDataOpcao').html('O Campo DataOpcao Deve ser preenchido').show();
            jQuery("#validaDataOpcao").removeClass("par control-group success").addClass("par control-group error");
            retorno = false;
        }
        else {
            jQuery('#msgDataOpcao').html('').hide();
            jQuery("#validaDataOpcao").removeClass("par control-group error").addClass("par control-group success");
        }

        if (!BancoFGTS && BancoFGTS.length <= 0) {
            jQuery('#msgBancoFGTS').html('O Campo BancoFGTS Deve ser preenchido').show();
            jQuery("#validaBancoFGTS").removeClass("par control-group success").addClass("par control-group error");
            retorno = false;
        }
        else {
            jQuery('#msgBancoFGTS').html('').hide();
            jQuery("#validaBancoFGTS").removeClass("par control-group error").addClass("par control-group success");
        }

        if (!AgenciaFGTS && AgenciaFGTS.length <= 0) {
            jQuery('#msgAgenciaFGTS').html('O Campo AgenciaFGTS Deve ser preenchido').show();
            jQuery("#validaAgenciaFGTS").removeClass("par control-group success").addClass("par control-group error");
            retorno = false;
        }
        else {
            jQuery('#msgAgenciaFGTS').html('').hide();
            jQuery("#validaAgenciaFGTS").removeClass("par control-group error").addClass("par control-group success");
        }

        if (!DigitoFGTS && DigitoFGTS.length <= 0) {
            jQuery('#msgDigitoFGTS').html('O Campo DigitoFGTS Deve ser preenchido').show();
            jQuery("#validaDigitoFGTS").removeClass("par control-group success").addClass("par control-group error");
            retorno = false;
        }
        else {
            jQuery('#msgDigitoFGTS').html('').hide();
            jQuery("#validaDigitoFGTS").removeClass("par control-group error").addClass("par control-group success");
        }

        return retorno;
    }

    // Validar Caracteristicas Fisicas
    if (passoAtivo == 7) {

        var Cor = jQuery('#ddlCor').val();
        var Altura = jQuery('#txtAltura').val();
        var Peso = jQuery('#txtPeso').val();
        var Cabelo = jQuery('#ddlCabelo').val();
        var Olho = jQuery('#ddlOlho').val();
        var Sinais = jQuery('#txtSinais').val();

        if (Cor == 'Selecionar') {
            jQuery('#msgCor').html('O Campo Tipo de LogradouroPIS Deve ser Selecionado um Item').show();
            jQuery("#validaCor").removeClass("par control-group success").addClass("par control-group error");
            retorno = false;
        }
        else {
            jQuery('#msgCor').html('').hide();
            jQuery("#validaCor").removeClass("par control-group error").addClass("par control-group success");
        }

        if (!Altura && Altura.length <= 0) {
            jQuery('#msgAltura').html('O Campo Altura Deve ser preenchido').show();
            jQuery("#validaAltura").removeClass("par control-group success").addClass("par control-group error");
            retorno = false;
        }
        else {
            jQuery('#msgAltura').html('').hide();
            jQuery("#validaAltura").removeClass("par control-group error").addClass("par control-group success");
        }

        if (!Peso && Peso.length <= 0) {
            jQuery('#msgPeso').html('O Campo Peso Deve ser preenchido').show();
            jQuery("#validaPeso").removeClass("par control-group success").addClass("par control-group error");
            retorno = false;
        }
        else {
            jQuery('#msgPeso').html('').hide();
            jQuery("#validaPeso").removeClass("par control-group error").addClass("par control-group success");
        }

        if (Cabelo == 'Selecionar') {
            jQuery('#msgCabelo').html('O Campo Tipo de LogradouroPIS Deve ser Selecionado um Item').show();
            jQuery("#validaCabelo").removeClass("par control-group success").addClass("par control-group error");
            retorno = false;
        }
        else {
            jQuery('#msgCabelo').html('').hide();
            jQuery("#validaCabelo").removeClass("par control-group error").addClass("par control-group success");
        }

        if (Olho == 'Selecionar') {
            jQuery('#msgOlho').html('O Campo Tipo de LogradouroPIS Deve ser Selecionado um Item').show();
            jQuery("#validaOlho").removeClass("par control-group success").addClass("par control-group error");
            retorno = false;
        }
        else {
            jQuery('#msgOlho').html('').hide();
            jQuery("#validaOlho").removeClass("par control-group error").addClass("par control-group success");
        }

        if (!Sinais && Sinais.length <= 0) {
            jQuery('#msgSinais').html('O Campo Sinais Deve ser preenchido').show();
            jQuery("#validaSinais").removeClass("par control-group success").addClass("par control-group error");
            retorno = false;
        }
        else {
            jQuery('#msgSinais').html('').hide();
            jQuery("#validaSinais").removeClass("par control-group error").addClass("par control-group success");
        }

        return retorno;
    }

}

function IncluirDadosFuncionario() {

    jQuery.ajax({
        type: "GET",
        url: "../../Handler/ManutencaoFuncionario.ashx",
        data: {
            Metodo: 'CadastroFuncionario',
            Acao: 'Inclusao',
            NumeroOrdemMatricula: jQuery('#txtNumeroOrdemMatricula').val(),
            NumeroMatricula: jQuery('#txtNumeroMatricula').val(),
            NomeFuncionario: jQuery('#txtNomeFuncionario').val(),
            DataNascimento: jQuery('#txtDataNascimento').val(),
            NacionalidadeFuncionario: jQuery('#ddlNacionalidadeFuncionario option:selected').val(),
            EstadoCivil: jQuery('#ddlEstadoCivil  option:selected').val(),
            NomeConjuge: jQuery('#txtNomeConjuge').val(),
            QtdFilhos: jQuery('#txtQtdFilhos').val(),
            TipoEndereco: jQuery('#ddlTipoEndereco option:selected').val(),
            TipoLogradouro: jQuery('#ddlTipoLogradouro option:selected').val(),
            EstadoFuncionario: jQuery('#ddlEstadoFuncionario option:selected').val(),
            CidadeFuncionario: jQuery('#ddlCidadeFuncionario option:selected').val(),
            Logradouro: jQuery('#txtLogradouro').val(),
            NumeroEndereco: jQuery('#txtNumeroEndereco').val(),
            Bairro: jQuery('#txtBairro').val(),
            Complemento: jQuery('#txtComplemento').val(),
            CEP: jQuery('#txtCEP').val(),
            NomePai: jQuery('#txtNomePai').val(),
            NacionalidadePai: jQuery('#ddlNacionalidadePai option:selected').val(),
            NomeMae: jQuery('#txtNomeMae').val(),
            NacionalidadeMae: jQuery('#ddlNacionalidadeMae option:selected').val(),
            RG: jQuery('#txtRG').val(),
            CarteiraTrabalho: jQuery('#txtCarteiraTrabalho').val(),
            NumeroSerie: jQuery('#txtNumeroSerie').val(),
            NumeroCertificadoReservista: jQuery('#txtNumeroCertificadoReservista').val(),
            Categoria: jQuery('#txtCategoria').val(),
            CPF: jQuery('#txtCPF').val(),
            TituloEleitor: jQuery('#txtTituloEleitor').val(),
            CateiraSaude: jQuery('#txtCateiraSaude').val(),
            CBO: jQuery('#txtCBO').val(),
            Carteira19: jQuery('#txtCarteira19').val(),
            RegistroGeral: jQuery('#txtRegistroGeral').val(),
            CasadoBrasileiro: jQuery('input[@name=<%=rdbCasadoBrasileiro.ClientID%>]:radio:checked').val(),
            //CasadoBrasileiro: jQuery('input[name$:rdbCasadoBrasileiro]:checked').val(),
            //$("input[@name=<%=rdlMinor.ClientID%>]:radio:checked").val();
            Naturalizado: jQuery('input[@name=<%=rblNaturalizado.ClientID%>]:radio:checked').val(),
            //Naturalizado: jQuery('input[name$:rblNaturalizado]:checked').val(),
            FilhoBrasileiro: jQuery('input[@name=<%=rblFilhoBrasileiro.ClientID%>]:radio:checked').val(),
            //FilhoBrasileiro: jQuery('input[name$:rblFilhoBrasileiro]:checked').val(),
            DataChegadaBrasil: jQuery('#txtDataChegadaBrasil').val(),
            CadastroPIS: jQuery('#txtCadastroPIS').val(),
            SobNumero: jQuery('#txtSobNumero').val(),
            BancoPIS: jQuery('#txtBancoPIS').val(),
            Agencia: jQuery('#txtAgencia').val(),
            Digito: jQuery('#txtDigito').val(),
            TipoEnderecoPIS: jQuery('#ddlTipoEnderecoPIS').val(),
            TipoLogradouroPIS: jQuery('#ddlTipoLogradouroPIS').val(),
            EstadoPIS: jQuery('#ddlEstadoPIS option:selected').val(),
            CidadePIS: jQuery('#ddlCidadePIS option:selected').val(),
            LogradouroPIS: jQuery('#txtLogradouroPIS').val(),
            NumeroEnderecoPIS: jQuery('#txtNumeroEnderecoPIS').val(),
            BairroPIS: jQuery('#txtBairroPIS').val(),
            ComplementoPIS: jQuery('#txtComplementoPIS').val(),
            CEPPIS: jQuery('#txtCEPPIS').val(),
            OptanteFGTS: jQuery('#rdpOptanteFGTS').val(),
            DataOpcao: jQuery('#txtDataOpcao').val(),
            DataRetratacao: jQuery('#txtDataRetratacao').val(),
            BancoFGTS: jQuery('#txtBancoFGTS').val(),
            AgenciaFGTS: jQuery('#txtAgenciaFGTS').val(),
            DigitoFGTS: jQuery('#txtDigitoFGTS').val(),
            Cor: jQuery('#ddlCor').val(),
            Altura: jQuery('#txtAltura').val(),
            Peso: jQuery('#txtPeso').val(),
            Cabelo: jQuery('#ddlCabelo').val(),
            Olho: jQuery('#ddlOlho').val(),
            Sinais: jQuery('#txtSinais').val()
        },
        contentType: "json",
        cache: false,
        success: function (data) {
            alert(data);


            for (var i = 0; i < data.length; i++) {
                alert(data[i].FUNC_NOME_FUNCIONARIO)
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrow) {
            errorAjax(textStatus);
        }
    });

}

function CarregaComboCidade(str, tipo) {

    alert(2);

    jQuery.ajax({
        type: "GET",
        url: "../../Handler/BuscaCidade.ashx",
        data: {
            codigoEstado: str
        },
        contentType: "json",
        cache: false,
        success: function (data) {

            var arrCidade = eval(data);



            if (tipo == 1) 
            {
                jQuery('#ddlCidadeFuncionario').empty();

                for (var i = 0; i < arrCidade.length; i++) {
                    jQuery("#ddlCidadeFuncionario").append('<option value=' + arrCidade[i].CODIGO_CIDADE + '>' + arrCidade[i].DESCRICAO + '</option>');
                }

                jQuery("#ddlCidadeFuncionario").attr("class", "chzn-select-cidade");

                jQuery(".chzn-select-cidade").chosen();

                jQuery('#ddlCidadeFuncionario_chzn .chzn-single span').text('Selecione');

                jQuery('#ddlCidadeFuncionario').trigger("chosen:updated");
            }
            else if (tipo = 2)
            {
                jQuery('#ddlCidadePIS').empty();

                for (var i = 0; i < arrCidade.length; i++) {
                    jQuery("#ddlCidadePIS").append('<option value=' + arrCidade[i].CODIGO_CIDADE + '>' + arrCidade[i].DESCRICAO + '</option>');
                }

                jQuery("#ddlCidadePIS").attr("class", "chzn-select-cidade-pis");

                jQuery(".chzn-select-cidade-pis").chosen();

                jQuery('#ddlCidadePIS_chzn .chzn-single span').text('Selecione');

                jQuery('#ddlCidadePIS').trigger("chosen:updated");
            }
            
        },
        error: function (XMLHttpRequest, textStatus, errorThrow) {
            errorAjax(textStatus);
        }
    });

    

}

function validarCPF(strCPF) {
    var Soma;
    var Resto;
    Soma = 0;
    var novoCPF = strCPF.replace(/[\.-]/g, "");
    //strCPF  = RetiraCaracteresInvalidos(strCPF,11);
    if (novoCPF == "00000000000")
        return false;
    for (i = 1; i <= 9; i++)
        Soma = Soma + parseInt(novoCPF.substring(i - 1, i)) * (11 - i);
    Resto = (Soma * 10) % 11;
    if ((Resto == 10) || (Resto == 11))
        Resto = 0;
    if (Resto != parseInt(novoCPF.substring(9, 10)))
        return false;
    Soma = 0;
    for (i = 1; i <= 10; i++)
        Soma = Soma + parseInt(novoCPF.substring(i - 1, i)) * (12 - i);
    Resto = (Soma * 10) % 11;
    if ((Resto == 10) || (Resto == 11))
        Resto = 0;
    if (Resto != parseInt(novoCPF.substring(10, 11)))
        return false;
    return true;
}

