using MarthaLibrary.Host.Models;
using MarthaLibrary.Host.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarthaLibrary.Application.Catalog.Books;
using System.Net;
using MarthaLibrary.Domain.Catalog;

namespace MarthaLibrary.Host.Controllers.Library
{
    [Route("api/v{version:apiVersion}/LibraryBooks")]
    [ApiController]
    public class BooksController : Controller
    {
        private IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        /// <summary>
        /// Endpoint used to get all books from Library - wether borrowed, reserved or available books
        /// </summary>
        /// <returns>A list of Books</returns>
        [HttpGet("GetAllBooks")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<BookModel>))]
        [ProducesResponseType(400)]
        public IActionResult GetBooks()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var books = _bookService.GetBooks().Result;
            var booksDto = new List<BookDto>();

            foreach (var book in books)
            {
                booksDto.Add(new BookDto
                {
                    BookID = book.BookID,
                    Author = book.Author,
                    BookDescription = book.BookDescription,
                    BorrowDeadline = book.BorrowDeadline,
                    CoverImageURL = book.CoverImageURL,
                    DateBorrowed = book.DateBorrowed,
                    DateReservationExpires = book.DateReservationExpires,
                    DateReserved = book.DateReserved,
                    Genre = book.Genre,
                    ISBN = book.ISBN,
                    IsBorrowed = book.IsBorrowed,
                    IsReserved = book.IsReserved,
                    IsReturned = book.IsReturned,
                    PublicationYear = book.PublicationYear,
                    Title = book.Title
                });
            }

            return Ok(booksDto);
        }

        /// <summary>
        /// Endpoint used to get all available (borrowable) books from Library
        /// </summary>
        /// <returns>A list of available books from the library</returns>
        [HttpGet("GetAvailableBooks")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<BookModel>))]
        [ProducesResponseType(400)]
        public IActionResult GetAllAvailableBooks()
        {            
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var books = _bookService.GetAllAvailableBooks().Result;
            var booksDto = new List<BookDto>();
            foreach (var book in books)
            {
                booksDto.Add(new BookDto
                {
                    BookID = book.BookID,
                    Author = book.Author,
                    BookDescription = book.BookDescription,
                    BorrowDeadline = book.BorrowDeadline,
                    CoverImageURL = book.CoverImageURL,
                    DateBorrowed = book.DateBorrowed,
                    DateReservationExpires = book.DateReservationExpires,
                    DateReserved = book.DateReserved,
                    Genre = book.Genre,
                    ISBN = book.ISBN,
                    IsBorrowed = book.IsBorrowed,
                    IsReserved = book.IsReserved,
                    IsReturned = book.IsReturned,
                    PublicationYear = book.PublicationYear,
                    Title = book.Title
                });
            }

            return Ok(booksDto);
        }


        /// <summary>
        /// Endpoint used to get a books using BookID
        /// </summary>
        /// <param name="bookId"></param>
        /// <returns>A book object</returns>
        [HttpGet("GetSingleBook")]
        [ProducesResponseType(200, Type = typeof(BookModel))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult GetABooks(int bookId)
        {            
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var books = _bookService.GetBookById(bookId).Result;
            if (books.Equals(null))
            {
                return NotFound();
            } 
            return Ok(books);
        }

        /// <summary>
        /// Use this endpoint to borrow a book from the library
        /// </summary>
        /// <param name="bookId">Id of book to be borrowed</param>
        /// <param name="customerId">Id of customer who is borrowing</param>
        /// <returns></returns>
        [HttpPost("Borrow")]
        [ProducesResponseType(200, Type = typeof(BookModel))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult BorrowBook(int bookId, int customerId)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            string result = _bookService.BorrowBook(bookId, customerId).Result;
            return Ok(result);
        }

        /// <summary>
        /// Endpoint used to reserve a book
        /// </summary>
        /// <param name="bookId">Id of book to be reserved</param>
        /// <param name="customerId">Id of customer who is reserving</param>
        /// <returns></returns>
        [HttpPost("ReserveBook")]
        [ProducesResponseType(200, Type = typeof(BookModel))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult ReserveBook(int bookId, int customerId)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            string result = _bookService.ReserveBook(bookId, customerId).Result;
            return Ok(result);
        }

        
    }
}
