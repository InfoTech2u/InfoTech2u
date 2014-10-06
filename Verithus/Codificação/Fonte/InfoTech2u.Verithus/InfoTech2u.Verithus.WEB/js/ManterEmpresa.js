jQuery(document).ready(function () {

    CarregarEmpresaLista();
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


            if (empresa != undefined && empresa.length > 0) {

                jQuery('#txtCodigoEmpresa').val(empresa[0].CODIGO_EMPRESA);
                jQuery('#txtNomeFantasia').val(empresa[0].NOME_FANTASIA);
                jQuery('#txtRazaoSocial').val(empresa[0].RAZAO_SOCIAL);
                jQuery('#txtCNPJ').val(empresa[0].CNJP);
                jQuery('#txtInscricaoEstadual').val(empresa[0].INCRICAO_ESTADUAL);

                jQuery('#btnIncluir').attr('onclick', 'javascript:Gravar(' + id + ');');

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


            if (empresa != undefined && empresa.length > 0) {
                jQuery('#ddlTipoParentesco').append('<option value="0">Escolha</option>');
                for (var x in empresa) {

                    var row = '<tr value="' + empresa[x].CODIGO_EMPRESA + '">' +
                           '<td>' + empresa[x].CODIGO_EMPRESA + '</td>' +
                           '<td>' + empresa[x].RAZAO_SOCIAL + '</td>' +
                           '<td>' + empresa[x].CNJP + '</td>' +
                           '<td class="centeralign"><a title="Alterar" href="#myModal" onclick="javascript:FuncaoTelaModal(\'Detalhar\', ' + empresa[x].CODIGO_EMPRESA + ');" data-toggle="modal"><i class="iconfa-pencil"></i></a></td>' +
                           '<td class="centeralign"><a title="Alterar" href="#myModal" onclick="javascript:FuncaoTelaModal(\'Alterar\', ' + empresa[x].CODIGO_EMPRESA + ');" data-toggle="modal"><i class="iconfa-pencil"></i></a></td>' +
                           '<td class="centeralign"><a title="Excluir" href="javascript:Excluir(' + empresa[x].CODIGO_EMPRESA + ')" class="deleterow"><i class="icon-trash"></i></a></td>' +
                         '</tr>';
                    jQuery('#dyntable').append(row);
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

                if (empresa != undefined && empresa.length > 0) {
                    var row = '<tr value="' + empresa[0].CODIGO_EMPRESA + '">' +
                               '<td>' + empresa[0].CODIGO_EMPRESA + '</td>' +
                               '<td>' + empresa[0].RAZAO_SOCIAL + '</td>' +
                               '<td>' + empresa[0].CNJP + '</td>' +
                               '<td class="centeralign"><a title="Alterar" href="#myModal" onclick="javascript:FuncaoTelaModal(\'Detalhar\', ' + empresa[0].CODIGO_EMPRESA + ');" data-toggle="modal"><i class="iconfa-pencil"></i></a></td>' +
                               '<td class="centeralign"><a title="Alterar" href="#myModal" onclick="javascript:FuncaoTelaModal(\'Alterar\', ' + empresa[0].CODIGO_EMPRESA + ');" data-toggle="modal"><i class="iconfa-pencil"></i></a></td>' +
                               '<td class="centeralign"><a title="Excluir" href="javascript:Excluir(' + empresa[0].CODIGO_EMPRESA + ')" class="deleterow"><i class="icon-trash"></i></a></td>' +
                             '</tr>';

                    if (id != 0)
                        jQuery('#dyntable tbody tr[value=' + id + ']').remove();

                        jQuery('#dyntable').append(row);

                    MontarGrid();
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

}

function MontarGrid() {
    //jQuery('#gridDependentes').dataTable().fnDestroy();
    //// dynamic table
    //jQuery('#gridDependentes').dataTable({
    //    "sPaginationType": "full_numbers",
    //    "aaSortingFixed": [[0, 'asc']],
    //    "fnDrawCallback": function (oSettings) {
    //        jQuery.uniform.update();
    //    }
    //});
}

function Excluir(id) {
    var conf = confirm('Continue delete?');
    if (conf) {

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

                if (data) {
                    jQuery('#dyntable tbody tr[value=' + id + ']').remove();
                    MontarGrid();
                    alert('Concluído.');
                }
            },
            error: function (XMLHttpRequest, textStatus, errorThrow) {
                errorAjax(textStatus);
                alert(textStatus);
            }
        });
    }
}