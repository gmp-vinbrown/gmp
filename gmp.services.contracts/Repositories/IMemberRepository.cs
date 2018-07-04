using System.Collections.Generic;
using System.Threading.Tasks;
using gmp.DomainModels.Projections;

namespace gmp.services.contracts.Repositories
{
    public interface IMemberRepository
    {
        Task<MemberDTO> GetMemberById(int id);
        Task<int> AddMember(MemberDTO member);
        Task<bool> DeleteMember(int id);
        Task<MemberDTO> UpdateMember(MemberDTO member);
        Task<IEnumerable<MemberDTO>> GetMembersBySchool(int schoolId);
        Task<IEnumerable<MemberDTO>> GetMembersBySchoolLocation(int schoolLocationId);
    }
}
