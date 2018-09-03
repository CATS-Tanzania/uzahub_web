using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using System.Data.Common;

namespace DAL
{
    public class customerdbManager
    {
        public delegate void DataReaderHandler(IDataReader reader);
        Database db = SqlHelper.CreateConnection();
        public void GetAllcustomer(DataReaderHandler handler, int customerId, int flag)
        {
            DbCommand dbCmd = db.GetStoredProcCommand(StoreProcedure.sp_customer.ToString());
            db.AddInParameter(dbCmd, "@customerId", DbType.Int32, customerId);
            db.AddInParameter(dbCmd, "@cusname", DbType.String, "");
            db.AddInParameter(dbCmd, "@mobileno", DbType.String, "");
            db.AddInParameter(dbCmd, "@telno", DbType.String, "");
            db.AddInParameter(dbCmd, "@email", DbType.String, "");
            db.AddInParameter(dbCmd, "@address", DbType.String, "");
            db.AddInParameter(dbCmd, "@branchId", DbType.Int32, 0);
            db.AddInParameter(dbCmd, "@companyId", DbType.Int32, 0);
            db.AddInParameter(dbCmd, "@isDel", DbType.Boolean, false);
            db.AddInParameter(dbCmd, "@flag", DbType.Int32, flag);
            using (IDataReader idr = db.ExecuteReader(dbCmd))
            {
                handler(idr);
            }
            SqlHelper.CloseConnection(dbCmd);
        }
        public int savecustomer(int customerId, string cusname, string mobileno, string telno, string email, string address, int branchId, 
            int companyId, bool isDel, int flag)
        {
            DbCommand dbCmd = db.GetStoredProcCommand(StoreProcedure.sp_customer.ToString());
            db.AddInParameter(dbCmd, "@customerId", DbType.Int32, customerId);
            db.AddInParameter(dbCmd, "@cusname", DbType.String, cusname);
            db.AddInParameter(dbCmd, "@mobileno", DbType.String, mobileno);
            db.AddInParameter(dbCmd, "@telno", DbType.String, telno);
            db.AddInParameter(dbCmd, "@email", DbType.String, email);
            db.AddInParameter(dbCmd, "@address", DbType.String, address);
            db.AddInParameter(dbCmd, "@branchId", DbType.Int32, branchId);
            db.AddInParameter(dbCmd, "@companyId", DbType.Int32, companyId);
            db.AddInParameter(dbCmd, "@isDel", DbType.Boolean, false);
            db.AddInParameter(dbCmd, "@flag", DbType.Int32, flag);
            return Convert.ToInt32(db.ExecuteScalar(dbCmd));
        }
        public void deletecustomer(int customerId, int flag)
        {
            DbCommand dbCmd = db.GetStoredProcCommand(StoreProcedure.sp_customer.ToString());
            db.AddInParameter(dbCmd, "@customerId", DbType.Int32, customerId);
            db.AddInParameter(dbCmd, "@cusname", DbType.String, "");
            db.AddInParameter(dbCmd, "@mobileno", DbType.String, "");
            db.AddInParameter(dbCmd, "@telno", DbType.String, "");
            db.AddInParameter(dbCmd, "@email", DbType.String, "");
            db.AddInParameter(dbCmd, "@address", DbType.String, "");
            db.AddInParameter(dbCmd, "@branchId", DbType.Int32, 0);
            db.AddInParameter(dbCmd, "@companyId", DbType.Int32, 0);
            db.AddInParameter(dbCmd, "@isDel", DbType.Boolean, false);
            db.AddInParameter(dbCmd, "@flag", DbType.Int32, flag);
            db.ExecuteNonQuery(dbCmd);
        }
    }
}
