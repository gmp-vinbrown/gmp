using System;
using System.Collections.Generic;

namespace gmp.DomainModels.Entities
{
    public partial class School
    {
        public School()
        {
            Level = new HashSet<Level>();
            Program = new HashSet<Program>();
            Role = new HashSet<Role>();
            SchoolLocation = new HashSet<SchoolLocation>();
        }

        public int SchoolId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public DateTime? Created { get; set; }

        public ICollection<Level> Level { get; set; }
        public ICollection<Program> Program { get; set; }
        public ICollection<Role> Role { get; set; }
        public ICollection<SchoolLocation> SchoolLocation { get; set; }
    }
}
