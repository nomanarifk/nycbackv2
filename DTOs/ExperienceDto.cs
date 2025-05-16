using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace nycWeb.DTOs
{
    public class ExperienceDto
    {
        public List<VoluntaryDto> VoluntaryList { get; set; } = new();
        public string ParticipatedInCamp { get; set; } = string.Empty;
        public List<CampDto> CampDetails { get; set; } = new();
    }

    public class VoluntaryDto
    {
        public string Institution { get; set; } = string.Empty;
        public string FromYear { get; set; } = string.Empty;
        public string ToYear { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
    }

    public class CampDto
    {
        public string Program { get; set; } = string.Empty;
        public string Year { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
    }
}