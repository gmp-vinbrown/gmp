using System.Collections.Generic;
using AutoMapper.Attributes;
using gmp.DomainModels.Entities;

namespace gmp.DomainModels.Projections
{
    [MapsFrom(typeof(EventType))]
    public class EventTypeDTO
    {
        public EventTypeDTO()
        {
            Events = new HashSet<EventDTO>();
        }

        public int EventTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<EventDTO> Events { get; set; }
    }
}
