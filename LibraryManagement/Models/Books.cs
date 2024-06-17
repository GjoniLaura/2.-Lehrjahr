using System;

namespace LibraryManagement.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime YearPublished { get; set; }
        public string Genre { get; set; }
        public int NumberOfPages { get; set; }
    }
}
