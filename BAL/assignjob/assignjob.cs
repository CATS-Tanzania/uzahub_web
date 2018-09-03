using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BAL.assignjob
{
    public class assignjob : BaseEntity
    {
        public Int32 assignjobId
        {
            get;
            set;
        }
        public string cmlNo
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
        public Int32 infuel
        {
            get;
            set;
        }
        public Int32 outfuel
        {
            get;
            set;
        }
        public Int32 mileage
        {
            get;
            set;
        }
        public DateTime regdate
        {
            get;
            set;
        }
        public string truckNo
        {
            get;
            set;
        }
        public string driverName
        {
            get;
            set;
        }
        public string drvlncNo
        {
            get;
            set;
        }
        public string conductorName
        {
            get;
            set;
        }
        public string omreadingarrival
        {
            get;
            set;
        }
        public string omreadingdeparture
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
        public Int32 assignjobitemId
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
        public int avlQty
        {
            get;
            set;
        }
    }
}
