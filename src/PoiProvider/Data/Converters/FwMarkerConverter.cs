using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TT.Infr.ExternalServices.Data.Converters
{
    public class FwMarkerConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return false;
        }

        public override bool CanWrite
        {
            get { return true; }
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var jo = serializer.Deserialize<JObject>(reader);

            var fwMarker = new FwMarker();

            foreach (var e in jo.Properties())
            {
                fwMarker.Name = e.Name;
                fwMarker.Marker = new MarkerData();
                var obj = e.Value as JObject;

                foreach (var v in obj.Properties())
                {
                    var prop = typeof(MarkerData).GetProperties().Where(x => x.GetCustomAttributes(typeof(JsonPropertyAttribute), false).FirstOrDefault() != null)
                                                    .Select(x =>
                                                    {
                                                        var jsonAttribute = (JsonPropertyAttribute)x.GetCustomAttributes(typeof(JsonPropertyAttribute), false).FirstOrDefault();
                                                        return new { Property = x, JsonName = jsonAttribute.PropertyName };
                                                    }).FirstOrDefault(x => x.JsonName == v.Name);

                    prop.Property.SetValue(fwMarker.Marker, v.Value.ToString());
                }
            }

            return fwMarker;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var marker = (FwMarker)value;

            writer.WriteStartObject();

            writer.WritePropertyName(marker.Name);

            serializer.Serialize(writer, marker.Marker);

            writer.WriteEndObject();
        }
    }
}
