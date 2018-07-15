using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace gmp.DomainModels.Entities
{
    [Table("Program")]
    public partial class Program
    {
        public Program()
        {
            Members = new HashSet<Member>();
        }

        public int ProgramId { get; set; }
        public int SchoolId { get; set; }
        public string Name { get; set; }
        public int DurationDays { get; set; }
        public decimal BaseFee { get; set; }
        public string Description { get; set; }
        public bool Deleted { get; set; }

        public virtual School School { get; set; }
        public virtual ICollection<Member> Members { get; set; }
    }
}
