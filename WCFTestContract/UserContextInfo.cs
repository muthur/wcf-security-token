﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WCFTestContract
{
    public class UserContextInfo
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public TimeZoneInfo UserTimeZoneInfo { get; set; }
        public BankBranch BankBranch { get; set; }
        //Other user specific context info here
    }
}
