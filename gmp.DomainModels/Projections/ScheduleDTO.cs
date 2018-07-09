using AutoMapper.Attributes;
using gmp.DomainModels.Entities;

namespace gmp.DomainModels.Projections
{
    [MapsFrom(typeof(Schedule))]
    public class ScheduleDTO : AuditableEntity
    {
        public int ScheduleId { get; set; }
        public int EventId { get; set; }
        public string Days { get; set; }
        public string StartTime { get; set; }
        public int DurationMinutes { get; set; }

        public virtual EventDTO Event { get; set; }
    }
}
