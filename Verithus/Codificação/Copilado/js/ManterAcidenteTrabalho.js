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

    CarregarAcidentes();

    jQuery('#dyntable').dataTable({
        "sPaginationType": "full_numbers",
        "fnDrawCallback": function (oSettings) { jQuery.uniform.update(); },
        "language": {
            "search": "Pesquisa",
            "lengthMenu": "Mostrar _MENU_ registros por página",
            "zeroRecords": "Não há registros",
            "info": "Página _PAGE_ de _PAGES_",
            "infoEmpty": "Não há registros.",
            "infoFiltered": "(Pesquisado de um total de _MAX_ registro(s))",
            "paginate": {
                "first": "Primeira",
                "previous": "Anterior",
                "next": "Próxima",
                "last": "Última"
            },
        }
    });

    jQuery('#dyntable tbody').on('click', 'tr', function () {
        if (jQuery(this).hasClass('selected')) {
            //jQuery(this).removeClass('selected');
        }
        else {
            jQuery('#dyntable tr.selected').removeClass('selected');
            jQuery(this).addClass('selected');
        }
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

function Incluir() {

    //alert('Teste');

    jQuery('#btnConcluirAcidente').attr('onclick', 'javascript:Incluir()');
    jQuery('#myModalLabel').text('Cadastro de Acidente de Trabalho');

    jQuery('#txtCodigoAcidenteTrabalho').val('');

    jQuery('#txtData').val('');
    jQuery('#txtLocalAcidente').val('');
    jQuery('#txtCausaAcidente').val('');
    jQuery('#txtDataAlta').val('');
    jQuery('#txtResultado').val('');
    jQuery('#txtObservacoes').val('');
}

function PrepararTela(id) {

    if (jQuery('#hdnFuncaoTela').val() == 'Incluir') {
        jQuery('#btnConcluirAcidente').attr('onclick', 'javascript:Incluir()');
        jQuery('#myModalLabel').text('Cadastro de Acidentes de Trabalho');

        jQuery('#txtCodigoAcidenteTrabalho').val('');

        jQuery('#txtData').val('');
        jQuery('#txtLocalAcidente').val('');
        jQuery('#txtCausaAcidente').val('');
        jQuery('#txtDataAlta').val('');
        jQuery('#txtResultado').val('');
        jQuery('#txtObservacoes').val('');
    }
    else (jQuery('#hdnFuncaoTela').val() == 'Alterar')
    {
        CarregarAcidentesFormulario(id);
    }
}

function FuncaoTelaModal(funcao, id) {

    if (funcao == 'Incluir') {
        jQuery('#hdnFuncaoTela').val('Incluir');

        jQuery('#txtData').attr('readonly', false);
        jQuery('#txtLocalAcidente').attr('readonly', false);
        jQuery('#txtCausaAcidente').attr('readonly', false);
        jQuery('#txtDataAlta').attr('readonly', false);
        jQuery('#txtResultado').attr('readonly', false);
        jQuery('#txtObservacoes').attr('readonly', false);

        jQuery("#btnConcluirAcidente").prop("disabled", false);

    }
    else if (funcao == 'Alterar') {
        jQuery('#hdnFuncaoTela').val('Alterar');

        jQuery('#txtData').attr('readonly', false);
        jQuery('#txtLocalAcidente').attr('readonly', false);
        jQuery('#txtCausaAcidente').attr('readonly', false);
        jQuery('#txtDataAlta').attr('readonly', false);
        jQuery('#txtResultado').attr('readonly', false);
        jQuery('#txtObservacoes').attr('readonly', false);

        jQuery("#btnConcluirAcidente").prop("disabled", false);

        PrepararTela(id)


    }
    else { jQuery('#hdnFuncaoTela').val(''); }
}

function CarregarAcidentesFormulario(id) {

    var idUser = getUrlVars()["idUser"];

    jQuery.ajax({
        type: "GET",
        crossDomain: true,
        url: "../../Handler/ManterAcidenteTrabalho.ashx",
        contentType: "json",
        cache: false,
        data: {
            Metodo: 'Selecionar',
            Acao: 'Selecionar',
            CodigoFuncionario: idUser,
            CodigoAcidenteTrabalho: id
        },
        success: function (data) {
            if (data['Msg'] != null) {
                jQuery('#myModal').modal('hide');

                jQuery(window.document.location).attr('href', '../../Login.aspx?cod=300');

                return;
            } else {
                var Acidente = eval(data);


                if (Acidente != undefined && Acidente.length > 0) {

                    jQuery('#txtCodigoAcidenteTrabalho').val(Acidente[0].CODIGO_ACIDENTE_TRABALHO);
                    jQuery('#txtData').val(Acidente[0].DATA);
                    jQuery('#txtLocalAcidente').val(Acidente[0].ACIDENTE_TRABALHO_LOCAL);
                    jQuery('#txtCausaAcidente').val(Acidente[0].CAUSA);
                    jQuery('#txtDataAlta').val(Acidente[0].DATA_ALTA);

                    jQuery('#txtResultado').val(Acidente[0].RESULTADO);
                    jQuery('#txtObservacoes').val(Acidente[0].OBSERVACOES);

                    jQuery('#btnConcluirAcidente').attr('onclick', 'javascript:Alterar(' + id + ');');
                    jQuery('#myModalLabel').text('Alteração de Ferias');

                }
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrow) {
            errorAjax(textStatus);
            alert(textStatus);
        }
    });

}

function CarregarAcidentes() {

    jQuery("tbody").empty();
    jQuery('tbody').remove();
    jQuery('#dyntable').append('<tbody></tbody>');

    var idUser = getUrlVars()["idUser"];

    if (idUser != undefined && idUser != 0) {
        jQuery.ajax({
            type: "GET",
            crossDomain: true,
            url: "../../Handler/ManterAcidenteTrabalho.ashx",
            contentType: "json",
            cache: false,
            data: {
                Metodo: 'Selecionar',
                Acao: 'Selecionar',
                CodigoFuncionario: idUser
            },
            success: function (data) {
                if (data['Msg'] != null) {
                    jQuery('#myModal').modal('hide');

                    jQuery(window.document.location).attr('href', '../../Login.aspx?cod=300');

                    return;
                } else {
                    var Acidente = eval(data);


                    if (Acidente != undefined && Acidente.length > 0) {

                        for (var x in Acidente) {
                            jQuery('#dyntable').DataTable().row.add([
                                Acidente[x].CODIGO_ACIDENTE_TRABALHO,
                                Acidente[x].DATA,
                                Acidente[x].ACIDENTE_TRABALHO_LOCAL,
                                Acidente[x].CAUSA,
                                Acidente[x].DATA_ALTA,
                                '<a title="Alterar" href="#myModal" onclick="javascript:FuncaoTelaModal(\'Alterar\', ' + Acidente[x].CODIGO_ACIDENTE_TRABALHO + ');" data-toggle="modal"><i class="iconfa-pencil"></i></a>',
                                '<a title="Excluir" href="javascript:ExcluirFerias(' + Acidente[x].CODIGO_ACIDENTE_TRABALHO + ')" class="deleterow"><i class="icon-trash"></i></a>'
                            ]).draw();
                        }

                    }
                }
            },
            error: function (XMLHttpRequest, textStatus, errorThrow) {
                errorAjax(textStatus);
                alert(textStatus);
            }
        });
    }

}

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
                var Acidente = eval(data);


                if (Acidente != undefined && Acidente.length > 0) {

                    jQuery('#myModal').modal('hide');


                    jQuery('#dyntable').DataTable().row().remove().draw(false);
                    // do some other stuff here
                    jQuery.alerts.dialogClass = 'alert-success';
                    jAlert('Item foi gravado', 'Informação', function () {
                        jQuery.alerts.dialogClass = null; // reset to default
                    });

                    for (var x in Acidente) {

                        jQuery('#dyntable').DataTable().row.add([
                                Acidente[x].CODIGO_ACIDENTE_TRABALHO,
                                Acidente[x].DATA,
                                Acidente[x].ACIDENTE_TRABALHO_LOCAL,
                                Acidente[x].CAUSA,
                                Acidente[x].DATA_ALTA,
                                '<a title="Alterar" href="#myModal" onclick="javascript:FuncaoTelaModal(\'Alterar\', ' + Acidente[x].CODIGO_ACIDENTE_TRABALHO + ');" data-toggle="modal"><i class="iconfa-pencil"></i></a>',
                                '<a title="Excluir" href="javascript:ExcluirFerias(' + Acidente[x].CODIGO_ACIDENTE_TRABALHO + ')" class="deleterow"><i class="icon-trash"></i></a>'
                        ]).draw();
                    }
                }
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