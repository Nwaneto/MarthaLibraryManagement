using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarthaLibrary.Domain.Catalog;

public class BookModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int BookID { get; set; }
    [Required]
    public string Title { get; set; } = string.Empty;
    [Required]
    public string Author { get; set; } = string.Empty;
    [Required]
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

public class AddBookRequestModel
{
    public string Title { get; set; } = string.Empty;
    [Required]
    public string Author { get; set; } = string.Empty;
    [Required]
    public int PublicationYear { get; set; }
    public string ISBN { get; set; } = string.Empty;
    public string Genre { get; set; } = string.Empty;
    public string BookDescription { get; set; } = string.Empty;    
    public string CoverImageURL { get; set; } = string.Empty;
}