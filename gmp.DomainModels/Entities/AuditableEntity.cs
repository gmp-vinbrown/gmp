using System;
using System.Collections.Generic;
using System.Text;

namespace gmp.DomainModels.Entities
{
    public abstract class AuditableEntity
    {
        public DateTime Created { get; set; }
        public int CreatedId { get; set; }
        public DateTime? Updated { get; set; }
        public int? UpdatedId { get; set; }
    }
}
