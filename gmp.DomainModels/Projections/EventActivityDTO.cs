using System.Collections.Generic;
using AutoMapper.Attributes;
using gmp.DomainModels.Entities;
using Newtonsoft.Json;

namespace gmp.DomainModels.Projections
{
    [MapsFrom(typeof(EventActivity))]
    public class EventActivityDTO
    {
        public EventActivityDTO()
        {
            MemberEventActivity = new HashSet<MemberEventActivityDTO>();
        }

        public int EventActivityId { get; set; }
        public int EventId { get; set; }
        public int EventActivityTypeId { get; set; }
        public bool Deleted { get; set; }

        [JsonIgnore]
        public EventDTO Event { get; set; }

        public EventActivityTypeDTO EventActivityType { get; set; }

        [JsonIgnore]
        public ICollection<MemberEventActivityDTO> MemberEventActivity { get; set; }
    }
}
