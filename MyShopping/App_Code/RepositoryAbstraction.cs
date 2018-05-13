using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace MyShopping.App_Code
{
    public class RepositoryAbstraction
    {
        #region IRepositoryDataAuthentication and IRepositoryDataAccount
        IRepositoryDataAuthentication _IRepositoryDataAuthentication = null;
        IRepositoryDataAccount _IRepositoryDataAccount = null;
        #endregion

        #region Constructor for Injection
        public RepositoryAbstraction()
        {
            _IRepositoryDataAuthentication = GenericFactory<RepositorySQL, IRepositoryDataAuthentication>.CreateInstance();
            _IRepositoryDataAccount = GenericFactory<RepositorySQL, IRepositoryDataAccount>.CreateInstance();
        }
        #endregion

        #region IRepositoryDataAuthentication Method 
        #region Method for Validating user
        public object ValidUser(string userName, string password)
        {
            try
            {
                return _IRepositoryDataAuthentication.ValidUser(userName, password);
            }
            catch(Exception exception)
            {
                throw exception;
            }
        }
        #endregion
        #endregion

        #region IRepositoryDataAccount Methods
        #region Get User Role
        public object GetUserRole(string userName)
        {
            try
            {
                return _IRepositoryDataAccount.GetUserRoles(userName);
            }
            catch(Exception exception)
            {
                throw exception;
            }
        }
        #endregion

        #region Get Products by Category ID
        public DataSet ProductListByID(int ID)
        {
            try
            {
                return _IRepositoryDataAccount.ProductListByID(ID);
            }
            catch(Exception exception)
            {
                throw exception;
            }
        }
        #endregion

        #region Get Products by Product ID
        public DataSet GetProductsByPID(int PID)
        {
            try
            {
                return _IRepositoryDataAccount.GetProductsByPID(PID);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        #endregion

        #region Add items to shopping cart
        public int AddToCart(string userName, int PID, string productSDesc, int itemQuantity, decimal price)
        {
            try
            {
                return _IRepositoryDataAccount.AddToCart(userName, PID, productSDesc, itemQuantity, price);
            }
            catch(Exception exception)
            {
                throw exception;
            }
        }
        #endregion

        #region View Shopping Cart
        public DataSet ViewCart(string userName)
        {
            try
            {
                return _IRepositoryDataAccount.ViewCart(userName);
            }
            catch(Exception exception)
            {
                throw exception;
            }
        }
        #endregion

        #region Update Products Table
        public bool UpdateProducts(int PID, int quantity)
        {
            try
            {
                return _IRepositoryDataAccount.UpdateProducts(PID, quantity);
            }
            catch(Exception exception)
            {
                throw exception;
            }
        }
        #endregion

        #region Delete from shopping cart and update the database
        public bool DeleteCartUpdProducts(int PID, string userName, int quantity)
        {
            try
            {
                return _IRepositoryDataAccount.DeleteCartUpdProducts(PID, userName, quantity);
            } 
            catch(Exception exception)
            {
                throw exception;
            }
        }
        #endregion
        #endregion
    }
}