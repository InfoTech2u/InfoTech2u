<%@ Page Title="" Language="C#" MasterPageFile="~/Modulos/InfoTech2u.Master" AutoEventWireup="true" CodeBehind="ManterAcidenteTrabalho.aspx.cs" Inherits="InfoTech2u.Verithus.WEB.Modulos.RecursosHumanos.ManterAcidenteTrabalho" %>

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

                            <p>
                                <label>Codigo de Acidente de Trabalho</label>
                                <span class="field">
                                    <asp:TextBox runat="server" ID="txtCodigoAcidenteTrabalho" class="input-small" ClientIDMode="Static" ReadOnly="true" />
                                </span>
                            </p>


                            <p id="validaData">
                                <label>Data</label>
                                <span class="field">
                                    <asp:TextBox runat="server" ID="txtData" class="input-small dataddmmaaaa" ClientIDMode="Static" />
                                    <span class="help-inline" id="msgData"></span>
                                </span>
                            </p>

                            <p id="validaLocalAcidente">
                                <label>Local Acidente</label>
                                <span class="field">
                                    <asp:TextBox runat="server" ID="txtLocalAcidente" TextMode="MultiLine" cols="80" rows="5" class="span5 textareaCount" MaxLength="300" ClientIDMode="Static" />
                                    <span class="help-inline" id="msgLocalAcidente"></span>
                                </span>
                            </p>

                            <p id="validaCausaAcidente">
                                <label>Causa Acidente</label>
                                <span class="field">
                                    <asp:TextBox runat="server" ID="txtCausaAcidente" TextMode="MultiLine" cols="80" rows="5" class="span5 textareaCount" MaxLength="300" ClientIDMode="Static" />
                                    <span class="help-inline" id="msgCausaAcidente"></span>
                                </span>
                            </p>

                            <p id="validaDataAlta">
                                <label>Data Alta</label>
                                <span class="field">
                                    <asp:TextBox runat="server" ID="txtDataAlta" class="input-small dataddmmaaaa" ClientIDMode="Static" />
                                    <span class="help-inline" id="msgDataAlta"></span>
                                </span>
                            </p>

                            <p id="validaResultado">
                                <label>Resultado</label>
                                <span class="field">
                                    <asp:TextBox runat="server" ID="txtResultado" TextMode="MultiLine" cols="80" rows="5" class="span5 textareaCount" MaxLength="300" ClientIDMode="Static" />
                                    <span class="help-inline" id="msgResultado"></span>
                                </span>
                            </p>

                            <p id="validaObservacoes">
                                <label>Observações</label>
                                <span class="field">
                                    <asp:TextBox runat="server" ID="txtObservacoes" TextMode="MultiLine" cols="80" rows="5" class="span5 textareaCount" MaxLength="300"  ClientIDMode="Static" />
                                    <span class="help-inline" id="msgObservacoes"></span>
                                </span>
                            </p>

                            
                            <p class="stdformbutton">
                                <a href="#" id="btnConcluirAcidente" class="btn btn-primary btn-rounded">Concluir</a>
                                <a href="#" id="btnLimparAcidente" class="btn btn-rounded"><i class="iconfa-refresh iconsweets-black"></i>&nbsp; limpar</a>
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
