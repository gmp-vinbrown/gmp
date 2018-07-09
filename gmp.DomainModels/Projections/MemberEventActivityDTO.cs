using AutoMapper.Attributes;
using gmp.DomainModels.Entities;

namespace gmp.DomainModels.Projections
{
    [MapsFrom(typeof(MemberEventActivity))]
    public class MemberEventActivityDTO
    {
        public int MemberEventActivityId { get; set; }
        public int MemberId { get; set; }
        public int EventActivityId { get; set; }
        public string Result { get; set; }
        public string Notes { get; set; }
        public bool Deleted { get; set; }

        public virtual EventActivityDTO EventActivity { get; set; }
        public virtual MemberDTO Member { get; set; }
    }
}
