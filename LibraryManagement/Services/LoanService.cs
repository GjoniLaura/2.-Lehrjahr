using LibraryManagement.Data;
using LibraryManagement.Interfaces;
using LibraryManagement.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryManagement.Services
{
    public class LoanService : ILoanService
    {
        private readonly IDbContextFactory<LibraryContext> _contextFactory;

        public LoanService(IDbContextFactory<LibraryContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<List<Loan>> GetLoansAsync()
        {
            using var context = _contextFactory.CreateDbContext();
            return await context.Loans.ToListAsync();
        }

        public async Task AddLoanAsync(Loan loan)
        {
            using var context = _contextFactory.CreateDbContext();
            context.Loans.Add(loan);
            await context.SaveChangesAsync();
        }

        public async Task RemoveLoanAsync(int loanId)
        {
            using var context = _contextFactory.CreateDbContext();
            var loan = await context.Loans.FindAsync(loanId);
            if (loan != null)
            {
                context.Loans.Remove(loan);
                await context.SaveChangesAsync();
            }
        }

        public async Task<List<Loan>> SearchLoansAsync(string searchText)
        {
            using var context = _contextFactory.CreateDbContext();
            return await context.Loans
                .Where(l => l.Status.Contains(searchText))
                .ToListAsync();
        }

        public async Task UpdateLoanAsync(Loan loan)
        {
            using var context = _contextFactory.CreateDbContext();
            context.Loans.Update(loan);
            await context.SaveChangesAsync();
        }
    }
}
