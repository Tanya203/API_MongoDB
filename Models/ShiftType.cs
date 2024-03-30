using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace API_MongoDB.Models
{
    public class ShiftType
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("shiftTypeName")]
        public string? ShiftTypeName { get; set; }

        [BsonElement("salaryCoefficent")]
        public decimal? SalaryCoefficient { get; set; }
    }
}
