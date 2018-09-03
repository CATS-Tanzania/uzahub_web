using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    internal enum StoreProcedure
    {
        sp_usertype,
        sp_branch,
        sp_user,
        sp_filldropdownList,
        sp_category,
        sp_product,
        sp_stockin,
        sp_stockinitem,
        sp_stockmove,
        sp_stockmoveitem,
        sp_avlstockQty,
        sp_customer,
        sp_assignjob,
        sp_assignjobitem,
        sp_expensetype,
        sp_expense,
        sp_expenseitem,
        sp_sale,
        sp_saleitem,
        sp_rp_searchInstockin,
        sp_rp_searchInassignjob,
        sp_rp_searchInsale,
        sp_rp_searchInexpense,
        sp_searchInassignjob,
        sp_searchInsale,
        sp_searchInexpense
    }
}
