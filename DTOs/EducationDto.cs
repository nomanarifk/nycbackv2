using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace nycWeb.DTOs
{
    public class EducationDto
    {   
        public string ReligiousEducation { get; set; } = string.Empty;
        public string AcademicQualification { get; set; } = string.Empty;
        public string CurrentlyStudying { get; set; } = string.Empty;
        public string StudyInstitution { get; set; } = string.Empty;
        public string AreaOfStudy { get; set; } = string.Empty;
        public string CurrentlyWorking { get; set; } = string.Empty;
        public string WorkInstitution { get; set; } = string.Empty;
        public string CurrentRoleDescription { get; set; } = string.Empty;
    }
}