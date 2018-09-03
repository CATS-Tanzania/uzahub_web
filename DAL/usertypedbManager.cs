using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using System.Data.Common;

namespace DAL
{
    public class usertypedbManager
    {
        public delegate void DataReaderHandler(IDataReader reader);
        Database db = SqlHelper.CreateConnection();
        public void GetAllusertype(DataReaderHandler handler, int usertypeId, int flag)
        {
            DbCommand dbCmd = db.GetStoredProcCommand(StoreProcedure.sp_usertype.ToString());
            db.AddInParameter(dbCmd, "@usertypeId", DbType.Int32, usertypeId);
            db.AddInParameter(dbCmd, "@usertypename", DbType.String, "");
            db.AddInParameter(dbCmd, "@isDel", DbType.Boolean, false);
            db.AddInParameter(dbCmd, "@flag", DbType.Int32, flag);
            using (IDataReader idr = db.ExecuteReader(dbCmd))
            {
                handler(idr);
            }
            SqlHelper.CloseConnection(dbCmd);
        }
        public int saveusertype(int usertypeId, string usertypename, bool isDel, int flag)
        {
            DbCommand dbCmd = db.GetStoredProcCommand(StoreProcedure.sp_usertype.ToString());
            db.AddInParameter(dbCmd, "@usertypeId", DbType.Int32, usertypeId);
            db.AddInParameter(dbCmd, "@usertypename", DbType.String, usertypename);
            db.AddInParameter(dbCmd, "@isDel", DbType.Boolean, isDel);
            db.AddInParameter(dbCmd, "@flag", DbType.Int32, flag);
            return Convert.ToInt32(db.ExecuteScalar(dbCmd));
        }
        public void deleteusertype(int usertypeId, int flag)
        {
            DbCommand dbCmd = db.GetStoredProcCommand(StoreProcedure.sp_usertype.ToString());
            db.AddInParameter(dbCmd, "@usertypeId", DbType.Int32, usertypeId);
            db.AddInParameter(dbCmd, "@usertypename", DbType.String, "");
            db.AddInParameter(dbCmd, "@isDel", DbType.Boolean, false);
            db.AddInParameter(dbCmd, "@flag", DbType.Int32, flag);
            db.ExecuteNonQuery(dbCmd);
        }
    }
}
