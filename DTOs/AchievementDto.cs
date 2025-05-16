using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace nycWeb.DTOs
{
    public class AchievementsDto
    {
        public List<AchievementEntryDto> Entries { get; set; } = new();
        public string OtherAchievements { get; set; } = string.Empty;

        // These extra fields may be UI-only; ignore in backend if not needed
        public bool _AddingEntry { get; set; }
        public string _PendingName { get; set; } = string.Empty;
        public int _PendingYear { get; set; }
    }

    public class AchievementEntryDto
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Year { get; set; }
    }
}