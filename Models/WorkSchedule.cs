using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace API_MongoDB.Models
{
    public class WorkSchedule
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("workDate")]
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime? WorkDate { get; set; }

        [BsonElement("detail")]
        public List<Detail>? Details { get; set; }

        public class Detail
        {
            [BsonId]
            [BsonRepresentation(BsonType.ObjectId)]
            public string? StaffId { get; set; }

            [BsonElement("dateOff")]
            public bool? DateOff { get; set; }

            [BsonElement("timeKeeping")]
            public List<TimeKeeping>? TimeKeeping { get; set; }
        }

        public class TimeKeeping
        {
            [BsonId]
            [BsonRepresentation(BsonType.ObjectId)]
            public string? ShiftId { get; set; }

            [BsonElement("checkIn")]
            public string? CheckIn { get; set; }

            [BsonElement("checkOut")]
            public string? CheckOut { get; set; }           
        }
    }
}
