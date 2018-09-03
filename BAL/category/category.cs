using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BAL.category
{
    public class category : BaseEntity
    {
        public Int32 categoryId
        {
            get;
            set;
        }
        public string categoryname
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
