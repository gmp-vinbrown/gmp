using System.Collections.Generic;
using System.Text.Json.Serialization;
using AutoMapper.Attributes;
using gmp.DomainModels.Entities;

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

        public int? MinAge { get; set; }
        public int? MaxAge { get; set; }

        public int? MinWeight { get; set; }
        public int? MaxWeight { get; set; }

        public int? MinLevel { get; set; }
        public int? MaxLevel { get; set; }

        public int? GenderId { get; set; }

        [JsonIgnore]
        public ICollection<AttendanceEventActivityTypeDTO> AttendanceEventActivityTypes { get; set; }

        [JsonIgnore]
        public ICollection<EventActivityDTO> EventActivities { get; set; }
    }
}
