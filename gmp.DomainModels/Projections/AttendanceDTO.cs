using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using AutoMapper.Attributes;
using gmp.DomainModels.Entities;

namespace gmp.DomainModels.Projections
{
    [MapsFrom(typeof(Attendance))]
    public class AttendanceDTO
    {
        public AttendanceDTO()
        {
            AttendanceEventActivityTypes = new HashSet<AttendanceEventActivityTypeDTO>();
        }

        public int AttendanceId { get; set; }
        public int MemberId { get; set; }
        public int EventId { get; set; }
        public DateTime EventDate { get; set; }
        public string Notes { get; set; }
        public bool Deleted { get; set; }

        [JsonIgnore]
        public virtual EventDTO Event { get; set; }
        [JsonIgnore]
        public virtual MemberDTO Member { get; set; }
        [JsonIgnore]
        public virtual ICollection<AttendanceEventActivityTypeDTO> AttendanceEventActivityTypes { get; set; }
    }
}
