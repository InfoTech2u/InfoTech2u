jQuery(document).ready(function () {

    jQuery('#hdnCodigoFuncionario').val(getUrlVars()["idUser"]);
    CarregarDependentes();

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

    jQuery(".btnVoltar").click(function (event) {
        event.preventDefault();
        history.back(1);
    });

    //Data dataddmmaaaa
    jQuery(".dataddmmaaaa").mask("99/99/9999");
    jQuery(".txtDataFilMesAno").datepicker({
        defaultDate: new Date(),
        dateFormat: 'dd/mm/yy',
        changeMonth: true,
        changeYear: true,
        yearRange: '-100y:c+nn'
    });

    // Dual Box Select
    var db = jQuery('#dualselect').find('.ds_arrow a');	//get arrows of dual select
    var sel1 = jQuery('#dualselect select:first-child');		//get first select element
    var sel2 = jQuery('#dualselect select:last-child');			//get second select element
    sel2.empty(); //empty it first from dom.

    db.click(function () {
        var t = (jQuery(this).hasClass('ds_prev')) ? 0 : 1;	// 0 if arrow prev otherwise arrow next
        if (t) {
            sel1.find('option').each(function () {
                if (jQuery(this).is(':selected')) {
                    jQuery(this).attr('selected', false);
                    var op = sel2.find('option:first-child');
                    sel2.append(jQuery(this));
                }
            });
        } else {
            sel2.find('option').each(function () {
                if (jQuery(this).is(':selected')) {
                    jQuery(this).attr('selected', false);
                    sel1.append(jQuery(this));
                }
            });
        }
        return false;
    });
});

function CarregarDependentes() {
    if (jQuery('#hdnCodigoFuncionario').val() != undefined && jQuery('#hdnCodigoFuncionario').val() != 0) {
        jQuery.ajax({
            type: "GET",
            crossDomain: true,
            url: "../../Handler/Dependente.ashx",
            contentType: "json",
            cache: false,
            data: {
                Metodo: 'Listar',
                Acao: 'Selecionar',
                CodigoFuncionario: jQuery('#hdnCodigoFuncionario').val()
            },
            success: function (data) {
                var dependentes = eval(data);
                if (dependentes['Msg'] != null) {
                    jQuery('#myModal').modal('hide');

                    jQuery(window.document.location).attr('href', '../../Login.aspx?cod=300');

                    return;
                } else {

                if (dependentes != undefined && dependentes.length > 0) {
                    jQuery('#ddlTipoParentesco').append('<option value="0">Escolha</option>');
                    for (var x in dependentes) {
                            jQuery('#dyntable').DataTable().row.add([
                               dependentes[x].CODIGO_DEPENDENTE,
                               dependentes[x].NOME,
                               dependentes[x].TIPO_PARENTESCO_DESC,
                               dependentes[x].DATA_NASCIMENTO_STR,
                               '<a style="align: center;" title="Detalhar" href="#modalDependente" onclick="javascript:FuncaoTelaModal(\'Detalhar\', ' + dependentes[x].CODIGO_DEPENDENTE + ');" data-toggle="modal"><i class="iconfa-pencil"></i></a>',
                               '<a style="align: center;" title="Alterar" href="#modalDependente" onclick="javascript:FuncaoTelaModal(\'Alterar\', ' + dependentes[x].CODIGO_DEPENDENTE + ');" data-toggle="modal"><i class="iconfa-pencil"></i></a>',
                               '<a style="align: center;" title="Excluir" href="javascript:Excluir(' + dependentes[x].CODIGO_DEPENDENTE + ')" class="deleterow"><i class="icon-trash"></i></a>'
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

function CarregarCombos(id) {
    jQuery.ajax({
        type: "GET",
        crossDomain: true,
        url: "../../Handler/TipoParentesco.ashx",
        contentType: "json",
        cache: false,
        data: {
            Metodo: 'Listar',
            Acao: 'Selecionar'
        },
        success: function (data) {
            if (data['Msg'] != null) {
                jQuery('#myModal').modal('hide');

                jQuery(window.document.location).attr('href', '../../Login.aspx?cod=300');

                return;
            } else {
            var lstparentesco = eval(data);
            jQuery('#ddlTipoParentesco').append("<option value=\"0\">Escolha</option>");
            if (lstparentesco != undefined && lstparentesco.length > 0) {
                for (var x in lstparentesco) {
                    var row = "<option value=\"" + lstparentesco[x].CodigoTipoParentesco + "\">" + lstparentesco[x].Descricao + "</option>";
                    jQuery('#ddlTipoParentesco').append(row);
                }

                CarregarListaTiposBeneficios(id);
            }
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrow) {
            errorAjax(textStatus);
            alert(textStatus);
        }
    });
}

function CarregarListaTiposBeneficios(id) {
    jQuery.ajax({
        type: "GET",
        crossDomain: true,
        url: "../../Handler/TipoBeneficio.ashx",
        contentType: "json",
        cache: false,
        data: {
            Metodo: 'Listar',
            Acao: 'Selecionar'
        },
        success: function (data) {
            if (data['Msg'] != null) {
                jQuery('#myModal').modal('hide');

                jQuery(window.document.location).attr('href', '../../Login.aspx?cod=300');

                return;
            } else {
            var lstbeneficio = eval(data);
            jQuery('#lstBeneficioSelected option').remove();
            if (lstbeneficio != undefined && lstbeneficio.length > 0) {
                for (var x in lstbeneficio) {
                    var row = "<option value=\"" + lstbeneficio[x].CodigoTipoBeneficio + "\">" + lstbeneficio[x].Descricao + "</option>";
                    jQuery('#lstBeneficioSelect').append(row);
                }

                PrepararTela(id);
            }
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrow) {
            errorAjax(textStatus);
            alert(textStatus);
        }
    });
}

function PrepararTela(id) {
    if (jQuery('#hdnFuncaoTela').val() == 'Incluir') {
        jQuery('#btnIncluir').attr('onclick', 'javascript:Incluir()');
        jQuery('#modalDependenteLabel').text('Cadastro de Dependente');
        jQuery('#txtNomeDependente').val('');
        jQuery('#ddlTipoParentesco').val(0);
        jQuery('#txtDataNascimento').val('');
    }
    else (jQuery('#hdnFuncaoTela').val() == 'Alterar')
    {
        CarregarDependente(id);
    }
}

function FuncaoTelaModal(funcao, id) {
    jQuery('#ddlTipoParentesco option').remove();
    jQuery('#lstBeneficioSelect option').remove();


    if (funcao == 'Incluir') {
        jQuery('#hdnFuncaoTela').val('Incluir');

        jQuery('#txtNomeDependente').attr('readonly', false);
        jQuery('#txtDataNascimento').attr('readonly', false);

        jQuery("#ddlTipoParentesco").prop("disabled", false);
        jQuery("#lstBeneficioSelect").prop("disabled", false);
        jQuery("#lstBeneficioSelected").prop("disabled", false);
        jQuery(".ds_prev").prop("disabled", false);
        jQuery(".ds_next").prop("disabled", false);
        jQuery("#btnIncluir").prop("disabled", false);

    }
    else if (funcao == 'Alterar') {
        jQuery('#hdnFuncaoTela').val('Alterar');

        jQuery('#txtNomeDependente').attr('readonly', false);
        jQuery('#txtDataNascimento').attr('readonly', false);

        jQuery("#ddlTipoParentesco").prop("disabled", false);
        jQuery("#lstBeneficioSelect").prop("disabled", false);
        jQuery("#lstBeneficioSelected").prop("disabled", false);
        jQuery(".ds_prev").prop("disabled", false);
        jQuery(".ds_next").prop("disabled", false);
        jQuery("#btnIncluir").prop("disabled", false);
    }
    else if (funcao == 'Detalhar') {
        jQuery('#hdnFuncaoTela').val('Detalhar');

        jQuery('#txtNomeDependente').attr('readonly', true);
        jQuery('#txtDataNascimento').attr('readonly', true);

        jQuery("#ddlTipoParentesco").prop("disabled", true);
        jQuery("#lstBeneficioSelect").prop("disabled", true);
        jQuery("#lstBeneficioSelected").prop("disabled", true);
        jQuery(".ds_prev").prop("disabled", true);
        jQuery(".ds_next").prop("disabled", true);
        jQuery("#btnIncluir").prop("disabled", true);


    }
    else { jQuery('#hdnFuncaoTela').val(''); }

    CarregarCombos(id);
}

function CarregarDependente(id) {
    jQuery.ajax({
        type: "GET",
        crossDomain: true,
        url: "../../Handler/Dependente.ashx",
        contentType: "json",
        cache: false,
        data: {
            Metodo: 'Selecionar',
            Acao: 'Selecionar',
            CodigoDependente: id
        },
        success: function (data) {
            var dependente = eval(data);

            if (data['Msg'] != null) {
                jQuery('#myModal').modal('hide');

                jQuery(window.document.location).attr('href', '../../Login.aspx?cod=300');

                return;
            } else {
            if (dependente != undefined && dependente.length > 0) {

                    if (dependente[0].Mensagem == undefined) {
                jQuery('#txtNomeDependente').val(dependente[0].NOME);
                jQuery('#ddlTipoParentesco').val(dependente[0].CODIGO_TIPO_PARENTESCO);
                jQuery('#txtDataNascimento').val(dependente[0].DATA_NASCIMENTO_STR);


                for (var x in dependente) {
                    var row = jQuery('#lstBeneficioSelect option[value=' + dependente[x].CODIGO_TIPO_BENEFICIO + ']')
                    jQuery('#lstBeneficioSelect option[value=' + dependente[x].CODIGO_TIPO_BENEFICIO + ']').remove();
                    jQuery('#lstBeneficioSelected').append(row);
                }

                jQuery('#btnIncluir').attr('onclick', 'javascript:Alterar(' + id + ');');
                jQuery('#modalDependenteLabel').text('Alteração de Dependente');
                    }
                    else {
                        jQuery.alerts.dialogClass = 'alert-danger';
                        jAlert(dependente[0].Mensagem, 'Alerta', function () {
                            jQuery.alerts.dialogClass = null; // reset to default
                        });
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

function DadosValidos() {
    var valido = true;

    if (jQuery('#txtNomeDependente').val() == "") {
        jQuery('#lblErrorNomeDependente').show();
        valido = false;
    }
    else { jQuery('#lblErrorNomeDependente').hide(); }

    if (jQuery('#ddlTipoParentesco').val() == 0) {
        jQuery('#lblErrorTipoParentesco').show();
        valido = false;
    }
    else { jQuery('#lblErrorTipoParentesco').hide(); }

    if (jQuery('#txtDataNascimento').val() != "") {
        if (!isDate(jQuery('#txtDataNascimento').val(), '/', 0, 1, 2)) {
            jQuery('#lblErrorDataNascimento').show();
            valido = false;
        }
        else {
            jQuery('#lblErrorDataNascimento').hide();
        }
    }


    return valido;
};

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

function Incluir() {

    if (DadosValidos()) {
        var selected = jQuery('#lstBeneficioSelected option');
        var arraySel = '';

        if (selected.length > 0) {
            for (var i = 0; i < selected.length; i++) {
                arraySel += selected[i].value + '|';
            }
        }

        jQuery.ajax({
            type: "GET",
            crossDomain: true,
            url: "../../Handler/Dependente.ashx",
            contentType: "json",
            cache: false,
            data: {
                Metodo: 'Incluir',
                Acao: 'Inclusao',
                Nome: jQuery('#txtNomeDependente').val(),
                TipoParentesco: jQuery('#ddlTipoParentesco').val(),
                DataNascimento: jQuery('#txtDataNascimento').val(),
                CodigoFuncionario: jQuery('#hdnCodigoFuncionario').val(),
                Beneficios: arraySel
            },
            success: function (data) {
                var dependentes = eval(data);

                if (dependentes['Msg'] != null) {
                    jQuery('#myModal').modal('hide');

                    jQuery(window.document.location).attr('href', '../../Login.aspx?cod=300');

                    return;
                } else {

                    if (dependentes[0].Erro != null) {
                        jQuery.alerts.dialogClass = 'alert-danger';
                        jAlert(dependentes[0].Mensagem, 'Alerta', function () {
                            jQuery.alerts.dialogClass = null; // reset to default
                        });
                    } else {

                        if (dependentes.length > 0) {
                            jQuery('#dyntable').DataTable().row.add([
                              dependentes[0].CODIGO_DEPENDENTE,
                              dependentes[0].NOME,
                              dependentes[0].TIPO_PARENTESCO_DESC,
                              dependentes[0].DATA_NASCIMENTO_STR,
                              '<a style="align: center;" title="Detalhar" href="#modalDependente" onclick="javascript:FuncaoTelaModal(\'Detalhar\', ' + dependentes[0].CODIGO_DEPENDENTE + ');" data-toggle="modal"><i class="iconfa-pencil"></i></a>',
                              '<a style="align: center;" title="Alterar" href="#modalDependente" onclick="javascript:FuncaoTelaModal(\'Alterar\', ' + dependentes[0].CODIGO_DEPENDENTE + ');" data-toggle="modal"><i class="iconfa-pencil"></i></a>',
                              '<a style="align: center;" title="Excluir" href="javascript:Excluir(' + dependentes[0].CODIGO_DEPENDENTE + ')" class="deleterow"><i class="icon-trash"></i></a>'
                            ]).draw();

                            //Sucesso
                            jQuery.alerts.dialogClass = 'alert-success';
                            jAlert('Item foi incluído', 'Informação', function () {
                                jQuery.alerts.dialogClass = null; // reset to default
                            });

                            jQuery('#modalDependente').modal('hide');
                }
                else {
                            jQuery.alerts.dialogClass = 'alert-danger';
                            jAlert('Inclusão não foi realizada.', 'Alerta', function () {
                                jQuery.alerts.dialogClass = null; // reset to default
                            });

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

function Alterar(id) {
    if (DadosValidos()) {
        var selected = jQuery('#lstBeneficioSelected option');
        var arraySel = '';

        if (selected.length > 0) {
            for (var i = 0; i < selected.length; i++) {
                arraySel += selected[i].value + '|';
            }
        }

        jQuery.ajax({
            type: "GET",
            crossDomain: true,
            url: "../../Handler/Dependente.ashx",
            contentType: "json",
            cache: false,
            data: {
                Metodo: 'Alterar',
                Acao: 'Alteracao',
                Nome: jQuery('#txtNomeDependente').val(),
                TipoParentesco: jQuery('#ddlTipoParentesco').val(),
                DataNascimento: jQuery('#txtDataNascimento').val(),
                CodigoDependente: id,
                Beneficios: arraySel
            },
            success: function (data) {
                if (data['Msg'] != null) {
                    jQuery('#myModal').modal('hide');

                    jQuery(window.document.location).attr('href', '../../Login.aspx?cod=300');

                    return;
                } else {

                var dependente = eval(data);

                if (dependente != undefined && dependente.length > 0) {
                    jQuery('#dyntable').DataTable().row('.selected').remove().draw(false);

                    jQuery('#dyntable').DataTable().row.add([
                              dependente[0].CODIGO_DEPENDENTE,
                              dependente[0].NOME,
                              dependente[0].TIPO_PARENTESCO_DESC,
                              dependente[0].DATA_NASCIMENTO_STR,
                              '<a style="align: center;" title="Detalhar" href="#modalDependente" onclick="javascript:FuncaoTelaModal(\'Detalhar\', ' + dependente[0].CODIGO_DEPENDENTE + ');" data-toggle="modal"><i class="iconfa-pencil"></i></a>',
                              '<a style="align: center;" title="Alterar" href="#modalDependente" onclick="javascript:FuncaoTelaModal(\'Alterar\', ' + dependente[0].CODIGO_DEPENDENTE + ');" data-toggle="modal"><i class="iconfa-pencil"></i></a>',
                              '<a style="align: center;" title="Excluir" href="javascript:Excluir(' + dependente[0].CODIGO_DEPENDENTE + ')" class="deleterow"><i class="icon-trash"></i></a>'
                    ]).draw();

                    jQuery('#modalDependente').modal('hide')
                }
                else {
                    jQuery.alerts.dialogClass = 'alert-info';
                    jAlert('Item não foi alterado', 'Informação', function () {
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
}

function Excluir(id) {

    //Confirmação
    jConfirm('Deseja excluir o item selecionado?', 'Confirmation Dialog', function (r) {
        if (r == true) {

            jQuery.ajax({
                type: "GET",
                crossDomain: true,
                url: "../../Handler/Dependente.ashx",
                contentType: "json",
                cache: false,
                data: {
                    Metodo: 'Excluir',
                    Acao: 'Exclusao',
                    CodigoDependente: id
                },
                success: function (data) {


                    var lista = eval(data);

                    if (lista['Msg'] != null) {
                        jQuery('#myModal').modal('hide');

                        jQuery(window.document.location).attr('href', '../../Login.aspx?cod=300');

                        return;
                    } else {
                        if (lista != null && lista[0] != undefined) {
                            jQuery.alerts.dialogClass = 'alert-danger';
                            jAlert(lista[0].Mensagem, 'Alerta', function () {
                                jQuery.alerts.dialogClass = null; // reset to default
                            });
                        } else {
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
        else if (r == false) {
            jQuery.alerts.dialogClass = 'alert-info';
            jAlert('Item não foi excluido', 'Informação', function () {
                jQuery.alerts.dialogClass = null; // reset to default
            });
        }
    });

    
}

function isDate(value, sepVal, dayIdx, monthIdx, yearIdx) {
    try {
        //Change the below values to determine which format of date you wish to check. It is set to dd/mm/yyyy by default.
        var DayIndex = dayIdx !== undefined ? dayIdx : 0;
        var MonthIndex = monthIdx !== undefined ? monthIdx : 0;
        var YearIndex = yearIdx !== undefined ? yearIdx : 0;

        value = value.replace(/-/g, "/").replace(/\./g, "/");
        var SplitValue = value.split(sepVal || "/");
        var OK = true;
        if (!(SplitValue[DayIndex].length == 1 || SplitValue[DayIndex].length == 2)) {
            OK = false;
        }
        if (OK && !(SplitValue[MonthIndex].length == 1 || SplitValue[MonthIndex].length == 2)) {
            OK = false;
        }
        if (OK && SplitValue[YearIndex].length != 4) {
            OK = false;
        }
        if (OK) {
            var Day = parseInt(SplitValue[DayIndex], 10);
            var Month = parseInt(SplitValue[MonthIndex], 10);
            var Year = parseInt(SplitValue[YearIndex], 10);

            if (OK = ((Year > 1900) && (Year <= new Date().getFullYear()))) {
                if (OK = (Month <= 12 && Month > 0)) {

                    var LeapYear = (((Year % 4) == 0) && ((Year % 100) != 0) || ((Year % 400) == 0));

                    if (OK = Day > 0) {
                        if (Month == 2) {
                            OK = LeapYear ? Day <= 29 : Day <= 28;
                        }
                        else {
                            if ((Month == 4) || (Month == 6) || (Month == 9) || (Month == 11)) {
                                OK = Day <= 30;
                            }
                            else {
                                OK = Day <= 31;
                            }
                        }
                    }
                }
            }
        }
        return OK;
    }
    catch (e) {
        return false;
    }
}


