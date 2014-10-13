<%@ Page Title="" Language="C#" MasterPageFile="~/Modulos/InfoTech2u.Master" AutoEventWireup="true" CodeBehind="PesquisaFuncionario.aspx.cs" Inherits="InfoTech2u.Verithus.WEB.Modulos.RecursosHumanos.Funcionario.PesquisaFuncionario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderInfoTech2u" runat="server">

    <script type="text/javascript">
        jQuery(document).ready(function () {
            // dynamic table
            /*jQuery('#dyntable').dataTable({
                "sPaginationType": "full_numbers",
                "aaSortingFixed": [[0, 'asc']],
                "fnDrawCallback": function (oSettings) {
                    jQuery.uniform.update();
                }
            });*/




            //GridFake();

            jQuery('#dyntable').hide();
            jQuery('.dyntable').hide();
            jQuery('.btnAcao').hide();

            //btnLimpar


            jQuery("#btnLimpar").click(function () {
                

                jQuery('#txtCodigoFuncionario').attr('value', '');
                jQuery('#txtNumeroOrdemMatricula').attr('value', '');
                jQuery('#txtNumeroMatricula').attr('value', '');
                jQuery('#txtNomeFuncionario').attr('value', '');

                jQuery('#dyntable').hide();
                jQuery('.dyntable').hide();
                jQuery('.btnAcao').hide();

                jQuery("tbody").empty();
                jQuery('tbody').remove();

            });

            jQuery("#btnPesquisar").click(function () {



                jQuery('#dyntable').show();
                jQuery('.dyntable').show();
                jQuery('.btnAcao').show();
                jQuery("tbody").empty();
                jQuery('tbody').remove();
                jQuery('#dyntable').append('<tbody></tbody>');

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

                        //jQuery('tbody').remove();
                        //('#dyntable').append('<tbody></tbody>');


                        for (var i = 0; i < arrFuncionario.length; i++) {

                            var row = '<tr id="' + arrFuncionario[i].FUNC_CODIGO_FUNCIONARIO + '" class="gradeX"><td><input type="radio" name="rdbFuncionario" class="rdbFuncionario" value="' + arrFuncionario[i].FUNC_CODIGO_FUNCIONARIO + '" /></td><td>' + arrFuncionario[i].FUNC_CODIGO_FUNCIONARIO + '</td><td>' + arrFuncionario[i].FUNC_NUMERO_ORDEM_MATRICULA + '</td><td>' + arrFuncionario[i].FUNC_NUMERO_MATRICULA + '</td><td class="center">' + arrFuncionario[i].FUNC_NOME_FUNCIONARIO + '</td></tr>';
                            jQuery('tbody').append(row);

                        }


                        jQuery('#dyntable').dataTable().fnDestroy();

                        jQuery('#dyntable').dataTable({
                            "sPaginationType": "full_numbers",
                            "fnDrawCallback": function (oSettings) {
                                jQuery.uniform.update();
                            },
                            "language": {
                                "lengthMenu": "Display _MENU_ records per page",
                                "zeroRecords": "Nothing found - sorry",
                                "info": "Showing page _PAGE_ of _PAGES_",
                                "infoEmpty": "No records available",
                                "infoFiltered": "(filtered from _MAX_ total records)",
                                "sInfoEmpty": "Mostrando 0-0 de 0 Funcionários"
                            }
                            //"sInfoEmpty": "Mostrando 0-0 de 0 Funcionários"
                        });

                    },
                    error: function (XMLHttpRequest, textStatus, errorThrow) {
                        errorAjax(textStatus);
                    }
                });



                //Pesquisar();


                return false;
            });



            //rdbFuncionario






            jQuery("#btnIncluir").click(function () {

                var codigoSel = jQuery('input[name=rdbFuncionario]:checked', '.frmInfotech2u').val();
                jQuery(window.document.location).attr('href', 'ManterFuncionario.aspx?tpAcao=1');

                return false;
            });

            jQuery("#btnAlterar").click(function () {

                var codigoSel = jQuery('input[name=rdbFuncionario]:checked', '.frmInfotech2u').val();
                //jQuery(window.document.location).attr('href', 'ManterFuncionario.aspx?tpAcao=2&idUser=' + codigoSel);
                if (codigoSel != null)
                    jQuery(window.document.location).attr('href', 'ManterFuncionario.aspx?tpAcao=2&idUser=' + codigoSel);
                else {
                    jQuery.alerts.dialogClass = 'alert-warning';
                    jAlert('Selecione um funcionario', 'Alerta', function () {
                        jQuery.alerts.dialogClass = null; // reset to default
                    });
                }

                return false;
            });

            jQuery("#btnDetalhar").click(function () {

                var codigoSel = jQuery('input[name=rdbFuncionario]:checked', '.frmInfotech2u').val();
                if (codigoSel != null)
                    jQuery(window.document.location).attr('href', 'ManterFuncionario.aspx?tpAcao=3&idUser=' + codigoSel);
                else {
                    jQuery.alerts.dialogClass = 'alert-warning';
                    jAlert('Selecione um funcionario', 'Alerta', function () {
                        jQuery.alerts.dialogClass = null; // reset to default
                    });
                }

                return false;
            });

            jQuery("#btnExcluir").click(function () {

                var codigoSel = jQuery('input[name=rdbFuncionario]:checked', '.frmInfotech2u').val();

                jQuery.ajax({
                    type: "GET",
                    url: "../../Handler/ExcluirFuncionario.ashx",
                    data: {
                        CodigoFuncionario: codigoSel
                    },
                    contentType: "json",
                    cache: false,
                    success: function (data) {

                        var arrFuncionario = eval(data);

                        if (arrFuncionario[0].CodigoErro = '1') {

                            jQuery('table tbody tr[id="' + codigoSel + '"]').remove();

                            jQuery.alerts.dialogClass = 'alert-warning';
                            jAlert(arrFuncionario[0].Mensagem, 'Mensagem', function () {
                                jQuery.alerts.dialogClass = null; // reset to default
                            });
                        }
                        else if (arrFuncionario[0].CodigoErro = '2') {
                            jQuery.alerts.dialogClass = 'alert-warning';
                            jAlert(arrFuncionario[0].Mensagem, 'Mensagem', function () {
                                jQuery.alerts.dialogClass = null; // reset to default
                            });
                        }

                        //jQuery('#dyntable').dataTable().fnDestroy();

                       

                    },
                    error: function (XMLHttpRequest, textStatus, errorThrow) {
                        errorAjax(textStatus);
                    }
                });

                return false;
            });

            jQuery("#btnAdmisao").click(function () {

                var codigoSel = jQuery('input[name=rdbFuncionario]:checked', '.frmInfotech2u').val();
                //jQuery(window.document.location).attr('href', 'ManterAdmissao.aspx?idUser=' + codigoSel);
                if (codigoSel != null)
                    jQuery(window.document.location).attr('href', 'ManterAdmissao.aspx?idUser=' + codigoSel);
                else {
                    jQuery.alerts.dialogClass = 'alert-warning';
                    jAlert('Selecione um funcionario', 'Alerta', function () {
                        jQuery.alerts.dialogClass = null; // reset to default
                    });
                }

                return false;
            });

            jQuery("#btnDemissao").click(function () {

                var codigoSel = jQuery('input[name=rdbFuncionario]:checked', '.frmInfotech2u').val();
                //jQuery(window.document.location).attr('href', 'ManterDemissao.aspx?idUser=' + codigoSel);
                if (codigoSel != null)
                    jQuery(window.document.location).attr('href', 'ManterDemissao.aspx?idUser=' + codigoSel);
                else {
                    jQuery.alerts.dialogClass = 'alert-warning';
                    jAlert('Selecione um funcionario', 'Alerta', function () {
                        jQuery.alerts.dialogClass = null; // reset to default
                    });
                }

                return false;
            });

            jQuery("#btnDependente").click(function () {

                var codigoSel = jQuery('input[name=rdbFuncionario]:checked', '.frmInfotech2u').val();
                //jQuery(window.document.location).attr('href', 'ManterDependente.aspx?idUser=' + codigoSel);
                if (codigoSel != null)
                    jQuery(window.document.location).attr('href', 'ManterDependente.aspx?idUser=' + codigoSel);
                else {
                    jQuery.alerts.dialogClass = 'alert-warning';
                    jAlert('Selecione um funcionario', 'Alerta', function () {
                        jQuery.alerts.dialogClass = null; // reset to default
                    });
                }

                return false;
            });

            jQuery("#btnSindical").click(function () {

                var codigoSel = jQuery('input[name=rdbFuncionario]:checked', '.frmInfotech2u').val();
                //jQuery(window.document.location).attr('href', 'ManterContribuicaoSindicaol.aspx?idUser=' + codigoSel);
                if (codigoSel != null)
                    jQuery(window.document.location).attr('href', 'ManterContribuicaoSindical.aspx?idUser=' + codigoSel);
                else {
                    jQuery.alerts.dialogClass = 'alert-warning';
                    jAlert('Selecione um funcionario', 'Alerta', function () {
                        jQuery.alerts.dialogClass = null; // reset to default
                    });
                }
                return false;
            });


            jQuery("#btnFerias").click(function () {

                var codigoSel = jQuery('input[name=rdbFuncionario]:checked', '.frmInfotech2u').val();

                if (codigoSel != null)
                    jQuery(window.document.location).attr('href', 'ManterFerias.aspx?idUser=' + codigoSel);
                else {
                    jQuery.alerts.dialogClass = 'alert-warning';
                    jAlert('Selecione um funcionario', 'Alerta', function () {
                        jQuery.alerts.dialogClass = null; // reset to default
                    });
                }
                return false;
            });

            jQuery("#btnAlteracaoCargoSalario").click(function () {

                var codigoSel = jQuery('input[name=rdbFuncionario]:checked', '.frmInfotech2u').val();

                if (codigoSel != null)
                    jQuery(window.document.location).attr('href', 'ManterAlteracaoCargoSalario.aspx?idUser=' + codigoSel);
                else {
                    jQuery.alerts.dialogClass = 'alert-warning';
                    jAlert('Selecione um funcionario', 'Alerta', function () {
                        jQuery.alerts.dialogClass = null; // reset to default
                    });
                }
                return false;
            });

            jQuery("#btnAcidenteTrabalho").click(function () {

                var codigoSel = jQuery('input[name=rdbFuncionario]:checked', '.frmInfotech2u').val();

                if (codigoSel != null)
                    jQuery(window.document.location).attr('href', 'ManterAcidenteTrabalho.aspx?idUser=' + codigoSel);
                else {
                    jQuery.alerts.dialogClass = 'alert-warning';
                    jAlert('Selecione um funcionario', 'Alerta', function () {
                        jQuery.alerts.dialogClass = null; // reset to default
                    });
                }
                return false;
            });
            
        });



        function Pesquisar() {


            jQuery("tbody").empty();

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

                    //jQuery('tbody').remove();
                    //('#dyntable').append('<tbody></tbody>');


                    for (var i = 0; i < arrFuncionario.length; i++) {

                        var row = '<tr class="gradeX"><td><input type="radio" name="rdbFuncionario" value="' + arrFuncionario[i].FUNC_CODIGO_FUNCIONARIO + '" /></td><td>' + arrFuncionario[i].FUNC_CODIGO_FUNCIONARIO + '</td><td>' + arrFuncionario[i].FUNC_NUMERO_ORDEM_MATRICULA + '</td><td>' + arrFuncionario[i].FUNC_NUMERO_MATRICULA + '</td><td class="center">' + arrFuncionario[i].FUNC_NOME_FUNCIONARIO + '</td></tr>';
                        jQuery('tbody').append(row);

                    }
                },
                error: function (XMLHttpRequest, textStatus, errorThrow) {
                    errorAjax(textStatus);
                }
            });

            jQuery('#dyntable').dataTable().fnDestroy();
            jQuery('#dyntable').dataTable({
                "sPaginationType": "full_numbers",
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
