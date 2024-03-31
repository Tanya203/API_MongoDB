using API_MongoDB.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Xml.Linq;

namespace API_MongoDB.Services
{
    public class BenefitServices
    {
        private readonly IMongoCollection<Benefit> _benefitCollection;

        public BenefitServices(IOptions<DatabaseSettings> dbSettings)
        {
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
        
        public async Task<object> CountStaffByBenefitId(string id)
        {
            try
            {
                var response = await _benefitCollection.Find(s => s.Id == id).FirstOrDefaultAsync();
                long count = response.Staff.Count();
                return count;                
            }
            catch (Exception ex)
            {
                return ex.InnerException != null ? ex.InnerException.Message : ex.Message;
            }
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
        public async Task<object> UpdateBenefit(Benefit benefit)
        {
            try
            {
                var update = Builders<Benefit>.Update
                    .Set(s => s.Id, benefit.Id)
                    .Set(s => s.BenefitName, benefit.BenefitName)
                    .Set(s => s.Amount, benefit.Amount);
                return await _benefitCollection.UpdateOneAsync(s => s.Id == benefit.Id, update);
            }
            catch (Exception ex)
            {
                return ex.InnerException != null ? ex.InnerException.Message : ex.Message;
            }
        }
        public async Task<object> AddStaffInBenefit(Benefit benefit)
        {
            try
            {
                Benefit update = await _benefitCollection.FindSync(s => s.Id == benefit.Id).FirstOrDefaultAsync();               
                if(update.Staff == null)
                    update.Staff = new List<StaffModels>();
                update.Staff.AddRange(benefit.Staff);
                return await _benefitCollection.ReplaceOneAsync(s => s.Id == update.Id, update);
            }
            catch (Exception ex)
            {
                return ex.InnerException != null ? ex.InnerException.Message : ex.Message;
            }
        }        
        public async Task<object> DeleteBenefit(string id)
        {
            try
            {
                return await _benefitCollection.DeleteOneAsync(s => s.Id == id);
            }
            catch (Exception ex)
            {
                return ex.InnerException != null ? ex.InnerException.Message : ex.Message;
            }
        }
        public async Task<object> DeleteStaffBenefit(string id, string staffId)
        {
            try
            {
                Benefit update = await _benefitCollection.Find(s => s.Id == id).FirstOrDefaultAsync();
                update.Staff.RemoveAll(s => s.Id == staffId);
                return await _benefitCollection.ReplaceOneAsync(s => s.Id == update.Id, update);
            }
            catch (Exception ex)
            {
                return ex.InnerException != null ? ex.InnerException.Message : ex.Message;
            }
        }
    }    
}
