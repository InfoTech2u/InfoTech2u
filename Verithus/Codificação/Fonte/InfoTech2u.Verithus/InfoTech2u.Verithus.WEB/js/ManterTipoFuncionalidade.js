jQuery(document).ready(function () {
    CarregarTipoFuncionalidadeLista();

    jQuery('#btnIncluir').click(function (event) {
        if (validar()) {

            jQuery.ajax({
                type: "GET",
                crossDomain: true,
                url: "../../Handler/ManterTipoSistema.ashx",
                contentType: "json",
                cache: false,
                data: {
                    Metodo: 'Incluir',
                    Acao: 'Inclusao',
                    Descricao: jQuery('#txtDescricaoTipoFuncionalidade').val()
                },
                success: function (data) {
                    if (data['Msg'] != null) {
                        jQuery('#myModal').modal('hide');

                        jQuery(window.document.location).attr('href', '../../Login.aspx?cod=300');

                        return;
                    } else {
                    var lista = eval(data);

                    if (lista.length > 0) {
                        var row = '<tr><td>' + lista[0].DESCRICAO + '</td><td class="centeralign"><a title="Excluir" href="javascript:Excluir(' + lista[0].CODIGO_TIPO_FUNCIONALIDADE + ')" class="deleterow"><i class="icon-trash"></i></a></td></tr>';
                        jQuery('tbody').append(row);
                        jQuery('#myModal').modal('hide')
                    }
                    else {
                        alert("Não foi possível incluir.");
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

function validar() {

    if (jQuery('#txtDescricaoTipoFuncionalidade').val() == "") {
        alert("Preencha a descrição do Tipo de Funcionalidade.")
        return false;
    }
    else {
        return true;
    }
};

function CarregarTipoFuncionalidadeLista() {
    jQuery.ajax({
        type: "GET",
        crossDomain: true,
        url: "../../Handler/ManterTipoSistema.ashx",
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
            var tiposFuncionalidade = eval(data);
            for (x in tiposFuncionalidade) {
                var row = '<tr><td>' + tiposFuncionalidade[x].Descricao + '</td><td class="centeralign"><a title="Excluir" href="javascript:Excluir(' + tiposFuncionalidade[x].CodigoTipoFuncionalidade + ')" class="deleterow"><i class="icon-trash"></i></a></td></tr>';
                jQuery('tbody').append(row);
            }
            }

        },
        error: function (XMLHttpRequest, textStatus, errorThrow) {
            errorAjax(textStatus);
            alert(textStatus);
        }
    });
}

function Excluir(id) {

    //Confirmação
    jConfirm('Deseja excluir o item selecionado?', 'Confirmation Dialog', function (r) {
        if (r == true) {
            jQuery(this).parents('tr').fadeOut(function () {
                jQuery.ajax({
                    type: "GET",
                    crossDomain: true,
                    url: "../../Handler/ManterTipoSistema.ashx",
                    contentType: "json",
                    cache: false,
                    data: {
                        Metodo: 'Excluir',
                        Acao: 'Exclusao',
                        Id: id
                    },
                    success: function (data) {
                        if (data['Msg'] != null) {
                            jQuery('#myModal').modal('hide');

                            jQuery(window.document.location).attr('href', '../../Login.aspx?cod=300');

                            return;
                        } else {
                        if (data) {
                            jQuery(this).remove();
                            // do some other stuff here
                            //Sucesso
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


            });
        }
        else if (r == false) {
            jQuery.alerts.dialogClass = 'alert-info';
            jAlert('Item não foi excluido', 'Informação', function () {
                jQuery.alerts.dialogClass = null; // reset to default
            });
        }
    });
    /*
    var conf = confirm('Continue delete?');
    if (conf)
        jQuery(this).parents('tr').fadeOut(function () {
            jQuery.ajax({
                type: "GET",
                crossDomain: true,
                url: "../../Handler/ManterTipoSistema.ashx",
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


        });*/
    return false;
}
