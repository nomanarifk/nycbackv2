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

        public async Task<List<RegistrationDtoToReturn>> GetSummaryListAsync()
        {
            var rawList = await _RegistrationModel
                .Find(_ => true)
                .Project(r => new
                {
                    r.Id,
                    r.Role,
                    r.Status,
                    r.personalInfo.FirstName,
                    r.personalInfo.LastName,
                    r.personalInfo.CurrentRegion,
                    r.personalInfo.LocalCouncil,
                    r.personalInfo.Jamatkhana
                })
                .ToListAsync();

            var result = rawList.Select(r => new RegistrationDtoToReturn
            {
                Id = r.Id,
                Role = r.Role,
                FullName = $"{r.FirstName} {r.LastName}",
                RegionalCouncil = r.CurrentRegion,
                LocalCouncil = r.LocalCouncil,
                Jamatkhana = r.Jamatkhana,
                Status = string.IsNullOrWhiteSpace(r.Status) ? "Pending" : r.Status
            }).ToList();

            return result;
        }    

    }
}