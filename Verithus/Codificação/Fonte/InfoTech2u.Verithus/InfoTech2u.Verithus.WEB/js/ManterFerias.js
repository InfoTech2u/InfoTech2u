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

    jQuery("#btnLimparFerias").click(function () {

        jQuery('#txtDataPeriodoInicio').val("");
        jQuery('#msgDataPeriodoInicio').html('').hide();
        jQuery("#validaDataPeriodoInicio").removeClass("par control-group error").addClass("input-small");

        jQuery('#txtDataPeriodoFim').val("");
        jQuery('#msgDataPeriodoFim').html('').hide();
        jQuery("#validaDataPeriodoFim").removeClass("par control-group error").addClass("input-small");

        jQuery('#txtDataGozadaInicio').val("");
        jQuery('#msgDataGozadaInicio').html('').hide();
        jQuery("#validaDataGozadaInicio").removeClass("par control-group error").addClass("input-small");

        jQuery('#txtDataGozadaFim').val("");
        jQuery('#msgDataGozadaFim').html('').hide();
        jQuery("#validaDataGozadaFim").removeClass("par control-group error").addClass("input-small");

    });

    jQuery("#btnConcluirFerias").click(function () {

        if (ValidarFormularioFerias()) {
            GravarDados();
        }

    });

    function ValidarFormularioFerias() {

        retorno = true;

        var dataPeriodoInicio = jQuery('#txtDataPeriodoInicio').val();
        if (!dataPeriodoInicio && dataPeriodoInicio.length <= 0) {
            jQuery('#msgDataPeriodoInicio').html('O Campo Data de Periodo Inicio Deve ser preenchido').show();
            jQuery("#validaDataPeriodoInicio").removeClass("par control-group success").addClass("par control-group error");
            retorno = false;
        }
        else {
            jQuery('#msgDataPeriodoInicio').html('').hide();
            jQuery("#validaDataPeriodoInicio").removeClass("par control-group error").addClass("par control-group success");
        }

        var dataPeriodoFim = jQuery('#txtDataPeriodoFim').val();
        if (!dataPeriodoFim && dataPeriodoFim.length <= 0) {
            jQuery('#msgDataPeriodoFim').html('O Campo Data de Periodo Fim Deve ser preenchido').show();
            jQuery("#validaDataPeriodoFim").removeClass("par control-group success").addClass("par control-group error");
            retorno = false;
        }
        else {
            jQuery('#msgDataPeriodoFim').html('').hide();
            jQuery("#validaDataPeriodoFim").removeClass("par control-group error").addClass("par control-group success");
        }


        var dataGozadaInicio = jQuery('#txtDataGozadaInicio').val();
        if (!dataGozadaInicio && dataGozadaInicio.length <= 0) {
            jQuery('#msgDataGozadaInicio').html('O Campo Data de Gozada Inicio Deve ser preenchido').show();
            jQuery("#validaDataGozadaInicio").removeClass("par control-group success").addClass("par control-group error");
            retorno = false;
        }
        else {
            jQuery('#msgDataGozadaInicio').html('').hide();
            jQuery("#validaDataGozadaInicio").removeClass("par control-group error").addClass("par control-group success");
        }

        var dataGozadaFim = jQuery('#txtDataGozadaFim').val();
        if (!dataGozadaFim && dataGozadaFim.length <= 0) {
            jQuery('#msgDataGozadaFim').html('O Campo Data de Gozada Fim Deve ser preenchido').show();
            jQuery("#validaDataGozadaFim").removeClass("par control-group success").addClass("par control-group error");
            retorno = false;
        }
        else {
            jQuery('#msgDataGozadaFim').html('').hide();
            jQuery("#validaDataGozadaFim").removeClass("par control-group error").addClass("par control-group success");
        }


        return retorno;

    }

});

function GravarDados() {

    var idUser = getUrlVars()["idUser"];
    
    jQuery.ajax({
        type: "GET",
        crossDomain: true,
        url: "../../Handler/ManterFerias.ashx",
        contentType: "json",
        cache: false,
        data: {
            Metodo: 'Gravar',
            Acao: 'Inclusao',
            CodigoFerias: jQuery('#txtCodigoFerias').val(),
            CodigoFuncionario: idUser,
            DataPeriodoInicio: jQuery('#txtDataPeriodoInicio').val(),
            DataPeriodoFim: jQuery('#txtDataPeriodoFim').val(),
            DataGozadaInicio: jQuery('#txtDataGozadaInicio').val(),
            DataGozadaFim: jQuery('#txtDataGozadaFim').val(),
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