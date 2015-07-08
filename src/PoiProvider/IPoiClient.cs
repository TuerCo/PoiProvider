using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TT.Infr.ExternalServices.Data;
using TT.Infr.ExternalServices.QueryParams;
using TT.Infr.ExternalServices.Response;
namespace TT.Infr.ExternalServices.PoiProvider
{
    public interface IPoiClient
    {
        AddPoiResponse AddPoi(PoiData poiData);
        Task<AddPoiResponse> AddPoiAsync(PoiData poiData);
        System.Collections.Generic.List<PoiData> BboxSearch(BboxSearchQueryParams queryParams);
        Task<List<PoiData>> BboxSearchAsync(BboxSearchQueryParams queryParams);
        string DeletePoi(string poiId);
        Task<string> DeletePoiAsync(string poiId);
        GetComponentsResponse GetComponents();
        Task<GetComponentsResponse> GetComponentsAsync();
        PoiData GetPois(GetPoisSearchQueryParams queryParams);
        Task<PoiData> GetPoisAsync(GetPoisSearchQueryParams queryParams);
        List<PoiData> RadialSearch(RadialSearchQueryParams queryParams);
        Task<List<PoiData>> RadialSearchAsync(RadialSearchQueryParams queryParams);
        string UpdatePoi(PoiData poiData);
        Task<string> UpdatePoiAsync(PoiData poiData);
    }
}
