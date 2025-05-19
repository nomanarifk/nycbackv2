using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace nycWeb.Models
{
    public class RegistrationDtoToReturn
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = null!;
        [BsonElement("role")]
        public string Role { get; set; } = string.Empty;

        public string FullName { get; set; } = string.Empty;

        public string RegionalCouncil { get; set; } = string.Empty;

        public string LocalCouncil { get; set; } = string.Empty;

        public string Jamatkhana { get; set; } = string.Empty;

        public string Status { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
    }
}