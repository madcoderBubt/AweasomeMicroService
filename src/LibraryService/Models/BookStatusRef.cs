using Infrastructure.Extensions;
using System.ComponentModel;

namespace LibraryService.Models
{
    public class BookStatusRef
    {
        public BookStatusEnum StatusId { get; set; }
        public string StatusName { get; set; }

        public BookStatusRef(BookStatusEnum status)
        {
            StatusId = status;
            StatusName = status.GetDescription();
        }
    }
    public enum BookStatusEnum
    {
        [Description("Available")]
        Available,
        [Description("Not Available")]
        NotAvailable
    }
}
