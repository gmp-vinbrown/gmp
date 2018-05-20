using System;
using System.Collections.Generic;

namespace gmp.DomainModels.Entities
{
    public partial class Registration
    {
        public int RegistrationId { get; set; }
        public int EventActivityId { get; set; }
        public int MemberId { get; set; }
        public int? PaymentId { get; set; }

        public EventActivity EventActivity { get; set; }
        public Member Member { get; set; }
        public Payment Payment { get; set; }
    }
}
