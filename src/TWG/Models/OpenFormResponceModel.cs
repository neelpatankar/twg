using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace TWG.Models
{
  

    public class OpenFormResponceModel
    {

        [JsonProperty("fs_P5540G37_W5540G37A")]
        public FsP5540G37W5540G37A fs_P5540G37_W5540G37A { get; set; }

        [JsonProperty("stackId")]
        public int stackId { get; set; }

        [JsonProperty("stateId")]
        public int stateId { get; set; }

        [JsonProperty("rid")]
        public string rid { get; set; }

        [JsonProperty("currentApp")]
        public string currentApp { get; set; }

        [JsonProperty("timeStamp")]
        public string timeStamp { get; set; }

        [JsonProperty("sysErrors")]
        public IList<object> sysErrors { get; set; }
    }
}
