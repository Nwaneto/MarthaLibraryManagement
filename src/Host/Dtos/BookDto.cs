using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarthaLibrary.Host.Dtos
{
    public class BookDto
    {
        public int BookID { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public int PublicationYear { get; set; }
        public string ISBN { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;
        public string BookDescription { get; set; } = string.Empty;
        public bool IsReserved { get; set; }
        public DateTime? DateReserved { get; set; }
        public DateTime? DateReservationExpires { get; set; }
        public bool IsBorrowed { get; set; }
        public DateTime? DateBorrowed { get; set; }
        public DateTime? BorrowDeadline { get; set; }
        public bool IsReturned { get; set; }
        public string CoverImageURL { get; set; } = string.Empty;
    }
}
