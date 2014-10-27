<%@ Page Title="" Language="C#" MasterPageFile="~/Modulos/InfoTech2u.Master" AutoEventWireup="true" CodeBehind="RelatorioFuncionarioGeral.aspx.cs" Inherits="InfoTech2u.Verithus.WEB.Modulos.RecursosHumanos.RelatorioFuncionarioGeral" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderInfoTech2u" runat="server">
    <div class="rightpanel">


        <div class="maincontent">
            <div class="maincontentinner">



                <div class="span12">
                    <div class="invoice_logo">
                        <img src="../../images/logo.png" alt="" />
                    </div>
                    <h3>Dados Pessoais</h3>
                    <table class="table table-bordered table-invoice">
                        <tr>
                            <td class="width30">Nome Funcionario:</td>
                            <td class="width70"><strong>
                                <asp:Label runat="server" ID="lblNomeFuncionario"></asp:Label></strong></td>
                        </tr>
                        <tr>
                            <td>Empresa:</td>
                            <td>
                                <asp:Label runat="server" ID="lblNomeEmpresa"></asp:Label></td>
                        </tr>
                        <tr>
                            <td>Data de Nascimento:</td>
                            <td>
                                <asp:Label runat="server" ID="lblDatadeNascimento"></asp:Label></td>
                        </tr>
                        <tr>
                            <td>Nacionalidade:</td>
                            <td>
                                <asp:Label runat="server" ID="lblNacionalidade"></asp:Label></td>
                        </tr>
                        <tr>
                            <td>Estado Civil:</td>
                            <td>
                                <asp:Label runat="server" ID="lblEstadoCivil"></asp:Label></td>
                        </tr>
                        <tr>
                            <td>Nome do(a) Conjuge:</td>
                            <td>
                                <asp:Label runat="server" ID="lblNomeConjuge"></asp:Label></td>
                        </tr>
                        <tr>
                            <td>Quantos Filhos:</td>
                            <td>
                                <asp:Label runat="server" ID="lblQtdFilhos"></asp:Label></td>
                        </tr>
                    </table>
                </div>
                <!--span6-->



                <div class="span12">
                    <h3>Endereço</h3>
                    <table class="table table-bordered table-invoice">
                        <tr>
                            <td class="width30">Endereço:</td>
                            <td class="width70"><strong>
                                <asp:Label runat="server" ID="lblTipoLogradouroFuncionario"></asp:Label>
                                <asp:Label runat="server" ID="lblLogradouroFuncionario"></asp:Label>,
                                <asp:Label runat="server" ID="lblNumeroFuncionario"></asp:Label></strong></td>
                        </tr>
                        <tr>
                            <td>Bairro:</td>
                            <td>
                                <asp:Label runat="server" ID="lblBairroFuncionario"></asp:Label></td>
                        </tr>
                        <tr>
                            <td>Complemento:</td>
                            <td>
                                <asp:Label runat="server" ID="lblComplemento"></asp:Label></td>
                        </tr>
                        <tr>
                            <td>Estado:</td>
                            <td>
                                <asp:Label runat="server" ID="lblEstado"></asp:Label></td>
                        </tr>
                        <tr>
                            <td>Cidade:</td>
                            <td>
                                <asp:Label runat="server" ID="lblCidade"></asp:Label></td>
                        </tr>
                        <tr>
                            <td>CEP:</td>
                            <td>
                                <asp:Label runat="server" ID="lblCEP"></asp:Label></td>
                        </tr>
                    </table>
                </div>
                <!--span6-->


                <div class="span12">
                    <h3>Filiação</h3>
                    <table class="table table-bordered table-invoice">
                        <tr>
                            <td class="width30">Nome do Pai:</td>
                            <td class="width70"><strong>
                                <asp:Label runat="server" ID="lblNomePai"></asp:Label></strong></td>
                        </tr>
                        <tr>
                            <td class="width30">Nacionalidade  do Pai:</td>
                            <td class="width70"><strong>
                                <asp:Label runat="server" ID="lblNacionalidadePai"></asp:Label></strong></td>
                        </tr>
                        <tr>
                            <td class="width30">Nome do Mãe:</td>
                            <td class="width70"><strong>
                                <asp:Label runat="server" ID="lblNomeMae"></asp:Label></strong></td>
                        </tr>
                        <tr>
                            <td class="width30">Nacionalidade  do Mãe:</td>
                            <td class="width70"><strong>
                                <asp:Label runat="server" ID="lblNacionalidadeMae"></asp:Label></strong></td>
                        </tr>
                    </table>

                </div>
                <!--span6-->


                <div class="span12">
                    <h3>Documentos Pessoais</h3>
                    <table class="table table-bordered table-invoice">
                        <tr>
                            <td class="width30">Numero de RG:</td>
                            <td class="width70">
                                <asp:Label runat="server" ID="lblRG"></asp:Label></td>
                        </tr>
                        <tr>
                            <td class="width30">Numero Carteira de Trabalho:</td>
                            <td class="width70">
                                <asp:Label runat="server" ID="lblNumeroCarteiraTrabalho"></asp:Label></td>
                        </tr>
                        <tr>
                            <td class="width30">Numero da Serie:</td>
                            <td class="width70">
                                <asp:Label runat="server" ID="lblNumeroSerie"></asp:Label></td>
                        </tr>
                        <tr>
                            <td class="width30">Numero Certificado de Reservista:</td>
                            <td class="width70">
                                <asp:Label runat="server" ID="lblNumeroCertificadoReservista"></asp:Label></td>
                        </tr>
                        <tr>
                            <td class="width30">Categoria:</td>
                            <td class="width70">
                                <asp:Label runat="server" ID="lblCategoria"></asp:Label></td>
                        </tr>
                        <tr>
                            <td class="width30">Numero de CPF:</td>
                            <td class="width70">
                                <asp:Label runat="server" ID="lblNumeroCPF"></asp:Label></td>
                        </tr>
                        <tr>
                            <td class="width30">Titulo de Eleitor:</td>
                            <td class="width70">
                                <asp:Label runat="server" ID="lblTituloEleitor"></asp:Label></td>
                        </tr>
                        <tr>
                            <td class="width30">Numero Carteira de Saude:</td>
                            <td class="width70">
                                <asp:Label runat="server" ID="lblCarteiraSaude"></asp:Label></td>
                        </tr>
                    </table>

                </div>
                <!--span6-->


                <div class="span12">
                    <h3>Documentos PIS</h3>
                    <table class="table table-bordered table-invoice">
                        <tr>
                            <td class="width30">Data de Cadastro:</td>
                            <td class="width70">
                                <asp:Label runat="server" ID="lblDataCadastroPIS"></asp:Label></td>
                        </tr>
                        <tr>
                            <td class="width30">Numero do PIS:</td>
                            <td class="width70">
                                <asp:Label runat="server" ID="lblNumeroPIS"></asp:Label></td>
                        </tr>
                        <tr>
                            <td class="width30">Banco:</td>
                            <td class="width70">
                                <asp:Label runat="server" ID="lblBancoPIS"></asp:Label></td>
                        </tr>
                        <tr>
                            <td class="width30">Agencia:</td>
                            <td class="width70">
                                <asp:Label runat="server" ID="lblAgenciaPIS"></asp:Label></td>
                        </tr>
                        <tr>
                            <td class="width30">Conta/Digito:</td>
                            <td class="width70">
                                <asp:Label runat="server" ID="lblContaPIS"></asp:Label>/<asp:Label runat="server" ID="lblDigitoPIS"></asp:Label></td>
                        </tr>
                        <tr>
                            <td class="width30">Endereço:</td>
                            <td class="width70">
                                <asp:Label runat="server" ID="lblTipoLogradouroPIS"></asp:Label>
                                <asp:Label runat="server" ID="lblTLogradouroPIS"></asp:Label>,
                                <asp:Label runat="server" ID="lblNumeroEnderecoPIS"></asp:Label></td>
                        </tr>
                        <tr>
                            <td class="width30">Complemento:</td>
                            <td class="width70">
                                <asp:Label runat="server" ID="lblComplementoPIS"></asp:Label></td>
                        </tr>
                        <tr>
                            <td class="width30">Bairro:</td>
                            <td class="width70">
                                <asp:Label runat="server" ID="lblBairroPIS"></asp:Label></td>
                        </tr>
                        <tr>
                            <td class="width30">Cidade:</td>
                            <td class="width70">
                                <asp:Label runat="server" ID="lblCidadePIS"></asp:Label></td>
                        </tr>
                        <tr>
                            <td class="width30">Estado:</td>
                            <td class="width70">
                                <asp:Label runat="server" ID="lblEstadoPIS"></asp:Label></td>
                        </tr>
                        <tr>
                            <td class="width30">CEP:</td>
                            <td class="width70">
                                <asp:Label runat="server" ID="lblCEPPIS"></asp:Label></td>
                        </tr>
                    </table>

                </div>
                <!--span6-->


                <div class="span12">
                    <h3>Documentos Fundo de Garantia</h3>
                    <table class="table table-bordered table-invoice">
                        <tr>
                            <td class="width30">Optante:</td>
                            <td class="width70">
                                <asp:Label runat="server" ID="lblOptanteFGTS"></asp:Label></td>
                        </tr>
                        <tr>
                            <td class="width30">Data de Opção:</td>
                            <td class="width70">
                                <asp:Label runat="server" ID="lblDataOpcaoFGTS"></asp:Label></td>
                        </tr>
                        <tr>
                            <td class="width30">Data de retratação:</td>
                            <td class="width70">
                                <asp:Label runat="server" ID="lblDataRetratacaoFGTS"></asp:Label></td>
                        </tr>
                        <tr>
                            <td class="width30">Banco:</td>
                            <td class="width70">
                                <asp:Label runat="server" ID="lblBancoFGTS"></asp:Label></td>
                        </tr>
                        <tr>
                            <td class="width30">Agencia:</td>
                            <td class="width70">
                                <asp:Label runat="server" ID="lblAgenciaFGTS"></asp:Label></td>
                        </tr>
                        <tr>
                            <td class="width30">Conta/Digito:</td>
                            <td class="width70">
                                <asp:Label runat="server" ID="lblContaFGTS"></asp:Label>/<asp:Label runat="server" ID="lblDigitoFGTS"></asp:Label></td>
                        </tr>
                    </table>

                </div>
                <!--span6-->


                <div class="span12">
                    <h3>Caracteristicas Físicas</h3>
                    <table class="table table-bordered table-invoice">
                        <tr>
                            <td class="width30">Cor:</td>
                            <td class="width70">
                                <asp:Label runat="server" ID="lblCor"></asp:Label></td>
                        </tr>
                        <tr>
                            <td class="width30">Altura:</td>
                            <td class="width70">
                                <asp:Label runat="server" ID="lblAltura"></asp:Label></td>
                        </tr>
                        <tr>
                            <td class="width30">Peso:</td>
                            <td class="width70">
                                <asp:Label runat="server" ID="lblPeso"></asp:Label></td>
                        </tr>
                        <tr>
                            <td class="width30">Cabelo:</td>
                            <td class="width70">
                                <asp:Label runat="server" ID="lblCabelo"></asp:Label></td>
                        </tr>
                        <tr>
                            <td class="width30">Olho:</td>
                            <td class="width70">
                                <asp:Label runat="server" ID="lblOlho"></asp:Label></td>
                        </tr>
                        <tr>
                            <td class="width30">Sinais:</td>
                            <td class="width70">
                                <asp:Label runat="server" ID="lblSinais"></asp:Label></td>
                        </tr>
                    </table>

                </div>
                <!--span6-->


                <div class="span12">
                    <h3>Dados de Admissão</h3>
                    <table class="table table-bordered table-invoice">
                        <tr>
                            <td class="width30">Data de Admissão:</td>
                            <td class="width70">
                                <asp:Label runat="server" ID="lblDataAdmissao"></asp:Label></td>
                        </tr>
                        <tr>
                            <td class="width30">Data do Registro:</td>
                            <td class="width70">
                                <asp:Label runat="server" ID="lblDataregistroAdmissao"></asp:Label></td>
                        </tr>
                        <tr>
                            <td class="width30">Cargo:</td>
                            <td class="width70">
                                <asp:Label runat="server" ID="lblCargoAdmissao"></asp:Label></td>
                        </tr>
                        <tr>
                            <td class="width30">Seção:</td>
                            <td class="width70">
                                <asp:Label runat="server" ID="lblSecaoAdmissao"></asp:Label></td>
                        </tr>
                        <tr>
                            <td class="width30">Salário Inicial R$:</td>
                            <td class="width70">
                                <asp:Label runat="server" ID="lblSalarioAdmissao"></asp:Label></td>
                        </tr>
                        <tr>
                            <td class="width30">Comissões:</td>
                            <td class="width70">
                                <asp:Label runat="server" ID="lblComissoeAdmissao"></asp:Label></td>
                        </tr>
                        <tr>
                            <td class="width30">Tarefa:</td>
                            <td class="width70">
                                <asp:Label runat="server" ID="lblTarefaAdmissao"></asp:Label></td>
                        </tr>
                        <tr>
                            <td class="width30">Forma de Pagamento:</td>
                            <td class="width70">
                                <asp:Label runat="server" ID="lblFormaPagamentoAdmissao"></asp:Label></td>
                        </tr>
                        <tr>
                            <td class="width30">Horário de Trabalho - Entrada:</td>
                            <td class="width70">
                                <asp:Label runat="server" ID="lblHorarioTrabalhoEntredaAdmissao"></asp:Label></td>
                        </tr>
                        <tr>
                            <td class="width30">Horário de Trabalho - Saida:</td>
                            <td class="width70">
                                <asp:Label runat="server" ID="lblHorarioTrabalhoSaidaAdmissao"></asp:Label></td>
                        </tr>
                        <tr>
                            <td class="width30">Intervalo de Trabalho - Entrada:</td>
                            <td class="width70">
                                <asp:Label runat="server" ID="lblIntervaloTravbalhoEntradaAdmissao"></asp:Label></td>
                        </tr>
                        <tr>
                            <td class="width30">Intervalo de Trabalho - Saida:</td>
                            <td class="width70">
                                <asp:Label runat="server" ID="lblIntervaloTrabalhoSaidaAdmissao"></asp:Label></td>
                        </tr>
                        <tr>
                            <td class="width30">Descanso Semanal - Entrada:</td>
                            <td class="width70">
                                <asp:Label runat="server" ID="lblDescabsiSemanaEntradaAdmissao"></asp:Label></td>
                        </tr>
                        <tr>
                            <td class="width30">Descanso Semanal - Saida:</td>
                            <td class="width70">
                                <asp:Label runat="server" ID="lblDescansoSemanaSaidaAdmissao"></asp:Label></td>
                        </tr>
                    </table>

                </div>
                <!--span6-->


                <div class="span12">
                    <h3>Dados de Demissão</h3>
                    <table class="table table-bordered table-invoice">
                        <tr>
                            <td class="width30">Data de Demissão:</td>
                            <td class="width70">
                                <asp:Label runat="server" ID="lblDataDemissao"></asp:Label></td>
                        </tr>
                        <tr>
                            <td class="width30">Data do Registro:</td>
                            <td class="width70">
                                <asp:Label runat="server" ID="lblDataRegistroDemissao"></asp:Label></td>
                        </tr>
                        <tr>
                            <td class="width30">Cargo:</td>
                            <td class="width70">
                                <asp:Label runat="server" ID="lblCargoDemissao"></asp:Label></td>
                        </tr>
                        <tr>
                            <td class="width30">Seção:</td>
                            <td class="width70">
                                <asp:Label runat="server" ID="lblSecaoDemissao"></asp:Label></td>
                        </tr>
                        <tr>
                            <td class="width30">Salário Inicial R$:</td>
                            <td class="width70">
                                <asp:Label runat="server" ID="lblSalarioInicialDemissao"></asp:Label></td>
                        </tr>
                        <tr>
                            <td class="width30">Comissões:</td>
                            <td class="width70">
                                <asp:Label runat="server" ID="lblComissaoDemissao"></asp:Label></td>
                        </tr>
                        <tr>
                            <td class="width30">Tarefa:</td>
                            <td class="width70">
                                <asp:Label runat="server" ID="lblTarefaDemissao"></asp:Label></td>
                        </tr>
                        <tr>
                            <td class="width30">Forma de Pagamento:</td>
                            <td class="width70">
                                <asp:Label runat="server" ID="lblFormaPagamentoDemissao"></asp:Label></td>
                        </tr>
                    </table>

                </div>
                <!--span6-->


                <div class="span12">
                    <h3>Contribuição Sindical</h3>
                    <table class="table table-bordered table-invoice">
                        <tr>
                            <td class="width30">Período Ano:</td>
                            <td class="width70">
                                <asp:Label runat="server" ID="lblPeriodoAnoSindicato"></asp:Label></td>
                        </tr>
                        <tr>
                            <td class="width30">Sindicato:</td>
                            <td class="width70">
                                <asp:Label runat="server" ID="lblSindicato"></asp:Label></td>
                        </tr>
                        <tr>
                            <td class="width30">Valor da Contribuição:</td>
                            <td class="width70">
                                <asp:Label runat="server" ID="lblValorContribuicaoSindicato"></asp:Label></td>
                        </tr>
                    </table>

                </div>
                <!--span6-->

                <div class="span12">
                    <h3>Dependentes</h3>
                    <asp:Repeater ID="rptDependentes" runat="server" OnItemDataBound="rptDependentes_ItemDataBound">
                        <HeaderTemplate>
                            
                        </HeaderTemplate>
                        <ItemTemplate>
                            <table class="table table-bordered table-invoice">
                            <tr>
                                <td class="width30">Nome Dependente:</td>
                                <td class="width70"><%# DataBinder.Eval(Container.DataItem,"Nome") %></td>
                            </tr>
                            <tr>
                                <td class="width30">Parentesco:</td>
                                <td class="width70"><%# DataBinder.Eval(Container.DataItem,"DescricaoTipoParentesco") %></td>
                            </tr>
                            <tr>
                                <td class="width30">Data Nascimento:</td>
                                <td class="width70"><%# DataBinder.Eval(Container.DataItem,"DataNascimento") %></td>
                            </tr>
                            <tr>
                                <td class="width30">Benefícios:</td>
                                <td class="width70">
                                    <asp:Repeater ID="rptBeneficio" runat="server" OnItemDataBound="rptBeneficio_ItemDataBound">
                                        <ItemTemplate>
                                            <p>
                                                <asp:Literal runat="server" ID="ltBeneficio" /></p>
                                        </ItemTemplate>
                                    </asp:Repeater>

                                </td>
                            </tr>
                                </table>
                        </ItemTemplate>
                        <FooterTemplate></FooterTemplate>
                    </asp:Repeater>
                </div>
                <!--span6-->

                <div class="span12">
                    <h3>Ferias</h3>
                    <asp:GridView ID="grdFerias" AutoGenerateColumns="false" EmptyDataText="Não existe informações cadastradas." runat="server" class="table table-bordered responsive">
                        <Columns>
                            <asp:BoundField DataField="DATA_PERIODO_INICIO" HeaderText=" Data Periodo Inicio" />
                            <asp:BoundField DataField="DATA_PERIODO_FIM" HeaderText="Data Periodo Fim" />
                            <asp:BoundField DataField="DATA_GOZADA_INICIO" HeaderText="Data Gozadas Inicio" />
                            <asp:BoundField DataField="DATA_GOZADA_FIM" HeaderText="Data Gozadas Fim" />
                        </Columns>
                    </asp:GridView>
                </div>
                <!--span6-->

                <div class="span12">
                    <h3>Alteração de Cargo e Salario</h3>
                    <asp:GridView ID="grdAlteracaoCargoSalario" AutoGenerateColumns="false" EmptyDataText="Não existe informações cadastradas." runat="server" class="table table-bordered responsive">
                        <Columns>
                            <asp:BoundField DataField="DATA" HeaderText="Data" />
                            <asp:BoundField DataField="TIPO_CARGO_DESCRICAO" HeaderText="Cargo" />
                            <asp:BoundField DataField="SALARIO" HeaderText="Salário R$" />
                            <asp:BoundField DataField="HORARIO_INICIO" HeaderText="Horário - Entrada" />
                            <asp:BoundField DataField="HORARIO_FIM" HeaderText="Horário - Saída" />
                        </Columns>
                    </asp:GridView>
                </div>
                <!--span6-->

                <div class="span12">
                    <h3>Acidentes de Trabalho</h3>
                    <asp:Repeater ID="rptAcidenteTrabalho" runat="server" OnItemDataBound="rptAcidenteTrabalho_ItemDataBound">
                        <HeaderTemplate>
                            
                        </HeaderTemplate>
                        <ItemTemplate>
                            <table class="table table-bordered table-invoice">
                            <tr>
                                <td class="width30">Data:</td>
                                <td class="width70"><%# DataBinder.Eval(Container.DataItem,"DATA") %></td>
                            </tr>
                            <tr>
                                <td class="width30">Local Acidente:</td>
                                <td class="width70"><%# DataBinder.Eval(Container.DataItem,"ACIDENTE_TRABALHO_LOCAL") %></td>
                            </tr>
                            <tr>
                                <td class="width30">Causa Acidente:</td>
                                <td class="width70"><%# DataBinder.Eval(Container.DataItem,"CAUSA") %></td>
                            </tr>
                            <tr>
                                <td class="width30">Data Alta:</td>
                                <td class="width70"><%# DataBinder.Eval(Container.DataItem,"DATA_ALTA") %></td>
                            </tr>
                            <tr>
                                <td class="width30">Resultado:</td>
                                <td class="width70"><%# DataBinder.Eval(Container.DataItem,"RESULTADO") %></td>
                            </tr>
                            <tr>
                                <td class="width30">Observações:</td>
                                <td class="width70"><%# DataBinder.Eval(Container.DataItem,"OBSERVACOES") %></td>
                            </tr>
                                </table>
                        </ItemTemplate>
                        <FooterTemplate></FooterTemplate>
                    </asp:Repeater>
                </div>
                <!--span6-->
                
                
                <div class="span6">
                    <br /><br /><br /><br />
                    <br /><br /><br /><br />
                    <br /><br /><br /><br />
                    <table class="span12">
                        <tr>
                            <td>________________________________________</td>
                            <td></td>
                            <td>________________________________________</td>
                        </tr>
                        <tr>
                            <td>Assinatura do Empregador</td>
                            <td></td>
                            <td>Assinatura do Empregado</td>
                        </tr>
                    </table>
                </div>



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
