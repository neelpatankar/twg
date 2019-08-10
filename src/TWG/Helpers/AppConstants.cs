using System;
using System.Text.RegularExpressions;

namespace TWG.Helpers
{
    public static class AppConstants
    {
        // Put constants here that are not of a sensitive nature
        public static string ApiUrl = "http://entdev-mosrv01.twg.pvt:8004";

        public static string ApiHostName
        {
            get
            {
                var apiHostName = Regex.Replace(ApiUrl, @"^(?:http(?:s)?://)?(?:www(?:[0-9]+)?\.)?", string.Empty, RegexOptions.IgnoreCase)
                                   .Replace("/", string.Empty);
                return apiHostName;
            }
        }
    }
}
