using System;
using System.Collections.Generic;

namespace gmp.DomainModels.Entities
{
    public partial class AttendanceEventActivityType
    {
        public int AttendanceEventActivityTypeId { get; set; }
        public int AttendanceId { get; set; }
        public int EventActivityTypeId { get; set; }

        public Attendance Attendance { get; set; }
        public EventActivityType EventActivityType { get; set; }
    }
}
