using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShopping.App_Code
{
    public interface IBusinessDataAuthentication
    {
        #region Method for Validating User
        object ValidUser(string userName, string password);
        #endregion 
    }
}
