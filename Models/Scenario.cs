using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace nycWeb.Models
{
    public class Scenario
    {
        //Participant
        public string ProjectChoice { get; set; } = string.Empty;
        public string ProjectReason { get; set; } = string.Empty;

        //Facilitator
        public string SessionChoice { get; set; } = string.Empty;
        public string SessionExplanation { get; set; } = string.Empty;
    }
}