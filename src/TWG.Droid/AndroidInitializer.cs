using System;
using System.Collections.Generic;
using System.Linq;
using Prism;
using Prism.Ioc;
using TWG.Droid.HelperClasses;
using TWG.Interface;

namespace TWG.Droid
{
    public class AndroidInitializer : IPlatformInitializer
    {
        private static readonly UniqueIdAndroid uniqueId = new UniqueIdAndroid();
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterInstance<IDevice>(uniqueId);
            // Register Any Platform Specific Implementations that you cannot 
            // access from Shared Code
        }
    }
}
