using MyShopping.App_Code;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace MyShopping
{
    public partial class ViewCart : System.Web.UI.Page
    {
        private DataSet cartDataSet = null;
        private decimal totalPriceToPay = 0;
        private string totalItems = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (SessionFacade.USERNAME == null)
            {
                SessionFacade.PAGEREQUESTED = Request.ServerVariables["SCRIPT_NAME"];
                Response.Redirect("Login.aspx");
            }
            else
            {
                IBusinessDataAccount _IBusinessDataAccount = GenericFactory<BusinessLayer, IBusinessDataAccount>.CreateInstance();
                cartDataSet = _IBusinessDataAccount.ViewCart(SessionFacade.USERNAME);
                // Not working - ask doubt
                if (cartDataSet.Tables.Count == 0)
                {
                    Message.Text = "You haven't added items to the cart";
                }
                else
                {
                    Message.Text = null;
                    foreach (DataTable tables in cartDataSet.Tables)
                    {
                        foreach (DataRow dataRow in tables.Rows)
                        {
                            totalPriceToPay += Convert.ToDecimal(dataRow["Price"]);
                            totalItems += (dataRow["ProductSmallDescription"] + " ");
                        }
                    }
                    //Message.Text = "Total amount to pay : " + totalPriceToPay + " and the products bought are : " + totalItems;
                    CartGridView.DataSource = cartDataSet;
                    CartGridView.DataBind();
                }
            }
        }

        protected void CartGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "DeleteItemFromCart")
            {
                int selectedRow = ((GridViewRow)((LinkButton)e.CommandSource).NamingContainer).RowIndex;
                //CartGridView.SelectRow(selectedRow);
                int PID = Convert.ToInt32(CartGridView.DataKeys[selectedRow].Values[0]);
                string userName = (string)CartGridView.DataKeys[selectedRow].Values[1];
                int quantity = Convert.ToInt32(CartGridView.DataKeys[selectedRow].Values[2]);
                IBusinessDataAccount _IBusinessDataAccount = GenericFactory<BusinessLayer, IBusinessDataAccount>.CreateInstance();
                if (_IBusinessDataAccount.DeleteCartUpdProducts(PID, userName, quantity))
                {
                    Message.Text = "Item successfully deleted from the cart and the database is updated";
                    Response.Redirect("ViewCart.aspx");
                }
                else
                {
                    Message.Text = "Not deleted from the cart. Please try again later";
                }
            }
        }

        protected void Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }

        protected void BuyUsingPaypal_Click(object sender, EventArgs e)
        {
            string url = "Paypal.aspx?Products=" + totalItems + "&TotalPrice=" + totalPriceToPay;
            Response.Redirect(url);
        }
    }
}