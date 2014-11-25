<%@ Page Title="" Language="C#" MasterPageFile="~/Modulos/InfoTech2u.Master" AutoEventWireup="true" CodeBehind="ManterAlteracaoCargoSalarioFuncionario.aspx.cs" Inherits="InfoTech2u.Verithus.WEB.Modulos.RecursosHumanos.ManterAlteracaoCargoSalarioFuncionario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderInfoTech2u" runat="server">
    <div class="rightpanel">

        <ul class="breadcrumbs">
            <li><a href="Dashboard.aspx"><i class="iconfa-home"></i></a><span class="separator"></span></li>
            <li><a href="Default.aspx">Recursos Humanos</a> <span class="separator"></span></li>
            <li>Alteração de Cargo e Salario</li>
        </ul>

        <div class="pageheader">
            <div class="pageicon"><span class="iconfa-pencil"></span></div>
            <div class="pagetitle">
                <h5>Formulário</h5>
                <h1>Alteração de Cargo e Salario</h1>
            </div>
        </div>
        <!--pageheader-->
        <div class="maincontent">
            <div class="maincontentinner">
                <div aria-hidden="false" aria-labelledby="myModalLabel" role="dialog" tabindex="-1" class="modal hide fade in" id="myModal">
                    <div class="modal-header widgettitle">
                        <button aria-hidden="true" data-dismiss="modal" class="close" type="button">&times;</button>
                        <h3 id="myModalLabel">Alteração de Cargo e Salario</h3>
                        <asp:HiddenField ID="hdnFuncaoTela" runat="server" ClientIDMode="Static" />
                    </div>
                    <div class="modal-body">
                        <div class="widgetbox box-inverse">

                            <h4 class="widgettitle">Dados Ferias</h4>
                            <div class="widgetcontent nopadding">
                                <div class="stdform stdform2">

                                    <p>
                                        <label>Codigo de Alteração Cargo Salario</label>
                                        <span class="field">
                                            <asp:TextBox runat="server" ID="txtCodigoAlteracaoCargoSalario" class="input-small" ClientIDMode="Static" ReadOnly="true" />
                                        </span>
                                    </p>


                                    <p id="validaData">
                                        <label>Data</label>
                                        <span class="field">
                                            <asp:TextBox runat="server" ID="txtData" class="input-small dataddmmaaaa" ClientIDMode="Static" />
                                            <span class="help-inline" id="msgData"></span>
                                        </span>
                                    </p>

                                    <p id="validaCargo">
                                        <label>Cargo</label>
                                        <span class="field">
                                            <asp:DropDownList runat="server" ID="ddlCargo" class="uniformselect" ClientIDMode="Static" />
                                            <span class="help-inline" id="msgCargo"></span>
                                        </span>
                                    </p>

                                    <p id="validaSalario">
                                        <label>Salário R$</label>
                                        <span class="field">
                                            <asp:TextBox runat="server" ID="txtSalario" class="input-small" ClientIDMode="Static" />
                                            <span class="help-inline" id="msgSalario"></span>
                                        </span>
                                    </p>

                                    <p>
                                        <label>Horário</label>
                                        <p id="validaHorarioEntrada">
                                            <label>Entrada</label>
                                            <span class="field">
                                                <asp:TextBox runat="server" ID="txtHorarioEntrada" class="input-small horaBrasil" ClientIDMode="Static" />
                                                <span class="help-inline" id="msgHorarioEntrada"></span>
                                            </span>
                                        </p>
                                        <p id="validaHorarioSaida">
                                            <label>Saída</label>
                                            <span class="field">
                                                <asp:TextBox runat="server" ID="txtHorarioSaida" class="input-small horaBrasil" ClientIDMode="Static" />
                                                <span class="help-inline" id="msgHorarioSaida"></span>
                                            </span>
                                        </p>
                                    </p>

                                </div>
                            </div>
                            <!--widgetcontent-->
                        </div>
                    </div>

                    <div class="modal-footer">
                        <button data-dismiss="modal" class="btn">&nbsp; Sair</button>
                        <a href="#" id="btnLimparAlteracaoCargoSalario" class="btn btn-rounded"><i class="iconfa-refresh iconsweets-black"></i>&nbsp; limpar</a>
                        <a class="btn btn-primary" id="btnConcluirAlteracaoCargoSalario" href="#" data-toggle="modal"><i class="iconfa-pencil"></i>&nbsp; Gravar</a>
                    </div>
                </div>
                <!--#myModal-->

                <div class="row-fluid">
                    <a class="btn btn-primary" onclick="javascript:Incluir();" href="#myModal" data-toggle="modal"><i class="iconfa-pencil"></i>&nbsp; Incluir</a>
                </div>

                <h4 class="widgettitle">Alteração de Cargo e Salario</h4>
                <table id="dyntable" class="table table-bordered responsive">
                    <colgroup>
                        <col class="con0" />
                        <col class="con1" />
                        <col class="con0" />
                        <col class="con1" />
                        <col class="con0" />
                        <col class="con1" />
                    </colgroup>
                    <thead>
                        <tr>
                            <th>Id</th>
                            <th>Data</th>
                            <th>Cargo</th>
                            <th>Salario</th>
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
