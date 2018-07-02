using System;
using System.Collections.Generic;

namespace gmp.DomainModels.Entities
{
    public partial class SchoolLocation
    {
        public SchoolLocation()
        {
            Member = new HashSet<Member>();
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
        public DateTime? Created { get; set; }
        public bool Deleted { get; set; }

        public School School { get; set; }
        public ICollection<Member> Member { get; set; }
    }
}
