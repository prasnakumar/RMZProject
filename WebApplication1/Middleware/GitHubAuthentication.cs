using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace WebApplication1.Middleware
{
    public class GitHubAuthentication: AuthenticationHandler<AuthenticationSchemeOptions>
    {
        public GitHubAuthentication(IOptionsMonitor<AuthenticationSchemeOptions> options, ILoggerFactory logger,
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
                var credentials = (authHeader.Parameter);
                var client = new RestClient("https://api.github.com/user");
                client.Timeout = -1;
                var request = new RestRequest(Method.GET);
                request.AddHeader("Authorization", $"Bearer  {credentials}");
                request.AddHeader("Cookie", "_octo=GH1.1.978743831.1665044809; logged_in=no");
                IRestResponse response = client.Execute(request);
                username = response.Content;
                Console.WriteLine(response.Content);
                if (response.StatusCode != System.Net.HttpStatusCode.OK)
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
