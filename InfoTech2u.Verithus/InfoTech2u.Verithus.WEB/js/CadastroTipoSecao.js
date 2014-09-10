

jQuery(document).ready(function () {

    jQuery('#btnConcluir').click(function (event) {
        if (ValidarFormulario()) {
            jQuery.ajax({
                type: "GET",
                crossDomain: true,
                url: "../../Handler/ManterSecao.ashx?Incluir",
                contentType: "json",
                cache: false,
                data: {
                    Metodo: 'Incluir',
                    Acao: 'Inclusao',
                    Descricao: jQuery('#txtDescricao').val()
                },
                success: function (data) {

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

});