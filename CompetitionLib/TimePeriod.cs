using System;
using System.Collections.Generic;
using System.Text;

namespace CompetitionLib
{
    public class TimePeriod
    {
        public Guid TimePeriodId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
