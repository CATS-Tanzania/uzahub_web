using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using System.Data;

namespace BAL.product
{
    public class productManager
    {
        productdbManager dbManager = new productdbManager();
        public int saveproduct(int productId, int categoryId, string productname, decimal buyprice, decimal sellprice, bool isDel, int flag)
        {
            return dbManager.saveproduct(productId, categoryId, productname, buyprice, sellprice, isDel, flag);
        }
        public productCollection GetAllproduct(int productId, int flag)
        {
            productCollection prColl = null;
            dbManager.GetAllproduct(delegate(IDataReader dr)
            {
                using (dr)
                {
                    prColl = new productCollection();
                    while (dr.Read())
                    {
                        product pr = new product();
                        pr.productId = SqlHelper.GetInt(dr, "productId");
                        pr.categoryId = SqlHelper.GetInt(dr, "categoryId");
                        pr.productname = SqlHelper.GetString(dr, "productname");
                        pr.categoryname = SqlHelper.GetString(dr, "categoryname");
                        pr.buyprice = SqlHelper.GetDecimal(dr, "buyprice");
                        pr.sellprice = SqlHelper.GetDecimal(dr, "sellprice");
                        prColl.Add(pr);
                    }
                }
            }, productId, flag);
            return prColl;
        }
        public product getproduct(int productId, int flag)
        {
            product pr = null;
            dbManager.GetAllproduct(delegate(IDataReader dr)
            {
                using (dr)
                {
                    if (dr.Read())
                    {
                        pr = new product();
                        pr.productId = SqlHelper.GetInt(dr, "productId");
                        pr.categoryId = SqlHelper.GetInt(dr, "categoryId");
                        pr.productname = SqlHelper.GetString(dr, "productname");
                        pr.categoryname = SqlHelper.GetString(dr, "categoryname");
                        pr.buyprice = SqlHelper.GetDecimal(dr, "buyprice");
                        pr.sellprice = SqlHelper.GetDecimal(dr, "sellprice");
                    }
                }
            }, productId, flag);
            return pr;
        }
        public void deleteproduct(int productId, int flag)
        {
            dbManager.deleteproduct(productId, flag);
        }
        public product getavlstockQty(int branchId, int productId, int flag)
        {
            product pr = null;
            dbManager.getavlstockQty(delegate (IDataReader dr)
            {
                using (dr)
                {
                    if (dr.Read())
                    {
                        pr = new product();
                        pr.avlstockQty = SqlHelper.GetInt(dr, "avlstockQty");
                    }
                }
            }, branchId, productId, flag);
            return pr;
        }
    }
}
