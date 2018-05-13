<%@ Page Title="" Language="C#" MasterPageFile="~/ShoppingMasterPage.Master" AutoEventWireup="true" CodeBehind="ViewProducts.aspx.cs" Inherits="MyShopping.ViewProducts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <div class="col-xs-12">
        <h1 style="text-align: center">Product Details</h1>
        <span><b>Product Small Description : </b>&nbsp;<asp:Label ID="PSmallDesc" runat="server"></asp:Label></span>
        <br />
        <br />
        <span><b>Product Large Description : </b>&nbsp;<asp:Label ID="PLargeDesc" runat="server"></asp:Label></span>
        <br />
        <br />
        <span><b>Product Image : </b>&nbsp;<asp:Label ID="PImage" runat="server"></asp:Label></span>
        <br />
        <br />
        <span><b>Price : </b>&nbsp;<asp:Label ID="Price" runat="server"></asp:Label></span>
        <br />
        <br />
        <span><b>In Stock : </b>&nbsp;<asp:Label ID="InStock" runat="server"></asp:Label></span>
        <br />
        <br />
        <asp:Label ID="UpdateMessage" runat="server"></asp:Label>
        <br />
        <br />
        <form id="QuantityForm" runat="server">
            <b id="QuantityLable" runat="server">Quantity : </b>
            <asp:DropDownList ID="Quantity" runat="server"></asp:DropDownList>
            <br />
            <br />
            <asp:Button ID="AddInCart" runat="server" Text="Add to Cart to buy later" OnClick="AddInCart_Click" />
            &nbsp;&nbsp;
            <asp:Button ID="BuyNow" runat="server" Text="Buy Now" OnClick="BuyNow_Click" />
            &nbsp;&nbsp
            <asp:Button ID="BackToPreviousPage" runat="server" Text="Back" OnClick="BackToPreviousPage_Click" />
        </form>
        <br />
        <asp:Label ID="Message" runat="server"></asp:Label>
    </div>
</asp:Content>
