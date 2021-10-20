<%@ Page Title="Login" Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Email_System.Pages.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <link rel="stylesheet" href="../Content/login.css" />
    <link rel="stylesheet" href="../Content/bootstrap.css" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous" />
</head>
<body>
    <div class="login-box">
        <h2>Login</h2>
        <form runat="server">

            <div class="user-box">
                <asp:TextBox ID="Uname" runat="server" class="input" placeholder="UserName" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ForeColor="Red" Font-Size="Medium" ControlToValidate="Uname" runat="server" ErrorMessage="UserName must be required !"></asp:RequiredFieldValidator>
                <br />
                <asp:Label ID="UserNotExistError" ForeColor="Red" runat="server" Text="" Font-Size="Medium"></asp:Label>
                <label>Username</label>
            </div>
            <br />
            <div class="user-box">
                <asp:TextBox ID="Pass" runat="server" type="password" class="input" placeholder="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ForeColor="Red" Font-Size="Medium" ControlToValidate="Pass" runat="server" ErrorMessage="Password must be Required !"></asp:RequiredFieldValidator>
                <br />
                <asp:Label ID="LoginFailed" runat="server" ForeColor="Red" Font-Size="Medium" Text=""></asp:Label>
                <label>Password</label>
            </div>

            <div class="d-flex bd-highlight mb-3">
                <div class="mr-auto p-2 bd-highlight">
                    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="Login_Click">
                        <span></span>
                        <span></span>
                        <span></span>
                        <span></span>
                        Login
                    </asp:LinkButton>
                </div>
                <div class="p-2 bd-highlight">
                    <asp:HyperLink ID="signup" runat="server" ForeColor="White" NavigateUrl="~/Pages/SignUp.aspx">SignUp</asp:HyperLink>
                </div>
            </div>
        </form>
    </div>
</body>
</html>
