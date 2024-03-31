using API_MongoDB.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace API_MongoDB.Services
{
    public class StaffServices
    {
        private readonly IMongoCollection<Staff> _staffCollection;
        public StaffServices(IOptions<DatabaseSettings> dbSettings)
        {
            var mongoClient = new MongoClient(dbSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(dbSettings.Value.DatabaseName);
            _staffCollection = mongoDatabase.GetCollection<Staff>(dbSettings.Value.StaffCollectionName);
        }
        public async Task<List<Staff>> GetAllStaff()
        {
            var response = await _staffCollection.Find(_ => true).ToListAsync();
            return response;
        }
        public async Task<Staff> GetStaffById(string id)
        {
            var response = await _staffCollection.Find(s => s.Id == id).FirstOrDefaultAsync();
            return response;
        }
        public async Task<string> CreateStaff(Staff staff)
        {
            try
            {
                await _staffCollection.InsertOneAsync(staff);
                return "Success";
            }
            catch (Exception ex)
            {
                return ex.InnerException != null ? ex.InnerException.Message : ex.Message;
            }
        }
        public async Task<object> UpdateStaff(Staff staff)
        {
            try
            {
                return await _staffCollection.ReplaceOneAsync(s => s.Id == staff.Id, staff);
            }
            catch (Exception ex)
            {
                return ex.InnerException != null ? ex.InnerException.Message : ex.Message;
            }
        }
        public async Task<object> DeleteStaff(string id)
        {
            try
            {
                return await _staffCollection.DeleteOneAsync(s => s.Id == id);
            }
            catch (Exception ex)
            {
                return ex.InnerException != null ? ex.InnerException.Message : ex.Message;
            }
        }
    }
}
