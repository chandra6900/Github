using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace FileOperations.Common
{
    public static class Utilities
    {
        public static IConfiguration Configuration { get; set; }
        public static List<SecurityKey> JWKSIssuerSigningKeyResolver(string token, SecurityToken securityToken, string kid, TokenValidationParameters validatiorparmeters)
        {
            TokenManagement tokenConfiguration = Configuration.GetSection("tokenManagement").Get<TokenManagement>();
            var jwksJson = GetKeysAsync(tokenConfiguration.JWKS).GetAwaiter().GetResult();
            var jwks = new JsonWebKeySet(jwksJson);
            validatiorparmeters.IssuerSigningKeys = jwks.GetSigningKeys().ToList();
            return jwks.GetSigningKeys().ToList();
        }

        public static async Task<string> GetKeysAsync(string path)
        {
            var handler = new HttpClientHandler();
            var client = new HttpClient(handler);
            string keys = null;
            HttpResponseMessage response = await client.GetAsync(path);

            if (response.IsSuccessStatusCode)
            {
                keys = await response.Content.ReadAsStringAsync();
            }
            return keys;
        }
    }
}

