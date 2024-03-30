using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace API_MongoDB.Models
{
    public class Shift
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("shiftName")]
        public string? ShiftName { get; set; }

        [BsonElement("beginTime")]
        public string? BeginTime { get; set; }

        [BsonElement("endTime")]
        public string? EndTime { get; set; }

        [BsonElement("shiftTypeID")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? ShiftTypeId { get; set; }
    }
}
