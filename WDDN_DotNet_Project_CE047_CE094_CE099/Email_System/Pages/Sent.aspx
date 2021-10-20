<%@ Page Title="Sent Mail" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Sent.aspx.cs" Inherits="Email_System.Pages.Sent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <nav class="navbar navbar-light bg-primary">
        <div class="container-fluid justify-content-center">
            <h1 class="text-light">Sent</h1>
        </div>
    </nav>
    <br />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataKeyNames="Id" DataSourceID="SqlDataSource1" ForeColor="Black" GridLines="Horizontal" Width="100%">
        <Columns>
            <asp:BoundField DataField="EMailSubject" HeaderText="Mail Subject" SortExpression="EMailSubject" />
            <asp:BoundField DataField="ToUserEmailId" HeaderText="To" SortExpression="ToUserEmailId" />
            <asp:BoundField DataField="AttachmentName" HeaderText="Attachment" SortExpression="AttachmentName" />
            <asp:BoundField DataField="Is_FromUser_Starred" HeaderText="Mail Starred" SortExpression="Is_FromUser_Starred" />
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
                        CommandArgument='<%#Eval("Id")%>' OnClick="StarMail_Click" ToolTip="Star Mail">
                        <i class="fas fa-star"></i></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:LinkButton BorderColor="Black" runat="server" ID="DeleteMail"
                        CommandArgument='<%#Eval("Id")%>' OnClick="DeleteMail_Click" ToolTip="Delete Mail"
                        OnClientClick="return confirmation();">
                        <i class="fas fa-trash"></i></asp:LinkButton>
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
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:emaildb %>" SelectCommand="SELECT [Id], [EMailSubject], [Is_Inbox], [Is_Sent], [Is_ToUser_Starred], [Is_FromUser_Starred], [Is_FromUser_Delete], [AttachmentName], [ToUserEmailId], [FromUserEmailId], [Is_ToUser_Delete] FROM [Emails] WHERE (([FromUserEmailId] = @FromUserEmailId) AND ([Is_Sent] = @Is_Sent)) ORDER BY [Id] DESC">
        <SelectParameters>
            <asp:SessionParameter Name="FromUserEmailId" SessionField="email" Type="String" />
            <asp:Parameter DefaultValue="True" Name="Is_Sent" Type="Boolean" />
        </SelectParameters>
    </asp:SqlDataSource>
    <script type="text/javascript">
        function confirmation() {
            var answer = confirm("Are you shure to delete mail?")
            if (answer) {
                return true;
            }
            else {
                return false;
            }
        }
    </script>

</asp:Content>
