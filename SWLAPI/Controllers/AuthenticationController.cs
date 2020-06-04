using System;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SWLAPI.Authentication;
using SWLAPI.Authentication.AuthScheme;
using SWLAPI.Services;

namespace SWLAPI.Controllers
{
    [Route("auth")]
    public class AuthenticationController : Controller
    {
        private readonly MainEventBus _mainEventBus;

        public AuthenticationController(MainEventBus mainEventBus)
        {
            _mainEventBus = mainEventBus;
        }

        public struct AuthenticationData
        {
            public UserAuthenticationType Type;
            public string Value;
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = SchemesNamesConst.SecretAuthenticationHandler)]
        public HttpStatusCode Post([FromBody] AuthenticationData authenticationData)
        {
            var retVal = default(HttpStatusCode);
            var authenticationType = authenticationData.Type;
            switch (authenticationType)
            {
                case UserAuthenticationType.EmailLink:
                    if (tryParseEmail(authenticationData.Value, out var mailAddress))
                    {
                        _mainEventBus.DoAuthByEmailLinkRequested(this, mailAddress);
                    }
                    else
                    {
                        //retVal = HttpStatusCode.BadRequest;
                        throw new NotImplementedException();
                    }

                    break;
                default:
                    throw new NotImplementedException();
//                    throw new NotSupportedException(string.Format("Тип аутентификации {0} не поддерживается",
//                        authenticationType));
//                    break;
            }

            return retVal;
        }

        static bool tryParseEmail(string email, out MailAddress mailAddress)
        {
            var retVal = false;
            mailAddress = default(MailAddress);
            try
            {
                var addr = new MailAddress(email);
                if (addr.Address == email)
                {
                    mailAddress = addr;
                    retVal = true;
                }
            }
            catch
            {
                retVal = false;
            }

            return retVal;
        }
    }
}