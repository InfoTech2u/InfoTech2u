<%@ Page Title="" Language="C#" MasterPageFile="~/Modulos/InfoTech2u.Master" AutoEventWireup="true" CodeBehind="PesquisaFuncionario.aspx.cs" Inherits="InfoTech2u.Verithus.WEB.Modulos.RecursosHumanos.Funcionario.PesquisaFuncionario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderInfoTech2u" runat="server">
    <div class="rightpanel">
        <asp:HiddenField runat="server" ID="hdnIdUser" ClientIDMode="Static" />
        <ul class="breadcrumbs">
            <li><a href="Dashboard.aspx"><i class="iconfa-home"></i></a><span class="separator"></span></li>
            <li><a href="Default.aspx">Recursos Humanos</a> <span class="separator"></span></li>
            <li>Pesquisa de Funcionários</li>

        </ul>

        <div class="pageheader">
            <div class="pageicon"><span class="iconfa-pencil"></span></div>
            <div class="pagetitle">
                <h5>Formulario</h5>
                <h1>Pesquisa de Funcionários</h1>
            </div>
        </div>
        <!--pageheader-->

        <div class="maincontent">
            <div class="maincontentinner">




                <div class="widgetbox box-inverse">
                    <h4 class="widgettitle">Formulario de Pesquisa de Funcionario</h4>
                    <div class="widgetcontent nopadding">
                        <div class="stdform stdform2">
                            <p>
                                <label>Codigo do Funcionario</label>
                                <span class="field">
                                    <asp:TextBox runat="server" ID="txtCodigoFuncionario" class="input-small" ClientIDMode="Static" />
                                </span>
                            </p>

                            <p>
                                <label>Ordem Matricula</label>
                                <span class="field">
                                    <asp:TextBox runat="server" ID="txtNumeroOrdemMatricula" class="input-small" ClientIDMode="Static" />
                                </span>
                            </p>

                            <p>
                                <label>Matricula</label>
                                <span class="field">
                                    <asp:TextBox runat="server" ID="txtNumeroMatricula" class="input-small" ClientIDMode="Static" />
                                </span>
                            </p>

                            <p>
                                <label>Nome Funcionario</label>
                                <span class="field">
                                    <asp:TextBox runat="server" ID="txtNomeFuncionario" class="input-xxLarge" ClientIDMode="Static" />
                                </span>
                            </p>

                            <p class="stdformbutton">
                                <a href="#" class="btn btn-primary btn-rounded" id="btnPesquisar"><i class="iconsweets-magnifying iconsweets-white"></i>&nbsp; Pesquisar</a>
                                <a href="#" class="btn btn-rounded" id="btnLimpar"><i class="iconfa-refresh iconsweets-black"></i>&nbsp; limpar</a>
                            </p>

                        </div>
                    </div>
                </div>

                <h4 class="widgettitle dyntable">Funcionários</h4>
                <table id="dyntable" class=" order-column table table-bordered responsive">
                    <colgroup>
                        <col class="con0" style="align: center; width: 4%" />
                        <col class="con1" />
                        <col class="con0" />
                        <col class="con1" />
                        <col class="con0" />
                    </colgroup>
                    <thead>
                        <tr>
                            <th class="head0">Selecionar</th>
                            <th class="head1">Código Funcionario</th>
                            <th class="head0">Ordem de Matricula</th>
                            <th class="head1">Matricula</th>
                            <th class="head0">Nome Completo</th>
                        </tr>
                    </thead>
                    <tbody></tbody>
                </table>
                <br />
                <div class="row-fluid btnAcao">
                    <button class="btn btn-primary" id="btnIncluir"><i class="iconsweets-magnifying"></i>&nbsp; Incluir</button>
                    <button class="btn" id="btnAlterar"><i class="iconsweets-magnifying"></i>&nbsp; Alterar</button>
                    <button class="btn" id="btnExcluir"><i class="iconsweets-magnifying"></i>&nbsp; Excluir</button>
                    <button class="btn" id="btnDetalhar"><i class="iconsweets-magnifying"></i>&nbsp; Detalhar</button>
                    <button class="btn" id="btnAdmisao"><i class="iconsweets-magnifying"></i>&nbsp; Admissão</button>
                    <button class="btn" id="btnDemissao"><i class="iconsweets-magnifying"></i>&nbsp; Demissão</button>
                    <button class="btn" id="btnDependente"><i class="iconsweets-magnifying"></i>&nbsp; Dependentes</button>
                    <button class="btn" id="btnSindical"><i class="iconsweets-magnifying"></i>&nbsp; Contribuição Sindical</button>
                    <button class="btn" id="btnFerias"><i class="iconsweets-magnifying"></i>&nbsp; Ferias</button>
                    <button class="btn" id="btnAcidenteTrabalho"><i class="iconsweets-magnifying"></i>&nbsp; Acidente de Trabalho</button>
                    <button class="btn" id="btnAlteracaoCargoSalario"><i class="iconsweets-magnifying"></i>&nbsp; Alteração de Cargo e Salario</button>
                    <button class="btn" id="btnRelatorioFuncionarioGeral"><i class="iconsweets-magnifying"></i>&nbsp; Relatorio Funcionario</button>
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
