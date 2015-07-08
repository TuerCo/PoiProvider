using TT.Infr.ExternalServices.Data.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TT.Infr.ExternalServices.Data
{
    [JsonConverter(typeof(FwMarkerConverter))]
    public class FwMarker
    {
        public string Name { get; set; }
        public MarkerData Marker { get; set; }
    }
}
