using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using gmp.DomainModels.Entities;

namespace gmp.DomainModels.Projections
{
    public class SchoolLocationDTO : AuditableEntity
    {
        public SchoolLocationDTO()
        {
            Members = new HashSet<MemberDTO>();
        }

        public int SchoolLocationId { get; set; }
        public int SchoolId { get; set; }
        public bool IsPrimary { get; set; }
        [MaxLength(250)]
        public string Name { get; set; }
        [MaxLength(250)]
        public string Address1 { get; set; }
        [MaxLength(250)]
        public string Address2 { get; set; }
        [MaxLength(150)]
        public string City { get; set; }
        [MaxLength(4)]
        public string StateCode { get; set; }
        [MaxLength(10)]
        public string Zip { get; set; }
        public bool Deleted { get; set; }

        public SchoolDTO School { get; set; }
        public ICollection<MemberDTO> Members { get; set; }
    }
}
