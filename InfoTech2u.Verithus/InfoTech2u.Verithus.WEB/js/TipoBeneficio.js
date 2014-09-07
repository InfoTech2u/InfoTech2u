jQuery(document).ready(function () {
    CarregarTipoBeneficioLista();

    jQuery('#btnIncluir').click(function (event) {
        if (validar()) {

            jQuery.ajax({
                type: "GET",
                crossDomain: true,
                url: "../../Handler/TipoBeneficio.ashx?Incluir",
                contentType: "json",
                cache: false,
                data: {
                    Metodo: 'Incluir',
                    Acao: 'Inclusao',
                    Descricao: jQuery('#txtDescricaoTipoBeneficio').val()
                },
                success: function (data) {

                    if (data) {
                        //LimparGrid();
                        //FormatarGrid();
                        //CarregarTipoBeneficioLista();

                        var row = '<tr><td>' + tiposBeneficios[x].CodigoTipoBeneficio + '</td><td>' + tiposBeneficios[x].Descricao + '</td><td class="centeralign"><a title="Excluir" href="#" class="deleterow"><i class="icon-trash"></i></a></td></tr>';
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
                var row = '<tr><td>' + tiposBeneficios[x].CodigoTipoBeneficio + '</td><td>' + tiposBeneficios[x].Descricao + '</td><td class="centeralign"><a title="Excluir" href="#" class="deleterow"><i class="icon-trash"></i></a></td></tr>';
                jQuery('tbody').append(row);
            }
            FormatarGrid();
            Excluir();
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

function Excluir() {
    // delete row in a table
    jQuery('.deleterow').click(function () {
        var conf = confirm('Continue delete?');
        if (conf)
            jQuery(this).parents('tr').fadeOut(function () {
                var id = jQuery(this).children('td:first').text();

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

                        FormatarGrid();
                        Excluir();
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrow) {
                        errorAjax(textStatus);
                        alert(textStatus);
                    }
                });


            });
        return false;
    });
}

function LimparGrid() {
    // dynamic table
    jQuery('#dyntable tbody tr').remove();
};