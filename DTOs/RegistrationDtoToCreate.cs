using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using nycWeb.Models;

namespace nycWeb.DTOs
{
    public class RegistrationDtoToCreate
    {
        public string role { get; set; } = string.Empty;
        public string reg { get; set; } = string.Empty;
        public EligibilityDto Eligibility { get; set; } = new();
        public ConsentsDto Consents { get; set; } = new();
        public PersonalDto Personal { get; set; } = new();
        public EducationDto Education { get; set; } = new();
        public ExperienceDto Experience { get; set; } = new();
        public AchievementsDto Achievements { get; set; } = new();
        public ReflectiveDto Reflective { get; set; } = new();
        public ScenarioDto Scenario { get; set; } = new();
    }
}