using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using System.Data;
using BAL.user;

namespace BAL.user
{
    public class userManager
    {
        userdbManager dbManager = new userdbManager();
        public int saveuser(int userId, int usertypeId, string name, string mobileno, string email, string address, int branchId, string username,
            string password, int companyId, bool isDel, int flag)
        {
            return dbManager.saveuser(userId, usertypeId, name, mobileno, email, address, branchId, username, password, companyId, isDel, flag);
        }
        public userCollection GetAlluser(int userId, int flag)
        {
            userCollection brColl = null;
            dbManager.GetAlluser(delegate (IDataReader dr)
            {
                using (dr)
                {
                    brColl = new userCollection();
                    while (dr.Read())
                    {
                        user br = new user();
                        br.userId = SqlHelper.GetInt(dr, "userId");
                        br.username = SqlHelper.GetString(dr, "username");
                        br.password = SqlHelper.GetString(dr, "password");
                        br.address = SqlHelper.GetString(dr, "address");
                        br.branchId = SqlHelper.GetInt(dr, "branchId");
                        br.companyId = SqlHelper.GetInt(dr, "companyId");
                        br.email = SqlHelper.GetString(dr, "email");
                        br.mobileno = SqlHelper.GetString(dr, "mobileno");
                        br.name = SqlHelper.GetString(dr, "name");
                        br.branchname = SqlHelper.GetString(dr, "branchname");
                        br.usertypeId = SqlHelper.GetInt(dr, "usertypeId");
                        brColl.Add(br);
                    }
                }
            }, userId, flag);
            return brColl;
        }
        public user getuser(int userId, int flag)
        {
            user br = null;
            dbManager.GetAlluser(delegate (IDataReader dr)
            {
                using (dr)
                {
                    if (dr.Read())
                    {
                        br = new user();
                        br.userId = SqlHelper.GetInt(dr, "userId");
                        br.username = SqlHelper.GetString(dr, "username");
                        br.password = SqlHelper.GetString(dr, "password");
                        br.address = SqlHelper.GetString(dr, "address");
                        br.branchId = SqlHelper.GetInt(dr, "branchId");
                        br.companyId = SqlHelper.GetInt(dr, "companyId");
                        br.email = SqlHelper.GetString(dr, "email");
                        br.mobileno = SqlHelper.GetString(dr, "mobileno");
                        br.name = SqlHelper.GetString(dr, "name");
                        br.branchname = SqlHelper.GetString(dr, "branchname");
                        br.usertypeId = SqlHelper.GetInt(dr, "usertypeId");
                    }
                }
            }, userId, flag);
            return br;
        }
        public void deleteuser(int userId, int flag)
        {
            dbManager.deleteuser(userId, flag);
        }
        public user getloginuser(string username, string password, int flag)
        {
            user br = null;
            dbManager.getloginuser(delegate (IDataReader dr)
            {
                using (dr)
                {
                    if (dr.Read())
                    {
                        br = new user();
                        br.userId = SqlHelper.GetInt(dr, "userId");
                        br.branchId = SqlHelper.GetInt(dr, "branchId");
                        br.name = SqlHelper.GetString(dr, "name");
                        br.password = SqlHelper.GetString(dr, "password");
                    }
                }
            }, username, password, flag);
            return br;
        }
    }
}
