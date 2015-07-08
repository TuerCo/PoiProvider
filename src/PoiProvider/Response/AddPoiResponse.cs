using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TT.Infr.ExternalServices.Response
{
    public class AddPoiResponse
    {
        [JsonProperty("created_poi")]
        public CreatedPoi CreatedPoi { get; set; }
    }

    public class CreatedPoi
    {
        public string Uuid { get; set; }
        public long Timestamp { get; set; }
    }
}
