using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace gmp.DomainModels.Entities
{
    [Table("Level")]
    public partial class Level
    {
        public Level()
        {
            Members = new HashSet<Member>();
        }

        public int LevelId { get; set; }
        public int SchoolId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? Value { get; set; }
        public bool Deleted { get; set; }

        public virtual School School { get; set; }
        public virtual ICollection<Member> Members { get; set; }
    }
}
