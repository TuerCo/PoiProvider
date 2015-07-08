using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TT.Infr.ExternalServices.QueryParams
{
    public abstract class BaseSearchQueryParams
    {
        /// <summary>
        /// POI category/categories to be included to results. Several categories can be given by separating them with commas. If this parameter is not given, all categories are included. (Optional)
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// POI data component name(s) to be included to results. Several component names can be given by separating them with commas. If this parameter is not given, all components are included. (Optional)
        /// </summary>
        public string Component { get; set; }

        /// <summary>
        /// Maximum number of POIs returned. (Optional)
        /// </summary>
        public int MaxResults { get; set; }

        /// <summary>
        /// When time of interest begins. See 'Time format' below. Optional, requires end_time. (Optional)
        /// Basic rule: ISO 8601 adaptation format [1] is used for times. However, it is allowed to leave the time zone definition out. If time zone is missing, the local time zone of the POI is used. This specification does not require implementation of time zone functionality. E.g.: '2014-01-23', '2014-01-23T13:34'
        /// </summary>
        public string BeginTime { get; set; }

        /// <summary>
        /// When time of interest ends. See 'Time format' below. Required, if begin_time is defined. (Optional)
        /// Basic rule: ISO 8601 adaptation format [1] is used for times. However, it is allowed to leave the time zone definition out. If time zone is missing, the local time zone of the POI is used. This specification does not require implementation of time zone functionality. E.g.: '2014-01-23', '2014-01-23T13:34'
        /// </summary>
        public string EndTime { get; set; }

        /// <summary>
        /// Minimum time of availability in minutes. Optional. If begin_time is defined, default: a short time > 0. (Optional)
        /// </summary>
        public int MinMinutes { get; set; }

        internal virtual string ToUrlParams()
        {
            var list = new List<string>();
            if(!string.IsNullOrEmpty(Category))
                list.Add("category=" + Category);
            if (!string.IsNullOrEmpty(Component))
                list.Add("component=" + Component);
            if (MaxResults > 0)
                list.Add("max_results=" + MaxResults);
            if (!string.IsNullOrEmpty(BeginTime))
                list.Add("begin_time=" + BeginTime);
            if (!string.IsNullOrEmpty(EndTime))
                list.Add("begin_time=" + EndTime);
            if (MinMinutes > 0)
                list.Add("min_minutes=" + MinMinutes);

            if (list.Count == 0)
            {
                return "";
            }

            return string.Join("&", list);
        }
    }
}
