using API_MongoDB.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace API_MongoDB.Services
{
    public class TimeKeepingMethodServices
    {
        private readonly IMongoCollection<TimeKeepingMethod> _timeKeepingMethodCollection;
        public TimeKeepingMethodServices(IOptions<DatabaseSettings> dbSettings)
        {
            var mongoClient = new MongoClient(dbSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(dbSettings.Value.DatabaseName);
            _timeKeepingMethodCollection = mongoDatabase.GetCollection<TimeKeepingMethod>(dbSettings.Value.TimeKeepingMethodCollectionName);
        }
        public async Task<List<TimeKeepingMethod>> GetAllTimeKeepingMethod()
        {
            var response = await _timeKeepingMethodCollection.Find(_ => true).ToListAsync();
            return response;
        }
        public async Task<TimeKeepingMethod> GetTimeKeepingMethodById(string id)
        {
            var response = await _timeKeepingMethodCollection.Find(s => s.Id == id).FirstOrDefaultAsync();
            return response;
        }
        public async Task<TimeKeepingMethod> GetTimeKeepingMethodByName(string name)
        {
            var response = await _timeKeepingMethodCollection.Find(s => s.TimeKeepingMethodName == name).FirstOrDefaultAsync();
            return response;
        }
        public async Task<string> CreateTimeKeepingMethod(TimeKeepingMethod timeKeepingMethod)
        {
            try
            {
                await _timeKeepingMethodCollection.InsertOneAsync(timeKeepingMethod);
                return "Success";
            }
            catch (Exception ex)
            {
                return ex.InnerException != null ? ex.InnerException.Message : ex.Message;
            }
        }
        public async Task<object> UpdateTimeKeepingMethod(TimeKeepingMethod timeKeepingMethod)
        {
            try
            {
                return await _timeKeepingMethodCollection.ReplaceOneAsync(s => s.Id == timeKeepingMethod.Id, timeKeepingMethod);
            }
            catch (Exception ex)
            {
                return ex.InnerException != null ? ex.InnerException.Message : ex.Message;
            }
        }
        public async Task<object> DeleteTimeKeepingMethod(string id)
        {
            try
            {
                return await _timeKeepingMethodCollection.DeleteOneAsync(s => s.Id == id);
            }
            catch (Exception ex)
            {
                return ex.InnerException != null ? ex.InnerException.Message : ex.Message;
            }
        }
    }
}
