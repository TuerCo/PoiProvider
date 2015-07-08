using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TT.Infr.ExternalServices.QueryParams
{
    public class BboxSearchQueryParams : BaseSearchQueryParams
    {
        /// <summary>
        /// latitude - Latitude of the northern edge of the bounding box [degrees]
        /// </summary>
        public double North { get; set; }

        /// <summary>
        /// latitude - Latitude of the southern edge of the bounding box [degrees]
        /// </summary>
        public double South { get; set; }

        /// <summary>
        /// longitude - Longitude of the eastern edge of the bounding box [degrees]
        /// </summary>
        public double East { get; set; }

        /// <summary>
        /// longitude - Longitude of the western edge of the bounding box [degrees]
        /// </summary>
        public double West { get; set; }

        internal override string ToUrlParams()
        {
            var list = new List<string>();
            list.Add("north=" + North);
            list.Add("south=" + South);
            list.Add("east=" + East);
            list.Add("west=" + West);
            return string.Concat(string.Join("&", list), "&", base.ToUrlParams());
        }
    }
}
