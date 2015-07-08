using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TT.Infr.ExternalServices.Data
{
    public class FwTime
    {
        public string Type { get; set; }
        public ScheduleData Schedule { get; set; }

        [JsonProperty("last_update")]
        public UpdateStampData LastUpdate { get; set; }

        public SourceData Source { get; set; }
    }
}
