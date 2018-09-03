using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using System.Data.Common;

namespace DAL
{
    public class userdbManager
    {
        public delegate void DataReaderHandler(IDataReader reader);
        Database db = SqlHelper.CreateConnection();
        public void GetAlluser(DataReaderHandler handler, int userId, int flag)
        {
            DbCommand dbCmd = db.GetStoredProcCommand(StoreProcedure.sp_user.ToString());
            db.AddInParameter(dbCmd, "@userId", DbType.Int32, userId);
            db.AddInParameter(dbCmd, "@usertypeId", DbType.Int32, 0);
            db.AddInParameter(dbCmd, "@name", DbType.String, "");
            db.AddInParameter(dbCmd, "@mobileno", DbType.String, "");
            db.AddInParameter(dbCmd, "@email", DbType.String, "");
            db.AddInParameter(dbCmd, "@address", DbType.String, "");
            db.AddInParameter(dbCmd, "@branchId", DbType.Int32, 0);
            db.AddInParameter(dbCmd, "@username", DbType.String, "");
            db.AddInParameter(dbCmd, "@password", DbType.String, "");
            db.AddInParameter(dbCmd, "@companyId", DbType.Int32, 0);
            db.AddInParameter(dbCmd, "@isDel", DbType.Boolean, false);
            db.AddInParameter(dbCmd, "@flag", DbType.Int32, flag);
            using (IDataReader idr = db.ExecuteReader(dbCmd))
            {
                handler(idr);
            }
            SqlHelper.CloseConnection(dbCmd);
        }
        public int saveuser(int userId, int usertypeId, string name, string mobileno, string email, string address, int branchId, string username,
            string password, int companyId, bool isDel, int flag)
        {
            DbCommand dbCmd = db.GetStoredProcCommand(StoreProcedure.sp_user.ToString());
            db.AddInParameter(dbCmd, "@userId", DbType.Int32, userId);
            db.AddInParameter(dbCmd, "@usertypeId", DbType.Int32, usertypeId);
            db.AddInParameter(dbCmd, "@name", DbType.String, name);
            db.AddInParameter(dbCmd, "@mobileno", DbType.String, mobileno);
            db.AddInParameter(dbCmd, "@email", DbType.String, email);
            db.AddInParameter(dbCmd, "@address", DbType.String, address);
            db.AddInParameter(dbCmd, "@branchId", DbType.Int32, branchId);
            db.AddInParameter(dbCmd, "@username", DbType.String, username);
            db.AddInParameter(dbCmd, "@password", DbType.String, password);
            db.AddInParameter(dbCmd, "@companyId", DbType.Int32, companyId);
            db.AddInParameter(dbCmd, "@isDel", DbType.Boolean, false);
            db.AddInParameter(dbCmd, "@flag", DbType.Int32, flag);
            return Convert.ToInt32(db.ExecuteScalar(dbCmd));
        }
        public void deleteuser(int userId, int flag)
        {
            DbCommand dbCmd = db.GetStoredProcCommand(StoreProcedure.sp_user.ToString());
            db.AddInParameter(dbCmd, "@userId", DbType.Int32, userId);
            db.AddInParameter(dbCmd, "@usertypeId", DbType.Int32, 0);
            db.AddInParameter(dbCmd, "@name", DbType.String, "");
            db.AddInParameter(dbCmd, "@mobileno", DbType.String, "");
            db.AddInParameter(dbCmd, "@email", DbType.String, "");
            db.AddInParameter(dbCmd, "@address", DbType.String, "");
            db.AddInParameter(dbCmd, "@branchId", DbType.Int32, 0);
            db.AddInParameter(dbCmd, "@username", DbType.String, "");
            db.AddInParameter(dbCmd, "@password", DbType.String, "");
            db.AddInParameter(dbCmd, "@companyId", DbType.Int32, 0);
            db.AddInParameter(dbCmd, "@isDel", DbType.Boolean, false);
            db.AddInParameter(dbCmd, "@flag", DbType.Int32, flag);
            db.ExecuteNonQuery(dbCmd);
        }
        public void getloginuser(DataReaderHandler handler, string username, string password, int flag)
        {
            DbCommand dbCmd = db.GetStoredProcCommand(StoreProcedure.sp_user.ToString());
            db.AddInParameter(dbCmd, "@userId", DbType.Int32, 0);
            db.AddInParameter(dbCmd, "@usertypeId", DbType.Int32, 0);
            db.AddInParameter(dbCmd, "@name", DbType.String, "");
            db.AddInParameter(dbCmd, "@mobileno", DbType.String, "");
            db.AddInParameter(dbCmd, "@email", DbType.String, "");
            db.AddInParameter(dbCmd, "@address", DbType.String, "");
            db.AddInParameter(dbCmd, "@branchId", DbType.Int32, 0);
            db.AddInParameter(dbCmd, "@username", DbType.String, username);
            db.AddInParameter(dbCmd, "@password", DbType.String, password);
            db.AddInParameter(dbCmd, "@companyId", DbType.Int32, 0);
            db.AddInParameter(dbCmd, "@isDel", DbType.Boolean, false);
            db.AddInParameter(dbCmd, "@flag", DbType.Int32, flag);
            using (IDataReader idr = db.ExecuteReader(dbCmd))
            {
                handler(idr);
            }
            SqlHelper.CloseConnection(dbCmd);
        }
    }
}
