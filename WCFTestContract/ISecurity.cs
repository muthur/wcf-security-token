﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCFTestContract;

namespace WCFTestService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ISecurity" in both code and config file together.
    [ServiceContract]
    public interface ISecurity
    {
        [OperationContract]
        LoginResult Login(string userId, string password);
    }
}
