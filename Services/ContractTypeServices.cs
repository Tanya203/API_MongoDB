using API_MongoDB.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace API_MongoDB.Services
{
    public class ContractTypeServices
    {
        private readonly IMongoCollection<ContractType> _contractTypCollection;

        public ContractTypeServices(IOptions<DatabaseSettings> dbSettings)
        {
            var mongoClient = new MongoClient(dbSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(dbSettings.Value.DatabaseName);
            _contractTypCollection = mongoDatabase.GetCollection<ContractType>(dbSettings.Value.ContractTypeCollectionName);
        }
        public async Task<List<ContractType>> GetAllContractType()
        {
            var response = await _contractTypCollection.Find(_ => true).ToListAsync();
            return response;
        }
        public async Task<ContractType> GetContractTypeById(string id)
        {
            var response = await _contractTypCollection.Find(s => s.Id == id).FirstOrDefaultAsync();
            return response;
        }
        public async Task<ContractType> GetContractTypeByName(string name)
        {
            var response = await _contractTypCollection.Find(s => s.ContractTypeName == name).FirstOrDefaultAsync();
            return response;
        }
        public async Task<object> CountStaffByContractTypeId(string id)
        {
            try
            {
                var response = await _contractTypCollection.Find(s => s.Id == id).FirstOrDefaultAsync();
                long count = response.Staff.Count();
                return count;
            }
            catch (Exception ex)
            {
                return ex.InnerException != null ? ex.InnerException.Message : ex.Message;
            }
        }
        public async Task<object> CreateContractType(ContractType contractType)
        {
            try
            {
                await _contractTypCollection.InsertOneAsync(contractType);
                return "Success";
            }
            catch (Exception ex)
            {
                return ex.InnerException != null ? ex.InnerException.Message : ex.Message;
            }
        }
        public async Task<object> UpdateContractType(ContractType contractType)
        {
            try
            {
                var update = Builders<ContractType>.Update
                    .Set(s => s.Id, contractType.Id)
                    .Set(s => s.ContractTypeName, contractType.ContractTypeName)
                    .Set(s => s.TimeKeepingMethodId, contractType.TimeKeepingMethodId);
                return await _contractTypCollection.UpdateOneAsync(s => s.Id == contractType.Id, update);
            }
            catch (Exception ex)
            {
                return ex.InnerException != null ? ex.InnerException.Message : ex.Message;
            }
        }
        public async Task<object> AddStaffInContractType(ContractType contractType)
        {
            try
            {
                ContractType update = await _contractTypCollection.FindSync(s => s.Id == contractType.Id).FirstOrDefaultAsync();
                if (update.Staff == null)
                    update.Staff = new List<StaffModels>();
                update.Staff.AddRange(contractType.Staff);
                return await _contractTypCollection.ReplaceOneAsync(s => s.Id == update.Id, update);
            }
            catch (Exception ex)
            {
                return ex.InnerException != null ? ex.InnerException.Message : ex.Message;
            }
        }
        public async Task<object> DeleteContractType(string id)
        {
            try
            {
                return await _contractTypCollection.DeleteOneAsync(s => s.Id == id);
            }
            catch (Exception ex)
            {
                return ex.InnerException != null ? ex.InnerException.Message : ex.Message;
            }
        }

        public async Task<object> DeleteStaffInContractType(string id, string staffId)
        {
            try
            {
                ContractType update = await _contractTypCollection.FindSync(s => s.Id == id).FirstOrDefaultAsync();
                update.Staff.RemoveAll(s => s.Id == staffId);
                return await _contractTypCollection.ReplaceOneAsync(s => s.Id == update.Id, update);
            }
            catch (Exception ex)
            {
                return ex.InnerException != null ? ex.InnerException.Message : ex.Message;
            }
        }

    }
}
