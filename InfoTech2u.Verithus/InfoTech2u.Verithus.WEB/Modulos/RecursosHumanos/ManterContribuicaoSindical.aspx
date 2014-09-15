<%@ Page Title="" Language="C#" MasterPageFile="~/Modulos/InfoTech2u.Master" AutoEventWireup="true" CodeBehind="ManterContribuicaoSindical.aspx.cs" Inherits="InfoTech2u.Verithus.WEB.Modulos.RecursosHumanos.ManterContribuicaoSindical" %>

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
                <h5>Forms</h5>
                <h1>Form Styles</h1>
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
                        <div class="par">
                            <label>Período Ano</label>
                            <span class="field">
                                <asp:TextBox ID="datepicker" runat="server"  CssClass="input-small" ClientIDMode="Static" /></span>
                                <asp:Label ID="lblErrorData"  CssClass="help-inline" runat="server" ClientIDMode="Static">Data inválida.</asp:Label>
                        </div>
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
                    <!--widgetcontent-->
                </div>
                <!--widget-->
            </div>
            <!--maincontentinner-->
        </div>
        <!--maincontent-->
    </div>
</asp:Content>
