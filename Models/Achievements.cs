using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace nycWeb.Models
{
    public class Achievements
    {
        public List<AchievementEntry> Entries { get; set; } = new();
        public string OtherAchievements { get; set; }
    }
    
    public class AchievementEntry
    {
        public string Name { get; set; }
        public int Year { get; set; } = DateTime.Now.Year;
    }
}