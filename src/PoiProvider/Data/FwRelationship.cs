using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TT.Infr.ExternalServices.Data
{
    public class FwRelationship
    {
        public string Subject { get; set; }
        public ReferenceData Predicate { get; set; }
        public List<string> Objects { get; set; }

        [JsonProperty("last_update")]
        public UpdateStampData LastUpdate { get; set; }
    }
}
