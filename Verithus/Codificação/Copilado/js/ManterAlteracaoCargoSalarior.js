

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

    jQuery('.horaBrasil').mask('99:99');

    jQuery("#txtSalario").maskMoney({ showSymbol: true, symbol: "R$", decimal: ",", thousands: "." });

    jQuery("#btnConcluirAlteracaoCargoSalario").click(function () {

        if (ValidarFormularioAlteracaoCargoSalario()) {
            GravarDados();
        }

    });
    

    jQuery("#btnLimparAlteracaoCargoSalario").click(function () {

        jQuery('#txtData').val("");
        jQuery('#msgData').html('').hide();
        jQuery("#validaData").removeClass("par control-group error").addClass("input-small");

        jQuery('#ddlCargo').val(0);
        jQuery('#msgCargo').html('').hide();
        jQuery("#validaCargo").removeClass("par control-group error").addClass("input-small");

        jQuery("#txtSalario").val("");
        jQuery('#msgSalario').html('').hide();
        jQuery("#validaSalario").removeClass("par control-group error").addClass("input-small");

        jQuery("#txtHorarioEntrada").val("");
        jQuery('#msgHorarioEntrada').html('').hide();
        jQuery("#validaHorarioEntrada").removeClass("par control-group error").addClass("input-small");

        jQuery("#txtHorarioSaida").val("");
        jQuery('#msgHorarioSaida').html('').hide();
        jQuery("#validaHorarioSaida").removeClass("par control-group error").addClass("input-small");

    });

    function ValidarFormularioAlteracaoCargoSalario() {

        var retorno = true;
        /*
        var dataDeAdmissao = jQuery('#txtDataAdmissao').val();
        if (!dataDeAdmissao && dataDeAdmissao.length <= 0) {
            jQuery('#msgDataDeAdmissao').html('O Campo Data de Admissão Deve ser preenchido').show();
            jQuery("#validaDataDeAdmissao").removeClass("par control-group success").addClass("par control-group error");
            retorno = false;
        }
        else {
            jQuery('#msgDataDeAdmissao').html('').hide();
            jQuery("#validaDataDeAdmissao").removeClass("par control-group error").addClass("par control-group success");
        }


        var dataDeRegistro = jQuery('#txtDataRegistro').val();
        if (!dataDeRegistro && dataDeRegistro.length <= 0) {
            jQuery('#msgDataRegistro').html('O Campo Data de Registro Deve ser preenchido').show();
            jQuery("#validaDataRegistro").removeClass("par control-group success").addClass("par control-group error");
            retorno = false;
        }
        else {
            jQuery('#msgDataRegistro').html('').hide();
            jQuery("#validaDataRegistro").removeClass("par control-group error").addClass("par control-group success");
        }


        var ddlCargo = jQuery('#ddlCargo option:selected').text();
        if (ddlCargo == 'Selecionar') {
            jQuery('#msgCargo').html('O Campo Cargo Deve ser preenchido').show();
            jQuery("#validaCargo").removeClass("par control-group success").addClass("par control-group error");
            retorno = false;
        }
        else {
            jQuery('#msgCargo').html('').hide();
            jQuery("#validaCargo").removeClass("par control-group error").addClass("par control-group success");
        }


        var ddlSecao = jQuery('#ddlSecao option:selected').text();
        if (ddlSecao == 'Selecionar') {
            jQuery('#msgSecao').html('O Campo Seção Deve ser preenchido').show();
            jQuery("#validaSecao").removeClass("par control-group success").addClass("par control-group error");
            retorno = false;
        }
        else {
            jQuery('#msgSecao').html('').hide();
            jQuery("#validaSecao").removeClass("par control-group error").addClass("par control-group success");
        }


        var salarioInicial = jQuery("#txtSalarioInicial").val();
        if (!salarioInicial && salarioInicial.length <= 0) {
            jQuery('#msgSalarioInicial').html('O Campo Salário Inicial Deve ser preenchido').show();
            jQuery("#validaSalarioInicial").removeClass("par control-group success").addClass("par control-group error");
            retorno = false;
        }
        else {
            jQuery('#msgSalarioInicial').html('').hide();
            jQuery("#validaSalarioInicial").removeClass("par control-group error").addClass("par control-group success");
        }


        var comissao = jQuery("#txtComissao").val();
        if (!comissao && comissao.length <= 0) {
            jQuery('#msgComissao').html('O Campo Comissão Deve ser preenchido').show();
            jQuery("#validaComissao").removeClass("par control-group success").addClass("par control-group error");
            retorno = false;
        }
        else {
            jQuery('#msgComissao').html('').hide();
            jQuery("#validaComissao").removeClass("par control-group error").addClass("par control-group success");
        }


        var ddlTarefa = jQuery('#ddlTarefa option:selected').text();
        if (ddlTarefa == 'Selecionar') {
            jQuery('#msgTarefa').html('O Campo Tarefa Deve ser preenchido').show();
            jQuery("#validaTarefa").removeClass("par control-group success").addClass("par control-group error");
            retorno = false;
        }
        else {
            jQuery('#msgTarefa').html('').hide();
            jQuery("#validaTarefa").removeClass("par control-group error").addClass("par control-group success");
        }


        var horarioTrabalhoEntrada = jQuery("#txtHorarioTrabalhoEntrada").val();
        if (!horarioTrabalhoEntrada && horarioTrabalhoEntrada.length <= 0) {
            jQuery('#msgHorarioTrabalhoEntrada').html('O Campo Horário de Trabalho Deve ser preenchido').show();
            jQuery("#validaHorarioTrabalhoEntrada").removeClass("par control-group success").addClass("par control-group error");
            retorno = false;
        }
        else {
            jQuery('#msgHorarioTrabalhoEntrada').html('').hide();
            jQuery("#validaHorarioTrabalhoEntrada").removeClass("par control-group error").addClass("par control-group success");
        }


        var horarioTrabalhoSaida = jQuery("#txtHorarioTrabalhoSaida").val();
        if (!horarioTrabalhoSaida && horarioTrabalhoSaida.length <= 0) {
            jQuery('#msgHorarioTrabalhoSaida').html('O Campo Horário de Trabalho Deve ser preenchido').show();
            jQuery("#validaHorarioTrabalhoSaida").removeClass("par control-group success").addClass("par control-group error");
            retorno = false;
        }
        else {
            jQuery('#msgHorarioTrabalhoSaida').html('').hide();
            jQuery("#validaHorarioTrabalhoSaida").removeClass("par control-group error").addClass("par control-group success");
        }


        var intervaloTrabalhoEntrada = jQuery("#txtIntervaloTrabalhoEntrada").val();
        if (!intervaloTrabalhoEntrada && intervaloTrabalhoEntrada.length <= 0) {
            jQuery('#msgIntervaloTrabalhoEntrada').html('O Campo Intervalo de Trabalho Deve ser preenchido').show();
            jQuery("#validaIntervaloTrabalhoEntrada").removeClass("par control-group success").addClass("par control-group error");
            retorno = false;
        }
        else {
            jQuery('#msgIntervaloTrabalhoEntrada').html('').hide();
            jQuery("#validaIntervaloTrabalhoEntrada").removeClass("par control-group error").addClass("par control-group success");
        }


        var intervaloTrabalhoSaida = jQuery("#txtIntervaloTrabalhoSaida").val();
        if (!intervaloTrabalhoSaida && intervaloTrabalhoSaida.length <= 0) {
            jQuery('#msgIntervaloTrabalhoSaida').html('O Campo Intervalo de Trabalho Deve ser preenchido').show();
            jQuery("#validaIntervaloTrabalhoSaida").removeClass("par control-group success").addClass("par control-group error");
            retorno = false;
        }
        else {
            jQuery('#msgIntervaloTrabalhoSaida').html('').hide();
            jQuery("#validaIntervaloTrabalhoSaida").removeClass("par control-group error").addClass("par control-group success");
        }

        var descansoSemanalEntrada = jQuery('#ddlDescansoSemanalEntrada option:selected').text();
        if (!descansoSemanalEntrada == 'Selecionar') {
            jQuery('#msgDescansoSemanalEntrada').html('O Campo Descanso Semanal Deve ser preenchido').show();
            jQuery("#validaDescansoSemanalEntrada").removeClass("par control-group success").addClass("par control-group error");
            retorno = false;
        }
        else {
            jQuery('#msgDescansoSemanalEntrada').html('').hide();
            jQuery("#validaDescansoSemanalEntrada").removeClass("par control-group error").addClass("par control-group success");
        }


        var descansoSemanalSaida = jQuery('#ddlDescansoSemanalSaida option:selected').text();
        if (!descansoSemanalSaida == 'Selecionar') {
            jQuery('#msgDescansoSemanalSaida').html('O Campo Descanso Semanal Deve ser preenchido').show();
            jQuery("#validaDescansoSemanalSaida").removeClass("par control-group success").addClass("par control-group error");
            retorno = false;
        }
        else {
            jQuery('#msgDescansoSemanalSaida').html('').hide();
            jQuery("#validaDescansoSemanalSaida").removeClass("par control-group error").addClass("par control-group success");
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
        url: "../../Handler/ManterAlteracaoCargoSalarior.ashx",
        contentType: "json",
        cache: false,
        data: {
            Metodo: 'Gravar',
            Acao: 'Inclusao',
            CodigoAlteracaoCargoSalario: jQuery('#txtCodigoAlteracaoCargoSalario').val(),
            CodigoFuncionario: idUser,
            Data: jQuery('#txtData').val(),
            CodigoTipoCargo: jQuery('#ddlCargo option:selected').val(),
            Salario: jQuery('#txtSalario').val(),
            HorarioInicio: jQuery('#txtHorarioEntrada').val(),
            HorarioFim: jQuery('#txtHorarioSaida').val(),
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