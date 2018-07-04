using System;
using System.Collections.Generic;

namespace gmp.DomainModels.Entities
{
    public partial class Attendance
    {
        public Attendance()
        {
            AttendanceEventActivityType = new HashSet<AttendanceEventActivityType>();
        }

        public int AttendanceId { get; set; }
        public int MemberId { get; set; }
        public int EventId { get; set; }
        public DateTime EventDate { get; set; }
        public string Notes { get; set; }
        public bool Deleted { get; set; }

        public Event Event { get; set; }
        public Member Member { get; set; }
        public ICollection<AttendanceEventActivityType> AttendanceEventActivityType { get; set; }
    }
}
