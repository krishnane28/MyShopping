using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyShopping
{
    public partial class PayPalTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //form1.
            item_name.Value = "Mp3 Player";
            //ItemHidden.Attributes.Add("name", "item_name");
        }
    }
}