using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TT.Infr.ExternalServices.Data
{
    public class FwCore
    {
        public List<string> Categories { get; set; }

        public LocationData Location { get; set; }

        public GeometryData Geometry { get; set; }

        public ReferenceData ShortName { get; set; }

        public ReferenceData Name { get; set; }

        public ReferenceData Label { get; set; }

        public ReferenceData Description { get; set; }

        public string Thumbnail { get; set; }

        public ReferenceData Url { get; set; }

        [JsonProperty("last_update")]
        public UpdateStampData LastUpdate { get; set; }

        public SourceData Source { get; set; }
    }
}
