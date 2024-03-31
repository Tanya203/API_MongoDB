using API_MongoDB.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace API_MongoDB.Services
{
    public class DepartmentServices
    {
        private readonly IMongoCollection<Department> _departmentCollection;

        public DepartmentServices(IOptions<DatabaseSettings> dbSettings)
        {
            var mongoClient = new MongoClient(dbSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(dbSettings.Value.DatabaseName);
            _departmentCollection = mongoDatabase.GetCollection<Department>(dbSettings.Value.DepartmentCollectionName);
        }
        public async Task<List<Department>> GetAllDepartment()
        {
            var response = await _departmentCollection.Find(_ => true).ToListAsync();
            return response;
        }
        public async Task<Department> GetDepartmentById(string id)
        {
            var response = await _departmentCollection.Find(s => s.Id == id).FirstOrDefaultAsync();
            return response;
        }
        public async Task<Department> GetDepartmentByName(string name)
        {
            var response = await _departmentCollection.Find(s => s.DepartmentName == name).FirstOrDefaultAsync();
            return response;
        }
        public async Task<object> CountStaffByDepartmentId(string id)
        {
            try
            {
                var response = await _departmentCollection.Find(s => s.Id == id).FirstOrDefaultAsync();
                long count = response.Staff.Count();
                return count;
            }
            catch (Exception ex)
            {
                return ex.InnerException != null ? ex.InnerException.Message : ex.Message;
            }
        }
        public async Task<string> CreateDepartment(Department department)
        {
            try
            {
                await _departmentCollection.InsertOneAsync(department);
                return "Success";
            }
            catch (Exception ex)
            {
                return ex.InnerException != null ? ex.InnerException.Message : ex.Message;
            }
        }
        public async Task<object> UpdateDepartment(Department department)
        {
            try
            {
                var update = Builders<Department>.Update
                    .Set(s => s.Id, department.Id)
                    .Set(s => s.DepartmentName, department.DepartmentName);
                return await _departmentCollection.UpdateOneAsync(s => s.Id == department.Id, update);
            }
            catch (Exception ex)
            {
                return ex.InnerException != null ? ex.InnerException.Message : ex.Message;
            }
        }
        public async Task<object> AddStaffInDepartment(Department department)
        {
            try
            {
                Department update = await _departmentCollection.FindSync(s => s.Id == department.Id).FirstOrDefaultAsync();
                if (update.Staff == null)
                    update.Staff = new List<StaffModels>();
                update.Staff.AddRange(department.Staff);
                return await _departmentCollection.ReplaceOneAsync(s => s.Id == update.Id, update);
            }
            catch (Exception ex)
            {
                return ex.InnerException != null ? ex.InnerException.Message : ex.Message;
            }
        }
        public async Task<object> DeleteDepartment(string id)
        {
            try
            {
                return await _departmentCollection.DeleteOneAsync(s => s.Id == id);
            }
            catch (Exception ex)
            {
                return ex.InnerException != null ? ex.InnerException.Message : ex.Message;
            }
        }
        public async Task<object> DeleteStaffDepartment(string id, string staffId)
        {
            try
            {
                Department update = await _departmentCollection.Find(s => s.Id == id).FirstOrDefaultAsync();
                update.Staff.RemoveAll(s => s.Id == staffId);
                return await _departmentCollection.ReplaceOneAsync(s => s.Id == update.Id, update);
            }
            catch (Exception ex)
            {
                return ex.InnerException != null ? ex.InnerException.Message : ex.Message;
            }
        }
    }
}
