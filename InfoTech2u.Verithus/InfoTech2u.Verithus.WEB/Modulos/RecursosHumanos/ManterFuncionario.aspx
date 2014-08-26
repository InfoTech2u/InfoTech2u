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
                                <span class="label">Endereço</span>
                            </a>
                        </li>
                        <li>
                            <a href="#wiz3step3">
                                <span class="h2">PASSO 3</span>
                                <span class="label">Filiação</span>
                            </a>
                        </li>
                        <li>
                            <a href="#wiz3step4">
                                <span class="h2">PASSO 4</span>
                                <span class="label">Documentos Pessoais</span>
                            </a>
                        </li>
                        <li>
                            <a href="#wiz3step5">
                                <span class="h2">PASSO 5</span>
                                <span class="label">Documentos PIS</span>
                            </a>
                        </li>
                        <li>
                            <a href="#wiz3step6">
                                <span class="h2">PASSO 6</span>
                                <span class="label">Documentos Fundo de Garantia</span>
                            </a>
                        </li>
                        <li>
                            <a href="#wiz3step7">
                                <span class="h2">PASSO 7</span>
                                <span class="label">caracteristicas Fisicas</span>
                            </a>
                        </li>
                    </ul>

                    <div id="wiz3step1" class="formwiz">
                        <h4>Passo 1: Dados Pessoais</h4>

                        <br/>
                        <p id="validaNumeroOrdemMatricula">
                            <label>Numero Ordem(Matricula)</label>
                            <span class="field">
                                <asp:TextBox runat="server" ID="txtNumeroOrdemMatricula" CssClass="input-small" ClientIDMode="Static" />
                                <span class="help-inline" id="msgNumeroOrdemMatricula"></span>
                            </span>
                        </p>

                        <p id="validaNumeroMatricula">
                            <label>Numero Matricula</label>
                            <span class="field">
                                <asp:TextBox runat="server" ID="txtNumeroMatricula" CssClass="input-small" ClientIDMode="Static" />
                                <span class="help-inline" id="msgNumeroMatricula"></span>
                            </span>
                        </p>

                        <p id="validaNomeFuncionario">
                            <label>Nome Funcionario</label>
                            <span class="field">
                                <asp:TextBox runat="server" ID="txtNomeFuncionario" CssClass="input-xxlarge" ClientIDMode="Static" />
                                <span class="help-inline" id="msgNomeFuncionario"></span>
                            </span>
                        </p>

                        <p id="validaDataNascimento">
                            <label>Data de Nascimento</label>
                            <span class="field">
                                <asp:TextBox runat="server" ID="txtDataNascimento" CssClass="input-small txtDataFilMesAno dataddmmaaaa" ClientIDMode="Static" />
                                <span class="help-inline" id="msgDataNascimento"></span>
                            </span>
                        </p>

                        <p id="validaNacionalidadeFuncionario">
                            <label>Nacionalidade</label>
                            <span class="field">
                                <asp:DropDownList runat="server" ID="ddlNacionalidadeFuncionario" data-placeholder="Escolha um país..." Style="width: 350px" class="chzn-select" TabIndex="2" ClientIDMode="Static" />
                                <span class="help-inline" id="msgNacionalidadeFuncionario"></span>
                            </span>
                        </p>

                        <p id="validaEstadoCivil">
                            <label>Estado Civil</label>
                            <span class="field">
                                <asp:DropDownList runat="server" ID="ddlEstadoCivil" class="uniformselect" ClientIDMode="Static" />
                                <span class="help-inline" id="msgEstadoCivil"></span>
                            </span>
                        </p>

                        <p id="validaNomeConjuge">
                            <label>Nome do(a) Conjuge</label>
                            <span class="field">
                                <asp:TextBox runat="server" ID="txtNomeConjuge" CssClass="input-xxlarge" ClientIDMode="Static" />
                                <span class="help-inline" id="msgNomeConjuge"></span>
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
                        <h4>Passo 2: Endereço</h4>


                        <p id="validaTipoEndereco">
                            <label>Tipo de Endereço</label>
                            <span class="field">
                                <asp:DropDownList runat="server" ID="ddlTipoEndereco" data-placeholder="Escolha um tipo de Endereço..." Style="width: 350px" class="chzn-select" TabIndex="2" ClientIDMode="Static" />
                                <span class="help-inline" id="msgTipoEndereco"></span>
                            </span>
                        </p>

                        <p id="validaTipoLogradouro">
                            <label>Tipo de Logradouro</label>
                            <span class="field">
                                <asp:DropDownList runat="server" ID="ddlTipoLogradouro" data-placeholder="Escolha um tipo de Logradouro..." Style="width: 350px" class="chzn-select" TabIndex="2" ClientIDMode="Static" />
                                <span class="help-inline" id="msgTipoLogradouro"></span>
                            </span>
                        </p>

                        <p id="validaLogradouro">
                            <label>Logradouro</label>
                            <span class="field">
                                <asp:TextBox runat="server" ID="txtLogradouro" CssClass="input-xxlarge" ClientIDMode="Static" />
                                <span class="help-inline" id="msgLogradouro"></span>
                            </span>
                        </p>

                        <p id="validaNumeroEndereco">
                            <label>Numero</label>
                            <span class="field">
                                <asp:TextBox runat="server" ID="txtNumeroEndereco" CssClass="input-small" ClientIDMode="Static" />
                                <span class="help-inline" id="msgNumeroEndereco"></span>
                            </span>
                        </p>

                        <p id="validaBairro">
                            <label>Bairro</label>
                            <span class="field">
                                <asp:TextBox runat="server" ID="txtBairro" CssClass="input-large" ClientIDMode="Static" />
                                <span class="help-inline" id="msgBairro"></span>
                            </span>
                        </p>

                        <p>
                            <label>Complemento</label>
                            <span class="field">
                                <asp:TextBox runat="server" ID="txtComplemento" CssClass="input-xxlarge" ClientIDMode="Static" />
                            </span>
                        </p>

                        <p>
                            <label>CEP</label>
                            <span class="input-append">
                                <asp:TextBox runat="server" ID="txtCEP" CssClass="input-small CEP" ClientIDMode="Static" />
                                <button type="button" class="btn" id="btnBuscarCEP">Buscar</button>
                            </span>
                        </p>



                    </div>
                    <!--#wiz3step2-->

                    <div id="wiz3step3" class="formwiz">
                        <h4>Passo 3: Filiação</h4>

                        <p id="validaNomePai">
                            <label>Nome do Pai</label>
                            <span class="field">
                                <asp:TextBox runat="server" ID="txtNomePai" CssClass="input-xxlarge" ClientIDMode="Static" />
                                <span class="help-inline" id="msgNomePai"></span>
                            </span>
                        </p>

                        <p id="validaNacionalidadePai">
                            <label>Nacionalidade da Pai</label>
                            <span class="field">
                                <asp:DropDownList runat="server" ID="ddlNacionalidadePai" data-placeholder="Escolha um país..." Style="width: 350px" class="chzn-select" TabIndex="2" ClientIDMode="Static">
                                </asp:DropDownList>
                                <span class="help-inline" id="msgNacionalidadePai"></span>
                            </span>
                        </p>

                        <p id="validaNomeMae">
                            <label>Nome da Mãe</label>
                            <span class="field">
                                <asp:TextBox runat="server" ID="txtNomeMae" CssClass="input-xxlarge" ClientIDMode="Static" />
                                <span class="help-inline" id="msgNomeMae"></span>
                            </span>
                        </p>

                        <p id="validaNacionalidadeMae">
                            <label>Nacionalidade da Mãe</label>
                            <span class="field">
                                <asp:DropDownList runat="server" ID="ddlNacionalidadeMae" data-placeholder="Escolha um país..." Style="width: 350px" class="chzn-select" TabIndex="2" ClientIDMode="Static" />
                                <span class="help-inline" id="msgNacionalidadeMae"></span>
                            </span>
                        </p>


                    </div>
                    <!--#wiz3step3-->

                    <div id="wiz3step4" class="formwiz">
                        <h4>Passo 4: Documentos Pessoais</h4>

                        <div runat="server" id="divBrasil" class="divBrasil">

                            <p id="validaRG">
                                <label>Numero de RG</label>
                                <span class="field">
                                    <asp:TextBox runat="server" ID="txtRG" CssClass="input-small" ClientIDMode="Static" />
                                    <span class="help-inline" id="msgRG"></span>
                                </span>
                            </p>

                            <p id="validaCarteiraTrabalho">
                                <label>Numero Carteira de Trabalho</label>
                                <span class="field">
                                    <asp:TextBox runat="server" ID="txtCarteiraTrabalho" CssClass="input-small" ClientIDMode="Static" />
                                    <span class="help-inline" id="msgCarteiraTrabalho"></span>
                                </span>
                            </p>

                            <p id="validaNumeroSerie">
                                <label>Numero da Serie</label>
                                <span class="field">
                                    <asp:TextBox runat="server" ID="txtNumeroSerie" CssClass="input-small" ClientIDMode="Static" />
                                    <span class="help-inline" id="msgNumeroSerie"></span>
                                </span>
                            </p>

                            <p id="validaNumeroCertificadoReservista">
                                <label>Numero Certificado de Reservista</label>
                                <span class="field">
                                    <asp:TextBox runat="server" ID="txtNumeroCertificadoReservista" CssClass="input-small" ClientIDMode="Static" />
                                    <span class="help-inline" id="msgNumeroCertificadoReservista"></span>
                                </span>
                            </p>

                            <p id="validaCategoria">
                                <label>Categoria</label>
                                <span class="field">
                                    <asp:TextBox runat="server" ID="txtCategoria" CssClass="input-small" ClientIDMode="Static" />
                                    <span class="help-inline" id="msgCategoria"></span>
                                </span>
                            </p>

                            <p id="validaCPF">
                                <label>Numero de CPF</label>
                                <span class="field">
                                    <asp:TextBox runat="server" ID="txtCPF" CssClass="input-small CPF" ClientIDMode="Static" />
                                    <span class="help-inline" id="msgCPF"></span>
                                </span>
                            </p>

                            <p id="validaTituloEleitor">
                                <label>Titulo de Eleitor</label>
                                <span class="field">
                                    <asp:TextBox runat="server" ID="txtTituloEleitor" CssClass="input-small" ClientIDMode="Static" />
                                    <span class="help-inline" id="msgTituloEleitor"></span>
                                </span>
                            </p>

                            <p id="validaCateiraSaude">
                                <label>Numero Carteira de Saude</label>
                                <span class="field">
                                    <asp:TextBox runat="server" ID="txtCateiraSaude" CssClass="input-small" ClientIDMode="Static" />
                                    <span class="help-inline" id="msgCateiraSaude"></span>
                                </span>
                            </p>
                        </div>

                        <div runat="server" id="divEstrangeiro" class="divEstrangeiro">
                            <p id="validaCBO">
                                <label>Numero C.B.O</label>
                                <span class="field">
                                    <asp:TextBox runat="server" ID="txtCBO" CssClass="input-small" ClientIDMode="Static" />
                                    <span class="help-inline" id="msgCBO"></span>
                                </span>
                            </p>

                            <p id="validaCarteira19">
                                <label>Numero Carteira 19</label>
                                <span class="field">
                                    <asp:TextBox runat="server" ID="txtCarteira19" CssClass="input-small" ClientIDMode="Static" />
                                    <span class="help-inline" id="msgCarteira19"></span>
                                </span>
                            </p>

                            <p id="validaRegistroGeral">
                                <label>Numero do Registro Geral</label>
                                <span class="field">
                                    <asp:TextBox runat="server" ID="txtRegistroGeral" CssClass="input-small" ClientIDMode="Static" />
                                    <span class="help-inline" id="msgRegistroGeral"></span>
                                </span>
                            </p>

                            <p id="validaCasadoBrasileiro">
                                <label>Casado(a) com Brasileira(o)</label>
                                <span class="field">
                                    <asp:RadioButtonList runat="server" ID="rdbCasadoBrasileiro" RepeatDirection="Horizontal" ClientIDMode="Static" Width="100px">
                                        <asp:ListItem Text="Sim" Value="S" Selected="True" />
                                        <asp:ListItem Text="Não" Value="N" />
                                    </asp:RadioButtonList>
                                    <span class="help-inline" id="msgCasadoBrasileiro"></span>
                                </span>
                            </p>

                            <p id="validaNaturalizado">
                                <label>Naturalizado</label>
                                <span class="field">
                                    <asp:RadioButtonList runat="server" ID="rblNaturalizado" RepeatDirection="Horizontal" ClientIDMode="Static" Width="100px">
                                        <asp:ListItem Text="Sim" Value="S" Selected="True" />
                                        <asp:ListItem Text="Não" Value="N" />
                                    </asp:RadioButtonList>
                                    <span class="help-inline" id="msgNaturalizado"></span>
                                </span>
                            </p>

                            <p id="validaFilhoBrasileiro">
                                <label>Filhos Brasileiros</label>
                                <span class="field">
                                    <asp:RadioButtonList runat="server" ID="rblFilhoBrasileiro" RepeatDirection="Horizontal" ClientIDMode="Static" Width="100px">
                                        <asp:ListItem Text="Sim" Value="S" Selected="True" />
                                        <asp:ListItem Text="Não" Value="N" />
                                    </asp:RadioButtonList>
                                    <span class="help-inline" id="msgFilhoBrasileiro"></span>
                                </span>
                            </p>

                            <p id="validaDataChegadaBrasil">
                                <label>Data de Chegada no Brasil</label>
                                <span class="field">
                                    <input id="txtDataChegadaBrasil" type="text" name="date" class="input-small DataPadrao dataddmmaaaa" clientidmode="Static" />
                                    <span class="help-inline" id="msgDataChegadaBrasil"></span>
                                </span>
                            </p>
                        </div>


                    </div>
                    <!--#wiz3step4-->

                    <div id="wiz3step5" class="formwiz">
                        <h4>Passo 5: PIS</h4>

                        <p id="validaCadastroPIS">
                            <label>Data de Cadastro</label>
                            <span class="field">
                                <asp:TextBox runat="server" ID="txtCadastroPIS" CssClass="input-small txtDataFilMesAno dataddmmaaaa" ClientIDMode="Static" />
                                <span class="help-inline" id="msgCadastroPIS"></span>
                            </span>
                        </p>

                        <p id="validaSobNumero">
                            <label>Numero do PIS</label>
                            <span class="field">
                                <asp:TextBox runat="server" ID="txtSobNumero" CssClass="input-small" ClientIDMode="Static" />
                                <span class="help-inline" id="msgSobNumero"></span>
                            </span>
                        </p>

                        <p id="validaBancoPIS">
                            <label>Banco</label>
                            <span class="field">
                                <asp:TextBox runat="server" ID="txtBancoPIS" CssClass="input-small" ClientIDMode="Static" />
                                <span class="help-inline" id="msgBancoPIS"></span>
                            </span>
                        </p>

                        <p id="validaAgencia">
                            <label>Agencia</label>
                            <span class="field">
                                <asp:TextBox runat="server" ID="txtAgencia" CssClass="input-small" ClientIDMode="Static" />
                                <span class="help-inline" id="msgAgencia"></span>
                            </span>
                        </p>

                        <p id="validaDigito">
                            <label>Digito</label>
                            <span class="field">
                                <asp:TextBox runat="server" ID="txtDigito" CssClass="input-small" ClientIDMode="Static" />
                                <span class="help-inline" id="msgDigito"></span>
                            </span>
                        </p>

                        <p id="validaTipoEnderecoPIS">
                            <label>Tipo de Endereço</label>
                            <span class="field">
                                <asp:DropDownList runat="server" ID="txtTipoEnderecoPIS" data-placeholder="Escolha um tipo de Endereço..." Style="width: 350px" class="chzn-select" TabIndex="2" ClientIDMode="Static" />
                                <span class="help-inline" id="msgTipoEnderecoPIS"></span>
                            </span>
                        </p>

                        <p id="validaTipoLogradouroPIS">
                            <label>Tipo de Logradouro</label>
                            <span class="field">
                                <asp:DropDownList runat="server" ID="ddlTipoLogradouroPIS" data-placeholder="Escolha um tipo de Logradouro..." Style="width: 350px" class="chzn-select" TabIndex="2" ClientIDMode="Static" />
                                <span class="help-inline" id="msgTipoLogradouroPIS"></span>
                            </span>
                        </p>

                        <p id="validaLogradouroPIS">
                            <label>Logradouro</label>
                            <span class="field">
                                <asp:TextBox runat="server" ID="txtLogradouroPIS" CssClass="input-xxlarge" ClientIDMode="Static" />
                                <span class="help-inline" id="msgLogradouroPIS"></span>
                            </span>
                        </p>

                        <p id="validaNumeroEnredecoPIS">
                            <label>Numero</label>
                            <span class="field">
                                <asp:TextBox runat="server" ID="txtNumeroEnredecoPIS" CssClass="input-small" ClientIDMode="Static" />
                                <span class="help-inline" id="msgNNumeroEnredecoPIS"></span>
                            </span>
                        </p>

                        <p id="validaBairroPIS">
                            <label>Bairro</label>
                            <span class="field">
                                <asp:TextBox runat="server" ID="txtBairroPIS" CssClass="input-large" ClientIDMode="Static" />
                                <span class="help-inline" id="msgBairroPIS"></span>
                            </span>
                        </p>

                        <p id="validaComplementoPIS">
                            <label>Complemento</label>
                            <span class="field">
                                <asp:TextBox runat="server" ID="txtComplementoPIS" CssClass="input-xxlarge" ClientIDMode="Static" />
                                <span class="help-inline" id="msgComplementoPIS"></span>
                            </span>
                        </p>

                        <p id="validaCEPPIS">
                            <label>CEP</label>
                            <span class="field">
                                <asp:TextBox runat="server" ID="txtCEPPIS" CssClass="input-small CEP" ClientIDMode="Static" />
                                <span class="help-inline" id="msgCEPPIS"></span>
                            </span>
                        </p>



                    </div>
                    <!--#wiz3step5-->

                    <div id="wiz3step6">
                        <h4>Passo 6: Fundo de Garantia</h4>

                        <p id="validaOptanteFGTS">
                            <label>Optante</label>
                            <span class="field">
                                <asp:RadioButtonList runat="server" ID="rdpOptanteFGTS" RepeatDirection="Horizontal" ClientIDMode="Static" Width="100px">
                                    <asp:ListItem Text="Sim" Value="S" Selected="True" />
                                    <asp:ListItem Text="Não" Value="N" />
                                </asp:RadioButtonList>
                                <span class="help-inline" id="msgOptanteFGTS"></span>
                            </span>
                        </p>
                        
                        <p  id="validaDataOpcao">
                            <label>Data de Opção</label>
                            <span class="field">
                                <asp:TextBox runat="server" ID="txtDataOpcao" CssClass="input-small txtDataFilMesAno dataddmmaaaa" ClientIDMode="Static"  />
                                <span class="help-inline" id="msgDataOpcao"></span>
                            </span>
                        </p>

                        <p id="validaDataRetratacao">
                            <label>Data de retratação</label>
                            <span class="field">
                                <asp:TextBox runat="server" ID="txtDataRetratacao" CssClass="input-small txtDataFilMesAno dataddmmaaaa" ClientIDMode="Static"  />
                                <span class="help-inline" id="msgDataRetratacao"></span>
                            </span>
                        </p>

                        <p id="validaBancoFGTS">
                            <label>Banco</label>
                            <span class="field">
                                <asp:TextBox runat="server" ID="txtBancoFGTS" CssClass="input-small" ClientIDMode="Static" />
                                <span class="help-inline" id="msgBancoFGTS"></span>
                            </span>
                        </p>

                        <p id="validaAgenciaFGTS">
                            <label>Agencia</label>
                            <span class="field">
                                <asp:TextBox runat="server" ID="txtAgenciaFGTS" CssClass="input-small" ClientIDMode="Static" />
                                <span class="help-inline" id="msgAgenciaFGTS"></span>
                            </span>
                        </p>

                        <p id="validaDigitoFGTS">
                            <label>Digito</label>
                            <span class="field">
                                <asp:TextBox runat="server" ID="txtDigitoFGTS" CssClass="input-small" ClientIDMode="Static" />
                                <span class="help-inline" id="msgDigitoFGTS"></span>
                            </span>
                        </p>


                    </div>
                    <!--#wiz3step6-->

                    <div id="wiz3step7" class="formwiz">
                        <h4>Passo 3: Dados fisicos</h4>

                        <p>
                            <label>Cor</label>
                            <span class="field">
                                <asp:DropDownList runat="server" ID="ddlCor" data-placeholder="Escolha um tipo de Cor..." Style="width: 350px" class="chzn-select" TabIndex="2" ClientIDMode="Static" />
                            </span>
                        </p>

                        <p>
                            <label>Altura</label>
                            <span class="field">
                                <asp:TextBox runat="server" ID="txtAltura" CssClass="input-small Altura" ClientIDMode="Static" />
                            </span>
                        </p>

                        <p>
                            <label>Peso</label>
                            <span class="field">
                                <asp:TextBox runat="server" ID="txtPeso" CssClass="input-small Peso" ClientIDMode="Static" />
                            </span>
                        </p>

                        <p>
                            <label>Cabelo</label>
                            <span class="field">
                                <asp:DropDownList runat="server" ID="ddlCabelo" data-placeholder="Escolha um tipo de Cabelo..." Style="width: 350px" class="chzn-select" TabIndex="2" ClientIDMode="Static" />
                            </span>
                        </p>

                        <p>
                            <label>Olho</label>
                            <span class="field">
                                <asp:DropDownList runat="server" ID="ddlOlho" data-placeholder="Escolha um tipo de Olho..." Style="width: 350px" class="chzn-select" TabIndex="2" ClientIDMode="Static" />
                            </span>
                        </p>

                        <p>
                            <label>Sinais</label>
                            <span class="field">
                                <asp:TextBox runat="server" ID="txtSinais" CssClass="input-small" ClientIDMode="Static" />
                            </span>
                        </p>


                    </div>
                    <!--#wiz3step7-->

                </div>
                <!--#wizard-->

                <!-- END OF TABBED WIZARD -->

                <div class="footer">
                    <div class="footer-left">
                        <span>&copy; 2014. InfoTech2u. All Rights Reserved.</span>
                    </div>
                    <div class="footer-right">
                        <span>Designed by: <a href="http://www.infotech2u.com.br/">InfoTech2u</a></span>
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
