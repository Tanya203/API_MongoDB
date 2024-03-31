using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace API_MongoDB.Models
{
    public class TimeKeepingMethod
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("timeKeepingMethodName")]
        public string? TimeKeepingMethodName { get; set; }
    }
}
