using AutoMapper.Attributes;
using gmp.DomainModels.Entities;

namespace gmp.DomainModels.Projections {

    [MapsFrom(typeof(EventActivityMatch))]
    public class EventActivityMatchDTO {

		public int EventActivityMatchId { get; set; }
		public int EventActivityId { get; set; }
		public int MemberId { get; set; }
		public int MatchingId { get; set; }
		public int Round { get; set; }
		public bool Winner { get; set; }
		public bool Deleted { get; set; }

		public virtual EventActivity EventActivity { get; set; }

		public virtual Member Member { get; set; }
	}
}
