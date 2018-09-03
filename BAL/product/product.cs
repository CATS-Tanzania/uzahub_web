using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BAL.product
{
    public class product : BaseEntity
    {
        public Int32 productId
        {
            get;
            set;
        }
        public Int32 categoryId
        {
            get;
            set;
        }
        public Int32 avlstockQty
        {
            get;
            set;
        }
        public string productname
        {
            get;
            set;
        }
        public string categoryname
        {
            get;
            set;
        }
        public decimal buyprice
        {
            get;
            set;
        }
        public decimal sellprice
        {
            get;
            set;
        }
        public bool isdel
        {
            get;
            set;
        }
    }
}
