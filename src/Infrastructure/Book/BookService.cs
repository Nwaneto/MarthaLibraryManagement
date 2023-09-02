using MarthaLibrary.Application.Catalog.Books;
using MarthaLibrary.Application.Common.Persistence;
using MarthaLibrary.Domain.Catalog;
using MarthaLibrary.Infrastructure.Persistence.Context;
using MarthaLibrary.Infrastructure.Persistence.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using MarthaLibrary.Infrastructure.Persistence;
using Microsoft.Extensions.Options;
using MarthaLibrary.Infrastructure.Persistence.ConnectionString;
using Microsoft.Extensions.Logging;
using System.Reflection;
using System.Net;

namespace MarthaLibrary.Infrastructure.Book;
internal class BookService : IBookService
{
    private readonly DatabaseSettings _dbSettings;
    private readonly ILogger<BookService> _logger;
    public BookService(IOptions<DatabaseSettings> dbSettings, ILogger<BookService> logger)
    {
        _dbSettings = dbSettings.Value;
        _logger = logger;
    }

    public bool BookExists(int bookId)
    {
        throw new NotImplementedException();
    }

    public bool BookExists(string bookIsbn)
    {
        throw new NotImplementedException();
    }

    public bool CreateBook(List<int> authorsId, List<int> categoriesId, BookModel book)
    {
        throw new NotImplementedException();
    }

    public bool DeleteBook(BookModel book)
    {
        throw new NotImplementedException();
    }

    public BookModel GetBook(int bookId)
    {
        throw new NotImplementedException();
    }

    public BookModel GetBook(string bookIsbn)
    {
        throw new NotImplementedException();
    }

    public decimal GetBookRating(int bookId)
    {
        throw new NotImplementedException();
    }

    public async Task <List<BookModel>> GetBooks()
    {
        try
        {
            var procedureName = "dbo.GetAllBooks";

            var result = new List<BookModel>();
            using (var connection = new SqlConnection(_dbSettings.ConnectionString))
            {
                result = connection.QueryAsync<BookModel>(procedureName, commandType: CommandType.StoredProcedure).Result.ToList();
                result.ToList();
                return await Task.FromResult(result.ToList());
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An Error Occured");
            return null;
        }
    }
    public async Task <List<BookModel>> GetAllAvailableBooks()
    {
        try
        {
            var procedureName = "dbo.GetAvailableBooks";

            var result = new List<BookModel>();
            using (var connection = new SqlConnection(_dbSettings.ConnectionString))
            {
                result = connection.QueryAsync<BookModel>(procedureName, commandType: CommandType.StoredProcedure).Result.ToList();
                result.ToList();                
            }
            return await Task.FromResult(result.ToList());
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An Error Occured while fetching all available books.");
            return null;
        }
    }
    public async Task<BookModel> GetBookById(int bookId)
    {
        try
        {
            var procedureName = "dbo.GetBook";
            var param = new DynamicParameters();
            param.Add("@BookID", bookId);
            var result = new BookModel();
            using (var connection = new SqlConnection(_dbSettings.ConnectionString))
            {
                result = connection.QueryFirstOrDefault<BookModel>(procedureName, param, commandType: CommandType.StoredProcedure);                
                
            }
            return await Task.FromResult(result);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"An Error Occured While retrieving the record for book with Id = {bookId}");
            return null;
        }
    }
    public async Task<string> BorrowBook(int bookId, int customerId)
    {
        try
        {
            string procedureName = "dbo.BorrowBook";
            var param = new DynamicParameters();
            param.Add("@BookID", bookId);
            param.Add("@CustomerID", customerId);
            string result = string.Empty;
            using (var connection = new SqlConnection(_dbSettings.ConnectionString))
            {
                result = connection.ExecuteScalarAsync<string>(procedureName, param, commandType: CommandType.StoredProcedure).Result;
                
            }
            return await Task.FromResult(result);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"An Error Occured While retrieving the record for book with Id = {bookId}");
            return "";
        }
    }

    public async Task<string> ReserveBook(int bookId, int customerId)
    {
        try
        {
            string procedureName = "dbo.ReserveBook";
            var param = new DynamicParameters();
            param.Add("@BookID", bookId);
            param.Add("@CustomerID", customerId);
            string result = string.Empty;
            using (var connection = new SqlConnection(_dbSettings.ConnectionString))
            {
                result = connection.ExecuteScalarAsync<string>(procedureName, param, commandType: CommandType.StoredProcedure).Result;
            }
            return await Task.FromResult(result);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"An Error Occured While retrieving the record for book with Id = {bookId}");
            return "";
        }
    }

    public async Task<BookModel> AddBookToLibrary(AddBookRequestModel book)
    {
        string procedureName = "dbo.CreateBook";
        try
        {
            _logger.LogInformation("About to add a book to library");

            BookModel result = new BookModel();
            var param = new DynamicParameters();
            param.Add("@Title", book.Title);
            param.Add("@Author", book.Author);
            param.Add("@PublicationYear", book.PublicationYear);
            param.Add("@ISBN", book.ISBN);
            param.Add("@Genre", book.Genre);
            param.Add("@BookDescription", book.BookDescription);
            param.Add("@CoverImageURL", book.CoverImageURL);

            using (var connection = new SqlConnection(_dbSettings.ConnectionString))
            {
                result = connection.QueryFirstOrDefault<BookModel>(procedureName, param, commandType: CommandType.StoredProcedure);

            }
            return await Task.FromResult(result);

            //using (SqlConnection sql = new SqlConnection(_dbSettings.ConnectionString))
            //{
            //    using (SqlCommand cmd = new SqlCommand(procedureName, sql))
            //    {
            //        cmd.CommandType = CommandType.StoredProcedure;                    
            //        BookModel result = new BookModel();
            //        var param = new DynamicParameters();
            //        param.Add("@Title", book.Title);
            //        param.Add("@Author", book.Author);
            //        param.Add("@PublicationYear", book.PublicationYear);
            //        param.Add("@ISBN", book.ISBN);
            //        param.Add("@Genre", book.Genre);
            //        param.Add("@BookDescription", book.BookDescription);
            //        param.Add("@CoverImageURL", book.CoverImageURL);
            //        await sql.OpenAsync();

            //        using (var reader = await cmd.ExecuteReaderAsync())
            //        {
            //            while (await reader.ReadAsync())
            //            {
            //                result.BookID = Convert.ToInt32(reader["Title"]);
            //                result.Title = reader["Title"].ToString();
            //                result.Author = reader["Author"].ToString();
            //                result.PublicationYear = Convert.ToInt32(reader["PublicationYear"]);
            //                result.ISBN = reader["ISBN"].ToString();
            //                result.Genre = reader["Genre"].ToString();
            //                result.BookDescription = reader["BookDescription"].ToString();
            //                result.IsReserved = Convert.ToBoolean(reader["IsReserved"]);
            //                result.DateReserved = Convert.ToDateTime(reader["DateReserved"]);
            //                result.DateReservationExpires = Convert.ToDateTime(reader["DateReservationExpires"]);
            //                result.IsBorrowed = Convert.ToBoolean(reader["IsBorrowed"]);
            //                result.DateBorrowed = Convert.ToDateTime(reader["DateBorrowed"]);
            //                result.BorrowDeadline = Convert.ToDateTime(reader["BorrowDeadline"]);
            //                result.IsReturned = Convert.ToBoolean(reader["IsReturned"]);
            //                result.CoverImageURL = reader["CoverImageURL"].ToString();

            //            }
            //        }
            //        return await Task.FromResult(result);
            //    }
            //}
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An Error Occured While adding a book to the library. See exception for details.");
            return null;
        }
    }
    public bool IsDuplicateIsbn(int bookId, string bookIsbn)
    {
        throw new NotImplementedException();
    }


    public bool Save()
    {
        throw new NotImplementedException();
    }

    public bool UpdateBook(List<int> authorsId, List<int> categoriesId, BookModel book)
    {
        throw new NotImplementedException();
    }

    async Task<List<BookModel>> IBookService.SearchBooksAsync(string searchTerm)
    {
        //return await _dapperRepo.Books
        //    .Where(book => book.Title.Contains(searchTerm) || book.Author.Contains(searchTerm))
        //    .ToListAsync();
        throw new NotImplementedException();
    }


    //public LibraryBook GetBook(int bookId)
    //{
    //    return _dbConnection.QuerySingleOrDefault<LibraryBook>("dbo.GetBook", new { BookID = bookId }, commandType: CommandType.StoredProcedure);
    //}

    //public IEnumerable<LibraryBook> GetAllBooks()
    //{
    //    return _dbConnection.Query<LibraryBook>("dbo.GetAllBooks", commandType: CommandType.StoredProcedure);
    //}
}


