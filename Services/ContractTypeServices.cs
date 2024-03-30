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
                return await _contractTypCollection.ReplaceOneAsync(s => s.Id == contractType.Id, contractType);
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
    }
}
