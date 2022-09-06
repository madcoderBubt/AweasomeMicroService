using LibraryService.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize("Librarian,AdminUser")]
    public class LibraryController : ControllerBase
    {
        LibraryDbContext dbContext = null;
        public LibraryController(LibraryDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet("{readerId}/borrow/{bookId}")]
        public List<BookModel> BorrowBook(int readerId, int bookId)
        {
            throw new NotImplementedException();
        }

        [HttpGet("{readerId}/return/{bookId}")]
        public List<BookModel> ReturnBook(int readerId, int bookId)
        {
            throw new NotImplementedException();
        }

        [HttpGet("{readerId}/books")]
        public List<BookModel> BorrowedBooks(int readerId)
        {
            throw new NotImplementedException();
        }
    }
}
