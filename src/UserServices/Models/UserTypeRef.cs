using System.ComponentModel;
using Infrastructure.Extensions;
namespace UserServices.Models;

public class UserTypeRef
{
    public UserTypeEnum StatusId { get; set; }
    public string StatusName { get; set; }

    public UserTypeRef(UserTypeEnum status)
    {
        this.StatusId = status;
        this.StatusName = status.GetDescription();
    }
}
public enum UserTypeEnum
{
    [Description("Admin User")]
    AdminUser = 0,

    [Description("Faculty")]
    FacultyUser = 1,

    [Description("Student")]
    StudentUser = 2,

    [Description("Librarian")]
    Librarian = 3
}