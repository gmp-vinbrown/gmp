using System.Collections.Generic;
using AutoMapper.Attributes;
using gmp.DomainModels.Entities;

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

        public ICollection<AttendanceEventActivityTypeDTO> AttendanceEventActivityType { get; set; }
        public ICollection<EventActivityDTO> EventActivity { get; set; }
    }
}
