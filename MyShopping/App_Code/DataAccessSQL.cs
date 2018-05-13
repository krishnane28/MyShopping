using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MyShopping.App_Code
{
    public class DataAccessSQL : IDataAccess
    {
        #region Connection String
        private string connectionString = ConfigurationManager.ConnectionStrings["ShoppingDB"].ConnectionString;
        #endregion

        #region IDataAccess Methods Implementations
        #region Get Single Data 
        public object GetSingleData(string sql, List<DbParameter> parameterList)
        {
            object result = null;
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sql, connection);
                foreach (SqlParameter sqlParameter in parameterList)
                {
                    command.Parameters.Add(sqlParameter);
                }
                result = command.ExecuteScalar();
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                connection.Close();
            }
            return result;
        }
        #endregion

        #region Get Multiple Data
        public DataSet GetMultipleData(string sql, List<DbParameter> parameterList)
        {
            DataSet dataSet = new DataSet();
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(sql, connection);
                foreach (SqlParameter sqlParameter in parameterList)
                {
                    dataAdapter.SelectCommand.Parameters.Add(sqlParameter);
                }
                dataAdapter.Fill(dataSet);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                connection.Close();
            }
            return dataSet;
        }
        #endregion

        #region Insert or Update or Delete
        public int InsUpdDel(string sql, List<DbParameter> parameterList)
        {
            int rowsUpdated = 0;
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sql, connection);
                foreach (SqlParameter sqlParameter in parameterList)
                {
                    command.Parameters.Add(sqlParameter);
                }
                rowsUpdated = command.ExecuteNonQuery();
                return rowsUpdated;
            }
            catch(Exception exception)
            {
                throw exception;
            }
            finally
            {
                connection.Close();
            }
        }
        #endregion

        #region Using Stored Procedure
        public object UsingStoredProcedure(string sp, List<DbParameter> parameterList)
        {
            object result = null;
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sp, connection);
                command.CommandType = CommandType.StoredProcedure;  
                foreach(SqlParameter parameter in parameterList)
                {
                    command.Parameters.Add(parameter);
                }
                if(sp == "dbo.spDeleteCartUpdateProducts")
                {
                    result = command.ExecuteNonQuery();
                }
                else
                {
                    result = command.ExecuteScalar();
                }
                return result;
            }
            catch(Exception exception)
            {
                throw exception;
            }
            finally
            {
                connection.Close();
            }
        }
        #endregion
        #endregion
    }
}