﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Modulos/InfoTech2u.Master" AutoEventWireup="true" CodeBehind="ManterCargo.aspx.cs" Inherits="InfoTech2u.Verithus.WEB.Modulos.RecursosHumanos.ManterCargo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderInfoTech2u" runat="server">
    <div class="rightpanel">

        <ul class="breadcrumbs">
            <li><a href="dashboard.html"><i class="iconfa-home"></i></a><span class="separator"></span></li>
            <li><a href="forms.html">Forms</a> <span class="separator"></span></li>
            <li>Form Styles</li>

        </ul>

        <div class="pageheader">
            <div class="pageicon"><span class="iconfa-pencil"></span></div>
            <div class="pagetitle">
                <h5>Cargo
                </h5>
                <h1>Fomulário de Cargo</h1>
            </div>
        </div>
        <!--pageheader-->

        <div class="maincontent">
            <div class="maincontentinner">
                <div class="widgetbox box-inverse">
                    <h4 class="widgettitle">Dados Cargo</h4>
                    <div class="widgetcontent nopadding">
                        <div class="stdform stdform2">
                            <p>
                                <label>Descrição</label>
                                <span class="field">
                                    <asp:TextBox runat="server" ID="txtDescricao" class="input-small" ClientIDMode="Static" />
                                </span>
                            </p>

                            <p class="stdformbutton">
                                <a href="#" class="btn btn-primary btn-rounded">Concluir</a>
                                <a href="#" class="btn btn-rounded"><i class="iconfa-refresh iconsweets-black"></i>&nbsp; limpar</a>
                            </p>

                        </div>
                    </div>
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
