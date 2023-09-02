using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarthaLibrary.Application.Catalog.Books;
public interface IBookService : ITransientService
{
    Task<List<BookModel>> SearchBooksAsync(string searchTerm);
    Task <List<BookModel>> GetBooks();
    Task<List<BookModel>> GetAllAvailableBooks();
    Task <BookModel> GetBookById(int bookId);
    Task <string> BorrowBook(int bookId, int customerId);
    Task<string> ReserveBook(int bookId, int customerId);
    
    BookModel GetBook(int bookId);
    BookModel GetBook(string bookIsbn);
    decimal GetBookRating(int bookId);
    bool BookExists(int bookId);
    bool BookExists(string bookIsbn);
    bool IsDuplicateIsbn(int bookId, string bookIsbn);

    bool CreateBook(List<int> authorsId, List<int> categoriesId, BookModel book);
    bool UpdateBook(List<int> authorsId, List<int> categoriesId, BookModel book);
    bool DeleteBook(BookModel book);
    bool Save();
}
