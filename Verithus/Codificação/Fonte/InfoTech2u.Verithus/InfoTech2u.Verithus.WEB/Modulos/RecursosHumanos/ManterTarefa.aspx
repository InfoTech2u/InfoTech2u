<%@ Page Title="" Language="C#" MasterPageFile="~/Modulos/InfoTech2u.Master" AutoEventWireup="true" CodeBehind="ManterTarefa.aspx.cs" Inherits="InfoTech2u.Verithus.WEB.Modulos.RecursosHumanos.ManterTarefa" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderInfoTech2u" runat="server">
    <div class="rightpanel">

       <ul class="breadcrumbs">
            <li><a href="dashboard.html"><i class="iconfa-home"></i></a><span class="separator"></span></li>
            <li><a href="forms.html">Formulario</a> <span class="separator"></span></li>
            <li>Tarefa</li>

        </ul>

        <div class="pageheader">
            <div class="pageicon"><span class="iconfa-pencil"></span></div>
            <div class="pagetitle">
                <h5>Tarefa
                </h5>
                <h1>Fomulário de Tarefa</h1>
            </div>
        </div>
        <!--pageheader-->
        <div class="maincontent">
            <div class="maincontentinner">
                 <asp:HiddenField ID="hdnCodigoFuncionario" runat="server" ClientIDMode="Static"/>
                <div aria-hidden="false" aria-labelledby="myModalLabel" role="dialog" tabindex="-1" class="modal hide fade in" id="myModal">
                    <div class="modal-header widgettitle">
                        <button aria-hidden="true" data-dismiss="modal" class="close" type="button">&times;</button>
                        <h4 class="widgettitle">Dados Tarefa</h4>
                       
                    </div>
                    <div class="modal-body">
                        <div class="widgetbox box-inverse">

                            <div class="par control-group">
                                <label class="control-label" for="txtDescricaoTipoBeneficio">Descrição</label>
                                <div class="controls">
                                    <asp:TextBox runat="server" ID="txtDescricao" class="input-block-level" ClientIDMode="Static" />
                                    <span class="help-inline" id="msgDescricao"></span>
                                </div>
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
                    <a class="btn btn-primary" onclick="javascript:Limpar();" href="#myModal" data-toggle="modal"><i class="iconfa-pencil"></i>&nbsp; Incluir</a>                   
                </div>

                <h4 class="widgettitle">Benefício</h4>
            	<table id="dyntable" class="table table-bordered responsive">
                    <colgroup>
                        <col class="con0" style="align: center; width: 4%" />
                        <col class="con1"  style="align: center; width: 80%" />
                        <col class="con0" />
                    </colgroup>
                    <thead>
                        <tr>
                            <th>Id</th>
                            <th>Descrição</th>
                            <th>Excluir</th
                        </tr>
                    </thead>
                    <tbody>
                       
                       
                    </tbody>
                </table>
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
</asp:Content>
