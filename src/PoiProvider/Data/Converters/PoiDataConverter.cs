using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TT.Infr.ExternalServices.Data.Converters
{
    public class PoiDataConverter : JsonConverter
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
            throw new NotImplementedException();
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var poi = (PoiData)value;

            writer.WriteStartObject();

            if (!string.IsNullOrEmpty(poi.Id))
            {
                writer.WritePropertyName(poi.Id);
                writer.WriteStartObject();
            }

            WriteNewObject(writer, poi, serializer, "fw_core", poi.Core);
            WriteNewObject(writer, poi, serializer, "fw_time", poi.Time);
            WriteNewObject(writer, poi, serializer, "fw_xml3d", poi.Xml3ds);
            WriteNewObject(writer, poi, serializer, "fw_contact", poi.Contacts);
            WriteNewObject(writer, poi, serializer, "fw_media", poi.Media);
            WriteNewObject(writer, poi, serializer, "fw_relationships", poi.Relationships);
            WriteNewObject(writer, poi, serializer, "fw_marker", poi.Markers);

            if (!string.IsNullOrEmpty(poi.Id))
            {
                writer.WriteEndObject();
            }

            writer.WriteEndObject();
        }

        private void WriteNewObject(JsonWriter writer, PoiData poi, JsonSerializer serializer, string propertyName, object value)
        {
            if(value != null)
            {
                writer.WritePropertyName(propertyName);
                serializer.Serialize(writer, value);
            }

        }
    }
}
