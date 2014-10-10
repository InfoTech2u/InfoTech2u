

jQuery(document).ready(function () {

    CarregarLista();

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

    jQuery('#btnIncluir').click(function (event) {
        if (ValidarFormulario()) {
            jQuery.ajax({
                type: "GET",
                crossDomain: true,
                url: "../../Handler/ManterTarefa.ashx?Incluir",
                contentType: "json",
                cache: false,
                data: {
                    Metodo: 'Incluir',
                    Acao: 'Inclusao',
                    Descricao: jQuery('#txtDescricao').val()
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
                                   lista[0].CODIGO_TIPO_TAREFA,
                                   lista[0].DESCRICAO,
                                   '<a title="Excluir" href="javascript:Excluir(' + lista[0].CODIGO_TIPO_TAREFA + ')" class="deleterow"><i class="icon-trash"></i></a>'
                                ]).draw();

                                //Sucesso
                                jQuery.alerts.dialogClass = 'alert-success';
                                jAlert('Item foi incluído', 'Informação', function () {
                                    jQuery.alerts.dialogClass = null; // reset to default
                                });

                                Limpar();
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

    function Limpar() {
        jQuery('#txtDescricao').val("");
        jQuery('#msgDescricao').html('').hide();
        jQuery("#validaDescricao").removeClass("par control-group error").addClass("input-small");
};

    function ValidarFormulario() {

        var descricao = jQuery('#txtDescricao').val();
        if (!descricao && descricao.length <= 0) {
            jQuery('#msgDescricao').html('O Campo Descrição Deve ser preenchido').show();
            jQuery("#validaDescricao").removeClass("par control-group success").addClass("par control-group error");
            return false;
        }
        else {
            jQuery('#msgDescricao').html('').hide();
            jQuery("#validaDescricao").removeClass("par control-group error").addClass("par control-group success");
            return true;
        }

    }

    function CarregarLista() {

        jQuery("tbody").empty();
        jQuery('tbody').remove();
        jQuery('#dyntable').append('<tbody></tbody>');

        jQuery.ajax({
            type: "GET",
            crossDomain: true,
            url: "../../Handler/ManterTarefa.ashx",
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
                var tipos = eval(data);

                if (tipos.length > 0) {

                    for (x in tipos) {
                        jQuery('#dyntable').DataTable().row.add([
                            tipos[x].CodigoTipoTarefa,
                            tipos[x].Descricao,
                            '<a title="Excluir" href="javascript:Excluir(' + tipos[x].CodigoTipoTarefa + ')" class="deleterow"><i class="icon-trash"></i></a>'
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

function Excluir(Id) {

    //Confirmação
    jConfirm('Deseja excluir o item selecionado?', 'Confirmation Dialog', function (r) {
        if (r == true) {
            jQuery.ajax({
                type: "GET",
                crossDomain: true,
                url: "../../Handler/ManterTarefa.ashx",
                contentType: "json",
                cache: false,
                data: {
                    Metodo: 'Excluir',
                    Acao: 'Exclusao',
                    Id: Id
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


