

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
                    alert("Incluído com Sucesso!");
                },
                error: function (XMLHttpRequest, textStatus, errorThrow) {
                    errorAjax(textStatus);
                    alert(textStatus);
                }
            });
        }
    });

    jQuery("#btnLimpar").click(function () {
        jQuery('#txtDescricao').val("");
        jQuery('#msgDescricao').html('').hide();
        jQuery("#validaDescricao").removeClass("par control-group error").addClass("input-small");
    });

    // delete row in a table
    jQuery(".deleterow").click(function () {
        var conf = confirm('Deseja Deletar este Registro?');
        if (conf)
            jQuery(this).parents('tr').fadeOut(function () {
                var id = jQuery(this).children('td:first').text();

                jQuery.ajax({
                    type: "GET",
                    crossDomain: true,
                    url: "../../Handler/ManterTarefa.ashx",
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
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrow) {
                        errorAjax(textStatus);
                        alert(textStatus);
                    }
                });
            });
        return false;
    });


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

                var tipos = eval(data);
                for (x in tipos) {
                    var row = '<tr><td>' + tipos[x].CodigoTipoTarefa + '</td><td>' + tipos[x].Descricao + '</td><td class="centeralign"><a title="Excluir" href="#" class="deleterow"><i class="icon-trash"></i></a></td></tr>';
                    jQuery('tbody').append(row);
                }
                FormatarGrid();
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



