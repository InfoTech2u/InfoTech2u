<%@ Page Title="" Language="C#" MasterPageFile="~/Modulos/InfoTech2u.Master" AutoEventWireup="true" CodeBehind="ManterFuncionario.aspx.cs" Inherits="InfoTech2u.Verithus.WEB.Modulos.RecursosHumanos.Funcionario.ManterFuncionario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderInfoTech2u" runat="server">
    <div class="rightpanel">

        <ul class="breadcrumbs">
            <li><a href="dashboard.html"><i class="iconfa-home"></i></a><span class="separator"></span></li>
            <li><a href="forms.html">Recursos Humanos</a> <span class="separator"></span></li>
            <li>Cadastros de Funcionario</li>
        </ul>

        <div class="pageheader">
            <div class="pageicon"><span class="iconfa-pencil"></span></div>
            <div class="pagetitle">
                <h5>Cadastro</h5>
                <h1>Funcionário</h1>
            </div>
        </div>
        <!--pageheader-->

        <div class="maincontent">
            <div class="maincontentinner">

                <!-- START OF TABBED WIZARD -->
                <h4 class="subtitle2">Formulario de Cadastros</h4>
                <br />

                <div id="wizard3" class="wizard tabbedwizard">

                    <ul class="tabbedmenu">
                        <li>
                            <a href="#wiz3step1">
                                <span class="h2">PASSO 1</span>
                                <span class="label">Dados Pessoais</span>
                            </a>
                        </li>
                        <li>
                            <a href="#wiz3step2">
                                <span class="h2">PASSO 2</span>
                                <span class="label">Documentos</span>
                            </a>
                        </li>
                        <li>
                            <a href="#wiz3step3">
                                <span class="h2">PASSO 3</span>
                                <span class="label">Dados fisicos</span>
                            </a>
                        </li>
                        <li>
                            <a href="#wiz3step4">
                                <span class="h2">PASSO 4</span>
                                <span class="label">Beneficiários</span>
                            </a>
                        </li>
                        <li>
                            <a href="#wiz3step5">
                                <span class="h2">PASSO 5</span>
                                <span class="label">Dados Contratação</span>
                            </a>
                        </li>
                        <li>
                            <a href="#wiz3step6">
                                <span class="h2">PASSO 6</span>
                                <span class="label">Contribuição Sindical</span>
                            </a>
                        </li>
                    </ul>

                    <div id="wiz3step1" class="formwiz">
                        <h4>Passo 1: Dados Pessoais</h4>

                        <p>
                            <label>Numero Ordem(Matricula)</label>
                            <span class="field">
                                <asp:TextBox runat="server" ID="txtNumeroOrdemMatricula" CssClass="input-small" />
                            </span>
                        </p>

                        <p>
                            <label>Nome Funcionario</label>
                            <span class="field">
                                <asp:TextBox runat="server" ID="txtNomeFuncionario" CssClass="input-xxlarge" />
                            </span>
                        </p>

                        <p>
                            <label>Numero Matricula</label>
                            <span class="field">
                                <asp:TextBox runat="server" ID="txtNumeroMatricula" CssClass="input-small" />
                            </span>
                        </p>

                        <p>
                            <label>Nome do Pai</label>
                            <span class="field">
                                <asp:TextBox runat="server" ID="txtNomePai" CssClass="input-xxlarge" />
                            </span>
                        </p>

                        <p>
                            <label>Nacionalidade da Pai</label>
                            <span class="field">
                                <asp:DropDownList runat="server" ID="ddlNacionalidadePai" data-placeholder="Escolha um país..." style="width: 350px" class="chzn-select" tabindex="2">
                                    <asp:ListItem Value="0" Text="Selecione um País" />
                                    </asp:DropDownList>
                            </span>
                        </p>

                        <p>
                            <label>Nome da Mãe</label>
                            <span class="field">
                                <asp:TextBox runat="server" ID="txtNomeMae" CssClass="input-xxlarge" />
                            </span>
                        </p>

                        <p>
                            <label>Nacionalidade da Mãe</label>
                            <span class="field">
                                <asp:DropDownList runat="server" ID="ddlNacionalidadeMae" data-placeholder="Escolha um país..." style="width: 350px" class="chzn-select" tabindex="2" />
                            </span>
                        </p>

                        <p>
                            <label>Data de Nascimento</label>
                            <span class="field">
                                <asp:TextBox runat="server" ID="txtDataNascimento" CssClass="input-small" ClientIDMode="Static" />
                            </span>
                        </p>

                        <p>
                            <label>Nacionalidade</label>
                            <span class="field">
                                <asp:DropDownList runat="server" ID="ddlNacionalidadeFuncionario" data-placeholder="Escolha um país..." style="width: 350px" class="chzn-select" tabindex="2" ClientIDMode="Static" />
                            </span>
                        </p>

                        <p>
                            <label>Estado Civil</label>
                            <span class="field">
                                <asp:DropDownList runat="server" ID="ddlEstadoCivil"  class="uniformselect"  />
                            </span>
                        </p>

                        <p>
                            <label>Nome do(a) Conjuge</label>
                            <span class="field">
                                <asp:TextBox runat="server" ID="txtNomeConjuge" CssClass="input-xxlarge" />
                            </span>
                        </p>

                        <p>
                            <label>Quantos Filhos</label>
                            <span class="field">
                                <asp:TextBox runat="server" ID="txtQtdFilhos" CssClass="input-small input-spinner" Text="0" ClientIDMode="Static" />
                            </span>
                        </p>



                    </div>

                    <!--#wiz13tep1-->

                    <div id="wiz3step2" class="formwiz">
                        <h4>Passo 2: Documentos</h4>

                        <p>
                            <label>Account No</label>
                            <span class="field">
                                <input type="text" name="lastname" class="input-xxlarge" /></span>
                        </p>
                        <p>
                            <label>Address</label>
                            <span class="field">
                                <textarea cols="80" rows="5" class="span6" name="location"></textarea></span>
                        </p>

                    </div>
                    <!--#wiz3step2-->

                    <div id="wiz3step3" class="formwiz">
                        <h4>Passo 3: Dados fisicos</h4>
                        <div class="par terms">
                            <p>Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo. Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit aut fugit, sed quia consequuntur magni dolores eos qui ratione voluptatem sequi nesciunt.</p>
                            <p>Neque porro quisquam est, qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit, sed quia non numquam eius modi tempora incidunt ut labore et dolore magnam aliquam quaerat voluptatem. Ut enim ad minima veniam, quis nostrum exercitationem ullam corporis suscipit laboriosam, nisi ut aliquid ex ea commodi consequatur? Quis autem vel eum iure reprehenderit qui in ea voluptate velit esse quam nihil molestiae consequatur, vel illum qui dolorem eum fugiat quo voluptas nulla pariatur?</p>
                            <p>
                                <input type="checkbox" />
                                I agree with the terms and agreement...
                            </p>
                        </div>
                    </div>
                    <!--#wiz3step3-->

                    <div id="wiz3step4" class="formwiz">
                        <h4>Passo 4: Beneficiários</h4>
                        <div class="par terms">
                            <p>Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo. Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit aut fugit, sed quia consequuntur magni dolores eos qui ratione voluptatem sequi nesciunt.</p>
                            <p>Neque porro quisquam est, qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit, sed quia non numquam eius modi tempora incidunt ut labore et dolore magnam aliquam quaerat voluptatem. Ut enim ad minima veniam, quis nostrum exercitationem ullam corporis suscipit laboriosam, nisi ut aliquid ex ea commodi consequatur? Quis autem vel eum iure reprehenderit qui in ea voluptate velit esse quam nihil molestiae consequatur, vel illum qui dolorem eum fugiat quo voluptas nulla pariatur?</p>
                            <p>
                                <input type="checkbox" />
                                I agree with the terms and agreement...
                            </p>
                        </div>
                    </div>
                    <!--#wiz3step4-->

                    <div id="wiz3step5" class="formwiz">
                        <h4>Passo 5: Dados Contratação</h4>
                        <div class="par terms">
                            <p>Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo. Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit aut fugit, sed quia consequuntur magni dolores eos qui ratione voluptatem sequi nesciunt.</p>
                            <p>Neque porro quisquam est, qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit, sed quia non numquam eius modi tempora incidunt ut labore et dolore magnam aliquam quaerat voluptatem. Ut enim ad minima veniam, quis nostrum exercitationem ullam corporis suscipit laboriosam, nisi ut aliquid ex ea commodi consequatur? Quis autem vel eum iure reprehenderit qui in ea voluptate velit esse quam nihil molestiae consequatur, vel illum qui dolorem eum fugiat quo voluptas nulla pariatur?</p>
                            <p>
                                <input type="checkbox" />
                                I agree with the terms and agreement...
                            </p>
                        </div>
                    </div>
                    <!--#wiz3step5-->

                    <div id="wiz3step6">
                        <h4>Passo 6: Contribuição Sindical</h4>
                        <div class="par terms">
                            <p>Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo. Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit aut fugit, sed quia consequuntur magni dolores eos qui ratione voluptatem sequi nesciunt.</p>
                            <p>Neque porro quisquam est, qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit, sed quia non numquam eius modi tempora incidunt ut labore et dolore magnam aliquam quaerat voluptatem. Ut enim ad minima veniam, quis nostrum exercitationem ullam corporis suscipit laboriosam, nisi ut aliquid ex ea commodi consequatur? Quis autem vel eum iure reprehenderit qui in ea voluptate velit esse quam nihil molestiae consequatur, vel illum qui dolorem eum fugiat quo voluptas nulla pariatur?</p>
                            <p>
                                <input type="checkbox" />
                                I agree with the terms and agreement...
                            </p>
                        </div>
                    </div>
                    <!--#wiz3step6-->

                </div>
                <!--#wizard-->

                

                <!-- END OF TABBED WIZARD -->

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
