using System;
using System.Collections.Generic;

namespace gmp.DomainModels.Entities
{
    public partial class Member : AuditableEntity
    {
        public Member()
        {
            Attendance = new HashSet<Attendance>();
            MemberEventActivities = new HashSet<MemberEventActivity>();
            Registrations = new HashSet<EventRegistration>();
        }

        public int MemberId { get; set; }
        public int SchoolLocationId { get; set; }
        public int ContactInfoId { get; set; }
        public int RoleId { get; set; }
        public int? FeeScheduleId { get; set; }
        public string Prefix { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Suffix { get; set; }
        public string Gender { get; set; }
        public decimal Weight { get; set; }
        public DateTime DOB { get; set; }
        public int Age { get; set; }
        public int LevelId { get; set; }
        public string Notes { get; set; }
        public bool Deleted { get; set; }

        public ContactInfo ContactInfo { get; set; }
        public FeeSchedule FeeSchedule { get; set; }
        public Level Level { get; set; }
        public Role Role { get; set; }
        public SchoolLocation SchoolLocation { get; set; }
        public ICollection<Payment> Payments { get; set; }
        public ICollection<Attendance> Attendance { get; set; }
        public ICollection<MemberEventActivity> MemberEventActivities { get; set; }
        public ICollection<EventRegistration> Registrations { get; set; }
    }
}
