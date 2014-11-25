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

    

    CarregarLista();

    jQuery('.horaBrasil').mask('99:99');

    jQuery("#txtSalario").maskMoney({ showSymbol: true, symbol: "R$", decimal: ",", thousands: "." });

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

    jQuery("#btnConcluirAlteracaoCargoSalario").click(function () {

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

function CarregarLista() {

   

    jQuery.ajax({
        type: "GET",
        crossDomain: true,
        url: "../../Handler/ManterCargo.ashx",
        contentType: "json",
        cache: false,
        data: {
            Metodo: 'Lista',
            Acao: 'Consulta'
        },
        success: function (data) {
            if (data['Msg'] != null) {
                jQuery('#myModal').modal('hide');

                jQuery(window.document.location).attr('href', '../../Login.aspx?cod=300');

                return;
            } else {

                
                /**/
                var lstTipoCargo = eval(data);
                jQuery('#ddlCargo').append("<option value=\"0\">Escolha</option>");
                if (lstTipoCargo != undefined && lstTipoCargo.length > 0) {
                    for (var x in lstTipoCargo) {
                        var row = "<option value=\"" + lstTipoCargo[x].CodigoTipoCargo + "\">" + lstTipoCargo[x].Descricao + "</option>";
                        jQuery('#ddlCargo').append(row);
                    }

                    //CarregarListaTiposBeneficios(id);
                }
                /**/
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrow) {
            errorAjax(textStatus);
            alert(textStatus);
        }
    });
}

function Incluir() {

    //alert('Teste');

    jQuery('#btnConcluirAcidente').attr('onclick', 'javascript:Incluir()');
    jQuery('#myModalLabel').text('Cadastro de Alteração de Cargo e Salario');

    jQuery('#txtCodigoAlteracaoCargoSalario').val('');

    jQuery('#txtData').val('');
    jQuery('#txtSalario').val('');
    jQuery('#txtHorarioEntrada').val('');
    jQuery('#txtHorarioSaida').val('');
    
    jQuery('#ddlCargo').val('');
}

function PrepararTela(id) {

    if (jQuery('#hdnFuncaoTela').val() == 'Incluir') {
        jQuery('#btnConcluirAcidente').attr('onclick', 'javascript:Incluir()');
        jQuery('#myModalLabel').text('Cadastro de Alteração de Cargo e Salario');

        jQuery('#txtCodigoAlteracaoCargoSalario').val('');

        jQuery('#txtData').val('');
        jQuery('#txtSalario').val('');
        jQuery('#txtHorarioEntrada').val('');
        jQuery('#txtHorarioSaida').val('');
        
        jQuery('#ddlCargo').val('');
    }
    else (jQuery('#hdnFuncaoTela').val() == 'Alterar')
    {
        CarregarAcidentesFormulario(id);
    }
}

function FuncaoTelaModal(funcao, id) {

    if (funcao == 'Incluir') {
        jQuery('#hdnFuncaoTela').val('Incluir');

        jQuery('#txtCodigoAlteracaoCargoSalario').attr('readonly', false);
        jQuery('#txtData').attr('readonly', false);
        jQuery('#ddlCargo').attr('readonly', false);
        jQuery('#txtSalario').attr('readonly', false);
        jQuery('#txtHorarioEntrada').attr('readonly', false);
        jQuery('#txtHorarioSaida').attr('readonly', false);

        jQuery("#btnConcluirAlteracaoCargoSalario").prop("disabled", false);

    }
    else if (funcao == 'Alterar') {
        jQuery('#hdnFuncaoTela').val('Alterar');

        jQuery('#txtCodigoAlteracaoCargoSalario').attr('readonly', false);
        jQuery('#txtData').attr('readonly', false);
        jQuery('#ddlCargo').attr('readonly', false);
        jQuery('#txtSalario').attr('readonly', false);
        jQuery('#txtHorarioEntrada').attr('readonly', false);
        jQuery('#txtHorarioSaida').attr('readonly', false);

        jQuery("#btnConcluirAlteracaoCargoSalario").prop("disabled", false);

        PrepararTela(id)


    }
    else { jQuery('#hdnFuncaoTela').val(''); }
}

function CarregarAcidentesFormulario(id) {

    var idUser = getUrlVars()["idUser"];

    jQuery.ajax({
        type: "GET",
        crossDomain: true,
        url: "../../Handler/ManterAlteracaoCargoSalariorFuncionario.ashx",
        contentType: "json",
        cache: false,
        data: {
            Metodo: 'Selecionar',
            Acao: 'Selecionar',
            CodigoFuncionario: idUser,
            CodigoAlteracaoCargoSalario: id
        },
        success: function (data) {
            if (data['Msg'] != null) {
                jQuery('#myModal').modal('hide');

                jQuery(window.document.location).attr('href', '../../Login.aspx?cod=300');

                return;
            } else {
                var Acidente = eval(data);


                if (Acidente != undefined && Acidente.length > 0) {

                    jQuery('#txtCodigoAlteracaoCargoSalario').val(Acidente[0].CODIGO_ALTERACAO_CARGO_SALARIO);
                    jQuery('#txtData').val(Acidente[0].DATA);
                    //jQuery('#ddlTipoParentesco').val(dependente[0].CODIGO_TIPO_PARENTESCO);
                    jQuery('#ddlCargo').val(Acidente[0].CODIGO_TIPO_CARGO);
                    jQuery('#txtSalario').val(Acidente[0].SALARIO);
                    jQuery('#txtHorarioEntrada').val(Acidente[0].HORARIO_INICIO);
                    jQuery('#txtHorarioSaida').val(Acidente[0].HORARIO_FIM);
                    
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
            url: "../../Handler/ManterAlteracaoCargoSalariorFuncionario.ashx",
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
                                Acidente[x].CODIGO_ALTERACAO_CARGO_SALARIO,
                                Acidente[x].DATA,
                                Acidente[x].TIPO_CARGO_DESCRICAO,
                                Acidente[x].SALARIO,
                                '<a title="Alterar" href="#myModal" onclick="javascript:FuncaoTelaModal(\'Alterar\', ' + Acidente[x].CODIGO_ALTERACAO_CARGO_SALARIO + ');" data-toggle="modal"><i class="iconfa-pencil"></i></a>',
                                '<a title="Excluir" href="javascript:ExcluirFerias(' + Acidente[x].CODIGO_ALTERACAO_CARGO_SALARIO + ')" class="deleterow"><i class="icon-trash"></i></a>'
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

    alert('1');

    var idUser = getUrlVars()["idUser"];

    jQuery.ajax({
        type: "GET",
        crossDomain: true,
        url: "../../Handler/ManterAlteracaoCargoSalariorFuncionario.ashx",
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
                                Acidente[x].CODIGO_ALTERACAO_CARGO_SALARIO,
                                Acidente[x].DATA,
                                Acidente[x].TIPO_CARGO_DESCRICAO,
                                Acidente[x].SALARIO,
                                '<a title="Alterar" href="#myModal" onclick="javascript:FuncaoTelaModal(\'Alterar\', ' + Acidente[x].CODIGO_ALTERACAO_CARGO_SALARIO + ');" data-toggle="modal"><i class="iconfa-pencil"></i></a>',
                                '<a title="Excluir" href="javascript:ExcluirFerias(' + Acidente[x].CODIGO_ALTERACAO_CARGO_SALARIO + ')" class="deleterow"><i class="icon-trash"></i></a>'
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