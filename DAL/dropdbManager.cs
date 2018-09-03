using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace DAL
{
    public class dropdbManager
    {
        public delegate void DataReaderHandler(IDataReader reader);
        public static void filldropdownList(DataReaderHandler handler, string tablename, string column1, string column2, string column3, int condition)
        {
            Database db = SqlHelper.CreateConnection();
            DbCommand dbCmd = db.GetStoredProcCommand(StoreProcedure.sp_filldropdownList.ToString());
            db.AddInParameter(dbCmd, "@tablename", DbType.String, tablename);
            db.AddInParameter(dbCmd, "@column1", DbType.String, column1);
            db.AddInParameter(dbCmd, "@column2", DbType.String, column2);
            db.AddInParameter(dbCmd, "@column3", DbType.String, column3);
            db.AddInParameter(dbCmd, "@condition", DbType.String, condition);
            using (IDataReader dr = db.ExecuteReader(dbCmd))
            {
                handler(dr);
            }
            SqlHelper.CloseConnection(dbCmd);
        }
    }
}
