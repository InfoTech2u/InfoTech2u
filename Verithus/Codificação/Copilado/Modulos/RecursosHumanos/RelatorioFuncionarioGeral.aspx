<%@ Page Title="" Language="C#" MasterPageFile="~/Modulos/InfoTech2u.Master" AutoEventWireup="true" CodeBehind="RelatorioFuncionarioGeral.aspx.cs" Inherits="InfoTech2u.Verithus.WEB.Modulos.RecursosHumanos.RelatorioFuncionarioGeral" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderInfoTech2u" runat="server">
    <div class="rightpanel">
        
        
        <div class="maincontent">
            <div class="maincontentinner">
                
                
                    
                    <div class="span12">
                        <div class="invoice_logo"><img src="../../images/logo.png" alt="" class="img-polaroid" /></div>
                  
                        <table class="table table-bordered table-invoice">
                            <tr>
                                <td class="width30">Nome Funcionario:</td>
                                <td class="width70"><strong><asp:Label runat="server" ID="lblNomeFuncionario"></asp:Label></strong></td>
                            </tr>
                            <tr>
                                <td>Empresa:</td>
                                <td><asp:Label runat="server" ID="lblNomeEmpresa"></asp:Label></td>
                            </tr>
                            <tr>
                                <td>Data de Nascimento:</td>
                                <td><asp:Label runat="server" ID="lblDatadeNascimento"></asp:Label></td>
                            </tr>
                            <tr>
                                <td>Nacionalidade:</td>
                                <td><asp:Label runat="server" ID="lblNacionalidade"></asp:Label></td>
                            </tr>
                            <tr>
                                <td>Estado Civil:</td>
                                <td>lblEstadoCivil</td>
                            </tr>
                            <tr>
                                <td>Nome do(a) Conjuge:</td>
                                <td><asp:Label runat="server" ID="lblNomeConjuge"></asp:Label></td>
                            </tr>
                            <tr>
                                <td>Quantos Filhos:</td>
                                <td><asp:Label runat="server" ID="lblQtdFilhos"></asp:Label></td>
                            </tr>
                        </table>
                    </div><!--span6-->
                    
                    
                    
                    <div class="span12">
                    	<table class="table table-bordered table-invoice">
                            <tr>
                                <td class="width30">Endereço:</td>
                                <td class="width70"><strong><asp:Label runat="server" ID="lblTipoLogradouroFuncionario"></asp:Label> <asp:Label runat="server" ID="lblLogradouroFuncionario"></asp:Label>, <asp:Label runat="server" ID="lblNumeroFuncionario"></asp:Label></strong></td>
                            </tr>
                            <tr>
                                <td>Bairro:</td>
                                <td><asp:Label runat="server" ID="lblBairroFuncionario"></asp:Label></td>
                            </tr>
                            <tr>
                                <td>Complemento:</td>
                                <td><asp:Label runat="server" ID="lblComplemento"></asp:Label></td>
                            </tr>
                            <tr>
                                <td>Estado:</td>
                                <td><asp:Label runat="server" ID="lblEstado"></asp:Label></td>
                            </tr>
                            <tr>
                                <td>Cidade:</td>
                                <td><asp:Label runat="server" ID="lblCidade"></asp:Label></td>
                            </tr>
                            <tr>
                                <td>CEP:</td>
                                <td><asp:Label runat="server" ID="lblCEP"></asp:Label></td>
                            </tr>
                        </table>
            		</div><!--span6-->
                    
                    <div class="span12">
                  
                        <table class="table table-bordered table-invoice">
                            <tr>
                                <td class="width30">Nome do Pai:</td>
                                <td class="width70"><strong><asp:Label runat="server" ID="lblNomePai"></asp:Label></strong></td>
                            </tr>
                            <tr>
                                <td class="width30">Nacionalidade  do Pai:</td>
                                <td class="width70"><strong><asp:Label runat="server" ID="lblNacionalidadePai"></asp:Label></strong></td>
                            </tr>
                            <tr>
                                <td class="width30">Nome do Mãe:</td>
                                <td class="width70"><strong><asp:Label runat="server" ID="lblNomeMae"></asp:Label></strong></td>
                            </tr>
                            <tr>
                                <td class="width30">Nacionalidade  do Mãe:</td>
                                <td class="width70"><strong><asp:Label runat="server" ID="lblNacionalidadeMae"></asp:Label></strong></td>
                            </tr>
                        </table>
                        
                </div><!--span6-->
                
                <div class="span12">
                  
                        <table class="table table-bordered table-invoice">
                            <tr>
                                <td class="width30">Numero de RG:</td>
                                <td class="width70"><asp:Label runat="server" ID="lblRG"></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="width30">Numero Carteira de Trabalho:</td>
                                <td class="width70"><asp:Label runat="server" ID="lblNumeroCarteiraTrabalho"></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="width30">Numero da Serie:</td>
                                <td class="width70"><asp:Label runat="server" ID="lblNumeroSerie"></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="width30">Numero Certificado de Reservista:</td>
                                <td class="width70"><asp:Label runat="server" ID="lblNumeroCertificadoReservista"></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="width30">Categoria:</td>
                                <td class="width70"><asp:Label runat="server" ID="lblCategoria"></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="width30">Numero de CPF:</td>
                                <td class="width70"><asp:Label runat="server" ID="lblNumeroCPF"></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="width30">Titulo de Eleitor:</td>
                                <td class="width70"><asp:Label runat="server" ID="lblTituloEleitor"></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="width30">Numero Carteira de Saude:</td>
                                <td class="width70"><asp:Label runat="server" ID="lblCarteiraSaude"></asp:Label></td>
                            </tr>
                        </table>
                        
                </div><!--span6-->

                <div class="span12">
                  
                        <table class="table table-bordered table-invoice">
                            <tr>
                                <td class="width30">Data de Cadastro:</td>
                                <td class="width70"><asp:Label runat="server" ID="lblDataCadastroPIS"></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="width30">Numero do PIS:</td>
                                <td class="width70"><asp:Label runat="server" ID="lblNumeroPIS"></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="width30">Banco:</td>
                                <td class="width70"><asp:Label runat="server" ID="lblBancoPIS"></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="width30">Agencia:</td>
                                <td class="width70"><asp:Label runat="server" ID="lblAgenciaPIS"></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="width30">Conta/Digito:</td>
                                <td class="width70"><asp:Label runat="server" ID="lblContaPIS"></asp:Label>/<asp:Label runat="server" ID="lblDigitoPIS"></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="width30">Endereço:</td>
                                <td class="width70"><asp:Label runat="server" ID="lblTipoLogradouroPIS"></asp:Label> <asp:Label runat="server" ID="lblTLogradouroPIS"></asp:Label>, <asp:Label runat="server" ID="lblNumeroEnderecoPIS"></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="width30">Complemento:</td>
                                <td class="width70"><asp:Label runat="server" ID="lblComplementoPIS"></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="width30">Bairro:</td>
                                <td class="width70"><asp:Label runat="server" ID="lblBairroPIS"></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="width30">Cidade:</td>
                                <td class="width70"><asp:Label runat="server" ID="lblCidadePIS"></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="width30">Estado:</td>
                                <td class="width70"><asp:Label runat="server" ID="lblEstadoPIS"></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="width30">CEP:</td>
                                <td class="width70"><asp:Label runat="server" ID="lblCEPPIS"></asp:Label></td>
                            </tr>
                        </table>
                        
                </div><!--span6-->

                <div class="span12">
                  
                        <table class="table table-bordered table-invoice">
                            <tr>
                                <td class="width30">Optante:</td>
                                <td class="width70"><asp:Label runat="server" ID="lblOptanteFGTS"></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="width30">Data de Opção:</td>
                                <td class="width70"><asp:Label runat="server" ID="lblDataOpcaoFGTS"></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="width30">Data de retratação:</td>
                                <td class="width70"><asp:Label runat="server" ID="lblDataRetratacaoFGTS"></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="width30">Banco:</td>
                                <td class="width70"><asp:Label runat="server" ID="lblBancoFGTS"></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="width30">Agencia:</td>
                                <td class="width70"><asp:Label runat="server" ID="lblAgenciaFGTS"></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="width30">Conta/Digito:</td>
                                <td class="width70"><asp:Label runat="server" ID="lblContaFGTS"></asp:Label>/<asp:Label runat="server" ID="lblDigitoFGTS"></asp:Label></td>
                            </tr>
                        </table>
                        
                </div><!--span6-->

                <div class="span12">
                  
                        <table class="table table-bordered table-invoice">
                            <tr>
                                <td class="width30">Cor:</td>
                                <td class="width70"><asp:Label runat="server" ID="lblCor"></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="width30">Altura:</td>
                                <td class="width70"><asp:Label runat="server" ID="lblAltura"></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="width30">Peso:</td>
                                <td class="width70"><asp:Label runat="server" ID="lblPeso"></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="width30">Cabelo:</td>
                                <td class="width70"><asp:Label runat="server" ID="lblCabelo"></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="width30">Olho:</td>
                                <td class="width70"><asp:Label runat="server" ID="lblOlho"></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="width30">Sinais:</td>
                                <td class="width70"><asp:Label runat="server" ID="lblSinais"></asp:Label></td>
                            </tr>
                        </table>
                        
                </div><!--span6-->
                
            <div class="span12">
                  
                        <table class="table table-bordered table-invoice">
                            <tr>
                                <td class="width30">Data de Admissão:</td>
                                <td class="width70"><asp:Label runat="server" ID="lblDataAdmissao"></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="width30">Data do Registro:</td>
                                <td class="width70"><asp:Label runat="server" ID="lblDataregistroAdmissao"></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="width30">Cargo:</td>
                                <td class="width70"><asp:Label runat="server" ID="lblCargoAdmissao"></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="width30">Seção:</td>
                                <td class="width70"><asp:Label runat="server" ID="lblSecaoAdmissao"></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="width30">Salário Inicial R$:</td>
                                <td class="width70"><asp:Label runat="server" ID="lblSalarioAdmissao"></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="width30">Comissões:</td>
                                <td class="width70"><asp:Label runat="server" ID="lblComissoeAdmissao"></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="width30">Tarefa:</td>
                                <td class="width70"><asp:Label runat="server" ID="lblTarefaAdmissao"></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="width30">Forma de Pagamento:</td>
                                <td class="width70"><asp:Label runat="server" ID="lblFormaPagamentoAdmissao"></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="width30">Horário de Trabalho - Entrada:</td>
                                <td class="width70"><asp:Label runat="server" ID="lblHorarioTrabalhoEntredaAdmissao"></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="width30">Horário de Trabalho - Saida:</td>
                                <td class="width70"><asp:Label runat="server" ID="lblHorarioTrabalhoSaidaAdmissao"></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="width30">Intervalo de Trabalho - Entrada:</td>
                                <td class="width70"><asp:Label runat="server" ID="lblIntervaloTravbalhoEntradaAdmissao"></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="width30">Intervalo de Trabalho - Saida:</td>
                                <td class="width70"><asp:Label runat="server" ID="lblIntervaloTrabalhoSaidaAdmissao"></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="width30">Descanso Semanal - Entrada:</td>
                                <td class="width70"><asp:Label runat="server" ID="lblDescabsiSemanaEntradaAdmissao"></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="width30">Descanso Semanal - Saida:</td>
                                <td class="width70"><asp:Label runat="server" ID="lblDescansoSemanaSaidaAdmissao"></asp:Label></td>
                            </tr>
                        </table>
                        
                </div><!--span6-->
            
            <div class="clearfix"><br /></div>
            
            <table class="table table-bordered table-invoice-full">
                <colgroup>
                    <col class="con0 width15" />
                    <col class="con1 width45" />
                    <col class="con0 width5" />
                    <col class="con1 width15" />
                    <col class="con0 width20" />
                </colgroup>
                <thead>
                    <tr>
                        <th class="head0">Type</th>
                        <th class="head1">Description</th>
                        <th class="head0 right">Quantity</th>
                        <th class="head1 right">Unit Price</th>
                        <th class="head0 right">Amount</th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td>Website Design</td>
                        <td>Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae</td>
                        <td class="right">2</td>
                        <td class="right">$150</td>
                        <td class="right"><strong>$300</strong></td>
                    </tr>
                    <tr>
                        <td>Firefox Plugin</td>
                        <td>At vero eos et accusamus et iusto odio dignissimos ducimus qui blanditiis praesentium voluptatum deleniti atque</td>
                        <td class="right">1</td>
                        <td class="right">$1,200</td>
                        <td class="right"><strong>$1,2000</strong></td>
                    </tr>
                    <tr>
                        <td>iPhone App</td>
                        <td>Et harum quidem rerum facilis est et expedita distinctio</td>
                        <td class="right">2</td>
                        <td class="right">$850</td>
                        <td class="right"><strong>$1,700</strong></td>
                    </tr>
                    <tr>
                        <td>Android App</td>
                        <td>Neque porro quisquam est, qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit, sed quia non numquam eius modi tempora incidunt ut</td>
                        <td class="right">3</td>
                        <td class="right">$850</td>
                        <td class="right"><strong>$2,550</strong></td>
                    </tr>
                    <tr>
                        <td>Wordpress Template</td>
                        <td>At vero eos et accusamus et iusto odio dignissimos ducimus qui blanditiis praesentium voluptatum deleniti atque</td>
                        <td class="right">5</td>
                        <td class="right">$50</td>
                        <td class="right"><strong>$250</strong></td>
                    </tr>
                    </tbody>
                </table>
                                
                <table class="table invoice-table">
                    <tbody>
                        <tr>
                        	<td class="width65 msg-invoice">
          						<h4>Message:</h4>
          						<p>Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo. Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit aut fugit, sed quia consequuntur magni dolores eos qui ratione voluptatem sequi nesciunt. </p>
                            </td>
                            <td class="width15 right numlist">
                            	  <strong>Subtotal</strong>
                                <strong>Tax (5%)</strong>
                                <strong>Discount</strong>
                            </td>
                            <td class="width20 right numlist">
                                <strong>$1,000</strong>
                                <strong>$320</strong>
                                <strong>$50</strong>
                            </td>
                        </tr>
                    </tbody>
          </table>
			
          <div class="amountdue">
          	<h1><span>Amount Due:</span> $1,370.00</h1> <br />
            <a href="" class="btn btn-primary btn-large">Pay Invoice</a>
          </div>
          
          <div class="footer">
                    <div class="footer-left">
                        <span>&copy; 2013. Shamcey Admin Template. All Rights Reserved.</span>
                    </div>
                    <div class="footer-right">
                        <span>Designed by: <a href="http://themepixels.com/">ThemePixels</a></span>
                    </div>
                </div><!--footer-->
          
            </div><!--maincontentinner-->
        </div><!--maincontent-->
        
    </div><!--rightpanel-->
</asp:Content>
