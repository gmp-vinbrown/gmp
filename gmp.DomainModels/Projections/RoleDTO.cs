using System;
using System.Collections.Generic;
using System.Text;

namespace gmp.DomainModels.Projections
{
    public class RoleDTO
    {
        public RoleDTO()
        {
            Members = new HashSet<MemberDTO>();
        }

        public int RoleId { get; set; }
        public int SchoolId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual SchoolDTO School { get; set; }
        public virtual ICollection<MemberDTO> Members { get; set; }
    }
}
