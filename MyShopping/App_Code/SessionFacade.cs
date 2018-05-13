using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyShopping.App_Code
{
    public class SessionFacade
    {
        private static readonly string _USERNAME = "USERNAME";
        public static string USERNAME
        {
            get
            {
                string currentUser = null;
                if(HttpContext.Current.Session[_USERNAME] != null)
                {
                    currentUser = (string)HttpContext.Current.Session[_USERNAME];
                }                
                return currentUser;
            }
            set
            {
                HttpContext.Current.Session[_USERNAME] = value;
            }
        }

        private static readonly string _USERROLE = "ROLE";
        public static string USERROLE
        {
            get
            {
                string userRole = null;
                if(HttpContext.Current.Session[_USERROLE] != null)
                {
                    userRole = (string)HttpContext.Current.Session[_USERROLE];
                }
                return userRole;
            }
            set
            {
                HttpContext.Current.Session[_USERROLE] = value;
            }
        }

        private static readonly string _PAGEREQUESTED = "PAGEREQUESTED";
        public static string PAGEREQUESTED
        {
            get
            {
                string requestedPage = null;
                if(HttpContext.Current.Session[_PAGEREQUESTED] != null)
                {
                    requestedPage = (string)HttpContext.Current.Session[_PAGEREQUESTED];
                }
                return requestedPage;
            }
            set
            {
                HttpContext.Current.Session[_PAGEREQUESTED] = value;
            }
        }
    }
}