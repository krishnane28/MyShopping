<%@ Page Title="" Language="C#" MasterPageFile="~/ShoppingMasterPage.Master" AutoEventWireup="true" CodeBehind="AddToCart.aspx.cs" Inherits="MyShopping.AddToCart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <div class="col-xs-12">
        <form id="AddToCart" runat="server">
            <asp:Button ID="DeleteFromCart" runat="server" Text="Delete from Cart" />
            <asp:Button ID="CheckOut" runat="server" Text="Check Out" />
        </form>
    </div>
</asp:Content>
