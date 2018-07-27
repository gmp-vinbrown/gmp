using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace gmp.DomainModels.Entities
{
    [Table("EventActivity")]
    public partial class EventActivity
    {
        public EventActivity()
        {
            MemberEventActivities = new HashSet<MemberEventActivity>();            
        }

        public int EventActivityId { get; set; }
        public int EventId { get; set; }
        public int EventActivityTypeId { get; set; }
        public bool Deleted { get; set; }

        public virtual Event Event { get; set; }
        public virtual EventActivityType EventActivityType { get; set; }
        public virtual ICollection<MemberEventActivity> MemberEventActivities { get; set; }        
    }
}
