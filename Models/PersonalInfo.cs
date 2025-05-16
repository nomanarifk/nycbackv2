using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace nycWeb.Models
{
    public class PersonalInfo
    {
        public bool IsAfghan { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string ContactNumber { get; set; }
        public string Whatsapp { get; set; }
        public string BirthDate { get; set; }
        public string Address { get; set; }
        public string DocumentType { get; set; } = "cnic";
        public string DocumentNumber { get; set; }
        public string PermanentRegion { get; set; } = "southern";
        public string CurrentRegion { get; set; } = "southern";
        public string LocalCouncil { get; set; } = "garden";
        public string Jamatkhana { get; set; }
    }
}