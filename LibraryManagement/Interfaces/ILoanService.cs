using System.Collections.Generic;
using System.Threading.Tasks;
using LibraryManagement.Models;

namespace LibraryManagement.Interfaces
{
    public interface ILoanService
    {
        Task<List<Loan>> GetLoansAsync();
        Task AddLoanAsync(Loan loan);
        Task RemoveLoanAsync(int loanId);
        Task<List<Loan>> SearchLoansAsync(string searchText);
        Task UpdateLoanAsync(Loan loan);
    }
}
