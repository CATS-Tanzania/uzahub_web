using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BAL.user
{
    public class user : BaseEntity
    {
        public Int32 userId
        {
            get;
            set;
        }
        public Int32 usertypeId
        {
            get;
            set;
        }
        public string name  
        {
            get;
            set;
        }
        public string mobileno
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
        public string username
        {
            get;
            set;
        }
        public string password
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
