using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BAL.branch
{
    public class branch : BaseEntity
    {
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
        public bool isdel
        {
            get;
            set;
        }
    }
}
