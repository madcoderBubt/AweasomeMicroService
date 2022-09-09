using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserServices.Models;

namespace UserServices.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
public class UserController : ControllerBase
{
    UserDbContext dbContext = null;
    public UserController(UserDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    [HttpGet]
    [Authorize(Roles = "AdminUser")]
    public List<UserModel> GetUsers(){
        List<UserModel> returnValue = dbContext.Users.ToList();

        return returnValue;
    }

    [HttpGet("{id}")]
    public UserModel? GetUser(int id)
    {
        UserModel? returnValue = dbContext.Users.Where(f => f.UserId == id).FirstOrDefault();

        if (User.IsInRole("AdminUser") || User.Identity.Name == returnValue.UserName)
        {
            return returnValue ?? new UserModel();
        }
        else
        {
            return null;
        }
    }

    [HttpPost]
    [AllowAnonymous]
    public ActionResult SetUser(UserModel user)
    {
        if (!ModelState.IsValid)
            return StatusCode(StatusCodes.Status400BadRequest, new { msg = "Invalid Model data" });

        if(user.UserId <= 0)
        {
            if(User.Identity == null) user.UserStatus = 0;
            dbContext.Add(user);
            dbContext.SaveChanges();
        }

        return Ok(user);
    }

    [HttpPut("{id}")]
    public ActionResult SetUser(UserModel user, int id)
    {
        if (!ModelState.IsValid)
            return StatusCode(StatusCodes.Status400BadRequest, new { msg = "Invalid Model data" });

        UserModel? returnValue = dbContext.Users.Where(f => f.UserId == id).FirstOrDefault();
        if (returnValue == null) return StatusCode(StatusCodes.Status404NotFound, new { msg = "user info not found" });

        if (User.IsInRole("AdminUser") || User.Identity.Name == returnValue.UserName)
        {
            if (id > 0 && returnValue != null)
            {
                dbContext.Entry<UserModel>(user).State = EntityState.Modified;
                dbContext.SaveChanges();
            }
            return Ok(user);
        }

        return StatusCode(StatusCodes.Status401Unauthorized, new { msg = "You don't have permission to perform this operation."});
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "AdminUser")]
    public ActionResult DelUser(int id)
    {
        UserModel? returnValue = dbContext.Users.Where(f => f.UserId == id).FirstOrDefault();
        if (returnValue == null) return StatusCode(StatusCodes.Status204NoContent, new { msg = "Data Not Found." });

        dbContext.Users.Remove(returnValue);
        dbContext.SaveChanges();

        return Ok();
    }
}