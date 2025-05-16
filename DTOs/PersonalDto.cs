using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace nycWeb.DTOs
{
    public class PersonalDto
    {
        public bool IsAfghan { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string ContactNumber { get; set; } = string.Empty;
        public string Whatsapp { get; set; } = string.Empty;
        public string BirthDate { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string DocumentType { get; set; } = string.Empty;
        public string DocumentNumber { get; set; } = string.Empty;
        public string PermanentRegion { get; set; } = string.Empty;
        public string CurrentRegion { get; set; } = string.Empty;
        public string LocalCouncil { get; set; } = string.Empty;
        public string Jamatkhana { get; set; } = string.Empty;
    }
}