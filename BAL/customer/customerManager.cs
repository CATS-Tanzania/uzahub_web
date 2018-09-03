using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using System.Data;
using BAL.customer;

namespace BAL.customer
{
    public class customerManager
    {
        customerdbManager dbManager = new customerdbManager();
        public int savecustomer(int customerId, string cusname, string mobileno, string telno, string email, string address, int branchId,
            int companyId, bool isDel, int flag)
        {
            return dbManager.savecustomer(customerId, cusname, mobileno, telno, email, address, branchId, companyId, isDel, flag);
        }
        public customerCollection GetAllcustomer(int customerId, int flag)
        {
            customerCollection brColl = null;
            dbManager.GetAllcustomer(delegate (IDataReader dr)
            {
                using (dr)
                {
                    brColl = new customerCollection();
                    while (dr.Read())
                    {
                        customer br = new customer();
                        br.customerId = SqlHelper.GetInt(dr, "customerId");
                        br.cusname = SqlHelper.GetString(dr, "cusname");
                        br.address = SqlHelper.GetString(dr, "address");
                        br.branchId = SqlHelper.GetInt(dr, "branchId");
                        br.companyId = SqlHelper.GetInt(dr, "companyId");
                        br.email = SqlHelper.GetString(dr, "email");
                        br.mobileno = SqlHelper.GetString(dr, "mobileno");
                        br.telno = SqlHelper.GetString(dr, "telno");
                        br.branchname = SqlHelper.GetString(dr, "branchname");
                        brColl.Add(br);
                    }
                }
            }, customerId, flag);
            return brColl;
        }
        public customer getcustomer(int customerId, int flag)
        {
            customer br = null;
            dbManager.GetAllcustomer(delegate (IDataReader dr)
            {
                using (dr)
                {
                    if (dr.Read())
                    {
                        br = new customer();
                        br.customerId = SqlHelper.GetInt(dr, "customerId");
                        br.cusname = SqlHelper.GetString(dr, "cusname");
                        br.address = SqlHelper.GetString(dr, "address");
                        br.branchId = SqlHelper.GetInt(dr, "branchId");
                        br.companyId = SqlHelper.GetInt(dr, "companyId");
                        br.email = SqlHelper.GetString(dr, "email");
                        br.mobileno = SqlHelper.GetString(dr, "mobileno");
                        br.telno = SqlHelper.GetString(dr, "telno");
                        br.branchname = SqlHelper.GetString(dr, "branchname");
                    }
                }
            }, customerId, flag);
            return br;
        }
        public void deletecustomer(int customerId, int flag)
        {
            dbManager.deletecustomer(customerId, flag);
        }
    }
}
