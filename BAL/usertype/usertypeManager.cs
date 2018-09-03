using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using System.Data;

namespace BAL.usertype
{
    public class usertypeManager
    {
        usertypedbManager dbManager = new usertypedbManager();
        public int saveusertype(int usertypeId, string usertypename, Boolean isDel, int flag)
        {
            return dbManager.saveusertype(usertypeId, usertypename, isDel, flag);
        }
        public usertypeCollection GetAllusertype(int usertypeId, int flag)
        {
            usertypeCollection brColl = null;
            dbManager.GetAllusertype(delegate(IDataReader dr)
            {
                using (dr)
                {
                    brColl = new usertypeCollection();
                    while (dr.Read())
                    {
                        usertype br = new usertype();
                        br.usertypeId = SqlHelper.GetInt(dr, "usertypeId");
                        br.usertypename = SqlHelper.GetString(dr, "usertypename");
                        brColl.Add(br);
                    }
                }
            }, usertypeId, flag);
            return brColl;
        }
        public usertype getusertype(int usertypeId, int flag)
        {
            usertype br = null;
            dbManager.GetAllusertype(delegate(IDataReader dr)
            {
                using (dr)
                {
                    if (dr.Read())
                    {
                        br = new usertype();
                        br.usertypeId = SqlHelper.GetInt(dr, "usertypeId");
                        br.usertypename = SqlHelper.GetString(dr, "usertypename");
                    }
                }
            }, usertypeId, flag);
            return br;
        }
        public void deleteusertype(int usertypeId, int flag)
        {
            dbManager.deleteusertype(usertypeId, flag);
        }
    }
}
