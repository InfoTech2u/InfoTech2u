<%@ Page Title="" Language="C#" MasterPageFile="~/Modulos/InfoTech2u.Master" AutoEventWireup="true" CodeBehind="ManterEmpresa.aspx.cs" Inherits="InfoTech2u.Verithus.WEB.Modulos.RecursosHumanos.Empresa.ManterEmpresa" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderInfoTech2u" runat="server">
<div class="rightpanel">

        <ul class="breadcrumbs">
            <li><a href="dashboard.html"><i class="iconfa-home"></i></a><span class="separator"></span></li>
            <li><a href="forms.html">Formulario</a> <span class="separator"></span></li>
            <li>Empresa</li>
        </ul>

        <div class="pageheader">
            <div class="pageicon"><span class="iconfa-pencil"></span></div>
            <div class="pagetitle">
                <h5>Formulario</h5>
                <h1>Empresa</h1>
            </div>
        </div>
        <!--pageheader-->
        <div class="maincontent">
            <div class="maincontentinner">
                <div aria-hidden="false" aria-labelledby="myModalLabel" role="dialog" tabindex="-1" class="modal hide fade in" id="myModal">
                    <div class="modal-header widgettitle">
                        <button aria-hidden="true" data-dismiss="modal" class="close" type="button">&times;</button>
                        <h3 id="myModalLabel">Empresa</h3>
                        <asp:HiddenField ID="hdnFuncaoTela" runat="server" ClientIDMode="Static" />
                    </div>
                    <div class="modal-body">
                        <div class="widgetbox box-inverse">
                            
                            <div class="par control-group">
                                <label class="control-label" for="txtCodigoEmpresa">Codigo Empresa</label>
                                <div class="controls">
                                    <asp:TextBox runat="server" ID="txtCodigoEmpresa" class="input-small" ClientIDMode="Static" ReadOnly="true" />
                                </div>
                            </div>

                            <div class="par control-group">
                                <label class="control-label" for="txtNomeFantasia">Nome Fantasia</label>
                                <div class="controls">
                                    <asp:TextBox runat="server" ID="txtNomeFantasia" class="input-block-level" ClientIDMode="Static" />
                                    <asp:Label ID="lblErrorNomeFantasia" CssClass="help-inline" runat="server" ClientIDMode="Static">Informe o Nome Fantasia.</asp:Label>
                                </div>
                            </div>

                            <div class="par control-group">
                                <label class="control-label" for="txtRazaoSocial">Razão Social</label>
                                <div class="controls">
                                    <asp:TextBox runat="server" ID="txtRazaoSocial" class="input-block-level" ClientIDMode="Static" />
                                    <asp:Label ID="lblErrorRazaoSocial" CssClass="help-inline" runat="server" ClientIDMode="Static">Informe o Razão Social.</asp:Label>
                                </div>
                            </div>

                            <div class="par control-group">
                                <label class="control-label" for="txtCNPJ">CNPJ</label>
                                <div class="controls">
                                    <asp:TextBox runat="server" ID="txtCNPJ" class="input-medium" ClientIDMode="Static" />
                                    <asp:Label ID="lblErrorCNPJ" CssClass="help-inline" runat="server" ClientIDMode="Static">Informe o CNPJ.</asp:Label>
                                </div>
                            </div>

                            <div class="par control-group">
                                <label class="control-label" for="txtInscricaoEstadual">Inscrição Estadual</label>
                                <div class="controls">
                                    <asp:TextBox runat="server" ID="txtInscricaoEstadual" class="input-medium" ClientIDMode="Static" />
                                    <asp:Label ID="lblErrorInscricaoEstadual" CssClass="help-inline" runat="server" ClientIDMode="Static">Informe o Inscrição Estadual.</asp:Label>
                                </div>
                            </div>

                            <!--widgetcontent-->
                        </div>
                    </div>

                    <div class="modal-footer">
                        <button data-dismiss="modal" class="btn">&nbsp; Sair</button>
                        <a class="btn btn-primary" id="btnIncluir" href="#" data-toggle="modal"><i class="iconfa-pencil"></i>&nbsp; Gravar</a>
                    </div>
                </div>
                <!--#myModal-->

                <div class="row-fluid">
                    <a class="btn btn-primary" href="#myModal" data-toggle="modal"><i class="iconfa-pencil"></i>&nbsp; Incluir</a>                   
                </div>

                <h4 class="widgettitle">Empresa</h4>
            	<table id="dyntable" class="table table-bordered responsive">
                    <colgroup>
                        <col class="con0" style="align: center; width: 4%" />
                        <col class="con1" style="align: center; width: 50%" />
                        <col class="con1" style="align: center; width: 25%" />
                        <col class="con0" style="align: center; width: 6%" />
                        <col class="con0" style="align: center; width: 6%" />
                        <col class="con0" style="align: center; width: 6%" />
                        
                    </colgroup>
                    <thead>
                        <tr>
                            <th>Id</th>
                            <th>Razão Social</th>
                            <th>CNPJ</th>
                            <th>Detalhar</th>
                            <th>Alterar</th>
                            <th>Excluir</th>
                        </tr>
                    </thead>
                    <tbody>
                       
                       
                    </tbody>
                </table>
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
</asp:Content>
