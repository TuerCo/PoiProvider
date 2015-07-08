using TT.Infr.ExternalServices.Data.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TT.Infr.ExternalServices.Data
{
    [JsonConverter(typeof(PoiDataConverter))]
    public class PoiData
    {
        public string Id { get; set; }

        [JsonProperty("fw_core")]
        public FwCore Core { get; set; }

        [JsonProperty("fw_time")]
        public FwTime Time { get; set; }

        [JsonProperty("fw_xml3d")]
        public FwXml3d Xml3ds { get; set; }

        [JsonProperty("fw_contact")]
        public FwContact Contacts { get; set; }

        [JsonProperty("fw_media")]
        public FwMedia Media { get; set; }

        [JsonProperty("fw_relationships")]
        public List<FwRelationship> Relationships { get; set; }

        [JsonProperty("fw_marker")]
        public FwMarker Markers { get; set; }


    }
}
