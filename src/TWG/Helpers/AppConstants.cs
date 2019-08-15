using System;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace TWG.Helpers
{
    public static class AppConstants
    {
        // Put constants here that are not of a sensitive nature
        public static string ApiUrl = "http://entdev-mosrv01.twg.pvt:8004";

        private static string token = "";
        public static string ApiHostName
        {
            get
            {
                var apiHostName = Regex.Replace(ApiUrl, @"^(?:http(?:s)?://)?(?:www(?:[0-9]+)?\.)?", string.Empty, RegexOptions.IgnoreCase)
                                   .Replace("/", string.Empty);
                return apiHostName;
            }
        }
        public static string AppToken
        {
            set
            {
                Xamarin.Forms.Application.Current.Properties["token"] = value;

            }
            get
            {
                if (Xamarin.Forms.Application.Current.Properties.ContainsKey("token"))
                {
                    return Xamarin.Forms.Application.Current.Properties["token"].ToString();
                }
                return token;
            }
        }

        public static string Rid
        {
            set
            {
                Xamarin.Forms.Application.Current.Properties["rid"] = value;

            }
            get
            {
                if (Xamarin.Forms.Application.Current.Properties.ContainsKey("rid"))
                {
                    return Xamarin.Forms.Application.Current.Properties["rid"].ToString();
                }
                return token;
            }
        }

    }
}
