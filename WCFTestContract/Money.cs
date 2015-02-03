using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;


namespace WCFTestContract
{
    [DataContract]
    public class Money
    {
        public decimal Amount { get; set; }
        public CurrencyCode CurrencyCode { get; set; }
    }

    [DataContract]
    public enum CurrencyCode
    {
        [EnumMember]
        Usd = 100,
        [EnumMember]
        Inr = 101
    }
}
