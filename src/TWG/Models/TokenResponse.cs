using System;
using Newtonsoft.Json;

namespace TWG.Models
{
    public class TokenResponse
    {
        [JsonProperty("username")]
        public string username { get; set; }

        [JsonProperty("environment")]
        public string environment { get; set; }

        [JsonProperty("role")]
        public string role { get; set; }

        [JsonProperty("jasserver")]
        public string jasserver { get; set; }

        [JsonProperty("userAuthorized")]
        public string userAuthorized { get; set; }

        [JsonProperty("userInfo")]
        public userInfo userInfo { get; set; }

        [JsonProperty("version")]
        public string version { get; set; }

        [JsonProperty("poStringJSON")]
        public string poStringJSON { get; set; }

        [JsonProperty("altPoStringJSON")]

        public string altPoStringJSON { get; set; }

        [JsonProperty("aisSessionCookie")]
        public string aisSessionCookie { get; set; }

    }
}
