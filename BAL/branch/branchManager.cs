using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using System.Data;

namespace BAL.branch
{
    public class branchManager
    {
        branchdbManager dbManager = new branchdbManager();
        public int savebranch(int branchId, string branchname, Boolean isDel, int flag)
        {
            return dbManager.savebranch(branchId, branchname, isDel, flag);
        }
        public branchCollection GetAllbranch(int branchId, int flag)
        {
            branchCollection brColl = null;
            dbManager.GetAllbranch(delegate(IDataReader dr)
            {
                using (dr)
                {
                    brColl = new branchCollection();
                    while (dr.Read())
                    {
                        branch br = new branch();
                        br.branchId = SqlHelper.GetInt(dr, "branchId");
                        br.branchname = SqlHelper.GetString(dr, "branchname");
                        brColl.Add(br);
                    }
                }
            }, branchId, flag);
            return brColl;
        }
        public branch getbranch(int branchId, int flag)
        {
            branch br = null;
            dbManager.GetAllbranch(delegate(IDataReader dr)
            {
                using (dr)
                {
                    if (dr.Read())
                    {
                        br = new branch();
                        br.branchId = SqlHelper.GetInt(dr, "branchId");
                        br.branchname = SqlHelper.GetString(dr, "branchname");
                    }
                }
            }, branchId, flag);
            return br;
        }
        public void deletebranch(int branchId, int flag)
        {
            dbManager.deletebranch(branchId, flag);
        }
    }
}
