using TT.Infr.ExternalServices.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TT.Infr.ExternalServices.Utils;
using Newtonsoft.Json;
using TT.Infr.ExternalServices.QueryParams;
using TT.Infr.ExternalServices.Data;
using Newtonsoft.Json.Serialization;

namespace TT.Infr.ExternalServices
{
    public class PoiClient : TT.Infr.ExternalServices.PoiProvider.IPoiClient
    {
        private string _url;

        public PoiClient(string url)
        {
            _url = url;
        }

        public GetComponentsResponse GetComponents()
        {
            return GetComponentsAsync().ResultSynchronizer();
        }

        public async Task<GetComponentsResponse> GetComponentsAsync()
        {
            using(var client = new HttpClient())
            {
                var url = string.Format("{0}/{1}", _url, "get_components");

                var response = await client.GetAsync(url);

                var content = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<GetComponentsResponse>(content);
            }
        }

        public List<PoiData> RadialSearch(RadialSearchQueryParams queryParams)
        {
            return RadialSearchAsync(queryParams).ResultSynchronizer();
        }

        public async Task<List<PoiData>> RadialSearchAsync(RadialSearchQueryParams queryParams)
        {
            using (var client = new HttpClient())
            {
                var url = string.Format("{0}/{1}?{2}", _url, "radial_search", queryParams.ToUrlParams());

                var response = await client.GetAsync(url);

                var content = await response.Content.ReadAsStringAsync();

                return ResponseUtils.BuildPoiResponse(content);
            }
        }

        public List<PoiData> BboxSearch(BboxSearchQueryParams queryParams)
        {
            return BboxSearchAsync(queryParams).ResultSynchronizer();
        }

        public async Task<List<PoiData>> BboxSearchAsync(BboxSearchQueryParams queryParams)
        {
            using (var client = new HttpClient())
            {
                var url = string.Format("{0}/{1}?{2}", _url, "bbox_search", queryParams.ToUrlParams());

                var response = await client.GetAsync(url);

                var content = await response.Content.ReadAsStringAsync();

                return ResponseUtils.BuildPoiResponse(content);
            }
        }

        public PoiData GetPois(GetPoisSearchQueryParams queryParams)
        {
            return GetPoisAsync(queryParams).ResultSynchronizer();
        }

        public async Task<PoiData> GetPoisAsync(GetPoisSearchQueryParams queryParams)
        {
            using (var client = new HttpClient())
            {
                var url = string.Format("{0}/{1}?{2}", _url, "get_pois", queryParams.ToUrlParams());

                var response = await client.GetAsync(url);

                var content = await response.Content.ReadAsStringAsync();

                try
                {
                    return ResponseUtils.BuildPoiResponse(content).FirstOrDefault();
                }
                catch
                {
                    return null;
                }
            }
        }

        public AddPoiResponse AddPoi(PoiData poiData)
        {
            return AddPoiAsync(poiData).ResultSynchronizer();
        }

        public async Task<AddPoiResponse> AddPoiAsync(PoiData poiData)
        {
            using (var client = new HttpClient())
            {
                var url = string.Format("{0}/{1}", _url, "add_poi");

                var jsonSerializerSettings = new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver(),
                    NullValueHandling = NullValueHandling.Ignore
                };

                poiData.Id = null;

                var poiStringData = JsonConvert.SerializeObject(poiData, Newtonsoft.Json.Formatting.Indented, jsonSerializerSettings);

                var jsonContent = new StringContent(poiStringData);

                var response = await client.PostAsync(url, jsonContent);

                var content = await response.Content.ReadAsStringAsync();

                try
                {
                    return JsonConvert.DeserializeObject<AddPoiResponse>(content);
                }
                catch (Exception)
                {
                    throw new Exception(content);
                }
            }
        }

        public string UpdatePoi(PoiData poiData)
        {
            return UpdatePoiAsync(poiData).ResultSynchronizer();
        }

        public async Task<string> UpdatePoiAsync(PoiData poiData)
        {
            using (var client = new HttpClient())
            {
                var url = string.Format("{0}/{1}", _url, "update_poi");

                var jsonSerializerSettings = new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver(),
                    NullValueHandling = NullValueHandling.Ignore
                };

                var poiStringData = JsonConvert.SerializeObject(poiData, Newtonsoft.Json.Formatting.Indented, jsonSerializerSettings);

                var jsonContent = new StringContent(poiStringData);

                var response = await client.PostAsync(url, jsonContent);

                var content = await response.Content.ReadAsStringAsync();

                return content;
            }
        }

        public string DeletePoi(string poiId)
        {
            return DeletePoiAsync(poiId).ResultSynchronizer();
        }

        public async Task<string> DeletePoiAsync(string poiId)
        {
            using (var client = new HttpClient())
            {
                var url = string.Format("{0}/{1}?poi_id={2}", _url, "delete_poi", poiId);

                var jsonSerializerSettings = new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver(),
                    NullValueHandling = NullValueHandling.Ignore
                };

                var response = await client.DeleteAsync(url);

                var content = await response.Content.ReadAsStringAsync();

                return content;
            }
        }
    }
}
