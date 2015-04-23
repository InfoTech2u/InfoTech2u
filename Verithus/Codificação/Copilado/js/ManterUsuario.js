jQuery(document).ready(function () {
    CarregarUsuarios();

    jQuery('#gridUsuarios').dataTable({
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

    jQuery('#gridUsuarios tbody').on('click', 'tr', function () {
        if (jQuery(this).hasClass('selected')) {
            //jQuery(this).removeClass('selected');
        }
        else {
            jQuery('#gridUsuarios tr.selected').removeClass('selected');
            jQuery(this).addClass('selected');
        }
    });

    CarregarTiposAcessos();
    CarregarStatus();
});

function CarregarStatus()
{
    jQuery.ajax({
        type: "GET",
        crossDomain: true,
        url: "../../Handler/ManterStatus.ashx",
        contentType: "json",
        cache: false,
        data: {
            Metodo: 'Listar',
            Acao: 'Consulta'
        },
        success: function (data) {
            if (data['Msg'] != null) {
                jQuery('#myModal').modal('hide');

                jQuery(window.document.location).attr('href', '../../Login.aspx?cod=300');

                return;
            } else {
            var lista = eval(data);
            jQuery('#ddlStatus').append("<option value='0'>Escolha</option>");
            for (x in lista) {
                var row = "<option value='" + lista[x].CodigoStatus + "'>" + lista[x].Descricao + "</option>";
                jQuery('#ddlStatus').append(row);
            }
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrow) {
            errorAjax(textStatus);
            alert(textStatus);
        }
    });
}

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
            if (data['Msg'] != null) {
                jQuery('#myModal').modal('hide');

                jQuery(window.document.location).attr('href', '../../Login.aspx?cod=300');

                return;
            } else {
            var lista = eval(data);
            jQuery('#ddlTipoAcesso').append("<option value='0'>Escolha</option>");
            for (x in lista) {
                var row = "<option value='" + lista[x].CODIGO_TIPO_ACESSO + "'>" + lista[x].DESCRICAO + "</option>";
                jQuery('#ddlTipoAcesso').append(row);
            }
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
            if (data['Msg'] != null) {
                jQuery('#myModal').modal('hide');

                jQuery(window.document.location).attr('href', '../../Login.aspx?cod=300');

                return;
            } else {
                var tipos = eval(data);

                if (tipos.length > 0) {

                    for (x in tipos) {
                        jQuery('#gridUsuarios').DataTable().row.add([
                            tipos[x].NOME,
                            tipos[x].MAIL,
                            tipos[x].LOGIN_USUARIO,
                            tipos[x].STATUS_DESCRICAO,
                            '<a title="Alterar" href="#modalCadastrar" onclick="javascript:LimparCadastrar();FuncaoTelaModal(\'Alterar\', ' + tipos[x].CODIGO_USUARIO + ');CarregarUsuario(' + tipos[x].CODIGO_USUARIO + ');" data-toggle="modal"><i class="iconfa-pencil"></i></a>'                            
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
            if (data['Msg'] != null) {
                jQuery('#myModal').modal('hide');

                jQuery(window.document.location).attr('href', '../../Login.aspx?cod=300');

                return;
            } else {
            var usuarios = eval(data);
            if (usuarios != undefined && usuarios.length > 0) {
                jQuery('#txtNome').val(usuarios[0].NOME);
                jQuery('#txtEmail').val(usuarios[0].MAIL);
                jQuery('#txtLogin').val(usuarios[0].LOGIN_USUARIO);
                jQuery('#txtSenhaI').val(usuarios[0].SENHA);
                jQuery('#txtSenhaII').val(usuarios[0].SENHA);

                jQuery('#ddlTipoAcesso').val(usuarios[0].CODIGO_TIPO_ACESSO);
                jQuery('#ddlStatus').val(usuarios[0].CODIGO_STATUS);
            }
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
            CodigoTipoAcesso: jQuery('#ddlTipoAcesso').val(),
            CodigoStatus: jQuery('#ddlStatus').val()
        },
        success: function (data) {
            if (data['Msg'] != null) {
                jQuery('#myModal').modal('hide');

                jQuery(window.document.location).attr('href', '../../Login.aspx?cod=300');

                return;
            } else {
            var lista = eval(data);

            if (lista['Msg'] != null) {
                jQuery('#myModal').modal('hide');

                jQuery(window.document.location).attr('href', '../../Login.aspx?cod=300');

                return;
                } else {

                if (lista[0].Erro != null) {
                    jQuery.alerts.dialogClass = 'alert-danger';
                    jAlert(lista[0].Mensagem, 'Alerta', function () {
                        jQuery.alerts.dialogClass = null; // reset to default
                    });
                } else {

                    if (lista.length > 0) {
                        jQuery('#gridUsuarios').DataTable().row.add([
                           lista[0].NOME,
                           lista[0].MAIL,
                           lista[0].LOGIN_USUARIO,
                           lista[0].STATUS_DESCRICAO,
                           '<a title="Alterar" href="#modalCadastrar" onclick="javascript:LimparCadastrar();FuncaoTelaModal(\'Alterar\', ' + lista[0].CODIGO_USUARIO + ');CarregarUsuario(' + lista[0].CODIGO_USUARIO + ');" data-toggle="modal"><i class="iconfa-pencil"></i></a>'
                           
                        ]).draw();

                        //Sucesso
                        jQuery.alerts.dialogClass = 'alert-success';
                        jAlert('Item foi incluído', 'Informação', function () {
                            jQuery.alerts.dialogClass = null; // reset to default
                        });

                        LimparCadastrar();
            }
            else {
                        jQuery.alerts.dialogClass = 'alert-danger';
                        jAlert('Inclusão não foi realizada.', 'Alerta', function () {
                            jQuery.alerts.dialogClass = null; // reset to default
                        });

                    }
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
                Senha: jQuery('#txtSenhaI').val(),
                CodigoTipoAcesso: jQuery('#ddlTipoAcesso').val(),
                CodigoStatus: jQuery('#ddlStatus').val(),
                CodigoUsuario: codigousuario
            },
            success: function (data) {
                var lista = eval(data);
                if (data['Msg'] != null) {
                    jQuery('#myModal').modal('hide');

                    jQuery(window.document.location).attr('href', '../../Login.aspx?cod=300');

                    return;
                    } else {

                    if (lista[0].Erro != null) {
                        jQuery.alerts.dialogClass = 'alert-danger';
                        jAlert(lista[0].Mensagem, 'Alerta', function () {
                            jQuery.alerts.dialogClass = null; // reset to default
                        });
                    } else {

                        if (lista.length > 0) {
                            jQuery('#gridUsuarios').DataTable().row('.selected').remove().draw(false);
                            jQuery('#gridUsuarios').DataTable().row.add([
                               lista[0].NOME,
                               lista[0].MAIL,
                               lista[0].LOGIN_USUARIO,
                               lista[0].STATUS_DESCRICAO,
                               '<a title="Alterar" href="#modalCadastrar" onclick="javascript:LimparCadastrar();FuncaoTelaModal(\'Alterar\', ' + lista[0].CODIGO_USUARIO + ');CarregarUsuario(' + lista[0].CODIGO_USUARIO + ');" data-toggle="modal"><i class="iconfa-pencil"></i></a>'                               
                            ]).draw();

                            //Sucesso
                            jQuery.alerts.dialogClass = 'alert-success';
                            jAlert('Item foi alterado.', 'Informação', function () {
                                jQuery.alerts.dialogClass = null; // reset to default
                            });

                            jQuery('#modalCadastrar').modal('hide')
                }
                else {
                            jQuery.alerts.dialogClass = 'alert-danger';
                            jAlert('Alteraçãa não foi realizada.', 'Alerta', function () {
                                jQuery.alerts.dialogClass = null; // reset to default
                            });

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
                if (data['Msg'] != null) {
                    jQuery('#myModal').modal('hide');

                    jQuery(window.document.location).attr('href', '../../Login.aspx?cod=300');

                    return;
                } else {
                if (data) {
                        jQuery('#gridUsuarios').DataTable().row('.selected').remove().draw(false);
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
                if (data['Msg'] != null) {
                    jQuery('#myModal').modal('hide');

                    jQuery(window.document.location).attr('href', '../../Login.aspx?cod=300');

                    return;
                } else {
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
                }
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

    if (jQuery('#ddlStatus').val() == 0) {
        jQuery('#lblErrorStatus').show();
        semErros = false;
    }
    else {
        jQuery('#lblErrorStatus').hide();
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
    jQuery('#lblErrorStatus').hide();

    jQuery('#txtNome').val('');
    jQuery('#txtEmail').val('');
    jQuery('#txtLogin').val('');
    jQuery('#txtSenhaI').val('');
    jQuery('#txtSenhaII').val('');
    jQuery('#ddlTipoAcesso').val(0);
    jQuery('#ddlStatus').val(0);
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
        jQuery('#txtLogin').hide();
        //jQuery('#lblSenhaI').hide();
        //jQuery('#lblSenhaII').hide();        
        //jQuery('#txtSenhaI').hide();
        //jQuery('#txtSenhaII').hide();
    }
}