namespace gmp.DomainModels.Entities
{
    public class Schedule : AuditableEntity
    {
        public int ScheduleId { get; set; }
        public int EventId { get; set; }
        public string Days { get; set; }
        public string StartTime { get; set; }
        public int DurationMinutes { get; set; }

        public virtual Event Event { get; set; }
    }
}
