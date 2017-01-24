<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SendMessage.aspx.cs" Inherits="FcmDemo.SendMessage" %>


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

            <table class="auto-style1">
                <tr>
                    <td class="auto-style2" colspan="2" style="font-family: Arial, Helvetica, sans-serif; font-size: medium; font-weight: bold; text-transform: capitalize; text-decoration: underline; text-align: center;">Firebase Api Config</td>
                </tr>
                <tr>
                    <td class="auto-style3">Message Title</td>
                    <td class="auto-style4">
                        <asp:TextBox ID="txtTitle" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">Body</td>
                    <td class="auto-style4">
                        <asp:TextBox ID="txtBody" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">Click Action</td>
                    <td class="auto-style4">
                        <asp:TextBox ID="txtClickAction" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">Icon Url</td>
                    <td class="auto-style4">
                        <asp:TextBox ID="txtIcon" runat="server" /></td>
                </tr>
                <tr>
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style4">
                        <asp:Button ID="btnSend" runat="server" Text="Send Message" OnClick="btnUpdateConfig_Click" /></td>
                </tr>
                <tr>
                    <td class="auto-style3" colspan="2">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style3" colspan="2">
                        <asp:GridView ID="gvClientTokens" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="dsSqlClientTokens">
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkSelected" runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="Id" />
                                <asp:BoundField DataField="Token" HeaderText="Token" SortExpression="Token" />
                                <asp:BoundField DataField="RawReq" HeaderText="RawReq" SortExpression="RawReq" />
                            </Columns>
                        </asp:GridView>
                        <asp:SqlDataSource ID="dsSqlClientTokens" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnectionString %>" SelectCommand="SELECT * FROM [DtClient]"></asp:SqlDataSource>
                    </td>
                </tr>
            </table>

        </div>
    </form>
</body>
</html>
