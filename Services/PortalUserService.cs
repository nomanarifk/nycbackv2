using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using nycformweb.Models;

namespace nycformweb.Services
{
    public class PortalUserService
    {
        private readonly IMongoCollection<PortalUser> _PortalUserModel;
        public PortalUserService(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("MongoDb"));
            var database = client.GetDatabase(config.GetConnectionString("DatabaseName"));
            _PortalUserModel = database.GetCollection<PortalUser>("PortalUser");
        }
        public async Task<List<PortalUser>> GetAllAsync() =>
            await _PortalUserModel.Find(item => true).ToListAsync();

        public async Task<PortalUser> GetAsync(string id) =>
            await _PortalUserModel.Find(item => item.Id == id).FirstOrDefaultAsync();

        public async Task<PortalUser> GetUserByUsernameAsync(string username) =>
            await _PortalUserModel.Find(item => item.Username == username).FirstOrDefaultAsync();

        public async Task<PortalUser> CreateAsync(PortalUser item)
        {
            await _PortalUserModel.InsertOneAsync(item);
            return item;
        }

        public async Task UpdateAsync(string id, PortalUser itemIn) =>
            await _PortalUserModel.ReplaceOneAsync(item => item.Id == id, itemIn);

        public async Task RemoveAsync(string id) =>
            await _PortalUserModel.DeleteOneAsync(item => item.Id == id);

        public async Task<PortalUser?> AuthenticateAsync(string username, string password)
        {
            return await _PortalUserModel.Find(u => u.Username == username && u.Password == password).FirstOrDefaultAsync();
        }
    }
}