using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace nycWeb.Models
{
    public class ExperienceInfo
    {
        public List<Voluntary> VoluntaryList { get; set; } = new();
        public string ParticipatedInCamp { get; set; } = string.Empty;
        public List<Camp> CampDetails { get; set; } = new();
    }

    public class Voluntary
    {
        public string Institution { get; set; } = string.Empty;
        public string FromYear { get; set; } = string.Empty;
        public string ToYear { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
    }

    public class Camp
    {
        public string Program { get; set; } = string.Empty;
        public string Year { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
    }
}