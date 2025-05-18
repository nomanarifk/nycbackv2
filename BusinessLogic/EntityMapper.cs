using MongoDB.Bson;
using nycWeb.DTOs;
using nycWeb.Models;

namespace nycWeb.BusinessLogic
{
    public static class EntityMapper
    {
        public static Registration MapToEntity(RegistrationDtoToCreate dto)
        {
            return new Registration
            {
                Id = ObjectId.GenerateNewId().ToString(),
                RegistrationID = dto.reg,
                Role = dto.role,
                DateTime = DateTime.UtcNow,
                consents = MapConsents(dto.Consents),
                personalInfo = MapPersonal(dto.Personal),
                educationInfo = MapEducation(dto.Education),
                experienceInfo = MapExperience(dto.Experience),
                achievements = MapAchievements(dto.Achievements),
                reflective = MapReflective(dto.Reflective),
                scenario = MapScenario(dto.Scenario),
                
            };
        }

        public static Consents MapConsents(ConsentsDto dto)
        {
            return new Consents
            {
                AiUsageConsent = dto.AiUsageConsent,
                AvailabilityConsent = dto.AvailabilityConsent,
                SharingConsent = dto.SharingConsent,
            };
        }

        public static PersonalInfo MapPersonal(PersonalDto dto)
        {
            return new PersonalInfo
            {
                IsAfghan = dto.IsAfghan,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Gender = dto.Gender,
                Email = dto.Email,
                ContactNumber = dto.ContactNumber,
                Whatsapp = dto.Whatsapp,
                BirthDate = dto.BirthDate,
                Address = dto.Address,
                DocumentType = dto.DocumentType,
                DocumentNumber = dto.DocumentNumber,
                PermanentRegion = dto.PermanentRegion,
                CurrentRegion = dto.CurrentRegion,
                LocalCouncil = dto.LocalCouncil,
                Jamatkhana = dto.Jamatkhana,
            };
        }

        public static EducationInfo MapEducation(EducationDto dto)
        {
            return new EducationInfo
            {
                ReligiousEducation = dto.ReligiousEducation,
                AcademicQualification = dto.AcademicQualification,
                CurrentlyStudying = dto.CurrentlyStudying,
                StudyInstitution = dto.StudyInstitution,
                AreaOfStudy = dto.AreaOfStudy,
                CurrentlyWorking = dto.CurrentlyStudying,
                WorkInstitution = dto.WorkInstitution,
                CurrentRoleDescription = dto.CurrentRoleDescription
            };
        }

        public static ExperienceInfo MapExperience(ExperienceDto dto)
        {
            return new ExperienceInfo
            {
                ParticipatedInCamp = dto.ParticipatedInCamp,
                VoluntaryList = dto.VoluntaryList.Select(v => new Voluntary
                {
                    Institution = v.Institution,
                    FromYear = v.FromYear,
                    ToYear = v.ToYear,
                    Role = v.Role
                }).ToList(),
                CampDetails = dto.CampDetails.Select(c => new Camp
                {
                    Program = c.Program,
                    Year = c.Year,
                    Role = c.Role
                }).ToList()
            };
        }

        public static Achievements MapAchievements(AchievementsDto dto)
        {
            return new Achievements
            {
                OtherAchievements = dto.OtherAchievements,
                Entries = dto.Entries.Select(e => new AchievementEntry
                {
                    Name = e.Name,
                    Year = e.Year
                }).ToList()
            };
        }

        public static Reflective MapReflective(ReflectiveDto dto)
        {
            return new Reflective
            {
                KhidmatMeaning = dto.KhidmatMeaning,
                VideoUrl = dto.VideoUrl
            };
        }

        private static Scenario MapScenario(ScenarioDto dto)
        {
            return new Scenario
            {
                ProjectChoice = dto.ProjectChoice,
                ProjectReason = dto.ProjectReason,
                SessionChoice = dto.SessionChoice,
                SessionExplanation = dto.SessionExplanation,
                PayFees = dto.PayFees,
                PaymentOption = dto.PaymentOption
            };
        }

        public static Visual MapVisual(VisualDto dto)
        {
            return new Visual
            {
                ImageInterpretation = dto.ImageInterpretation
            };
        }
    }
}