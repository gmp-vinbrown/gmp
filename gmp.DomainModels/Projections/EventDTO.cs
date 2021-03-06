﻿using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using AutoMapper.Attributes;
using gmp.DomainModels.Entities;

namespace gmp.DomainModels.Projections
{
    [MapsFrom(typeof(Event))]
    public class EventDTO : AuditableEntity
    {
        public EventDTO()
        {
            Attendance = new HashSet<AttendanceDTO>();
            EventActivities = new HashSet<EventActivityDTO>();
            Registrations = new HashSet<EventRegistrationDTO>();
            Schedules = new HashSet<ScheduleDTO>();
            FeeGroups = new HashSet<EventFeeGroupDTO>();
        }

        public int EventId { get; set; }
        public int EventTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int SchoolLocationId { get; set; }
        public DateTime EventStartDate { get; set; }
        public DateTime? EventEndDate { get; set; }
        public bool Deleted { get; set; }

        public virtual EventTypeDTO EventType { get; set; }
        public virtual ICollection<AttendanceDTO> Attendance { get; set; }
        public virtual ICollection<EventActivityDTO> EventActivities { get; set; }
        public virtual ICollection<EventFeeGroupDTO> FeeGroups { get; set; }
        [JsonIgnore]
        public virtual ICollection<EventRegistrationDTO> Registrations { get; set; }
        public virtual IEnumerable<ScheduleDTO> Schedules { get; set; }
    }
}
