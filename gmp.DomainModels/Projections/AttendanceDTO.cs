using System;
using System.Collections.Generic;
using AutoMapper.Attributes;
using gmp.DomainModels.Entities;

namespace gmp.DomainModels.Projections
{
    [MapsFrom(typeof(Attendance))]
    public class AttendanceDTO
    {
        public AttendanceDTO()
        {
            AttendanceEventActivityType = new HashSet<AttendanceEventActivityTypeDTO>();
        }

        public int AttendanceId { get; set; }
        public int MemberId { get; set; }
        public int EventId { get; set; }
        public DateTime EventDate { get; set; }
        public string Notes { get; set; }
        public bool Deleted { get; set; }

        public virtual EventDTO Event { get; set; }
        public virtual MemberDTO Member { get; set; }
        public virtual ICollection<AttendanceEventActivityTypeDTO> AttendanceEventActivityType { get; set; }
    }
}
