using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TT.Infr.ExternalServices.Data
{
    public class FwContact
    {
        public string Visit { get; set; }
        public List<string> Postal { get; set; }
        public string Mailto { get; set; }
        public string Phone { get; set; }

        [JsonProperty("last_update")]
        public UpdateStampData LastUpdate { get; set; }

        public SourceData Source { get; set; }
    }
}
