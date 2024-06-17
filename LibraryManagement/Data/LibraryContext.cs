using LibraryManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Data
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<Members> Members { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Members>()
                .HasKey(m => m.MemberId); // Sicherstellen, dass MemberId der Primärschlüssel ist

            modelBuilder.Entity<Book>()
                .HasKey(b => b.BookId); // Sicherstellen, dass BookId der Primärschlüssel ist

            modelBuilder.Entity<Loan>()
                .HasKey(l => l.LoanId); // Sicherstellen, dass LoanId der Primärschlüssel ist

            // Configure JSON columns
            modelBuilder.Entity<Members>()
                .Property(m => m.BorrowedBooksJson)
                .HasColumnName("BorrowedBooks");

            modelBuilder.Entity<Members>()
                .Property(m => m.DueDatesJson)
                .HasColumnName("DueDates");

            base.OnModelCreating(modelBuilder);
        }
    }
}
