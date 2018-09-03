using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using System.Data;

namespace BAL.sale
{
    public class saleManager
    {
        saledbManager dbManager = new saledbManager();
        public int savesale(int saleId, int assignjobId, int customerId, int branchId, int userId, DateTime regdate, bool isDel, int flag)
        {
            return dbManager.savesale(saleId, assignjobId, customerId, branchId, userId, regdate, isDel, flag);
        }
        public int savesaleItem(int saleitemId, int saleId, int categoryId, int productId, decimal unitprice, int stockqty,int measurementQty, decimal totalunitamount, int flag)
        {
            return dbManager.savesaleItem(saleitemId, saleId, categoryId, productId, unitprice, stockqty, measurementQty, totalunitamount, flag);
        }
        public saleCollection GetAllsale(int saleId, int assignjobId, int flag)
        {
            saleCollection brColl = null;
            dbManager.GetAllsale(delegate (IDataReader dr)
            {
                using (dr)
                {
                    brColl = new saleCollection();
                    while (dr.Read())
                    {
                        sale br = new sale();
                        br.saleId = SqlHelper.GetInt(dr, "saleId");
                        br.assignjobId = SqlHelper.GetInt(dr, "assignjobId");
                        br.customerId = SqlHelper.GetInt(dr, "customerId");
                        br.userId = SqlHelper.GetInt(dr, "userId");
                        br.branchId = SqlHelper.GetInt(dr, "branchId");
                        br.regdate = SqlHelper.GetDateTime(dr, "regdate");
                        br.branchname = SqlHelper.GetString(dr, "branchname");
                        br.name = SqlHelper.GetString(dr, "name");
                        brColl.Add(br);
                    }
                }
            }, saleId, assignjobId, flag);
            return brColl;
        }
        public saleCollection searchInsale(int userId, int branchId, string datefrom, string dateto, int flag)
        {
            saleCollection brColl = null;
            dbManager.searchInsale(delegate (IDataReader dr)
            {
                using (dr)
                {
                    brColl = new saleCollection();
                    while (dr.Read())
                    {
                        sale br = new sale();
                        br.assignjobId = SqlHelper.GetInt(dr, "assignjobId");
                        br.cmlNo = SqlHelper.GetString(dr, "cmlNo");
                        br.regdate = SqlHelper.GetDateTime(dr, "regdate");
                        br.branchname = SqlHelper.GetString(dr, "branchname");
                        br.name = SqlHelper.GetString(dr, "name");
                        brColl.Add(br);
                    }
                }
            }, userId, branchId, datefrom, dateto, flag);
            return brColl;
        }
        public sale getsale(int saleId, int assignjobId, int flag)
        {
            sale br = null;
            dbManager.GetAllsale(delegate (IDataReader dr)
            {
                using (dr)
                {
                    if (dr.Read())
                    {
                        br = new sale();
                        br.saleId = SqlHelper.GetInt(dr, "saleId");
                        br.customerId = SqlHelper.GetInt(dr, "customerId");
                        br.userId = SqlHelper.GetInt(dr, "userId");
                        br.branchId = SqlHelper.GetInt(dr, "branchId");
                        br.regdate = SqlHelper.GetDateTime(dr, "regdate");
                        br.branchname = SqlHelper.GetString(dr, "branchname");
                        br.name = SqlHelper.GetString(dr, "name");
                    }
                }
            }, saleId, assignjobId, flag);
            return br;
        }
        public sale getassignjob(int saleId, int assignjobId, int flag)
        {
            sale br = null;
            dbManager.GetAllsale(delegate (IDataReader dr)
            {
                using (dr)
                {
                    if (dr.Read())
                    {
                        br = new sale();
                        br.userId = SqlHelper.GetInt(dr, "userId");
                        br.branchId = SqlHelper.GetInt(dr, "branchId");
                    }
                }
            }, saleId, assignjobId, flag);
            return br;
        }
        public void deletesale(int saleId, int flag)
        {
            dbManager.deletesale(saleId, flag);
        }
    }
}
