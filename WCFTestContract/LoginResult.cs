using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace WCFTestContract
{
    [DataContract]
    public class LoginResult
    {
        [DataMember]
        public bool LoginSuccess { get; set; }

        [DataMember]
        public string SecurityToken { get; set; }
        /*
         * Other  required information to be returned as part of the login result like,
         * 1) login status
         * etc.
         */
    }
}
