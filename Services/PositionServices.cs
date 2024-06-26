﻿using API_MongoDB.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace API_MongoDB.Services
{
    public class PositionServices
    {
        private readonly IMongoCollection<Position> _positionCollection;

        public PositionServices(IOptions<DatabaseSettings> dbSettings)
        {
            var mongoClient = new MongoClient(dbSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(dbSettings.Value.DatabaseName);
            _positionCollection = mongoDatabase.GetCollection<Position>(dbSettings.Value.PositionCollectionName);
        }
        public async Task<List<Position>> GetAllPosition()
        {
            var response = await _positionCollection.Find(_ => true).ToListAsync();
            return response;
        }
        public async Task<Position> GetPositionById(string id)
        {
            var response = await _positionCollection.Find(s => s.Id == id).FirstOrDefaultAsync();
            return response;
        }
        public async Task<Position> GetPositionByName(string name)
        {
            var response = await _positionCollection.Find(s => s.PositionName == name).FirstOrDefaultAsync();
            return response;
        }
        public async Task<object> CountStaffByPositionId(string id)
        {
            try
            {
                var response = await _positionCollection.Find(s => s.Id == id).FirstOrDefaultAsync();
                long count = response.Staff.Count();
                return count;
            }
            catch (Exception ex)
            {
                return ex.InnerException != null ? ex.InnerException.Message : ex.Message;
            }
        }
        public async Task<string> CreatePosition(Position position)
        {
            try
            {
                await _positionCollection.InsertOneAsync(position);
                return "Success";
            }
            catch (Exception ex)
            {
                return ex.InnerException != null ? ex.InnerException.Message : ex.Message;
            }
        }
        public async Task<object> UpdatePosition(Position position)
        {
            try
            {
                var update = Builders<Position>.Update
                    .Set(s => s.Id, position.Id)
                    .Set(s => s.PositionName, position.PositionName)
                    .Set(s => s.DepartmentID, position.DepartmentID);
                return await _positionCollection.UpdateOneAsync(s => s.Id == position.Id, update);
            }
            catch (Exception ex)
            {
                return ex.InnerException != null ? ex.InnerException.Message : ex.Message;
            }
        }
        public async Task<object> AddStaffInPosition(Position position)
        {
            try
            {
                Position update = await _positionCollection.FindSync(s => s.Id == position.Id).FirstOrDefaultAsync();
                if (update.Staff == null)
                    update.Staff = new List<StaffModels>();
                update.Staff.AddRange(position.Staff);
                return await _positionCollection.ReplaceOneAsync(s => s.Id == update.Id, update);
            }
            catch (Exception ex)
            {
                return ex.InnerException != null ? ex.InnerException.Message : ex.Message;
            }
        }
        public async Task<object> DeletePosition(string id)
        {
            try
            {
                return await _positionCollection.DeleteOneAsync(s => s.Id == id);
            }
            catch (Exception ex)
            {
                return ex.InnerException != null ? ex.InnerException.Message : ex.Message;
            }
        }
        public async Task<object> DeleteStaffPosition(string id, string staffId)
        {
            try
            {
                Position update = await _positionCollection.Find(s => s.Id == id).FirstOrDefaultAsync();
                update.Staff.RemoveAll(s => s.Id == staffId);
                return await _positionCollection.ReplaceOneAsync(s => s.Id == update.Id, update);
            }
            catch (Exception ex)
            {
                return ex.InnerException != null ? ex.InnerException.Message : ex.Message;
            }
        }
    }
}
