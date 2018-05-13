using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MyShopping.App_Code
{
    public class RepositorySQL : IRepositoryDataAuthentication, IRepositoryDataAccount
    {
        #region DataAbstraction Reference
        DataAbstraction dataAbstraction = null;
        #endregion

        #region Constructors for Injection
        public RepositorySQL() : this(new DataAbstraction())
        {

        }

        public RepositorySQL(DataAbstraction _dataAbstraction)
        {
            dataAbstraction = _dataAbstraction;
        }
        #endregion

        #region IRepositoryDataAccount Method Implementation
        #region Get User Roles
        public object GetUserRoles(string userName)
        {
            try
            {
                string storedProcedure = "dbo.GetUserRoles";
                List<DbParameter> parameterList = new List<DbParameter>();
                SqlParameter parameterUserName = new SqlParameter("@Username", SqlDbType.NVarChar, 50);
                parameterUserName.Value = userName;
                parameterList.Add(parameterUserName);
                return dataAbstraction.UsingSP(storedProcedure, parameterList);
            }
            catch (Exception exception)
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
                string sql = "select * from dbo.Products where CatID=@CatID";
                List<DbParameter> parameterList = new List<DbParameter>();
                SqlParameter catID = new SqlParameter("@CatID", SqlDbType.Int);
                catID.Value = ID;
                parameterList.Add(catID);
                return dataAbstraction.GetMultipleData(sql, parameterList);
            }
            catch (Exception exception)
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
                string sql = "select * from dbo.Products where ProductID=@PID";
                List<DbParameter> parameterList = new List<DbParameter>();
                SqlParameter PIDParameter = new SqlParameter("@PID", SqlDbType.Int);
                PIDParameter.Value = PID;
                parameterList.Add(PIDParameter);
                return dataAbstraction.GetMultipleData(sql, parameterList);
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
                string sql = "insert into dbo.UserCart (Username, ProductID, ProductSmallDescription, Quantity, Price)" +
               "values (@username, @pid, @pdtsdesc, @quantity, @price)";
                List<DbParameter> parameterList = new List<DbParameter>();
                SqlParameter usernameParameter = new SqlParameter("@username", SqlDbType.VarChar, 50);
                usernameParameter.Value = userName;
                parameterList.Add(usernameParameter);
                SqlParameter pidParameter = new SqlParameter("@pid", SqlDbType.Int);
                pidParameter.Value = PID;
                parameterList.Add(pidParameter);
                SqlParameter smallDescParameter = new SqlParameter("@pdtsdesc", SqlDbType.VarChar, 50);
                smallDescParameter.Value = productSDesc;
                parameterList.Add(smallDescParameter);
                SqlParameter quantityParameter = new SqlParameter("@quantity", SqlDbType.Int);
                quantityParameter.Value = itemQuantity;
                parameterList.Add(quantityParameter);
                SqlParameter priceParameter = new SqlParameter("@price", SqlDbType.Money);
                priceParameter.Value = price;
                parameterList.Add(priceParameter);
                return dataAbstraction.InsUpdDel(sql, parameterList);
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
                string sql = "select * from dbo.UserCart where Username=@username";
                List<DbParameter> parameterList = new List<DbParameter>();
                SqlParameter usernameParameter = new SqlParameter("@username", SqlDbType.VarChar, 50);
                usernameParameter.Value = userName;
                parameterList.Add(usernameParameter);
                return dataAbstraction.GetMultipleData(sql, parameterList);
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
                if(quantity == 0)
                {
                    string sql = "update dbo.Products set Instock=@instock, Inventory=@quantity where ProductID=@pid";
                    List<DbParameter> parameterList = new List<DbParameter>();
                    SqlParameter instockParameter = new SqlParameter("@instock", SqlDbType.Bit);
                    instockParameter.Value = false;
                    parameterList.Add(instockParameter);
                    SqlParameter quantityParameter = new SqlParameter("@quantity", SqlDbType.Int);
                    quantityParameter.Value = quantity;
                    parameterList.Add(quantityParameter);
                    SqlParameter pidParameter = new SqlParameter("@pid", SqlDbType.Int);
                    pidParameter.Value = PID;
                    parameterList.Add(pidParameter);
                    if(dataAbstraction.InsUpdDel(sql, parameterList) == 1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    string sql = "update dbo.Products set Inventory=@quantity where ProductID=@pid";
                    List<DbParameter> parameterList = new List<DbParameter>();
                    SqlParameter quantityParameter = new SqlParameter("@quantity", SqlDbType.Int);
                    quantityParameter.Value = quantity;
                    parameterList.Add(quantityParameter);
                    SqlParameter pidParameter = new SqlParameter("@pid", SqlDbType.Int);
                    pidParameter.Value = PID;
                    parameterList.Add(pidParameter);
                    if (dataAbstraction.InsUpdDel(sql, parameterList) == 1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
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
                string storedProcedure = "dbo.spDeleteCartUpdateProducts";
                List<DbParameter> parameterList = new List<DbParameter>();
                SqlParameter pidParameter = new SqlParameter("@PID", SqlDbType.Int);
                pidParameter.Value = PID;
                parameterList.Add(pidParameter);
                SqlParameter usernameParameter = new SqlParameter("@Username", SqlDbType.VarChar, 50);
                usernameParameter.Value = userName;
                parameterList.Add(usernameParameter);
                SqlParameter quantityParameter = new SqlParameter("@quantity", SqlDbType.Int);
                quantityParameter.Value = quantity;
                parameterList.Add(quantityParameter);
                if(dataAbstraction.UsingSP(storedProcedure, parameterList).ToString() == "2")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(Exception exception)
            {
                throw exception;
            }
        }
        #endregion
        #endregion

        #region IRepositoryDataAuthentication Methods Implementation
        public object ValidUser(string userName, string password)
        {
            try
            {
                string sql = "select Username from dbo.Users where Username=@Username and Password=@Password";
                List<DbParameter> parameterList = new List<DbParameter>();
                SqlParameter parameterUsername = new SqlParameter("@Username", SqlDbType.NVarChar, 50);
                parameterUsername.Value = userName;
                parameterList.Add(parameterUsername);
                SqlParameter parameterPassword = new SqlParameter("@Password", SqlDbType.NVarChar, 50);
                parameterPassword.Value = password;
                parameterList.Add(parameterPassword);
                return dataAbstraction.GetSingleData(sql, parameterList);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        #endregion
    }
}