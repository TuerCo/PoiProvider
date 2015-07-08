using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TT.Infr.ExternalServices.Data
{
    public class EntityData
    {
        public string Type { get; set; }
        [JsonProperty("short_label")]
        public ReferenceData ShortLabel { get; set; }
        public ReferenceData Caption { get; set; }
        public ReferenceData Description { get; set; }
        public string Thumbnail { get; set; }
        public string Url { get; set; }
        public string Copyright { get; set; }
    }
}
