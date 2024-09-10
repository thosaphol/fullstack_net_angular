using Api.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly AppDbContext _dbContext;

        public StudentsController(AppDbContext dbContext){
            _dbContext = dbContext;
        }
        
        [HttpGet]
        public string SayHi(){
            return "Hi";
        }
    }
}
