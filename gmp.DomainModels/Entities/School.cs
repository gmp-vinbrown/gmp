using System;
using System.Collections.Generic;

namespace gmp.DomainModels.Entities
{
    public partial class School : AuditableEntity
    {
        public School()
        {
            Levels = new HashSet<Level>();
            Programs = new HashSet<Program>();
            Roles = new HashSet<Role>();
            SchoolLocations = new HashSet<SchoolLocation>();
        }

        public int SchoolId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public DateTime? Created { get; set; }

        public ICollection<Level> Levels { get; set; }
        public ICollection<Program> Programs { get; set; }
        public ICollection<Role> Roles { get; set; }
        public ICollection<SchoolLocation> SchoolLocations { get; set; }
    }
}
