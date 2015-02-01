using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WCFTestContract
{
    public class Transaction
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public Money Money { get; set; }
    }
}
