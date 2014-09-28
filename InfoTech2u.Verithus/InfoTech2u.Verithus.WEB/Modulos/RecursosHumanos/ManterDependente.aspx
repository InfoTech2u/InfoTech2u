<%@ Page Title="" Language="C#" MasterPageFile="~/Modulos/InfoTech2u.Master" AutoEventWireup="true" CodeBehind="ManterDependente.aspx.cs" Inherits="InfoTech2u.Verithus.WEB.Modulos.RecursosHumanos.ManterDependente" %>

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
                <asp:HiddenField ID="hdnCodigoFuncionario" runat="server" ClientIDMode="Static" />
                <div aria-hidden="false" aria-labelledby="myModalLabel" role="dialog" tabindex="-1" class="modal hide fade in" id="modalDependente">
                    <div class="modal-header widgettitle">
                        <button aria-hidden="true" data-dismiss="modal" class="close" type="button">&times;</button>
                        <h3 id="modalDependenteLabel">Dependente</h3>
                        <asp:HiddenField ID="hdnFuncaoTela" runat="server" ClientIDMode="Static" />
                    </div>
                    <div class="modal-body">
                        <div class="widgetbox box-inverse">

                            <div class="par control-group">
                                <label class="control-label" for="nomedependente">Nome Dependente</label>
                                <div class="controls">
                                    <asp:TextBox runat="server" ID="txtNomeDependente" CssClass="input-large" ClientIDMode="Static" />
                                     <asp:Label ID="lblErrorNomeDependente" CssClass="help-inline" runat="server" ClientIDMode="Static">Informe o nome.</asp:Label>
                                </div>
                            </div>

                            <div class="par control-group">
                                <label>Parentesco</label>
                                <span class="field">
                                    <asp:DropDownList runat="server" ID="ddlTipoParentesco" CssClass="input-large chzn-select" TabIndex="2" ClientIDMode="Static" ></asp:DropDownList>
                                     <asp:Label ID="lblErrorTipoParentesco" CssClass="help-inline" runat="server" ClientIDMode="Static">Escolha uma opção.</asp:Label>
                                </span>
                            </div>
                            
                            <div class="control-group">
                                <label class="control-label" for="txtDataNascimento">Data Nascimento</label>
                                <div class="controls">
                                    <asp:TextBox runat="server" ID="txtDataNascimento" CssClass="input-small dataddmmaaaa" ClientIDMode="Static" />
                                     <asp:Label ID="lblErrorDataNascimento" CssClass="help-inline" runat="server" ClientIDMode="Static">Data inválida.</asp:Label>
                                </div>
                            </div>

                            <div class="control-group">
                                <label>Benefícios</label>
                                <span id="dualselect" class="dualselect" style="margin-left: 0px">
                                    <asp:ListBox ID="lstBeneficioSelect" runat="server" SelectionMode="Multiple" ClientIDMode="Static">
                                    </asp:ListBox>
                                    <span class="ds_arrow">
                                        <a href="#" class="btn ds_prev"><i class="iconfa-chevron-left"></i></a>
                                        <br />
                                        <a href="#" class="btn ds_next"><i class="iconfa-chevron-right"></i></a>
                                    </span>
                                     <asp:ListBox ID="lstBeneficioSelected" runat="server" SelectionMode="Multiple" ClientIDMode="Static">
                                        
                                    </asp:ListBox>
                                </span>
                            </div>

                            <!--widgetcontent-->
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button data-dismiss="modal" class="btn">&nbsp; Sair</button>
                        <a class="btn btn-primary" id="btnIncluir" href="#" onclick="javascript:Incluir();" data-toggle="modal"><i class="iconfa-pencil"></i>&nbsp; Gravar</a>
                    </div>
                </div>
                <!--#myModal-->

                <div class="row-fluid">
                    <a class="btn btn-primary" href="#modalDependente" onclick="javascript:FuncaoTelaModal('Incluir', 0);" data-toggle="modal"><i class="iconfa-pencil"></i>&nbsp; Incluir</a>                   
                </div>

                <h4 class="widgettitle">Dependentes</h4>
                <table id="gridDependentes" class="table table-bordered responsive">
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
                            <th class="head1">Parentesco</th>
                            <th class="head0">Data Nascimento</th>
                            <th class="head1">Alterar</th>
                            <th class="head0">Excluir</th>
                        </tr>
                    </thead>
                    <tbody>
                        
                    </tbody>
                </table>
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
