using System;
using TWG.Droid.HelperClasses;
using TWG.Interface;
using Xamarin.Forms;
using static Android.Provider.Settings;

[assembly: Xamarin.Forms.Dependency(typeof(UniqueIdAndroid))]
namespace TWG.Droid.HelperClasses
{

    public class UniqueIdAndroid:IDevice
    {
        public string GetIdentifier()
        {
            return Secure.GetString(Forms.Context.ContentResolver, Secure.AndroidId);
        }
    }
}
