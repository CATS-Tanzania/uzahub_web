using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BAL.sale
{
    public class sale : BaseEntity
    {
        public Int32 saleId
        {
            get;
            set;
        }
        public Int32 assignjobId
        {
            get;
            set;
        }
        public Int32 customerId
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
        public string cmlNo
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
        public Int32 saleitemId
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
