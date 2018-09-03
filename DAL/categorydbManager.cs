using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using System.Data.Common;

namespace DAL
{
    public class categorydbManager
    {
        public delegate void DataReaderHandler(IDataReader reader);
        Database db = SqlHelper.CreateConnection();
        public void GetAllcategory(DataReaderHandler handler, int categoryId, int flag)
        {
            DbCommand dbCmd = db.GetStoredProcCommand(StoreProcedure.sp_category.ToString());
            db.AddInParameter(dbCmd, "@categoryId", DbType.Int32, categoryId);
            db.AddInParameter(dbCmd, "@categoryname", DbType.String, "");
            db.AddInParameter(dbCmd, "@isDel", DbType.Boolean, false);
            db.AddInParameter(dbCmd, "@flag", DbType.Int32, flag);
            using (IDataReader idr = db.ExecuteReader(dbCmd))
            {
                handler(idr);
            }
            SqlHelper.CloseConnection(dbCmd);
        }
        public int savecategory(int categoryId, string categoryname, bool isDel, int flag)
        {
            DbCommand dbCmd = db.GetStoredProcCommand(StoreProcedure.sp_category.ToString());
            db.AddInParameter(dbCmd, "@categoryId", DbType.Int32, categoryId);
            db.AddInParameter(dbCmd, "@categoryname", DbType.String, categoryname);
            db.AddInParameter(dbCmd, "@isDel", DbType.Boolean, isDel);
            db.AddInParameter(dbCmd, "@flag", DbType.Int32, flag);
            return Convert.ToInt32(db.ExecuteScalar(dbCmd));
        }
        public void deletecategory(int categoryId, int flag)
        {
            DbCommand dbCmd = db.GetStoredProcCommand(StoreProcedure.sp_category.ToString());
            db.AddInParameter(dbCmd, "@categoryId", DbType.Int32, categoryId);
            db.AddInParameter(dbCmd, "@categoryname", DbType.String, "");
            db.AddInParameter(dbCmd, "@isDel", DbType.Boolean, false);
            db.AddInParameter(dbCmd, "@flag", DbType.Int32, flag);
            db.ExecuteNonQuery(dbCmd);
        }
    }
}
