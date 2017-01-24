<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FcmConfig.aspx.cs" Inherits="FcmDemo.FcmConfig" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
            border: 1px solid #000000;
            border-collapse: collapse;
        }

        .auto-style2 {
            border: 1px solid #000000;
            border-collapse: collapse;
        }

        .auto-style3 {
            width: 230px;
            border: 1px solid #000000;
            border-collapse: collapse;
        }

        .auto-style4 {
            width: 747px;
            border: 1px solid #000000;
            border-collapse: collapse;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div style="width: 1000px; margin-right: auto; margin-left: auto;">
            <asp:Label ID="lblStatus"  Text="" runat="server" />
            <table class="auto-style1">
                <tr>
                    <td class="auto-style2" colspan="2" style="font-family: Arial, Helvetica, sans-serif; font-size: medium; font-weight: bold; text-transform: capitalize; text-decoration: underline; text-align: center;">Firebase Api Config</td>
                </tr>
                <tr>
                    <td class="auto-style3">apiKey</td>
                    <td class="auto-style4">
                        <asp:TextBox ID="lblApiKey" runat="server" Text="Label" Font-Bold="True" Font-Names="Arial Black"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="auto-style3">authDomain</td>
                    <td class="auto-style4">
                        <asp:TextBox ID="lblAuthDomain" runat="server" Text="Label" Font-Bold="True" Font-Names="Arial Black"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="auto-style3">messagingSenderId</td>
                    <td class="auto-style4">
                        <asp:TextBox ID="lblSenderId" runat="server" Text="Label" Font-Bold="True" Font-Names="Arial Black"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="auto-style3">serverKey</td>
                    <td class="auto-style4">
                        <asp:TextBox ID="lblServerKey" runat="server" Text="Label" Font-Bold="True" Font-Names="Arial Black"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style4">
                        <asp:Button ID="btnUpdateConfig" runat="server" Text="Update" OnClick="btnUpdateConfig_Click" /></td>
                </tr>
            </table>

        </div>
    </form>
</body>
</html>
