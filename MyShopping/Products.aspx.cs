using MyShopping.App_Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyShopping
{
    public partial class Products : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int ID = 0;
            if (SessionFacade.USERNAME == null)
            {
                SessionFacade.PAGEREQUESTED = Request.ServerVariables["HTTP_URL"];
                Response.Redirect("Login.aspx");
            }
            else
            {
                IBusinessDataAccount _IBusinessDataAccount = GenericFactory<BusinessLayer, IBusinessDataAccount>.CreateInstance();
                ID = Convert.ToInt32(Request.QueryString["ID"]);
                if (ID == 10)
                {
                    TableName.Text = "Electronics Products";
                }
                else if (ID == 20)
                {
                    TableName.Text = "Kitchen Products";
                }
                else
                {
                    TableName.Text = "Luggages";
                }
                ProductsGridView.DataSource = _IBusinessDataAccount.ProductsByID(ID);
                ProductsGridView.DataBind();
            }
        }

        protected void ProductsGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName == "SelectedRow")
            {
                int row = ((GridViewRow)((LinkButton)e.CommandSource).NamingContainer).RowIndex;
                ProductsGridView.SelectRow(row);
                int ID = Convert.ToInt32(ProductsGridView.SelectedValue);
                //SelectedRow.Text = "You selected the row with Product ID = " + ID;
                SessionFacade.PAGEREQUESTED = Request.ServerVariables["HTTP_URL"];
                Response.Redirect("ViewProducts.aspx?ProductID=" + ID);
            }
        }
    }
}