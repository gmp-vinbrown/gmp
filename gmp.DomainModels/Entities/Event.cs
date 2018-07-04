using System;
using System.Collections.Generic;

namespace gmp.DomainModels.Entities
{
    public partial class Event : AuditableEntity
    {
        public Event()
        {
            Attendance = new HashSet<Attendance>();
            EventActivity = new HashSet<EventActivity>();
            Registration = new HashSet<EventRegistration>();
        }

        public int EventId { get; set; }
        public int EventTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int SchoolLocationId { get; set; }
        public DateTime EventStartDate { get; set; }
        public DateTime? EventEndDate { get; set; }
        public string Schedule { get; set; }
        public bool Deleted { get; set; }

        public virtual EventType EventType { get; set; }
        public virtual ICollection<Attendance> Attendance { get; set; }
        public virtual ICollection<EventActivity> EventActivity { get; set; }
        public virtual ICollection<EventRegistration> Registration { get; set; }
        public virtual ICollection<Schedule> Schedules { get; set; }
    }
}
