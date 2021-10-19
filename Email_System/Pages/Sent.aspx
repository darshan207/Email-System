<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Sent.aspx.cs" Inherits="Email_System.Pages.Sent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    Sent<br />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataKeyNames="Id" DataSourceID="SqlDataSource1" ForeColor="Black" GridLines="Horizontal" Width="100%">
         <Columns>
            <asp:BoundField DataField="EMailSubject" HeaderText="Mail Subject" SortExpression="EMailSubject" />
            <asp:BoundField DataField="FromUserEmailId" HeaderText="From" SortExpression="FromUserEmailId" />
            <asp:BoundField DataField="ToUserEmailId" HeaderText="To" SortExpression="ToUserEmailId" />
            <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:HyperLink runat="server"
                        NavigateUrl='<%# Eval("Id", "ViewMail.aspx?Id={0}") %>'
                        Text="View Mail"></asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:LinkButton BorderColor="Black" runat="server" ID="StarMail"
                        CommandArgument='<%#Eval("Id")%>' OnClick="StarMail_Click">
                        <i class="fas fa-star"></i></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
             <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:LinkButton BorderColor="Black" runat="server" ID="DeleteMail"
                        CommandArgument='<%#Eval("Id")%>' OnClick="DeleteMail_Click">
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
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:emaildb %>" SelectCommand="SELECT [Id], [EMailSubject], [Is_Inbox], [Is_Sent], [Is_ToUser_Starred], [Is_FromUser_Starred], [Is_FromUser_Delete], [ToUserEmailId], [FromUserEmailId], [Is_ToUser_Delete] FROM [Emails] WHERE (([FromUserEmailId] = @FromUserEmailId) AND ([Is_Sent] = @Is_Sent)) ORDER BY [Id] DESC">
        <SelectParameters>
            <asp:SessionParameter Name="FromUserEmailId" SessionField="email" Type="String" />
            <asp:Parameter DefaultValue="True" Name="Is_Sent" Type="Boolean" />
        </SelectParameters>
    </asp:SqlDataSource>
&nbsp;

</asp:Content>
