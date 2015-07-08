using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TT.Infr.ExternalServices.Data
{
    public class FwXml3d
    {
        [JsonProperty("model_id")]
        public string ModelId { get; set; }

        public string Model { get; set; }

        [JsonProperty("last_update")]
        public UpdateStampData LastUpdate { get; set; }

        public SourceData Source { get; set; }
    }
}
