using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Web;
using System.Web.Mvc;
using MVCTestApp.AccountService;
using MVCTestApp.Models;
using MVCTestApp.SecurityService;

namespace MVCTestApp.Controllers
{
    public class HomeController : Controller
    {
        private SecurityClient securityClient;
        private AccountClient accountClient;

        private const string MESSAGE_HEADER_SECURITY_TOKEN = "security-token";
        private const string MESSAGE_HEADER_NAMESPACE = "TokenNameSpace";  
        private const string COOKIE_SECURITY_TOKEN = "stkn";

        //Service proxy object is injected. This to be later replaced using dependency injection like ninject
        public HomeController()
            : this(new SecurityClient(), new AccountClient())
        {

        }

        public HomeController(SecurityClient securityClient, AccountClient accountClient)
        {
            this.securityClient = securityClient;
            this.accountClient = accountClient;
        }


        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Account()
        {
            ViewBag.Message = "Account info";

            return View("Account", new AccountInfoViewModel()
            {
                AccountBalance = 0
            });
        }

        public ActionResult DoAuthenticate(UserCredentialViewModel userCredential)
        {
            ViewBag.Message = "Welcome User!";

            /*
             * Making our first request to validated user credential 
             * 1) On success we get the security-token
             * 2) Place the security token in cookie so that it could be used on subsequent request which ever requires it for authentication
             */
            var result = securityClient.Login(userCredential.UserName, userCredential.Password);
            if (result.LoginSuccess)
            {
                Response.Cookies.Add(new HttpCookie("STKN",result.SecurityToken));
            }
            else
            {
                ViewBag.Message = "Login failed!";
            }

            return View("Index");
        }

        public ActionResult ShowAccountInfo()
        {
            ViewBag.Message = "Welcome!";

            decimal balance = 0;

            try
            {
                using (var scope = new OperationContextScope(accountClient.InnerChannel))
                {

                    OperationContext.Current.OutgoingMessageHeaders.Add(GetSecurityTokenHeader());
                    var userInfoFromSession = new UserContextInfo()
                    {
                        //UserId = Session["userid"])
                        //BankBranch = Session["BankBranch"]
                        //ExtensionData = Session["sometablestructure"])
                    };

                    var accountBalance = accountClient.GetAccountBalance(userInfoFromSession);
                    balance = accountBalance.Amount;
                }
            }
            catch (FaultException fe)
            {

                ViewBag.Message = fe.Message;
            }
            
            return View("Account",new AccountInfoViewModel()
            {
                AccountBalance = balance
            });
        }

        private MessageHeader GetSecurityTokenHeader()
        {
            var securityTokeCookie = Request.Cookies.Get(COOKIE_SECURITY_TOKEN);
            //return MessageHeader.CreateHeader(MESSAGE_HEADER_SECURITY_TOKEN, MESSAGE_HEADER_NAMESPACE,securityTokeCookie != null ? securityTokeCookie.Value : string.Empty);

            var sessionTokenHeader = new MessageHeader<string>(securityTokeCookie != null ? securityTokeCookie.Value : string.Empty);
            return sessionTokenHeader.GetUntypedHeader(MESSAGE_HEADER_SECURITY_TOKEN, MESSAGE_HEADER_NAMESPACE);
        }
    }
}