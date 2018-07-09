using System.Collections.Generic;
using AutoMapper.Attributes;
using gmp.DomainModels.Entities;

namespace gmp.DomainModels.Projections
{
    [MapsFrom(typeof(Role))]
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
