using System;
using System.Collections.Generic;
using AutoMapper.Attributes;
using gmp.DomainModels.Entities;

namespace gmp.DomainModels.Projections
{
    [MapsFrom(typeof(Member))]
    public class MemberDTO : AuditableEntity
    {
        public MemberDTO()
        {
            Attendance = new HashSet<AttendanceDTO>();
            MemberEventActivities = new HashSet<MemberEventActivityDTO>();
            Registrations = new HashSet<EventRegistrationDTO>();
            Payments = new HashSet<PaymentDTO>();
        }

        public int MemberId { get; set; }
        public int SchoolLocationId { get; set; }
        public int? ContactInfoId { get; set; }
        public int RoleId { get; set; }
        public int? ProgramId { get; set; }
        public int? FeeScheduleId { get; set; }
        public string Prefix { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Suffix { get; set; }
        public string Gender { get; set; }
        public decimal? Weight { get; set; }
        public DateTime? DOB { get; set; }
        public int? Age { get; set; }
        public int? LevelId { get; set; }
        public string Notes { get; set; }
        public bool Deleted { get; set; }

        public virtual ContactInfoDTO ContactInfo { get; set; }
        public virtual ProgramDTO Program { get; set; }
        public virtual FeeScheduleDTO FeeSchedule { get; set; }
        public virtual LevelDTO Level { get; set; }
        public virtual RoleDTO Role { get; set; }
        public virtual SchoolLocationDTO SchoolLocation { get; set; }
        public virtual ICollection<PaymentDTO> Payments { get; set; }
        public virtual ICollection<AttendanceDTO> Attendance { get; set; }
        public virtual ICollection<MemberEventActivityDTO> MemberEventActivities { get; set; }
        public virtual ICollection<EventRegistrationDTO> Registrations { get; set; }
    }
}
