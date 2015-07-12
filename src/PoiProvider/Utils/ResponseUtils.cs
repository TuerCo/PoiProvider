using TT.Infr.ExternalServices.Data;
using TT.Infr.ExternalServices.Response;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TT.Infr.ExternalServices.Utils
{
    public class ResponseUtils
    {
        public static List<PoiData> BuildPoiResponse(string json)
        {
            var jobject = JObject.Parse(json);

            var result = new List<PoiData>();

            if ((jobject["pois"] as JObject) == null)
            {
                return result;
            }

            foreach (var element in (jobject["pois"] as JObject).Properties().Select(x => x.Name))
            {
                var poiResponse = new PoiData();

                poiResponse.Core = CreateFwData<FwCore>(jobject, element, "fw_core", FillGeneric<FwCore>);
                poiResponse.Time = CreateFwData<FwTime>(jobject, element, "fw_time", FillGeneric<FwTime>);
                poiResponse.Xml3ds = CreateFwData<FwXml3d>(jobject, element, "fw_xml3d", FillGeneric<FwXml3d>);
                poiResponse.Contacts = CreateFwData<FwContact>(jobject, element, "fw_contact", FillGeneric<FwContact>);
                poiResponse.Media = CreateFwData<FwMedia>(jobject, element, "fw_media", FillGeneric<FwMedia>);
                poiResponse.Relationships = CreateFwData<List<FwRelationship>>(jobject, element, "fw_relationships", FillGeneric<List<FwRelationship>>);
                poiResponse.Markers = CreateFwData<FwMarker>(jobject, element, "fw_marker", FillGeneric<FwMarker>);

                poiResponse.Id = element;

                result.Add(poiResponse);

            }

            return result;
        }

        private static T CreateFwData<T>(JObject jobject, string element, string key, Func<JToken, T> func) where T : new()
        {
            var jFw = jobject["pois"][element][key];

            if (jFw == null)
                return default(T);

            return func(jFw);
        }

        private static T FillGeneric<T>(JToken jFw)
        {
            var fw = JsonConvert.DeserializeObject<T>(jFw.ToString());
            return fw;
        }
    }
}
