using API_MongoDB.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace API_MongoDB.Services
{
    public class ShiftTypeServices
    {
        private readonly IMongoCollection<ShiftType> _shiftTypeCollection;

        public ShiftTypeServices(IOptions<DatabaseSettings> dbSettings)
        {
            var mongoClient = new MongoClient(dbSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(dbSettings.Value.DatabaseName);
            _shiftTypeCollection = mongoDatabase.GetCollection<ShiftType>(dbSettings.Value.ShiftTypeColectionName);
        }
        public async Task<List<ShiftType>> GetAllShiftType()
        {
            var response = await _shiftTypeCollection.Find(_ => true).ToListAsync();
            return response;
        }
        public async Task<ShiftType> GetShiftTypeById(string id)
        {
            var response = await _shiftTypeCollection.Find(s => s.Id == id).FirstOrDefaultAsync();
            return response;
        }
        public async Task<ShiftType> GetShiftTypeByName(string name)
        {
            var response = await _shiftTypeCollection.Find(s => s.ShiftTypeName == name).FirstOrDefaultAsync();
            return response;
        }
        public async Task<string> CreateShiftType(ShiftType shiftType)
        {
            try
            {
                await _shiftTypeCollection.InsertOneAsync(shiftType);
                return "Success";
            }
            catch (Exception ex)
            {
                return ex.InnerException != null ? ex.InnerException.Message : ex.Message;
            }
        }
        public async Task<object> UpdateShiftType(ShiftType shiftType)
        {
            try
            {
                return await _shiftTypeCollection.ReplaceOneAsync(s => s.Id == shiftType.Id, shiftType);
            }
            catch (Exception ex)
            {
                return ex.InnerException != null ? ex.InnerException.Message : ex.Message;
            }
        }
        public async Task<object> DeleteShiftType(string id)
        {
            try
            {
                return await _shiftTypeCollection.DeleteOneAsync(s => s.Id == id);
            }
            catch (Exception ex)
            {
                return ex.InnerException != null ? ex.InnerException.Message : ex.Message;
            }
        }
    }
}
