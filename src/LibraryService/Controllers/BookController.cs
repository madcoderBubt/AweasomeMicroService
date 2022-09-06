using LibraryService.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize("Librarian,AdminUser")]
    public class BookController : ControllerBase
    {
        LibraryDbContext dbContext = null;
        public BookController(LibraryDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public List<BookModel> Get()
        {
            List<BookModel> returnValue = dbContext.Books.ToList();

            return returnValue;
        }

        [HttpGet("{id}")]
        public BookModel? Get(int id)
        {
            BookModel? returnValue = dbContext.Books.Find(id);

            return returnValue;
        }

        [HttpPost]
        public BookModel? Set(BookModel book)
        {
            throw new NotImplementedException();
        }

        [HttpPut("{id}")]
        public BookModel? Set(BookModel book, int id)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{id}")]
        public bool GetUsers(int id)
        {
            throw new NotImplementedException();
        }
    }
}
