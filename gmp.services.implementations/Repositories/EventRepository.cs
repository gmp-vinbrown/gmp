using gmp.Core.Services;
using gmp.DomainModels;
using gmp.DomainModels.Projections;
using gmp.services.contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gmp.services.implementations.Repositories
{
    public class EventRepository : BaseRepository, IEventRepository
    {
        public EventRepository(IUserInfoService<int> userInfoService) : base(userInfoService)
        {
        }

        public Task<int> AddPersonToEventActivity(int personId, int eventActivityId)
        {
            int assignedEventActivity = -1;

            return Task.FromResult(assignedEventActivity);
        }

        public async Task<List<EventActivityMatchDTO>> GenerateMatches(int eventActivityId)
        {
            var matches = new List<EventActivityMatchDTO>();
            var eventActivity = await _ctx.EventActivities.FindAsync(eventActivityId);

            foreach(var mea in eventActivity.MemberEventActivities)
            {

            }

            return matches;
        }
    }
}
