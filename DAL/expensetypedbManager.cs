using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using System.Data.Common;

namespace DAL
{
    public class expensetypedbManager
    {
        public delegate void DataReaderHandler(IDataReader reader);
        Database db = SqlHelper.CreateConnection();
        public void GetAllexpensetype(DataReaderHandler handler, int expensetypeId, int flag)
        {
            DbCommand dbCmd = db.GetStoredProcCommand(StoreProcedure.sp_expensetype.ToString());
            db.AddInParameter(dbCmd, "@expensetypeId", DbType.Int32, expensetypeId);
            db.AddInParameter(dbCmd, "@expensetypename", DbType.String, "");
            db.AddInParameter(dbCmd, "@isDel", DbType.Boolean, false);
            db.AddInParameter(dbCmd, "@flag", DbType.Int32, flag);
            using (IDataReader idr = db.ExecuteReader(dbCmd))
            {
                handler(idr);
            }
            SqlHelper.CloseConnection(dbCmd);
        }
        public int saveexpensetype(int expensetypeId, string expensetypename, bool isDel, int flag)
        {
            DbCommand dbCmd = db.GetStoredProcCommand(StoreProcedure.sp_expensetype.ToString());
            db.AddInParameter(dbCmd, "@expensetypeId", DbType.Int32, expensetypeId);
            db.AddInParameter(dbCmd, "@expensetypename", DbType.String, expensetypename);
            db.AddInParameter(dbCmd, "@isDel", DbType.Boolean, isDel);
            db.AddInParameter(dbCmd, "@flag", DbType.Int32, flag);
            return Convert.ToInt32(db.ExecuteScalar(dbCmd));
        }
        public void deleteexpensetype(int expensetypeId, int flag)
        {
            DbCommand dbCmd = db.GetStoredProcCommand(StoreProcedure.sp_expensetype.ToString());
            db.AddInParameter(dbCmd, "@expensetypeId", DbType.Int32, expensetypeId);
            db.AddInParameter(dbCmd, "@expensetypename", DbType.String, "");
            db.AddInParameter(dbCmd, "@isDel", DbType.Boolean, false);
            db.AddInParameter(dbCmd, "@flag", DbType.Int32, flag);
            db.ExecuteNonQuery(dbCmd);
        }
    }
}
