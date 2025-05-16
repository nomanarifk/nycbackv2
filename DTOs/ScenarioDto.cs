using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace nycWeb.DTOs
{
    public class ScenarioDto
    {
        public string ProjectChoice { get; set; } = string.Empty;
        public string ProjectReason { get; set; } = string.Empty;
        public string SessionChoice { get; set; } = string.Empty;
        public string SessionExplanation { get; set; } = string.Empty;
        public bool PayFees { get; set; }
        public string PaymentOption { get; set; } = string.Empty;
    }
}