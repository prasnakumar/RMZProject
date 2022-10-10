using Microsoft.OpenApi.Models;

namespace WebApplication1
{
    internal class OAuth2Scheme : OpenApiSecurityScheme
    {
        public string Type { get; set; }
        public string Flow { get; set; }
        public string AuthorizationUrl { get; set; }
        public string TokenUrl { get; set; }
    }
}