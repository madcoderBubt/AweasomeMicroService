using System.ComponentModel.DataAnnotations;

namespace UserServices.Models;
public class UserModel
{
    // public Guid UserId { get; set; } = Guid.NewGuid();
    [Key]
    public int UserId { get; set; }
    public string UserName { get; set; }
    public string PassCode { get; set; }
    public DateTime JoinDate { get; set; }
    public UserStatusEnum UserStatus { get; set; }
    public UserTypeEnum UserType {get;set;}
}
