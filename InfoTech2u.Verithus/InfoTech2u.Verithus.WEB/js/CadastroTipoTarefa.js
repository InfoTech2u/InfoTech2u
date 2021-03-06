﻿

jQuery(document).ready(function () {

    CarregarLista();

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
                    var tipos = eval(data);
                    Limpar();
                    if (tipos.length > 0) {
                        var row = '<tr id="' + tipos[0].CODIGO_TIPO_TAREFA + '"><td>' + tipos[0].CODIGO_TIPO_TAREFA + '</td><td>' + tipos[0].DESCRICAO + '</td><td class="centeralign"><a title="Excluir" href="javascript:Excluir(' + tipos[0].CODIGO_TIPO_TAREFA + ');" class="deleterow"><i class="icon-trash"></i></a></td></tr>';
                        jQuery('tbody').append(row);
                        jQuery('#myModal').modal('hide');
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
    });

    jQuery("#btnLimpar").click(function () {
        Limpar();
    });


    function Limpar() {
        jQuery('#txtDescricao').val("");
        jQuery('#msgDescricao').html('').hide();
        jQuery("#validaDescricao").removeClass("par control-group error").addClass("input-small");
    }


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

                if (data != '[]') {
                    var tipos = eval(data);
                    for (x in tipos) {
                        var row = '<tr id="' + tipos[x].CodigoTipoTarefa + '"><td>' + tipos[x].CodigoTipoTarefa + '</td><td>' + tipos[x].Descricao + '</td><td class="centeralign"><a title="Excluir" href="javascript:Excluir(' + tipos[x].CodigoTipoTarefa + ');" class="deleterow"><i class="icon-trash"></i></a></td></tr>';
                        jQuery('tbody').append(row);
                    }

                    //FormatarGrid();

                    jQuery('#dyntable').dataTable().fnDestroy();

                    jQuery('#dyntable').dataTable({
                        "sPaginationType": "full_numbers",
                        "fnDrawCallback": function (oSettings) {
                            jQuery.uniform.update();
                        },
                        "language": {
                            "lengthMenu": "Display _MENU_ records per page",
                            "zeroRecords": "Nothing found - sorry",
                            "info": "Showing page _PAGE_ of _PAGES_",
                            "infoEmpty": "No records available",
                            "infoFiltered": "(filtered from _MAX_ total records)",
                            "sInfoEmpty": "Mostrando 0-0 de 0 Funcionários"
                        }
                        //"sInfoEmpty": "Mostrando 0-0 de 0 Funcionários"
                    });

                }
            },
            error: function (XMLHttpRequest, textStatus, errorThrow) {
                errorAjax(textStatus);
                alert(textStatus);
            }
        });
    }

    function FormatarGrid() {
        // dynamic table
        jQuery('#dyntable').dataTable({
            "sPaginationType": "full_numbers",
            "aaSortingFixed": [[0, 'asc']],
            "fnDrawCallback": function (oSettings) {
                jQuery.uniform.update();
            }
        });
    };
});


function Excluir(Id) {
    var conf = confirm('Deseja Deletar este Registro?');
    if (conf) {
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

                if (data) {
                    jQuery('table tbody tr[id="' + Id + '"]').remove();
                    // do some other stuff here
                }
                //FormatarGrid();
            },
            error: function (XMLHttpRequest, textStatus, errorThrow) {
                errorAjax(textStatus);
                alert(textStatus);
            }
        });
    }
}


