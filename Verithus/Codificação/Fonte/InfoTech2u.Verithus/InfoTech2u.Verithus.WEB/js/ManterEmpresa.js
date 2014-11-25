jQuery(document).ready(function () {

    CarregarEmpresaLista();

    jQuery('#dyntable').dataTable({
        "sPaginationType": "full_numbers",
        "fnDrawCallback": function (oSettings) { jQuery.uniform.update(); },
        "language": {
            "search": "Pesquisa",
            "lengthMenu": "Mostrar _MENU_ registros por página",
            "zeroRecords": "Não há registros",
            "info": "Página _PAGE_ de _PAGES_",
            "infoEmpty": "Não há registros.",
            "infoFiltered": "(Pesquisado de um total de _MAX_ registro(s))",
            "paginate": {
                "first": "Primeira",
                "previous": "Anterior",
                "next": "Próxima",
                "last": "Última"
            },
        }
    });

    //CNPJ
    jQuery(".CNPJ").mask("99.999.999/9999-99");

    jQuery('#dyntable tbody').on('click', 'tr', function () {
        if (jQuery(this).hasClass('selected')) {
            //jQuery(this).removeClass('selected');
        }
        else {
            jQuery('#dyntable tr.selected').removeClass('selected');
            jQuery(this).addClass('selected');
        }
    });
});

function PrepararTela(id, acao) {
    if (acao == 'Incluir') {
        jQuery('#btnIncluir').attr('onclick', 'javascript:Gravar("")');
        jQuery('#txtCodigoEmpresa').val('');
        jQuery('#txtNomeFantasia').val('');
        jQuery('#txtRazaoSocial').val('');
        jQuery('#txtCNPJ').val('');
        jQuery('#txtInscricaoEstadual').val('');
    }
    else if (acao == 'Alterar')
    {
        CarregarEmpresa(id);
    }
    else if (acao == 'Detalhar') {
        CarregarEmpresa(id);
    }
    else {

        jQuery('#btnIncluir').attr('onclick', 'javascript:Gravar("")');
        jQuery('#txtCodigoEmpresa').val('');
        jQuery('#txtNomeFantasia').val('');
        jQuery('#txtRazaoSocial').val('');
        jQuery('#txtCNPJ').val('');
        jQuery('#txtInscricaoEstadual').val('');
    }
}

function CarregarEmpresa(id) {
    jQuery.ajax({
        type: "GET",
        crossDomain: true,
        url: "../../Handler/ManterEmpresa.ashx",
        contentType: "json",
        cache: false,
        data: {
            Metodo: 'SelecionarEmpresa',
            Acao: 'Selecionar',
            CodigoEmpresa: id,
            NomeFantasia: '',
            RazaoSocial: '',
            CNPJ: '',
            InscricaoEstadual: '',
            CodigoStatus: ''
        },
        success: function (data) {
            var empresa = eval(data);

            if (data['Msg'] != null) {
                jQuery('#myModal').modal('hide');

                jQuery(window.document.location).attr('href', '../../Login.aspx?cod=300');

                return;
            } else {

            if (empresa != undefined && empresa.length > 0) {

                jQuery('#txtCodigoEmpresa').val(empresa[0].CODIGO_EMPRESA);
                jQuery('#txtNomeFantasia').val(empresa[0].NOME_FANTASIA);
                jQuery('#txtRazaoSocial').val(empresa[0].RAZAO_SOCIAL);
                jQuery('#txtCNPJ').val(empresa[0].CNJP);
                jQuery('#txtInscricaoEstadual').val(empresa[0].INCRICAO_ESTADUAL);

                jQuery('#btnIncluir').attr('onclick', 'javascript:Gravar(' + id + ');');

            }
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrow) {
            errorAjax(textStatus);
            alert(textStatus);
        }
    });
}

function FuncaoTelaModal(funcao, id) {

    if (funcao == 'Incluir') {
        jQuery('#hdnFuncaoTela').val('Incluir');

        jQuery('#txtNomeFantasia').attr('readonly', false);
        jQuery('#txtRazaoSocial').attr('readonly', false);
        jQuery('#txtCNPJ').attr('readonly', false);
        jQuery('#txtInscricaoEstadual').attr('readonly', false);
        jQuery("#btnIncluir").prop("disabled", false);

        PrepararTela(id, 'incluir');

    }
    else if (funcao == 'Alterar') {
        jQuery('#hdnFuncaoTela').val('Alterar');

        jQuery('#txtNomeFantasia').attr('readonly', false);
        jQuery('#txtRazaoSocial').attr('readonly', false);
        jQuery('#txtCNPJ').attr('readonly', false);
        jQuery('#txtInscricaoEstadual').attr('readonly', false);
        jQuery("#btnIncluir").prop("disabled", false);

        PrepararTela(id,'Alterar');


    }
    else if (funcao == 'Detalhar') {
        jQuery('#hdnFuncaoTela').val('Detalhar');

        jQuery('#txtNomeFantasia').attr('readonly', true);
        jQuery('#txtRazaoSocial').attr('readonly', true);
        jQuery('#txtCNPJ').attr('readonly', true);
        jQuery('#txtInscricaoEstadual').attr('readonly', true);
        jQuery("#btnIncluir").prop("disabled", true);

        PrepararTela(id,'Detalhar');
    }
    else { jQuery('#hdnFuncaoTela').val(''); }

}

function DadosValidos() {
    var valido = true;

    if (jQuery('#txtNomeFantasia').val() == "") {
        jQuery('#lblErrorNomeFantasia').show();
        valido = false;
    }
    else { jQuery('#lblErrorNomeFantasia').hide(); }

    if (jQuery('#txtRazaoSocial').val() == "") {
        jQuery('#lblErrorRazaoSocial').show();
        valido = false;
    }
    else { jQuery('#lblErrorRazaoSocial').hide(); }

    if (jQuery('#txtCNPJ').val() == "") {
        jQuery('#lblErrorCNPJ').show();
        valido = false;
    }
    else { jQuery('#lblErrorCNPJ').hide(); }

    if (jQuery('#txtInscricaoEstadual').val() == "") {
        jQuery('#lblErrorInscricaoEstadual').show();
        valido = false;
    }
    else { jQuery('#lblErrorInscricaoEstadual').hide(); }

    return valido;
};

function CarregarEmpresaLista() {

    jQuery("tbody").empty();
    jQuery('tbody').remove();
    jQuery('#dyntable').append('<tbody></tbody>');

    jQuery.ajax({
        type: "GET",
        crossDomain: true,
        url: "../../Handler/ManterEmpresa.ashx",
        contentType: "json",
        cache: false,
        data: {
            Metodo: 'ListaEmpresa',
            Acao: 'Selecionar',
            CodigoEmpresa: '',
            NomeFantasia: '',
            RazaoSocial: '',
            CNPJ: '',
            InscricaoEstadual: '',
            CodigoStatus: ''
        },
        success: function (data) {
            var empresa = eval(data);
            if (data['Msg'] != null) {
                jQuery('#myModal').modal('hide');

                jQuery(window.document.location).attr('href', '../../Login.aspx?cod=300');

                return;
            } else {

            if (empresa != undefined && empresa.length > 0) {
                jQuery('#ddlTipoParentesco').append('<option value="0">Escolha</option>');

                    for (x in empresa) {
                        jQuery('#dyntable').DataTable().row.add([
                            empresa[x].CODIGO_EMPRESA,
                            empresa[x].RAZAO_SOCIAL,
                            empresa[x].CNJP,
                            '<a title="Detalhar" href="#myModal" onclick="javascript:FuncaoTelaModal(\'Detalhar\', ' + empresa[x].CODIGO_EMPRESA + ');" data-toggle="modal"><i class="iconfa-pencil"></i></a>',
                            '<a title="Alterar" href="#myModal" onclick="javascript:FuncaoTelaModal(\'Alterar\', ' + empresa[x].CODIGO_EMPRESA + ');" data-toggle="modal"><i class="iconfa-pencil"></i></a>',
                            '<a title="Excluir" href="javascript:Excluir(' + empresa[x].CODIGO_EMPRESA + ')" class="deleterow"><i class="icon-trash"></i></a>'
                        ]).draw();
                }


                    }
            }

        },
        error: function (XMLHttpRequest, textStatus, errorThrow) {
            errorAjax(textStatus);
            alert(textStatus);
        }
    });

}

function Gravar(id) {

    if (DadosValidos()) {

        jQuery.ajax({
            type: "GET",
            crossDomain: true,
            url: "../../Handler/ManterEmpresa.ashx",
            contentType: "json",
            cache: false,
            data: {
                Metodo: 'Gravar',
                Acao: 'Inclusao',
                CodigoEmpresa: jQuery('#txtCodigoEmpresa').val(),
                NomeFantasia: jQuery('#txtNomeFantasia').val(),
                RazaoSocial: jQuery('#txtRazaoSocial').val(),
                CNPJ: jQuery('#txtCNPJ').val(),
                InscricaoEstadual: jQuery('#txtInscricaoEstadual').val(),
                CodigoStatus: 1
            },
            success: function (data) {

                var empresa = eval(data);

                if (data['Msg'] != null) {
                    jQuery('#myModal').modal('hide');

                    jQuery(window.document.location).attr('href', '../../Login.aspx?cod=300');

                    return;
                } else {

                if (empresa != undefined && empresa.length > 0) {

                    if (id != 0)
                            jQuery('#dyntable').DataTable().row('.selected').remove().draw(false);

                        jQuery('#dyntable').DataTable().row.add([
                            empresa[0].CODIGO_EMPRESA,
                            empresa[0].RAZAO_SOCIAL,
                            empresa[0].CNJP,
                            '<a title="Detalhar" href="#myModal" onclick="javascript:FuncaoTelaModal(\'Detalhar\', ' + empresa[0].CODIGO_EMPRESA + ');" data-toggle="modal"><i class="iconfa-pencil"></i></a>',
                            '<a title="Alterar" href="#myModal" onclick="javascript:FuncaoTelaModal(\'Alterar\', ' + empresa[0].CODIGO_EMPRESA + ');" data-toggle="modal"><i class="iconfa-pencil"></i></a>',
                            '<a title="Excluir" href="javascript:Excluir(' + empresa[0].CODIGO_EMPRESA + ')" class="deleterow"><i class="icon-trash"></i></a></td>'
                        ]).draw();

                    jQuery('#myModal').modal('hide')
                }
                else {
                        jQuery.alerts.dialogClass = 'alert-danger';
                        jAlert('Ação não pode ser concluída.', 'Alerta', function () {
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
    }

}


function Excluir(id) {

    //Confirmação
    jConfirm('Deseja excluir o item selecionado?', 'Confirmation Dialog', function (r) {
        if (r == true) {
            jQuery.ajax({
                type: "GET",
                crossDomain: true,
                url: "../../Handler/ManterEmpresa.ashx",
                contentType: "json",
                cache: false,
                data: {
                    Metodo: 'Excluir',
                    Acao: 'Exclusao',
                    CodigoEmpresa: id,
                    NomeFantasia: '',
                    RazaoSocial: '',
                    CNPJ: '',
                    InscricaoEstadual: '',
                    CodigoStatus: ''
                },
                success: function (data) {
                    var ret = eval(data)
                    if (data['Msg'] != null) {
                        jQuery('#myModal').modal('hide');

                        jQuery(window.document.location).attr('href', '../../Login.aspx?cod=300');

                        return;
                    } else {

                        if (ret) {
                            jQuery('#dyntable').DataTable().row('.selected').remove().draw(false);
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
        }
        else if (r == false) {
            jQuery.alerts.dialogClass = 'alert-info';
            jAlert('Item não foi excluido', 'Informação', function () {
                jQuery.alerts.dialogClass = null; // reset to default
            });
        }
    });

    
}