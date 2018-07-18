using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AutoMapper.Attributes;
using gmp.DomainModels.Entities;
using Newtonsoft.Json;

namespace gmp.DomainModels.Projections
{
    [MapsFrom(typeof(SchoolLocation))]
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

        [JsonIgnore]
        public virtual SchoolDTO School { get; set; }

        [JsonIgnore]
        public virtual ICollection<MemberDTO> Members { get; set; }
    }
}
