using LibraryService.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize(Roles = "AdminUser,Librarian")]
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
        public IActionResult Set(BookModel book)
        {
            if(!ModelState.IsValid) return StatusCode(StatusCodes.Status400BadRequest, new { msg = "Invalid Model data" });

            if (book.BookId <= 0)
            {
                var userClaim = User.HasClaim(claim => claim.Type == "UserId");
                if (userClaim) book.AddedBy = Convert.ToInt32(User.FindFirst("UserId")?.Value);
                book.CreatedDate = DateTime.UtcNow;

                dbContext.Books.Add(book);
                dbContext.SaveChanges();

                return Ok(book);
            }
            else return StatusCode(StatusCodes.Status304NotModified, new {msg = "Invalid Data Model."});
        }

        [HttpPut("{id}")]
        public IActionResult Set(BookModel book, int id)
        {
            if (!ModelState.IsValid) return StatusCode(StatusCodes.Status400BadRequest, new { msg = "Invalid Model data" });

            var bookData = dbContext.Books.Find(id);
            if(bookData == null) return StatusCode(StatusCodes.Status404NotFound, new { msg = "book details not found" });

            if (book.BookId > 0)
            {
                var userClaim = User.HasClaim(claim => claim.Type == "UserId");
                if (userClaim) book.AddedBy = Convert.ToInt32(User.FindFirst("UserId")?.Value);

                dbContext.Entry<BookModel>(book).State = EntityState.Modified;
                dbContext.SaveChanges();

                return Ok(book);
            }
            else return StatusCode(StatusCodes.Status304NotModified, new { msg = "Invalid Data Model." });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            BookModel? returnValue = dbContext.Books.Where(f => f.BookId == id).FirstOrDefault();
            if (returnValue == null) return StatusCode(StatusCodes.Status204NoContent, new { status=false, msg = "Data Not Found." });

            dbContext.Books.Remove(returnValue);
            dbContext.SaveChanges();

            return Ok(new { status = true, msg = "Deleted Successful."});
        }
    }
}
