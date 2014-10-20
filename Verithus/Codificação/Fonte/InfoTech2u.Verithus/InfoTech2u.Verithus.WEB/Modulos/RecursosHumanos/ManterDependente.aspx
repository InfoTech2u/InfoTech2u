<%@ Page Title="" Language="C#" MasterPageFile="~/Modulos/InfoTech2u.Master" AutoEventWireup="true" CodeBehind="ManterDependente.aspx.cs" Inherits="InfoTech2u.Verithus.WEB.Modulos.RecursosHumanos.ManterDependente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderInfoTech2u" runat="server">
    <div class="rightpanel">

        <ul class="breadcrumbs">
            <li><a href="Dashboard.aspx"><i class="iconfa-home"></i></a><span class="separator"></span></li>
            <li><a href="Default.aspx">Recursos Humanos</a> <span class="separator"></span></li>
            <li>Dados Dependente</li>
        </ul>

        <div class="pageheader">
            <div class="pageicon"><span class="iconfa-pencil"></span></div>
            <div class="pagetitle">
                <h5>Formulário</h5>
                <h1>Dependente</h1>
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
                            
                            <p id="validaDataNascimento">
                            <label>Data Nascimento</label>
                            <span class="field">
                                <asp:TextBox runat="server" ID="txtDataNascimento" CssClass="input-small txtDataFilMesAno dataddmmaaaa" ClientIDMode="Static" />
                                     <asp:Label ID="lblErrorDataNascimento" CssClass="help-inline" runat="server" ClientIDMode="Static">Data inválida.</asp:Label>
                            </span>
                        </p>

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
                        <col class="con1" style="align: center; width: 5%" />
                        <col class="con0" style="align: center; width: 25%" />
                        <col class="con1" style="align: center; width: 25%" />
                        <col class="con0" style="align: center; width: 15%" />
                        <col class="con1" style="align: center; width: 10%" />
                        <col class="con1" style="align: center; width: 10%" />
                        <col class="con0" style="align: center; width: 10%" />
                    </colgroup>
                    <thead>
                        <tr>
                            <th class="head0">Id</th>
                            <th class="head1">Nome</th>
                            <th class="head0">Parentesco</th>
                            <th class="head1">Data Nascimento</th>
                            <th class="head0">Detalhar</th>
                            <th class="head1">Alterar</th>
                            <th class="head0">Excluir</th>
                        </tr>
                    </thead>
                    <tbody>
                        
                    </tbody>
                </table>
                <div class="row-fluid btnAcao" runat="server" id="divBtnAcao">
                    <button class="btn btnVoltar" id="btnVoltar"><i class="iconsweets-magnifying"></i>&nbsp; Voltar</button>
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
