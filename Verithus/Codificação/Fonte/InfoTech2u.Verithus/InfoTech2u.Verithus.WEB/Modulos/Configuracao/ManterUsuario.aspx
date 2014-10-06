<%@ Page Title="" Language="C#" MasterPageFile="~/Modulos/InfoTech2u.Master" AutoEventWireup="true" CodeBehind="ManterUsuario.aspx.cs" Inherits="InfoTech2u.Verithus.WEB.Modulos.Configuracao.ManterUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderInfoTech2u" runat="server">
    
    <div class="rightpanel">

        <ul class="breadcrumbs">
            <li><a href="dashboard.html"><i class="iconfa-home"></i></a><span class="separator"></span></li>
            <li><a href="forms.html">Formulario</a> <span class="separator"></span></li>
            <li>Cadastro de Usuário</li>
        </ul>

        <div class="pageheader">
            <div class="pageicon"><span class="iconfa-pencil"></span></div>
            <div class="pagetitle">
                <h5>Configurações</h5>
                <h1>Cadastro de Usuário</h1>
            </div>
        </div>
        <!--pageheader-->
        <div class="maincontent">
            <div class="maincontentinner">
                <div aria-hidden="false" aria-labelledby="myModalLabel" role="dialog" tabindex="-1" class="modal hide fade in" id="modalCadastrar">
                    <div class="modal-header widgettitle">
                        <button aria-hidden="true" data-dismiss="modal" class="close" type="button">&times;</button>
                        <h3 id="modalLabelCadastroAlteracao">Cadastro de Usuário</h3>

                    </div>
                    <div class="modal-body">
                        <div class="widgetbox box-inverse">

                            <div class="par control-group">
                                <div class="controls">
                                    <p>
                                        <label id="lblNome">Nome</label>
                                        <span class="field">
                                            <asp:TextBox type="text" runat="server" ID="txtNome" CssClass="input-xlarge" placeholder="" ClientIDMode="Static" /></span>
                                        <asp:Label ID="lblErrorNome" CssClass="help-inline" runat="server" ClientIDMode="Static">Informe o nome.</asp:Label>
                                    </p>
                                    <p>
                                        <label id="lblEmail">Email</label>
                                        <span class="field">
                                            <asp:TextBox type="text" runat="server" ID="txtEmail" CssClass="input-xlarge" placeholder="" ClientIDMode="Static" /></span>
                                        <asp:Label ID="lblErrorEmail" CssClass="help-inline" runat="server" ClientIDMode="Static">Email inválido.</asp:Label>
                                    </p>
                                    <p>
                                        <label id="lblLogin">Login</label>
                                        <span class="field">
                                            <asp:TextBox type="text" runat="server" ID="txtLogin" CssClass="input-medium" placeholder="" ClientIDMode="Static" /></span>
                                        <asp:Label ID="lblErrorLogin" CssClass="help-inline" runat="server" ClientIDMode="Static">Informe o login.</asp:Label>
                                    </p>
                                    <p>
                                        <label id="lblSenhaI">Senha</label>
                                        <span class="field">
                                            <asp:TextBox type="text" runat="server" ID="txtSenhaI" CssClass="input-medium" placeholder="" ClientIDMode="Static" TextMode="Password" /></span>
                                        <asp:Label ID="lblErrorSenhaI" CssClass="help-inline" runat="server" ClientIDMode="Static">Informe o login.</asp:Label>
                                    </p>
                                    <p>
                                        <label id="lblSenhaII">Redigite a senha</label>
                                        <span class="field">
                                            <asp:TextBox type="text" runat="server" ID="txtSenhaII" CssClass="input-medium" placeholder="" ClientIDMode="Static" TextMode="Password" /></span>
                                        <asp:Label ID="lblErrorSenhaII" CssClass="help-inline" runat="server" ClientIDMode="Static">Informe o login.</asp:Label>
                                    </p>

                                    <p>
                                        <label id="lblTipoAcesso">Tipo de Acesso</label>
                                        <span class="field">
                                            <asp:DropDownList ID="ddlTipoAcesso" CssClass="uniformselect" runat="server" ClientIDMode="Static"></asp:DropDownList>
                                            <asp:Label ID="lblErrorTipoAcesso" CssClass="help-inline display:none" runat="server" ClientIDMode="Static">Selecione um item.</asp:Label>

                                        </span>
                                    </p>
                                </div>
                            </div>
                            <!--widgetcontent-->
                        </div>
                    </div>

                    <div class="modal-footer">
                        <button data-dismiss="modal" class="btn">&nbsp; Sair</button>
                        <a class="btn btn-primary" id="btnIncluir" href="javascript:VarificarDados()"><i class="iconfa-pencil"></i>&nbsp; Gravar</a>
                    </div>
                </div>
                <!--#myModal-->



                <div class="row-fluid">
                    <a class="btn btn-primary" href="#modalCadastrar" onclick="javascript:LimparCadastrar();FuncaoTelaModal('Cadastro', 0);" data-toggle="modal"><i class="iconfa-pencil"></i>&nbsp; Cadastrar</a>
                </div>




                <h4 class="widgettitle">Usuarios</h4>
                <table class="table table-bordered table-infinite" id="gridUsuarios">
                    <colgroup>
                        <col class="con0" style="align: center; width: 30%" />
                        <col class="con1" style="align: center; width: 30%" />
                        <col class="con0" style="align: center; width: 20%" />
                        <col class="con1" style="align: center; width: 10%" />
                        <col class="con0" style="align: center; width: 10%" />
                    </colgroup>
                    <thead>
                        <tr>
                            <th class="head0">Nome</th>
                            <th class="head1">Email</th>
                            <th class="head0">Login</th>
                            <th class="head1">Alterar</th>
                            <th class="head0">Excluir</th>
                        </tr>
                    </thead>
                    <tbody>
                    </tbody>
                </table>

            </div>
            <!--maincontentinner-->
        </div>
        <!--maincontent-->
    </div>
</asp:Content>
