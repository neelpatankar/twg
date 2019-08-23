using System;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace TWG.Helpers
{
    public static class AppConstants
    {
        // Put constants here that are not of a sensitive nature
        private static string _apiUrl { get; set; } = "http://entdev-mosrv01.twg.pvt:8004";
        private static string _verison { get; set; } = "TWG0001";
        private static string _token { get; set; } = "";


        private static string _username { get; set; } = "RDHARA";
        private static string _password { get; set; } = "WELCOME1";

        private static string _rid { get; set; } = "";
        private static int _stackId { get; set; } = 1;
        private static int _stateId { get; set; } = 1;

        public static string Username
        {
            set
            {

                App.Current.Properties["username"] = value;

            }
            get
            {
                if (App.Current.Properties.ContainsKey("username"))
                {
                    return App.Current.Properties["username"].ToString();
                }
                return _username;
            }
        }

        public static string Password
        {
            set
            {

                App.Current.Properties["password"] = value;

            }
            get
            {
                if (App.Current.Properties.ContainsKey("password"))
                {
                    return App.Current.Properties["password"].ToString();
                }
                return _password;
            }
        }


        public static string Verison
        {
            set
            {

                App.Current.Properties["verison"] = value;

            }
            get
            {
                if (App.Current.Properties.ContainsKey("verison"))
                {
                    return App.Current.Properties["verison"].ToString();
                }
                return _verison;
            }
        }

        public static string ApiUrl
        {
            set
            {
                App.Current.Properties["apiUrl"] = value;

            }
            get
            {
                if (App.Current.Properties.ContainsKey("apiUrl"))
                {
                    return App.Current.Properties["apiUrl"].ToString();
                }
                return _apiUrl;
            }
        }

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
                App.Current.Properties["token"] = value;

            }
            get
            {
                if (App.Current.Properties.ContainsKey("token"))
                {
                    return App.Current.Properties["token"].ToString();
                }
                return _token;
            }
        }

        public static string Rid
        {
            set
            {
                App.Current.Properties["rid"] = value;

            }
            get
            {
                if (
                    App.Current.Properties.ContainsKey("rid"))
                {
                    return App.Current.Properties["rid"].ToString();
                }
                return _rid;
            }
        }


        public static int stackId
        {
            set
            {
                _stackId = value;

            }
            get
            {

                return _stackId;


            }
        }


        public static int stateId
        {
            set
            {
                _stateId = value;

            }
            get
            {

                return _stateId;
            }
        }
    }
}
