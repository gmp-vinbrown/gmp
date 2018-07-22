using System.ComponentModel.DataAnnotations.Schema;

namespace gmp.DomainModels.Entities
{
    [Table("Schedule")]
    public class Schedule : AuditableEntity
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

        public virtual Event Event { get; set; }
    }
}
