using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using gmp.DomainModels.Projections;

namespace gmp.services.contracts.Services
{
    public interface ISchoolService
    {
        Task<SchoolDTO> GetSchoolById(int id);
        Task<int> AddSchool(SchoolDTO school);
        Task<SchoolDTO> UpdateSchool(SchoolDTO school);
        Task<bool> DeleteSchool(int id);

        Task<SchoolLocationDTO> GetSchoolLocationById(int id);
        Task<int> AddSchoolLocation(SchoolLocationDTO location);
        Task<SchoolLocationDTO> UpdateSchoolLocation(SchoolLocationDTO location);
        Task<bool> DeleteSchoolLocation(int id);

        Task<int> AddRole(RoleDTO role);
        Task<bool> DeleteRole(int id);
        Task<RoleDTO> UpdateRole(RoleDTO role);
    }
}
