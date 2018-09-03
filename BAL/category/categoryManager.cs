using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using System.Data;

namespace BAL.category
{
    public class categoryManager
    {
        categorydbManager dbManager = new categorydbManager();
        public int savecategory(int categoryId, string categoryname, Boolean isDel, int flag)
        {
            return dbManager.savecategory(categoryId, categoryname, isDel, flag);
        }
        public categoryCollection GetAllcategory(int categoryId, int flag)
        {
            categoryCollection brColl = null;
            dbManager.GetAllcategory(delegate(IDataReader dr)
            {
                using (dr)
                {
                    brColl = new categoryCollection();
                    while (dr.Read())
                    {
                        category br = new category();
                        br.categoryId = SqlHelper.GetInt(dr, "categoryId");
                        br.categoryname = SqlHelper.GetString(dr, "categoryname");
                        brColl.Add(br);
                    }
                }
            }, categoryId, flag);
            return brColl;
        }
        public category getcategory(int categoryId, int flag)
        {
            category br = null;
            dbManager.GetAllcategory(delegate(IDataReader dr)
            {
                using (dr)
                {
                    if (dr.Read())
                    {
                        br = new category();
                        br.categoryId = SqlHelper.GetInt(dr, "categoryId");
                        br.categoryname = SqlHelper.GetString(dr, "categoryname");
                    }
                }
            }, categoryId, flag);
            return br;
        }
        public void deletecategory(int categoryId, int flag)
        {
            dbManager.deletecategory(categoryId, flag);
        }
    }
}
