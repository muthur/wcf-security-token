using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFTestService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IAuthentication" in both code and config file together.
    [ServiceContract]
    public interface IAuthentication
    {
        [OperationContract]
        string Authenticate(string userId, string password);
    }
}
