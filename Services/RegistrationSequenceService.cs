using MongoDB.Bson;
using MongoDB.Driver;

namespace nycWeb.Services
{
    
public class RegistrationSequenceService
{
    private readonly IMongoCollection<BsonDocument> _sequenceCollection;

    public RegistrationSequenceService(IConfiguration config)
    {
        var client = new MongoClient(config.GetConnectionString("MongoDb"));
        var database = client.GetDatabase(config.GetConnectionString("DatabaseName"));
        _sequenceCollection = database.GetCollection<BsonDocument>("RegistrationSequence");
    }

    public async Task<string> GetNextRegistrationIdAsync(string role)
    {
        // Choose prefix based on role
        string prefix = role.ToLower() switch
        {
            "facilitator" => "NYCF",
            "participant" => "NYCP",
            _ => throw new ArgumentException("Invalid role")
        };

        var filter = Builders<BsonDocument>.Filter.Eq("_id", prefix);
        var update = Builders<BsonDocument>.Update.Inc("seq", 1);
        var options = new FindOneAndUpdateOptions<BsonDocument>
        {
            IsUpsert = true,
            ReturnDocument = ReturnDocument.After
        };

        var counter = await _sequenceCollection.FindOneAndUpdateAsync(filter, update, options);
        int sequence = counter["seq"].AsInt32;

        return $"{prefix}{sequence.ToString("D5")}";
    }
}
}