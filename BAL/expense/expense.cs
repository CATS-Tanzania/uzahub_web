using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BAL.expense
{
    public class expense : BaseEntity
    {
        public Int32 expenseId
        {
            get;
            set;
        }
        public Int32 assignjobId
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
        public bool isapprove
        {
            get;
            set;
        }
        public Int32 expenseitemId
        {
            get;
            set;
        }
        public Int32 expensetypeId
        {
            get;
            set;
        }
        public decimal expamount
        {
            get;
            set;
        }
    }
}
