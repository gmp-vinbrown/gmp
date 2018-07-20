using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gmp.DomainModels.Entities
{
    [Table("MemberHistory")]
    public class MemberHistory : AuditableEntity
    {
        [Key]
        public int MemberHistoryId { get; set; }

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

        public virtual Member Member { get; set; }
        public virtual ContactInfo ContactInfo { get; set; }
        public virtual Program Program { get; set; }
        public virtual FeeSchedule FeeSchedule { get; set; }
        public virtual Level Level { get; set; }
        public virtual Role Role { get; set; }
        public virtual SchoolLocation SchoolLocation { get; set; }
    }
}
