using System.Collections.Generic;
using System.Threading.Tasks;
using gmp.DomainModels.Projections;

namespace gmp.services.contracts.Repositories {
    public interface IEventRepository {

        public Task<List<EventActivityMatchDTO>> GenerateMatches(int eventActivityId);
    }
}
