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

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
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

            return View("Index");
        }

        public ActionResult ShowAccountInfo()
        {
            ViewBag.Message = "Welcome!";

            using (var scope = new OperationContextScope(securityClient.InnerChannel))
            {

                OperationContext.Current.OutgoingMessageHeaders.Add(GetSecurityTokenHeader());

                var accountBalance = accountClient.GetAccountBalance(new UserContextInfo());
                //accountBalance.Amount
            }
            return View("Index");
        }

        private MessageHeader GetSecurityTokenHeader()
        {
            return MessageHeader.CreateHeader(MESSAGE_HEADER_SECURITY_TOKEN, "TokenNameSpace",
                Request.Cookies.AllKeys.Any(x => x == COOKIE_SECURITY_TOKEN) ? Request.Cookies.Get(COOKIE_SECURITY_TOKEN).Value : string.Empty);
        }
    }
}