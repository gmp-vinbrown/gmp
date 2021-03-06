﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace gmp.DomainModels.Entities
{
    [Table("Attendance")]
    public partial class Attendance
    {
        public Attendance()
        {
            AttendanceEventActivityTypes = new HashSet<AttendanceEventActivityType>();
        }

        public int AttendanceId { get; set; }
        public int MemberId { get; set; }
        public int EventId { get; set; }
        public DateTime EventDate { get; set; }
        public string Notes { get; set; }
        public bool Deleted { get; set; }
        
        public virtual Event Event { get; set; }
        public virtual Member Member { get; set; }
        public virtual ICollection<AttendanceEventActivityType> AttendanceEventActivityTypes { get; set; }
    }
}
