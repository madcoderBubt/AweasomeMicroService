using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UserServices.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UserServices.Controllers;

[Route("[controller]")]
[ApiController]
public class UserAuthController : ControllerBase
{
    UserDbContext dbContext = null;
    IConfiguration configuration = null;
    public UserAuthController(UserDbContext dbContext, IConfiguration configuration)
    {
        this.dbContext = dbContext;
        this.configuration = configuration;
    }

    // POST api/<UserAuthController>
    [HttpPost]
    [Route("log")]
    public IActionResult Post([FromBody] LoginModel log)
    {
        if (log == null) return StatusCode(StatusCodes.Status204NoContent, new { Status = "Error", Message = "Null Reference!" });
        //if (!ModelState.IsValid) return Content();

        var user = dbContext.Users.Where(f => f.UserName == log.UserName && f.PassCode == log.PassCode).FirstOrDefault();

        if (user != null && user.UserStatus == UserStatusEnum.Active)
        {
            var roles = new UserTypeRef(user.UserType);

            var authClaims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            authClaims.Add(new Claim(ClaimTypes.Role, user.UserStatus.ToString()));

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]));
            var token = new JwtSecurityToken(
                issuer: configuration["JWT:ValidIssuer"],
                audience: configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256)
            );

            return Ok(new
            {
                status = "Success",
                user = user.UserName,
                roles = roles,
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expiration = token.ValidTo
            });
        }

        return Unauthorized();
    }

    // PUT api/<UserAuthController>/5
    [HttpPost]
    public void Put(int id, [FromBody] string value)
    {

    }
}
