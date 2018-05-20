using System;
using System.Collections.Generic;

namespace gmp.DomainModels.Entities
{
    public partial class EventActivity
    {
        public EventActivity()
        {
            MemberEventActivity = new HashSet<MemberEventActivity>();            
        }

        public int EventActivityId { get; set; }
        public int EventId { get; set; }
        public int EventActivityTypeId { get; set; }

        public Event Event { get; set; }
        public EventActivityType EventActivityType { get; set; }
        public ICollection<MemberEventActivity> MemberEventActivity { get; set; }        
    }
}
