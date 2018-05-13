using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace MyShopping.App_Code
{
    public class BusinessLayer : IBusinessDataAuthentication, IBusinessDataAccount
    {
        #region RepositoryAbstraction reference
        private RepositoryAbstraction _RepositoryAbstraction = null;
        #endregion

        #region Constructors for Injection 
        public BusinessLayer() : this(new RepositoryAbstraction())
        {

        }

        public BusinessLayer(RepositoryAbstraction repositoryAbstraction)
        {
            _RepositoryAbstraction = repositoryAbstraction;
        }
        #endregion

        #region IBusinessDataAuthentication Method
        #region Method for Validating User
        public object ValidUser(string userName, string password)
        {
            try
            {
                return _RepositoryAbstraction.ValidUser(userName, password);
            }
            catch(Exception exception)
            {
                throw exception;
            }
        }
        #endregion
        #endregion

        #region IBusinessDataAccount Methods
        #region Get User Role
        public object GetUserRole(string userName)
        {
            try
            {
                return _RepositoryAbstraction.GetUserRole(userName);
            }
            catch(Exception exception)
            {
                throw exception;
            }
        }
        #endregion

        #region Get Products by Category ID
        public DataSet ProductsByID(int ID)
        {
            try
            {
                return _RepositoryAbstraction.ProductListByID(ID);
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
                return _RepositoryAbstraction.GetProductsByPID(PID);
            }
            catch(Exception exception)
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
                return _RepositoryAbstraction.AddToCart(userName, PID, productSDesc, itemQuantity, price);
            }
            catch (Exception exception)
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
                return _RepositoryAbstraction.ViewCart(userName);
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
                return _RepositoryAbstraction.UpdateProducts(PID, quantity);
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
                return _RepositoryAbstraction.DeleteCartUpdProducts(PID, userName, quantity);
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