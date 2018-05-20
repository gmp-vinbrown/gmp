using System;
using System.Collections.Generic;

namespace gmp.DomainModels.Entities
{
    public partial class Member
    {
        public Member()
        {
            Attendance = new HashSet<Attendance>();
            MemberEventActivity = new HashSet<MemberEventActivity>();
            Registration = new HashSet<Registration>();
        }

        public int MemberId { get; set; }
        public int SchoolLocationId { get; set; }
        public int RoleId { get; set; }
        public int FeeScheduleId { get; set; }
        public string Prefix { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Suffix { get; set; }
        public string Gender { get; set; }
        public int LevelId { get; set; }
        public string Notes { get; set; }
        public DateTime Created { get; set; }
        public bool Deleted { get; set; }

        public FeeSchedule FeeSchedule { get; set; }
        public Level Level { get; set; }
        public Role Role { get; set; }
        public SchoolLocation SchoolLocation { get; set; }
        public ICollection<Attendance> Attendance { get; set; }
        public ICollection<MemberEventActivity> MemberEventActivity { get; set; }
        public ICollection<Registration> Registration { get; set; }
    }
}
