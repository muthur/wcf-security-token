﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCFTestContract;

namespace WCFTestService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Security" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Security.svc or Security.svc.cs at the Solution Explorer and start debugging.
    public class Security : ISecurity
    {

        public LoginResult Login(string userId, string password)
        {
            //For simplicity sake returning a token based on GUID alone.
            //This part should take care of generating a strongly hashed token based on userid and password after validating the user credentials against the database.
            return new LoginResult() {SecurityToken = Convert.ToBase64String(Guid.NewGuid().ToByteArray())};
        }
    }
}
