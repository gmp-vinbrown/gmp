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
            AttendanceEventActivityTypes = new HashSet<AttendanceEventActivityTypeDTO>();
            EventActivities = new HashSet<EventActivityDTO>();
        }

        public int EventActivityTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        [JsonIgnore]
        public ICollection<AttendanceEventActivityTypeDTO> AttendanceEventActivityTypes { get; set; }

        [JsonIgnore]
        public ICollection<EventActivityDTO> EventActivities { get; set; }
    }
}
