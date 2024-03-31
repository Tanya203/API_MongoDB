using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace API_MongoDB.Models
{
    public class ContractType
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("contractTypeName")]
        public string? ContractTypeName { get; set; }

        [BsonElement("timeKeepingMehotdID")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? TimeKeepingMethodId { get; set; }

        [BsonElement("staff")]
        public List<StaffModels>? Staff { get; set; }
        
    }
}
