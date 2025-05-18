using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace nycWeb.Models
{
    public class Consents
    {
        public bool SharingConsent { get; set; }
        public bool AvailabilityConsent { get; set; }
        public bool AiUsageConsent { get; set; }
    }
}