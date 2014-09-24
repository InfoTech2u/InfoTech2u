<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cryptography.aspx.cs" Inherits="InfoTech2u.Verithus.WEB.Cryptography" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td>database</td>
                    <td><asp:TextBox runat="server" ID="txtdatabase" Width="500" /></td>
                    <td><asp:Label runat="server" ID="lbldatabaseResultado" /></td>
                </tr>
                <tr>
                    <td>server</td>
                    <td><asp:TextBox runat="server" ID="txtserver" Width="500" /></td>
                    <td><asp:Label runat="server" ID="lblserverResultado" /></td>
                </tr>
                <tr>
                    <td>user</td>
                    <td><asp:TextBox runat="server" ID="txtuser" Width="500" /></td>
                    <td><asp:Label runat="server" ID="lbluserResultado" /></td>
                </tr>
                <tr>
                    <td>password</td>
                    <td><asp:TextBox runat="server" ID="txtpassword" Width="500" /></td>
                    <td><asp:Label runat="server" ID="lblpasswordResultado" /></td>
                </tr>
                <tr>
                    <td colspan="3"><asp:TextBox TextMode="MultiLine" runat="server" ID="txtXmlDatabase" /></td>
                </tr>
                <tr >
                    <td colspan="3">
                        <asp:Button runat="server" ID="btnEncrypt" Text="Encrypt" OnClick="btnEncrypt_Click" />
                        <asp:Button runat="server" ID="btnDecrypt" Text="Decrypt" OnClick="btnDecrypt_Click" />
                        <asp:Button runat="server" ID="btnLimpar" Text="Limpar" OnClick="btnLimpar_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
