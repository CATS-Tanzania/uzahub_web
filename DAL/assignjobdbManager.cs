using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using System.Data.Common;

namespace DAL
{
    public class assignjobdbManager
    {
        public delegate void DataReaderHandler(IDataReader reader);
        Database db = SqlHelper.CreateConnection();
        public void GetAllassignjob(DataReaderHandler handler, int assignjobId, int flag)
        {
            DbCommand dbCmd = db.GetStoredProcCommand(StoreProcedure.sp_assignjob.ToString());
            db.AddInParameter(dbCmd, "@assignjobId", DbType.Int32, assignjobId);
            db.AddInParameter(dbCmd, "@cmlNo", DbType.Int32, 0);
            db.AddInParameter(dbCmd, "@truckNo", DbType.String, "");
            db.AddInParameter(dbCmd, "@driverName", DbType.String, "");
            db.AddInParameter(dbCmd, "@drvlncNo", DbType.String, "");
            db.AddInParameter(dbCmd, "@conductorName", DbType.String, "");
            db.AddInParameter(dbCmd, "@infuel", DbType.Int32, 0);
            db.AddInParameter(dbCmd, "@omreadingarrival", DbType.String, "");
            db.AddInParameter(dbCmd, "@omreadingdeparture", DbType.String, "");
            db.AddInParameter(dbCmd, "@mileage", DbType.Int32, 0);
            db.AddInParameter(dbCmd, "@outfuel", DbType.Int32, 0);
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
        public int saveassignjob(int assignjobId, string cmlNo, string truckNo, string driverName, string drvlncNo, string conductorName, int infuel
           , string omreadingarrival, string omreadingdeparture, int mileage, int outfuel, int branchId, int userId, DateTime regdate, bool isdel, int flag)
        {
            DbCommand dbCmd = db.GetStoredProcCommand(StoreProcedure.sp_assignjob.ToString());
            db.AddInParameter(dbCmd, "@assignjobId", DbType.Int32, assignjobId);
            db.AddInParameter(dbCmd, "@cmlNo", DbType.String, cmlNo);
            db.AddInParameter(dbCmd, "@truckNo", DbType.String, truckNo);
            db.AddInParameter(dbCmd, "@driverName", DbType.String, driverName);
            db.AddInParameter(dbCmd, "@drvlncNo", DbType.String, drvlncNo);
            db.AddInParameter(dbCmd, "@conductorName", DbType.String, conductorName);
            db.AddInParameter(dbCmd, "@infuel", DbType.Int32, infuel);
            db.AddInParameter(dbCmd, "@omreadingarrival", DbType.String, omreadingarrival);
            db.AddInParameter(dbCmd, "@omreadingdeparture", DbType.String, omreadingdeparture);
            db.AddInParameter(dbCmd, "@mileage", DbType.Int32, mileage);
            db.AddInParameter(dbCmd, "@outfuel", DbType.Int32, outfuel);
            db.AddInParameter(dbCmd, "@branchId", DbType.Int32, branchId);
            db.AddInParameter(dbCmd, "@userId", DbType.Int32, userId);
            db.AddInParameter(dbCmd, "@regdate", DbType.DateTime, regdate);
            db.AddInParameter(dbCmd, "@isDel", DbType.Boolean, isdel);
            db.AddInParameter(dbCmd, "@flag", DbType.Int32, flag);
            return Convert.ToInt32(db.ExecuteScalar(dbCmd));
        }
        public void deleteassignjob(int assignjobId, int flag)
        {
            DbCommand dbCmd = db.GetStoredProcCommand(StoreProcedure.sp_assignjob.ToString());
            db.AddInParameter(dbCmd, "@assignjobId", DbType.Int32, assignjobId);
            db.AddInParameter(dbCmd, "@cmlNo", DbType.Int32, 0);
            db.AddInParameter(dbCmd, "@truckNo", DbType.String, "");
            db.AddInParameter(dbCmd, "@driverName", DbType.String, "");
            db.AddInParameter(dbCmd, "@drvlncNo", DbType.String, "");
            db.AddInParameter(dbCmd, "@conductorName", DbType.String, "");
            db.AddInParameter(dbCmd, "@infuel", DbType.Int32, 0);
            db.AddInParameter(dbCmd, "@omreadingarrival", DbType.String, "");
            db.AddInParameter(dbCmd, "@omreadingdeparture", DbType.String, "");
            db.AddInParameter(dbCmd, "@mileage", DbType.Int32, 0);
            db.AddInParameter(dbCmd, "@outfuel", DbType.Int32, 0);
            db.AddInParameter(dbCmd, "@branchId", DbType.Int32, 0);
            db.AddInParameter(dbCmd, "@userId", DbType.Int32, 0);
            db.AddInParameter(dbCmd, "@regdate", DbType.DateTime, null);
            db.AddInParameter(dbCmd, "@isDel", DbType.Boolean, false);
            db.AddInParameter(dbCmd, "@flag", DbType.Int32, flag);
            db.ExecuteNonQuery(dbCmd);
        }
        public int saveassignjobItem(int assignjobitemId, int assignjobId, int categoryId, int productId, decimal unitprice,
            int stockqty, int measurementQty, decimal totalunitamount, int flag)
        {
            DbCommand dbCmd = db.GetStoredProcCommand(StoreProcedure.sp_assignjobitem.ToString());
            db.AddInParameter(dbCmd, "@assignjobitemId", DbType.Int32, assignjobitemId);
            db.AddInParameter(dbCmd, "@assignjobId", DbType.Int32, assignjobId);
            db.AddInParameter(dbCmd, "@categoryId", DbType.Int32, categoryId);
            db.AddInParameter(dbCmd, "@productId", DbType.Int32, productId);
            db.AddInParameter(dbCmd, "@unitprice", DbType.Decimal, unitprice);
            db.AddInParameter(dbCmd, "@stockqty", DbType.Int32, stockqty);
            db.AddInParameter(dbCmd, "@measurementQty", DbType.Int32, measurementQty);
            db.AddInParameter(dbCmd, "@totalunitamount", DbType.Decimal, totalunitamount);
            db.AddInParameter(dbCmd, "@flag", DbType.Int32, flag);
            return Convert.ToInt32(db.ExecuteScalar(dbCmd));
        }
        public void searchInassignjob(DataReaderHandler handler, int userId, int branchId, string datefrom, string dateto, int flag)
        {
            DbCommand dbCmd = db.GetStoredProcCommand(StoreProcedure.sp_searchInassignjob.ToString());
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
        public void getavailableQty(DataReaderHandler handler, int assignjobId, int productId, int measurementQty, int flag)
        {
            DbCommand dbCmd = db.GetStoredProcCommand(StoreProcedure.sp_assignjobitem.ToString());
            db.AddInParameter(dbCmd, "@assignjobitemId", DbType.Int32, 0);
            db.AddInParameter(dbCmd, "@assignjobId", DbType.Int32, assignjobId);
            db.AddInParameter(dbCmd, "@categoryId", DbType.Int32, 0);
            db.AddInParameter(dbCmd, "@productId", DbType.Int32, productId);
            db.AddInParameter(dbCmd, "@unitprice", DbType.Decimal, 0);
            db.AddInParameter(dbCmd, "@stockqty", DbType.Int32, 0);
            db.AddInParameter(dbCmd, "@measurementQty", DbType.Int32, measurementQty);
            db.AddInParameter(dbCmd, "@totalunitamount", DbType.Decimal, 0);
            db.AddInParameter(dbCmd, "@flag", DbType.Int32, flag);
            using (IDataReader idr = db.ExecuteReader(dbCmd))
            {
                handler(idr);
            }
            SqlHelper.CloseConnection(dbCmd);
        }
    }
}
