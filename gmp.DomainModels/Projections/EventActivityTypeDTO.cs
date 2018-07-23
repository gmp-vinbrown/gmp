using System.Collections.Generic;
using AutoMapper.Attributes;
using gmp.DomainModels.Entities;
using Newtonsoft.Json;

namespace gmp.DomainModels.Projections
{
    [MapsFrom(typeof(EventActivityType))]
    public class EventActivityTypeDTO
    {
        public EventActivityTypeDTO()
        {
            AttendanceEventActivityType = new HashSet<AttendanceEventActivityTypeDTO>();
            EventActivity = new HashSet<EventActivityDTO>();
        }

        public int EventActivityTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        [JsonIgnore]
        public ICollection<AttendanceEventActivityTypeDTO> AttendanceEventActivityType { get; set; }

        [JsonIgnore]
        public ICollection<EventActivityDTO> EventActivity { get; set; }
    }
}
