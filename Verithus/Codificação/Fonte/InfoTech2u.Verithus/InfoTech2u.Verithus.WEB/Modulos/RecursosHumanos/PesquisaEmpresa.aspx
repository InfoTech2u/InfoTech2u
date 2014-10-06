<%@ Page Title="" Language="C#" MasterPageFile="~/Modulos/InfoTech2u.Master" AutoEventWireup="true" CodeBehind="PesquisaEmpresa.aspx.cs" Inherits="InfoTech2u.Verithus.WEB.Modulos.RecursosHumanos.Empresa.PesquisaEmpresa" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderInfoTech2u" runat="server">
    <div class="rightpanel">
        <ul class="breadcrumbs">
            <li><a href="dashboard.html"><i class="iconfa-home"></i></a><span class="separator"></span></li>
            <li><a href="table-static.html">Tables</a> <span class="separator"></span></li>
            <li>Table Dynamic</li>

            <li class="right">
                <a href="" data-toggle="dropdown" class="dropdown-toggle"><i class="icon-tint"></i>Color Skins</a>
                <ul class="dropdown-menu pull-right skin-color">
                    <li><a href="default">Default</a></li>
                    <li><a href="navyblue">Navy Blue</a></li>
                    <li><a href="palegreen">Pale Green</a></li>
                    <li><a href="red">Red</a></li>
                    <li><a href="green">Green</a></li>
                    <li><a href="brown">Brown</a></li>
                </ul>
            </li>
        </ul>
        <div class="pageheader">
            <div class="pageicon"><span class="iconfa-table"></span></div>
            <div class="pagetitle">
                <h5>Tables</h5>
                <h1>Table Dynamic</h1>
            </div>
        </div>
        <!--pageheader-->
        <div class="maincontent">
            <div class="maincontentinner">
                <h4 class="widgettitle">Data Table</h4>
                <table class="table table-bordered responsive" id="example">
                    <thead>
                        <tr>
                            <th>Sequencia</th>
                            <th>Codigo Empresa</th>
                            <th>Nome Empresa</th>
                            <th>CNPJ</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td colspan="5" class="dataTables_empty">Loading data from server</td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>

    </div>
</asp:Content>
