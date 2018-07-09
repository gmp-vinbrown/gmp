using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace gmp.DomainModels.Entities
{
    [Table("SchoolLocation")]
    public partial class SchoolLocation : AuditableEntity
    {
        public SchoolLocation()
        {
            Members = new HashSet<Member>();
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

        public virtual School School { get; set; }
        public virtual ICollection<Member> Members { get; set; }
    }
}
