using System;
using System.Threading.Tasks;
using gmp.Core.Services;
using gmp.DomainModels.Entities;
using gmp.DomainModels.Projections;
using gmp.services.contracts.Repositories;

namespace gmp.services.implementations.Repositories
{
    public class SchoolRepository : BaseRepository, ISchoolRepository
    {
        public SchoolRepository(IUserInfoService<int> userInfoService) : base(userInfoService)
        {

        }

        public async Task<SchoolDTO> GetSchoolById(int id)
        {
            var school = await _ctx.FindAsync<School>(id);
            return (school != null && school.Deleted) ? null : AutoMapper.Mapper.Map<SchoolDTO>(school);
        }

        public async Task<int> AddSchool(SchoolDTO school)
        {
            if (school == null)
            {
                throw new ArgumentNullException($"School cannot be null");
            }

            var newSchool = AutoMapper.Mapper.Map<School>(school);
            await _ctx.Schools.AddAsync(newSchool);
            await _ctx.SaveChangesAsync();
            return newSchool.SchoolId;
        }

        public async Task<SchoolDTO> UpdateSchool(SchoolDTO schoolSrc)
        {
            var entityDest = await _ctx.Schools.FindAsync(schoolSrc.SchoolId);
            if (entityDest != null)
            {
                AutoMapper.Mapper.Map(schoolSrc, entityDest);
            }
            await _ctx.SaveChangesAsync();

            return await Task.FromResult(schoolSrc);
        }

        public async Task<bool> DeleteSchool(int id)
        {
            var school = await _ctx.Schools.FindAsync(id);
            school.Deleted = true;
            return await _ctx.SaveChangesAsync() > 0;
        }

        public async Task<SchoolLocationDTO> GetSchoolLocationById(int id)
        {
            var location = await _ctx.FindAsync<SchoolLocation>(id);
            return location.Deleted ? null : AutoMapper.Mapper.Map<SchoolLocationDTO>(location);
        }

        public async Task<int> AddSchoolLocation(SchoolLocationDTO location)
        {
            if (location == null)
            {
                throw new ArgumentNullException($"School cannot be null");
            }

            var newSchoolLocation = AutoMapper.Mapper.Map<SchoolLocation>(location);
            await _ctx.SchoolLocations.AddAsync(newSchoolLocation);
            await _ctx.SaveChangesAsync();
            return newSchoolLocation.SchoolId;
        }

        public async Task<SchoolLocationDTO> UpdateSchoolLocation(SchoolLocationDTO locationSrc)
        {
            var entityDest = await _ctx.SchoolLocations.FindAsync(locationSrc.SchoolLocationId);
            if (entityDest != null)
            {
                AutoMapper.Mapper.Map(locationSrc, entityDest);
            }
            await _ctx.SaveChangesAsync();

            return await Task.FromResult(locationSrc);
        }

        public async Task<bool> DeleteSchoolLocation(int id)
        {
            var location = await _ctx.SchoolLocations.FindAsync(id);
            location.Deleted = true;
            return await _ctx.SaveChangesAsync() > 0;
        }
    }
}
