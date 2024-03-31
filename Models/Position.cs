using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace API_MongoDB.Models
{
    public class Position
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("positionName")]
        public string? PositionName { get; set; }

        [BsonElement("departmentID")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? DepartmentID { get; set; }

        [BsonElement("staff")]
        public List<StaffModels>? Staff { get; set; }
    }
}
