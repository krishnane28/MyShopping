using MyShopping.App_Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyShopping
{
    public partial class PayPal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(SessionFacade.USERNAME == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                item_name.Value = Request.QueryString["Products"];
                double totalPrice = Convert.ToDouble(Request.QueryString["TotalPrice"]);
                amount.Value = Convert.ToString(totalPrice);
                //Request.QueryString[]
            }
        }
    }
}