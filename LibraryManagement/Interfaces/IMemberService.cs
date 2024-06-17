using System.Collections.Generic;
using System.Threading.Tasks;
using LibraryManagement.Models;

namespace LibraryManagement.Interfaces
{
    public interface IMemberService
    {
        Task<List<Members>> GetMembersAsync();
        Task AddMemberAsync(Members member);
        Task DeleteMemberAsync(int memberId);
        Task<List<Members>> SearchMembersAsync(string searchText);
        Task UpdateMemberAsync(Members member);
    }
}
