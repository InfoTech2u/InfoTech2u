jQuery(document).ready(function () {
    jQuery('#hdnCodigoFuncionario').val(getUrlVars()["idUser"]);

    jQuery(".btnVoltar").click(function (event) {
        event.preventDefault();
        history.back(1);
    });

    CarregarMascaras();
    CarregarSindicatoLista();
    CarregarContribuicaoExistente();
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

function CarregarMascaras() {
    jQuery("#datepicker").mask("99/99/9999");
    jQuery("#txtVlrContribuicao").maskMoney({ showSymbol: true, symbol: "R$", decimal: ",", thousands: "." });

    jQuery("#datepicker").datepicker({
        defaultDate: new Date(),
        dateFormat: 'dd/mm/yy',
        changeMonth: true,
        changeYear: true,
        yearRange: '-100y:c+nn'
    });
    
    /*
    jQuery("#datepicker").datepicker({
        defaultDate: new Date(),
        dateFormat: 'dd/mm/yy',
        changeMonth: true,
        changeYear: true,
        yearRange: '-100y:c+nn'
        
    });*/
}

function CarregarSindicatoLista() {

    jQuery.ajax({
        type: "GET",
        crossDomain: true,
        url: "../../Handler/ManterSindicato.ashx",
        contentType: "json",
        cache: false,
        data: {
            Metodo: 'Lista',
            Acao: 'Consulta'
        },
        success: function (data) {

            var lista = eval(data);
            jQuery('#ddlSindicato').append("<option value='0'>Escolha</option>");
            for (x in lista) {
                var row = "<option value='" + lista[x].CodigoSindicato + "'>" + lista[x].Nome + "</option>";
                jQuery('#ddlSindicato').append(row);
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrow) {
            errorAjax(textStatus);
            alert(textStatus);
        }
    });
}

function CarregarContribuicaoExistente() {

    var codFunc = jQuery('#hdnCodigoFuncionario').val();

    jQuery.ajax({
        type: "GET",
        crossDomain: true,
        url: "../../Handler/ManterContribuicaoSindical.ashx",
        contentType: "json",
        cache: false,
        data: {
            Metodo: 'SelecionarContribuicaoFuncionario',
            Acao: 'Inclusao',
            CodigoFuncionario: codFunc
        },
        success: function (data) {

            var lista = eval(data);

            if (lista.length > 0) {
                jQuery('#hdnCodigoFuncionario').val(lista[0].CODIGO_FUNCIONARIO);
                jQuery('#hdnCodigoContribuicaoSindical').val(lista[0].CODIGO_CONTRIBUICAO_SINDICAL);
                jQuery('#datepicker').val(lista[0].PERIODO_ANO_STR);
                jQuery('#ddlSindicato option[value="' + lista[0].CODIGO_SINDICATO + '"]').prop('selected', true);
                jQuery('#txtVlrContribuicao').val(lista[0].VALOR_RECOLHIDO)
                CarregarMascaras();
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrow) {
            errorAjax(textStatus);
            alert(textStatus);
        }
    });
}

function Incluir() {
    var metodo = "";
    var acao = "";

    if (!DadosValidos()) {
        return;
    }

    if (jQuery('#hdnCodigoContribuicaoSindical').val() > 0) {
        metodo = "Alterar";
        acao = "Alteracao"
    }
    else {
        metodo = "Incluir";
        acao = "Imclusao"
    }

    jQuery.ajax({
        type: "GET",
        crossDomain: true,
        url: "../../Handler/ManterContribuicaoSindical.ashx",
        contentType: "json",
        cache: false,
        data: {
            Metodo: metodo,
            Acao: acao,
            CodigoUsuario: jQuery('#hdnCodigoUsuario').val(),
            CodigoFuncionario: jQuery('#hdnCodigoFuncionario').val(),
            CodigoContribuicaoSindical: jQuery('#hdnCodigoContribuicaoSindical').val(),
            PeriodoAno: jQuery('#datepicker').val(),
            CodigoSindicato: jQuery('#ddlSindicato').val(),
            ValorRecolhido: jQuery('#txtVlrContribuicao').val()
        },
        success: function (data) {

            var lista = eval(data);
            if (lista != undefined && lista.length > 0) {
                history.back(1);
            }
            else {
                jAlert('Contribuição Sindical não foi gravada.', 'Alerta', function () {
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

function Excluir() {
    if (!DadosValidos()) {
        return;
    }

    jQuery.ajax({
        type: "GET",
        crossDomain: true,
        url: "../../Handler/ManterContribuicaoSindical.ashx",
        contentType: "json",
        cache: false,
        data: {
            Metodo: 'Excluir',
            Acao: 'Exclusao',
            CodigoUsuario: jQuery('#hdnCodigoUsuario').val(),
            CodigoContribuicaoSindical: jQuery('#hdnCodigoContribuicaoSindical').val()
        },
        success: function (data) {
            if (data) {
                Limpar();
                history.back(1);
            }
            else {
                jAlert('Contribuição Sindical não foi excluída.', 'Alerta', function () {
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

function Limpar() {
    jQuery('#hdnCodigoContribuicaoSindical').val(0);
    jQuery('#datepicker').val('');
    jQuery('#ddlSindicato option[value="0"]').prop('selected', true);
    jQuery('#txtVlrContribuicao').val('');
}

function DadosValidos() {
    var semErros = true;

    //if (!isDate(jQuery('#datepicker').val(), '/', 0, 1, 2)) {
    //    jQuery('#lblErrorData').show();
    //    semErros = false;
    //}
    //else {
    //    jQuery('#lblErrorData').hide();
    //}

    if (jQuery('#ddlSindicato').val() == 0) {
        jQuery('#lblErrorSindicato').show();
        semErros = false;
    }
    else {
        jQuery('#lblErrorSindicato').hide();
    }

    return semErros;

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

            if (OK = ((Year > 1900) && (Year < new Date().getFullYear()))) {
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
