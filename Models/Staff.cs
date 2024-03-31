using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace API_MongoDB.Models
{
    public class Staff
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("account")]
        public string? Account { get; set; }

        [BsonElement("password")]
        public string? Password { get; set; }

        [BsonElement("idCard")]
        public string? IdCard { get; set; }

        [BsonElement("fullName")]
        public string? FullName { get; set; }

        [BsonElement("dateOfBrith")]
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime DateOfBirth { get; set; }

        [BsonElement("address")]
        public string? Address { get; set; }

        [BsonElement("gender")]
        public string? Gender { get; set; }

        [BsonElement("phone")]
        public string? Phone { get; set; }

        [BsonElement("email")]
        public string? Email { get; set; }

        [BsonElement("educationLevel")]
        public string? EducationLevel { get; set; }

        [BsonElement("entryDate")]
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime? EntryDate { get; set; }

        [BsonElement("contractDuration")]
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime? ContractDuration { get; set; }

        [BsonElement("status")]
        public string? Status { get; set; }

        [BsonElement("dayOff")]
        [BsonRepresentation(BsonType.Int64)]
        public long? DayOff { get; set; }

        [BsonElement("basicSalary")]
        [BsonRepresentation(BsonType.Decimal128)]
        public decimal? BasicSalary { get; set; }
    }
}
