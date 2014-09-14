<%@ Page Title="" Language="C#" MasterPageFile="~/Modulos/InfoTech2u.Master" AutoEventWireup="true" CodeBehind="PesquisaFuncionario.aspx.cs" Inherits="InfoTech2u.Verithus.WEB.Modulos.RecursosHumanos.Funcionario.PesquisaFuncionario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderInfoTech2u" runat="server">

    <script type="text/javascript">
        jQuery(document).ready(function () {
            // dynamic table

            //GridFake();

            jQuery("#btnPesquisar").click(function () {

                Pesquisar();


                //return false;
            });

            



            jQuery("#btnIncluir").click(function () {

                var codigoSel = jQuery('input[name=rdbFuncionario]:checked', '.frmInfotech2u').val();
                jQuery(window.document.location).attr('href', 'ManterFuncionario.aspx?tpAcao=1');

                return false;
            });

            jQuery("#btnAlterar").click(function () {

                var codigoSel = jQuery('input[name=rdbFuncionario]:checked', '.frmInfotech2u').val();
                jQuery(window.document.location).attr('href', 'ManterFuncionario.aspx?tpAcao=2&idUser=' + codigoSel);

                return false;
            });

            jQuery("#btnDetalhar").click(function () {

                var codigoSel = jQuery('input[name=rdbFuncionario]:checked', '.frmInfotech2u').val();
                jQuery(window.document.location).attr('href', 'ManterFuncionario.aspx?tpAcao=3&idUser=' + codigoSel);

                return false;
            });

            jQuery("#btnExcluir").click(function () {

                var codigoSel = jQuery('input[name=rdbFuncionario]:checked', '.frmInfotech2u').val();
                jQuery(window.document.location).attr('href', 'ManterFuncionario.aspx?idUser=' + codigoSel);

                return false;
            });

            jQuery("#btnAdmisao").click(function () {

                var codigoSel = jQuery('input[name=rdbFuncionario]:checked', '.frmInfotech2u').val();
                jQuery(window.document.location).attr('href', 'ManterAdmissao.aspx?idUser=' + codigoSel);

                return false;
            });

            jQuery("#btnDemissao").click(function () {

                var codigoSel = jQuery('input[name=rdbFuncionario]:checked', '.frmInfotech2u').val();
                jQuery(window.document.location).attr('href', 'ManterDemissao.aspx?idUser=' + codigoSel);

                return false;
            });

            jQuery("#btnDependente").click(function () {

                var codigoSel = jQuery('input[name=rdbFuncionario]:checked', '.frmInfotech2u').val();
                jQuery(window.document.location).attr('href', 'ManterDependente.aspx?idUser=' + codigoSel);

                return false;
            });

            jQuery("#btnSindical").click(function () {

                var codigoSel = jQuery('input[name=rdbFuncionario]:checked', '.frmInfotech2u').val();
                jQuery(window.document.location).attr('href', 'ManterContribuicaoSindicaol.aspx?idUser=' + codigoSel);

                return false;
            });



        });

        function Pesquisar() {

            jQuery.ajax({
                type: "GET",
                url: "../../Handler/PesquisarFuncionario.ashx",
                data: {
                    CodigoFuncionario: jQuery('#txtCodigoFuncionario').val(),
                    NumeroOrdemMatricula: jQuery('#txtNumeroOrdemMatricula').val(),
                    NumeroMatricula: jQuery('#txtNumeroMatricula').val(),
                    NomeFuncionario: jQuery('#txtNomeFuncionario').val()
                },
                contentType: "json",
                cache: false,
                success: function (data) {

                    var arrFuncionario = eval(data);

                    for (var i = 0; i < arrFuncionario.length; i++) {

                        var row = '<tr class="gradeX"><td><input type="radio" name="rdbFuncionario" value="' + arrFuncionario[i].FUNC_CODIGO_FUNCIONARIO + '" /></td><td>' + arrFuncionario[i].FUNC_CODIGO_FUNCIONARIO + '</td><td>' + arrFuncionario[i].FUNC_NUMERO_ORDEM_MATRICULA + '</td><td>' + arrFuncionario[i].FUNC_NUMERO_MATRICULA + '</td><td class="center">' + arrFuncionario[i].FUNC_NOME_FUNCIONARIO + '</td></tr>';
                        jQuery('tbody').append(row);

                    }
                },
                error: function (XMLHttpRequest, textStatus, errorThrow) {
                    errorAjax(textStatus);
                }
            });


            jQuery('#dyntable').dataTable({
                "sPaginationType": "full_numbers",
                "aaSortingFixed": [[0, 'asc']],
                "fnDrawCallback": function (oSettings) {
                    jQuery.uniform.update();
                }
            });
        }

        function GridFake() {

            for (i = 0; i < 50; i++) {
                var row = '<tr class="gradeX"><td><input type="radio" name="rdbFuncionario" value="' + i + '" /></td><td>' + i + '</td><td>' + i + '</td><td>' + i + '</td><td class="center">Nome do Funcionario ' + i + '</td></tr>';
                jQuery('tbody').append(row);
            }
        }



    </script>
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
                                <a href="#" class="btn btn-rounded"><i class="iconfa-refresh iconsweets-black"></i>&nbsp; limpar</a>
                            </p>

                        </div>
                    </div>
                </div>

                <h4 class="widgettitle">Data Table</h4>
                <table id="dyntable" class="table table-bordered responsive">
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
                    <!--<tbody>
                        <tr class="gradeX">
                            <td><input type="radio" name="rdbFuncionario" value="1" /></td>
                            <td>1</td>
                            <td>1</td>
                            <td>1001</td>
                            <td class="center">Nome do Funcionario 1</td>
                        </tr>
                        <tr class="gradeC">
                            <td>Trident</td>
                            <td>Internet Explorer 5.0</td>
                            <td>Win 95+</td>
                            <td class="center">5</td>
                        </tr>
                        <tr class="gradeA">
                            <td>Trident</td>
                            <td>Internet Explorer 5.5</td>
                            <td>Win 95+</td>
                            <td class="center">5.5</td>
                        </tr>
                        <tr class="gradeA">
                            <td>Trident</td>
                            <td>Internet Explorer 6</td>
                            <td>Win 98+</td>
                            <td class="center">6</td>
                        </tr>
                        <tr class="gradeA">
                            <td>Trident</td>
                            <td>Internet Explorer 7</td>
                            <td>Win XP SP2+</td>
                            <td class="center">7</td>
                        </tr>
                        <tr class="gradeA">
                            <td>Trident</td>
                            <td>AOL browser (AOL desktop)</td>
                            <td>Win XP</td>
                            <td class="center">6</td>
                        </tr>
                        <tr class="gradeA">
                            <td>Gecko</td>
                            <td>Firefox 1.0</td>
                            <td>Win 98+ / OSX.2+</td>
                            <td class="center">1.7</td>
                        </tr>
                        <tr class="gradeA">
                            <td>Gecko</td>
                            <td>Firefox 1.5</td>
                            <td>Win 98+ / OSX.2+</td>
                            <td class="center">1.8</td>
                        </tr>
                        <tr class="gradeA">
                            <td>Gecko</td>
                            <td>Firefox 2.0</td>
                            <td>Win 98+ / OSX.2+</td>
                            <td class="center">1.8</td>
                        </tr>
                        <tr class="gradeA">
                            <td>Gecko</td>
                            <td>Firefox 3.0</td>
                            <td>Win 2k+ / OSX.3+</td>
                            <td class="center">1.9</td>
                        </tr>
                        <tr class="gradeA">
                            <td>Gecko</td>
                            <td>Camino 1.0</td>
                            <td>OSX.2+</td>
                            <td class="center">1.8</td>
                        </tr>
                        <tr class="gradeA">
                            <td>Gecko</td>
                            <td>Camino 1.5</td>
                            <td>OSX.3+</td>
                            <td class="center">1.8</td>
                        </tr>
                        <tr class="gradeA">
                            <td>Gecko</td>
                            <td>Netscape 7.2</td>
                            <td>Win 95+ / Mac OS 8.6-9.2</td>
                            <td class="center">1.7</td>
                        </tr>
                        <tr class="gradeA">
                            <td>Gecko</td>
                            <td>Netscape Browser 8</td>
                            <td>Win 98SE+</td>
                            <td class="center">1.7</td>
                        </tr>
                        <tr class="gradeA">
                            <td>Gecko</td>
                            <td>Netscape Navigator 9</td>
                            <td>Win 98+ / OSX.2+</td>
                            <td class="center">1.8</td>
                        </tr>
                        <tr class="gradeA">
                            <td>Gecko</td>
                            <td>Mozilla 1.0</td>
                            <td>Win 95+ / OSX.1+</td>
                            <td class="center">1</td>
                        </tr>
                        <tr class="gradeA">
                            <td>Gecko</td>
                            <td>Mozilla 1.1</td>
                            <td>Win 95+ / OSX.1+</td>
                            <td class="center">1.1</td>
                        </tr>
                        <tr class="gradeA">
                            <td>Gecko</td>
                            <td>Mozilla 1.2</td>
                            <td>Win 95+ / OSX.1+</td>
                            <td class="center">1.2</td>
                        </tr>
                        <tr class="gradeA">
                            <td>Gecko</td>
                            <td>Mozilla 1.3</td>
                            <td>Win 95+ / OSX.1+</td>
                            <td class="center">1.3</td>
                        </tr>
                        <tr class="gradeA">
                            <td>Gecko</td>
                            <td>Mozilla 1.4</td>
                            <td>Win 95+ / OSX.1+</td>
                            <td class="center">1.4</td>
                        </tr>
                        <tr class="gradeA">
                            <td>Gecko</td>
                            <td>Mozilla 1.5</td>
                            <td>Win 95+ / OSX.1+</td>
                            <td class="center">1.5</td>
                        </tr>
                        <tr class="gradeA">
                            <td>Gecko</td>
                            <td>Mozilla 1.6</td>
                            <td>Win 95+ / OSX.1+</td>
                            <td class="center">1.6</td>
                        </tr>
                        <tr class="gradeA">
                            <td>Gecko</td>
                            <td>Mozilla 1.7</td>
                            <td>Win 98+ / OSX.1+</td>
                            <td class="center">1.7</td>
                        </tr>
                        <tr class="gradeA">
                            <td>Gecko</td>
                            <td>Mozilla 1.8</td>
                            <td>Win 98+ / OSX.1+</td>
                            <td class="center">1.8</td>
                        </tr>
                        <tr class="gradeA">
                            <td>Gecko</td>
                            <td>Seamonkey 1.1</td>
                            <td>Win 98+ / OSX.2+</td>
                            <td class="center">1.8</td>
                        </tr>
                        <tr class="gradeA">
                            <td>Gecko</td>
                            <td>Epiphany 2.20</td>
                            <td>Gnome</td>
                            <td class="center">1.8</td>
                        </tr>
                        <tr class="gradeA">
                            <td>Webkit</td>
                            <td>Safari 1.2</td>
                            <td>OSX.3</td>
                            <td class="center">125.5</td>
                        </tr>
                        <tr class="gradeA">
                            <td>Webkit</td>
                            <td>Safari 1.3</td>
                            <td>OSX.3</td>
                            <td class="center">312.8</td>
                        </tr>
                        <tr class="gradeA">
                            <td>Webkit</td>
                            <td>Safari 2.0</td>
                            <td>OSX.4+</td>
                            <td class="center">419.3</td>
                        </tr>
                        <tr class="gradeA">
                            <td>Webkit</td>
                            <td>Safari 3.0</td>
                            <td>OSX.4+</td>
                            <td class="center">522.1</td>
                        </tr>
                       
                    </tbody>-->
                </table>
                <br />
                <div class="row-fluid">
                    <button class="btn btn-primary" id="btnIncluir"><i class="iconsweets-magnifying"></i>&nbsp; Incluir</button>
                    <button class="btn" id="btnAlterar"><i class="iconsweets-magnifying"></i>&nbsp; Alterar</button>
                    <button class="btn" id="btnExcluir"><i class="iconsweets-magnifying"></i>&nbsp; Excluir</button>
                    <button class="btn" id="btnDetalhar"><i class="iconsweets-magnifying"></i>&nbsp; Detalhar</button>
                    <button class="btn" id="btnAdmisao"><i class="iconsweets-magnifying"></i>&nbsp; Admissão</button>
                    <button class="btn" id="btnDemissao"><i class="iconsweets-magnifying"></i>&nbsp; Demissão</button>
                    <button class="btn" id="btnDependente"><i class="iconsweets-magnifying"></i>&nbsp; Dependentes</button>
                    <button class="btn" id="btnSindical"><i class="iconsweets-magnifying"></i>&nbsp; Contribuição Sindical</button>
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
