using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using System.Data.Common;

namespace DAL
{
    public class saledbManager
    {
        public delegate void DataReaderHandler(IDataReader reader);
        Database db = SqlHelper.CreateConnection();
        public void GetAllsale(DataReaderHandler handler, int saleId, int assignjobId, int flag)
        {
            DbCommand dbCmd = db.GetStoredProcCommand(StoreProcedure.sp_sale.ToString());
            db.AddInParameter(dbCmd, "@saleId", DbType.Int32, saleId);
            db.AddInParameter(dbCmd, "@assignjobId", DbType.Int32, assignjobId);
            db.AddInParameter(dbCmd, "@customerId", DbType.Int32, 0);
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
        public int savesale(int saleId, int assignjobId, int customerId, int branchId, int userId, DateTime regdate, bool isDel, int flag)
        {
            DbCommand dbCmd = db.GetStoredProcCommand(StoreProcedure.sp_sale.ToString());
            db.AddInParameter(dbCmd, "@saleId", DbType.Int32, saleId);
            db.AddInParameter(dbCmd, "@assignjobId", DbType.Int32, assignjobId);
            db.AddInParameter(dbCmd, "@customerId", DbType.Int32, customerId);
            db.AddInParameter(dbCmd, "@branchId", DbType.Int32, branchId);
            db.AddInParameter(dbCmd, "@userId", DbType.Int32, userId);
            db.AddInParameter(dbCmd, "@regdate", DbType.DateTime, regdate);
            db.AddInParameter(dbCmd, "@isDel", DbType.Boolean, isDel);
            db.AddInParameter(dbCmd, "@flag", DbType.Int32, flag);
            return Convert.ToInt32(db.ExecuteScalar(dbCmd));
        }
        public void deletesale(int saleId, int flag)
        {
            DbCommand dbCmd = db.GetStoredProcCommand(StoreProcedure.sp_sale.ToString());
            db.AddInParameter(dbCmd, "@saleId", DbType.Int32, saleId);
            db.AddInParameter(dbCmd, "@assignjobId", DbType.Int32, 0);
            db.AddInParameter(dbCmd, "@customerId", DbType.Int32, 0);
            db.AddInParameter(dbCmd, "@branchId", DbType.Int32, 0);
            db.AddInParameter(dbCmd, "@userId", DbType.Int32, 0);
            db.AddInParameter(dbCmd, "@regdate", DbType.DateTime, null);
            db.AddInParameter(dbCmd, "@isDel", DbType.Boolean, false);
            db.AddInParameter(dbCmd, "@flag", DbType.Int32, flag);
            db.ExecuteNonQuery(dbCmd);
        }
        public int savesaleItem(int saleitemId, int saleId, int categoryId, int productId, decimal unitprice, int saleqty, 
            int measurementQty, decimal totalunitamount, int flag)
        {
            DbCommand dbCmd = db.GetStoredProcCommand(StoreProcedure.sp_saleitem.ToString());
            db.AddInParameter(dbCmd, "@saleitemId", DbType.Int32, saleitemId);
            db.AddInParameter(dbCmd, "@saleId", DbType.Int32, saleId);
            db.AddInParameter(dbCmd, "@categoryId", DbType.Int32, categoryId);
            db.AddInParameter(dbCmd, "@productId", DbType.Int32, productId);
            db.AddInParameter(dbCmd, "@unitprice", DbType.Decimal, unitprice);
            db.AddInParameter(dbCmd, "@saleqty", DbType.Int32, saleqty);
            db.AddInParameter(dbCmd, "@measurementQty", DbType.Int32, measurementQty);
            db.AddInParameter(dbCmd, "@totalunitamount", DbType.Decimal, totalunitamount);
            db.AddInParameter(dbCmd, "@flag", DbType.Int32, flag);
            return Convert.ToInt32(db.ExecuteScalar(dbCmd));
        }
        public void searchInsale(DataReaderHandler handler, int userId, int branchId, string datefrom, string dateto, int flag)
        {
            DbCommand dbCmd = db.GetStoredProcCommand(StoreProcedure.sp_searchInsale.ToString());
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
