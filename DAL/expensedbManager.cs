using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using System.Data.Common;

namespace DAL
{
    public class expensedbManager
    {
        public delegate void DataReaderHandler(IDataReader reader);
        Database db = SqlHelper.CreateConnection();
        public void GetAllexpense(DataReaderHandler handler, int expenseId, int flag)
        {
            DbCommand dbCmd = db.GetStoredProcCommand(StoreProcedure.sp_expense.ToString());
            db.AddInParameter(dbCmd, "@expenseId", DbType.Int32, expenseId);
            db.AddInParameter(dbCmd, "@assignjobId", DbType.Int32, 0);
            db.AddInParameter(dbCmd, "@branchId", DbType.Int32, 0);
            db.AddInParameter(dbCmd, "@userId", DbType.Int32, 0);
            db.AddInParameter(dbCmd, "@regdate", DbType.DateTime, null);
            db.AddInParameter(dbCmd, "@isDel", DbType.Boolean, false);
            db.AddInParameter(dbCmd, "@flag", DbType.Int32, flag);
            using (IDataReader idr = db.ExecuteReader(dbCmd))
            {
                handler(idr);
            }
            SqlHelper.CloseConnection(dbCmd);
        }
        public int saveexpense(int expenseId, int assignjobId, int branchId, int userId, DateTime regdate, bool isDel, int flag)
        {
            DbCommand dbCmd = db.GetStoredProcCommand(StoreProcedure.sp_expense.ToString());
            db.AddInParameter(dbCmd, "@expenseId", DbType.Int32, expenseId);
            db.AddInParameter(dbCmd, "@assignjobId", DbType.Int32, assignjobId);
            db.AddInParameter(dbCmd, "@branchId", DbType.Int32, branchId);
            db.AddInParameter(dbCmd, "@userId", DbType.Int32, userId);
            db.AddInParameter(dbCmd, "@regdate", DbType.DateTime, regdate);
            db.AddInParameter(dbCmd, "@isDel", DbType.Boolean, isDel);
            db.AddInParameter(dbCmd, "@flag", DbType.Int32, flag);
            return Convert.ToInt32(db.ExecuteScalar(dbCmd));
        }
        public void deleteexpense(int expenseId, int flag)
        {
            DbCommand dbCmd = db.GetStoredProcCommand(StoreProcedure.sp_expense.ToString());
            db.AddInParameter(dbCmd, "@expenseId", DbType.Int32, expenseId);
            db.AddInParameter(dbCmd, "@assignjobId", DbType.Int32, 0);
            db.AddInParameter(dbCmd, "@branchId", DbType.Int32, 0);
            db.AddInParameter(dbCmd, "@userId", DbType.Int32, 0);
            db.AddInParameter(dbCmd, "@regdate", DbType.DateTime, null);
            db.AddInParameter(dbCmd, "@isDel", DbType.Boolean, false);
            db.AddInParameter(dbCmd, "@flag", DbType.Int32, flag);
            db.ExecuteNonQuery(dbCmd);
        }
        public int saveexpenseItem(int expenseitemId, int expenseId, int expensetypeId, decimal expamount, int flag)
        {
            DbCommand dbCmd = db.GetStoredProcCommand(StoreProcedure.sp_expenseitem.ToString());
            db.AddInParameter(dbCmd, "@expenseitemId", DbType.Int32, expenseitemId);
            db.AddInParameter(dbCmd, "@expenseId", DbType.Int32, expenseId);
            db.AddInParameter(dbCmd, "@expensetypeId", DbType.Int32, expensetypeId);
            db.AddInParameter(dbCmd, "@expamount", DbType.Decimal, expamount);
            db.AddInParameter(dbCmd, "@flag", DbType.Int32, flag);
            return Convert.ToInt32(db.ExecuteScalar(dbCmd));
        }
        public void approveexpense(int expenseId, int userId, int flag)
        {
            DbCommand dbCmd = db.GetStoredProcCommand(StoreProcedure.sp_expense.ToString());
            db.AddInParameter(dbCmd, "@expenseId", DbType.Int32, expenseId);
            db.AddInParameter(dbCmd, "@assignjobId", DbType.Int32, 0);
            db.AddInParameter(dbCmd, "@branchId", DbType.Int32, 0);
            db.AddInParameter(dbCmd, "@userId", DbType.Int32, userId);
            db.AddInParameter(dbCmd, "@regdate", DbType.DateTime, null);
            db.AddInParameter(dbCmd, "@isDel", DbType.Boolean, false);
            db.AddInParameter(dbCmd, "@flag", DbType.Int32, flag);
            db.ExecuteNonQuery(dbCmd);
        }
        public void searchInexpense(DataReaderHandler handler, int userId, int branchId, string datefrom, string dateto, int flag)
        {
            DbCommand dbCmd = db.GetStoredProcCommand(StoreProcedure.sp_searchInexpense.ToString());
            db.AddInParameter(dbCmd, "@userId", DbType.Int32, userId);
            db.AddInParameter(dbCmd, "@branchId", DbType.Int32, branchId);
            db.AddInParameter(dbCmd, "@datefrom", DbType.String, datefrom);
            db.AddInParameter(dbCmd, "@dateto", DbType.String, dateto);
            db.AddInParameter(dbCmd, "@flag", DbType.Int32, flag);
            using (IDataReader idr = db.ExecuteReader(dbCmd))
            {
                handler(idr);
            }
            SqlHelper.CloseConnection(dbCmd);
        }
    }
}
