using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BAL.usertype
{
    public class usertype : BaseEntity
    {
        public Int32 usertypeId
        {
            get;
            set;
        }
        public string usertypename
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
