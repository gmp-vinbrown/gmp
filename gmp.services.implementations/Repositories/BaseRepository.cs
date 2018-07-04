using gmp.DomainModels.Entities;
using Microsoft.EntityFrameworkCore;

namespace gmp.services.implementations.Repositories
{
    public class BaseRepository
    {
        protected readonly gmpContext _ctx;

        public BaseRepository()
        {
            _ctx = new gmpContext(new DbContextOptions<gmpContext>());
        }
    }
}
