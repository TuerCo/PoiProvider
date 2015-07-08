using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TT.Infr.ExternalServices.QueryParams
{
    public class GetPoisSearchQueryParams
    {
        /// <summary>
        /// UUID - UUID of the POI. Several UUIDs can be given by separating them with commas.
        /// </summary>
        public string PoiId { get; set; }

        /// <summary>
        /// POI data component name(s) to be included to results. Several component names can be given by separating them with commas. If this parameter is not given, all components are included. (Optional)
        /// </summary>
        public string Component { get; set; }

        /// <summary>
        /// The components requested are returned with all language and other variants and possible metadata for inspection and edit.
        /// </summary>
        public bool? GetForUpdate { get; set; }

        internal string ToUrlParams()
        {
            var list = new List<string>();
            list.Add("poi_id=" + PoiId);
            if(!string.IsNullOrEmpty(Component))
            {
                list.Add("component=" + Component);
            }
            if (GetForUpdate.HasValue)
            {
                list.Add("get_for_update=" + GetForUpdate.ToString().ToLower());
            }

            return string.Join("&", list);
        }
    }
}
