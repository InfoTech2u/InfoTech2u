jQuery(document).ready(function () {
    CarregarSindicatoLista();
    
    jQuery('.deleterow').click(function () {
        var conf = confirm('Continue delete?');
        if (conf)
            jQuery(this).parents('tr').fadeOut(function () {
                var id = jQuery(this).children('td:first').text();

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
                        }
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrow) {
                        errorAjax(textStatus);
                        alert(textStatus);
                    }
                });


            });
        return false;
    });

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

                        var row = '<tr><td>' + lista[0].CODIGO_SINDICATO + '</td><td>' + lista[0].NOME + '</td><td class="centeralign"><a title="Excluir" href="#" class="deleterow"><i class="icon-trash"></i></a></td></tr>';
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

