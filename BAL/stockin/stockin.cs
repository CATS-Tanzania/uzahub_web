using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BAL.stockin
{
    public class stockin : BaseEntity
    {
        public Int32 stockinId
        {
            get;
            set;
        }
        public Int32 branchId
        {
            get;
            set;
        }
        public Int32 userId
        {
            get;
            set;
        }
        public DateTime regdate
        {
            get;
            set;
        }
        public string name
        {
            get;
            set;
        }
        public string branchname
        {
            get;
            set;
        }
        public bool isdel
        {
            get;
            set;
        }
        public Int32 stockinitemId
        {
            get;
            set;
        }
        public Int32 stockqty
        {
            get;
            set;
        }
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
        public decimal unitprice
        {
            get;
            set;
        }
        public decimal totalunitamount
        {
            get;
            set;
        }
        public string productname
        {
            get;
            set;
        }
    }
}
