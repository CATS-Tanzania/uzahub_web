using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using System.Data.Common;

namespace DAL
{
    public class stockindbManager
    {
        public delegate void DataReaderHandler(IDataReader reader);
        Database db = SqlHelper.CreateConnection();
        public void GetAllstockin(DataReaderHandler handler, int stockinId, int flag)
        {
            DbCommand dbCmd = db.GetStoredProcCommand(StoreProcedure.sp_stockin.ToString());
            db.AddInParameter(dbCmd, "@stockinId", DbType.Int32, stockinId);
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
        public int savestockin(int stockinId, int branchId, int userId, DateTime regdate, bool isDel, int flag)
        {
            DbCommand dbCmd = db.GetStoredProcCommand(StoreProcedure.sp_stockin.ToString());
            db.AddInParameter(dbCmd, "@stockinId", DbType.Int32, stockinId);
            db.AddInParameter(dbCmd, "@branchId", DbType.Int32, branchId);
            db.AddInParameter(dbCmd, "@userId", DbType.Int32, userId);
            db.AddInParameter(dbCmd, "@regdate", DbType.DateTime, regdate);
            db.AddInParameter(dbCmd, "@isDel", DbType.Boolean, isDel);
            db.AddInParameter(dbCmd, "@flag", DbType.Int32, flag);
            return Convert.ToInt32(db.ExecuteScalar(dbCmd));
        }
        public void deletestockin(int stockinId, int flag)
        {
            DbCommand dbCmd = db.GetStoredProcCommand(StoreProcedure.sp_stockin.ToString());
            db.AddInParameter(dbCmd, "@stockinId", DbType.Int32, stockinId);
            db.AddInParameter(dbCmd, "@branchId", DbType.Int32, 0);
            db.AddInParameter(dbCmd, "@userId", DbType.Int32, 0);
            db.AddInParameter(dbCmd, "@regdate", DbType.DateTime, null);
            db.AddInParameter(dbCmd, "@isDel", DbType.Boolean, false);
            db.AddInParameter(dbCmd, "@flag", DbType.Int32, flag);
            db.ExecuteNonQuery(dbCmd);
        }
        public int savestockinItem(int stockinitemId, int stockinId, int categoryId, int productId, decimal unitprice, int stockqty, decimal totalunitamount, int flag)
        {
            DbCommand dbCmd = db.GetStoredProcCommand(StoreProcedure.sp_stockinitem.ToString());
            db.AddInParameter(dbCmd, "@stockinitemId", DbType.Int32, stockinitemId);
            db.AddInParameter(dbCmd, "@stockinId", DbType.Int32, stockinId);
            db.AddInParameter(dbCmd, "@categoryId", DbType.Int32, categoryId);
            db.AddInParameter(dbCmd, "@productId", DbType.Int32, productId);
            db.AddInParameter(dbCmd, "@unitprice", DbType.Decimal, unitprice);
            db.AddInParameter(dbCmd, "@stockqty", DbType.Int32, stockqty);
            db.AddInParameter(dbCmd, "@totalunitamount", DbType.Decimal, totalunitamount);
            db.AddInParameter(dbCmd, "@flag", DbType.Int32, flag);
            return Convert.ToInt32(db.ExecuteScalar(dbCmd));
        }
    }
}
