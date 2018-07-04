﻿namespace gmp.DomainModels.Entities
{
    public partial class AttendanceEventActivityType
    {
        public int AttendanceEventActivityTypeId { get; set; }
        public int AttendanceId { get; set; }
        public int EventActivityTypeId { get; set; }

        public virtual Attendance Attendance { get; set; }
        public virtual EventActivityType EventActivityType { get; set; }
    }
}
