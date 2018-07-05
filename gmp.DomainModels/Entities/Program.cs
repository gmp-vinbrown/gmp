using System.Collections.Generic;

namespace gmp.DomainModels.Entities
{
    public partial class Program
    {
        public Program()
        {
            FeeSchedules = new HashSet<FeeSchedule>();
        }

        public int ProgramId { get; set; }
        public int SchoolId { get; set; }
        public string Name { get; set; }
        public int DurationDays { get; set; }
        public decimal BaseFee { get; set; }
        public string Description { get; set; }
        public bool Deleted { get; set; }

        public virtual School School { get; set; }
        public virtual ICollection<FeeSchedule> FeeSchedules { get; set; }
    }
}
