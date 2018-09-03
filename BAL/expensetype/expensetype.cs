using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BAL.expensetype
{
    public class expensetype : BaseEntity
    {
        public Int32 expensetypeId
        {
            get;
            set;
        }
        public string expensetypename
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
