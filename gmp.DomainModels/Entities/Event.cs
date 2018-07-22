using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace gmp.DomainModels.Entities
{
    [Table("Event")]
    public partial class Event : AuditableEntity
    {
        public Event()
        {
            Attendance = new HashSet<Attendance>();
            EventActivities = new HashSet<EventActivity>();
            Registrations = new HashSet<EventRegistration>();
            Schedules = new HashSet<Schedule>();
        }

        public int EventId { get; set; }
        public int EventTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int SchoolLocationId { get; set; }
        public DateTime EventStartDate { get; set; }
        public DateTime? EventEndDate { get; set; }
        public bool Deleted { get; set; }

        public virtual EventType EventType { get; set; }
        public virtual ICollection<Attendance> Attendance { get; set; }
        public virtual ICollection<EventActivity> EventActivities { get; set; }
        public virtual ICollection<EventRegistration> Registrations { get; set; }
        public virtual ICollection<Schedule> Schedules { get; set; }
    }
}
