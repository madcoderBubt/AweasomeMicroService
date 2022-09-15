using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentService.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StudentService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class StudentController : ControllerBase
    {
        StudentDbContext dbContext;
        public StudentController(StudentDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // GET: api/<StudentController>
        [HttpGet]
        public IEnumerable<StudentModel> Get()
        {
            List<StudentModel> model = dbContext.Students.ToList();
            return model;
        }

        // GET api/<StudentController>/5
        [HttpGet("{id}")]
        public StudentModel? Get(int id)
        {
            return dbContext.Students.Find(id);
        }

        // POST api/<StudentController>
        [HttpPost]
        public IActionResult Post([FromBody] StudentModel model)
        {
            if (!ModelState.IsValid) return StatusCode(StatusCodes.Status400BadRequest, new { msg = "Invalid Model data" });

            if (model.StudentId <= 0)
            {
                var userClaim = User.HasClaim(claim => claim.Type == "UserId");
                if (userClaim) model.CreatedBy = Convert.ToInt32(User.FindFirst("UserId")?.Value);
                model.CreatedDate = DateTime.UtcNow;

                dbContext.Students.Add(model);
                dbContext.SaveChanges();

                return Ok(model);
            }
            else return StatusCode(StatusCodes.Status304NotModified, new { msg = "Invalid Data Model." });
        }

        // PUT api/<StudentController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] StudentModel value)
        {
            throw new NotImplementedException();
        }

        // DELETE api/<StudentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
