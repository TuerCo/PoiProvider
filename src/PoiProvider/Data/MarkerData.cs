using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TT.Infr.ExternalServices.Data
{
    public class MarkerData
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("image_ref")]
        public string ImageRef { get; set; }
    }
}
