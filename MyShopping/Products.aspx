<%@ Page Title="" Language="C#" MasterPageFile="~/ShoppingMasterPage.Master" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="MyShopping.Products" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <div class="col-xs-12">
        <table border="1">
            <tr>
                <td style="text-align: center;">
                    <b>
                        <asp:Label ID="TableName" runat="server"></asp:Label></b>
                </td>
            </tr>
            <tr>
                <td>
                    <form id="GridViewContainer" runat="server">
                        <asp:GridView ID="ProductsGridView" runat="server" CellPadding="3" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellSpacing="2" OnRowCommand="ProductsGridView_RowCommand" DataKeyNames="ProductID">
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="SelectedLinkButton" runat="server" CommandName="SelectedRow">View</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:HyperLinkField NavigateUrl="#" Text="Edit" />
                                <asp:HyperLinkField NavigateUrl="#" Text="Delete" />
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
                    </form>
                </td>
            </tr>
        </table>
    </div>
    <!--<asp:Label ID="SelectedRow" runat="server"></asp:Label>-->
</asp:Content>
