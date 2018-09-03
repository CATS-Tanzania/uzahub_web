using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using System.Data;

namespace BAL.assignjob
{
    public class assignjobManager
    {
        assignjobdbManager dbManager = new assignjobdbManager();
        public int saveassignjob(int assignjobId, String cmlNo, string truckNo, string driverName, string drvlncNo, string conductorName, int infuel
           , string omreadingarrival, string omreadingdeparture, int mileage, int outfuel, int branchId, int userId, DateTime regdate, bool isdel, int flag)
        {
            return dbManager.saveassignjob(assignjobId, cmlNo, truckNo, driverName, drvlncNo, conductorName, infuel,
           omreadingarrival, omreadingdeparture, mileage, outfuel, branchId, userId, regdate, isdel, flag);
        }
        public int saveassignjobItem(int assignjobitemId, int assignjobId, int categoryId, int productId, decimal unitprice, int stockqty,
            int measurementQty, decimal totalunitamount, int flag)
        {
            return dbManager.saveassignjobItem(assignjobitemId, assignjobId, categoryId, productId, unitprice, stockqty, measurementQty, totalunitamount, flag);
        }
        public assignjobCollection GetAllassignjob(int assignjobId, int flag)
        {
            assignjobCollection brColl = null;
            dbManager.GetAllassignjob(delegate (IDataReader dr)
            {
                using (dr)
                {
                    brColl = new assignjobCollection();
                    while (dr.Read())
                    {
                        assignjob br = new assignjob();
                        br.assignjobId = SqlHelper.GetInt(dr, "assignjobId");
                        br.cmlNo = SqlHelper.GetString(dr, "cmlNo");
                        br.infuel = SqlHelper.GetInt(dr, "infuel");
                        br.outfuel = SqlHelper.GetInt(dr, "outfuel");
                        br.mileage = SqlHelper.GetInt(dr, "mileage");
                        br.userId = SqlHelper.GetInt(dr, "userId");
                        br.branchId = SqlHelper.GetInt(dr, "branchId");
                        br.regdate = SqlHelper.GetDateTime(dr, "regdate");
                        br.branchname = SqlHelper.GetString(dr, "branchname");
                        br.name = SqlHelper.GetString(dr, "name");
                        br.truckNo = SqlHelper.GetString(dr, "truckNo");
                        br.driverName = SqlHelper.GetString(dr, "driverName");
                        br.drvlncNo = SqlHelper.GetString(dr, "drvlncNo");
                        br.conductorName = SqlHelper.GetString(dr, "conductorName");
                        br.omreadingarrival = SqlHelper.GetString(dr, "omreadingarrival");
                        br.omreadingdeparture = SqlHelper.GetString(dr, "omreadingdeparture");
                        brColl.Add(br);
                    }
                }
            }, assignjobId, flag);
            return brColl;
        }
        public assignjob getassignjob(int assignjobId, int flag)
        {
            assignjob br = null;
            dbManager.GetAllassignjob(delegate (IDataReader dr)
            {
                using (dr)
                {
                    if (dr.Read())
                    {
                        br = new assignjob();
                        br.assignjobId = SqlHelper.GetInt(dr, "assignjobId");
                        br.cmlNo = SqlHelper.GetString(dr, "cmlNo");
                        br.infuel = SqlHelper.GetInt(dr, "infuel");
                        br.outfuel = SqlHelper.GetInt(dr, "outfuel");
                        br.mileage = SqlHelper.GetInt(dr, "mileage");
                        br.userId = SqlHelper.GetInt(dr, "userId");
                        br.branchId = SqlHelper.GetInt(dr, "branchId");
                        br.regdate = SqlHelper.GetDateTime(dr, "regdate");
                        br.branchname = SqlHelper.GetString(dr, "branchname");
                        br.name = SqlHelper.GetString(dr, "name");
                        br.truckNo = SqlHelper.GetString(dr, "truckNo");
                        br.driverName = SqlHelper.GetString(dr, "driverName");
                        br.drvlncNo = SqlHelper.GetString(dr, "drvlncNo");
                        br.conductorName = SqlHelper.GetString(dr, "conductorName");
                        br.omreadingarrival = SqlHelper.GetString(dr, "omreadingarrival");
                        br.omreadingdeparture = SqlHelper.GetString(dr, "omreadingdeparture");
                    }
                }
            }, assignjobId, flag);
            return br;
        }
        public void deleteassignjob(int assignjobId, int flag)
        {
            dbManager.deleteassignjob(assignjobId, flag);
        }
        public assignjob getcmlNo(int assignjobId, int flag)
        {
            assignjob br = null;
            dbManager.GetAllassignjob(delegate (IDataReader dr)
            {
                using (dr)
                {
                    if (dr.Read())
                    {
                        br = new assignjob();
                        br.cmlNo = SqlHelper.GetString(dr, "cmlNo");
                    }
                }
            }, assignjobId, flag);
            return br;
        }
        public assignjob getavailableQty(int assignjobId, int productId, int measurementQty, int flag)
        {
            assignjob br = null;
            dbManager.getavailableQty(delegate (IDataReader dr)
            {
                using (dr)
                {
                    if (dr.Read())
                    {
                        br = new assignjob();
                        br.avlQty = SqlHelper.GetInt(dr, "avlQty");
                    }
                }
            }, assignjobId, productId, measurementQty, flag);
            return br;
        }
        public assignjobCollection searchInassignjob(int userId, int branchId, string datefrom, string dateto, int flag)
        {
            assignjobCollection brColl = null;
            dbManager.searchInassignjob(delegate (IDataReader dr)
            {
                using (dr)
                {
                    brColl = new assignjobCollection();
                    while (dr.Read())
                    {
                        assignjob br = new assignjob();
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
    }
}
