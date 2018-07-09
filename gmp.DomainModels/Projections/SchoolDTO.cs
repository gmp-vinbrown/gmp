using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AutoMapper.Attributes;
using gmp.DomainModels.Entities;

namespace gmp.DomainModels.Projections
{
    [MapsFrom(typeof(School))]
    public class SchoolDTO : AuditableEntity
    {
        

        public SchoolDTO()
        {
            Levels = new HashSet<LevelDTO>();
            Programs = new HashSet<ProgramDTO>();
            Roles = new HashSet<RoleDTO>();
            SchoolLocations = new HashSet<SchoolLocationDTO>();
        }

        public int SchoolId { get; set; }
        [MaxLength(250)]
        public string Name { get; set; }
        [MaxLength(10)]
        public string Code { get; set; }
        public bool Deleted { get; set; }

        public virtual ICollection<LevelDTO> Levels { get; set; }
        public virtual ICollection<ProgramDTO> Programs { get; set; }
        public virtual ICollection<RoleDTO> Roles { get; set; }
        public virtual ICollection<SchoolLocationDTO> SchoolLocations { get; set; }
    }
}
