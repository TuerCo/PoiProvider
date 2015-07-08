using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TT.Infr.ExternalServices.Data
{
    public class FwMedia
    {
        public List<EntityData> Entities { get; set; }

        [JsonProperty("last_update")]
        public UpdateStampData LastUpdate { get; set; }
    }
}
