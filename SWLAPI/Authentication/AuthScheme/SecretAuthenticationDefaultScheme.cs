using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;

namespace SWLAPI.Authentication.AuthScheme
{
    public class SecretAuthenticationHandler : AuthenticationHandler<SecretAuthenticationHandler.SecretAuthenticationSchemeOptions >
    {
//        Пример использования. Вставить перед методом
//        [Authorize(AuthenticationSchemes = SchemesNamesConst.SecretAuthenticationHandler)]
        private readonly string secret;
        public class SecretAuthenticationSchemeOptions : AuthenticationSchemeOptions
        {
        }

        public SecretAuthenticationHandler(IOptionsMonitor<SecretAuthenticationSchemeOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock, IConfiguration config)
            : base(options, logger, encoder, clock)
        {
            secret = config.GetSection("WebApp").GetValue<string>("AppKey");
        }

        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            var secret = Request.Headers["AppKey"];
            if (string.IsNullOrEmpty(secret))
            {
                return Task.FromResult(AuthenticateResult.Fail("Secret is null"));
            }

            if (secret != this.secret)
            {
                return Task.FromResult(AuthenticateResult.Fail("Secret is not valid"));
            }

            var claims = new[] { new Claim("secret", secret) };
            var identity = new ClaimsIdentity(claims, nameof(SecretAuthenticationHandler));
            var ticket = new AuthenticationTicket(new ClaimsPrincipal(identity), Scheme.Name);
            return Task.FromResult(AuthenticateResult.Success(ticket));
        }
    }
}
