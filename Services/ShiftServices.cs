using API_MongoDB.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace API_MongoDB.Services
{
    public class ShiftServices
    {
        private readonly IMongoCollection<Shift> _shiftCollection;

        public ShiftServices(IOptions<DatabaseSettings> dbSettings)
        {
            var mongoClient = new MongoClient(dbSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(dbSettings.Value.DatabaseName);
            _shiftCollection = mongoDatabase.GetCollection<Shift>(dbSettings.Value.ShiftCollectionName);
        }
        public async Task<List<Shift>> GetAllShift()
        {
            var response = await _shiftCollection.Find(_ => true).ToListAsync();
            return response;
        }
        public async Task<Shift> GetShiftById(string id)
        {
            var response = await _shiftCollection.Find(s => s.Id == id).FirstOrDefaultAsync();
            return response;
        }
        public async Task<Shift> GetShiftByName(string name)
        {
            var response = await _shiftCollection.Find(s => s.ShiftName == name).FirstOrDefaultAsync();
            return response;
        }
        public async Task<string> CreateShift(Shift shift)
        {
            try
            {
                await _shiftCollection.InsertOneAsync(shift);
                return "Success";
            }
            catch (Exception ex)
            {
                return ex.InnerException != null ? ex.InnerException.Message : ex.Message;
            }
        }
        public async Task<object> UpdateShift(Shift shift)
        {
            try
            {
                return await _shiftCollection.ReplaceOneAsync(s => s.Id == shift.Id, shift);
            }
            catch (Exception ex)
            {
                return ex.InnerException != null ? ex.InnerException.Message : ex.Message;
            }
        }
        public async Task<object> DeleteShift(string id)
        {
            try
            {
                return await _shiftCollection.DeleteOneAsync(s => s.Id == id);
            }
            catch (Exception ex)
            {
                return ex.InnerException != null ? ex.InnerException.Message : ex.Message;
            }
        }
    }
}
