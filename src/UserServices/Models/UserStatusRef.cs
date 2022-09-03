using System.ComponentModel;
using UserServices.Extensions;
namespace UserServices.Models;

public class UserStatusRef
{
    public UserStatusEnum StatusId { get; set; }
    public string StatusName { get; set; }

    public UserStatusRef(UserStatusEnum status)
    {
        this.StatusId = status;
        this.StatusName = status.GetDescription();
    }
}
public enum UserStatusEnum
{
    [Description("Waiting for confirmation")]
    WaitingConfirmation = 0,

    [Description("Active")]
    Active = 1,

    [Description("Deactive")]
    Deactive = 2
}