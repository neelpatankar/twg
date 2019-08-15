using System;
namespace TWG.Models
{
    public class FormRequest
    {
        public string version { get; set; }
        public string formName { get; set; }
        public string formServiceAction { get; set; }
    }

    public class OpenFormRequestModel
    {
        public string token { get; set; }
        public string deviceName { get; set; }
        public string formServiceAction { get; set; }
        public bool allowCache { get; set; }
        public bool aliasNaming { get; set; }
        public string version { get; set; }
        public string formName { get; set; }
        public string action { get; set; }
        public FormRequest formRequest { get; set; }
        public int stackId { get; set; }
        public int stateId { get; set; }
    }

}
