<%@ Page Title="" Language="C#" MasterPageFile="~/Modulos/InfoTech2u.Master" AutoEventWireup="true" CodeBehind="PesquisaBeneficios.aspx.cs" Inherits="InfoTech2u.Verithus.WEB.Modulos.RecursosHumanos.Beneficios.PesquisaBeneficios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderInfoTech2u" runat="server">
     <script type="text/javascript">
         jQuery(document).ready(function () {
             // dynamic table
             jQuery('#dyntable').dataTable({
                 "sPaginationType": "full_numbers",
                 "aaSortingFixed": [[0, 'asc']],
                 "fnDrawCallback": function (oSettings) {
                     jQuery.uniform.update();
                 }
             });
         });
    </script>
    <div class="rightpanel">

        <ul class="breadcrumbs">
            <li><a href="Dashboard.aspx"><i class="iconfa-home"></i></a><span class="separator"></span></li>
            <li><a href="Default.aspx">Recursos Humanos</a> <span class="separator"></span></li>
            <li>Dados de Beneficio</li>

        </ul>

        <div class="pageheader">
            <div class="pageicon"><span class="iconfa-pencil"></span></div>
            <div class="pagetitle">
                <h5>Formulário</h5>
                <h1>Beneficios</h1>
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
                                <label>Codigo do Benefício</label>
                                <span class="field">
                                    <asp:TextBox runat="server" ID="txtCodigoBeneficio" class="input-small" ClientIDMode="Static" />
                                </span>
                            </p>

                            <p class="stdformbutton">
                                <a href="#" class="btn btn-primary btn-rounded"><i class="iconsweets-magnifying iconsweets-white"></i>&nbsp; Pesquisar</a>
                                <a href="#" class="btn btn-rounded"><i class="iconfa-refresh iconsweets-black"></i>&nbsp; limpar</a>
                            </p>

                        </div>
                    </div>
                </div>

                 <h4 class="widgettitle">Data Table</h4>
                <table id="dyntable" class="table table-bordered responsive">
                    <colgroup>
                        <col class="con1" />
                    </colgroup>
                    <thead>
                        <tr>
                            <th class="head0">Descrição</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr class="gradeX">
                            <td>Trident</td>
                        </tr>
                       <tr class="gradeX">
                            <td>Trident</td>
                        </tr>
                        <tr class="gradeX">
                            <td>Trident</td>
                        </tr>
                        <tr class="gradeX">
                            <td>Trident</td>
                        </tr>
                        <tr class="gradeX">
                            <td>Trident</td>
                        </tr>
                        <tr class="gradeX">
                            <td>Trident</td>
                        </tr>
                        <tr class="gradeX">
                            <td>Trident</td>
                        </tr>
                        <tr class="gradeX">
                            <td>Trident</td>
                        </tr>
                        <tr class="gradeX">
                            <td>Trident</td>
                        </tr>
                        <tr class="gradeX">
                            <td>Trident</td>
                        </tr>
                        <tr class="gradeX">
                            <td>Trident</td>
                        </tr>
                        <tr class="gradeX">
                            <td>Trident</td>
                        </tr>
                        <tr class="gradeX">
                            <td>Trident</td>
                        </tr>
                    </tbody>
                </table>

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
