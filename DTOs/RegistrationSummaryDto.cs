using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace nycformweb.DTOs
{
    public class RegistrationSummaryDto
    {
        public int Total { get; set; }
        public int Pending { get; set; }
        public int InReview { get; set; }
        public int ReviewDone { get; set; }
        public int Approved { get; set; }
        public int Rejected { get; set; }
        public int Participant { get; set; }
        public int Facilitator { get; set; }
        public List<RegionCounterDto> RegionCounts { get; set; } = new();
    }

    public class RegionCounterDto
    {
        public string Region { get; set; } = string.Empty;
        public int Total { get; set; }
        public int Pending { get; set; }
        public int InReview { get; set; }
        public int ReviewDone { get; set; }
        public int Approved { get; set; }
        public int Rejected { get; set; }
        public int Participant { get; set; }
        public int Facilitator { get; set; }
    }
}