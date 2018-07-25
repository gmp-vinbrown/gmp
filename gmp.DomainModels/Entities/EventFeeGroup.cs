using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace gmp.DomainModels.Entities
{
    [Table("EventFeeGroup")]
    public class EventFeeGroup
    {
        public int EventFeeGroupId { get; set; }
        public int EventId { get; set; }
        public decimal Fee { get; set; }

        [MaxLength(250)]
        public string Name { get; set; }

        [MaxLength(350)]
        public string Description { get; set; }
        public bool Deleted { get; set; }

        public virtual Event Event { get; set; }
    }
}
