using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace API_MongoDB.Models
{
    public class Benefit
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("benefitName")]
        public string? BenefitName { get; set; }

        [BsonElement("amount")]
        [BsonRepresentation(BsonType.Decimal128)]
        public decimal? Amount { get; set; }

        [BsonElement("staff")]
        public List<StaffModels>? Staff { get; set; }
    } 
}
