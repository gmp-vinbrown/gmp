using System.Collections.Generic;
using AutoMapper.Attributes;
using gmp.DomainModels.Entities;

namespace gmp.DomainModels.Projections
{
    [MapsFrom(typeof(Program))]
    public partial class ProgramDTO
    {
        public ProgramDTO()
        {
            FeeSchedules = new HashSet<FeeScheduleDTO>();
        }

        public int ProgramId { get; set; }
        public int SchoolId { get; set; }
        public string Name { get; set; }
        public int DurationDays { get; set; }
        public decimal BaseFee { get; set; }
        public string Description { get; set; }
        public bool Deleted { get; set; }

        public virtual SchoolDTO School { get; set; }
        public virtual ICollection<FeeScheduleDTO> FeeSchedules { get; set; }
    }
}
