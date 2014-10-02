jQuery(document).ready(function () {

    jQuery('#hdnCodigoFuncionario').val(getUrlVars()["idUser"]);
    CarregarDependentes();

    //Data dataddmmaaaa
    jQuery(".dataddmmaaaa").mask("99/99/9999");

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

function MontarGrid()
{
    //jQuery('#gridDependentes').dataTable().fnDestroy();
    //// dynamic table
    //jQuery('#gridDependentes').dataTable({
    //    "sPaginationType": "full_numbers",
    //    "aaSortingFixed": [[0, 'asc']],
    //    "fnDrawCallback": function (oSettings) {
    //        jQuery.uniform.update();
    //    }
    //});
}

function CarregarDependentes()
{
    if (jQuery('#hdnCodigoFuncionario').val() != undefined && jQuery('#hdnCodigoFuncionario').val() != 0)
    {
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


                if (dependentes != undefined && dependentes.length > 0) {
                    jQuery('#ddlTipoParentesco').append('<option value="0">Escolha</option>');
                    for (var x in dependentes) {

                        var row = '<tr value="' + dependentes[x].CODIGO_DEPENDENTE + '">' +
                               '<td>' + dependentes[x].NOME + '</td>' +
                               '<td>' + dependentes[x].TIPO_PARENTESCO_DESC + '</td>' +
                               '<td>' + dependentes[x].DATA_NASCIMENTO_STR + '</td>' +
                               '<td class="centeralign"><a title="Alterar" href="#modalDependente" onclick="javascript:FuncaoTelaModal(\'Alterar\', ' + dependentes[x].CODIGO_DEPENDENTE + ');" data-toggle="modal"><i class="iconfa-pencil"></i></a></td>' +
                               '<td class="centeralign"><a title="Excluir" href="javascript:Excluir(' + dependentes[x].CODIGO_DEPENDENTE + ')" class="deleterow"><i class="icon-trash"></i></a></td>' +
                             '</tr>';
                        jQuery('#gridDependentes').append(row);
                    }

                    }

                MontarGrid();
            },
            error: function (XMLHttpRequest, textStatus, errorThrow) {
                errorAjax(textStatus);
                alert(textStatus);
            }
        });
                    }
}

function CarregarCombos(id)
{
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
            var lstparentesco = eval(data);
            jQuery('#ddlTipoParentesco').append("<option value=\"0\">Escolha</option>");
            if (lstparentesco != undefined && lstparentesco.length > 0) {
                for (var x in lstparentesco) {
                    var row = "<option value=\"" + lstparentesco[x].CodigoTipoParentesco + "\">" + lstparentesco[x].Descricao + "</option>";
                    jQuery('#ddlTipoParentesco').append(row);
                }

                CarregarListaTiposBeneficios(id);
            }
                },
                error: function (XMLHttpRequest, textStatus, errorThrow) {
                    errorAjax(textStatus);
                    alert(textStatus);
                }
            });
        }

function CarregarListaTiposBeneficios(id)
{
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
            var lstbeneficio = eval(data);
            jQuery('#lstBeneficioSelected option').remove();
            if (lstbeneficio != undefined && lstbeneficio.length > 0)
            {
                for (var x in lstbeneficio)
                {
                    var row = "<option value=\"" + lstbeneficio[x].CodigoTipoBeneficio + "\">" + lstbeneficio[x].Descricao + "</option>";
                    jQuery('#lstBeneficioSelect').append(row);
                }

                PrepararTela(id);
            }
            
        },
        error: function (XMLHttpRequest, textStatus, errorThrow) {
            errorAjax(textStatus);
            alert(textStatus);
        }
    });
}

function PrepararTela(id)
{
    if (jQuery('#hdnFuncaoTela').val() == 'Incluir')
    {
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

    }
    else if (funcao == 'Alterar') {
        jQuery('#hdnFuncaoTela').val('Alterar');
    }
    else { jQuery('#hdnFuncaoTela').val(''); }

    CarregarCombos(id);
}

function CarregarDependente(id)
{
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

            if (dependente != undefined && dependente.length > 0) {
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
        },
        error: function (XMLHttpRequest, textStatus, errorThrow) {
            errorAjax(textStatus);
            alert(textStatus);
    }
    });
}

function Incluir() {

    if (DadosValidos()) {
        var selected = jQuery('#lstBeneficioSelected option');
        var arraySel = '';

        if(selected.length > 0)
        {
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

                var dependente = eval(data);

                if(dependente != undefined && dependente.length > 0)
                {
                    var row = '<tr value="' + dependente[0].CODIGO_DEPENDENTE + '">' +
                               '<td>' + dependente[0].NOME + '</td>' +
                               '<td>' + dependente[0].TIPO_PARENTESCO_DESC + '</td>' +
                               '<td>' + dependente[0].DATA_NASCIMENTO_STR + '</td>' +
                               '<td class="centeralign"><a title="Alterar" href="#modalDependente" onclick="javascript:FuncaoTelaModal(\'Alterar\', ' + dependente[0].CODIGO_DEPENDENTE + ');" data-toggle="modal"><i class="iconfa-pencil"></i></a></td>' +
                               '<td class="centeralign"><a title="Excluir" href="javascript:Excluir(' + dependente[0].CODIGO_DEPENDENTE + ')" class="deleterow"><i class="icon-trash"></i></a></td>' +
                             '</tr>';

                    jQuery('#gridDependentes').append(row);

                    MontarGrid();
                    jQuery('#modalDependente').modal('hide')
                }
                else {
                    alert("Não foi possível incluir.");
                }
            },
            error: function (XMLHttpRequest, textStatus, errorThrow) {
                errorAjax(textStatus);
                alert(textStatus);
            }
        });
    }

}

function Alterar(id)
{
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

                var dependente = eval(data);

                if (dependente != undefined && dependente.length > 0) {
                    jQuery('#gridDependentes tr[value=' + id + ']').remove();
                    var row = '<tr value="' + dependente[0].CODIGO_DEPENDENTE + '">' +
                               '<td>' + dependente[0].NOME + '</td>' +
                               '<td>' + dependente[0].TIPO_PARENTESCO_DESC + '</td>' +
                               '<td>' + dependente[0].DATA_NASCIMENTO_STR + '</td>' +
                               '<td class="centeralign"><a title="Alterar" href="#modalDependente" onclick="javascript:FuncaoTelaModal(\'Alterar\', ' + dependente[0].CODIGO_DEPENDENTE + ');" data-toggle="modal"><i class="iconfa-pencil"></i></a></td>' +
                               '<td class="centeralign"><a title="Excluir" onclick="javascript:Excluir(' + dependente[0].CODIGO_DEPENDENTE + ')" class="deleterow"><i class="icon-trash"></i></a></td>' +
                             '</tr>';

                    jQuery('#gridDependentes').append(row);

                    MontarGrid();
                    jQuery('#modalDependente').modal('hide')
                }
                else {
                    alert("Não foi possível alterar.");
                }
            },
            error: function (XMLHttpRequest, textStatus, errorThrow) {
                errorAjax(textStatus);
                alert(textStatus);
            }
        });
    }
}

function Excluir(id)
{
    var conf = confirm('Continue delete?');
    if (conf) {

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

                if (data) {
                    jQuery('#gridDependentes tbody tr[value=' + id + ']').remove();
                    MontarGrid();
                    alert('Concluído.');
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrow) {
            errorAjax(textStatus);
                alert(textStatus);
        }
    });
    }
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
