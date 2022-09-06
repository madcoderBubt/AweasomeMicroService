using System.ComponentModel.DataAnnotations;

namespace LibraryService.Models
{
    public class BookModel
    {
        [Key]
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public BookTypeEnum BookType { get; set; }
        public BookStatusEnum BookStatus { get; set; }
        public DateTime CreatedDate { get; set; }
        public int AddedBy { get; set; }
    }
}
