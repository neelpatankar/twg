using System;
using System.Collections.Generic;
using System.Linq;
using Prism;
using Prism.Ioc;
using TWG.Interface;

namespace TWG.iOS
{
    public class iOSInitializer : IPlatformInitializer
    {
        private static readonly UniqueIdIOS uniqueId = new UniqueIdIOS();
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterInstance<IDevice>(uniqueId);
            // Register Any Platform Specific Implementations that you cannot 
            // access from Shared Code
        }
    }
}
