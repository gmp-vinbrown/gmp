using System.Collections.Generic;

namespace gmp.DomainModels.Entities
{
    public partial class Role
    {
        public Role()
        {
            Member = new HashSet<Member>();
        }

        public int RoleId { get; set; }
        public int SchoolId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual School School { get; set; }
        public virtual ICollection<Member> Member { get; set; }
    }
}
