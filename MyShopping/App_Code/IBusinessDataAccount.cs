using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShopping.App_Code
{
    public interface IBusinessDataAccount
    {
        #region Get User Role
        object GetUserRole(string userName);
        #endregion

        #region Get Products by Category ID
        DataSet ProductsByID(int ID);
        #endregion

        #region Get Products by Product ID
        DataSet GetProductsByPID(int PID);
        #endregion

        #region Add items to shopping cart
        int AddToCart(string userName, int PID, string productSDesc, int itemQuantity, decimal price);
        #endregion

        #region View Shopping Cart
        DataSet ViewCart(string userName);
        #endregion

        #region Update Products Table
        bool UpdateProducts(int PID, int quantity);
        #endregion

        #region Delete from shopping cart and update the database
        bool DeleteCartUpdProducts(int PID, string userName, int quantity);
        #endregion
    }
}
