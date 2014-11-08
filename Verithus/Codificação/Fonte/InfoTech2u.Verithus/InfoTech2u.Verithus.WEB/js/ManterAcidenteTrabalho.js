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

    // Character Counter
    jQuery(".textareaCount").charCount({
        allowed: 300,
        warning: 30,
        counterText: 'Caracteres Restantes: '
    });

    jQuery("#btnLimparAcidente").click(function () {

        jQuery('#txtData').val("");
        jQuery('#msgData').html('').hide();
        jQuery("#validaData").removeClass("par control-group error").addClass("input-small");

        jQuery('#txtLocalAcidente').val("");
        jQuery('#msgLocalAcidente').html('').hide();
        jQuery("#validaLocalAcidente").removeClass("par control-group error").addClass("input-small");

        jQuery('#txtCausaAcidente').val("");
        jQuery('#msgCausaAcidente').html('').hide();
        jQuery("#validaCausaAcidente").removeClass("par control-group error").addClass("input-small");

        jQuery('#txtDataAlta').val("");
        jQuery('#msgDataAlta').html('').hide();
        jQuery("#validaDataAlta").removeClass("par control-group error").addClass("input-small");

        jQuery('#txtResultado').val("");
        jQuery('#msgResultado').html('').hide();
        jQuery("#validaResultado").removeClass("par control-group error").addClass("input-small");

        jQuery('#txtObservacoes').val("");
        jQuery('#msgObservacoes').html('').hide();
        jQuery("#validaObservacoes").removeClass("par control-group error").addClass("input-small");

    });

    jQuery("#btnConcluirAcidente").click(function () {

        if (ValidarFormularioAcidente()) {
            GravarDados();
        }

    });
    
    function ValidarFormularioAcidente() {

        retorno = true;

        /*

        var dataPeriodoInicio = jQuery('#txtData').val();
        if (!dataPeriodoInicio && dataPeriodoInicio.length <= 0) {
            jQuery('#msgDataPeriodoInicio').html('O Campo Data de Periodo Inicio Deve ser preenchido').show();
            jQuery("#validaDataPeriodoInicio").removeClass("par control-group success").addClass("par control-group error");
            retorno = false;
        }
        else {
            jQuery('#msgDataPeriodoInicio').html('').hide();
            jQuery("#validaDataPeriodoInicio").removeClass("par control-group error").addClass("par control-group success");
        }

        var dataPeriodoFim = jQuery('#txtLocalAcidente').val();
        if (!dataPeriodoFim && dataPeriodoFim.length <= 0) {
            jQuery('#msgDataPeriodoFim').html('O Campo Data de Periodo Fim Deve ser preenchido').show();
            jQuery("#validaDataPeriodoFim").removeClass("par control-group success").addClass("par control-group error");
            retorno = false;
        }
        else {
            jQuery('#msgDataPeriodoFim').html('').hide();
            jQuery("#validaDataPeriodoFim").removeClass("par control-group error").addClass("par control-group success");
        }


        var dataGozadaInicio = jQuery('#txtCausaAcidente').val();
        if (!dataGozadaInicio && dataGozadaInicio.length <= 0) {
            jQuery('#msgDataGozadaInicio').html('O Campo Data de Gozada Inicio Deve ser preenchido').show();
            jQuery("#validaDataGozadaInicio").removeClass("par control-group success").addClass("par control-group error");
            retorno = false;
        }
        else {
            jQuery('#msgDataGozadaInicio').html('').hide();
            jQuery("#validaDataGozadaInicio").removeClass("par control-group error").addClass("par control-group success");
        }

        var dataGozadaFim = jQuery('#txtDataAlta').val();
        if (!dataGozadaFim && dataGozadaFim.length <= 0) {
            jQuery('#msgDataGozadaFim').html('O Campo Data de Gozada Fim Deve ser preenchido').show();
            jQuery("#validaDataGozadaFim").removeClass("par control-group success").addClass("par control-group error");
            retorno = false;
        }
        else {
            jQuery('#msgDataGozadaFim').html('').hide();
            jQuery("#validaDataGozadaFim").removeClass("par control-group error").addClass("par control-group success");
        }

        var dataGozadaFim = jQuery('#txtResultado').val();
        if (!dataGozadaFim && dataGozadaFim.length <= 0) {
            jQuery('#msgDataGozadaFim').html('O Campo Data de Gozada Fim Deve ser preenchido').show();
            jQuery("#validaDataGozadaFim").removeClass("par control-group success").addClass("par control-group error");
            retorno = false;
        }
        else {
            jQuery('#msgDataGozadaFim').html('').hide();
            jQuery("#validaDataGozadaFim").removeClass("par control-group error").addClass("par control-group success");
        }

        var Observacoes = jQuery('#txtObservacoes').val();
        if (!Observacoes && Observacoes.length <= 0) {
            jQuery('#msgObservacoes').html('O Campo Data de Gozada Fim Deve ser preenchido').show();
            jQuery("#validaObservacoes").removeClass("par control-group success").addClass("par control-group error");
            retorno = false;
        }
        else {
            jQuery('#msgObservacoes').html('').hide();
            jQuery("#validaObservacoes").removeClass("par control-group error").addClass("par control-group success");
        }
        */

        return retorno;

    }


});

function GravarDados() {

    var idUser = getUrlVars()["idUser"];

    jQuery.ajax({
        type: "GET",
        crossDomain: true,
        url: "../../Handler/ManterAcidenteTrabalho.ashx",
        contentType: "json",
        cache: false,
        data: {
            Metodo: 'Gravar',
            Acao: 'Inclusao',
            CodigoAcidenteTrabalho: jQuery('#txtCodigoAcidenteTrabalho').val(),
            CodigoFuncionario: idUser,
            Data: jQuery('#txtData').val(),
            Local: jQuery('#txtLocalAcidente').val(),
            Causa: jQuery('#txtCausaAcidente').val(),
            DataAlta: jQuery('#txtDataAlta').val(),
            Resultado: jQuery('#txtResultado').val(),
            Observacoes: jQuery('#txtObservacoes').val(),
            CodigoStatus: '1'
        },
        success: function (data) {
            if (data['Msg'] != null) {
                jQuery('#myModal').modal('hide');

                jQuery(window.document.location).attr('href', '../../Login.aspx?cod=300');

                return;
            } else {
            //Sucesso
            jQuery.alerts.dialogClass = 'alert-success';
            jAlert('Item foi incluído.', 'Informação', function () {
                jQuery.alerts.dialogClass = null; // reset to default
            });
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrow) {
            errorAjax(textStatus);
            alert(textStatus);
        }
    });

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