using MyShopping.App_Code;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyShopping
{
    public partial class ViewProducts : System.Web.UI.Page
    {
        private decimal itemPrice = 0;
        private DataSet productsDataSet = null;
        private DataTable productsDataTable = null;
        private DataRow productsRow = null;
        private int PID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            //Quantity.Items.Clear();
            int InStockValue = 0;
            if (SessionFacade.USERNAME == null)
            {
                SessionFacade.PAGEREQUESTED = Request.ServerVariables["HTTP_URL"];
                Response.Redirect("Login.aspx");
            }
            else
            {
                PID = Convert.ToInt32(Request.QueryString["ProductID"]);
                IBusinessDataAccount _IBusinessDataAccount = GenericFactory<BusinessLayer, IBusinessDataAccount>.CreateInstance();
                productsDataSet = _IBusinessDataAccount.GetProductsByPID(PID);
                productsDataTable = productsDataSet.Tables[0];
                productsRow = productsDataTable.Rows[0];
                PSmallDesc.Text = (string)productsRow["ProductSmallDescription"];
                PLargeDesc.Text = (string)productsRow["ProductLargeDescription"];
                PImage.Text = (string)productsRow["ProductImage"];
                itemPrice = Convert.ToDecimal(productsRow["Price"]);
                Price.Text = Convert.ToString(productsRow["Price"]);
                InStockValue = Convert.ToInt32(productsRow["Inventory"]);
                InStock.Text = Convert.ToString(productsRow["Instock"]);
                if (InStockValue == 0)
                {
                    Message.Text = "You cannot purchase this item at the moment";
                    Quantity.Visible = false;
                    QuantityLable.Visible = false;
                    AddInCart.Visible = false;
                    BuyNow.Visible = false;
                }
                else
                {
                    Message.Text = null;
                    AddInCart.Visible = true;
                    Quantity.Visible = true;
                    QuantityLable.Visible = true;
                    BuyNow.Visible = true;
                    if (!IsPostBack)
                    {
                        string items = null;
                        ListItem listItem = null;
                        for (int i = 1; i <= InStockValue; i++)
                        {
                            if (i == 1)
                            {
                                listItem = new ListItem("Select Quantity", "-1");
                                Quantity.Items.Add(listItem);
                            }
                            items = Convert.ToString(i);
                            listItem = new ListItem(items, items);
                            Quantity.Items.Add(listItem);
                        }
                    }
                }
            }
        }

        protected void AddInCart_Click(object sender, EventArgs e)
        {
            decimal amountToBePaid = 0;
            int selectedItemValue = 0;
            int updateQuantity = 0;
            if (Quantity.SelectedValue == "-1")
            {
                Message.Text = "Please select a quantity";
            }
            else
            {
                selectedItemValue = Convert.ToInt32(Quantity.SelectedValue);
                updateQuantity = (Convert.ToInt32(productsRow["Inventory"])) - selectedItemValue;
                amountToBePaid = (itemPrice * selectedItemValue);
                IBusinessDataAccount _IBusinessDataAccount = GenericFactory<BusinessLayer, IBusinessDataAccount>.CreateInstance();
                if(_IBusinessDataAccount.UpdateProducts(PID, updateQuantity))
                {
                    UpdateMessage.Text = "Database has been updated";
                }
                else
                {
                    UpdateMessage.Text = null;
                }
                if (_IBusinessDataAccount.AddToCart(SessionFacade.USERNAME, PID, (string)productsRow["ProductSmallDescription"], selectedItemValue, amountToBePaid) == 1)
                {
                    Message.Text = "Your item has been added to the shopping cart to buy it later";
                }
                else
                {
                    Message.Text = "Items are not added";
                }

            }
        }

        protected void BuyNow_Click(object sender, EventArgs e)
        {

        }

        protected void BackToPreviousPage_Click(object sender, EventArgs e)
        {
            Response.Redirect(SessionFacade.PAGEREQUESTED);
        }
    }
}