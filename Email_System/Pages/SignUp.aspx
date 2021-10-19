<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="Email_System.Pages.SignUp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SignUp</title>
    <link rel="stylesheet" href="../Content/login.css" />
    <link rel="stylesheet" href="../Content/bootstrap.css" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous"/>
</head>
<body>
        <div class="login-box">
          <h2>SignUp</h2>
          <form runat="server">

            <div class="user-box">
                <asp:TextBox ID="username" runat="server" class="input" placeholder="UserName"/>
                        <asp:RequiredFieldValidator ForeColor="Red" Font-Size="Medium" ControlToValidate="username" ID="RequiredFieldValidator1" runat="server" ErrorMessage="UserName must be required!"></asp:RequiredFieldValidator>
                        <br />
                        <asp:Label ID="UserIsExistError" ForeColor="Red" Font-Size="Medium" runat="server" Text=""></asp:Label>
                <label>Username</label>
            </div>
            <br />
            <div class="inlineTextBox">
                <div class="user-box">
                    <asp:TextBox ID="fname" runat="server" class="input" placeholder="FirstName"/>
                            <asp:RequiredFieldValidator ForeColor="Red" Font-Size="Medium" ControlToValidate="fname" ID="RequiredFieldValidator4" runat="server" ErrorMessage="FirstName must be required!"></asp:RequiredFieldValidator>
                    <label>Firstname</label>
                </div>
                <div class="user-box">
                    <asp:TextBox ID="lname" runat="server" class="input" placeholder="LastName"/>
                            <asp:RequiredFieldValidator ForeColor="Red" Font-Size="Medium" ControlToValidate="lname" ID="RequiredFieldValidator5" runat="server" ErrorMessage="LastName must be required!"></asp:RequiredFieldValidator>
                    <label>LastName</label>
                </div>
            </div>
            <br />                     
            <div class="user-box">
                <asp:TextBox  ID="dob" TextMode="Date" runat="server" class="input" placeholder="Date Of Birth"/>
                        <asp:RequiredFieldValidator ForeColor="Red" Font-Size="Medium" ControlToValidate="dob" ID="RequiredFieldValidator6" runat="server" ErrorMessage="DOB must be required!"></asp:RequiredFieldValidator>
                <label>Date Of Birth</label>
            </div>
            <br />
            <div class="inlineTextBox">
                <div class="user-box">
                    <asp:TextBox ID="password" runat="server" type="password" class="input" placeholder="Password"/>
                            <asp:RequiredFieldValidator ForeColor="Red" Font-Size="Medium" ControlToValidate="password" ID="RequiredFieldValidator2" runat="server" ErrorMessage="PassWord must be required!"></asp:RequiredFieldValidator>
                    <label>Password</label>
                </div>
                <div class="user-box">
                    <asp:TextBox ID="c_password" runat="server" type="password" class="input" placeholder="Confirm Password"/>
                            <asp:RequiredFieldValidator ForeColor="Red" Font-Size="Medium" ControlToValidate="c_password" ID="RequiredFieldValidator3" runat="server" ErrorMessage="Confirm Password must be required!"></asp:RequiredFieldValidator>
                            <br />
                            <asp:CompareValidator ForeColor="Red" Font-Size="Medium" ID="CompareValidator1" ControlToValidate="password" ControlToCompare="c_password" runat="server" ErrorMessage="Passwords are not match !"></asp:CompareValidator>
                    <label>Confirm Password</label>
                </div>
            </div>

              <div class="d-flex bd-highlight mb-3">
                <div class="mr-auto p-2 bd-highlight">
                    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="Signup_Click">
                        <span></span>
                        <span></span>
                        <span></span>
                        <span></span>
                        SignUp
                    </asp:LinkButton>
                </div>
                <div class="p-2 bd-highlight">
                    <asp:HyperLink ID="login" runat="server" ForeColor="White" NavigateUrl="~/Pages/Login.aspx">Login</asp:HyperLink>
                </div>
            </div>
          </form>
        </div>
</body>
</html>
