using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace LibraryManagement.Data
{
    public class DbContextSingleton
    {
        private static LibraryContext _instance;
        private static readonly object _lock = new object();

        private DbContextSingleton() { }

        public static LibraryContext GetInstance(IServiceProvider serviceProvider)
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        var options = serviceProvider.GetRequiredService<DbContextOptions<LibraryContext>>();
                        _instance = new LibraryContext(options);
                    }
                }
            }
            return _instance;
        }
    }
}
