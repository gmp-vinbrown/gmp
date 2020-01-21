using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace gmp.DomainModels.Entities
{
    [Table("EventActivityType")]
    public partial class EventActivityType
    {
        public EventActivityType()
        {
            AttendanceEventActivityTypes = new HashSet<AttendanceEventActivityType>();
            EventActivities = new HashSet<EventActivity>();
        }

        public int EventActivityTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public int? MinAge { get; set; }
        public int? MaxAge { get; set; }

        public int? MinWeight { get; set; }
        public int? MaxWeight { get; set; }

        public int? MinLevel { get; set; }
        public int? MaxLevel { get; set; }

        public int? GenderId { get; set; }
        
        public virtual ICollection<AttendanceEventActivityType> AttendanceEventActivityTypes { get; set; }
        public virtual ICollection<EventActivity> EventActivities { get; set; }
    }
}
