using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShopping.App_Code
{
    public interface IDataAccess
    {
        #region IDataAccess Methods
        object GetSingleData(string sql, List<DbParameter> parameterList);
        DataSet GetMultipleData(string sql, List<DbParameter> parameterList);
        int InsUpdDel(string sql, List<DbParameter> parameterList);
        object UsingStoredProcedure(string sp, List<DbParameter> parameterList);
        #endregion
    }
}
