using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace WCFTestContract
{
    [DataContract]
    public class Transaction
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public DateTime Date { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public Money Money { get; set; }
    }
}
