using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using System.Data.Common;

namespace DAL
{
    public class stockmovedbManager
    {
        public delegate void DataReaderHandler(IDataReader reader);
        Database db = SqlHelper.CreateConnection();
        public void GetAllstockmove(DataReaderHandler handler, int stockmoveId, int flag)
        {
            DbCommand dbCmd = db.GetStoredProcCommand(StoreProcedure.sp_stockmove.ToString());
            db.AddInParameter(dbCmd, "@stockmoveId", DbType.Int32, stockmoveId);
            db.AddInParameter(dbCmd, "@srcbranchId", DbType.Int32, 0);
            db.AddInParameter(dbCmd, "@desbranchId", DbType.Int32, 0);
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
        public int savestockmove(int stockmoveId, int srcbranchId, int desbranchId, int userId, DateTime regdate, bool isDel, int flag)
        {
            DbCommand dbCmd = db.GetStoredProcCommand(StoreProcedure.sp_stockmove.ToString());
            db.AddInParameter(dbCmd, "@stockmoveId", DbType.Int32, stockmoveId);
            db.AddInParameter(dbCmd, "@srcbranchId", DbType.Int32, srcbranchId);
            db.AddInParameter(dbCmd, "@desbranchId", DbType.Int32, desbranchId);
            db.AddInParameter(dbCmd, "@userId", DbType.Int32, userId);
            db.AddInParameter(dbCmd, "@regdate", DbType.DateTime, regdate);
            db.AddInParameter(dbCmd, "@isDel", DbType.Boolean, isDel);
            db.AddInParameter(dbCmd, "@flag", DbType.Int32, flag);
            return Convert.ToInt32(db.ExecuteScalar(dbCmd));
        }
        public void deletestockmove(int stockmoveId, int flag)
        {
            DbCommand dbCmd = db.GetStoredProcCommand(StoreProcedure.sp_stockmove.ToString());
            db.AddInParameter(dbCmd, "@stockmoveId", DbType.Int32, stockmoveId);
            db.AddInParameter(dbCmd, "@srcbranchId", DbType.Int32, 0);
            db.AddInParameter(dbCmd, "@desbranchId", DbType.Int32, 0);
            db.AddInParameter(dbCmd, "@userId", DbType.Int32, 0);
            db.AddInParameter(dbCmd, "@regdate", DbType.DateTime, null);
            db.AddInParameter(dbCmd, "@isDel", DbType.Boolean, false);
            db.AddInParameter(dbCmd, "@flag", DbType.Int32, flag);
            db.ExecuteNonQuery(dbCmd);
        }
        public int savestockmoveItem(int stockmoveitemId, int stockmoveId, int categoryId, int productId, decimal unitprice, int stockqty, decimal totalunitamount, int flag)
        {
            DbCommand dbCmd = db.GetStoredProcCommand(StoreProcedure.sp_stockmoveitem.ToString());
            db.AddInParameter(dbCmd, "@stockmoveitemId", DbType.Int32, stockmoveitemId);
            db.AddInParameter(dbCmd, "@stockmoveId", DbType.Int32, stockmoveId);
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
