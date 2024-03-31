namespace API_MongoDB.Models
{
    public class DatabaseSettings
    {
        public string? ConnectionString { get; set; }

        public string? DatabaseName { get; set; }

        public string? BenefitCollectionName { get; set; }

        public string? ContractTypeCollectionName { get; set; }

        public string? DepartmentCollectionName { get; set; }

        public string? PositionCollectionName { get; set; }

        public string? ShiftCollectionName { get; set; }

        public string? ShiftTypeColectionName { get; set; }

        public string? StaffCollectionName { get; set; }

        public string? TimeKeepingMethodCollectionName { get; set; }

        public string? WorkScheduleCollectionName { get; set; }
    }
}
