using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace nycWeb.DTOs
{
    public class ConsentsDto
    {
        public bool SharingConsent { get; set; }
        public bool AvailabilityConsent { get; set; }
        public bool AiUsageConsent { get; set; }
    }
}