using AutoMapper.Attributes;
using gmp.DomainModels.Entities;
using Newtonsoft.Json;

namespace gmp.DomainModels.Projections
{
    [MapsFrom(typeof(Schedule))]
    public class ScheduleDTO : AuditableEntity
    {
        public int ScheduleId { get; set; }
        public int EventId { get; set; }

        /// <summary>
        /// Days are stored as 0|1|2|3|4|5|6 where the number represents a day of the week.
        /// Example: 1|3|5 represents an event that meets on Monday, Wednesday and Friday.
        /// </summary>
        public string Days { get; set; }
        public string StartTime { get; set; }
        public int DurationMinutes { get; set; }

        [JsonIgnore]
        public virtual EventDTO Event { get; set; }
    }
}
