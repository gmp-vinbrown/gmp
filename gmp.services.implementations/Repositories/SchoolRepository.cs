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
                                where s.SchoolId == id
                select s)
                .Include(item => item.Roles)
                .Include(item => item.Levels)
                .Include(item => item.Programs)
                .Include(item => item.SchoolLocations)
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
            if (school == null)
            {
                return false;
            }

            school.Deleted = true;
            return await _ctx.SaveChangesAsync() > 0;
        }

        public async Task<SchoolLocationDTO> GetSchoolLocationById(int id)
        {
            var location = await (from loc in _ctx.SchoolLocations
                                where loc.SchoolLocationId == id
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
                AutoMapper.Mapper.Map(locationSrc, entityDest);

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
            if (location == null)
            {
                return false;
            }

            location.Deleted = true;
            return await _ctx.SaveChangesAsync() > 0;
        }

        public async Task<int> AddRole(RoleDTO role)
        {
            if (role == null)
            {
                throw new ArgumentNullException($"Role cannot be null");
            }

            var newRole = AutoMapper.Mapper.Map<Role>(role);
            await _ctx.Roles.AddAsync(newRole);
            await _ctx.SaveChangesAsync();
            return newRole.RoleId;
        }

        public async Task<bool> DeleteRole(int id)
        {
            var role = await _ctx.Roles.FindAsync(id);
            if (role == null)
            {
                return false;
            }

            role.Deleted = true;
            return await _ctx.SaveChangesAsync() > 0;
        }

        public async Task<RoleDTO> UpdateRole(RoleDTO roleSrc)
        {
            var entityDest = await _ctx.Roles.FindAsync(roleSrc.RoleId);
            if (entityDest != null)
            {
                AutoMapper.Mapper.Map(roleSrc, entityDest);
            }
            else
            {
                return null;
            }
            await _ctx.SaveChangesAsync();

            return await Task.FromResult(roleSrc);
        }

        public async Task<LevelDTO> GetLevelById(int id)
        {
            var level = await(from lvl in _ctx.Levels
                              where lvl.LevelId == id
                              select lvl)
                .SingleOrDefaultAsync();

            var ret = Mapper.Map<LevelDTO>(level);
            return ret;
            
        }

        public async Task<int> AddLevel(LevelDTO level)
        {
            if (level == null)
            {
                throw new ArgumentNullException($"Level cannot be null");
            }

            var newLevel = AutoMapper.Mapper.Map<Level>(level);
            await _ctx.Levels.AddAsync(newLevel);
            await _ctx.SaveChangesAsync();
            return newLevel.LevelId;
        }

        public async Task<bool> DeleteLevel(int id)
        {
            var level = await _ctx.Levels.FindAsync(id);
            if (level == null)
            {
                return false;
            }

            level.Deleted = true;
            return await _ctx.SaveChangesAsync() > 0;
        }

        public async Task<LevelDTO> UpdateLevel(LevelDTO levelSrc)
        {
            var entityDest = await _ctx.Levels.FindAsync(levelSrc.LevelId);
            if (entityDest != null)
            {
                AutoMapper.Mapper.Map(levelSrc, entityDest);
            }
            else
            {
                return null;
            }
            await _ctx.SaveChangesAsync();

            return await Task.FromResult(levelSrc);
        }
    }
}
