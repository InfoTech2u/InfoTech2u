jQuery(document).ready(function () {
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

    jQuery('#dyntable_wrapper').hide();
    jQuery('#dyntable').hide();
    jQuery('.dyntable').hide();
    jQuery('.btnAcao').hide();

    //btnLimpar
    jQuery("#btnLimpar").click(function () {


        jQuery('#txtCodigoFuncionario').attr('value', '');
        jQuery('#txtNumeroOrdemMatricula').attr('value', '');
        jQuery('#txtNumeroMatricula').attr('value', '');
        jQuery('#txtNomeFuncionario').attr('value', '');

        jQuery('#dyntable_wrapper').hide();
        jQuery('#dyntable').hide();
        jQuery('.dyntable').hide();
        jQuery('.btnAcao').hide();

        jQuery("tbody").empty();
        jQuery('tbody').remove();

    });

    jQuery("#btnPesquisar").click(function () {
        jQuery('#dyntable_wrapper').show();
        jQuery('#dyntable').show();
        jQuery('.dyntable').show();
        jQuery('.btnAcao').show();

        jQuery.ajax({
            type: "GET",
            url: "../../Handler/PesquisarFuncionario.ashx",
            data: {
                CodigoFuncionario: jQuery('#txtCodigoFuncionario').val(),
                NumeroOrdemMatricula: jQuery('#txtNumeroOrdemMatricula').val(),
                NumeroMatricula: jQuery('#txtNumeroMatricula').val(),
                NomeFuncionario: jQuery('#txtNomeFuncionario').val()
            },
            contentType: "json",
            cache: false,
            success: function (data) {
                if (data['Msg'] != null) {
                    jQuery('#myModal').modal('hide');

                    jQuery(window.document.location).attr('href', '../../Login.aspx?cod=300');

                    return;
                } else {
                    var arrFuncionario = eval(data);

                    for (i in arrFuncionario) {
                        jQuery('#dyntable').DataTable().row.add([
                            '<input type="radio" name="rdbFuncionario" class="rdbFuncionario" value="' + arrFuncionario[i].FUNC_CODIGO_FUNCIONARIO + '" />',                            
                            arrFuncionario[i].FUNC_CODIGO_FUNCIONARIO,
                            arrFuncionario[i].FUNC_NUMERO_ORDEM_MATRICULA,
                            arrFuncionario[i].FUNC_NUMERO_MATRICULA,
                            arrFuncionario[i].FUNC_NOME_FUNCIONARIO                            
                        ]).draw();
                        }
                }
            },
            error: function (XMLHttpRequest, textStatus, errorThrow) {
                errorAjax(textStatus);
            }
        });
        return false;
    });



    //rdbFuncionario
    jQuery("#btnIncluir").click(function () {

        var codigoSel = jQuery('input[name=rdbFuncionario]:checked', '.frmInfotech2u').val();
        jQuery(window.document.location).attr('href', 'ManterFuncionario.aspx?tpAcao=1');

        return false;
    });

    jQuery("#btnAlterar").click(function () {

        var codigoSel = jQuery('input[name=rdbFuncionario]:checked', '.frmInfotech2u').val();
        //jQuery(window.document.location).attr('href', 'ManterFuncionario.aspx?tpAcao=2&idUser=' + codigoSel);
        if (codigoSel != null)
            jQuery(window.document.location).attr('href', 'ManterFuncionario.aspx?tpAcao=2&idUser=' + codigoSel);
        else {
            jQuery.alerts.dialogClass = 'alert-warning';
            jAlert('Selecione um funcionario', 'Alerta', function () {
                jQuery.alerts.dialogClass = null; // reset to default
            });
        }

        return false;
    });

    jQuery("#btnDetalhar").click(function () {

        var codigoSel = jQuery('input[name=rdbFuncionario]:checked', '.frmInfotech2u').val();
        if (codigoSel != null)
            jQuery(window.document.location).attr('href', 'ManterFuncionario.aspx?tpAcao=3&idUser=' + codigoSel);
        else {
            jQuery.alerts.dialogClass = 'alert-warning';
            jAlert('Selecione um funcionario', 'Alerta', function () {
                jQuery.alerts.dialogClass = null; // reset to default
            });
        }

        return false;
    });

    jQuery("#btnExcluir").click(function () {

        var codigoSel = jQuery('input[name=rdbFuncionario]:checked', '.frmInfotech2u').val();

        if (codigoSel != null) {

        jQuery.ajax({
            type: "GET",
            url: "../../Handler/ExcluirFuncionario.ashx",
            data: {
                CodigoFuncionario: codigoSel
            },
            contentType: "json",
            cache: false,
            success: function (data) {
                if (data['Msg'] != null) {
                    jQuery('#myModal').modal('hide');

                    jQuery(window.document.location).attr('href', '../../Login.aspx?cod=300');

                    return;
                } else {
                    var arrFuncionario = eval(data);

                    if (arrFuncionario[0].CodigoErro = '1') {

                            jQuery('#dyntable').DataTable().row('.selected').remove().draw(false);

                        jQuery.alerts.dialogClass = 'alert-warning';
                        jAlert(arrFuncionario[0].Mensagem, 'Mensagem', function () {
                            jQuery.alerts.dialogClass = null; // reset to default
                        });
                    }
                    else if (arrFuncionario[0].CodigoErro = '2') {
                        jQuery.alerts.dialogClass = 'alert-warning';
                        jAlert(arrFuncionario[0].Mensagem, 'Mensagem', function () {
                            jQuery.alerts.dialogClass = null; // reset to default
                        });
                    }

                    //jQuery('#dyntable').dataTable().fnDestroy();


                }
            },
            error: function (XMLHttpRequest, textStatus, errorThrow) {
                errorAjax(textStatus);
            }
        });

        return false;
        } else {
            jQuery.alerts.dialogClass = 'alert-warning';
            jAlert('Selecione um funcionario', 'Alerta', function () {
                jQuery.alerts.dialogClass = null; // reset to default
            });
        }
    });

    jQuery("#btnAdmisao").click(function () {

        var codigoSel = jQuery('input[name=rdbFuncionario]:checked', '.frmInfotech2u').val();
        //jQuery(window.document.location).attr('href', 'ManterAdmissao.aspx?idUser=' + codigoSel);
        if (codigoSel != null)
            jQuery(window.document.location).attr('href', 'ManterAdmissao.aspx?idUser=' + codigoSel);
        else {
            jQuery.alerts.dialogClass = 'alert-warning';
            jAlert('Selecione um funcionario', 'Alerta', function () {
                jQuery.alerts.dialogClass = null; // reset to default
            });
        }

        return false;
    });

    jQuery("#btnDemissao").click(function () {

        var codigoSel = jQuery('input[name=rdbFuncionario]:checked', '.frmInfotech2u').val();
        //jQuery(window.document.location).attr('href', 'ManterDemissao.aspx?idUser=' + codigoSel);
        if (codigoSel != null)
            jQuery(window.document.location).attr('href', 'ManterDemissao.aspx?idUser=' + codigoSel);
        else {
            jQuery.alerts.dialogClass = 'alert-warning';
            jAlert('Selecione um funcionario', 'Alerta', function () {
                jQuery.alerts.dialogClass = null; // reset to default
            });
        }

        return false;
    });

    jQuery("#btnDependente").click(function () {

        var codigoSel = jQuery('input[name=rdbFuncionario]:checked', '.frmInfotech2u').val();
        //jQuery(window.document.location).attr('href', 'ManterDependente.aspx?idUser=' + codigoSel);
        if (codigoSel != null)
            jQuery(window.document.location).attr('href', 'ManterDependente.aspx?idUser=' + codigoSel);
        else {
            jQuery.alerts.dialogClass = 'alert-warning';
            jAlert('Selecione um funcionario', 'Alerta', function () {
                jQuery.alerts.dialogClass = null; // reset to default
            });
        }

        return false;
    });

    jQuery("#btnSindical").click(function () {

        var codigoSel = jQuery('input[name=rdbFuncionario]:checked', '.frmInfotech2u').val();
        //jQuery(window.document.location).attr('href', 'ManterContribuicaoSindicaol.aspx?idUser=' + codigoSel);
        if (codigoSel != null)
            jQuery(window.document.location).attr('href', 'ManterContribuicaoSindical.aspx?idUser=' + codigoSel);
        else {
            jQuery.alerts.dialogClass = 'alert-warning';
            jAlert('Selecione um funcionario', 'Alerta', function () {
                jQuery.alerts.dialogClass = null; // reset to default
            });
        }
        return false;
    });


    jQuery("#btnFerias").click(function () {

        var codigoSel = jQuery('input[name=rdbFuncionario]:checked', '.frmInfotech2u').val();

        if (codigoSel != null)
            jQuery(window.document.location).attr('href', 'ManterFeriasFuncionario.aspx?idUser=' + codigoSel);
        else {
            jQuery.alerts.dialogClass = 'alert-warning';
            jAlert('Selecione um funcionario', 'Alerta', function () {
                jQuery.alerts.dialogClass = null; // reset to default
            });
        }
        return false;
    });

    jQuery("#btnAlteracaoCargoSalario").click(function () {

        var codigoSel = jQuery('input[name=rdbFuncionario]:checked', '.frmInfotech2u').val();

        if (codigoSel != null)
            jQuery(window.document.location).attr('href', 'ManterAlteracaoCargoSalario.aspx?idUser=' + codigoSel);
        else {
            jQuery.alerts.dialogClass = 'alert-warning';
            jAlert('Selecione um funcionario', 'Alerta', function () {
                jQuery.alerts.dialogClass = null; // reset to default
            });
        }
        return false;
    });

    jQuery("#btnAcidenteTrabalho").click(function () {

        var codigoSel = jQuery('input[name=rdbFuncionario]:checked', '.frmInfotech2u').val();

        if (codigoSel != null)
            jQuery(window.document.location).attr('href', 'ManterAcidenteTrabalho.aspx?idUser=' + codigoSel);
        else {
            jQuery.alerts.dialogClass = 'alert-warning';
            jAlert('Selecione um funcionario', 'Alerta', function () {
                jQuery.alerts.dialogClass = null; // reset to default
            });
        }
        return false;
    });

    //btnRelatorioFuncionarioGeral

    jQuery("#btnRelatorioFuncionarioGeral").click(function () {

        var codigoSel = jQuery('input[name=rdbFuncionario]:checked', '.frmInfotech2u').val();

        if (codigoSel != null)
            jQuery(window.document.location).attr('href', 'RelatorioFuncionarioGeral.aspx?idUser=' + codigoSel);
        else {
            jQuery.alerts.dialogClass = 'alert-warning';
            jAlert('Selecione um funcionario', 'Alerta', function () {
                jQuery.alerts.dialogClass = null; // reset to default
            });
        }
        return false;
    });

});

function Pesquisar() {


    jQuery("tbody").empty();

    jQuery.ajax({
        type: "GET",
        url: "../../Handler/PesquisarFuncionario.ashx",
        data: {
            CodigoFuncionario: jQuery('#txtCodigoFuncionario').val(),
            NumeroOrdemMatricula: jQuery('#txtNumeroOrdemMatricula').val(),
            NumeroMatricula: jQuery('#txtNumeroMatricula').val(),
            NomeFuncionario: jQuery('#txtNomeFuncionario').val()
        },
        contentType: "json",
        cache: false,
        success: function (data) {

            var arrFuncionario = eval(data);

            //jQuery('tbody').remove();
            //('#dyntable').append('<tbody></tbody>');


            for (var i = 0; i < arrFuncionario.length; i++) {

                var row = '<tr class="gradeX"><td><input type="radio" name="rdbFuncionario" value="' + arrFuncionario[i].FUNC_CODIGO_FUNCIONARIO + '" /></td><td>' + arrFuncionario[i].FUNC_CODIGO_FUNCIONARIO + '</td><td>' + arrFuncionario[i].FUNC_NUMERO_ORDEM_MATRICULA + '</td><td>' + arrFuncionario[i].FUNC_NUMERO_MATRICULA + '</td><td class="center">' + arrFuncionario[i].FUNC_NOME_FUNCIONARIO + '</td></tr>';
                jQuery('tbody').append(row);

            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrow) {
            errorAjax(textStatus);
        }
    });
}

function GridFake() {

    for (i = 0; i < 50; i++) {
        var row = '<tr class="gradeX"><td><input type="radio" name="rdbFuncionario" value="' + i + '" /></td><td>' + i + '</td><td>' + i + '</td><td>' + i + '</td><td class="center">Nome do Funcionario ' + i + '</td></tr>';
        jQuery('tbody').append(row);
    }
}