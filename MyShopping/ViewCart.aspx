<%@ Page Title="" Language="C#" MasterPageFile="~/ShoppingMasterPage.Master" AutoEventWireup="true" CodeBehind="ViewCart.aspx.cs" Inherits="MyShopping.ViewCart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <form id="form1" runat="server">
        <asp:GridView ID="CartGridView" runat="server" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" OnRowCommand="CartGridView_RowCommand" DataKeyNames="ProductID, Username, Quantity">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="DeleteFromCart" runat="server" CommandName="DeleteItemFromCart">Delete Item</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
            <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
            <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
            <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#FFF1D4" />
            <SortedAscendingHeaderStyle BackColor="#B95C30" />
            <SortedDescendingCellStyle BackColor="#F1E5CE" />
            <SortedDescendingHeaderStyle BackColor="#93451F" />
        </asp:GridView>
        <br />
        <asp:Label ID="Message" runat="server"></asp:Label>
        <br />
        <asp:Button ID="Back" runat="server" Text="Back to Home" OnClick="Back_Click" />
        &nbsp;&nbsp;
        <asp:Button ID="BuyUsingPaypal" runat="server" Text="Buy" OnClick="BuyUsingPaypal_Click" />
    </form>
</asp:Content>
