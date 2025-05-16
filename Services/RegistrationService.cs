using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using nycWeb.Models;

namespace nycWeb.Services
{
    public class RegistrationService
    {
        private readonly IMongoCollection<Registration> _RegistrationModel;
        public RegistrationService(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("MongoDb"));
            var database = client.GetDatabase(config.GetConnectionString("DatabaseName"));
            _RegistrationModel = database.GetCollection<Registration>("Registration");
        }

        public async Task<List<Registration>> GetAllAsync() => 
            await _RegistrationModel.Find(item => true).ToListAsync();

        public async Task<Registration> GetAsync(string id) => 
            await _RegistrationModel.Find(item => item.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Registration item) =>
            await _RegistrationModel.InsertOneAsync(item);

        public async Task UpdateAsync(string id, Registration itemIn) =>
            await _RegistrationModel.ReplaceOneAsync(item => item.Id == id, itemIn);

        public async Task RemoveAsync(string id) =>
            await _RegistrationModel.DeleteOneAsync(item => item.Id == id);
    }
}