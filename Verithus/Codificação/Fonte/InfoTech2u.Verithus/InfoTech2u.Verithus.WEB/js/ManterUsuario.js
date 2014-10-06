jQuery(document).ready(function () {
    CarregarUsuarios();

    CarregarTiposAcessos();
});

function CarregarTiposAcessos() {
    jQuery.ajax({
        type: "GET",
        crossDomain: true,
        url: "../../Handler/ManterTipoAcesso.ashx",
        contentType: "json",
        cache: false,
        data: {
            Metodo: 'Lista',
            Acao: 'Consulta'
        },
        success: function (data) {

            var lista = eval(data);
            jQuery('#ddlTipoAcesso').append("<option value='0'>Escolha</option>");
            for (x in lista) {
                var row = "<option value='" + lista[x].CODIGO_TIPO_ACESSO + "'>" + lista[x].DESCRICAO + "</option>";
                jQuery('#ddlTipoAcesso').append(row);
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrow) {
            errorAjax(textStatus);
            alert(textStatus);
        }
    });
}

function CarregarUsuarios() {
    jQuery.ajax({
        type: "GET",
        crossDomain: true,
        url: "../../Handler/ManterUsuario.ashx",
        contentType: "json",
        cache: false,
        data: {
            Metodo: 'Lista',
            Acao: 'Consulta'
        },
        success: function (data) {

            var usuarios = eval(data);
            if (usuarios != undefined && usuarios.length > 0) {
                for (x in usuarios) {
                    var row = '<tr value="' + usuarios[x].CODIGO_USUARIO + '">' +
                                '<td>' + usuarios[x].NOME + '</td>' +
                                '<td>' + usuarios[x].MAIL + '</td>' +
                                '<td>' + usuarios[x].LOGIN_USUARIO + '</td>' +
                                '<td class="centeralign"><a title="Excluir" href="#modalCadastrar" onclick="javascript:LimparCadastrar();FuncaoTelaModal(\'Alterar\', ' + usuarios[x].CODIGO_USUARIO + ');CarregarUsuario(' + usuarios[x].CODIGO_USUARIO + ');" data-toggle="modal"><i class="iconfa-pencil"></i></a></td>' +
                                '<td class="centeralign"><a title="Excluir" href="javascript:Excluir(' + usuarios[x].CODIGO_USUARIO + ')" class="deleterow"><i class="icon-trash"></i></a></td>' +
                              '</tr>';
                    jQuery('#gridUsuarios tbody').append(row);
                }
            }

            MontarGrid();

        },
        error: function (XMLHttpRequest, textStatus, errorThrow) {
            errorAjax(textStatus);
            alert(textStatus);
        }
    });
}

function CarregarUsuario(codigousuario) {
    jQuery.ajax({
        type: "GET",
        crossDomain: true,
        url: "../../Handler/ManterUsuario.ashx",
        contentType: "json",
        cache: false,
        data: {
            Metodo: 'Lista',
            Acao: 'Consulta',
            CodigoUsuario: codigousuario
        },
        success: function (data) {

            var usuarios = eval(data);
            if (usuarios != undefined && usuarios.length > 0) {
                jQuery('#txtNome').val(usuarios[0].NOME);
                jQuery('#txtEmail').val(usuarios[0].MAIL);
                jQuery('#txtLogin').val(usuarios[0].LOGIN_USUARIO);
                jQuery('#ddlTipoAcesso').val(usuarios[0].CODIGO_TIPO_ACESSO);
            }

        },
        error: function (XMLHttpRequest, textStatus, errorThrow) {
            errorAjax(textStatus);
            alert(textStatus);
        }
    });
}

function Incluir() {
    jQuery.ajax({
        type: "GET",
        crossDomain: true,
        url: "../../Handler/ManterUsuario.ashx",
        contentType: "json",
        cache: false,
        data: {
            Metodo: 'Incluir',
            Acao: 'Incluir',
            Nome: jQuery('#txtNome').val(),
            Email: jQuery('#txtEmail').val(),
            Login: jQuery('#txtLogin').val(),
            Senha: jQuery('#txtSenhaI').val(),
            CodigoTipoAcesso: jQuery('#ddlTipoAcesso').val()
        },
        success: function (data) {

            var lista = eval(data);
            if (lista != undefined && lista.length > 0) {
                if (lista['Erro'] != undefined) {
                    alert('Problemas com a base de dados.');
                } else {
                    var row = '<tr value="' + lista[0].CODIGO_USUARIO + '">' +
                               '<td>' + lista[0].NOME + '</td>' +
                               '<td>' + lista[0].MAIL + '</td>' +
                               '<td>' + lista[0].LOGIN_USUARIO + '</td>' +
                               '<td class="centeralign"><a title="Alterar" href="#modalCadastrar" onclick="javascript:LimparCadastrar();FuncaoTelaModal(\'Alterar\', ' + usuarios[0].CODIGO_USUARIO + ');CarregarUsuario(' + usuarios[0].CODIGO_USUARIO + ');" data-toggle="modal"><i class="iconfa-pencil"></i></a></td>' +
                               '<td class="centeralign"><a title="Excluir" href="javascript:Excluir(' + usuarios[0].CODIGO_USUARIO + ')" class="deleterow"><i class="icon-trash"></i></a></td>' +
                             '</tr>';

                    jQuery('#gridUsuarios tbody').append(row);
                    MontarGrid();
                    alert('Concluído.');
                }
            }
            else {
                alert('Falha na inclusão.');
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrow) {
            errorAjax(textStatus);
            alert(textStatus);
        }
    });
}

function Alterar(codigousuario) {
    if (DadosValidos()) {
        jQuery.ajax({
            type: "GET",
            crossDomain: true,
            url: "../../Handler/ManterUsuario.ashx",
            contentType: "json",
            cache: false,
            data: {
                Metodo: 'Alterar',
                Acao: 'Incluir',
                Nome: jQuery('#txtNome').val(),
                Email: jQuery('#txtEmail').val(),
                CodigoTipoAcesso: jQuery('#ddlTipoAcesso').val(),
                CodigoUsuario: codigousuario
            },
            success: function (data) {

                var lista = eval(data);
                if (lista != undefined && lista.length > 0) {
                    if (lista['Erro'] != undefined) {
                        alert('Problemas com a base de dados.');
                    } else {

                        jQuery('#gridUsuarios tbody tr[value=' + codigousuario + ']').find('td:eq(0)').html(lista[0].NOME);
                        jQuery('#gridUsuarios tbody tr[value=' + codigousuario + ']').find('td:eq(1)').html(lista[0].MAIL);



                        alert('Concluído.');
                    }
                }
                else {
                    alert('Falha na inclusão.');
                }
            },
            error: function (XMLHttpRequest, textStatus, errorThrow) {
                errorAjax(textStatus);
                alert(textStatus);
            }
        });
    }
}

function Excluir(codigousuario) {
    var conf = confirm('Continue delete?');
    if (conf) {

        jQuery.ajax({
            type: "GET",
            crossDomain: true,
            url: "../../Handler/ManterUsuario.ashx",
            contentType: "json",
            cache: false,
            data: {
                Metodo: 'Excluir',
                Acao: 'Exclusao',
                CodigoUsuario: codigousuario
            },
            success: function (data) {

                if (data) {
                    jQuery('#gridUsuarios tbody tr[value=' + codigousuario + ']').remove();
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

function VarificarDados() {
    if (DadosValidos()) {
        jQuery.ajax({
            type: "GET",
            crossDomain: true,
            url: "../../Handler/ManterUsuario.ashx",
            contentType: "json",
            cache: false,
            data: {
                Metodo: "VerificarLogin",
                Acao: "Selecionar",
                Login: jQuery('#txtLogin').val(),
            },
            success: function (data) {

                var lista = eval(data);
                if (lista != undefined && lista.length > 0) {
                    if (lista["Erro"] != undefined) {
                        alert("Problemas com a base de dados.");
                        jQuery("#lblErrorLogin").text('');
                        return;
                    } else {
                        jQuery("#lblErrorLogin").show();
                        jQuery('#lblErrorLogin').text('Login já existe.');
                        return;
                    }
                }
                else {
                    jQuery("#lblErrorLogin").hide();
                }

                Incluir();

            },
            error: function (XMLHttpRequest, textStatus, errorThrow) {
                errorAjax(textStatus);
                alert(textStatus);
            }
        });
    }
}

function DadosValidos() {
    var semErros = true;

    if (jQuery('#txtNome').val() == '') {
        jQuery('#lblErrorNome').show();
        semErros = false;
    }
    else {
        jQuery('#lblErrorNome').hide();
    }

    if (jQuery('#txtEmail').val() == '') {
        jQuery('#lblErrorEmail').show();
        semErros = false;
    }
    else {
        jQuery('#lblErrorEmail').hide();
    }

    if (jQuery('#txtSenhaI').is(':visible') && jQuery('#txtSenhaI').val() == '') {
        jQuery('#lblErrorSenhaI').show();
        semErros = false;
    }
    else {
        jQuery('#lblErrorSenhaI').hide();
    }

    if (jQuery('#txtSenhaII').is(':visible')) {
        if (jQuery('#txtSenhaII').val() == '') {
            jQuery('#lblErrorSenhaII').show();
            jQuery('#lblErrorSenhaII').text('Preencha o campo.');
            semErros = false;
        }
        else {
            if (jQuery('#txtSenhaI').val() != jQuery('#txtSenhaII').val()) {
                jQuery('#lblErrorSenhaII').show();
                jQuery('#lblErrorSenhaII').text('Senhas não coincidem.');
                semErros = false;
            }
            else {
                jQuery('#lblErrorSenhaII').hide();
            }
        }
    }

    if (jQuery('#ddlTipoAcesso').val() == 0) {
        jQuery('#lblErrorTipoAcesso').show();
        semErros = false;
    }
    else {
        jQuery('#lblErrorTipoAcesso').hide();
    }

    if (jQuery('#txtLogin').is(':visible') && jQuery('#txtLogin').val() == '') {
        jQuery('#lblErrorLogin').show();
        jQuery('#lblErrorLogin').text('Preencha o campo.');

        semErros = false;
    }
    else {
        jQuery('#lblErrorLogin').hide();
    }
    return semErros;
}

function LimparCadastrar() {
    jQuery('#lblErrorNome').hide();
    jQuery('#lblErrorEmail').hide();
    jQuery('#lblErrorLogin').hide();
    jQuery('#lblErrorSenhaI').hide();
    jQuery('#lblErrorSenhaII').hide();
    jQuery('#lblErrorTipoAcesso').hide();

    jQuery('#txtNome').val('');
    jQuery('#txtEmail').val('');
    jQuery('#txtLogin').val('');
    jQuery('#txtSenhaI').val('');
    jQuery('#txtSenhaII').val('');
    jQuery('#ddlTipoAcesso').val(0);
}

function MontarGrid() {
    jQuery('#gridUsuarios').dataTable().fnDestroy();
    jQuery('#gridUsuarios').dataTable({
        "sPaginationType": "full_numbers",
        "aaSortingFixed": [[0, 'asc']],
        "fnDrawCallback": function (oSettings) {
            jQuery.uniform.update();
        }
    });
}

function FuncaoTelaModal(funcao, id) {
    if (funcao == 'Cadastro') {
        jQuery('#btnIncluir').attr('href', 'javascript:VarificarDados()');
        jQuery('#modalLabelCadastroAlteracao').text('Cadastro de Usuário');
        jQuery('#lblLogin').show();
        jQuery('#lblSenhaI').show();
        jQuery('#lblSenhaII').show();
        jQuery('#txtLogin').show();
        jQuery('#txtSenhaI').show();
        jQuery('#txtSenhaII').show();
    }
    else if (funcao == 'Alterar') {
        jQuery('#btnIncluir').attr('href', 'javascript:Alterar(' + id + ')');
        jQuery('#modalLabelCadastroAlteracao').text('Alteração de Usuário');
        jQuery('#lblLogin').hide();
        jQuery('#lblSenhaI').hide();
        jQuery('#lblSenhaII').hide();
        jQuery('#txtLogin').hide();
        jQuery('#txtSenhaI').hide();
        jQuery('#txtSenhaII').hide();
    }
}