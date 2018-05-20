using System;
using System.Collections.Generic;

namespace gmp.DomainModels.Entities
{
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

        public ICollection<AttendanceEventActivityType> AttendanceEventActivityType { get; set; }
        public ICollection<EventActivity> EventActivity { get; set; }
    }
}
