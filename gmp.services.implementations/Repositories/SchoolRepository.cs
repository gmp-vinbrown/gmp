using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using gmp.Core.Services;
using gmp.DomainModels.Entities;
using gmp.DomainModels.Projections;
using gmp.services.contracts.Repositories;
using Microsoft.EntityFrameworkCore;

namespace gmp.services.implementations.Repositories
{
    public class SchoolRepository : BaseRepository, ISchoolRepository
    {
        public SchoolRepository(IUserInfoService<int> userInfoService) : base(userInfoService)
        {

        }

        public async Task<SchoolDTO> GetSchoolById(int id)
        {
            var school = await (from s in _ctx.Schools
                                where s.SchoolId == id && !s.Deleted
                select s)
                .SingleOrDefaultAsync();

            var ret = Mapper.Map<SchoolDTO>(school);
            return ret;
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
            else
            {
                return null;
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
            var location = await (from loc in _ctx.SchoolLocations
                                where loc.SchoolLocationId == id && !loc.Deleted
                                select loc)
                .SingleOrDefaultAsync();

            var ret = Mapper.Map<SchoolLocationDTO>(location);
            return ret;
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
                entityDest.Name = locationSrc.Name;
                entityDest.IsPrimary = locationSrc.IsPrimary;
                entityDest.Address1 = locationSrc.Address1;
                entityDest.Address2 = locationSrc.Address2;
                entityDest.City = locationSrc.City;
                entityDest.StateCode = locationSrc.StateCode;
                entityDest.Zip = locationSrc.Zip;

                await _ctx.SaveChangesAsync();
            }
            else
            {
                return null;
            }
             
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
