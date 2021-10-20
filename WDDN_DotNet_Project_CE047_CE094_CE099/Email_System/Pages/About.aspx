<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="Email_System.Pages.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <nav class="navbar navbar-light bg-primary">
        <div class="container-fluid justify-content-center">
            <h1 class="text-light">About</h1>
        </div>
    </nav>

    <nav class="navbar navbar-light bg-light" style="overflow: scroll">
        <div class="container-fluid ">
            <img src="/Images/college.png" class="rounded float-start w-25 ">
            <div>
                <h2>Dharmsinh Desai University,Nadiad</h2>
                <h3>Computer Engineering Department</h3>
            </div>
        </div>
    </nav>

    <nav class="navbar navbar-light bg-secondary">
        <div class="container-fluid justify-content-lg-center">
            <h2 class="text-light">Contributors</h2>
        </div>

        <hr class="w-100 bg-dark">

        <div class="container-fluid justify-content-between">
            <div class="card" style="width: 18rem;">
                <img src="/Images/email1.png" class="card-img-top" style="height: 200px">
                <div class="card-body">
                    <h5 class="card-title">Parmar Darshan</h5>
                    <p class="card-text">Sem-5</p>
                </div>
            </div>

            <div class="card" style="width: 18rem;">
                <img src="/Images/email2.png" class="card-img-top" style="height: 200px">
                <div class="card-body">
                    <h5 class="card-title">Padaliya Ronak</h5>
                    <p class="card-text">Sem-5</p>
                </div>
            </div>

            <div class="card" style="width: 18rem;">
                <img src="/Images/email3.jpg" class="card-img-top" style="height: 200px">
                <div class="card-body">
                    <h5 class="card-title">Gohel Chandresh</h5>
                    <p class="card-text">Sem-5</p>
                </div>
            </div>
        </div>
    </nav>
</asp:Content>
