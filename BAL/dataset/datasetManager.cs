using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using System.Data;

namespace BAL.dataset
{
    public class datasetManager
    {
        datasetdbManager dbManager = new datasetdbManager();

        public DataSet GetAllstockinItem(int stockinId, int flag)
        {
            return dbManager.GetAllstockinItem(stockinId, flag);
        }
        public DataSet GetAllstockmoveItem(int stockmoveId, int flag)
        {
            return dbManager.GetAllstockmoveItem(stockmoveId, flag);
        }
        public DataSet GetAllassignjobItem(int assignjobId, int flag)
        {
            return dbManager.GetAllassignjobItem(assignjobId, flag);
        }
        public DataSet GetAllexpenseItem(int expenseId, int flag)
        {
            return dbManager.GetAllexpenseItem(expenseId, flag);
        }
        public DataSet GetAllsaleItem(int saleId, int flag)
        {
            return dbManager.GetAllsaleItem(saleId, flag);
        }
        public DataSet rp_searchInstockin(int branchId, int userId, string datefrom, string dateto, int flag)
        {
            return dbManager.rp_searchInstockin(branchId, userId, datefrom, dateto, flag);
        }
        public DataSet rp_searchInassignjob(int branchId, int userId, string datefrom, string dateto, int flag)
        {
            return dbManager.rp_searchInassignjob(branchId, userId, datefrom, dateto, flag);
        }
        public DataSet rp_searchInsale(int branchId, int userId, string datefrom, string dateto, int flag)
        {
            return dbManager.rp_searchInsale(branchId, userId, datefrom, dateto, flag);
        }
        public DataSet rp_searchInexpense(int branchId, int userId, string datefrom, string dateto, int flag)
        {
            return dbManager.rp_searchInexpense(branchId, userId, datefrom, dateto, flag);
        }
    }
}
