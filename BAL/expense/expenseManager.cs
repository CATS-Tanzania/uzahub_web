using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using System.Data;

namespace BAL.expense
{
    public class expenseManager
    {
        expensedbManager dbManager = new expensedbManager();
        public int saveexpense(int expenseId, int assignjobId, int branchId, int userId, DateTime regdate, bool isDel, int flag)
        {
            return dbManager.saveexpense(expenseId, assignjobId, branchId, userId, regdate, isDel, flag);
        }
        public int saveexpenseItem(int expenseitemId, int expenseId, int expensetypeId, decimal expamount, int flag)
        {
            return dbManager.saveexpenseItem(expenseitemId, expenseId, expensetypeId, expamount, flag);
        }
        public expenseCollection GetAllexpense(int expenseId, int flag)
        {
            expenseCollection brColl = null;
            dbManager.GetAllexpense(delegate (IDataReader dr)
            {
                using (dr)
                {
                    brColl = new expenseCollection();
                    while (dr.Read())
                    {
                        expense br = new expense();
                        br.expenseId = SqlHelper.GetInt(dr, "expenseId");
                        br.assignjobId = SqlHelper.GetInt(dr, "assignjobId");
                        br.userId = SqlHelper.GetInt(dr, "userId");
                        br.branchId = SqlHelper.GetInt(dr, "branchId");
                        br.regdate = SqlHelper.GetDateTime(dr, "regdate");
                        br.branchname = SqlHelper.GetString(dr, "branchname");
                        br.name = SqlHelper.GetString(dr, "name");
                        br.expamount = SqlHelper.GetDecimal(dr, "expamount");
                        br.isapprove = SqlHelper.GetBoolean(dr, "isapprove");
                        brColl.Add(br);
                    }
                }
            }, expenseId, flag);
            return brColl;
        }
        public expense getexpense(int expenseId, int flag)
        {
            expense br = null;
            dbManager.GetAllexpense(delegate (IDataReader dr)
            {
                using (dr)
                {
                    if (dr.Read())
                    {
                        br = new expense();
                        br.expenseId = SqlHelper.GetInt(dr, "expenseId");
                        br.assignjobId = SqlHelper.GetInt(dr, "assignjobId");
                        br.userId = SqlHelper.GetInt(dr, "userId");
                        br.branchId = SqlHelper.GetInt(dr, "branchId");
                        br.regdate = SqlHelper.GetDateTime(dr, "regdate");
                        br.branchname = SqlHelper.GetString(dr, "branchname");
                        br.name = SqlHelper.GetString(dr, "name");
                    }
                }
            }, expenseId, flag);
            return br;
        }
        public void deleteexpense(int expenseId, int flag)
        {
            dbManager.deleteexpense(expenseId, flag);
        }
        public void approveexpense(int expenseId, int userId, int flag)
        {
            dbManager.approveexpense(expenseId, userId, flag);
        }
        public expenseCollection searchInexpense(int userId, int branchId, string datefrom, string dateto, int flag)
        {
            expenseCollection brColl = null;
            dbManager.searchInexpense(delegate (IDataReader dr)
            {
                using (dr)
                {
                    brColl = new expenseCollection();
                    while (dr.Read())
                    {
                        expense br = new expense();
                        br.expenseId = SqlHelper.GetInt(dr, "expenseId");
                        br.userId = SqlHelper.GetInt(dr, "userId");
                        br.branchId = SqlHelper.GetInt(dr, "branchId");
                        br.regdate = SqlHelper.GetDateTime(dr, "regdate");
                        br.branchname = SqlHelper.GetString(dr, "branchname");
                        br.name = SqlHelper.GetString(dr, "name");
                        br.expamount = SqlHelper.GetDecimal(dr, "expamount");
                        br.isapprove = SqlHelper.GetBoolean(dr, "isapprove");
                        brColl.Add(br);
                    }
                }
            }, userId, branchId, datefrom, dateto, flag);
            return brColl;
        }
    }
}
