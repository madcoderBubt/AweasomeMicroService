using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserServices.Models;

namespace UserServices.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize(Roles = "WaitingConfirmation")]
public class UserController : ControllerBase
{
    UserDbContext dbContext = null;
    public UserController(UserDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    [HttpGet]
    public List<UserModel> GetUsers(){
        List<UserModel> returnValue = dbContext.Users.ToList();

        return returnValue;
    }

    [HttpGet("{id}")]
    public UserModel GetUser(int id){

        UserModel? returnValue = dbContext.Users.Where(f => f.UserId == id).FirstOrDefault();

        return returnValue ?? new UserModel();
    }

    [HttpPost]
    public ActionResult SetUser(UserModel user)
    {
        if (!ModelState.IsValid)
            return StatusCode(StatusCodes.Status400BadRequest, new { msg = "Invalid Model data" });

        if(user.UserId <= 0)
        {
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

        if (user.UserId > 0)
        {
            
        }

        return Ok(user);
    }
    [HttpDelete("{id}")]
    public ActionResult DelUser(int id)
    {
        if (!ModelState.IsValid)
            return StatusCode(StatusCodes.Status400BadRequest, new { msg = "Invalid Model data" });

        

        return Ok();
    }
}