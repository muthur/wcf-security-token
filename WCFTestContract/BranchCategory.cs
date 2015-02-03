using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace WCFTestContract
{
    [DataContract]
    public enum BranchCategory
    {
        Category1 = 1,
        Category2 = 2
    }
}
