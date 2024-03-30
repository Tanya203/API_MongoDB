using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace API_MongoDB.Models
{
    public class WorkSchedule
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("workDate")]
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime? WorkDate { get; set; }

        [BsonElement("detail")]
        public Detail[]? Array { get; set; }

        public class Detail
        {
            [BsonElement("$oid")]
            [BsonRepresentation(BsonType.ObjectId)]
            public required string StaffID { get; set; }

            [BsonElement("dateOff")]
            public bool DateOff { get; set; }

            [BsonElement("timeKeeping")]
            public TimeKeeping TimeKeeping { get; set; }
        }

        public class TimeKeeping
        {
            [BsonElement("$oid")]
            [BsonRepresentation(BsonType.ObjectId)]
            public required string ShiftID { get; set; }

            [BsonElement("checkIn")]
            public string? ShifTypeID { get; set; }

            [BsonElement("checkOut")]
            public string? CheckOut { get; set; }
        }
    }
}
