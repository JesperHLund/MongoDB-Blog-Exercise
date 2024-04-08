using Microsoft.AspNetCore.Mvc;
using MongoDB_Blog_Exercise.Models;
using MongoDB_Blog_Exercise.Database;

namespace MongoDB_Blog_Exercise.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BlogController : ControllerBase
    {
        
        private readonly ILogger<BlogController> _logger;
        private Blog _blog;
        //private Database.Database _database;
        private TempDatabase _database;

        public BlogController(ILogger<BlogController> logger)
        {
            _logger = logger;
        }

        //httppost to create a blog
        [HttpPost]
        public IActionResult CreateBlog([FromBody] Blog blog)
        {
            //create a new blog 
            if (_database.AddBlog(blog))
            {
                return Ok(blog);
            }
            else
            {
                return BadRequest("Creating blog failed");
            }           
        }
    }
}
