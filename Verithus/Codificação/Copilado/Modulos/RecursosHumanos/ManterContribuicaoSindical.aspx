<%@ Page Title="" Language="C#" MasterPageFile="~/Modulos/InfoTech2u.Master" AutoEventWireup="true" CodeBehind="ManterContribuicaoSindical.aspx.cs" Inherits="InfoTech2u.Verithus.WEB.Modulos.RecursosHumanos.ManterContribuicaoSindical" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderInfoTech2u" runat="server">
    <div class="rightpanel">
        <asp:HiddenField ID="hdnCodigoUsuario" ClientIDMode="Static" runat="server" />
        <ul class="breadcrumbs">
            <li><a href="Dashboard.aspx"><i class="iconfa-home"></i></a><span class="separator"></span></li>
            <li><a href="Default.aspx">Recursos Humanos</a> <span class="separator"></span></li>
            <li>Dados de Contribuição Sindical</li>
        </ul>

        <div class="pageheader">
            <div class="pageicon"><span class="iconfa-pencil"></span></div>
            <div class="pagetitle">
                <h5>Formulario</h5>
                <h1>Contribução Sindical</h1>
            </div>
        </div>
        <!--pageheader-->
        <div class="maincontent">
            <div class="maincontentinner">
                <div class="widget">
                    <h4 class="widgettitle">Contribuição Sindical</h4>
                    <div class="widgetcontent">
                        <asp:HiddenField ID="hdnCodigoFuncionario" runat="server" ClientIDMode="Static" Value="0" />
                        <asp:HiddenField ID="hdnCodigoContribuicaoSindical" Value="0" runat="server" ClientIDMode="Static" />
                        


                        <p id="validaDataNascimento">
                            <label>Período Ano</label>
                            <span class="field">
                                <asp:TextBox runat="server" ID="datepicker" CssClass="input-small txtDataFilMesAno dataddmmaaaa" ClientIDMode="Static" />
                                <asp:Label ID="lblErrorData"  CssClass="help-inline" runat="server" ClientIDMode="Static">Data inválida.</asp:Label>
                            </span>
                        </p>


                        <p>
                            <label>Sindicato</label>
                            <span class="field">
                                <asp:DropDownList ID="ddlSindicato" CssClass="uniformselect" runat="server" ClientIDMode="Static"></asp:DropDownList>
                                <asp:Label ID="lblErrorSindicato" CssClass="help-inline display:none" runat="server" ClientIDMode="Static">Selecione um item.</asp:Label>
                                
                            </span>
                        </p>
                        <p>
                            <label>Valor da Contribuição</label>
                            <span class="field"><asp:TextBox type="text" runat="server" ID="txtVlrContribuicao"  class="input-medium" placeholder="" ClientIDMode="Static" /></span>
                            <asp:Label ID="lblErrorVlrContribuicao" CssClass="help-inline" runat="server" ClientIDMode="Static">Informe o valor.</asp:Label>
                        </p>

                        <p class="stdformbutton">
                                <a href="javascript:Incluir()" class="btn btn-primary">Salvar</a>
                                <a href="javascript:Excluir()" class="btn btn-primary">Excluir</a>
                            </p>

                    </div>
                    <div class="row-fluid btnAcao" runat="server" id="divBtnAcao">
                    <button class="btn btnVoltar" id="btnVoltar"><i class="iconsweets-magnifying"></i>&nbsp; Voltar</button>
                </div>
                    <!--widgetcontent-->
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
</asp:Content>
