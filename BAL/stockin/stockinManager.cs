using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using System.Data;

namespace BAL.stockin
{
    public class stockinManager
    {
        stockindbManager dbManager = new stockindbManager();
        public int savestockin(int stockinId, int branchId, int userId, DateTime regdate, bool isDel, int flag)
        {
            return dbManager.savestockin(stockinId, branchId, userId, regdate, isDel, flag);
        }
        public int savestockinItem(int stockinitemId, int stockinId, int categoryId, int productId, decimal unitprice, int stockqty, decimal totalunitamount, int flag)
        {
            return dbManager.savestockinItem(stockinitemId, stockinId, categoryId, productId, unitprice, stockqty, totalunitamount, flag);
        }
        public stockinCollection GetAllstockin(int stockinId, int flag)
        {
            stockinCollection brColl = null;
            dbManager.GetAllstockin(delegate (IDataReader dr)
            {
                using (dr)
                {
                    brColl = new stockinCollection();
                    while (dr.Read())
                    {
                        stockin br = new stockin();
                        br.stockinId = SqlHelper.GetInt(dr, "stockinId");
                        br.userId = SqlHelper.GetInt(dr, "userId");
                        br.branchId = SqlHelper.GetInt(dr, "branchId");
                        br.regdate = SqlHelper.GetDateTime(dr, "regdate");
                        br.branchname = SqlHelper.GetString(dr, "branchname");
                        br.name = SqlHelper.GetString(dr, "name");
                        brColl.Add(br);
                    }
                }
            }, stockinId, flag);
            return brColl;
        }
        public stockin getstockin(int stockinId, int flag)
        {
            stockin br = null;
            dbManager.GetAllstockin(delegate (IDataReader dr)
            {
                using (dr)
                {
                    if (dr.Read())
                    {
                        br = new stockin();
                        br.stockinId = SqlHelper.GetInt(dr, "stockinId");
                        br.userId = SqlHelper.GetInt(dr, "userId");
                        br.branchId = SqlHelper.GetInt(dr, "branchId");
                        br.regdate = SqlHelper.GetDateTime(dr, "regdate");
                        br.branchname = SqlHelper.GetString(dr, "branchname");
                        br.name = SqlHelper.GetString(dr, "name");
                    }
                }
            }, stockinId, flag);
            return br;
        }
        public void deletestockin(int stockinId, int flag)
        {
            dbManager.deletestockin(stockinId, flag);
        }
    }
}
