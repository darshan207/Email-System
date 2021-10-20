<%@ Page Title="Profile" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Profile.aspx.cs" Inherits="Email_System.Pages.Profile" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="stylesheet" href="../Content/profile.css" />

    <nav class="navbar navbar-light bg-primary">
        <div class="container-fluid justify-content-center">
            <h1 class="text-light">Profile</h1>
        </div>
    </nav>

    <div>
        <div class="container emp-profile">
            <div class="row">
                <div class="col-md-4">
                    <div class="profile-img">
                        <img src="/Images/User.png" alt="" />
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="profile-head">
                        <h5>
                            <asp:Label ID="uname" runat="server" Text=""></asp:Label>
                        </h5>
                        <h6>
                            <asp:Label ID="email" runat="server" Text=""></asp:Label>
                        </h6>
                        <ul class="nav nav-tabs" id="myTab" role="tablist">
                            <li class="nav-item">
                                <a class="nav-link active" id="home-tab" data-toggle="tab" href="#home" role="tab" aria-controls="home" aria-selected="true">About</a>
                            </li>
                            <li class="nav-item">
                                <a class="nav-link" id="profile-tab" data-toggle="tab" href="#profile" role="tab" aria-controls="profile" aria-selected="false">Reset-PassWord</a>
                            </li>
                        </ul>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-4">
                </div>
                <div class="col-md-8">
                    <div class="tab-content profile-tab" id="myTabContent">
                        <div class="tab-pane fade show active" id="home" role="tabpanel" aria-labelledby="home-tab">
                            <div class="row">
                                <div class="col-md-6">
                                    <label>User Id</label>
                                </div>
                                <div class="col-md-6">
                                    <asp:Label ID="userid" runat="server" Text=""></asp:Label>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6">
                                    <label>First Name</label>
                                </div>
                                <div class="col-md-6">
                                    <asp:Label ID="fname" runat="server" Text=""></asp:Label>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6">
                                    <label>Last Name</label>
                                </div>
                                <div class="col-md-6">
                                    <asp:Label ID="lname" runat="server" Text=""></asp:Label>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6">
                                    <label>Date Of Birth</label>
                                </div>
                                <div class="col-md-6">
                                    <asp:Label ID="dob" runat="server" Text=""></asp:Label>
                                </div>
                            </div>
                        </div>
                        <div class="tab-pane fade" id="profile" role="tabpanel" aria-labelledby="profile-tab">
                            <div class="row">
                                <div class="col-md-6">
                                    <label>PassWord</label>
                                </div>
                                <div class="col-md-6">
                                    <asp:TextBox ID="password" runat="server" type="password" class="input" placeholder="Password" />
                                    <br />
                                    <asp:RequiredFieldValidator ForeColor="Red" Font-Size="Medium" ControlToValidate="password" ID="RequiredFieldValidator2" runat="server" ErrorMessage="PassWord must be required!"></asp:RequiredFieldValidator>
                                    <br />
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2"
                                        runat="server"
                                        ForeColor="Red" Font-Size="Medium"
                                        ErrorMessage="Like 8-10 length atleat one aphabet and numeric character"
                                        ValidationExpression="(?!^[0-9]*$)(?!^[a-zA-Z]*$)^([a-zA-Z0-9]{8,10})$"
                                        ControlToValidate="password">
                                    </asp:RegularExpressionValidator>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6">
                                    <label>Confirm Password</label>
                                </div>
                                <div class="col-md-6">
                                    <asp:TextBox ID="c_password" runat="server" type="password" class="input" placeholder="Confirm Password" />
                                    <br />
                                    <asp:RequiredFieldValidator ForeColor="Red" Font-Size="Medium" ControlToValidate="c_password" ID="RequiredFieldValidator3" runat="server" ErrorMessage="Confirm Password must be required!"></asp:RequiredFieldValidator>
                                    <br />
                                    <asp:CompareValidator ForeColor="Red" Font-Size="Medium" ID="CompareValidator1" ControlToValidate="password" ControlToCompare="c_password" runat="server" ErrorMessage="Passwords are not match !"></asp:CompareValidator>
                                    <br />
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1"
                                        runat="server"
                                        ErrorMessage="RegularExpressionValidator"
                                        ValidationExpression="(?!^[0-9]*$)(?!^[a-zA-Z]*$)^([a-zA-Z0-9]{8,10})$"
                                        ControlToValidate="c_password">
                                    </asp:RegularExpressionValidator>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6">
                                    <label></label>
                                </div>
                                <div class="col-md-6">
                                    <asp:Button ID="pass_submit" class="btn btn-primary" OnClick="passChange_Click" runat="server" Text="Change" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
