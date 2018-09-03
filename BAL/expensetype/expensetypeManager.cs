using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using System.Data;

namespace BAL.expensetype
{
    public class expensetypeManager
    {
        expensetypedbManager dbManager = new expensetypedbManager();
        public int saveexpensetype(int expensetypeId, string expensetypename, Boolean isDel, int flag)
        {
            return dbManager.saveexpensetype(expensetypeId, expensetypename, isDel, flag);
        }
        public expensetypeCollection GetAllexpensetype(int expensetypeId, int flag)
        {
            expensetypeCollection brColl = null;
            dbManager.GetAllexpensetype(delegate(IDataReader dr)
            {
                using (dr)
                {
                    brColl = new expensetypeCollection();
                    while (dr.Read())
                    {
                        expensetype br = new expensetype();
                        br.expensetypeId = SqlHelper.GetInt(dr, "expensetypeId");
                        br.expensetypename = SqlHelper.GetString(dr, "expensetypename");
                        brColl.Add(br);
                    }
                }
            }, expensetypeId, flag);
            return brColl;
        }
        public expensetype getexpensetype(int expensetypeId, int flag)
        {
            expensetype br = null;
            dbManager.GetAllexpensetype(delegate(IDataReader dr)
            {
                using (dr)
                {
                    if (dr.Read())
                    {
                        br = new expensetype();
                        br.expensetypeId = SqlHelper.GetInt(dr, "expensetypeId");
                        br.expensetypename = SqlHelper.GetString(dr, "expensetypename");
                    }
                }
            }, expensetypeId, flag);
            return br;
        }
        public void deleteexpensetype(int expensetypeId, int flag)
        {
            dbManager.deleteexpensetype(expensetypeId, flag);
        }
    }
}
