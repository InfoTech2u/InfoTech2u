jQuery(document).ready(function () {
    CarregarTipoBeneficioLista();

    jQuery('#dyntable').dataTable({
        "sPaginationType": "full_numbers",
        "fnDrawCallback": function (oSettings) { jQuery.uniform.update();  },
        "language": {
            "search":"Pesquisa",
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

    jQuery('#btnIncluir').click(function (event) {
        if (validar()) {

            jQuery.ajax({
                type: "GET",
                crossDomain: true,
                url: "../../Handler/TipoBeneficio.ashx",
                contentType: "json",
                cache: false,
                data: {
                    Metodo: 'Incluir',
                    Acao: 'Inclusao',
                    Descricao: jQuery('#txtDescricaoTipoBeneficio').val()
                },
                success: function (data) {
                    var lista = eval(data);

                    if (lista['Msg'] != null) {
                        jQuery('#myModal').modal('hide');

                        jQuery(window.document.location).attr('href', '../../Login.aspx?cod=300');

                        return;
                    } else {

                        if (lista[0].Erro != null) {
                            jQuery.alerts.dialogClass = 'alert-danger';
                            jAlert(lista[0].Mensagem, 'Alerta', function () {
                                jQuery.alerts.dialogClass = null; // reset to default
                            });
                        } else {

                    if (lista.length > 0) {
                                jQuery('#dyntable').DataTable().row.add([
                                   lista[0].CODIGO_TIPO_BENEFICIO,
                                   lista[0].DESCRICAO,
                                   '<a title="Excluir" href="javascript:Excluir(' + lista[0].CODIGO_TIPO_BENEFICIO + ')" class="deleterow"><i class="icon-trash"></i></a>'
                                ]).draw();

                                //Sucesso
                                jQuery.alerts.dialogClass = 'alert-success';
                                jAlert('Item foi incluído', 'Informação', function () {
                                    jQuery.alerts.dialogClass = null; // reset to default
                                });

                                LimparModal();
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
    });
});

function validar() {

    if (jQuery('#txtDescricaoTipoBeneficio').val() == "") {
        jQuery.alerts.dialogClass = 'alert-info';
        jAlert('Preencha o campo.', 'Informação', function () {
            jQuery.alerts.dialogClass = null; // reset to default
        });
        return false;
    }
    else {
        return true;
    }
};

function CarregarTipoBeneficioLista() {

    jQuery("tbody").empty();
    jQuery('tbody').remove();
    jQuery('#dyntable').append('<tbody></tbody>');

    jQuery.ajax({
        type: "GET",
        crossDomain: true,
        url: "../../Handler/TipoBeneficio.ashx",
        contentType: "json",
        cache: false,
        data: {
            Metodo: 'Listar',
            Acao: 'Consulta'
        },
        success: function (data) {

            if (data['Msg'] != null) {
                jQuery('#myModal').modal('hide');

                jQuery(window.document.location).attr('href', '../../Login.aspx?cod=300');

                return;
            } else {
            var tiposBeneficios = eval(data);

            if (tiposBeneficios.length > 0) {

                for (x in tiposBeneficios) {
                    jQuery('#dyntable').DataTable().row.add([
                        tiposBeneficios[x].CodigoTipoBeneficio,
                        tiposBeneficios[x].Descricao,
                        '<a title="Excluir" href="javascript:Excluir(' + tiposBeneficios[x].CodigoTipoBeneficio + ')" class="deleterow"><i class="icon-trash"></i></a>'
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

function Excluir(id) {

    jConfirm('Deseja excluir o item selecionado?', 'Confirmation Dialog', function (r) {
        if (r == true) {
            jQuery.ajax({
                type: "GET",
                crossDomain: true,
                url: "../../Handler/TipoBeneficio.ashx",
                contentType: "json",
                cache: false,
                data: {
                    Metodo: 'Excluir',
                    Acao: 'Exclusao',
                    Id: id
                },
                success: function (data) {
                    var lista = eval(data);

                    if (lista['Msg'] != null) {
                        jQuery('#myModal').modal('hide');

                        jQuery(window.document.location).attr('href', '../../Login.aspx?cod=300');

                        return;
                    } else {
                        if (lista != null && lista[0] != undefined)
                        {
                            jQuery.alerts.dialogClass = 'alert-danger';
                            jAlert(lista[0].Mensagem, 'Alerta', function () {
                                jQuery.alerts.dialogClass = null; // reset to default
                            });
                        }else  {
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

function LimparModal()
{
    jQuery('#txtDescricaoTipoBeneficio').val('');
}



