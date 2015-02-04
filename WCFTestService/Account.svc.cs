using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCFTestContract;
using WCFTestContract.Extensions;
using WCFTestService.Filters;



namespace WCFTestService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Account" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Account.svc or Account.svc.cs at the Solution Explorer and start debugging.

    [CustomServiceBehavior]
    public class Account : IAccount
    {
        //TODO: Try to figure out if it makes sense to move these constants to datacontract enums to be used across layer
        private const string MESSAGE_HEADER_SECURITY_TOKEN = "security-token";
        private const string MESSAGE_HEADER_NAMESPACE = "TokenNameSpace";

        public Money GetAccountBalance(UserContextInfo userContextInfo)
        {
            return new Money(){Amount = 2000, CurrencyCode = CurrencyCode.Inr};
        }

        public List<Transaction> GetRecentTransactions(UserContextInfo userContextInfo)
        {
            return new List<Transaction>()
            {
                new Transaction()
                {
                    Id = 1,
                    Date = DateTime.Now,
                    Description = "Trans description 1",
                    Money = new Money(){Amount = 100, CurrencyCode = CurrencyCode.Inr}
                },
                new Transaction()
                {
                    Id = 2,
                    Date = DateTime.Now,
                    Description = "Trans description 2",
                    Money = new Money(){Amount = 200, CurrencyCode = CurrencyCode.Inr}
                }
            };
        }

        
    }
}
