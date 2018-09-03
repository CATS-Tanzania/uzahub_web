using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using System.Data.Common;

namespace DAL
{
    public class productdbManager
    {
        public delegate void DataReaderHandler(IDataReader reader);
        Database db = SqlHelper.CreateConnection();
        public void GetAllproduct(DataReaderHandler handler, int productId, int flag)
        {
            DbCommand dbCmd = db.GetStoredProcCommand(StoreProcedure.sp_product.ToString());
            db.AddInParameter(dbCmd, "@productId", DbType.Int32, productId);
            db.AddInParameter(dbCmd, "@categoryId", DbType.Int32, 0);
            db.AddInParameter(dbCmd, "@productname", DbType.String, "");
            db.AddInParameter(dbCmd, "@buyprice", DbType.Decimal, 0);
            db.AddInParameter(dbCmd, "@sellprice", DbType.Decimal, 0);
            db.AddInParameter(dbCmd, "@isDel", DbType.Boolean, false);
            db.AddInParameter(dbCmd, "@flag", DbType.Int32, flag);
            using (IDataReader idr = db.ExecuteReader(dbCmd))
            {
                handler(idr);
            }
            SqlHelper.CloseConnection(dbCmd);
        }
        public int saveproduct(int productId, int categoryId, string productname, decimal buyprice, decimal sellprice, bool isDel, int flag)
        {
            DbCommand dbCmd = db.GetStoredProcCommand(StoreProcedure.sp_product.ToString());
            db.AddInParameter(dbCmd, "@productId", DbType.Int32, productId);
            db.AddInParameter(dbCmd, "@categoryId", DbType.Int32, categoryId);
            db.AddInParameter(dbCmd, "@productname", DbType.String, productname);
            db.AddInParameter(dbCmd, "@buyprice", DbType.Decimal, buyprice);
            db.AddInParameter(dbCmd, "@sellprice", DbType.Decimal, sellprice);
            db.AddInParameter(dbCmd, "@isDel", DbType.Boolean, isDel);
            db.AddInParameter(dbCmd, "@flag", DbType.Int32, flag);
            return Convert.ToInt32(db.ExecuteScalar(dbCmd));
        }
        public void deleteproduct(int productId, int flag)
        {
            DbCommand dbCmd = db.GetStoredProcCommand(StoreProcedure.sp_product.ToString());
            db.AddInParameter(dbCmd, "@productId", DbType.Int32, productId);
            db.AddInParameter(dbCmd, "@categoryId", DbType.Int32, 0);
            db.AddInParameter(dbCmd, "@productname", DbType.String, "");
            db.AddInParameter(dbCmd, "@buyprice", DbType.Decimal, 0);
            db.AddInParameter(dbCmd, "@sellprice", DbType.Decimal, 0);
            db.AddInParameter(dbCmd, "@isDel", DbType.Boolean, false);
            db.AddInParameter(dbCmd, "@flag", DbType.Int32, flag);
            db.ExecuteNonQuery(dbCmd);
        }
        public void getavlstockQty(DataReaderHandler handler, int branchId, int productId, int flag)
        {
            DbCommand dbCmd = db.GetStoredProcCommand(StoreProcedure.sp_avlstockQty.ToString());
            db.AddInParameter(dbCmd, "@branchId", DbType.Int32, branchId);
            db.AddInParameter(dbCmd, "@productId", DbType.Int32, productId);
            db.AddInParameter(dbCmd, "@flag", DbType.Int32, flag);
            using (IDataReader idr = db.ExecuteReader(dbCmd))
            {
                handler(idr);
            }
            SqlHelper.CloseConnection(dbCmd);
        }
    }
}
