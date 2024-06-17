using LibraryManagement.Data;
using LibraryManagement.Interfaces;
using LibraryManagement.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryManagement.Services
{
    public class MemberService : IMemberService
    {
        private readonly IDbContextFactory<LibraryContext> _contextFactory;

        public MemberService(IDbContextFactory<LibraryContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<List<Members>> GetMembersAsync()
        {
            using var context = _contextFactory.CreateDbContext();
            return await context.Members.ToListAsync();
        }

        public async Task AddMemberAsync(Members member)
        {
            using var context = _contextFactory.CreateDbContext();
            context.Members.Add(member);
            await context.SaveChangesAsync();
        }

        public async Task DeleteMemberAsync(int memberId)
        {
            using var context = _contextFactory.CreateDbContext();
            var member = await context.Members.FindAsync(memberId);
            if (member != null)
            {
                context.Members.Remove(member);
                await context.SaveChangesAsync();
            }
        }

        public async Task<List<Members>> SearchMembersAsync(string searchText)
        {
            using var context = _contextFactory.CreateDbContext();
            return await context.Members
                .Where(m => m.FirstName.Contains(searchText) || m.LastName.Contains(searchText) || m.Email.Contains(searchText))
                .ToListAsync();
        }

        public async Task UpdateMemberAsync(Members member)
        {
            using var context = _contextFactory.CreateDbContext();
            context.Members.Update(member);
            await context.SaveChangesAsync();
        }
    }
}
