using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace WCFTestContract
{
    [DataContract]
    public class UserContextInfo
    {
        [DataMember]
        public int UserId { get; set; }

        [DataMember]
        public string UserName { get; set; }

        //[DataMember]
        //public TimeZoneInfo UserTimeZoneInfo { get; set; }  //Note: TimeZoneInfo cannot be serialized and this has to be handled diffferently

        [DataMember]
        public BankBranch BankBranch { get; set; }
        //Other user specific context info here
    }
}
