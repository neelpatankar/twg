using System;
namespace TWG.Models
{
    public class AppStackRequestModel
    {
        public string token { get; set; }
        public string deviceName { get; set; }
        public bool aliasNaming { get; set; }
        public string action { get; set; }
        public bool allowCache { get; set; }
        public int stackId { get; set; }
        public int stateId { get; set; }
        public string rid { get; set; }
    }
}
