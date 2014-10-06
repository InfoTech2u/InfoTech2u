jQuery(document).ready(function () {
    CarregarTipoBeneficioLista();

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

                    if (lista.length > 0) {
                        var row = '<tr id="' + lista[0].CODIGO_TIPO_BENEFICIO + '" ><td>' + lista[0].CODIGO_TIPO_BENEFICIO + '</td><td>' + lista[0].DESCRICAO + '</td><td class="centeralign"><a title="Excluir" href="javascript:Excluir(' + lista[0].CODIGO_TIPO_BENEFICIO + ')" class="deleterow"><i class="icon-trash"></i></a></td></tr>';
                        jQuery('tbody').append(row);
                        jQuery('#myModal').modal('hide')
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

        //jQuery('#txtDescricaoTipoBeneficio').val('');

    });
});

function validar() {

    if (jQuery('#txtDescricaoTipoBeneficio').val() == "") {
        alert("Preencha a descrição do benefício.")
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

            var tiposBeneficios = eval(data);

            if (tiposBeneficios.length > 0) {

                for (x in tiposBeneficios) {
                    var row = '<tr id="' + tiposBeneficios[x].CodigoTipoBeneficio + '"><td>' + tiposBeneficios[x].CodigoTipoBeneficio + '</td><td>' + tiposBeneficios[x].Descricao + '</td><td class="centeralign"><a title="Excluir" href="javascript:Excluir(' + tiposBeneficios[x].CodigoTipoBeneficio + ')" class="deleterow"><i class="icon-trash"></i></a></td></tr>';
                    jQuery('tbody').append(row);
                }

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

function Excluir(id) {

    jConfirm('Deseja excluir o item selecionado?', 'Confirmation Dialog', function (r) {
        if(r == true)
        {
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

                    if (data) {
                        jQuery('table tbody tr[id="' + id + '"]').remove();
                        // do some other stuff here
                        jQuery.alerts.dialogClass = 'alert-success';
                        jAlert('Item foi excluido', 'Informação', function () {
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
        else if(r == false)
        {
            jQuery.alerts.dialogClass = 'alert-info';
            jAlert('Item não foi excluido', 'Informação', function () {
                jQuery.alerts.dialogClass = null; // reset to default
            });
        }
    });
}
