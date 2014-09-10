<%@ Page Title="" Language="C#" MasterPageFile="~/Modulos/InfoTech2u.Master" AutoEventWireup="true" CodeBehind="ManterDemissao.aspx.cs" Inherits="InfoTech2u.Verithus.WEB.Modulos.RecursosHumanos.ManterDemissao" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderInfoTech2u" runat="server">
    <div class="rightpanel">

        <ul class="breadcrumbs">
            <li><a href="dashboard.html"><i class="iconfa-home"></i></a><span class="separator"></span></li>
            <li><a href="forms.html">Forms</a> <span class="separator"></span></li>
            <li>Form Styles</li>

        </ul>

        <div class="pageheader">
            <div class="pageicon"><span class="iconfa-pencil"></span></div>
            <div class="pagetitle">
                <h5>Demissão</h5>
                <h1>Fomulário de Demissão</h1>
            </div>
        </div>
        <!--pageheader-->

        <div class="maincontent">
            <div class="maincontentinner">
                <div class="widgetbox box-inverse">
                    <h4 class="widgettitle">Dados Demissão</h4>
                    <div class="widgetcontent nopadding">
                        <div class="stdform stdform2">

                            <p id="validaDataDeAdmissao">
                                <label>Data de Admissão</label>
                                <span class="field">
                                    <asp:TextBox runat="server" ID="txtDataAdmissao" class="input-small dataddmmaaaa" ClientIDMode="Static" />
                                    <span class="help-inline" id="msgDataDeAdmissao"></span>
                                </span>
                            </p>

                            <p id="validaDataRegistro">
                                <label>Data do Registro</label>
                                <span class="field">
                                    <asp:TextBox runat="server" ID="txtDataRegistro" class="input-small dataddmmaaaa" ClientIDMode="Static" />
                                    <span class="help-inline" id="msgDataRegistro"></span>
                                </span>
                            </p>

                            <p id="validaCargo">
                                <label>Cargo</label>
                                <span class="field">
                                    <asp:DropDownList runat="server" ID="ddlCargo" class="uniformselect" ClientIDMode="Static" />
                                    <span class="help-inline" id="msgCargo"></span>
                                </span>
                            </p>

                            <p id="validaSecao">
                                <label>Seção</label>
                                <span class="field">
                                    <asp:DropDownList runat="server" ID="ddlSecao" class="uniformselect" ClientIDMode="Static" />
                                    <span class="help-inline" id="msgSecao"></span>
                                </span>
                            </p>

                            <p id="validaSalarioInicial">
                                <label>Salário Inicial R$</label>
                                <span class="field">
                                    <asp:TextBox runat="server" ID="txtSalarioInicial" class="input-small" ClientIDMode="Static" />
                                    <span class="help-inline" id="msgSalarioInicial"></span>
                                </span>
                            </p>

                            <p id="validaComissao">
                                <label>Comissões</label>
                                <span class="field">
                                    <asp:TextBox runat="server" ID="txtComissao" class="input-small" ClientIDMode="Static" />
                                    <span class="help-inline" id="msgComissao"></span>
                                </span>
                            </p>

                            <p id="validaTarefa">
                                <label>Tarefa</label>
                                <span class="field">
                                    <asp:DropDownList runat="server" ID="ddlTarefa" class="uniformselect" ClientIDMode="Static" />
                                    <span class="help-inline" id="msgTarefa"></span>
                                </span>
                            </p>

                            <p id="validaFormaPagamento">
                                <label>Forma de Pagamento</label>
                                <span class="field">
                                    <asp:DropDownList runat="server" ID="ddlFormaPagamento" class="uniformselect" ClientIDMode="Static" />
                                    <span class="help-inline" id="msgFormaPagamento"></span>
                                </span>
                            </p>

                            <p class="stdformbutton">
                                <a href="#" id="btnConcluirDemissao" class="btn btn-primary btn-rounded">Concluir</a>
                                <a href="#" id="btnLimparDemissao" class="btn btn-rounded"><i class="iconfa-refresh iconsweets-black"></i>&nbsp; limpar</a>
                            </p>
                        </div>
                    </div>
                </div>
                <!--widget-->

                <div class="footer">
                    <div class="footer-left">
                        <span>&copy; 2013. Shamcey Admin Template. All Rights Reserved.</span>
                    </div>
                    <div class="footer-right">
                        <span>Designed by: <a href="http://themepixels.com/">ThemePixels</a></span>
                    </div>
                </div>
                <!--footer-->

            </div>
            <!--maincontentinner-->
        </div>
        <!--maincontent-->

    </div>
    <!--rightpanel-->
</asp:Content>
