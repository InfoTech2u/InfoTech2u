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
                <h5>Forms</h5>
                <h1>Form Styles</h1>
            </div>
        </div>
        <!--pageheader-->

        <div class="maincontent">
            <div class="maincontentinner">
                <div class="widgetbox box-inverse">
                    <h4 class="widgettitle">With Form Validation</h4>
                    <div class="widgetcontent nopadding">
                        <div class="stdform stdform2">
                            <p>
                                <label>Data de Admissão</label>
                                <span class="field">
                                    <asp:TextBox runat="server" ID="txtCodigoFuncionario" class="input-small" ClientIDMode="Static" />
                                </span>
                            </p>

                            <p>
                                <label>Data do Registro</label>
                                <span class="field">
                                    <asp:TextBox runat="server" ID="TextBox1" class="input-small" ClientIDMode="Static" />
                                </span>
                            </p>

                            <p>
                                <label>Cargo</label>
                                <span class="field">
                                    <asp:TextBox runat="server" ID="TextBox2" class="input-small" ClientIDMode="Static" />
                                </span>
                            </p>

                            <p>
                                <label>Sessão</label>
                                <span class="field">
                                    <asp:TextBox runat="server" ID="TextBox3" class="input-small" ClientIDMode="Static" />
                                </span>
                            </p>

                            <p>
                                <label>Salário Inicial R$</label>
                                <span class="field">
                                    <asp:TextBox runat="server" ID="TextBox4" class="input-small" ClientIDMode="Static" />
                                </span>
                            </p>

                            <p>
                                <label>Comissões</label>
                                <span class="field">
                                    <asp:TextBox runat="server" ID="TextBox5" class="input-small" ClientIDMode="Static" />
                                </span>
                            </p>

                            <p>
                                <label>Tarefa</label>
                                <span class="field">
                                    <asp:TextBox runat="server" ID="TextBox6" class="input-small" ClientIDMode="Static" />
                                </span>
                            </p>







                            <p class="stdformbutton">
                                <a href="#" class="btn btn-primary btn-rounded"><i class="iconsweets-magnifying iconsweets-white"></i>&nbsp; Pesquisar</a>
                                <a href="#" class="btn btn-rounded"><i class="iconfa-refresh iconsweets-black"></i>&nbsp; limpar</a>
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
