using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace WebApplication1.Middleware
{
    public class BasicAuthentication : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        public BasicAuthentication(IOptionsMonitor<AuthenticationSchemeOptions> options,ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock) : base(options, logger, encoder, clock)
        {

        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {

            string username = null;
            try
            {
                var authHeader = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
                var credentials = Encoding.UTF8.GetString(Convert.FromBase64String(authHeader.Parameter)).Split(':');
                username = credentials.FirstOrDefault();
                var password = credentials.LastOrDefault();

                if (username != "prasanna" && password != "12")
                {
                    throw new ArgumentException("InValid");
                }
            }
            catch (Exception e)
            {
                return AuthenticateResult.Fail($"InValid user {e.Message}");
            }

            var claims = new[]
            {
                new Claim(ClaimTypes.Name,username)
        };
            var identify = new ClaimsIdentity(claims, Scheme.Name);
            var principle = new ClaimsPrincipal(identify);
            var ticket = new AuthenticationTicket(principle, Scheme.Name);

            return AuthenticateResult.Success(ticket);
        }
    }
}
