using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShopping.App_Code
{
    public interface IRepositoryDataAuthentication
    {
        #region Method for Validating user
        object ValidUser(string userName, string password);
        #endregion
    }
}
