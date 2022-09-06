using System.ComponentModel.DataAnnotations;

namespace LibraryService.Models
{
    public class BookRentModel
    {
        [Key]
        public int Id { get; set; }
        public int BookId { get; set; }
        public int ReaderId { get; set; } //possiboly Student UserId or could be faculty UserId
        public int GivenBy { get; set; } //librarian UserId
        public DateTime GivenDate { get; set; }
        public bool IsReturned { get; set; }
        public DateTime ReturnDate { get; set; }
        public int ReturnedBy { get; set; }
    }
}
