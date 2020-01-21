using System.Collections.Generic;
using System.Text.Json.Serialization;
using AutoMapper.Attributes;
using gmp.DomainModels.Entities;

namespace gmp.DomainModels.Projections
{
    [MapsFrom(typeof(Level))]
    public class LevelDTO
    {
        public LevelDTO()
        {
            Members = new HashSet<MemberDTO>();
        }

        public int LevelId { get; set; }
        public int SchoolId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? Value { get; set; }
        public bool Deleted { get; set; }

        [JsonIgnore]
        public virtual SchoolDTO School { get; set; }

        [JsonIgnore]
        public virtual ICollection<MemberDTO> Members { get; set; }
    }
}
