﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace gmp.DomainModels.Entities
{
    [Table("School")]
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
        public bool Deleted { get; set; }

        public virtual ICollection<Level> Levels { get; set; }
        public virtual ICollection<Program> Programs { get; set; }
        public virtual ICollection<Role> Roles { get; set; }
        public virtual ICollection<SchoolLocation> SchoolLocations { get; set; }
    }
}
