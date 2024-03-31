using API_MongoDB.Models;
using Microsoft.Extensions.Options;
using MongoDB.Bson.IO;
using MongoDB.Driver;
using System.Collections.Generic;

namespace API_MongoDB.Services
{
    public class WorkScheduleServices
    {
        private readonly IMongoCollection<WorkSchedule> _workScheduleCollection;
        public WorkScheduleServices(IOptions<DatabaseSettings> dbSettings)
        {
            var mongoClient = new MongoClient(dbSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(dbSettings.Value.DatabaseName);
            _workScheduleCollection = mongoDatabase.GetCollection<WorkSchedule>(dbSettings.Value.WorkScheduleCollectionName);
        }
        public async Task<List<WorkSchedule>> GetAllWorkSchedule()
        {
            var response = await _workScheduleCollection.Find(_ => true).ToListAsync();
            return response;
        }
        public async Task<WorkSchedule> GetWorkScheduleById(string id)
        {
            var response = await _workScheduleCollection.Find(s => s.Id == id).FirstOrDefaultAsync();
            return response;
        }
        public async Task<object> CountStaffByWorkScheduleId(string id)
        {
            try
            {
                var response = await _workScheduleCollection.Find(s => s.Id == id).FirstOrDefaultAsync();
                long count = response.Details.Count();
                return count;

            }
            catch (Exception ex)
            {
                return ex.InnerException != null ? ex.InnerException.Message : ex.Message;
            }
        }
        public async Task<string> CreateWorkSchedule(WorkSchedule workSchedule)
        {
            try
            {
                await _workScheduleCollection.InsertOneAsync(workSchedule);
                return "Success";
            }
            catch (Exception ex)
            {
                return ex.InnerException != null ? ex.InnerException.Message : ex.Message;
            }
        }
        public async Task<object> UpdateWorkSchedule(WorkSchedule workSchedule)
        {
            try
            {
                var update = Builders<WorkSchedule>.Update
                    .Set(s => s.Id, workSchedule.Id)
                    .Set(s => s.WorkDate, workSchedule.WorkDate);
                return await _workScheduleCollection.UpdateOneAsync(s => s.Id == workSchedule.Id, update);
            }
            catch (Exception ex)
            {
                return ex.InnerException != null ? ex.InnerException.Message : ex.Message;
            }
        }
        public async Task<object> UpdateDetailWorkSchedule(WorkSchedule workSchedule)
        {
            try
            {
                WorkSchedule update = await _workScheduleCollection.FindSync(s => s.Id == workSchedule.Id).FirstOrDefaultAsync();
                if (update.Details == null)
                    update.Details = new List<WorkSchedule.Detail>();
                update.Details.AddRange(workSchedule.Details);
                return await _workScheduleCollection.ReplaceOneAsync(s => s.Id == update.Id, update);
            }
            catch (Exception ex)
            {
                return ex.InnerException != null ? ex.InnerException.Message : ex.Message;
            }
        }
        public async Task<object> DeleteWorkSchedule(string id)
        {
            try
            {
                return await _workScheduleCollection.DeleteOneAsync(s => s.Id == id);
            }
            catch (Exception ex)
            {
                return ex.InnerException != null ? ex.InnerException.Message : ex.Message;
            }
        }
        public async Task<object> DeleteStaffWorkSchedule(string id, string staffId)
        {
            try
            {
                WorkSchedule update = await _workScheduleCollection.Find(s => s.Id == id).FirstOrDefaultAsync();
                update.Details.RemoveAll(s => s.StaffId == staffId);
                return await _workScheduleCollection.ReplaceOneAsync(s => s.Id == update.Id, update);
            }
            catch (Exception ex)
            {
                return ex.InnerException != null ? ex.InnerException.Message : ex.Message;
            }
        }
    }
}
