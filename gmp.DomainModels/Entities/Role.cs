using System;
using System.Collections.Generic;

namespace gmp.DomainModels.Entities
{
    public partial class Role
    {
        public Role()
        {
            Contact = new HashSet<Contact>();
            Member = new HashSet<Member>();
        }

        public int RoleId { get; set; }
        public int SchoolId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public School School { get; set; }
        public ICollection<Contact> Contact { get; set; }
        public ICollection<Member> Member { get; set; }
    }
}
