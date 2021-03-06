﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace gmp.DomainModels.Entities
{
    [Table("EventType")]
    public partial class EventType
    {
        public EventType()
        {
            Events = new HashSet<Event>();
        }

        public int EventTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Event> Events { get; set; }
    }
}
