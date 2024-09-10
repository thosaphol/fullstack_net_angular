using Api.Data;
using Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly AppDbContext _dbContext;

        public StudentsController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IEnumerable<Student>> Get()
        {
            var students = await _dbContext.Students.AsNoTracking().ToListAsync();
            return students;
        }

        [HttpPost]
        public async Task<IActionResult> Create(Student student)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _dbContext.AddAsync<Student>(student);
            var result = await _dbContext.SaveChangesAsync();
            if (result > 0)
            {
                return Ok();
            }

            return BadRequest();

        }
    }
}
