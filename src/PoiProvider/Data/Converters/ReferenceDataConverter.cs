using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TT.Infr.ExternalServices.Data.Converters
{
    public class ReferenceDataConverter : JsonConverter
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

            var refData = new ReferenceData();

            foreach (var e in jo.Properties())
            {
                var prop = objectType.GetProperties().Where(x => x.GetCustomAttributes(typeof(JsonPropertyAttribute), false).FirstOrDefault() != null)
                                                    .Select(x =>
                                                    {
                                                        var jsonAttribute = (JsonPropertyAttribute)x.GetCustomAttributes(typeof(JsonPropertyAttribute), false).FirstOrDefault();
                                                        return new { Property = x, JsonName = jsonAttribute.PropertyName };
                                                    }).FirstOrDefault(x => x.JsonName == e.Name);

                if (prop != null)
                {
                    prop.Property.SetValue(refData, e.Value.ToString());
                }
                else
                {
                    if (refData.KeyValues == null)
                    {
                        refData.KeyValues = new List<KeyValuePair<string, string>>();
                    }
                    refData.KeyValues.Add(new KeyValuePair<string, string>(e.Name, e.Value.ToString()));
                }


            }

            return refData;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var referenceData = (ReferenceData)value;

            writer.WriteStartObject();

            foreach (var prop in typeof(ReferenceData).GetProperties().Where(x => x.GetCustomAttributes(typeof(JsonPropertyAttribute), false).FirstOrDefault() != null)
                                                    .Select(x =>
                                                    {
                                                        var jsonAttribute = (JsonPropertyAttribute)x.GetCustomAttributes(typeof(JsonPropertyAttribute), false).FirstOrDefault();
                                                        return new { Property = x, JsonName = jsonAttribute.PropertyName };
                                                    }))
            {
                var val = prop.Property.GetValue(referenceData);
                if (val != null)
                {
                    writer.WritePropertyName(prop.JsonName);
                    serializer.Serialize(writer, val);
                }

            }

            foreach (var e in referenceData.KeyValues)
            {
                writer.WritePropertyName(e.Key);
                serializer.Serialize(writer, e.Value);
            }



            writer.WriteEndObject();
        }
    }
}
