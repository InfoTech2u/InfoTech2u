

jQuery(document).ready(function () {
    
    //Data dataddmmaaaa
    jQuery(".dataddmmaaaa").mask("99/99/9999");
    
    // Data com opção de Filtro de Mes e Ano
    jQuery(".dataddmmaaaa").datepicker({
        dateFormat: 'dd/mm/yy',
        changeMonth: true,
        changeYear: true,
        yearRange: '-100y:c+nn',
        maxDate: '-1d'
    });
    
   

    function ValidarFormulario() {

        var dataDeAdmissao = jQuery('#txtDataAdmissao').val();

        if (!dataDeAdmissao && dataDeAdmissao.length <= 0) {
            jQuery('#msgDataDeAdmissao').html('O Campo Data de Admissão Deve ser preenchido').show();
            jQuery("#validaDataDeAdmissao").removeClass("par control-group success").addClass("par control-group error");
            retorno = false;
        }
        else {
            jQuery('#msgDataDeAdmissao').html('').hide();
            jQuery("#validaDataDeAdmissao").removeClass("par control-group error").addClass("par control-group success");
        }



    }
});