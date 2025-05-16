using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace nycWeb.Models
{
    public class Registration
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = null!;
        [BsonElement("registrationId")]
        public string RegistrationID { get; set; } = string.Empty;
        [BsonElement("role")]
        public string Role { get; set; }  = string.Empty;
        public DateTime DateTime { get; set; } = DateTime.Now;
        public Consents consents { get; set; } = null!;
        public PersonalInfo personalInfo { get; set; } = null!;
        public EducationInfo educationInfo { get; set; } = null!;
        public ExperienceInfo experienceInfo { get; set; } = null!;
        public Achievements achievements { get; set; } = null!;
        public Reflective reflective { get; set; } = null!;
        public Scenario scenario { get; set; } = null!;
    }
}
