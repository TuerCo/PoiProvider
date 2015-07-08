using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TT.Infr.ExternalServices.Data
{
    public class ScheduleData
    {
        public List<ScheduleData> Or { get; set; }
        public List<ScheduleData> And { get; set; }
        public ScheduleData Not { get; set; }
        public List<int> Wd { get; set; }
        public List<int> Bhr { get; set; }
        public List<int> Ehr { get; set; }
        public List<int> Bev { get; set; }
        public List<int> Eev { get; set; }
    }
}
