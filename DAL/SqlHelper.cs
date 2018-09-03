using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Data.Common;

namespace DAL
{
    public partial class SqlHelper
    {
        #region Methods

        internal static string GetConnectionString()
        {
            try
            {
                string connectionString = null;
                ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["Conn"];
                if (settings != null)
                {
                    connectionString = settings.ConnectionString;
                }
                return connectionString;
            }
            finally
            {
                SqlConnection con = new SqlConnection();
                con.Close();
            }
        }
        public static string GetDatabaseName(string connetionString)
        {
            var builder = new SqlConnectionStringBuilder(connetionString);
            return builder.InitialCatalog;
        }
        public static bool GetResetAllConnection(string connetionString)
        {
            var builder = new SqlConnectionStringBuilder(connetionString);
            return builder.ConnectionReset;
        }
        public static Database CreateConnection()
        {
            SqlDatabase db = new SqlDatabase(GetConnectionString());
            return db;
        }
        public static void CloseConnection(DbCommand dbCmd)
        {
            if (dbCmd.Connection != null)
            {
                if (dbCmd.Connection.State == ConnectionState.Open)
                {
                    dbCmd.Connection.Close();
                }
            }
        }
        public static bool GetBoolean(IDataReader rdr, string columnName)
        {
            int index = rdr.GetOrdinal(columnName);
            if (rdr.IsDBNull(index))
            {
                return false;
            }
            return Convert.ToBoolean(rdr[index]);
        }
        public static byte[] GetBytes(IDataReader rdr, string columnName)
        {
            int index = rdr.GetOrdinal(columnName);
            if (rdr.IsDBNull(index))
            {
                return null;
            }
            return (byte[])rdr[index];
        }
        public static DateTime GetDateTime(IDataReader rdr, string columnName)
        {
            int index = rdr.GetOrdinal(columnName);
            if (rdr.IsDBNull(index))
            {
                return DateTime.MinValue;
            }
            return (DateTime)rdr[index];
        }
        public static DateTime GetUtcDateTime(IDataReader rdr, string columnName)
        {
            int index = rdr.GetOrdinal(columnName);
            if (rdr.IsDBNull(index))
            {
                return DateTime.MinValue;
            }
            return DateTime.SpecifyKind((DateTime)rdr[index], DateTimeKind.Utc);
        }
        [Obsolete("This method will be removed from future Versions. Use GetUtcDateTime", true)]
        public static DateTime? GetNullableDateTime(IDataReader rdr, string columnName)
        {
            int index = rdr.GetOrdinal(columnName);
            if (rdr.IsDBNull(index))
            {
                return null;
            }
            return (DateTime)rdr[index];
        }
        public static DateTime? GetNullableUtcDateTime(IDataReader rdr, string columnName)
        {
            int index = rdr.GetOrdinal(columnName);
            if (rdr.IsDBNull(index))
            {
                return null;
            }
            return DateTime.SpecifyKind((DateTime)rdr[index], DateTimeKind.Utc);
        }
        public static decimal GetDecimal(IDataReader rdr, string columnName)
        {
            int index = rdr.GetOrdinal(columnName);
            if (rdr.IsDBNull(index))
            {
                return decimal.Zero;
            }
            return Convert.ToDecimal(rdr[index]);
        }
        public static double GetDouble(IDataReader rdr, string columnName)
        {
            int index = rdr.GetOrdinal(columnName);
            if (rdr.IsDBNull(index))
            {
                return 0.0;
            }
            return (double)rdr[index];
        }
        public static Int64 GetInt64(IDataReader rdr, string columnName)
        {
            int index = rdr.GetOrdinal(columnName);
            if (rdr.IsDBNull(index))
            {
                return 0;
            }
            return (Int64)rdr[index];
        }
        public static Guid GetGuid(IDataReader rdr, string columnName)
        {
            int index = rdr.GetOrdinal(columnName);
            if (rdr.IsDBNull(index))
            {
                return Guid.Empty;
            }
            return (Guid)rdr[index];
        }
        public static int GetInt(IDataReader rdr, string columnName)
        {
            int index = rdr.GetOrdinal(columnName);
            if (rdr.IsDBNull(index))
            {
                return 0;
            }
            return (int)rdr[index];
        }
        public static int? GetNullableInt(IDataReader rdr, string columnName)
        {
            int index = rdr.GetOrdinal(columnName);
            if (rdr.IsDBNull(index))
            {
                return null;
            }
            return (int)rdr[index];
        }
        public static string GetString(IDataReader rdr, string columnName)
        {
            int index = rdr.GetOrdinal(columnName);
            if (rdr.IsDBNull(index))
            {
                return string.Empty;
            }
            return (string)rdr[index];
        }
        #endregion
    }
}
