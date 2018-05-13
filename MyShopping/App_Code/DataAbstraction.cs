using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Web;

namespace MyShopping.App_Code
{
    public class DataAbstraction
    {
        #region IDataAccess interface
        private IDataAccess _IDataAccess = null;
        #endregion

        #region Contructors for injection 
        public DataAbstraction() : this(new DataAccessSQL())
        {

        }

        public DataAbstraction(IDataAccess iDataAccess)
        {
            _IDataAccess = iDataAccess;
        }
        #endregion

        #region Get Single Data 
        public object GetSingleData(string sql, List<DbParameter> parameterList)
        {
            try
            {
                return _IDataAccess.GetSingleData(sql, parameterList);
            }
            catch(Exception exception)
            {
                throw exception;
            }            
        }
        #endregion

        #region Get Multiple Data 
        public DataSet GetMultipleData(string sql, List<DbParameter> parameterList)
        {
            try
            {
                return _IDataAccess.GetMultipleData(sql, parameterList);
            }
            catch(Exception exception)
            {
                throw exception;
            }
        }
        #endregion

        #region Insert or Update or Delete
        public int InsUpdDel(string sql, List<DbParameter> parameterList)
        {
            try
            {
                return _IDataAccess.InsUpdDel(sql, parameterList);
            }
            catch(Exception exception)
            {
                throw exception;
            }
        }
        #endregion

        #region Get Data using Stored Procedure
        public object UsingSP(string sp, List<DbParameter> parameterList)
        {
            try
            {
                return _IDataAccess.UsingStoredProcedure(sp, parameterList);
            }
            catch(Exception exception)
            {
                throw exception;
            }
        }
        #endregion
    }
}