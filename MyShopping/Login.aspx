<%@ Page Title="" Language="C#" MasterPageFile="~/ShoppingMasterPage.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="MyShopping.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <!-- Content Pages are associated with the master page using MasterPageFile 
         attribute of page directive-->
    <!-- Bootstrap provide three forms layout - vertical form(default), inline form
         and Horizontal form-->
    <div class="col-xs-10 col-sm-4 col-md-4 col-lg-4">
        <form id="form1" runat="server">
            <h1 style="text-align: center">Login</h1>
            <div class="form-group">
                <label for="TxtUsername">User Name</label>
                <div class="input-group input-group-lg">
                    <span class="input-group-addon">
                        <span class="glyphicon glyphicon-asterisk"></span>
                    </span>
                    <asp:TextBox ID="TxtUsername" runat="server" CssClass="form-control" OnTextChanged="TxtUsername_TextChanged"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <label for="TxtPassword">Password</label>
                <div class="input-group input-group-lg">
                    <span class="input-group-addon">
                        <span class="glyphicon glyphicon-asterisk"></span>
                    </span>
                    <asp:TextBox ID="TxtPassword" runat="server" CssClass="form-control" TextMode="Password" OnTextChanged="TxtPassword_TextChanged"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <asp:Button ID="LoginButton" runat="server" Text="Login" class="btn-primary" OnClick="LoginButton_Click" />
            </div>
            <asp:HyperLink ID="NewUser" runat="server" NavigateUrl="#">New User?</asp:HyperLink>
            &nbsp;&nbsp;
            <asp:HyperLink ID="ForgotPassword" runat="server" NavigateUrl="#">Forgot Password?</asp:HyperLink>
            <asp:Label ID="Message" runat="server"></asp:Label>
        </form>
    </div>
</asp:Content>
