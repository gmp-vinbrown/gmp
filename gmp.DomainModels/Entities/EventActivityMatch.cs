using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gmp.DomainModels.Entities {

	[Table("EventActivityMatch")]
	public class EventActivityMatch {

		[Key]
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
