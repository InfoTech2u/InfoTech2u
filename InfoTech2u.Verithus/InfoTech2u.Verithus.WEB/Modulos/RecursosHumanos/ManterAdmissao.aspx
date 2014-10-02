<%@ Page Title="" Language="C#" MasterPageFile="~/Modulos/InfoTech2u.Master" AutoEventWireup="true" CodeBehind="ManterAdmissao.aspx.cs" Inherits="InfoTech2u.Verithus.WEB.Modulos.RecursosHumanos.ManterAdmissao" %>

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
                <h5>Admissão
                </h5>
                <h1>Fomulário de Admissão</h1>
            </div>
        </div>
        <!--pageheader-->

        <div class="maincontent">
            <div class="maincontentinner">
                <div class="widgetbox box-inverse">
                    <h4 class="widgettitle">Dados Admissão</h4>
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
                                    <asp:TextBox runat="server" ID="txtComissao" class="input-block-level" ClientIDMode="Static" />
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

                            <p>
                                <label>Horário de Trabalho</label>
                                <p id="validaHorarioTrabalhoEntrada">
                                    <label>Entrada</label>
                                    <span class="field">
                                        <asp:TextBox runat="server" ID="txtHorarioTrabalhoEntrada" class="input-small horaBrasil" ClientIDMode="Static" />
                                        <span class="help-inline" id="msgHorarioTrabalhoEntrada"></span>
                                    </span>
                                </p>
                                <p id="validaHorarioTrabalhoSaida">
                                    <label>Saída</label>
                                    <span class="field">
                                        <asp:TextBox runat="server" ID="txtHorarioTrabalhoSaida" class="input-small horaBrasil" ClientIDMode="Static" />
                                        <span class="help-inline" id="msgHorarioTrabalhoSaida"></span>
                                    </span>
                                </p>
                            </p>

                            <p>
                                <label>Intervalo de Trabalho</label>
                                <p id="validaIntervaloTrabalhoEntrada">
                                    <label>Entrada</label>
                                    <span class="field">
                                        <asp:TextBox runat="server" ID="txtIntervaloTrabalhoEntrada" class="input-small horaBrasil" ClientIDMode="Static" />
                                        <span class="help-inline" id="msgIntervaloTrabalhoEntrada"></span>
                                    </span>
                                </p>
                                <p id="validaIntervaloTrabalhoSaida">
                                    <label>Saída</label>
                                    <span class="field">
                                        <asp:TextBox runat="server" ID="txtIntervaloTrabalhoSaida" class="input-small horaBrasil" ClientIDMode="Static" />
                                        <span class="help-inline" id="msgIntervaloTrabalhoSaida"></span>
                                    </span>
                                </p>
                            </p>

                            <p>
                                <label>Descanso Semanal</label>
                                <p id="validaDescansoSemanalEntrada">
                                    <label>Entrada</label>
                                    <span class="field">
                                        <asp:DropDownList runat="server" ID="ddlDescansoSemanalEntrada" class="uniformselect" ClientIDMode="Static">
                                            <asp:ListItem Value="0">Selecionar</asp:ListItem>
                                            <asp:ListItem Value="1">Domingo-Feira</asp:ListItem>
                                            <asp:ListItem Value="2">Segunda-Feira</asp:ListItem>
                                            <asp:ListItem Value="3">Terça-Feira</asp:ListItem>
                                            <asp:ListItem Value="4">Quarta-Feira</asp:ListItem>
                                            <asp:ListItem Value="5">Quinta-Feira</asp:ListItem>
                                            <asp:ListItem Value="6">Sexta-Feira</asp:ListItem>
                                            <asp:ListItem Value="7">Sabado-Feira</asp:ListItem>
                                        </asp:DropDownList>
                                        <span class="help-inline" id="msgDescansoSemanalEntrada"></span>
                                    </span>
                                </p>
                                <p id="validaDescansoSemanalSaida">
                                    <label>Saída</label>
                                    <span class="field">
                                        <asp:DropDownList runat="server" ID="ddlDescansoSemanalSaida" class="uniformselect" ClientIDMode="Static">
                                            <asp:ListItem Value="0">Selecionar</asp:ListItem>
                                            <asp:ListItem Value="1">Domingo-Feira</asp:ListItem>
                                            <asp:ListItem Value="2">Segunda-Feira</asp:ListItem>
                                            <asp:ListItem Value="3">Terça-Feira</asp:ListItem>
                                            <asp:ListItem Value="4">Quarta-Feira</asp:ListItem>
                                            <asp:ListItem Value="5">Quinta-Feira</asp:ListItem>
                                            <asp:ListItem Value="6">Sexta-Feira</asp:ListItem>
                                            <asp:ListItem Value="7">Sabado-Feira</asp:ListItem>
                                        </asp:DropDownList>
                                        <span class="help-inline" id="msgDescansoSemanalSaida"></span>
                                    </span>
                                </p>
                            </p>
                            <p class="stdformbutton">
                                <a href="#"  id="btnConcluirAdmissao"  class="btn btn-primary btn-rounded">Concluir</a>
                                <a href="#" id="btnLimparAdmissao" class="btn btn-rounded"><i class="iconfa-refresh iconsweets-black"></i>&nbsp; limpar</a>
                            </p>
                        </div>
                    </div>
                </div>
                <!--widget-->

                <div class="footer">
                    <div class="footer-left">
                        <span>&copy; 2014. Infotech2u. All Rights Reserved.</span>
                    </div>
                    <div class="footer-right">
                        <span>Developer by: <a href="http://infotech2u.com.br/">InfoTech2U</a></span>
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
