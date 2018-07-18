using System;
using System.Collections.Generic;
using AutoMapper.Attributes;
using gmp.DomainModels.Entities;
using Newtonsoft.Json;

namespace gmp.DomainModels.Projections
{
    [MapsFrom(typeof(FeeSchedule))]
    public class FeeScheduleDTO
    {
        public FeeScheduleDTO()
        {
            Members = new HashSet<MemberDTO>();
        }

        public int FeeScheduleId { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public int NumberOfPayments { get; set; }
        public decimal? DiscountAmount { get; set; }
        public decimal? DiscountPercent { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        public bool Deleted { get; set; }

        [JsonIgnore]
        public virtual ICollection<MemberDTO> Members { get; set; }
    }
}
