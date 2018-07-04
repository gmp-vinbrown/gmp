namespace gmp.DomainModels.Entities
{
    public partial class MemberEventActivity
    {
        public int MemberEventActivityId { get; set; }
        public int MemberId { get; set; }
        public int EventActivityId { get; set; }
        public string Result { get; set; }
        public string Notes { get; set; }
        public bool Deleted { get; set; }

        public EventActivity EventActivity { get; set; }
        public Member Member { get; set; }
    }
}
