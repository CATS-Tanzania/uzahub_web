using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BAL.stockmove
{
    public class stockmove : BaseEntity
    {
        public Int32 stockmoveId
        {
            get;
            set;
        }
        public Int32 srcbranchId
        {
            get;
            set;
        }
        public Int32 desbranchId
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
        public string srcbranchname
        {
            get;
            set;
        }
        public string desbranchname
        {
            get;
            set;
        }
        public bool isdel
        {
            get;
            set;
        }
        public Int32 stockmoveitemId
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
