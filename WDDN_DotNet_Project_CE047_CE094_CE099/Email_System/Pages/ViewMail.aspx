<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewMail.aspx.cs" Inherits="Email_System.Pages.ViewMail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table>
        <tr>
            <td style="width: 169px;">From User:
            </td>
            <td colspan="3">
                <asp:TextBox ID="Mail_From_User" ReadOnly="true" runat="server" Width="800px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 169px;">From Email:
            </td>
            <td colspan="3">
                <asp:TextBox ID="Mail_From_User_Email" ReadOnly="true" runat="server" Width="800px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 169px;">Subject:
            </td>
            <td colspan="3">
                <asp:TextBox ID="Mail_Subject" ReadOnly="true" runat="server" Width="800px"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="vertical-align: top; width: 169px;">Body:
            </td>
            <td colspan="3">
                <asp:TextBox ID="Mail_Body" ReadOnly="true" TextMode="MultiLine" Columns="97" Height="500px" Width="800px" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="vertical-align: top; width: 169px;">Attachment:
            </td>
            <td>
                <asp:TextBox ID="Mail_File" ReadOnly="true" runat="server"></asp:TextBox>
            </td>
            <td colspan="2">
                <asp:Button ID="Download_Mail_File" runat="server" Text="Download" Width="150px" OnClick="Mail_File_Download_Click" />
            </td>
        </tr>
        <tr>
            <td style="width: 169px"></td>
            <td>
                <asp:Button ID="Delete_Mail" runat="server" Text="Delete" Width="100px" OnClick="Delete_Mail_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
