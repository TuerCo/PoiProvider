using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TT.Infr.ExternalServices.QueryParams
{
    public class RadialSearchQueryParams : BaseSearchQueryParams
    {
        /// <summary>
        /// Latitude of the center of the search circle [degrees]
        /// </summary>
        public double Latitude { get; set; }

        /// <summary>
        /// Longitude of the center of the search circle [degrees]
        /// </summary>
        public double Longitude { get; set; }

        /// <summary>
        /// Radius of the search circle [meters], default is implementation dependent (Optional)
        /// </summary>
        public double Radius { get; set; }

        internal override string ToUrlParams()
        {
            var list = new List<string>();
            list.Add("lat="+Latitude);
            list.Add("lon="+Longitude);
            if (Radius > 0)
                list.Add("radius="+Radius);

            return string.Concat(string.Join("&", list), "&", base.ToUrlParams());
        }
    }
}
