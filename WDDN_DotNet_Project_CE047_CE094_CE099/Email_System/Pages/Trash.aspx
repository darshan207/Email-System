<%@ Page Title="Trash Mail" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Trash.aspx.cs" Inherits="Email_System.Pages.Trash" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <nav class="navbar navbar-light bg-primary">
        <div class="container-fluid justify-content-center">
            <h1 class="text-light">Trash</h1>
        </div>
    </nav>
    <br />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="SqlDataSource1" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" Width="100%">
        <Columns>
            <asp:BoundField DataField="EMailSubject" HeaderText="Mail Subject" SortExpression="EMailSubject" />
            <asp:BoundField DataField="FromUserEmailId" HeaderText="From" SortExpression="FromUserEmailId" />
            <asp:BoundField DataField="ToUserEmailId" HeaderText="To" SortExpression="ToUserEmailId" />
            <asp:BoundField DataField="AttachmentName" HeaderText="Attachment" SortExpression="AttachmentName" />
            <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:LinkButton runat="server" ID="ViewMail"
                        CommandArgument='<%# Eval("Id") %>' OnClick="ViewMail_Click"
                        Text="View Mail"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:LinkButton BorderColor="Black" runat="server" ID="StarMail"
                        CommandArgument='<%#Eval("Id")%>' OnClick="StarMail_Click" ToolTip="Star Mail"
                        OnClientClick="return confirmationStar();">
                        <i class="fas fa-star"></i></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:LinkButton BorderColor="Black" runat="server" ID="RestoreMail"
                        CommandArgument='<%#Eval("Id")%>' OnClick="RestoreMail_Click" ToolTip="Restore Mail"
                        OnClientClick="return confirmationRestore();">
                        <i class="fas fa-trash-restore"></i></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
        <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
        <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F7F7F7" />
        <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
        <SortedDescendingCellStyle BackColor="#E5E5E5" />
        <SortedDescendingHeaderStyle BackColor="#242121" />
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:emaildb %>" SelectCommand="SELECT [Id], [EMailSubject], [Is_Sent], [Is_Inbox], [Is_FromUser_Starred], [Is_ToUser_Starred], [Is_FromUser_Delete], [Is_ToUser_Delete], [AttachmentName], [FromUserEmailId], [ToUserEmailId] FROM [Emails] WHERE ((([FromUserEmailId] = @FromUserEmailId) AND ([Is_FromUser_Delete] = @Is_FromUser_Delete)) OR (([ToUserEmailId] = @ToUserEmailId) AND ([Is_ToUser_Delete] = @Is_ToUser_Delete))) ORDER BY [Id] DESC">
        <SelectParameters>
            <asp:SessionParameter Name="FromUserEmailId" SessionField="email" Type="String" />
            <asp:Parameter DefaultValue="True" Name="Is_FromUser_Delete" Type="Boolean" />
            <asp:SessionParameter Name="ToUserEmailId" SessionField="email" Type="String" />
            <asp:Parameter DefaultValue="True" Name="Is_ToUser_Delete" Type="Boolean" />
        </SelectParameters>
    </asp:SqlDataSource>
    <script type="text/javascript">
        function confirmationRestore() {
            var answer = confirm("Are you shure to restore mail? ")
            if (answer) {
                return true;
            }
            else {
                return false;
            }
        }
        function confirmationStar() {
            var answer = confirm("Are you shure to restore and starred this mail? ")
            if (answer) {
                return true;
            }
            else {
                return false;
            }
        }
    </script>
</asp:Content>
