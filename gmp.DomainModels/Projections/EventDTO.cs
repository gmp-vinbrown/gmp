using System;
using System.Collections.Generic;
using AutoMapper.Attributes;
using gmp.DomainModels.Entities;

namespace gmp.DomainModels.Projections
{
    [MapsFrom(typeof(Event))]
    public class EventDTO
    {
        public EventDTO()
        {
            Attendance = new HashSet<AttendanceDTO>();
            EventActivity = new HashSet<EventActivityDTO>();
            Registration = new HashSet<EventRegistrationDTO>();
        }

        public int EventId { get; set; }
        public int EventTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int SchoolLocationId { get; set; }
        public DateTime EventStartDate { get; set; }
        public DateTime? EventEndDate { get; set; }
        public bool Deleted { get; set; }

        public EventTypeDTO EventType { get; set; }
        public ICollection<AttendanceDTO> Attendance { get; set; }
        public ICollection<EventActivityDTO> EventActivity { get; set; }
        public ICollection<EventRegistrationDTO> Registration { get; set; }
    }
}
