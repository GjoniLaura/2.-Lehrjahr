using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace LibraryManagement.Models
{
    public class Members
    {
        public int MemberId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public DateTime Registration { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string MembershipStatus { get; set; }

        [NotMapped]
        public List<int> BorrowedBooks { get; set; } = new List<int>();

        [NotMapped]
        public List<DateTime> DueDates { get; set; } = new List<DateTime>();

        public string BorrowedBooksJson
        {
            get => JsonConvert.SerializeObject(BorrowedBooks);
            set => BorrowedBooks = JsonConvert.DeserializeObject<List<int>>(value);
        }

        public string DueDatesJson
        {
            get => JsonConvert.SerializeObject(DueDates);
            set => DueDates = JsonConvert.DeserializeObject<List<DateTime>>(value);
        }

        public decimal MembershipFee { get; set; }
    }
}
