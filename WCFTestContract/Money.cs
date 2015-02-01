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

    public enum CurrencyCode
    {
        Usd = 100,
        Inr = 101
    }
}
