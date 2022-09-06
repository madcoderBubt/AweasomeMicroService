using Microsoft.EntityFrameworkCore;

namespace LibraryService.Models
{
    public class LibraryDbContext: DbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options)
        { }

        //Db Data Models
        public DbSet<BookModel> Books { get; set; }
        public DbSet<BookRentModel> BookRents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
