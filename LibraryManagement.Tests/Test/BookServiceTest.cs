using LibraryManagement.Data;
using LibraryManagement.Interfaces;
using LibraryManagement.Models;
using LibraryManagement.Services;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace LibraryManagement.Tests
{
    public class BookServiceTests
    {
        private readonly IBookService _bookService;
        private readonly DbContextOptions<LibraryContext> _dbContextOptions;

        public BookServiceTests()
        {
            _dbContextOptions = new DbContextOptionsBuilder<LibraryContext>()
                .UseInMemoryDatabase(databaseName: "LibraryTest")
                .Options;

            var contextFactory = new DbContextFactory<LibraryContext>(_dbContextOptions);
            _bookService = new BookService(contextFactory);
        }

        [Fact]
        public async Task AddBookAsync_Should_Add_Book()
        {
            var book = new Book { Title = "Test Book", Author = "Test Author", YearPublished = new DateTime(2000, 1, 1), Genre = "Test Genre", NumberOfPages = 100 };

            await _bookService.AddBookAsync(book);

            using (var context = new LibraryContext(_dbContextOptions))
            {
                var addedBook = await context.Books.FindAsync(book.BookId);
                Assert.NotNull(addedBook);
                Assert.Equal("Test Book", addedBook.Title);
            }
        }

    }
}
