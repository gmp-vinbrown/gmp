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

        public virtual Event Event { get; set; }
        public virtual EventActivityType EventActivityType { get; set; }
        public virtual ICollection<MemberEventActivity> MemberEventActivity { get; set; }        
    }
}
