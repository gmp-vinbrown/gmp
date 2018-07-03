﻿using System;
using System.Collections.Generic;

namespace gmp.DomainModels.Entities
{
    public partial class Event
    {
        public Event()
        {
            Attendance = new HashSet<Attendance>();
            EventActivity = new HashSet<EventActivity>();
            Registration = new HashSet<EventRegistration>();
        }

        public int EventId { get; set; }
        public int EventTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int SchoolLocationId { get; set; }
        public DateTime EventStartDate { get; set; }
        public DateTime? EventEndDate { get; set; }

        public EventType EventType { get; set; }
        public ICollection<Attendance> Attendance { get; set; }
        public ICollection<EventActivity> EventActivity { get; set; }
        public ICollection<EventRegistration> Registration { get; set; }
    }
}
