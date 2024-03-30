using API_MongoDB.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace API_MongoDB.Services
{
    public class BenefitServices
    {
        private readonly IMongoCollection<Benefit> _benefitCollection;
        private readonly IOptions<DatabaseSettings> _dbSettings;

        public BenefitServices(IOptions<DatabaseSettings> dbSettings)
        {
            _dbSettings = dbSettings;
            var mongoClient = new MongoClient(dbSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(dbSettings.Value.DatabaseName);
            _benefitCollection = mongoDatabase.GetCollection<Benefit>(dbSettings.Value.BenefitCollectionName);
        }
        public async Task<List<Benefit>> GetAllBenefit()
        {
            var response = await _benefitCollection.Find(_=> true).ToListAsync();
            return response;
        }
    }
}
