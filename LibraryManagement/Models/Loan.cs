using System;

namespace LibraryManagement.Models
{
    public class Loan
    {
        public int LoanId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public int RenewalCount { get; set; }
        public string Status { get; set; }
        public decimal? Fine { get; set; }
        public int MemberId { get; set; }
    }
}
