namespace gmp.DomainModels.Entities
{
    public partial class EventRegistration
    {
        public int EventRegistrationId { get; set; }
        public int EventActivityId { get; set; }
        public int MemberId { get; set; }
        public int? PaymentId { get; set; }
        public bool Deleted { get; set; }

        public Event Event { get; set; }
        public Member Member { get; set; }
        public Payment Payment { get; set; }
    }
}
