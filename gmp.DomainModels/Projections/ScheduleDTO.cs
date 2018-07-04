using gmp.DomainModels.Entities;

namespace gmp.DomainModels.Projections
{
    public class ScheduleDTO : AuditableEntity
    {
        public int ScheduleId { get; set; }
        public int EventId { get; set; }
        public string Days { get; set; }
        public string StartTime { get; set; }
        public int DurationMinutes { get; set; }

        public EventDTO Event { get; set; }
    }
}
