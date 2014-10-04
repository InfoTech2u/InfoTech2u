

jQuery(document).ready(function () {

    //Data dataddmmaaaa
    jQuery(".dataddmmaaaa").mask("99/99/9999");

    // Data com opção de Filtro de Mes e Ano
    jQuery(".dataddmmaaaa").datepicker({
        dateFormat: 'dd/mm/yy',
        changeMonth: true,
        changeYear: true,
        yearRange: '-100y:c+nn'
        
    });

    jQuery("#txtSalarioInicial").maskMoney({ showSymbol: true, symbol: "R$", decimal: ",", thousands: "." });

    jQuery('#btnConcluirDemissao').click(function (event) {

        GravarDados();
        
    });

    jQuery("#btnLimparDemissao").click(function () {

        jQuery('#txtDataDemissao').val("");
        jQuery('#msgDataDemissao').html('').hide();
        jQuery("#validaDataDemissao").removeClass("par control-group error").addClass("input-small");

        jQuery('#txtDataRegistro').val("");
        jQuery('#msgDataRegistro').html('').hide();
        jQuery("#validaDataRegistro").removeClass("par control-group error").addClass("input-small");

        jQuery('#ddlCargo').val(0);
        jQuery('#msgCargo').html('').hide();
        jQuery("#validaCargo").removeClass("par control-group error").addClass("input-small");

        jQuery('#ddlSecao').val(0);
        jQuery('#msgSecao').html('').hide();
        jQuery("#validaSecao").removeClass("par control-group error").addClass("input-small");

        jQuery("#txtSalarioInicial").val("");
        jQuery('#msgSalarioInicial').html('').hide();
        jQuery("#validaSalarioInicial").removeClass("par control-group error").addClass("input-small");

        jQuery("#txtComissao").val("");
        jQuery('#msgComissao').html('').hide();
        jQuery("#validaComissao").removeClass("par control-group error").addClass("input-small");

        jQuery("#ddlTarefa").val(0);        
        jQuery('#msgTarefa').html('').hide();
        jQuery("#validaTarefa").removeClass("par control-group error").addClass("input-small");

        jQuery("#ddlFormaPagamento").val(0);
        jQuery('#msgFormaPagamento').html('').hide();
        jQuery("#validaFormaPagamento").removeClass("par control-group error").addClass("input-small");
    });

    

});

function ValidarFormularioDemissao() {

    var dataDemissao = jQuery('#txtDataDemissao').val();
    if (!dataDemissao && dataDemissao.length <= 0) {
        jQuery('#msgDataDemissao').html('O Campo Data de Admissão Deve ser preenchido').show();
        jQuery("#validaDataDemissao").removeClass("par control-group success").addClass("par control-group error");
        return false;
    }
    else {
        jQuery('#msgDataDemissao').html('').hide();
        jQuery("#validaDataDemissao").removeClass("par control-group error").addClass("par control-group success");
        return true;
    }


    var dataDeRegistro = jQuery('#txtDataRegistro').val();
    if (!dataDeRegistro && dataDeRegistro.length <= 0) {
        jQuery('#msgDataRegistro').html('O Campo Data de Registro Deve ser preenchido').show();
        jQuery("#validaDataRegistro").removeClass("par control-group success").addClass("par control-group error");
        return false;
    }
    else {
        jQuery('#msgDataRegistro').html('').hide();
        jQuery("#validaDataRegistro").removeClass("par control-group error").addClass("par control-group success");
        return true;
    }


    var ddlCargo = jQuery('#ddlCargo option:selected').text();
    if (ddlCargo == 'Selecionar') {
        jQuery('#msgCargo').html('O Campo Cargo Deve ser preenchido').show();
        jQuery("#validaCargo").removeClass("par control-group success").addClass("par control-group error");
        return false;
    }
    else {
        jQuery('#msgCargo').html('').hide();
        jQuery("#validaCargo").removeClass("par control-group error").addClass("par control-group success");
        return true;
    }

    /*
    var ddlSecao = jQuery('#ddlSecao option:selected').text();
    if (ddlSecao == 'Selecionar') {
        jQuery('#msgSecao').html('O Campo Seção Deve ser preenchido').show();
        jQuery("#validaSecao").removeClass("par control-group success").addClass("par control-group error");
        return false;
    }
    else {
        jQuery('#msgSecao').html('').hide();
        jQuery("#validaSecao").removeClass("par control-group error").addClass("par control-group success");
        return true;
    }
    */

    var salarioInicial = jQuery("#txtSalarioInicial").val();
    if (!salarioInicial && salarioInicial.length <= 0) {
        jQuery('#msgSalarioInicial').html('O Campo Salário Inicial Deve ser preenchido').show();
        jQuery("#validaSalarioInicial").removeClass("par control-group success").addClass("par control-group error");
        return false;
    }
    else {
        jQuery('#msgSalarioInicial').html('').hide();
        jQuery("#validaSalarioInicial").removeClass("par control-group error").addClass("par control-group success");
        return true;
    }


    var comissao = jQuery("#txtComissao").val();
    if (!comissao && comissao.length <= 0) {
        jQuery('#msgComissao').html('O Campo Comissão Deve ser preenchido').show();
        jQuery("#validaComissao").removeClass("par control-group success").addClass("par control-group error");
        return false;
    }
    else {
        jQuery('#msgComissao').html('').hide();
        jQuery("#validaComissao").removeClass("par control-group error").addClass("par control-group success");
        return true;
    }


    var ddlTarefa = jQuery('#ddlTarefa option:selected').text();
    if (ddlTarefa == 'Selecionar') {
        jQuery('#msgTarefa').html('O Campo Tarefa Deve ser preenchido').show();
        jQuery("#validaTarefa").removeClass("par control-group success").addClass("par control-group error");
        return false;
    }
    else {
        jQuery('#msgTarefa').html('').hide();
        jQuery("#validaTarefa").removeClass("par control-group error").addClass("par control-group success");
        return true;
    }


    var ddlFormaPagamento = jQuery("#ddlFormaPagamento option:selected").text();
    if (ddlFormaPagamento == 'Selecionar') {
        jQuery('#msgFormaPagamento').html('O Campo Forma de Pagamento Deve ser preenchido').show();
        jQuery("#validaFormaPagamento").removeClass("par control-group success").addClass("par control-group error");
        return false;
    }
    else {
        jQuery('#msgFormaPagamento').html('').hide();
        jQuery("#validaFormaPagamento").removeClass("par control-group error").addClass("par control-group success");
        return true;
    }

}

function GravarDados() {

    var idUser = getUrlVars()["idUser"];

    if (ValidarFormularioDemissao()) {
        jQuery.ajax({
            type: "GET",
            crossDomain: true,
            url: "../../Handler/ManterDemissao.ashx",
            contentType: "json",
            cache: false,
            data: {
                Metodo: 'Gravar',
                Acao: 'Inclusao',
                CodigoDemissao: jQuery('#txtCodigoDemissao').val(),
                CodigoFuncionario: idUser,
                DataDemissao: jQuery('#txtDataDemissao').val(),
                DataRegistro: jQuery('#txtDataRegistro').val(),
                CodigoTipoCargo: jQuery('#ddlCargo option:selected').val(),
                CodigoTipoSecao: jQuery('#ddlSecao option:selected').val(),
                SalarioInicial: jQuery('#txtSalarioInicial').val(),
                Comissao: jQuery('#txtComissao').val(),
                CodigoTipoTarefa: jQuery('#ddlTarefa option:selected').val(),
                CodigoTipoFormaPagamento: jQuery('#ddlFormaPagamento option:selected').val(),
                CodigoStatus: '1'
            },
            success: function (data) {
                alert("Incluído com Sucesso!");
            },
            error: function (XMLHttpRequest, textStatus, errorThrow) {
                errorAjax(textStatus);
                alert(textStatus);
            }
        });
    }

}

function getUrlVars() {
    var vars = [], hash;
    var hashes = window.location.href.slice(window.location.href.indexOf('?') + 1).split('&');
    for (var i = 0; i < hashes.length; i++) {
        hash = hashes[i].split('=');
        vars.push(hash[0]);
        vars[hash[0]] = hash[1];
    }
    return vars;
}