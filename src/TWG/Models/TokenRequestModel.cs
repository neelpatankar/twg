using System;
using Newtonsoft.Json;

namespace TWG.Models
{
    public class TokenRequestModel
    {
        [JsonProperty("deviceName")]
        public string deviceName { get; set; }

        [JsonProperty("username")]
        public string username { get; set; }

        [JsonProperty("password")]
        public string password { get; set; }
    }
}
