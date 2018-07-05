using System.Collections.Generic;

namespace gmp.DomainModels.Projections
{
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

        public SchoolDTO School { get; set; }
        public ICollection<MemberDTO> Members { get; set; }
    }
}
