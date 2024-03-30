﻿using API_MongoDB.Models;
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
        public async Task<Benefit> GetBenefitById(string id)
        {
            var response = await _benefitCollection.Find(s => s.Id == id).FirstOrDefaultAsync();
            return response;
        }
        public async Task<Benefit> GetBenefitByName(string name)
        {
            var response = await _benefitCollection.Find(s => s.BenefitName == name).FirstOrDefaultAsync();
            return response;
        }
        public async Task<string> CreateBenefit(Benefit benefit)
        {
            try
            {
                await _benefitCollection.InsertOneAsync(benefit);
                return "Success";
            }
            catch (Exception ex)
            {
                return ex.InnerException != null ? ex.InnerException.Message : ex.Message;
            }
        }
    }
}
