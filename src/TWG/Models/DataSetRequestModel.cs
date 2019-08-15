using System;
using System.Collections.Generic;

namespace TWG.Models
{

    public class FormAction
    {
        public string command { get; set; }
        public string controlID { get; set; }
        public string value { get; set; }
    }

    public class ActionRequest
    {
        public IList<FormAction> formActions { get; set; }
        public string formOID { get; set; }
    }

    public class DataSetRequestModel
    {
        public string token { get; set; }
        public string deviceName { get; set; }
        public bool aliasNaming { get; set; }
        public string action { get; set; }
        public string formServiceAction { get; set; }
        public bool allowCache { get; set; }
        public ActionRequest actionRequest { get; set; }
        public int stackId { get; set; }
        public int stateId { get; set; }
        public string rid { get; set; }
    }
}
