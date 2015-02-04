using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Threading.Tasks;

namespace WCFTestContract
{
    public class CustomDispatchMessageInspector : IDispatchMessageInspector //IClientMessageInspector
    {
        private const string MESSAGE_HEADER_SECURITY_TOKEN = "security-token";
        private const string MESSAGE_HEADER_NAMESPACE = "TokenNameSpace";   

        #region IDispatchMessageInspector   (For service)
        public object AfterReceiveRequest(ref Message request, IClientChannel channel, InstanceContext instanceContext)
        {
            //TODO: Muthu- Currently this check is done for all the service method calls. Need to implement the exclution logic where we can execute methods by anonymous
            CheckIfRequestIsAuthentic(request);
            return null;
        }

        public void BeforeSendReply(ref Message reply, object correlationState)
        {
            
        }
        #endregion

        private void CheckIfRequestIsAuthentic(Message message)
        {
            if (message.Headers.FindHeader(MESSAGE_HEADER_SECURITY_TOKEN, MESSAGE_HEADER_NAMESPACE) == -1)
            {
                //Security token missing.
                throw new FaultException("Unauthenticated request. Security token not present in header");
            }

            var validUserToken = "dXNlcjFwYXNzd29yZDE="; //Temp value for the username:user1 & password:password1 combination. This needs to be modified with more realtime check (e.g) checking against the database
            var securityToken = message.Headers.GetHeader<string>(MESSAGE_HEADER_SECURITY_TOKEN, MESSAGE_HEADER_NAMESPACE);

            if (!string.IsNullOrEmpty(securityToken))
            {
                //Validate the security token passed in header
                if (securityToken != validUserToken)
                {
                    throw new FaultException("Unauthenticated request. Invalid Security token passed");
                }
                
            }
            else
            {
                //Empty security token passed
                throw new FaultException("Unauthenticated request. Invalid Security token passed");
            }


            
        }
    }
}
