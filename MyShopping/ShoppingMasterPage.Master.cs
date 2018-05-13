using MyShopping.App_Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyShopping
{
    public partial class ShoppingMasterPage : System.Web.UI.MasterPage
    {
        public HyperLink AddProductLink
        {
            get
            {
                return this.AddProduct;
            }
        }

        public HyperLink UploadImageLink
        {
            get
            {
                return this.UploadImage;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (SessionFacade.USERROLE == "Admin")
            {
                AddProduct.Visible = true;
                UploadImage.Visible = true;
            }
            else
            {
                AddProduct.Visible = false;
                UploadImage.Visible = false;
            }
        }
    }
}