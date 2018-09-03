using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using System.Data.Common;

namespace DAL
{
    public class datasetdbManager
    {
        Database db = SqlHelper.CreateConnection();

        public DataSet GetAllstockinItem(int stockinId, int flag)
        {
            DbCommand dbCmd = db.GetStoredProcCommand(StoreProcedure.sp_stockinitem.ToString());
            db.AddInParameter(dbCmd, "@stockinitemId", DbType.Int32, 0);
            db.AddInParameter(dbCmd, "@stockinId", DbType.Int32, stockinId);
            db.AddInParameter(dbCmd, "@categoryId", DbType.Int32, 0);
            db.AddInParameter(dbCmd, "@productId", DbType.Int32, 0);
            db.AddInParameter(dbCmd, "@unitprice", DbType.Decimal, 0);
            db.AddInParameter(dbCmd, "@stockqty", DbType.Int32, 0);
            db.AddInParameter(dbCmd, "@totalunitamount", DbType.Decimal, 0);
            db.AddInParameter(dbCmd, "@flag", DbType.Int32, flag);
            DataSet ds = db.ExecuteDataSet(dbCmd);
            return ds;
        }
        public DataSet GetAllstockmoveItem(int stockmoveId, int flag)
        {
            DbCommand dbCmd = db.GetStoredProcCommand(StoreProcedure.sp_stockmoveitem.ToString());
            db.AddInParameter(dbCmd, "@stockmoveitemId", DbType.Int32, 0);
            db.AddInParameter(dbCmd, "@stockmoveId", DbType.Int32, stockmoveId);
            db.AddInParameter(dbCmd, "@categoryId", DbType.Int32, 0);
            db.AddInParameter(dbCmd, "@productId", DbType.Int32, 0);
            db.AddInParameter(dbCmd, "@unitprice", DbType.Decimal, 0);
            db.AddInParameter(dbCmd, "@stockqty", DbType.Int32, 0);
            db.AddInParameter(dbCmd, "@totalunitamount", DbType.Decimal, 0);
            db.AddInParameter(dbCmd, "@flag", DbType.Int32, flag);
            DataSet ds = db.ExecuteDataSet(dbCmd);
            return ds;
        }
        public DataSet GetAllassignjobItem(int assignjobId, int flag)
        {
            DbCommand dbCmd = db.GetStoredProcCommand(StoreProcedure.sp_assignjobitem.ToString());
            db.AddInParameter(dbCmd, "@assignjobitemId", DbType.Int32, 0);
            db.AddInParameter(dbCmd, "@assignjobId", DbType.Int32, assignjobId);
            db.AddInParameter(dbCmd, "@categoryId", DbType.Int32, 0);
            db.AddInParameter(dbCmd, "@productId", DbType.Int32, 0);
            db.AddInParameter(dbCmd, "@unitprice", DbType.Decimal, 0);
            db.AddInParameter(dbCmd, "@stockqty", DbType.Int32, 0);
            db.AddInParameter(dbCmd, "@measurementQty", DbType.Int32, 0);
            db.AddInParameter(dbCmd, "@totalunitamount", DbType.Decimal, 0);
            db.AddInParameter(dbCmd, "@flag", DbType.Int32, flag);
            DataSet ds = db.ExecuteDataSet(dbCmd);
            return ds;
        }
        public DataSet GetAllexpenseItem(int expenseId, int flag)
        {
            DbCommand dbCmd = db.GetStoredProcCommand(StoreProcedure.sp_expenseitem.ToString());
            db.AddInParameter(dbCmd, "@expenseitemId", DbType.Int32, 0);
            db.AddInParameter(dbCmd, "@expenseId", DbType.Int32, expenseId);
            db.AddInParameter(dbCmd, "@expensetypeId", DbType.Int32, 0);
            db.AddInParameter(dbCmd, "@expamount", DbType.Decimal, 0);
            db.AddInParameter(dbCmd, "@flag", DbType.Int32, flag);
            DataSet ds = db.ExecuteDataSet(dbCmd);
            return ds;
        }
        public DataSet GetAllsaleItem(int saleId, int flag)
        {
            DbCommand dbCmd = db.GetStoredProcCommand(StoreProcedure.sp_saleitem.ToString());
            db.AddInParameter(dbCmd, "@saleitemId", DbType.Int32, 0);
            db.AddInParameter(dbCmd, "@saleId", DbType.Int32, saleId);
            db.AddInParameter(dbCmd, "@categoryId", DbType.Int32, 0);
            db.AddInParameter(dbCmd, "@productId", DbType.Int32, 0);
            db.AddInParameter(dbCmd, "@unitprice", DbType.Decimal, 0);
            db.AddInParameter(dbCmd, "@saleqty", DbType.Int32, 0);
            db.AddInParameter(dbCmd, "@measurementQty", DbType.Int32, 0);
            db.AddInParameter(dbCmd, "@totalunitamount", DbType.Decimal, 0);
            db.AddInParameter(dbCmd, "@flag", DbType.Int32, flag);
            DataSet ds = db.ExecuteDataSet(dbCmd);
            return ds;
        }
        public DataSet rp_searchInstockin(int branchId, int userId, string datefrom, string dateto, int flag)
        {
            DbCommand dbCmd = db.GetStoredProcCommand(StoreProcedure.sp_rp_searchInstockin.ToString());
            db.AddInParameter(dbCmd, "@branchId", DbType.Int32, branchId);
            db.AddInParameter(dbCmd, "@userId", DbType.Int32, userId);
            db.AddInParameter(dbCmd, "@datefrom", DbType.String, datefrom);
            db.AddInParameter(dbCmd, "@dateto", DbType.String, dateto);
            db.AddInParameter(dbCmd, "@flag", DbType.Int32, flag);
            DataSet ds = db.ExecuteDataSet(dbCmd);
            return ds;
        }
        public DataSet rp_searchInassignjob(int branchId, int userId, string datefrom, string dateto, int flag)
        {
            DbCommand dbCmd = db.GetStoredProcCommand(StoreProcedure.sp_rp_searchInassignjob.ToString());
            db.AddInParameter(dbCmd, "@branchId", DbType.Int32, branchId);
            db.AddInParameter(dbCmd, "@userId", DbType.Int32, userId);
            db.AddInParameter(dbCmd, "@datefrom", DbType.String, datefrom);
            db.AddInParameter(dbCmd, "@dateto", DbType.String, dateto);
            db.AddInParameter(dbCmd, "@flag", DbType.Int32, flag);
            DataSet ds = db.ExecuteDataSet(dbCmd);
            return ds;
        }
        public DataSet rp_searchInsale(int branchId, int userId, string datefrom, string dateto, int flag)
        {
            DbCommand dbCmd = db.GetStoredProcCommand(StoreProcedure.sp_rp_searchInsale.ToString());
            db.AddInParameter(dbCmd, "@branchId", DbType.Int32, branchId);
            db.AddInParameter(dbCmd, "@userId", DbType.Int32, userId);
            db.AddInParameter(dbCmd, "@datefrom", DbType.String, datefrom);
            db.AddInParameter(dbCmd, "@dateto", DbType.String, dateto);
            db.AddInParameter(dbCmd, "@flag", DbType.Int32, flag);
            DataSet ds = db.ExecuteDataSet(dbCmd);
            return ds;
        }
        public DataSet rp_searchInexpense(int branchId, int userId, string datefrom, string dateto, int flag)
        {
            DbCommand dbCmd = db.GetStoredProcCommand(StoreProcedure.sp_rp_searchInexpense.ToString());
            db.AddInParameter(dbCmd, "@branchId", DbType.Int32, branchId);
            db.AddInParameter(dbCmd, "@userId", DbType.Int32, userId);
            db.AddInParameter(dbCmd, "@datefrom", DbType.String, datefrom);
            db.AddInParameter(dbCmd, "@dateto", DbType.String, dateto);
            db.AddInParameter(dbCmd, "@flag", DbType.Int32, flag);
            DataSet ds = db.ExecuteDataSet(dbCmd);
            return ds;
        }
    }
}
