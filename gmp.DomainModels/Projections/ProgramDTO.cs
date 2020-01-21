using System.Collections.Generic;
using System.Text.Json.Serialization;
using AutoMapper.Attributes;
using gmp.DomainModels.Entities;

namespace gmp.DomainModels.Projections
{
    [MapsFrom(typeof(Program))]
    public partial class ProgramDTO
    {
        public ProgramDTO()
        {
            Members = new HashSet<MemberDTO>();
        }

        public int ProgramId { get; set; }
        public int SchoolId { get; set; }
        public string Name { get; set; }
        public int DurationDays { get; set; }
        public decimal BaseFee { get; set; }
        public string Description { get; set; }
        public bool Deleted { get; set; }

        [JsonIgnore]
        public virtual SchoolDTO School { get; set; }

        [JsonIgnore]
        public virtual ICollection<MemberDTO> Members { get; set; }
    }
}
