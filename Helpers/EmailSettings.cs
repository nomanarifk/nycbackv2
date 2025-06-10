using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace nycformweb.Helpers
{
    public class EmailSettings
    {
        public string From { get; set; } = null!;
        public string FromName { get; set; } = null!;
        public string To { get; set; }
        public string ToName { get; set; }
        public string SmtpHost { get; set; }
        public int SmtpPort { get; set; }
        public bool EnableSsl { get; set; }
        public string PasswordBase64 { get; set; }
    }
}