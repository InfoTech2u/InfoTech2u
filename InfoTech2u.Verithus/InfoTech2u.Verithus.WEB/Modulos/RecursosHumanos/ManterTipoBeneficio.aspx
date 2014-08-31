﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Modulos/InfoTech2u.Master" AutoEventWireup="true" CodeBehind="ManterTipoBeneficio.aspx.cs" Inherits="InfoTech2u.Verithus.WEB.Modulos.RecursosHumanos.ManterTipoBeneficio" %>
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
                        <h3 id="myModalLabel">Benefício</h3>
                    </div>

                    <div class="modal-body">
                        <div class="widgetbox box-inverse">

                            <div class="par control-group">
                                <label class="control-label" for="nomedependente">Descrição</label>
                                <div class="controls">
                                    <asp:TextBox runat="server" ID="txtDescricaoTipoBeneficio" class="input-block-level" ClientIDMode="Static" />
                                </div>
                            </div>
                            <!--widgetcontent-->
                        </div>
                    </div>

                    <div class="modal-footer">
                        <button data-dismiss="modal" class="btn">&nbsp; Close</button>
                        <button id="btnSaveChanges" class="btn btn-primary"><i class="iconfa-pencil"></i>&nbsp; Save changes</button>
                    </div>
                </div>
                <!--#myModal-->

                <div class="row-fluid">
                    <a class="btn btn-primary" href="#myModal" data-toggle="modal"><i class="iconfa-pencil"></i>&nbsp; Incluir</a>                   
                </div>

                <h4 class="widgettitle">Benefício</h4>
            	<table class="table table-bordered responsive">
                    <thead>
                        <tr>
                            <th>Descrição</th>
                            <th>Alterar</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td>Trident</td>
                            <td class="centeralign"><a href="#myModal" class="deleterow"  data-toggle="modal"><span class=" iconfa-edit"></span></a></td>
                        </tr>
                        <tr>
                            <td>Trident</td>
                            <td class="centeralign"><a href="#myModal" class="deleterow"  data-toggle="modal"><span class="iconfa-edit"></span></a></td>
                        </tr>
                        <tr>
                            <td>Trident</td>
                            <td class="centeralign"><a href="#myModal" class="deleterow"  data-toggle="modal"><span class="iconfa-edit"></span></a></td>
                        </tr>
                        <tr>
                            <td>Trident</td>
                            <td class="centeralign"><a href="#myModal" class="deleterow"  data-toggle="modal"><span class="iconfa-edit"></span></a></td>
                        </tr>
                        <tr>
                            <td>Trident</td>
                            <td class="centeralign"><a href="#myModal" class="deleterow"  data-toggle="modal"><span class="iconfa-edit"></span></a></td>
                        </tr>
                    </tbody>
                </table>
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
</asp:Content>
