using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace gmp.DomainModels.Entities
{
    [Table("EventActivityType")]
    public partial class EventActivityType
    {
        public EventActivityType()
        {
            AttendanceEventActivityType = new HashSet<AttendanceEventActivityType>();
            EventActivity = new HashSet<EventActivity>();
        }

        public int EventActivityTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<AttendanceEventActivityType> AttendanceEventActivityType { get; set; }
        public virtual ICollection<EventActivity> EventActivity { get; set; }
    }
}
