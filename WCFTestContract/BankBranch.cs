using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WCFTestContract
{
    public class BankBranch
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public BranchCategory Category { get; set; }
    }
}
