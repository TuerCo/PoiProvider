using TT.Infr.ExternalServices.Data.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TT.Infr.ExternalServices.Data
{
    [JsonConverter(typeof(ReferenceDataConverter))]
    public class ReferenceData
    {
        [JsonProperty("_def")]
        public string Default { get; set; }

        [JsonProperty("")]
        public string IndependentValue { get; set; }

        [JsonProperty("en")]
        public string EnValue { get; set; }

        public List<KeyValuePair<string, string>> KeyValues { get; set; }

        public ReferenceData()
        {
            KeyValues = new List<KeyValuePair<string, string>>();
        }
    }
}
