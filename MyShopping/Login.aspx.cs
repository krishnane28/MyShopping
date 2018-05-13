using MyShopping.App_Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyShopping
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.Browser.Cookies)
                {
                    if (Request.QueryString["CheckCookie"] == null)
                    {
                        HttpCookie testCookie = new HttpCookie("Test", "1");
                        Response.Cookies.Add(testCookie);
                        Response.Redirect("Login.aspx?CheckCookie=1");
                    }
                    else
                    {
                        HttpCookie testCookie = Request.Cookies["Test"];
                        if(testCookie == null)
                        {
                            Message.Text = "Cookies are disabled in your browser. Please enable it";
                            LoginButton.Enabled = false;
                        }
                        else
                        {
                            Message.Text = "";
                            LoginButton.Enabled = true;
                        }
                    }

                }
                else
                {
                    Message.Text = "Your browser does not support cookies. Please install the latest version";
                    LoginButton.Enabled = false;
                }
            }
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            IBusinessDataAuthentication _IBusinessDataAuthentication = GenericFactory<BusinessLayer, IBusinessDataAuthentication>.CreateInstance();
            IBusinessDataAccount _IBusinessDataAccount = GenericFactory<BusinessLayer, IBusinessDataAccount>.CreateInstance();
            try
            {
                string userName = (string)_IBusinessDataAuthentication.ValidUser(TxtUsername.Text, TxtPassword.Text);
                if (userName != null)
                {
                    Message.Text = "";
                    SessionFacade.USERROLE = (string)_IBusinessDataAccount.GetUserRole(userName);
                    //if(SessionFacade.USERROLE == "Admin")
                    //{
                    //    ((ShoppingMasterPage)Master).AddProductLink.Visible = true;
                    //    ((ShoppingMasterPage)Master).UploadImageLink.Visible = true;
                    //}
                    SessionFacade.USERNAME = userName;
                    if (SessionFacade.PAGEREQUESTED != null)
                    {
                        Response.Redirect(SessionFacade.PAGEREQUESTED);
                    }
                    else
                    {
                        Response.Redirect("Home.aspx");
                    }
                }
                else
                {
                    Message.Text = "Enter Valid Credentials";
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        protected void TxtUsername_TextChanged(object sender, EventArgs e)
        {
            Message.Text = " ";
        }

        protected void TxtPassword_TextChanged(object sender, EventArgs e)
        {
            Message.Text = " ";
        }
    }
}