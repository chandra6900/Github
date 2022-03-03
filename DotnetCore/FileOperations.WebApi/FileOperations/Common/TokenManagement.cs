using Newtonsoft.Json;

namespace FileOperations.Common
{
    [JsonObject("tokenManegement")]
    public class TokenManagement
    {
        [JsonProperty("JWKS")]
        public string JWKS { get; set; }

        [JsonProperty("issuer")]
        public string Issuer { get; set; }

        [JsonProperty("audience")]
        public string Audience { get; set; }

        [JsonProperty("accessExpiration")]
        public string AccessExpiration { get; set; }

        [JsonProperty("refreshExpiration ")]
        public int RefreshExpiration { get; set; }

        [JsonProperty("tokenDecodeURL")]
        public string TokenDecodeURL { get; set; }

        [JsonProperty("client_id")]
        public string ClientD { get; set; }

        [JsonProperty("scope")]
        public string Scope { get; set; }
    }
}
