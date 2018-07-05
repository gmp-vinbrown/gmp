using System.Collections.Generic;
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
        public string Name { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string StateCode { get; set; }
        public string Zip { get; set; }
        public bool Deleted { get; set; }

        public SchoolDTO School { get; set; }
        public ICollection<MemberDTO> Members { get; set; }
    }
}
