<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="InfoTech2u.Verithus.WEB.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Verithus</title>
    <link rel="stylesheet" href="css/style.default.css" type="text/css" />
    <link rel="stylesheet" href="css/style.shinyblue.css" type="text/css" />

    <script type="text/javascript" src="js/jquery-1.9.1.min.js"></script>
    <script type="text/javascript" src="js/jquery-migrate-1.1.1.min.js"></script>
    <script type="text/javascript" src="js/jquery-ui-1.9.2.min.js"></script>
    <script type="text/javascript" src="js/modernizr.min.js"></script>
    <script type="text/javascript" src="js/bootstrap.min.js"></script>
    <script type="text/javascript" src="js/jquery.alerts.js"></script>
    <script type="text/javascript" src="js/jquery.cookie.js"></script>
    <script type="text/javascript" src="js/custom.js"></script>
    <script type="text/javascript">
        var tipoAcesso;
        jQuery(document).ready(function () {
            jQuery('#btnEntrar').click(function () {
                var u = jQuery('#username').val();
                var p = jQuery('#password').val();
                if (u == '' && p == '') {
                    jQuery('.login-alert').fadeIn();
                    return false;
                }
                else {
                    VerificarUsuario(u, p);


                }

                return false;
            });




        });

        function VerificarUsuario(user, pass) {
            jQuery.ajax({
                type: "GET",
                crossDomain: true,
                url: "Handler/VerificarUsuario.ashx",
                contentType: "json",
                cache: false,
                data: {
                    usuario: user,
                    senha: pass
                },
                success: function (data) {

                    //alert(data);
                    if (data == "Erro") {
                        jQuery.alerts.dialogClass = 'alert-warning';
                        jAlert('O Usuario ou a senha estão incorretos', 'Alerta', function () {
                            jQuery.alerts.dialogClass = null; // reset to default
                        });
                    }

                    var dadosUsuario = eval(data);


                    for (i in dadosUsuario) {

                        //alert(dadosUsuario[i].CODIGO_TIPO_ACESSO);
                        tipoAcesso = dadosUsuario[i].CODIGO_TIPO_ACESSO;
                        redirecionar();



                    }



                },
                error: function (XMLHttpRequest, textStatus, errorThrow) {
                    errorAjax(textStatus);
                    alert(textStatus);
                }
            });
        }

        function redirecionar() {
           // alert('Teste' + tipoAcesso);
            jQuery(window.document.location).attr('href', 'Modulos/Default.aspx');
        }

    </script>
</head>
<body class="loginpage">
    <div class="loginpanel">
        <div class="loginpanelinner">
            <div class="logo animate0 bounceIn">
                <img src="images/logo.png" alt="" />
            </div>
            <form id="frmInfotech2uLogin" runat="server">
                <div class="inputwrapper login-alert">
                    <div class="alert alert-error">Usuario ou senha Invalidas</div>
                </div>
                <div class="inputwrapper animate1 bounceIn">
                    <input type="text" name="username" id="username" placeholder="Entre com seu Usuario" />
                </div>
                <div class="inputwrapper animate2 bounceIn">
                    <input type="password" name="password" id="password" placeholder="Entre com sua Senha" />
                </div>
                <div class="inputwrapper animate3 bounceIn">
                    <button name="submit" id="btnEntrar" runat="server">Entrar</button>
                </div>
                <div class="inputwrapper animate4 bounceIn">
                    <label>
                        <input type="checkbox" class="remember" name="signin" />
                        Lembrar Senha</label>
                </div>
            </form>
        </div>
        <!--loginpanelinner-->
    </div>
    <!--loginpanel-->

    <div class="loginfooter">
        <p>&copy; 2014. Infotech2u. All Rights Reserved.</p>
    </div>
</body>
</html>
