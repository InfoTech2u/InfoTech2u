jQuery(document).ready(function () {
    CarregarSindicatoLista();
    

    jQuery('#btnIncluir').click(function (event) {
        if (validar()) {

            jQuery.ajax({
                type: "GET",
                crossDomain: true,
                url: "../../Handler/ManterSindicato.ashx",
                contentType: "json",
                cache: false,
                data: {
                    Metodo: 'Incluir',
                    Acao: 'Inclusao',
                    Nome: jQuery('#txtNomeSindicato').val()
                },
                success: function (data) {
                    var lista = eval(data);

                    if (lista.length > 0) {
                        //LimparGrid();

                        //CarregarTipoBeneficioLista();

                        var row = '<tr><td>' + lista[0].NOME + '</td><td class="centeralign"><a title="Excluir" href="javascript:Excluir(' + lista[0].CODIGO_SINDICATO + ')" class="deleterow"><i class="icon-trash"></i></a></td></tr>';
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
    });
});

function validar() {

    if (jQuery('#txtNomeSindicato').val() == "") {
        alert("Preencha o nome do sindicato.")
        return false;
    }
    else {
        return true;
    }
};



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

            for (x in lista) {
                var row = '<tr><td>' + lista[x].CodigoSindicato + '</td><td>' + lista[x].Nome + '</td><td class="centeralign"><a title="Excluir" href="#" class="deleterow"><i class="icon-trash"></i></a></td></tr>';
                jQuery('tbody').append(row);
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrow) {
            errorAjax(textStatus);
            alert(textStatus);
        }
    });
}

function Excluir(id)
{

    //Confirmação
    jConfirm('Deseja excluir o item selecionado?', 'Confirmation Dialog', function (r) {
        if (r == true) {
            jQuery(this).parents('tr').fadeOut(function () {
                jQuery.ajax({
                    type: "GET",
                    crossDomain: true,
                    url: "../../Handler/ManterSindicato.ashx",
                    contentType: "json",
                    cache: false,
                    data: {
                        Metodo: 'Excluir',
                        Acao: 'Exclusao',
                        Id: id
                    },
                    success: function (data) {

                        if (data) {
                            jQuery(this).remove();
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


            });
        }
        else if (r == false) {
            jQuery.alerts.dialogClass = 'alert-info';
            jAlert('Item não foi excluido', 'Informação', function () {
                jQuery.alerts.dialogClass = null; // reset to default
            });
        }
    });

      
    return false;
}

