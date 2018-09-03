using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using System.Data;

namespace BAL.stockmove
{
    public class stockmoveManager
    {
        stockmovedbManager dbManager = new stockmovedbManager();
        public int savestockmove(int stockmoveId, int srcbranchId, int desbranchId, int userId, DateTime regdate, bool isDel, int flag)
        {
            return dbManager.savestockmove(stockmoveId, srcbranchId, desbranchId, userId, regdate, isDel, flag);
        }
        public int savestockmoveItem(int stockmoveitemId, int stockmoveId, int categoryId, int productId, decimal unitprice, int stockqty, decimal totalunitamount, int flag)
        {
            return dbManager.savestockmoveItem(stockmoveitemId, stockmoveId, categoryId, productId, unitprice, stockqty, totalunitamount, flag);
        }
        public stockmoveCollection GetAllstockmove(int stockmoveId, int flag)
        {
            stockmoveCollection brColl = null;
            dbManager.GetAllstockmove(delegate (IDataReader dr)
            {
                using (dr)
                {
                    brColl = new stockmoveCollection();
                    while (dr.Read())
                    {
                        stockmove br = new stockmove();
                        br.stockmoveId = SqlHelper.GetInt(dr, "stockmoveId");
                        br.userId = SqlHelper.GetInt(dr, "userId");
                        br.srcbranchId = SqlHelper.GetInt(dr, "srcbranchId");
                        br.desbranchId = SqlHelper.GetInt(dr, "desbranchId");
                        br.regdate = SqlHelper.GetDateTime(dr, "regdate");
                        br.srcbranchname = SqlHelper.GetString(dr, "srcbranchname");
                        br.desbranchname = SqlHelper.GetString(dr, "desbranchname");
                        br.name = SqlHelper.GetString(dr, "name");
                        brColl.Add(br);
                    }
                }
            }, stockmoveId, flag);
            return brColl;
        }
        public stockmove getstockmove(int stockmoveId, int flag)
        {
            stockmove br = null;
            dbManager.GetAllstockmove(delegate (IDataReader dr)
            {
                using (dr)
                {
                    if (dr.Read())
                    {
                        br = new stockmove();
                        br.stockmoveId = SqlHelper.GetInt(dr, "stockmoveId");
                        br.userId = SqlHelper.GetInt(dr, "userId");
                        br.srcbranchId = SqlHelper.GetInt(dr, "srcbranchId");
                        br.desbranchId = SqlHelper.GetInt(dr, "desbranchId");
                        br.regdate = SqlHelper.GetDateTime(dr, "regdate");
                        br.srcbranchname = SqlHelper.GetString(dr, "srcbranchname");
                        br.desbranchname = SqlHelper.GetString(dr, "desbranchname");
                        br.name = SqlHelper.GetString(dr, "name");
                    }
                }
            }, stockmoveId, flag);
            return br;
        }
        public void deletestockmove(int stockmoveId, int flag)
        {
            dbManager.deletestockmove(stockmoveId, flag);
        }
    }
}
