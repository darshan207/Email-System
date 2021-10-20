<%@ Page Title="Compose-Mail" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Compose.aspx.cs" Inherits="Email_System.Pages.Compose" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <nav class="navbar navbar-light bg-primary">
        <div class="container-fluid justify-content-center">
            <h1 class="text-light">Compose</h1>
        </div>
    </nav>
    <br />
    <table>
        <tr>
            <td style="width: 169px;">To:
            </td>
            <td colspan="2">
                <asp:TextBox ID="Compose_Mail_To" runat="server" Width="800px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 169px;">Subject:
            </td>
            <td colspan="2">
                <asp:TextBox ID="Compose_Mail_Subject" runat="server" Width="800px"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="vertical-align: top; width: 169px;">Body:
            </td>
            <td colspan="2">
                <asp:TextBox ID="Compose_Mail_Body" TextMode="MultiLine" Columns="97" Height="350px" Width="800px" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="vertical-align: top; width: 169px;">Attachment:
            </td>
            <td colspan="2">
                <asp:FileUpload ID="Compose_Mail_File" runat="server" />
            </td>
        </tr>
        <tr>
            <td style="width: 169px"></td>
            <td>
                <asp:Button ID="Compose_Send_Mail" runat="server" Text="Send" Width="150px" OnClick="Compose_Send_Mail_Click" />
                <asp:Button ID="Compose_Delete_Mail" runat="server" Text="Delete" Width="100px" OnClick="Compose_Delete_Mail_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
