﻿using gmp.DomainModels.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gmp.DomainModels.Entities
{    
    [Table("Member")]
    public partial class Member : AuditableEntity
    {
        public Member()
        {
            Attendance = new HashSet<Attendance>();
            MemberEventActivities = new HashSet<MemberEventActivity>();
            Registrations = new HashSet<EventRegistration>();
            Payments = new HashSet<Payment>();
        }

        [Key]
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
        public Gender Gender { get; set; }
        public decimal? Weight { get; set; }
        public DateTime? DOB { get; set; }
        public int? Age {
            get {
                if (!DOB.HasValue) return -1;
                var today = DateTime.UtcNow;
                var age = today.Year - DOB.Value.Year;
                age -= Convert.ToInt32(today.Date < DOB.Value.Date.AddYears(age));
                return age;
            }
        }
        public int? LevelId { get; set; }
        public string Notes { get; set; }
        public bool Deleted { get; set; }
        public virtual ContactInfo ContactInfo { get; set; }
        public virtual Program Program { get; set; }
        public virtual FeeSchedule FeeSchedule { get; set; }
        public virtual Level Level { get; set; }
        public virtual Role Role { get; set; }
        public virtual SchoolLocation SchoolLocation { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
        public virtual ICollection<Attendance> Attendance { get; set; }
        public virtual ICollection<MemberEventActivity> MemberEventActivities { get; set; }
        public virtual ICollection<EventRegistration> Registrations { get; set; }
    }
}
