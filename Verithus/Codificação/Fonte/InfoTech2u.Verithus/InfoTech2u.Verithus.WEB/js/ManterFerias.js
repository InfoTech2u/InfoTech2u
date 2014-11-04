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

    //dyntable

    CarregarFerias();

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

function Incluir()
{

    //alert('Teste');

    jQuery('#btnConcluirFerias').attr('onclick', 'javascript:Incluir()');
    jQuery('#myModalLabel').text('Cadastro de Ferias');

    jQuery('#txtCodigoFerias').val('');

    jQuery('#txtDataPeriodoInicio').val('');
    jQuery('#txtDataPeriodoFim').val('');
    jQuery('#txtDataGozadaInicio').val('');
    jQuery('#txtDataGozadaFim').val('');
}

function PrepararTela(id) {

    if (jQuery('#hdnFuncaoTela').val() == 'Incluir') {
        jQuery('#btnConcluirFerias').attr('onclick', 'javascript:Incluir()');
        jQuery('#myModalLabel').text('Cadastro de Ferias');

        jQuery('#txtCodigoFerias').val('');

        jQuery('#txtDataPeriodoInicio').val('');
        jQuery('#txtDataPeriodoFim').val('');
        jQuery('#txtDataGozadaInicio').val('');
        jQuery('#txtDataGozadaFim').val('');
    }
    else (jQuery('#hdnFuncaoTela').val() == 'Alterar')
    {
        CarregarFeriasFormulario(id);
    }
}

function FuncaoTelaModal(funcao, id) {
    
    if (funcao == 'Incluir') {
        jQuery('#hdnFuncaoTela').val('Incluir');

        jQuery('#txtDataPeriodoInicio').attr('readonly', false);
        jQuery('#txtDataPeriodoFim').attr('readonly', false);
        jQuery('#txtDataGozadaInicio').attr('readonly', false);
        jQuery('#txtDataGozadaFim').attr('readonly', false);

        jQuery("#btnConcluirFerias").prop("disabled", false);

    }
    else if (funcao == 'Alterar') {
        jQuery('#hdnFuncaoTela').val('Alterar');

        jQuery('#txtDataPeriodoInicio').attr('readonly', false);
        jQuery('#txtDataPeriodoFim').attr('readonly', false);
        jQuery('#txtDataGozadaInicio').attr('readonly', false);
        jQuery('#txtDataGozadaFim').attr('readonly', false);

        jQuery("#btnConcluirFerias").prop("disabled", false);

        PrepararTela(id)


    }
    else { jQuery('#hdnFuncaoTela').val(''); }
}

function CarregarFeriasFormulario(id)
{

    var idUser = getUrlVars()["idUser"];

    jQuery.ajax({
        type: "GET",
        crossDomain: true,
        url: "../../Handler/ManterFerias.ashx",
        contentType: "json",
        cache: false,
        data: {
            Metodo: 'Selecionar',
            Acao: 'Selecionar',
            CodigoFuncionario: idUser,
            CodigoFerias: id
        },
        success: function (data) {
            if (data['Msg'] != null) {
                jQuery('#myModal').modal('hide');

                jQuery(window.document.location).attr('href', '../../Login.aspx?cod=300');

                return;
            } else {
            var ferias = eval(data);


            if (ferias != undefined && ferias.length > 0) {

                jQuery('#txtCodigoFerias').val(ferias[0].CODIGO_FERIAS);
                jQuery('#txtDataPeriodoInicio').val(ferias[0].DATA_PERIODO_INICIO);
                jQuery('#txtDataPeriodoFim').val(ferias[0].DATA_PERIODO_FIM);
                jQuery('#txtDataGozadaInicio').val(ferias[0].DATA_GOZADA_INICIO);
                jQuery('#txtDataGozadaFim').val(ferias[0].DATA_GOZADA_FIM);
                
                jQuery('#btnConcluirFerias').attr('onclick', 'javascript:Alterar(' + id + ');');
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

function CarregarFerias() {

    jQuery("tbody").empty();
    jQuery('tbody').remove();
    jQuery('#dyntable').append('<tbody></tbody>');

    var idUser = getUrlVars()["idUser"];

    if (idUser != undefined && idUser != 0) {
        jQuery.ajax({
            type: "GET",
            crossDomain: true,
            url: "../../Handler/ManterFerias.ashx",
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
                var ferias = eval(data);


                if (ferias != undefined && ferias.length > 0) {
                    
                    for (var x in ferias) {
                        jQuery('#dyntable').DataTable().row.add([
                            ferias[x].CODIGO_FERIAS,
                            ferias[x].DATA_PERIODO_INICIO,
                            ferias[x].DATA_PERIODO_FIM,
                            ferias[x].DATA_GOZADA_INICIO,
                            ferias[x].DATA_GOZADA_FIM,
                            '<a title="Alterar" href="#myModal" onclick="javascript:FuncaoTelaModal(\'Alterar\', ' + ferias[x].CODIGO_FERIAS + ');" data-toggle="modal"><i class="iconfa-pencil"></i></a>',
                            '<a title="Excluir" href="javascript:ExcluirFerias(' + ferias[x].CODIGO_FERIAS + ')" class="deleterow"><i class="icon-trash"></i></a>'
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
            if (data['Msg'] != null) {
                jQuery('#myModal').modal('hide');

                jQuery(window.document.location).attr('href', '../../Login.aspx?cod=300');

                return;
            } else {

            var ferias = eval(data);


            if (ferias != undefined && ferias.length > 0) {

                jQuery('#myModal').modal('hide');

                
                jQuery('#dyntable').DataTable().row().remove().draw(false);
                // do some other stuff here
                jQuery.alerts.dialogClass = 'alert-success';
                jAlert('Item foi gravado', 'Informação', function () {
                    jQuery.alerts.dialogClass = null; // reset to default
                });
                
                for (var x in ferias) {

                    jQuery('#dyntable').DataTable().row.add([
                            ferias[x].CODIGO_FERIAS,
                            ferias[x].DATA_PERIODO_INICIO,
                            ferias[x].DATA_PERIODO_FIM,
                            ferias[x].DATA_GOZADA_INICIO,
                            ferias[x].DATA_GOZADA_FIM,
                            '<a title="Alterar" href="#myModal" onclick="javascript:FuncaoTelaModal(\'Alterar\', ' + ferias[x].CODIGO_FERIAS + ');" data-toggle="modal"><i class="iconfa-pencil"></i></a>',
                            '<a title="Excluir" href="javascript:ExcluirFerias(' + ferias[x].CODIGO_FERIAS + ')" class="deleterow"><i class="icon-trash"></i></a>'
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

function ExcluirFerias(id) {

    var idUser = getUrlVars()["idUser"];

    

    jQuery.ajax({
        type: "GET",
        crossDomain: true,
        url: "../../Handler/ManterFerias.ashx",
        contentType: "json",
        cache: false,
        data: {
            Metodo: 'Excluir',
            Acao: 'Excluir',
            CodigoFerias: id,
            CodigoFuncionario: idUser
        },
        success: function (data) {
            if (data['Msg'] != null) {
                jQuery('#myModal').modal('hide');

                jQuery(window.document.location).attr('href', '../../Login.aspx?cod=300');
            
                return;
            } else {
            var ferias = eval(data);


            if (ferias != undefined && ferias.length > 0) {

                jQuery('#dyntable').DataTable().row('.selected').remove().draw(false);
                // do some other stuff here
                jQuery.alerts.dialogClass = 'alert-success';
                jAlert('Item foi excluido', 'Informação', function () {
                    jQuery.alerts.dialogClass = null; // reset to default
                });

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