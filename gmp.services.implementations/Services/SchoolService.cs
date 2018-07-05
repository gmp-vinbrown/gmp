using System.Threading.Tasks;
using gmp.DomainModels.Projections;
using gmp.services.contracts.Repositories;
using gmp.services.contracts.Services;

namespace gmp.services.implementations.Services
{
    public class SchoolService : ISchoolService
    {
        private readonly ISchoolRepository _schoolRepository;

        public SchoolService(ISchoolRepository schoolRepository)
        {
            _schoolRepository = schoolRepository;
        }

        public async Task<SchoolDTO> GetSchoolById(int id)
        {
            return await _schoolRepository.GetSchoolById(id);
        }

        public async Task<int> AddSchool(SchoolDTO school)
        {
            return await _schoolRepository.AddSchool(school);
        }

        public async Task<SchoolDTO> UpdateSchool(SchoolDTO school)
        {
            return await _schoolRepository.UpdateSchool(school);
        }

        public async Task<bool> DeleteSchool(int id)
        {
            return await _schoolRepository.DeleteSchool(id);
        }

        public async Task<SchoolLocationDTO> GetSchoolLocationById(int id)
        {
            return await _schoolRepository.GetSchoolLocationById(id);
        }

        public async Task<int> AddSchoolLocation(SchoolLocationDTO location)
        {
            return await _schoolRepository.AddSchoolLocation(location);
        }

        public async Task<SchoolLocationDTO> UpdateSchoolLocation(SchoolLocationDTO location)
        {
            return await _schoolRepository.UpdateSchoolLocation(location);
        }

        public async Task<bool> DeleteSchoolLocation(int id)
        {
            return await _schoolRepository.DeleteSchoolLocation(id);
        }
    }
}
