using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BAL.customer
{
    public class customer : BaseEntity
    {
        public Int32 customerId
        {
            get;
            set;
        }
        public string cusname  
        {
            get;
            set;
        }
        public string mobileno
        {
            get;
            set;
        }
        public string telno
        {
            get;
            set;
        }
        public string email
        {
            get;
            set;
        }
        public string address
        {
            get;
            set;
        }
        public Int32 branchId
        {
            get;
            set;
        }
        public string branchname
        {
            get;
            set;
        }
        public Int32 companyId
        {
            get;
            set;
        }
        public string companyname
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
