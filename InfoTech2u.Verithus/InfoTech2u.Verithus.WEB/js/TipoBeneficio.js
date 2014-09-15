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
                        var row = '<tr><td>' + lista[0].DESCRICAO + '</td><td class="centeralign"><a title="Excluir" href="javascript:Excluir(' + lista[0].CODIGO_TIPO_BENEFICIO + ')" class="deleterow"><i class="icon-trash"></i></a></td></tr>';
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

    if (jQuery('#txtDescricaoTipoBeneficio').val() == "") {
        alert("Preencha a descrição do benefício.")
        return false;
    }
    else {
        return true;
    }
};

function CarregarTipoBeneficioLista() {
    jQuery.ajax({
        type: "GET",
        crossDomain: true,
        url: "../../Handler/TipoBeneficio.ashx",
        contentType: "json",
        cache: false,
        data: {
            Metodo: 'Lista',
            Acao: 'Consulta'
        },
        success: function (data) {

            var tiposBeneficios = eval(data);
            for (x in tiposBeneficios) {
                var row = '<tr><td>' + tiposBeneficios[x].Descricao + '</td><td class="centeralign"><a title="Excluir" href="javascript:Excluir(' + tiposBeneficios[x].CodigoTipoBeneficio + ')" class="deleterow"><i class="icon-trash"></i></a></td></tr>';
                jQuery('tbody').append(row);
            }
           
           
        },
        error: function (XMLHttpRequest, textStatus, errorThrow) {
            errorAjax(textStatus);
            alert(textStatus);
        }
    });
}

function Excluir(id) {

    var conf = confirm('Continue delete?');
    if (conf)
        jQuery(this).parents('tr').fadeOut(function () {
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
}
