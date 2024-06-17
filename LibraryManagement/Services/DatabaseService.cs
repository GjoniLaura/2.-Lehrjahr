using LibraryManagement.Data;
using LibraryManagement.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryManagement.Services
{
    public class DatabaseService
    {
        private readonly LibraryContext _context;
        private readonly ILogger<DatabaseService> _logger;

        public DatabaseService(LibraryContext context, ILogger<DatabaseService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task InitializeDatabaseAsync()
        {
            try
            {
                if (await _context.Database.EnsureCreatedAsync())
                {
                    _logger.LogInformation("Database created successfully.");
                    await SeedDataAsync();
                }
                else
                {
                    _logger.LogInformation("Database already exists.");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while initializing the database.");
                throw;
            }
        }

        private async Task SeedDataAsync()
        {
            if (!await _context.Books.AnyAsync())
            {
                _context.Books.AddRange(
                    new Book { Title = "1984", Author = "George Orwell", YearPublished = new DateTime(1949, 6, 8), Genre = "Dystopian", NumberOfPages = 328 },
                    new Book { Title = "To Kill a Mockingbird", Author = "Harper Lee", YearPublished = new DateTime(1960, 7, 11), Genre = "Fiction", NumberOfPages = 281 }
                    // Add more books as needed
                );
                await _context.SaveChangesAsync();
            }

            if (!await _context.Members.AnyAsync())
            {
                _context.Members.AddRange(
                    new Members
                    {
                        FirstName = "John",
                        LastName = "Doe",
                        Age = 30,
                        Registration = new DateTime(2023, 1, 1),
                        Email = "john.doe@example.com",
                        PhoneNumber = "123-456-7890",
                        MembershipStatus = "Active",
                        BorrowedBooks = new List<int> { 101, 102 },
                        MembershipFee = 50.0m,
                        DueDates = new List<DateTime> { new DateTime(2023, 5, 1), new DateTime(2023, 5, 15) }
                    },
                    new Members
                    {
                        FirstName = "Jane",
                        LastName = "Smith",
                        Age = 25,
                        Registration = new DateTime(2023, 2, 1),
                        Email = "jane.smith@example.com",
                        PhoneNumber = "987-654-3210",
                        MembershipStatus = "Active",
                        BorrowedBooks = new List<int> { 103 },
                        MembershipFee = 60.0m,
                        DueDates = new List<DateTime> { new DateTime(2023, 5, 10) }
                    }
                    // Add more members as needed
                );
                await _context.SaveChangesAsync();
            }

            if (!await _context.Loans.AnyAsync())
            {
                _context.Loans.AddRange(
                    new Loan
                    {
                        StartDate = new DateTime(2023, 1, 1),
                        DueDate = new DateTime(2023, 1, 15),
                        ReturnDate = null,
                        RenewalCount = 0,
                        Status = "Active",
                        Fine = 0,
                        MemberId = 1
                    },
                    new Loan
                    {
                        StartDate = new DateTime(2023, 2, 1),
                        DueDate = new DateTime(2023, 2, 15),
                        ReturnDate = new DateTime(2023, 2, 10),
                        RenewalCount = 1,
                        Status = "Returned",
                        Fine = 5,
                        MemberId = 2
                    }
                    // Add more loans as needed
                );
                await _context.SaveChangesAsync();
            }
        }
    }
}
