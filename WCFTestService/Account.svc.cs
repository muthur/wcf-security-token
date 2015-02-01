using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCFTestContract;
using WCFTestService.Filters;



namespace WCFTestService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Account" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Account.svc or Account.svc.cs at the Solution Explorer and start debugging.
    public class Account : IAccount
    {

        [Secured]
        public Money GetAccountBalance()
        {
            throw new NotImplementedException();
        }

        [Secured]
        public List<Transaction> GetRecentTransactions()
        {
            throw new NotImplementedException();
        }
    }
}
