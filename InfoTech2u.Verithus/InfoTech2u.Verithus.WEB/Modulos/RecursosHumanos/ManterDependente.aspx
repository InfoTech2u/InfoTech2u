<%@ Page Title="" Language="C#" MasterPageFile="~/Modulos/InfoTech2u.Master" AutoEventWireup="true" CodeBehind="ManterDependente.aspx.cs" Inherits="InfoTech2u.Verithus.WEB.Modulos.RecursosHumanos.ManterDependente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderInfoTech2u" runat="server">
    <script type="text/javascript">
        Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(BeginRequest);
        function BeginRequest(sender, e) {
            e.get_postBackElement().disabled = true;

        }

        jQuery(document).ready(function () {
            CarregarDependentes();

            jQuery('#btnIncluir').click(function (event) {
                if (validar()) {

                    jQuery.ajax({
                        type: "GET",
                        crossDomain: true,
                        url: "../../Handler/TipoBeneficio.ashx?Incluir",
                        contentType: "json",
                        cache: false,
                        data: {
                            Metodo: 'Incluir',
                            Acao: 'Inclusao',
                            Descricao: jQuery('#txtDescricaoTipoBeneficio').val()
                        },
                        success: function (data) {

                            if (data) {
                                LimparGrid();
                                FormatarGrid();
                                CarregarTipoBeneficioLista();


                                jQuery('#myModal').modal('hide')
                            }
                            else {
                                alert("Não foi possível incluir.");
                            }

                        },
                        error: function (XMLHttpRequest, textStatus, errorThrow) {
                            errorAjax(textStatus);
                            alert(textStatus);
                        }
                    });
                }
            });


        });

        function validar() {

            if (jQuery('#txtDescricaoTipoBeneficio').val() == "") {
                alert("Preencha a descrição do benefício.")
                return false;
            }
            else {
                return true;
            }
        };

        function CarregarDependentes() {

            jQuery.ajax({
                type: "GET",
                crossDomain: true,
                url: "../../Handler/Dependente.ashx",
                contentType: "json",
                cache: false,
                data: {
                    Metodo: 'Lista',
                    Acao: 'Consulta',
                    CodigoFuncionario: jQuery('#hdnCodigoFuncionario').val()
                },
                success: function (data) {

                    var tiposBeneficios = eval(data);
                    for (x in tiposBeneficios) {
                        var row = '<tr><td>' + tiposBeneficios[x].CodigoTipoBeneficio + '</td><td>' + tiposBeneficios[x].Descricao + '</td><td class="centeralign"><a title="Excluir" href="#" class="deleterow"><i class="icon-trash"></i></a></td></tr>';
                        jQuery('tbody').append(row);
                    }
                    FormatarGrid();
                    Excluir();
                },
                error: function (XMLHttpRequest, textStatus, errorThrow) {
                    errorAjax(textStatus);
                    alert(textStatus);
                }
            });
        }

        function FormatarGrid() {
            // dynamic table
            jQuery('#dyntable').dataTable({
                "sPaginationType": "full_numbers",
                "aaSortingFixed": [[0, 'asc']],
                "fnDrawCallback": function (oSettings) {
                    jQuery.uniform.update();
                }
            });
        };

        function Excluir() {
            // delete row in a table
            jQuery('.deleterow').click(function () {
                var conf = confirm('Continue delete?');
                if (conf)
                    jQuery(this).parents('tr').fadeOut(function () {
                        var id = jQuery(this).children('td:first').text();

                        jQuery.ajax({
                            type: "GET",
                            crossDomain: true,
                            url: "../../Handler/TipoBeneficio.ashx",
                            contentType: "json",
                            cache: false,
                            data: {
                                Metodo: 'Excluir',
                                Acao: 'Exclusao',
                                Id: id
                            },
                            success: function (data) {

                                if (data) {
                                    jQuery(this).remove();
                                    // do some other stuff here
                                }

                                FormatarGrid();
                                Excluir();
                            },
                            error: function (XMLHttpRequest, textStatus, errorThrow) {
                                errorAjax(textStatus);
                                alert(textStatus);
                            }
                        });


                    });
                return false;
            });
        }

        function LimparGrid() {
            // dynamic table
            jQuery('#dyntable tbody tr').remove();
        };

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

                <div aria-hidden="false" aria-labelledby="myModalLabel" role="dialog" tabindex="-1" class="modal hide fade in" id="myModal">
                    <div class="modal-header widgettitle">
                        <button aria-hidden="true" data-dismiss="modal" class="close" type="button">&times;</button>
                        <h3 id="myModalLabel">Dependente</h3>

                    </div>
                    <div class="modal-body">
                        <div class="widgetbox box-inverse">

                            <div class="par control-group">
                                <label class="control-label" for="nomedependente">Nome Dependente</label>
                                <div class="controls">
                                    <asp:TextBox runat="server" ID="txtNomeDependente" class="input-block-level" ClientIDMode="Static" />
                                </div>
                            </div>

                            <div class="par control-group">
                                <label>Parentesco</label>
                                <span class="field">
                                    <asp:DropDownList runat="server" ID="ddlTipoParentesco" data-placeholder="Escolha o parentesco..." Style="width: 350px" class="chzn-select" TabIndex="2" ClientIDMode="Static" ></asp:DropDownList>
                                </span>
                            </div>
                            
                            <div class="control-group">
                                <label class="control-label" for="txtDataNascimento">Data Nascimento</label>
                                <div class="controls">
                                    <asp:TextBox runat="server" ID="txtDataNascimento" class="input-small dataddmmaaaa" ClientIDMode="Static" />
                                </div>
                            </div>

                            <div class="control-group">
                                <label>Benefícios</label>
                                <span id="dualselect" class="dualselect" style="margin-left: 0px">
                                    <asp:ListBox ID="lstBeneficioSelect" runat="server" SelectionMode="Multiple" ClientIDMode="Static">
                                    </asp:ListBox>
                                    <span class="ds_arrow">
                                        <button class="btn ds_prev"><i class="iconfa-chevron-left"></i></button>
                                        <br />
                                        <button class="btn ds_next"><i class="iconfa-chevron-right"></i></button>
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
                        <a class="btn btn-primary" id="btnIncluir" href="#" data-toggle="modal"><i class="iconfa-pencil"></i>&nbsp; Incluir</a>
                    </div>
                </div>
                <!--#myModal-->

                <div class="row-fluid">
                    <a class="btn btn-primary" href="#myModal" data-toggle="modal"><i class="iconfa-pencil"></i>&nbsp; Incluir</a>                   
                </div>

                <h4 class="widgettitle">Dependentes</h4>
                <table id="dyntable" class="table table-bordered responsive">
                    <colgroup>
                        <col class="con0" style="align: center; width: 4%" />
                        <col class="con1" />
                        <col class="con0" />
                        <col class="con1" />
                        <col class="con0" />
                        <col class="con1" />
                    </colgroup>
                    <thead>
                        <tr>
                            <th class="head0 nosort">
                                <input type="checkbox" class="checkall" /></th>
                            <th class="head0">Nome Dependente</th>
                            <th class="head1">Parentesco</th>
                            <th class="head0">Data Nascimento</th>
                            <th class="head1">Benefício</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr class="gradeX">
                            <td class="aligncenter"><span class="center">
                                <input type="checkbox" />
                            </span></td>
                            <td>Trident</td>
                            <td>Internet Explorer 4.0</td>
                            <td>Win 95+</td>
                            <td class="center">4</td>
                        </tr>
                        <tr class="gradeC">
                            <td class="aligncenter"><span class="center">
                                <input type="checkbox" />
                            </span></td>
                            <td>Trident</td>
                            <td>Internet Explorer 5.0</td>
                            <td>Win 95+</td>
                            <td class="center">5</td>
                        </tr>
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
