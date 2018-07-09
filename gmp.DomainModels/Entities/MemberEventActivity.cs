using System.ComponentModel.DataAnnotations.Schema;

namespace gmp.DomainModels.Entities
{
    [Table("MemberEventActivity")]
    public partial class MemberEventActivity
    {
        public int MemberEventActivityId { get; set; }
        public int MemberId { get; set; }
        public int EventActivityId { get; set; }
        public string Result { get; set; }
        public string Notes { get; set; }
        public bool Deleted { get; set; }

        public virtual EventActivity EventActivity { get; set; }
        public virtual Member Member { get; set; }
    }
}
