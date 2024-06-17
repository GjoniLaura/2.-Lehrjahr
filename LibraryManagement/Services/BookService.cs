using LibraryManagement.Data;
using LibraryManagement.Interfaces;
using LibraryManagement.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryManagement.Services
{
    public class BookService : IBookService
    {
        private readonly IDbContextFactory<LibraryContext> _contextFactory;

        public BookService(IDbContextFactory<LibraryContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<List<Book>> GetBooksAsync()
        {
            using var context = _contextFactory.CreateDbContext();
            return await context.Books.ToListAsync();
        }

        public async Task<Book> GetBookAsync(int id)
        {
            using var context = _contextFactory.CreateDbContext();
            return await context.Books.FindAsync(id);
        }

        public async Task AddBookAsync(Book book)
        {
            using var context = _contextFactory.CreateDbContext();
            context.Books.Add(book);
            await context.SaveChangesAsync();
        }

        public async Task UpdateBookAsync(Book book)
        {
            using var context = _contextFactory.CreateDbContext();
            context.Books.Update(book);
            await context.SaveChangesAsync();
        }

        public async Task DeleteBookAsync(int id)
        {
            using var context = _contextFactory.CreateDbContext();
            var book = await context.Books.FindAsync(id);
            if (book != null)
            {
                context.Books.Remove(book);
                await context.SaveChangesAsync();
            }
        }

        public async Task<List<Book>> SearchBooksAsync(string searchText)
        {
            using var context = _contextFactory.CreateDbContext();
            return await context.Books
                .Where(b => b.Title.Contains(searchText) || b.Author.Contains(searchText))
                .ToListAsync();
        }
    }
}
