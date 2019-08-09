using System;
using Newtonsoft.Json;

namespace TWG.Model
{
    public class userInfo
    {
        [JsonProperty("token", NullValueHandling = NullValueHandling.Ignore)]
        public string token { get; set; }

        [JsonProperty("langPref", NullValueHandling = NullValueHandling.Ignore)]
        public string langPref { get; set; }

        [JsonProperty("locale", NullValueHandling = NullValueHandling.Ignore)]
        public string locale { get; set; }

        [JsonProperty("dateFormat", NullValueHandling = NullValueHandling.Ignore)]
        public string dateFormat { get; set; }

        [JsonProperty("dateSeperator", NullValueHandling = NullValueHandling.Ignore)]
        public string dateSeperator { get; set; }

        [JsonProperty("simpleDateFormat", NullValueHandling = NullValueHandling.Ignore)]
        public string simpleDateFormat { get; set; }

        [JsonProperty("decimalFormat", NullValueHandling = NullValueHandling.Ignore)]
        public string decimalFormat { get; set; }


        [JsonProperty("addressNumber", NullValueHandling = NullValueHandling.Ignore)]
        public int addressNumber { get; set; }


        [JsonProperty("alphaName", NullValueHandling = NullValueHandling.Ignore)]
        public string alphaName { get; set; }

        [JsonProperty("appsRelease", NullValueHandling = NullValueHandling.Ignore)]
        public string appsRelease { get; set; }

    }
}
